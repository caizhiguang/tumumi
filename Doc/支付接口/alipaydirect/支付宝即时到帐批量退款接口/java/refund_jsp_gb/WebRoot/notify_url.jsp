<%
/* *
 ���ܣ�֧��������֪ͨ���õ�ҳ�棨�������첽֪ͨҳ�棩
 �汾��3.1
 ���ڣ�2010-12-13
 ˵����
 ���´���ֻ��Ϊ�˷����̻����Զ��ṩ���������룬�̻����Ը����Լ���վ����Ҫ�����ռ����ĵ���д,����һ��Ҫʹ�øô��롣
 �ô������ѧϰ���о�֧�����ӿ�ʹ�ã�ֻ���ṩһ���ο���

 //***********ҳ�湦��˵��***********
 ������ҳ���ļ�ʱ�������ĸ�ҳ���ļ������κ�HTML���뼰�ո�
 ��ҳ�治���ڱ������Բ��ԣ��뵽�������������ԡ���ȷ���ⲿ���Է��ʸ�ҳ�档
 ��ҳ����Թ�����ʹ��д�ı�����log_result���ú����ѱ�Ĭ�Ͽ���
 ��֪ͨҳ����Ҫ�����ǣ�����֧�����Ĵ������������̼ҵ�ҵ���߼�����
 ���û���յ���ҳ�淵�ص� success ��Ϣ��֧��������24Сʱ�ڰ�һ����ʱ������ط�֪ͨ
 //********************************
 * */
%>
<%@ page language="java" contentType="text/html; charset=GBK" pageEncoding="GBK"%>
<%@ page import="java.util.*"%>
<%@ page import="com.alipay.util.*"%>
<%@ page import="com.alipay.config.*"%>
<%
	String key = AlipayConfig.key;
	//��ȡ֧����POST����������Ϣ
	Map params = new HashMap();
	Map requestParams = request.getParameterMap();
	for (Iterator iter = requestParams.keySet().iterator(); iter.hasNext();) {
		String name = (String) iter.next();
		String[] values = (String[]) requestParams.get(name);
		String valueStr = "";
		for (int i = 0; i < values.length; i++) {
			valueStr = (i == values.length - 1) ? valueStr + values[i]
					: valueStr + values[i] + ",";
		}
		//����������δ����ڳ�������ʱʹ�á����mysign��sign�����Ҳ����ʹ����δ���ת��
		//valueStr = new String(valueStr.getBytes("ISO-8859-1"), "GBK");
		params.put(name, valueStr);
	}
	
	//�ж�responsetTxt�Ƿ�Ϊture�����ɵ�ǩ�����mysign���õ�ǩ�����sign�Ƿ�һ��
	//responsetTxt�Ľ������true����������������⡢���������ID��notify_idһ����ʧЧ�й�
	//mysign��sign���ȣ��밲ȫУ���롢����ʱ�Ĳ�����ʽ���磺���Զ�������ȣ��������ʽ�й�
	String mysign = AlipayNotify.GetMysign(params,key);
	String responseTxt = AlipayNotify.Verify(request.getParameter("notify_id"));
	String sign = request.getParameter("sign");
	
	//д��־��¼����Ҫ���ԣ���ȡ����������ע�ͣ�
	String sWord = "responseTxt=" + responseTxt + "\n notify_url_log:sign=" + sign + "&mysign=" + mysign + "\n notify�����Ĳ�����" + AlipayFunction.CreateLinkString(params);
	AlipayFunction.LogResult(sWord);
	
	//��ȡ֧������֪ͨ���ز������ɲο������ĵ���ҳ����תͬ��֪ͨ�����б�(���½����ο�)//
	//��ȡ���κ�
	String batch_no = request.getParameter("batch_no");
	
	//��ȡ�����˿�������ת�˳ɹ��ı���
	String success_num = request.getParameter("success_num");
	
	//��ȡ�����˿������е���ϸ��Ϣ
	String result_details = new String(request.getParameter("result_details").getBytes("ISO-8859-1"),"GBK");
	//��ʽ����һ�ʽ���#�ڶ��ʽ���#�����ʽ���
	//��N�ʽ��׸�ʽ�������˿���Ϣ
	//�����˿���Ϣ��ʽ��ԭ����֧�������׺�^�˿��ܽ��^��������^�������
	
	//��ȡ֧������֪ͨ���ز������ɲο������ĵ���ҳ����תͬ��֪ͨ�����б�(���Ͻ����ο�)//
	
	if(mysign.equals(sign) && responseTxt.equals("true")){//��֤�ɹ�
		//////////////////////////////////////////////////////////////////////////////////////////
		//������������̻���ҵ���߼��������

		//�������������ҵ���߼�����д�������´�������ο�������


		//�������������ҵ���߼�����д�������ϴ�������ο�������

		//////////////////////////////////////////////////////////////////////////////////////////
				
		out.println("success");	//��֧���������ĳɹ���־���벻Ҫ�޸Ļ�ɾ��
		
	}else{//��֤ʧ��
		out.println("fail");
	}
%>
