            �q�����������������������������������������������r
  �q����������           ֧��������ʾ���ṹ˵��             �����������r
  ��        �t�����������������������������������������������s        ��
����                                                                  ��
����     �ӿ����ƣ�֧������ʱ���ʽӿڣ�create_direct_pay_by_user��    ��
������   ����汾��3.1                                                ��
  ��     �������ԣ�JAVA                                               ��
  ��     ��    Ȩ��֧�������й������缼�����޹�˾                     ��
����     �� �� �ߣ�֧�����̻���ҵ������֧����                         ��
  ��     ��ϵ��ʽ���̻�����绰0571-88158090                          ��
  ��                                                                  ��
  �t�������������������������������������������������������������������s

��������������
 �����ļ��ṹ
��������������

js_jsp_gb
  ��
  ��src�����������������������������������ļ���
  ��  ��
  ��  ��com.alipay.config
  ��  ��  ��
  ��  ��  ��AlipayConfig.java����������������Ϣ�����������ļ�
  ��  ��
  ��  ��com.alipay.util
  ��  ��  ��
  ��  ��  ��AlipayFunction.java�����������ú������ļ�
  ��  ��  ��
  ��  ��  ��AlipayNotify.java����������֧����֪ͨ�������ļ�
  ��  ��  ��
  ��  ��  ��AlipayService.java ��������֧�������������ļ�
  ��  ��  ��
  ��  ��  ��Md5Encrypt.java������������MD5ǩ�����ļ�
  ��  ��  ��
  ��  ��  ��UtilDate.java���������������Զ��嶩�����ļ�
  ��  ��
  ��  ��filters�������������������������������ļ��У�����ʱɾ����
  ��
  ��WebRoot����������������������������ҳ���ļ���
  ��  ��
  ��  ��images ������������������������ͼƬ��CSS��ʽ�ļ���
  ��  ��
  ��  ��alipayto.jsp ������������������֧�����ӿ�����ļ�
  ��  ��
  ��  ��index.jsp�������������������������ٸ������ģ���ļ�
  ��  ��
  ��  ��notify_url.jsp �����������������������첽֪ͨҳ���ļ�
  ��  ��
  ��  ��return_url.jsp ����������������ҳ����תͬ��֪ͨ�ļ�
  ��
  ��readme.txt ������������������ʹ��˵���ı�

��ע���
��Ҫ���õ��ļ��ǣ�alipay_config.jsp��alipayto.jsp
���ð���com.alipay.config.*��com.alipay.util.*

index.jsp����֧�����ṩ�ĸ������ģ���ļ�����ѡ��ʹ�á�
����̻���վ����ҵ��������Ҫʹ�ã����alipayto.jsp��Ϊ���̻���վ��վ���ν�ҳ�档
�����Ҫʹ��index.jsp����ôalipayto.jsp�ļ�������ģ�ֻ�����ú�alipay_config.java�ļ�
�õ�index.jspҳ�����̻���վ�е�HTTP·���������̻���վ����Ҫ��λ�ã�����ֱ��ʹ��֧�����ӿڡ�

public static void LogResult(String sWord)
��������Ҫ������־�ļ�����ʱ���ڵ����ϵľ���·����



������������������
 ���ļ������ṹ
������������������

alipay_function.java

public static String BuildMysign(Map sArray, String key)
���ܣ�����ǩ�����
���룺Map    sArray Ҫǩ��������
      String key ��ȫУ����
�����String ǩ������ַ���

public static Map ParaFilter(Map sArray)
���ܣ���ȥ�����еĿ�ֵ��ǩ������
���룺Map    sArray Ҫǩ��������
�����Map    ȥ����ֵ��ǩ�����������ǩ��������

public static String CreateLinkString(Map params)
���ܣ�����������Ԫ�أ����ա�����=����ֵ����ģʽ�á�&���ַ�ƴ�ӳ��ַ���
���룺Map    params ��Ҫƴ�ӵ�����
�����String ƴ������Ժ���ַ���

public static String query_timestamp(String partner)
���ܣ����ڷ����㣬���ýӿ�query_timestamp����ȡʱ����Ĵ�����
���룺String partner ���������ID
�����String ʱ����ַ���

