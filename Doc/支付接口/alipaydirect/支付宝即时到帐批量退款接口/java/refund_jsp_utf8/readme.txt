                  �q�����������������������������������������������r
  �q����������������           ֧��������ʾ���ṹ˵��             �����������������r
  ��              �t�����������������������������������������������s              ��
����                                                                              ��
����     �ӿ����ƣ�֧������ʱ���������˿�ӿڣ�refund_fastpay_by_platform_pwd��   ��
������   ����汾��3.1                                                            ��
  ��     �������ԣ�JAVA                                                           ��
  ��     ��    Ȩ��֧�������й������缼�����޹�˾                                 ��
����     �� �� �ߣ�֧�����̻���ҵ������֧����                                     ��
  ��     ��ϵ��ʽ���̻�����绰0571-88158090                                      ��
  ��                                                                              ��
  �t�������������������������������������������������������������������������������s

��������������
 �����ļ��ṹ
��������������

refund_jsp_utf8
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
  ��  ��  ��AlipayRefundService.java ��֧�������������ļ�
  ��  ��  ��
  ��  ��  ��Md5Encrypt.java������������MD5ǩ�����ļ�
  ��  ��  ��
  ��  ��  ��UtilDate.java���������������Զ��嶩�����ļ�
  ��  ��
  ��  ��filters�������������������������������ļ��У�����ʱɾ����
  ��
  ��WebRoot����������������������������ҳ���ļ���
  ��  ��
  ��  ��refund.jsp ��������������������֧�����ӿ�����ļ�
  ��  ��
  ��  ��index.jsp���������������������������˿�ģ���ļ�
  ��  ��
  ��  ��notify_url.jsp �����������������������첽֪ͨҳ���ļ�
  ��
  ��readme.txt ������������������ʹ��˵���ı�

��ע���
��Ҫ���õ��ļ��ǣ�alipay_config.jsp��refund.jsp��notify_url.jsp
���ð���com.alipay.config.*��com.alipay.util.*

index.jsp����֧�����ṩ�ĸ������ģ���ļ�����ѡ��ʹ�á�
����̻���վ����ҵ��������Ҫʹ�ã����refund.jsp��Ϊ���̻���վ��վ���ν�ҳ�档
�����Ҫʹ��index.jsp����ôrefund.jsp�ļ�������ģ�ֻ�����ú�alipay_config.java�ļ�
�õ�index.jspҳ�����̻���վ�е�HTTP·���������̻���վ����Ҫ��λ�ã�����ֱ��ʹ��֧�����ӿڡ�

public static void LogResult(String sWord)
��������Ҫ������־�ļ�����ʱ���ڵ����ϵľ���·����



������������������
 ���ļ������ṹ
������������������

AlipayFunction.java

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
���ܣ����ã�Ŀǰ����

public static void LogResult(String sWord)
���ܣ�д��־��������ԣ�����վ����Ҳ���Ըĳɴ������ݿ⣩
���룺String sWord Ҫд����־����ı�����
˵�����ú�������Ҫ������־���ڵ����ϵľ���·��

��������������������������������������������������������������

Md5Encrypt.java

public static String md5(String text)
���ܣ�MD5ǩ��
���룺String sMessage Ҫǩ�����ַ���
�����String ǩ�����

��������������������������������������������������������������

AlipayNotify.java

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

AlipayRefundService.java

public static String BuildForm(String partner,
	String seller_email,
	String notify_url,
	String refund_date,
	String batch_no,
	String batch_num,
	String detail_data,
        String input_charset,
        String key,
        String sign_type)
���ܣ�������ύHTML
���룺String partner ���������ID
      String seller_email ǩԼ֧�����˺Ż�����֧�����ʻ�
      String notify_url ���׹����з�����֪ͨ��ҳ�� Ҫ�� ��http����ʽ������·�����������?id=123�����Զ������
      String refund_date �˿�����ڣ���ȡ�������ڣ���ʽ����[4λ]-��[2λ]-��[2λ] Сʱ[2λ 24Сʱ��]:��[2λ]:��[2λ]���磺2007-10-01 13:13:13
      String batch_no �̼���վ������κţ���֤��Ψһ�ԣ���ʽ����������[8λ]+���к�[3��24λ]���磺201008010000001
      String batch_num �˿������������detail_data��ֵ�У���#���ַ����ֵ�������1�����֧��1000�ʣ�����#���ַ����ֵ�����999����
      String detail_data �˿���ϸ����
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

public static String getTime()
���ܣ���ȡ��ǰʱ�䣬��ʽ��HHmmss
�����String ��ǰʱ��

public static String getThree()
���ܣ������������λ��
�����String �����λ��

��������������������
 �������⣬��������
��������������������

����ڼ���֧�����ӿ�ʱ�������ʻ�������⣬��ʹ����������ӣ��ύ���롣
https://b.alipay.com/support/helperApply.htm?action=supportHome
���ǻ���ר�ŵļ���֧����ԱΪ������




