<%@ page language="java" contentType="text/html; charset=GBK"
    pageEncoding="GBK"%>
 
<%@ page import="com.tenpay.util.TenpayUtil" %>
<%@ page import="com.tenpay.PayResponseHandler"%>       
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%
//��Կ
String key = "8934e7d15453e97507ef794cf7b0519d";

//����PayResponseHandlerʵ��
PayResponseHandler resHandler = new PayResponseHandler(request, response);

resHandler.setKey(key);

//�ж�ǩ��
if(resHandler.isTenpaySign()) {
	//���׵���
	String transaction_id = resHandler.getParameter("transaction_id");
	
	//�����,�Է�Ϊ��λ
	String total_fee = resHandler.getParameter("total_fee");
	
	//֧�����
	String pay_result = resHandler.getParameter("pay_result");
	
	if( "0".equals(pay_result) ) {
		//------------------------------
		//����ҵ��ʼ
		//------------------------------ 
		
		//ע�⽻�׵���Ҫ�ظ�����
		//ע���жϷ��ؽ��
		
		//------------------------------
		//����ҵ�����
		//------------------------------
			
		//����doShow, ��ӡmetaֵ��js����,���߲Ƹ�ͨ����ɹ�,�����û��������ʾ$showҳ��.
		resHandler.doShow("http://localhost:8080/tenpay/show.jsp");
	} else {
		//�������ɹ�����
		out.println("֧��ʧ��");
	}
	
} else {
	out.println("��֤ǩ��ʧ��");
	//String debugInfo = resHandler.getDebugInfo();
	//System.out.println("debugInfo:" + debugInfo);
}

%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=GBK">
<title>�Ƹ�֧ͨ���ص�����</title>
</head>
<body>

</body>
</html>