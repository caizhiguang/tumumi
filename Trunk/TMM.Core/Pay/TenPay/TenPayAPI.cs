using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using TMM.Model;

namespace TMM.Core.Pay
{
    public class TenPay
    {
        int PayWay = 2;//֧������1���Ƹ�ͨ��2������������3���ֹ�֧��10
        private string returnUrl = "http://{0}/pay/TenPayReceive.do";
        private string payOkUrl = "http://{0}/pay/payOK.do?orderId={1}";
        private string payUrl = "https://www.tenpay.com/cgi-bin/v1.0/pay_gate.cgi";
        private string payErrorUrl = "http://{0}/pay/payError.do?orderId={1}&message={2}";
        
        private int chargeType; //1�����ز����������г�ֵ 0��ֱ�ӳ�ֵ

        #region ����
        public int UserId { get; set; }
        #endregion

        /// <summary>
        /// ���캯��
        /// </summary>
        public TenPay()
        {

            string domain = HttpContext.Current.Request.Url.Host;
            returnUrl = returnUrl.Replace("{0}", domain);           
            payOkUrl = payOkUrl.Replace("{0}", domain);
            payErrorUrl=payErrorUrl.Replace("{0}",domain);
            
        }
        //public TenPay()
        //{
        //    string domain = HttpContext.Current.Request.Url.Host;
        //    returnUrl = returnUrl.Replace("{0}", domain).Replace("{1}", chargeType.ToString());  
        //    payOkUrl = payOkUrl.Replace("{0}", domain);
        //    payErrorUrl = payErrorUrl.Replace("{0}", domain);
        //}
        /// <summary>
        /// ����֧������
        /// </summary>
        /// <param name="orderno"></param>
        /// <param name="total"></param>
        /// <param name="remark"></param>
        public void Send(string orderno, string total, string remark)
        {
            Md5Pay p = new Md5Pay();
            p.Paygateurl = payUrl;
            p.Desc = remark;
          
            p.Total_fee = (long)(decimal.Parse(total)*100); 
            p.Sp_billno = orderno;
            p.Attach = "1";
            p.Return_url = returnUrl;
            p.Transaction_id = p.Bargainor_id + p.Date + p.UnixStamp();
            p.Spbill_create_ip =HttpContext.Current.Request.UserHostAddress;
            string url = "";
            
            if (!p.GetPayUrl(out url))
            {
                HttpContext.Current.Response.Write("TenPay Error");
                //labErrmsg.Text = Server.HtmlEncode(url);
            }
            else
            {
                /*��������԰�
                 * ���׵���			md5pay.Transaction_id
                 * �̻�������		md5pay.Sp_billno
                 * �������			md5pay.Total_fee
                 * ����Ϣ�������ݿ�.
                 * */


                MPayLog payrecordinfo = new MPayLog();
                payrecordinfo.PayUrl = url;
                payrecordinfo.OrderId = decimal.Parse(orderno);
                payrecordinfo.PayMoney = decimal.Parse(total);
                payrecordinfo.UserId = this.UserId;
                payrecordinfo.PayResult = "100";
                payrecordinfo.PayWay = PayWay;
                payrecordinfo.TransactionId = p.Transaction_id;
                payrecordinfo.BackUrl = p.Return_url;
                payrecordinfo.CreateTime = DateTime.Now;

                TMM.Service.Bll.Order.MPayLogBLL pbll = new TMM.Service.Bll.Order.MPayLogBLL();
                pbll.Insert(payrecordinfo);

                HttpContext.Current.Response.Redirect(url);
            }
        }
        /// <summary>
        /// ����֧���ɹ�����
        /// </summary>
        public void Receive()
        {
            string suchtml = "<meta content=\"China TENCENT\" name=\"TENCENT_ONLINE_PAYMENT\">\n"
                    + "<script language=\"javascript\">\n"
                    + "window.location.href='" + payOkUrl + "';\n"
                    + "</script>";


            string errmsg = "";

            //string key = "tenpaytesttenpaytesttenpaytest12";
            // string bargainor_id = "1202437801";

            Md5Pay md5pay = new Md5Pay();

            //md5pay.Key = key;
            //md5pay.Bargainor_id = bargainorId;
         
            //�ж�ǩ��
            if (md5pay.GetPayValueFromUrl(HttpContext.Current.Request.QueryString, out errmsg))
            {
                Decimal orderid = 0;
                orderid = Decimal.Parse(md5pay.Sp_billno); 
                MPayLog payrecordinfo = new MPayLog();

                payrecordinfo.PayUrl = HttpContext.Current.Request.UrlReferrer+"";
                payrecordinfo.OrderId = orderid;
                payrecordinfo.PayResult = md5pay.Pay_Result.ToString();
                payrecordinfo.PayMoney = decimal.Parse(md5pay.Total_fee.ToString())/100;
                payrecordinfo.PayWay = PayWay;
                payrecordinfo.TransactionId = md5pay.Transaction_id;
                payrecordinfo.BackUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                payrecordinfo.CreateTime = DateTime.Now;
                TMM.Service.Bll.Order.MPayLogBLL pbll = new TMM.Service.Bll.Order.MPayLogBLL();
                pbll.Insert(payrecordinfo);
                //��֤ǩ���ɹ�
                //֧���ж�
                if (md5pay.Pay_Result == Md5Pay.PAYOK)
                {                   
                    Service.Bll.Order.TOrderBLL obll = new TMM.Service.Bll.Order.TOrderBLL();
                    Service.Bll.User.MAccountBLL abll = new TMM.Service.Bll.User.MAccountBLL();
                    TOrder o = obll.GetOrderAndDetail(payrecordinfo.OrderId);
                    if (o.Status >= 0 && o.Status < 10) //�¶��� -- �Ѹ��� ֮��Ĺ���
                    {                        
                        //��ֵ
                        abll.AddAmount(payrecordinfo.OrderId, payrecordinfo.PayMoney, Utils.TmmUtils.IPAddress(),this.PayWay);
                        
                        bool expandResult = true;
                        //docidС��0 �����Ϊ���ⶩ������ִ���˻������Ķ���
                        if (o.SingleDetail.DocId > 0)
                        {
                            expandResult = abll.AccountExpend(payrecordinfo.OrderId, Utils.TmmUtils.IPAddress());
                        }
                        //�������ûص��ӿ�
                        if (expandResult)
                        {
                            #region �����ص��ӿ�
                            //obll.UpdateOrder2Paid(payrecordinfo.OrderId, PayWay, "�Ƹ�֧ͨ��", (int)Models.MOrderStateInfo.������);
                            Common.OrderCallBack oCallBack = new TMM.Core.Common.OrderCallBack();
                            oCallBack.UserId = o.UserId;
                            oCallBack.OrderId = o.OrderId;
                            oCallBack.PayWay = PayWay;
                            oCallBack.Status = (int)OrderStatus.IsPaied;
                            oCallBack.PayDetail = "�Ƹ�֧ͨ��";

                            oCallBack.ExecAfterPaid();
                            suchtml = suchtml.Replace("{1}", orderid.ToString());
                            //֧���ɹ���ͬ������md5pay.Transaction_id���ܻ���֪ͨ�������ע���ж϶����Ƿ��ظ����߼�
                            //����ҵ���߼�������db֮���
                            //errmsg = "֧���ɹ�";
                            //Response.Write(errmsg+"<br/>");
                            //Response.Write("�Ƹ�ͨ������:"+ md5pay.Transaction_id +"(���μǶ�����)"+"<br/>");	
                            //��ת���ɹ�ҳ�棬�Ƹ�ͨ�յ�<meta content=\"China TENCENT\" name=\"TENCENT_ONLINE_PAYMENT\">����Ϊ֪ͨ�ɹ�
                            payOkUrl = payOkUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                            Utils.Log4Net.Error(string.Format("���Ƹ�ͨ��-��ͬ���ص���-���ɹ���-��{0}��", payOkUrl));
                            HttpContext.Current.Response.Write(suchtml);
                            #endregion

                        }
                        else
                        {
                            Utils.Log4Net.Error(string.Format("���Ƹ�ͨ��-��ͬ���ص���-��ʧ��AccountExpend��-��{0}��", payOkUrl));
                            payErrorUrl = payErrorUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                            payErrorUrl = payErrorUrl.Replace("{2}", "�˻����㣡");
                        }
                    }                    
                    else
                    {
                        Utils.Log4Net.Error(string.Format("���Ƹ�ͨ��-��ͬ���ص���-��ʧ�ܡ�-��{0}��������״̬{1}��", payOkUrl,o.Status));
                        payErrorUrl = payErrorUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                        payErrorUrl = payErrorUrl.Replace("{2}", "��������");
                    }
                }
                else
                {
                    //֧��ʧ�ܣ��벻Ҫ���ɹ�����
                    //  Response.Write(md5pay.Pay_Result+"  "+Md5Pay.PAYOK);
                    payErrorUrl = payErrorUrl.Replace("{1}", md5pay.Sp_billno);
                    payErrorUrl = payErrorUrl.Replace("{2}", "֧��ʧ��" + errmsg);
                    HttpContext.Current.Response.Redirect(payErrorUrl);
                    //HttpContext.Current.Response.Write("֧��ʧ��" + errmsg + "<br/>");                  
                }

            }
            else
            {
                //��֤ǩ��ʧ��
                payErrorUrl = payErrorUrl.Replace("{1}", md5pay.Sp_billno);
                payErrorUrl = payErrorUrl.Replace("{2}", "��֤ǩ��ʧ��");
                HttpContext.Current.Response.Redirect(payErrorUrl);
               // errmsg = "��֤ǩ��ʧ��";
               // HttpContext.Current.Response.Write("��֤ǩ��ʧ��" + "<br/>");
            }
        }

       