public static void LogResult(String sWord)
���ܣ�д��־��������ԣ�����վ����Ҳ���Ըĳɴ������ݿ⣩
���룺String sWord Ҫд����־����ı�����

��������������������������������������������������������������

Md5Encrypt.java

public static String md5(String text)
���ܣ�MD5ǩ��
���룺String sMessage Ҫǩ�����ַ���
�����String ǩ�����

��������������������������������������������������������������

alipay_notify.java

public static String GetMysign(Map Params, String key)
���ܣ����ݷ�����������Ϣ������ǩ�����
���룺Map    Params ֪ͨ�������Ĳ�������
      String key ��ȫУ����
�����String ǩ�����

public static String Verify(String notify_id)
���ܣ���ȡԶ�̷�����ATN���,��֤����URL
���룺String notify_id ��֤֪ͨID
�����String ��֤���

public static String CheckUrl(String urlvalue)
���ܣ���ȡԶ�̷�����ATN���
���룺String urlvalue ָ��URL·����ַ
�����String ������ATN����ַ���

��������������������������������������������������������������

alipay_service.java

public static String BuildForm(String partner,
	String seller_email,
	String return_url,
	String notify_url,
	String show_url,
	String out_trade_no,
	String subject,
	String body,
	String total_fee,
	String paymethod,
	String defaultbank,
	String encrypt_key,
	String exter_invoke_ip,
	String extra_common_param,
	String buyer_email,
	String royalty_type,
	String royalty_parameters,
	String it_b_pay,
        String input_charset,
        String key,
        String sign_type)
���ܣ�������ύHTML
���룺String partner ���������ID
      String seller_email ǩԼ֧�����˺Ż�����֧�����ʻ�
      String return_url ��������ת��ҳ�� Ҫ�� ��http��ͷ��ʽ������·�����������?id=123�����Զ������
      String notify_url ���׹����з�����֪ͨ��ҳ�� Ҫ�� ��http����ʽ������·�����������?id=123�����Զ������
      String show_url ��վ��Ʒ��չʾ��ַ���������?id=123�����Զ������
      String out_trade_no �������վ����ϵͳ�е�Ψһ������ƥ��
      String subject �������ƣ���ʾ��֧��������̨��ġ���Ʒ���ơ����ʾ��֧�����Ľ��׹���ġ���Ʒ���ơ����б��
      String body ����������������ϸ��������ע����ʾ��֧��������̨��ġ���Ʒ��������
      String total_fee �����ܽ���ʾ��֧��������̨��ġ�Ӧ���ܶ��
      String paymethod Ĭ��֧����ʽ���ĸ�ֵ��ѡ��bankPay(����); cartoon(��ͨ); directPay(���); CASH(����֧��)
      String defaultbank Ĭ���������ţ������б��club.alipay.com/read.php?tid=8681379
      String encrypt_key ������ʱ���
      String exter_invoke_ip ��ұ��ص��Ե�IP��ַ
      String extra_common_param �Զ���������ɴ���κ����ݣ����������ַ��⣩��������ʾ��ҳ����
      String buyer_email Ĭ�����֧�����˺�
      String royalty_type ������ͣ���ֵΪ�̶�ֵ��10������Ҫ�޸�
      String royalty_parameters �����Ϣ��������Ҫ����̻���վ���������̬��ȡÿ�ʽ��׵ĸ������տ��˺š��������������˵�������ֻ������10��
      String it_b_pay ��ʱʱ�䣬����Ĭ����15�졣�˸�ֵ��ѡ��1h(1Сʱ),2h(2Сʱ),3h(3Сʱ),1d(1��),3d(3��),7d(7��),15d(15��),1c(����)
      String key ��ȫ������
      String input_charset �ַ������ʽ Ŀǰ֧�� gbk �� utf-8
      String sign_type ǩ����ʽ �����޸�
�����String ���ύHTML�ı�

��������������������������������������������������������������

UtilDate.java

public  static String getOrderNum()
���ܣ��Զ����������ţ���ʽyyyyMMddHHmmss
�����String ������

public  static String getDateFormatter()
���ܣ���ȡ���ڣ���ʽ��yyyy-MM-dd HH:mm:ss
�����String ����

public static String getDate()
���ܣ���ȡ���ڣ���ʽ��yyyyMMdd
�����String ����

