
<%
	/*
	���ܣ�֧�����˿�ӿڵ����ҳ�棬��������URL
	 *�汾��3.1
	 *���ڣ�2010-12-02
	 *˵����
	 *���´���ֻ��Ϊ�˷����̻����Զ��ṩ���������룬�̻����Ը����Լ���վ����Ҫ�����ռ����ĵ���д,����һ��Ҫʹ�øô��롣
	 *�ô������ѧϰ���о�֧�����ӿ�ʹ�ã�ֻ���ṩһ���ο���
	
	 *************************ע��*****************
	������ڽӿڼ��ɹ������������⣬
	�����Ե��̻��������ģ�https://b.alipay.com/support/helperApply.htm?action=consultationApply�����ύ���뼯��Э�������ǻ���רҵ�ļ�������ʦ������ϵ��Э�������
	��Ҳ���Ե�֧������̳��http://club.alipay.com/read-htm-tid-8681712.html��Ѱ����ؽ������
	Ҫ���ݵĲ���Ҫô������Ϊ�գ�Ҫô�Ͳ�Ҫ���������������ؿؼ���URL�����
	 **********************************************
	 */
%>
<%@ page language="java" contentType="text/html; charset=GBK"
	pageEncoding="GBK"%>
<%@ page import="com.alipay.config.*"%>
<%@ page import="com.alipay.util.*"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=GBK">
		<title>֧���������˿�ӿ�</title>
	</head>
	<body>
	<%
		//request.setCharacterEncoding("UTF-8");
			//AlipyConfig.java��������Ϣ���������޸ģ�
			String input_charset = AlipayConfig.input_charset;
			String sign_type = AlipayConfig.sign_type;
			String partner = AlipayConfig.partner;
			String key = AlipayConfig.key;
			String seller_email = AlipayConfig.seller_email;
			String notify_url = AlipayConfig.notify_url;
			/////////////////////////////////////////�������////////////////////////////////////////////////////
			UtilDate date = new UtilDate();//��ȡ֧�������������ɶ�����
			//�˿�����ڣ���ȡ�������ڣ���ʽ����[4λ]-��[2λ]-��[2λ] Сʱ[2λ 24Сʱ��]:��[2λ]:��[2λ]���磺2007-10-01 13:13:13
			String refund_date = date.getDateFormatter();
			
			//�̼���վ������κţ���֤��Ψһ�ԣ���ʽ����������[8λ]+���к�[3��24λ]���磺201008010000001
			String batch_no = date.getOrderNum();
			
			//�˿������������detail_data��ֵ�У���#���ַ����ֵ�������1�����֧��1000�ʣ�����#���ַ����ֵ�����999����
			String batch_num = request.getParameter("batch_num");
			
			//�˿���ϸ����
			String detail_data = new String(request.getParameter("detail_data").getBytes("ISO-8859-1"),"GBK");
	        //��ʽ����һ�ʽ���#�ڶ��ʽ���#�����ʽ���
	        //��N�ʽ��׸�ʽ�������˿���Ϣ
	        //�����˿���Ϣ��ʽ��ԭ����֧�������׺�^�˿��ܽ��^�˿�����
	        //ע�⣺
	        //1.detail_data�е��˿�����ܺ�Ҫ���ڲ���batch_num��ֵ
	        //2.detail_data��ֵ�в����С�^������|������#������$����Ӱ��detail_data�ĸ�ʽ�������ַ�
	        //3.detail_data���˿��ܽ��ܴ��ڽ����ܽ��
	        //4.һ�ʽ��׿��Զ���˿ֻ��Ҫ���ض���˿���ܽ������ñʽ��׸���ʱ��
	        //5.��֧���˷�����

	        /////////////////////////////////////////////////////////////////////////////////////////////////////
			
			//���캯��
	        String sHtmlText = AlipayRefundService.BuildForm(partner,seller_email,notify_url,
	        refund_date,batch_no,batch_num,detail_data,input_charset,key,sign_type);
	        out.println(sHtmlText);
	%>
	</body>
</html>
