<%@ page language="java" contentType="text/html; charset=GBK"
    pageEncoding="GBK"%>

<%@ page import="java.text.SimpleDateFormat" %>    
<%@ page import="java.util.Date" %>
<%@ page import="com.tenpay.util.TenpayUtil" %>
<%@ page import="com.tenpay.PayRequestHandler"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=GBK">
<title>�Ƹ�֧ͨ��֧������</title>
</head>
<body>
<%
//�̻���
String bargainor_id = "1900000109";

//��Կ
String key = "8934e7d15453e97507ef794cf7b0519d";

//�ص�֪ͨURL
String return_url = "http://localhost:8080/tenpay/return_url.jsp";

//��ǰʱ�� yyyyMMddHHmmss
String currTime = TenpayUtil.getCurrTime();

//8λ����
String strDate = currTime.substring(0, 8);

//6λʱ��
String strTime = currTime.substring(8, currTime.length());

//��λ�����
String strRandom = TenpayUtil.buildRandom(4) + "";

//10λ���к�,�������е�����
String strReq = strTime + strRandom;

//�̼Ҷ�����,����������32λ��ȡǰ32λ���Ƹ�ֻͨ��¼�̼Ҷ����ţ�����֤Ψһ��
String sp_billno = strReq;

//�Ƹ�ͨ���׵��ţ�����Ϊ��10λ�̻���+8λʱ�䣨YYYYmmdd)+10λ��ˮ��
String transaction_id = bargainor_id + strDate + strReq;

//����PayRequestHandlerʵ��
PayRequestHandler reqHandler = new PayRequestHandler(request, response);

//������Կ
reqHandler.setKey(key);

//��ʼ��
reqHandler.init();

//-----------------------------
//����֧������
//-----------------------------
reqHandler.setParameter("bargainor_id", bargainor_id);			//�̻���
reqHandler.setParameter("sp_billno", sp_billno);				//�̼Ҷ�����
reqHandler.setParameter("transaction_id", transaction_id);		//�Ƹ�ͨ���׵���
reqHandler.setParameter("return_url", return_url);				//֧��֪ͨurl
reqHandler.setParameter("desc", "�����ţ�" + transaction_id);	//��Ʒ����
reqHandler.setParameter("total_fee", "1");						//��Ʒ���,�Է�Ϊ��λ

//�û�ip,���Ի���ʱ��Ҫ�����ip��������ʽ�����ټӴ˲���
reqHandler.setParameter("spbill_create_ip",request.getRemoteAddr());

//��ȡ�����������url
String requestUrl = reqHandler.getRequestURL();

//��ȡdebug��Ϣ
String debuginfo = reqHandler.getDebugInfo();

//System.out.println("requestUrl:" + requestUrl);
//System.out.println("debuginfo:" + debuginfo);


%>
<br/><a target="_blank" href="<%=requestUrl %>">�Ƹ�֧ͨ��</a>
</body>
</html>