public static String getThree()
���ܣ������������λ��
�����String �����λ��



��������������������
 ��������������
��������������������

�ڼ����ĵ�����������б����������������������ҵ�������ԭ��Ҫ������Щ��������ô���԰�������Ĳ�������������ӿڹ��ܡ�

�������Բ���it_b_payΪ��������


��һ����com.alipay.util�ļ����µ�AlipayService.java�ļ�

�ҵ�BuildForm�Ĺ�����ύHTML�������������������,String it_b_pay����
�ڴ��롰Map sPara = new HashMap();�����·���ǩ������sPara����Ԫ�ء�sPara.put("it_b_pay", it_b_pay);��

�磺
////////////////////////////////////////////////
	/**
	 * ���ܣ�������ύHTML
	 * @param partner ���������ID
	 * @param seller_email ǩԼ֧�����˺Ż�����֧�����ʻ�
	 * @param return_url ��������ת��ҳ�� Ҫ�� ��http��ͷ��ʽ������·�����������?id=123�����Զ������
	 * @param notify_url ���׹����з�����֪ͨ��ҳ�� Ҫ�� ��http����ʽ������·�����������?id=123�����Զ������
	 * @param show_url ��վ��Ʒ��չʾ��ַ���������?id=123�����Զ������
	 * @param out_trade_no �������վ����ϵͳ�е�Ψһ������ƥ��
	 * @param subject �������ƣ���ʾ��֧��������̨��ġ���Ʒ���ơ����ʾ��֧�����Ľ��׹���ġ���Ʒ���ơ����б��
	 * @param body ����������������ϸ��������ע����ʾ��֧��������̨��ġ���Ʒ��������
	 * @param total_fee �����ܽ���ʾ��֧��������̨��ġ�Ӧ���ܶ��
	 * @param paymethod Ĭ��֧����ʽ���ĸ�ֵ��ѡ��bankPay(����); cartoon(��ͨ); directPay(���);  CASH(����֧��)
	 * @param defaultbank Ĭ���������ţ������б��club.alipay.com/read.php?tid=8681379
	 * @param encrypt_key ������ʱ���
	 * @param exter_invoke_ip ��ұ��ص��Ե�IP��ַ
	 * @param extra_common_param �Զ���������ɴ���κ����ݣ����������ַ��⣩��������ʾ��ҳ����
	 * @param buyer_email Ĭ�����֧�����˺�
	 * @param royalty_type ������ͣ���ֵΪ�̶�ֵ��10������Ҫ�޸�
	 * @param royalty_parameters �����Ϣ��������Ҫ����̻���վ���������̬��ȡÿ�ʽ��׵ĸ������տ��˺š��������������˵�������ֻ������10��
	 * @param it_b_pay ��ʱʱ�䣬����Ĭ����15�졣�˸�ֵ��ѡ��1h(1Сʱ),2h(2Сʱ),3h(3Сʱ),1d(1��),3d(3��),7d(7��),15d(15��),1c(����)
	 * @param input_charset �ַ������ʽ Ŀǰ֧�� GBK �� utf-8
	 * @param key ��ȫУ����
	 * @param sign_type ǩ����ʽ �����޸�
	 * @return ���ύHTML�ı�
	 */
	public static String BuildForm(String partner,
			String seller_email,
			String return_url,
			String notify_url,
			String show_url,
			String out_trade_no,
			String subject,
			String body,
			String total_fee,
			String paymethod,
			String defaultbank,
			String anti_phishing_key,
			String exter_invoke_ip,
			String extra_common_param,
            		String buyer_email,
			String royalty_type,
			String royalty_parameters,
			String it_b_pay,
            		String input_charset,
            		String key,
			String sign_type){
		Map sPara = new HashMap();
		sPara.put("service","create_direct_pay_by_user");
		sPara.put("payment_type","1");
		sPara.put("partner", partner);
		sPara.put("seller_email", seller_email);
		sPara.put("return_url", return_url);
		sPara.put("notify_url", notify_url);
		sPara.put("_input_charset", input_charset);
		sPara.put("show_url", show_url);
		sPara.put("out_trade_no", out_trade_no);
		sPara.put("subject", subject);
		sPara.put("body", body);
		sPara.put("total_fee", total_fee);
		sPara.put("paymethod", paymethod);
		sPara.put("defaultbank", defaultbank);
		sPara.put("anti_phishing_key", anti_phishing_key);
		sPara.put("exter_invoke_ip", exter_invoke_ip);
		sPara.put("extra_common_param", extra_common_param);
		sPara.put("buyer_email", buyer_email);
		sPara.put("royalty_type", royalty_type);
		sPara.put("royalty_parameters", royalty_parameters);
		sPara.put("it_b_pay", it_b_pay);
		
		Map sParaNew = AlipayFunction.ParaFilter(sPara); //��ȥ�����еĿ�ֵ��ǩ������
		String mysign = AlipayFunction.BuildMysign(sParaNew, key);//����ǩ�����
		
		StringBuffer sbHtml = new StringBuffer();
		List keys = new ArrayList(sParaNew.keySet());
		String gateway = "https://www.alipay.com/cooperate/gateway.do?";
		
		//GET��ʽ����
		sbHtml.append("<form id=\"alipaysubmit\" name=\"alipaysubmit\" action=\"" + gateway + "_input_charset=" + input_charset + "\" method=\"get\">");
		//POST��ʽ���ݣ�GET��POST����ѡһ��
		//sbHtml.append("<form id=\"alipaysubmit\" name=\"alipaysubmit\" action=\"" + gateway + "_input_charset=" + input_charset + "\" method=\"post\">");
		
		for (int i = 0; i < keys.size(); i++) {
			String name = (String) keys.get(i);
			String value = (String) sParaNew.get(name);
			
			sbHtml.append("<input type=\"hidden\" name=\"" + name + "\" value=\"" + value + "\"/>");
		}
        sbHtml.append("<input type=\"hidden\" name=\"sign\" value=\"" + mysign + "\"/>");
        sbHtml.append("<input type=\"hidden\" name=\"sign_type\" value=\"" + sign_type + "\"/>");
        
        //submit��ť�ؼ��벻Ҫ����name����
        sbHtml.append("<input type=\"submit\" value=\"֧����ȷ�ϸ���\"></form>");
        
        sbHtml.append("<script>document.forms['alipaysubmit'].submit();</script>");
		
		return sbHtml.toString();
	}
