<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%> 
<!--#include file="./classes/PayResponseHandler.asp"-->
<!--#include file="./tenpay_config.asp"-->
<%
'---------------------------------------------------------
'�Ƹ�ͨ��ʱ����֧��Ӧ�𣨴���ص���ʾ�����̻����մ��ĵ����п�������
'---------------------------------------------------------

'��Կ
Dim key
key = tenpay_key

'����֧��Ӧ�����
Dim resHandler
Set resHandler = new PayResponseHandler
resHandler.setKey(key)

'�ж�ǩ��
If resHandler.isTenpaySign() = True Then
	
	Dim transaction_id
	Dim total_fee

	'���׵���
	transaction_id = resHandler.getParameter("transaction_id")

	'��Ʒ���,�Է�Ϊ��λ
	total_fee = resHandler.getParameter("total_fee")
	
	'֧�����
	pay_result = resHandler.getParameter("pay_result")
	
	If "0" = pay_result Then
	
		'------------------------------
		'����ҵ��ʼ
		'------------------------------
		
		'ע�⽻�׵���Ҫ�ظ�����
		'ע���жϷ��ؽ��
		
		'------------------------------
		'����ҵ�����
		'------------------------------	
		
		'����doShow
		resHandler.doShow(tenpay_show)
	
	Else
		'�������ɹ�����
		Response.Write("֧��ʧ��")
	End If	

Else

	'ǩ��ʧ��
	Response.Write("ǩ��ǩ֤ʧ��")

	Dim debugInfo
	'debugInfo = resHandler.getDebugInfo()
	'Response.Write("<br/>debugInfo:" & debugInfo & "<br/>")

End If


%>