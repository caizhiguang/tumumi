package com.alipay.util;

import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.util.*;

import com.alipay.util.AlipayFunction;

/**
 *������alipay_refund_service
 *���ܣ�֧�����ⲿ����ӿڿ���
 *��ϸ����ҳ��������������Ĵ����ļ�������Ҫ�޸�
 *�汾��3.1
 *�޸����ڣ�2010-12-02
 *˵����
  ���´���ֻ��Ϊ�˷����̻����Զ��ṩ���������룬�̻����Ը����Լ���վ����Ҫ�����ռ����ĵ���д,����һ��Ҫʹ�øô��롣
  �ô������ѧϰ���о�֧�����ӿ�ʹ�ã�ֻ���ṩһ���ο���
 */

public class AlipayRefundService {
	/**
	 * ���ܣ�������ύHTML
	 * @param partner ���������ID
	 * @param seller_email ǩԼ֧�����˺Ż�����֧�����ʻ�
	 * @param notify_url ���׹����з�����֪ͨ��ҳ�� Ҫ�� ��http����ʽ������·�����������?id=123�����Զ������
	 * @param refund_date �˿�����ڣ���ȡ�������ڣ���ʽ����[4λ]-��[2λ]-��[2λ] Сʱ[2λ 24Сʱ��]:��[2λ]:��[2λ]���磺2007-10-01 13:13:13
	 * @param batch_no �̼���վ������κţ���֤��Ψһ�ԣ���ʽ����������[8λ]+���к�[3��24λ]���磺201008010000001
	 * @param batch_num �˿������������detail_data��ֵ�У���#���ַ����ֵ�������1�����֧��1000�ʣ�����#���ַ����ֵ�����999����
	 * @param detail_data �˿���ϸ����
	 * @param input_charset �ַ������ʽ Ŀǰ֧�� GBK �� utf-8
	 * @param key ��ȫУ����
	 * @param sign_type ǩ����ʽ �����޸�
	 * @return ���ύHTML�ı�
	 */
	public static String BuildForm(String partner,
			String seller_email,
			String notify_url,
			String refund_date,
			String batch_no,
			String batch_num,
			String detail_data,
            String input_charset,
            String key,
            String sign_type){
		Map sPara = new HashMap();
		sPara.put("_input_charset", input_charset);
		sPara.put("batch_no", batch_no);
		sPara.put("batch_num", batch_num);
		sPara.put("detail_data", detail_data);
		sPara.put("seller_email", seller_email);
		sPara.put("notify_url", notify_url);
		sPara.put("partner", partner);
		sPara.put("refund_date", refund_date);
		sPara.put("service","refund_fastpay_by_platform_pwd");
		
		Map sParaNew = AlipayFunction.ParaFilter(sPara); //��ȥ�����еĿ�ֵ��ǩ������
		String mysign = AlipayFunction.BuildMysign(sParaNew, key);//����ǩ�����
		
		StringBuffer sbHtml = new StringBuffer();
		List keys = new ArrayList(sParaNew.keySet());
		String gateway = "https://www.alipay.com/cooperate/gateway.do?";
		
		//GET��ʽ����
		//sbHtml.append("<form id=\"alipaysubmit\" name=\"alipaysubmit\" action=\"" + gateway + "_input_charset=" + input_charset + "\" method=\"get\">");
		//POST��ʽ���ݣ�GET��POST����ѡһ��
		sbHtml.append("<form id=\"alipaysubmit\" name=\"alipaysubmit\" action=\"" + gateway + "_input_charset=" + input_charset + "\" method=\"post\">");
		
		for (int i = 0; i < keys.size(); i++) {
			String name = (String) keys.get(i);
			String value = (String) sParaNew.get(name);
			
			sbHtml.append("<input type=\"hidden\" name=\"" + name + "\" value=\"" + value + "\"/>");
		}
        sbHtml.append("<input type=\"hidden\" name=\"sign\" value=\"" + mysign + "\"/>");
        sbHtml.append("<input type=\"hidden\" name=\"sign_type\" value=\"" + sign_type + "\"/>");
        
        //submit��ť�ؼ��벻Ҫ����name����
        sbHtml.append("<input type=\"submit\" value=\"֧����ȷ�ϸ���\"></form>");
		
        sbHtml.append("<script>document.forms['alipaysubmit'].submit();</script>");
        
		return sbHtml.toString();
	}
}