////////////////////////////////////////////////


�ڶ�������alipayto.aspx.cs�ļ�

��ע�͡�//���²�������Ҫͨ���µ�ʱ�Ķ������ݴ��������á��롰//////////�������֮��������������

�磺
////////////////////////////////////////////////
//��չ���ܲ��������Զ��峬ʱ(��Ҫʹ�ã��밴��ע��Ҫ��ĸ�ʽ��ֵ)
//�ù���Ĭ�ϲ���ͨ��
//���뿪ͨ��ʽ��
//��ʽһ����ϵ֧��������֧�����봦��
//��ʽ��������0571-88158090����
//��ʽ�����ύ�������루https://b.alipay.com/support/helperApply.htm?action=consultationApply��
String it_b_pay = "";
//��ʱʱ�䣬����Ĭ����15�졣���÷�Χ��1m~15d��,-�ָ�����~-��Χ �� m-���ӣ�h-Сʱ��d-�죬1c-���죨���ۺ�ʱ���������׶���0��رգ�
//�磺it_b_pay = "1m~1h,2h,3h,1c";
////////////////////////////////////////////////

�ڡ�����Ҫ����Ĳ������飬����Ķ���ע���·��ġ�String sHtmlText = AlipayService.BuildForm�����������������������,it_b_pay��

�磺
////////////////////////////////
String sHtmlText = AlipayService.BuildForm(partner,seller_email,return_url,notify_url,show_url,out_trade_no,
subject,body,total_fee,paymethod,defaultbank,anti_phishing_key,exter_invoke_ip,extra_common_param,buyer_email,
royalty_type,royalty_parameters,it_b_pay,input_charset,key,sign_type);
////////////////////////////////


��������������������
 �������⣬��������
��������������������

����ڼ���֧�����ӿ�ʱ�������ʻ�������⣬��ʹ����������ӣ��ύ���롣
https://b.alipay.com/support/helperApply.htm?action=supportHome
���ǻ���ר�ŵļ���֧����ԱΪ������




