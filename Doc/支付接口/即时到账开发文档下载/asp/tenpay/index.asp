<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%> 
<!--#include file="./classes/PayRequestHandler.asp"-->
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gbk">
<title>�Ƹ�ͨ��ʱ����֧������ʾ��</title>
</head>
<body>
<%
'---------------------------------------------------------
'�Ƹ�ͨ��ʱ����֧������ʾ�����̻����մ��ĵ����п�������
'---------------------------------------------------------

Dim strDate
Dim strTime
Dim randNumber
Dim strReq

'8λ���ڸ�ʽYYYYmmdd
strDate = getServerDate()

'6λʱ��,��ʽhhmiss
strTime = getTime()

'4λ�����
randNumber = getStrRandNumber(1000,9999)

'10λ���к�,�������е�����
strReq = strTime & randNumber

Dim key
Dim bargainor_id
Dim sp_billno
Dim transaction_id
Dim total_fee
Dim desc
Dim return_url

'��Կ
key = "8934e7d15453e97507ef794cf7b0519d"

'�̻���
bargainor_id = "1900000109"

'���ص�ַ
return_url = "http://localhost/tenpay/return_url.asp"

'�̼Ҷ�����,����������32λ��ȡǰ32λ���Ƹ�ֻͨ��¼�̼Ҷ����ţ�����֤Ψһ��
sp_billno = strReq

'�Ƹ�ͨ���׵��ţ�����Ϊ��10λ�̻���+8λʱ�䣨YYYYmmdd)+10λ��ˮ��,��֤Ψһ��
transaction_id = bargainor_id & strDate & strReq

'��Ʒ�۸񣨰����˷ѣ����Է�Ϊ��λ
total_fee = "1"

'��Ʒ����
desc = "�����ţ�" & transaction_id



'����֧���������
Dim reqHandler
Set reqHandler = new PayRequestHandler

'��ʼ��
reqHandler.init()

'������Կ
reqHandler.setKey(key)

'-----------------------------
'����֧������
'-----------------------------
reqHandler.setParameter "bargainor_id", bargainor_id		'�����̻���
reqHandler.setParameter "sp_billno", sp_billno				'�̻�������
reqHandler.setParameter "transaction_id", transaction_id	'�Ƹ�ͨ���׵���
reqHandler.setParameter "total_fee", total_fee				'��Ʒ�ܽ��,�Է�Ϊ��λ
reqHandler.setParameter "return_url", return_url			'���ص�ַ
reqHandler.setParameter "desc", desc						'��Ʒ����

'�û�ip,���Ի���ʱ��Ҫ�����ip��������ʽ�����ټӴ˲���
reqHandler.setParameter "spbill_create_ip", Request.ServerVariables("REMOTE_ADDR")


'�����URL
Dim reqUrl
reqUrl = reqHandler.getRequestURL()

'debug��Ϣ
'Dim debugInfo
'debugInfo = reqHandler.getDebugInfo()

'Response.Write("<br/>debugInfo:" & debugInfo & "<br/>")

'Response.Write("<br/>reqUrl" & reqUrl & "<br/>")

'�ض��򵽲Ƹ�֧ͨ��
'reqHandler.doSend()


%>
<br/><a href="<%=reqUrl%>" target="_blank">�Ƹ�֧ͨ��</a>
</body>
</html>