                  �q�����������������������������������������������r
  �q����������������           ֧��������ʾ���ṹ˵��             �����������������r
  ��              �t�����������������������������������������������s              ��
����                                                                              ��
����     �ӿ����ƣ�֧������ʱ���������˿�ӿڣ�refund_fastpay_by_platform_pwd��   ��
������   ����汾��3.1                                                            ��
  ��     �������ԣ�ASP.NET(C#)                                                    ��
  ��     ��    Ȩ��֧�������й������缼�����޹�˾                                 ��
����     �� �� �ߣ�֧�����̻���ҵ������֧����                                     ��
  ��     ��ϵ��ʽ���̻�����绰0571-88158090                                      ��
  ��                                                                              ��
  �t�������������������������������������������������������������������������������s

��������������
 �����ļ��ṹ
��������������

refund_vs2005_utf8
  ��
  ��app_code �����������������������ļ���
  ��  ��
  ��  ��alipay_config.cs ��������������Ϣ�����������ļ�
  ��  ��
  ��  ��alipay_function.cs ���������ú������ļ�
  ��  ��
  ��  ��alipay_notify.cs ��������֧����֪ͨ�������ļ�
  ��  ��
  ��  ��alipay_refund_service.cs��֧�������������ļ�
  ��
  ��log����������������������������־�ļ���
  ��
  ��refund.aspx������������������֧�����ӿ�����ļ�
  ��refund.aspx.cs ��������������֧�����ӿ�����ļ�
  ��
  ��default.aspx �����������������˿�ģ���ļ�
  ��default.aspx.cs���������������˿�ģ���ļ�
  ��
  ��notify_url.aspx���������������������첽֪ͨҳ���ļ�
  ��notify_url.aspx.cs �����������������첽֪ͨҳ���ļ�
  ��
  ��Web.Config �����������������������ļ�������ʱɾ����
  ��
  ��readme.txt ������������������ʹ��˵���ı�

��ע���
��Ҫ���õ��ļ��ǣ�alipay_config.cs��refund.aspx��refund.aspx.cs��notify_url.aspx.cs
ͳһ�����ռ�Ϊ��namespace AlipayClass

default.aspx����֧�����ṩ�ĸ������ģ���ļ�����ѡ��ʹ�á�
����̻���վ����ҵ��������Ҫʹ�ã����refund.aspx��Ϊ���̻���վ��վ���ν�ҳ�档
�����Ҫʹ��default.aspx����ôrefund.aspx�ļ�������ģ�ֻ�����ú�alipay_config.cs�ļ�
�õ�default.aspxҳ�����̻���վ�е�HTTP·���������̻���վ����Ҫ��λ�ã�����ֱ��ʹ��֧�����ӿڡ�



������������������
 ���ļ������ṹ
������������������

alipay_function.cs

public static string Build_mysign(Dictionary<string, string> dicArray, string key, string sign_type, string _input_charset)
���ܣ�����ǩ�����
���룺Dictionary<string, string>  dicArray Ҫǩ��������
      string key ��ȫУ����
      string sign_type ǩ������
      string _input_charset �����ʽ
�����string ǩ������ַ���

public static string Create_linkstring(Dictionary<string, string> dicArray)
���ܣ�����������Ԫ�أ����ա�����=����ֵ����ģʽ�á�&���ַ�ƴ�ӳ��ַ���
���룺Dictionary<string, string> dicArray ��Ҫƴ�ӵ�����
�����string ƴ������Ժ���ַ���

public static Dictionary<string, string> Para_filter(SortedDictionary<string, string> dicArrayPre)
���ܣ���ȥ�����еĿ�ֵ��ǩ������������ĸa��z��˳������
���룺SortedDictionary<string, string> dicArrayPre ����ǰ�Ĳ�����
�����Dictionary<string, string>  ȥ����ֵ��ǩ�����������ǩ��������

public static string Sign(string prestr, string sign_type, string _input_charset)
���ܣ�ǩ���ַ���
���룺string prestr ��Ҫǩ�����ַ���
      string sign_type ǩ������
      string _input_charset �����ʽ
�����string ǩ�����

public static string Query_timestamp(string partner)
���ܣ����ڷ����㣬���ýӿ�query_timestamp����ȡʱ����Ĵ�����
���룺string partner ���������ID
�����string ʱ����ַ���
���ܣ����ã�Ŀǰ����

public static void log_result(string sPath, string sWord)
���ܣ�д��־��������ԣ�����վ����Ҳ���Ըĳɴ������ݿ⣩
���룺string sPath ��־�ı��ؾ���·��
      string sWord Ҫд����־����ı�����

��������������������������������������������������������������

alipay_notify.cs

public AlipayNotify(SortedDictionary<string, string> inputPara, string notify_id, string partner, string key, string input_charset, string sign_type, string transport)
���ܣ����캯��
      �������ļ��г�ʼ������
���룺SortedDictionary<string, string> inputPara ֪ͨ�������Ĳ�������
      string notify_id ��֤֪ͨID
      string partner ���������ID
      string key ��ȫУ����
      string input_charset �����ʽ
      string sign_type ǩ������
      string transport ����ģʽ

private string Verify(string notify_id)
���ܣ���֤�Ƿ���֧��������������������
���룺string notify_id ��֤֪ͨID
�����string ��֤���

private string Get_Http(string strUrl, int timeout)
���ܣ���ȡԶ�̷�����ATN���
���룺string strUrl ָ��URL·����ַ
      int timeout ��ʱʱ������
�����string ������ATN����ַ���

��������������������������������������������������������������

alipay_refund_service.cs

public AlipayRefundService(string partner,
            string seller_email,
            string notify_url,
            string refund_date,
            string batch_no,
            string batch_num,
            string detail_data,
            string key,
            string input_charset,
            string sign_type)
���ܣ����캯��
      �������ļ�������ļ��г�ʼ������
���룺string partner ���������ID
      string seller_email ǩԼ֧�����˺Ż�����֧�����ʻ�
      string notify_url ���׹����з�����֪ͨ��ҳ�� Ҫ��http��ʽ������·�����������?id=123�����Զ������
      string refund_date �˿�����ڣ���ȡ�������ڣ���ʽ����[4λ]-��[2λ]-��[2λ] Сʱ[2λ 24Сʱ��]:��[2λ]:��[2λ]���磺2007-10-01 13:13:13
      string batch_no �̼���վ������κţ���֤��Ψһ�ԣ���ʽ����������[8λ]+���к�[3��24λ]���磺201008010000001
      string batch_num �˿������������detail_data��ֵ�У���#���ַ����ֵ�������1�����֧��1000�ʣ�����#���ַ����ֵ�����999����
      string detail_data �˿���ϸ����
      string key ��ȫ������
      string input_charset �ַ������ʽ Ŀǰ֧�� gbk �� utf-8
      string sign_type ǩ����ʽ �����޸�

public string Build_Form()
���ܣ�������ύHTML
�����string ���ύHTML�ı�

��������������������������������������������������������������

notify_url.aspx.cs

public SortedDictionary<string, string> GetRequestPost()
���ܣ���ȡ֧����POST����֪ͨ��Ϣ�����ԡ�������=����ֵ������ʽ�������
�����SortedDictionary<string, string> request��������Ϣ��ɵ�����

��������������������
 �������⣬��������
��������������������

����ڼ���֧�����ӿ�ʱ�������ʻ�������⣬��ʹ����������ӣ��ύ���롣
https://b.alipay.com/support/helperApply.htm?action=supportHome
���ǻ���ר�ŵļ���֧����ԱΪ������




