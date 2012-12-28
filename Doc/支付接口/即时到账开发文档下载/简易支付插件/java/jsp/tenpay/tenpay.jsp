<%@ page language="java" contentType="text/html; charset=GBK"
    pageEncoding="GBK"%>

<%@ page import="java.text.SimpleDateFormat" %>    
<%@ page import="java.util.Date" %>
<%@ page import="com.tenpay.util.TenpayUtil" %>
<%@ page import="com.tenpay.PayRequestHandler"%>

<%@ include file="tenpay_config.jsp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=GBK">
<title>�Ƹ�֧ͨ��֧������</title>
</head>
<body>

<%
//���ñ���
request.setCharacterEncoding("GBK");
//��ȡ�ύ����Ʒ�۸�
String order_price=request.getParameter("order_price");  
//��ȡ�ύ����Ʒ����
String product_name=request.getParameter("product_name");  
//��ȡ�ύ�ı�ע��Ϣ
String remarkexplain=request.getParameter("remarkexplain");  
//��ȡ�ύ�Ķ�����
String order_no=request.getParameter("order_no");  

/* ��Ʒ�۸񣨰����˷ѣ����Է�Ϊ��λ */
double total_fee = (Double.valueOf(order_price) * 100);
int fee = (int)total_fee;


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
String sp_billno = order_no;

String desc = "��Ʒ��" + product_name+",��ע��"+remarkexplain;

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
reqHandler.setParameter("sp_billno", sp_billno);				     //�̼Ҷ�����
reqHandler.setParameter("transaction_id", transaction_id);		//�Ƹ�ͨ���׵���
reqHandler.setParameter("return_url", return_url);				//֧��֪ͨurl
reqHandler.setParameter("desc", desc);	                            //��Ʒ����
reqHandler.setParameter("total_fee", String.valueOf(fee));			          //��Ʒ���,�Է�Ϊ��λ
reqHandler.setParameter("purchaser_id", "");						//��Ʒ���,�Է�Ϊ��λ

//�û��ͻ���ip,��ֵΪ�ջ���Ϊ���ص�ַ��ֻ��֧��1ëǮ���½��
reqHandler.setParameter("spbill_create_ip",request.getRemoteAddr());

//��ȡ�����������url
String requestUrl = reqHandler.getRequestURL();

//��ȡdebug��Ϣ
String debuginfo = reqHandler.getDebugInfo();

//System.out.println("requestUrl:" + requestUrl);
//System.out.println("debuginfo:" + debuginfo);

//�ض�����ת
//reqHandler.doSend();

%>
<br/><a target="_blank" href="<%=requestUrl %>">�Ƹ�֧ͨ��</a>
</body>
</html>