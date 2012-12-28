using System;
using System.Data;
using System.Configuration;
using System.Web;
using TMM.Model;

namespace TMM.Core.Pay
{
    public class ChinaBankPay
    {
        int PayWay = 3;//֧������1���Ƹ�ͨ��2������������3���ֹ�֧��10
        private string payErrorUrl = "http://{0}/pay/payError.do?orderId={1}&message={2}";
        protected string payUrl = "https://pay3.chinabank.com.cn/PayGate";
        protected string payOkUrl = "http://{0}/pay/payOK.do?orderId={1}";
        protected string v_url = "http://{0}/Pay/ChinaBankReceive.do"; // �̻��Զ��巵�ؽ���֧�������ҳ��
        protected string v_amount;       // �������
        protected string v_moneytype = "CNY";
        protected string v_md5info;      // ��ƴ�մ�MD5˽Կ���ܺ��ֵ
        protected string v_mid = "21837738";// �̻��ţ�����Ϊ�����̻���20000400���滻Ϊ�Լ����̻��ż���        
        protected string v_oid;		 // �Ƽ������Ź��ɸ�ʽΪ ������-�̻���-Сʱ������
        string key = "mall7804jhsl9389ijfk3533";				 // �������û������MD5��Կ���½����Ϊ���ṩ�̻���̨����ַ��https://merchant3.chinabank.com.cn/
        protected string v_remark1;
        protected string v_pstatus;	// ֧��״̬��
        //20��֧���ɹ�����ʹ��ʵʱ���п����пۿ�Ķ�������
        //30��֧��ʧ�ܣ���ʹ��ʵʱ���п����пۿ�Ķ�������
        protected string v_pstring;	//֧��״̬����
        protected string v_pmode;	//֧������
        protected string remark1;	// ��ע1
        protected string remark2 = "url:=http://{0}/pay/ChinaBankNotify.do";	// ��ע2,�첽����
        protected string v_md5str;
        
