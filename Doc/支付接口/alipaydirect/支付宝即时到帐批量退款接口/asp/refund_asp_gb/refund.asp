<%
	'���ܣ�֧�����˿�ӿڵ����ҳ�棬��������URL
	'�汾��3.1
	'���ڣ�2010-12-02
	'˵����
	'���´���ֻ��Ϊ�˷����̻����Զ��ṩ���������룬�̻����Ը����Լ���վ����Ҫ�����ռ����ĵ���д,����һ��Ҫʹ�øô��롣
	'�ô������ѧϰ���о�֧�����ӿ�ʹ�ã�ֻ���ṩһ���ο���
	
'''''''''''''''''ע��'''''''''''''''''''''''''
'������ڽӿڼ��ɹ������������⣬
'�����Ե��̻��������ģ�https://b.alipay.com/support/helperApply.htm?action=consultationApply�����ύ���뼯��Э�������ǻ���רҵ�ļ�������ʦ������ϵ��Э�������
'��Ҳ���Ե�֧������̳��http://club.alipay.com/read-htm-tid-8681712.html��Ѱ����ؽ������
'
''''''''''''''''''''''''''''''''''''''''''''''
%>
<!--#include file="alipay_config.asp"-->
<!--#include file="class/alipay_service.asp"-->
<%
'*********************************************�������*********************************************
'�˿�����ڣ���ȡ�������ڣ���ʽ����[4λ]-��[2λ]-��[2λ] Сʱ[2λ 24Сʱ��]:��[2λ]:��[2λ]���磺2007-10-01 13:13:13
sTime=now()
refund_date	= year(sTime)&"-"&right("0" & month(sTime),2)&"-"&right("0" & day(sTime),2)&" "&right("0" & hour(sTime),2)&":"&right("0" & minute(sTime),2)&":"&right("0" & second(sTime),2)

'�̼���վ������κţ���֤��Ψһ�ԣ���ʽ����������[8λ]+���к�[3��24λ]���磺201008010000001
batch_no	= year(sTime)&right("0" & month(sTime),2)&right("0" & day(sTime),2) & hour(sTime)&minute(sTime)&second(sTime)

'�˿������������detail_data��ֵ�У���#���ַ����ֵ�������1�����֧��1000�ʣ�����#���ַ����ֵ�����999����
batch_num	= request.Form("batch_num")

'�˿���ϸ����
detail_data	= request.Form("detail_data")
'��ʽ����һ�ʽ���#�ڶ��ʽ���#�����ʽ���
'��N�ʽ��׸�ʽ�������˿���Ϣ
'�����˿���Ϣ��ʽ��ԭ����֧�������׺�^�˿��ܽ��^�˿�����
'ע�⣺
'1.detail_data�е��˿�����ܺ�Ҫ���ڲ���batch_num��ֵ
'2.detail_data��ֵ�в����С�^������|������$������#����Ӱ��detail_data�ĸ�ʽ�������ַ�
'3.detail_data���˿��ܽ��ܴ��ڽ����ܽ��
'4.һ�ʽ��׿��Զ���˿ֻ��Ҫ���ض���˿���ܽ������ñʽ��׸���ʱ��
'5.��֧���˷�����

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

'����Ҫ����Ĳ������飬����Ķ�
para = Array("service=refund_fastpay_by_platform_pwd","partner="&partner,"seller_email="&seller_email,"notify_url="&notify_url,"refund_date="&refund_date,"batch_no="&batch_no,"batch_num="&batch_num,"detail_data="&detail_data,"_input_charset="&input_charset)

'����������
alipay_service(para)
sHtmlText = build_form()
response.Write sHtmlText

%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>֧�����˿�</title>
</head>
<body>
</body>
</html>
