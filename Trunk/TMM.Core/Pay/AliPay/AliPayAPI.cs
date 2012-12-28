using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using TMM.Model;

namespace TMM.Core.Pay
{
    public class AliPay
    {
        int PayWay = 1;//֧������1���Ƹ�ͨ��2������������3���ֹ�֧��10
        private string payErrorUrl = "http://{0}/pay/payError.do?orderId={1}&message={2}";
         protected string payUrl = "https://www.alipay.com/cooperate/gateway.do?";//'֧���ӿ�
       // protected string payUrl = "http://notify.alipay.com/trade/notify_query.do?";  //'֧���ӿ�
        protected string payOkUrl = "http://{0}/pay/payOK.do?orderId={1}";
        protected string returnUrl = "http://{0}/Pay/AliPayReceive.do"; // �̻��Զ��巵�ؽ���֧�������ҳ��
        protected string NotifyUrl = "http://{0}/Pay/AliPayNotify.do"; // �̻��Զ����첽֪ͨҳ��
        string alipayNotifyURL = "https://www.alipay.com/cooperate/gateway.do?service=notify_verify";//��֤��ַ
        string QueryNotifyURL = "http://notify.alipay.com/trade/notify_query.do?service=notify_verify";//֪ͨ��֤��ַ,��������֧��https������������ie״̬��
        protected string key = "d2rb7czc5uxq2keavyfpopsv3098ayrk"; //partner�˻���֧������ȫУ����
        protected string alipayAccount = "7109137@qq.com";// "liu.man@corp.0-6.com";
        protected string partner = "2088502888458253"; //partner		�������ID			�����ֶ�   
        string service = "create_direct_pay_by_user";
        protected string productUrl = "http://{0}";
        string _input_charset = "utf-8";//��������
        string payment_type = "1";                  //֧������	
        string sign_type = "MD5";
        AliPayPackage ap = new AliPayPackage();
        public AliPay()
        {
            string domain = HttpContext.Current.Request.Url.Host;
            returnUrl = returnUrl.Replace("{0}", domain);
            NotifyUrl = NotifyUrl.Replace("{0}", domain);
            payOkUrl = payOkUrl.Replace("{0}", domain);
            payErrorUrl = payErrorUrl.Replace("{0}", domain);
            productUrl = productUrl.Replace("{0}", domain);
        }
        public void Send(string orderNo, string total, string remark,int userId)
        {
           
            //ҵ�������ֵ��
            string gateway = payUrl;	//'֧���ӿ�  
            string subject = remark;	//subject		��Ʒ����
            string body = remark;		//body			��Ʒ����               
            string price = total;
            string quantity = "1";
            string show_url = productUrl;
            string seller_email = alipayAccount;             //�����˺�            
            string return_url = returnUrl; //������֪ͨ���ؽӿ�
            string notify_url = NotifyUrl; //������֪ͨ���ؽӿ�           
            string logistics_type = "EMS";//���﷢�ͷ�ʽ
            string logistics_fee = "0";//���˷���
            string logistics_payment = "BUYER_PAY";//֧����              
            string[] para ={
        "service="+service,
        "partner=" + partner,
        "seller_email=" + seller_email,
        "out_trade_no=" + orderNo,
        "subject=" + subject,
        "body=" + body,
        "total_fee=" + total, 
        "show_url=" + show_url,
        "payment_type=1",
        "notify_url=" + notify_url,
        "return_url=" + return_url,
        "_input_charset="+_input_charset
        };
            //֧��URL����
            string aliay_url = AliPayPackage.CreatUrl(
                gateway,//GET��ʽ���ݲ���ʱ��ȥ��ע��
                para,
                _input_charset,
                sign_type,
                key
                );
            //����֧����¼
            MPayLog payrecordinfo = new MPayLog();
            //Models.MPayLogInfo payrecordinfo = new Models.MPayLogInfo();
            payrecordinfo.PayUrl = aliay_url;
            payrecordinfo.UserId = userId;
            payrecordinfo.OrderId = decimal.Parse(orderNo);
            payrecordinfo.PayMoney = decimal.Parse(total);
            payrecordinfo.TransactionId = orderNo;
            payrecordinfo.PayResult = "100";
            payrecordinfo.PayWay = PayWay;
            payrecordinfo.BackUrl = PayReturnUrl;
            payrecordinfo.CreateTime = DateTime.Now;

            TMM.Service.Bll.Order.MPayLogBLL pbll = new TMM.Service.Bll.Order.MPayLogBLL();
            pbll.Insert(payrecordinfo);

            //TMM.Core.Utils.Log4Net.Error(aliay_url);

            HttpContext.Current.Response.Redirect(aliay_url);
            
        }
      
       public void Receive()
       {       

           alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + HttpContext.Current.Request.QueryString["notify_id"];
           //��ȡ֧����ATN���ؽ����true����ȷ�Ķ�����Ϣ��false ����Ч��
          // alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + HttpContext.Current.Request.QueryString["notify_id"];

           //��ȡ֧����ATN���ؽ����true����ȷ�Ķ�����Ϣ��false ����Ч��
           string responseTxt = AliPayPackage.Get_Http(alipayNotifyURL, 120000);
           Utils.Log4Net.Error("֧����ATN���ؽ����" + responseTxt);
           //*******����ǩ������ʼ//*******
           int i;
           System.Collections.Specialized.NameValueCollection coll;
           //Load Form variables into NameValueCollection variable.
           coll = HttpContext.Current.Request.QueryString;

           // Get names of all forms into a string array.
           String[] requestarr = coll.AllKeys;

           //��������
           string[] Sortedstr = AliPayPackage.BubbleSort(requestarr);

           //�����md5ժҪ�ַ��� ��

           StringBuilder prestr = new StringBuilder();

           for (i = 0; i < Sortedstr.Length; i++)
           {
               if (HttpContext.Current.Request.Form[Sortedstr[i]] != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type")
               {
                   if (i == Sortedstr.Length - 1)
                   {
                       prestr.Append(Sortedstr[i] + "=" + HttpContext.Current.Request.QueryString[Sortedstr[i]]);
                   }
                   else
                   {
                       prestr.Append(Sortedstr[i] + "=" + HttpContext.Current.Request.QueryString[Sortedstr[i]] + "&");

                   }
               }
           }

           prestr.Append(key);

           //����Md5ժҪ��
           string mysign = AliPayPackage.GetMD5(prestr.ToString(), _input_charset);
           //*******����ǩ���������*******

           string sign = HttpContext.Current.Request.QueryString["sign"];     
           //  Response.Write(prestr.ToString());  
           MPayLog payrecordinfo = new MPayLog();
           //Models.MPayLogInfo payrecordinfo = new Models.MPayLogInfo();
           payrecordinfo.PayUrl = HttpContext.Current.Request.UrlReferrer + "";//���ص�ַ
           payrecordinfo.OrderId = decimal.Parse(HttpContext.Current.Request.QueryString["out_trade_no"]);
           if (responseTxt=="true")
                payrecordinfo.PayResult = "1";
           else
                payrecordinfo.PayResult = "0";
           payrecordinfo.PayMoney = decimal.Parse(HttpContext.Current.Request.QueryString["total_fee"]);
           payrecordinfo.TransactionId = HttpContext.Current.Request.QueryString["trade_no"];
           payrecordinfo.PayWay = PayWay;
           payrecordinfo.BackUrl = HttpContext.Current.Request.Url.AbsoluteUri;
           payrecordinfo.CreateTime = DateTime.Now;

           TMM.Service.Bll.Order.MPayLogBLL pbll = new TMM.Service.Bll.Order.MPayLogBLL();
           pbll.Insert(payrecordinfo);

           if (mysign == sign && responseTxt == "true")   //��֤֧������������Ϣ��ǩ���Ƿ���ȷ
           {

               //�����Լ����ݿ�Ķ�����䣬���Լ���дһ��

               Service.Bll.Order.TOrderBLL obll = new TMM.Service.Bll.Order.TOrderBLL();
               Service.Bll.User.MAccountBLL abll = new TMM.Service.Bll.User.MAccountBLL();
               TOrder o = obll.GetOrderAndDetail(payrecordinfo.OrderId);
               if (o.Status >= 0 && o.Status < 10) //�¶��� -- �Ѹ��� ֮��Ĺ���
               {
                   //��ֵ
                   abll.AddAmount(payrecordinfo.OrderId, payrecordinfo.PayMoney,Utils.TmmUtils.IPAddress(),this.PayWay);
                   bool expandResult = true;
                   //docidС��0 �����Ϊ���ⶩ������ִ���˻������Ķ���
                   if (o.SingleDetail.DocId > 0)
                   {
                       expandResult = abll.AccountExpend(payrecordinfo.OrderId, Utils.TmmUtils.IPAddress());
                   }

                   if (expandResult)
                   {                     
                       
                       Common.OrderCallBack oCallBack = new TMM.Core.Common.OrderCallBack();
                       oCallBack.UserId = o.UserId;
                       oCallBack.OrderId = o.OrderId;
                       oCallBack.PayWay = PayWay;
                       oCallBack.Status = (int)OrderStatus.IsPaied;
                       oCallBack.PayDetail = "�Ա�֧��";

                       oCallBack.ExecAfterPaid();

                       //
                       payOkUrl = payOkUrl.Replace("{1}", o.OrderId.ToString());
                       HttpContext.Current.Response.Redirect(payOkUrl);
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
               // Response.Write("success");     //���ظ�֧������Ϣ���ɹ�


           }
           else
           {
               
               payErrorUrl = payErrorUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
               payErrorUrl = payErrorUrl.Replace("{2}", "У��ʧ��,֧��ʧ��" + responseTxt);
               HttpContext.Current.Response.Redirect(payErrorUrl);
           }
       }

        public void Notify()
        {
            try
            {
                QueryNotifyURL = QueryNotifyURL + "&partner=" + partner + "&notify_id=" + HttpContext.Current.Request["notify_id"].ToString();
                //��ȡ֧����ATN���ؽ����true����ȷ�Ķ�����Ϣ��false ����Ч��
                // alipayNotifyURL = alipayNotifyURL + "&partner=" + partner + "&notify_id=" + HttpContext.Current.Request.QueryString["notify_id"];

                //��ȡ֧����ATN���ؽ����true����ȷ�Ķ�����Ϣ��false ����Ч��
                string responseTxt = AliPayPackage.Get_Http(QueryNotifyURL, 120000);

                //*******����ǩ������ʼ//*******
                int i;
                System.Collections.Specialized.NameValueCollection coll;
                //Load Form variables into NameValueCollection variable.
                coll = HttpContext.Current.Request.Form;

                // Get names of all forms into a string array.
                String[] requestarr = coll.AllKeys;

                //��������
                string[] Sortedstr = AliPayPackage.BubbleSort(requestarr);

                //�����md5ժҪ�ַ��� ��

                StringBuilder prestr = new StringBuilder();
               // string temp = "";
                for (i = 0; i < Sortedstr.Length; i++)
                {
                    if (RQ(Sortedstr[i]) != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type")
                    {
                        if (i == Sortedstr.Length - 1)
                        {
                            prestr.Append(Sortedstr[i] + "=" + RQ(Sortedstr[i]));
                        }
                        else
                        {
                            prestr.Append(Sortedstr[i] + "=" + RQ(Sortedstr[i]) + "&");

                        }
                    }
                   // temp+=Sortedstr[i];
                }
              //  MamShare.Utils.Log4Net.Error(temp);
                prestr.Append(key);

                //����Md5ժҪ��
                string mysign = AliPayPackage.GetMD5(prestr.ToString(), _input_charset);
                //*******����ǩ���������*******

                
                string sign = RQ("sign");
                //  Response.Write(prestr.ToString());  
                string trade_status = RQ("trade_status");
                MPayLog payrecordinfo = new MPayLog();
                payrecordinfo.PayUrl = QueryNotifyURL;//���ص�ַ
                payrecordinfo.OrderId = decimal.Parse(RQ("out_trade_no"));//HttpContext.Current.Request.QueryString["out_trade_no"]);
                if (responseTxt == "true")
                    payrecordinfo.PayResult = "1";
                else
                    payrecordinfo.PayResult = "0";
                payrecordinfo.PayMoney = decimal.Parse(RQ("total_fee")); //decimal.Parse(HttpContext.Current.Request.QueryString["total_fee"]);
                payrecordinfo.TransactionId = RQ("trade_no"); //HttpContext.Current.Request.QueryString["trade_no"];
                payrecordinfo.PayWay = PayWay;
                payrecordinfo.BackUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                payrecordinfo.CreateTime = DateTime.Now;
                TMM.Service.Bll.Order.MPayLogBLL pbll = new TMM.Service.Bll.Order.MPayLogBLL();
                pbll.Insert(payrecordinfo);

                if (responseTxt == "true")   //��֤֧������������Ϣ��ǩ���Ƿ���ȷ
                {

                    //�����Լ����ݿ�Ķ�����䣬���Լ���дһ��
                    if (trade_status == "TRADE_FINISHED" || trade_status == "TRADE_SUCCESS")
                    {
                        Service.Bll.Order.TOrderBLL obll = new TMM.Service.Bll.Order.TOrderBLL();
                        Service.Bll.User.MAccountBLL abll = new TMM.Service.Bll.User.MAccountBLL();
                        TOrder o = obll.GetOrderAndDetail(payrecordinfo.OrderId);
                        if (o.Status >= 0 && o.Status < 10) //�¶��� -- �Ѹ��� ֮��Ĺ���
                        {
                            //��ֵ
                            abll.AddAmount(payrecordinfo.OrderId, payrecordinfo.PayMoney, Utils.TmmUtils.IPAddress(), this.PayWay);
                            bool expandResult = true;
                            //docidС��0 �����Ϊ���ⶩ������ִ���˻������Ķ���
                            if (o.SingleDetail.DocId > 0)
                            {
                                expandResult = abll.AccountExpend(payrecordinfo.OrderId, Utils.TmmUtils.IPAddress());
                            }

                            
                            if (expandResult)
                            {
                                Common.OrderCallBack oCallBack = new TMM.Core.Common.OrderCallBack();
                                oCallBack.UserId = o.UserId;
                                oCallBack.OrderId = o.OrderId;
                                oCallBack.PayWay = PayWay;
                                oCallBack.Status = (int)OrderStatus.IsPaied;
                                oCallBack.PayDetail = "�Ա�֧��";

                                oCallBack.ExecAfterPaid();
                                Utils.Log4Net.Error(string.Format("֧�����ӿ��첽���ûص������ɹ�����ת��URL��{0}", payOkUrl));
                                
                            }
                            else
                            {
                                payErrorUrl = payErrorUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                                payErrorUrl = payErrorUrl.Replace("{2}", "�˻����㣡");

                            }
                        }
                    }
                    HttpContext.Current.Response.Write("success");
                    // Response.Write("success");     //���ظ�֧������Ϣ���ɹ�


                }
                else
                {
                    //HttpContext.Current.Response.Write("------------------------------------------");
                    //HttpContext.Current.Response.Write("<br>Result:responseTxt=" + responseTxt);
                    //HttpContext.Current.Response.Write("<br>Result:mysign=" + mysign);
                    //HttpContext.Current.Response.Write("<br>Result:sign=" + sign);
                    //HttpContext.Current.Response.Write("fail");
                    payErrorUrl = payErrorUrl.Replace("{1}", payrecordinfo.OrderId.ToString());
                    payErrorUrl = payErrorUrl.Replace("{2}", "У��ʧ��,֧��ʧ��" + responseTxt);
                    HttpContext.Current.Response.Write("fail");
                    //  HttpContext.Current.Response.Redirect(payErrorUrl);
                }
            }
            catch(Exception e)
            {
                Utils.Log4Net.Error(e);
                HttpContext.Current.Response.Write("fail");
            }
        }
        /// <summary>
        /// request����
        /// </summary>
        /// <param name="pname"></param>
        /// <returns></returns>
        public string RQ(string pname)
        {
            try
            {
                return HttpContext.Current.Request[pname].ToString();
            }
            catch
            {
                return "";
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
       public string PayReturnUrl
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