        /// <summary>
        /// �Ƹ�ͨ�����첽֪ͨ��ֱ�ӵ��÷��ؽӿ�
        /// </summary>
        public void Notify()
        {
            
        }
        /// <summary>
        /// ֧����ַ��Ĭ��д�ڽӿ���
        /// </summary>
        public string PayUrl
        {
            get { return this.payUrl; }
            set { this.payUrl = value; }
        }
        /// <summary> 
        /// ֧�����ص�ַ��Ĭ��д�ڽӿ���
        /// </summary>
        public string BackUrl
        {
            get { return this.returnUrl; }
            set { this.returnUrl = value; }
        }
        /// <summary>
        /// ֧���ɹ���ַ��Ĭ��д�ڽӿ��У��磺http://www.iyoupiao.com/pay/payshow.do?orderId={0}����ʾ���������ɹ���ַ
        /// </summary>
        public string PayOkUrl
        {
            get { return this.payOkUrl; }
            set { this.payOkUrl = value; }
        }
        /// <summary>
        /// ֧��ʧ�ܵ�ַ��Ĭ��д�ڽӿ��У��磺http://www.iyoupiao.com/pay/payshow.do?orderId={0}&message={1}����ʾ���������ɹ���ַ
        /// </summary>
        public string PayErrorUrl
        {
            get { return this.PayErrorUrl; }
            set { this.payErrorUrl = value; }
        }
    }
}