        public  ChinaBankPay()
        {
            string domain = HttpContext.Current.Request.Url.Host;
            v_url = v_url.Replace("{0}", domain);
            payOkUrl = payOkUrl.Replace("{0}", domain);
            payErrorUrl = payErrorUrl.Replace("{0}", domain);
            remark2 = remark2.Replace("{0}", domain);
        }
        public void Send(string orderNo, string total, string remark)
        {
          
            v_oid = orderNo;
            if (v_oid == null || v_oid.Equals(""))
            {
                return;
            }
            v_amount = total;            
            string text = v_amount + v_moneytype + v_oid + v_mid + v_url + key; // ƴ�ռ��ܴ�
            v_md5info = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(text, "md5").ToUpper();
            v_remark1 = remark;
            string para = "";
            para += "v_mid=" + v_mid;
            para += "&v_url=" + v_url;
            para += "&v_oid=" + v_oid;
            para += "&v_amount=" + v_amount;
            para += "&v_moneytype=" + v_moneytype;
            para += "&v_md5info=" + v_md5info;
            para += "&v_remark1=" + v_remark1;
            para += "&remark2=" + remark2;
            payUrl += "?" + para;

            MPayLog payrecordinfo = new MPayLog();
            payrecordinfo.PayUrl = payUrl;
            payrecordinfo.OrderId = decimal.Parse(orderNo);
            payrecordinfo.PayMoney = decimal.Parse(v_amount);
            payrecordinfo.TransactionId = orderNo;
            payrecordinfo.PayResult = "100";
            payrecordinfo.PayWay = PayWay;           
            payrecordinfo.BackUrl = BackUrl;

            TMM.Service.Bll.Order.MPayLogBLL pbll = new TMM.Service.Bll.Order.MPayLogBLL();            
            pbll.Insert(payrecordinfo);

            HttpContext.Current.Response.Redirect(payUrl);
           
            
        }
        /// <summary>
        /// ���ӽ���
        /// </summary>
        public void Receive()
        {

            v_oid = HttpContext.Current.Request["v_oid"];
            v_pstatus = HttpContext.Current.Request["v_pstatus"];
            v_pstring = HttpContext.Current.Request["v_pstring"];
            v_pmode = HttpContext.Current.Request["v_pmode"];
            v_md5str = HttpContext.Current.Request["v_md5str"];
            v_amount = HttpContext.Current.Request["v_amount"];
            v_moneytype = HttpContext.Current.Request["v_moneytype"];
            remark1 = HttpContext.Current.Request["remark1"];
            remark2 = HttpContext.Current.Request["remark2"];

            string str = v_oid + v_pstatus + v_amount + v_moneytype + key;

            str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToUpper();

            MPayLog payrecordinfo = new MPayLog();
            payrecordinfo.PayUrl = HttpContext.Current.Request.UrlReferrer + "";
            payrecordinfo.OrderId = decimal.Parse(v_oid);
            payrecordinfo.PayResult = v_pstatus;
            payrecordinfo.PayMoney = decimal.Parse(v_amount);
            payrecordinfo.TransactionId = v_oid.ToString();
            payrecordinfo.PayWay = PayWay;
            payrecordinfo.BackUrl = HttpContext.Current.Request.Url.ToString();

            TMM.Service.Bll.Order.MPayLogBLL pbll = new TMM.Service.Bll.Order.MPayLogBLL();            
            pbll.Insert(payrecordinfo);
            if (str == v_md5str)
            {

                if (v_pstatus.Equals("20"))
                {

                    Service.Bll.Order.TOrderBLL obll = new TMM.Service.Bll.Order.TOrderBLL();
                    Service.Bll.User.MAccountBLL abll = new TMM.Service.Bll.User.MAccountBLL();
                    TOrder o = obll.Get(payrecordinfo.OrderId);
                    if (o.Status >= 0 && o.Status < 10) //�¶��� -- �Ѹ��� ֮��Ĺ���
                    {
                        abll.AddAmount(payrecordinfo.OrderId, payrecordinfo.PayMoney,Utils.TmmUtils.IPAddress(),this.PayWay);
                        if (abll.AccountExpend(payrecordinfo.OrderId,Utils.TmmUtils.IPAddress()))
                        {
                            
                            //Web.Common.OrderCallBack oCallBack = new MamShare.Mall.Web.Common.OrderCallBack(
                            //    o.UserId, o.OrderId, PayWay, (int)Models.MOrderStateInfo.������, "ChinaBank֧��");
                            //oCallBack.Update2Paid();
                            //payOkUrl = payOkUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                            //HttpContext.Current.Response.Redirect(payOkUrl);
                            Common.OrderCallBack oCallBack = new TMM.Core.Common.OrderCallBack();
                            oCallBack.UserId = o.UserId;
                            oCallBack.OrderId = o.OrderId;
                            oCallBack.PayWay = PayWay;
                            oCallBack.Status = (int)OrderStatus.IsPaied;
                            oCallBack.PayDetail = "ChinaBank֧��";

                            oCallBack.ExecAfterPaid();
                        }
                        else
                        {
                            payErrorUrl = payErrorUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                            payErrorUrl = payErrorUrl.Replace("{2}", "�˻����㣡");
                        }
                    }
                    
                    else
                    {
                        Utils.Log4Net.Error(string.Format("֧���ӿ�ֱ�ӵ��ûص�������ʧ�ܡ�����ת��URL��{0}", payOkUrl));
                        payErrorUrl = payErrorUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                        payErrorUrl = payErrorUrl.Replace("{2}", "��������");
                    }
                }
            }
            else
            {
                payErrorUrl = payErrorUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                payErrorUrl = payErrorUrl.Replace("{2}", "У��ʧ��,���ݿ���");
                HttpContext.Current.Response.Redirect(payErrorUrl);
                //  HttpContext.Current.Response.Write("У��ʧ��,���ݿ���");
            }
        }
        /// <summary>
        /// �첽֪ͨ
        /// </summary>
        public void Notify()
        {
            v_oid = HttpContext.Current.Request["v_oid"];
            v_pstatus = HttpContext.Current.Request["v_pstatus"];
            v_pstring = HttpContext.Current.Request["v_pstring"];
            v_pmode = HttpContext.Current.Request["v_pmode"];
            v_md5str = HttpContext.Current.Request["v_md5str"];
            v_amount = HttpContext.Current.Request["v_amount"];
            v_moneytype = HttpContext.Current.Request["v_moneytype"];
            remark1 = HttpContext.Current.Request["remark1"];
            remark2 = HttpContext.Current.Request["remark2"];

            string str = v_oid + v_pstatus + v_amount + v_moneytype + key;

            str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToUpper();

            MPayLog payrecordinfo = new MPayLog();
            payrecordinfo.PayUrl = HttpContext.Current.Request.UrlReferrer + "";
            payrecordinfo.OrderId = decimal.Parse(v_oid);
            payrecordinfo.PayResult = v_pstatus;
            payrecordinfo.PayMoney = decimal.Parse(v_amount);
            payrecordinfo.TransactionId = v_oid.ToString();
            payrecordinfo.PayWay = PayWay;
            payrecordinfo.BackUrl = HttpContext.Current.Request.Url.ToString();

            TMM.Service.Bll.Order.MPayLogBLL pbll = new TMM.Service.Bll.Order.MPayLogBLL();  
            pbll.Insert(payrecordinfo);
            if (str == v_md5str)
            {

                if (v_pstatus.Equals("20"))
                {
                    string domain = HttpContext.Current.Request.Url.Host;
                    //ȷ����m6go�µĶ���
                    if (remark2.ToLower().Contains(domain.ToLower()) == true)
                    {
                        Service.Bll.Order.TOrderBLL obll = new TMM.Service.Bll.Order.TOrderBLL();
                        Service.Bll.User.MAccountBLL abll = new TMM.Service.Bll.User.MAccountBLL();
                        TOrder o = obll.Get(payrecordinfo.OrderId);
                        if (o.Status >= 0 && o.Status < 10) //�¶��� -- �Ѹ��� ֮��Ĺ���
                        {
                            abll.AddAmount(payrecordinfo.OrderId, payrecordinfo.PayMoney,Utils.TmmUtils.IPAddress(),this.PayWay);
                            if (abll.AccountExpend(payrecordinfo.OrderId,Utils.TmmUtils.IPAddress()))
                            {
                                
                                //Web.Common.OrderCallBack oCallBack = new MamShare.Mall.Web.Common.OrderCallBack(
                                //    o.UserId, o.OrderId, PayWay, (int)Models.MOrderStateInfo.������, "ChinaBank֧��");
                                //oCallBack.Update2Paid();
                                //payOkUrl = payOkUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                                //HttpContext.Current.Response.Redirect(payOkUrl);
                                Common.OrderCallBack oCallBack = new TMM.Core.Common.OrderCallBack();
                                oCallBack.UserId = o.UserId;
                                oCallBack.OrderId = o.OrderId;
                                oCallBack.PayWay = PayWay;
                                oCallBack.Status = (int)OrderStatus.IsPaied;
                                oCallBack.PayDetail = "ChinaBank֧��";

                                oCallBack.ExecAfterPaid();
                            }
                            else
                            {
                                payErrorUrl = payErrorUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                                payErrorUrl = payErrorUrl.Replace("{2}", "�˻����㣡");
                                HttpContext.Current.Response.Redirect(payErrorUrl);
                            }
                        }
                    }
                    HttpContext.Current.Response.Write("ok");
                }
                else
                    HttpContext.Current.Response.Write("error");
            }
            else
            {
                payErrorUrl = payErrorUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                payErrorUrl = payErrorUrl.Replace("{2}", "У��ʧ��,���ݿ���");
                HttpContext.Current.Response.Write("error");
                // HttpContext.Current.Response.Redirect(payErrorUrl);
                //  HttpContext.Current.Response.Write("У��ʧ��,���ݿ���");
            }
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
            get { return this.v_url; }
            set { this.v_url = value; }
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
