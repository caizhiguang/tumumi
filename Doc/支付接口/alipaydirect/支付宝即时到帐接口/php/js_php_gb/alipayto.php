<?php
/*
 *���ܣ�������Ʒ�й���Ϣ��ȷ�϶���֧�������߹������ҳ��
 *��ϸ����ҳ���ǽӿ����ҳ�棬����֧��ʱ��URL
 *�汾��3.1
 *�޸����ڣ�2010-10-29
 '˵����
 '���´���ֻ��Ϊ�˷����̻����Զ��ṩ���������룬�̻����Ը����Լ���վ����Ҫ�����ռ����ĵ���д,����һ��Ҫʹ�øô��롣
 '�ô������ѧϰ���о�֧�����ӿ�ʹ�ã�ֻ���ṩһ���ο���

*/

////////////////////ע��/////////////////////////
//������ڽӿڼ��ɹ������������⣬
//�����Ե��̻��������ģ�https://b.alipay.com/support/helperApply.htm?action=consultationApply�����ύ���뼯��Э�������ǻ���רҵ�ļ�������ʦ������ϵ��Э�������
//��Ҳ���Ե�֧������̳��http://club.alipay.com/read-htm-tid-8681712.html��Ѱ����ؽ������
//Ҫ���ݵĲ���Ҫô������Ϊ�գ�Ҫô�Ͳ�Ҫ���������������ؿؼ���URL�����
/////////////////////////////////////////////////

require_once("alipay_config.php");
require_once("class/alipay_service.php");

/*���²�������Ҫͨ���µ�ʱ�Ķ������ݴ���������*/
//�������
$out_trade_no = date(Ymdhms);		//�������վ����ϵͳ�е�Ψһ������ƥ��
$subject      = $_POST['aliorder'];	//�������ƣ���ʾ��֧��������̨��ġ���Ʒ���ơ����ʾ��֧�����Ľ��׹���ġ���Ʒ���ơ����б��
$body         = $_POST['alibody'];	//����������������ϸ��������ע����ʾ��֧��������̨��ġ���Ʒ��������
$total_fee    = $_POST['alimoney'];	//�����ܽ���ʾ��֧��������̨��ġ�Ӧ���ܶ��

//��չ���ܲ�������Ĭ��֧����ʽ
$pay_mode	  = $_POST['pay_bank'];
if ($pay_mode == "directPay") {
	$paymethod    = "directPay";	//Ĭ��֧����ʽ���ĸ�ֵ��ѡ��bankPay(����); cartoon(��ͨ); directPay(���); CASH(����֧��)
	$defaultbank  = "";
}
else {
	$paymethod    = "bankPay";		//Ĭ��֧����ʽ���ĸ�ֵ��ѡ��bankPay(����); cartoon(��ͨ); directPay(���); CASH(����֧��)
	$defaultbank  = $pay_mode;		//Ĭ���������ţ������б��http://club.alipay.com/read.php?tid=8681379
}

//��չ���ܲ�������������
//������ѡ���Ƿ��������㹦��
//exter_invoke_ip��anti_phishing_keyһ�������ù�����ô���Ǿͻ��Ϊ�������
//���������㹦�ܺ󣬷��������������Ա���֧��Զ��XML�����������úøû�����
//��Ҫʹ�÷����㹦�ܣ����class�ļ�����alipay_function.php�ļ����ҵ����ļ����·���query_timestamp����������ע�ͶԸú��������޸�
//����ʹ��POST��ʽ��������
$anti_phishing_key  = '';			//������ʱ���
$exter_invoke_ip = '';				//��ȡ�ͻ��˵�IP��ַ�����飺��д��ȡ�ͻ���IP��ַ�ĳ���
//�磺
//$exter_invoke_ip = '202.1.1.1';
//$anti_phishing_key = query_timestamp($partner);		//��ȡ������ʱ�������


//��չ���ܲ�����������
$extra_common_param = '';			//�Զ���������ɴ���κ����ݣ���=��&�������ַ��⣩��������ʾ��ҳ����
$buyer_email		= '';			//Ĭ�����֧�����˺�

//��չ���ܲ�����������(��Ҫʹ�ã��밴��ע��Ҫ��ĸ�ʽ��ֵ)
$royalty_type		= "";			//������ͣ���ֵΪ�̶�ֵ��10������Ҫ�޸�
$royalty_parameters	= "";
//�����Ϣ��������Ҫ����̻���վ���������̬��ȡÿ�ʽ��׵ĸ������տ��˺š��������������˵�������ֻ������10��
//����������ܺ���С�ڵ���total_fee
//�����Ϣ����ʽΪ���տEmail_1^���1^��ע1|�տEmail_2^���2^��ע2
//�磺
//royalty_type = "10"
//royalty_parameters	= "111@126.com^0.01^����עһ|222@126.com^0.01^����ע��"

/////////////////////////////////////////////////

//����Ҫ����Ĳ������飬����Ķ�
$parameter = array(
        "service"			=> "create_direct_pay_by_user",	//�ӿ����ƣ�����Ҫ�޸�
        "payment_type"		=> "1",               			//�������ͣ�����Ҫ�޸�

        //��ȡ�����ļ�(alipay_config.php)�е�ֵ
        "partner"			=> $partner,
        "seller_email"		=> $seller_email,
        "return_url"		=> $return_url,
        "notify_url"		=> $notify_url,
        "_input_charset"	=> $_input_charset,
        "show_url"			=> $show_url,

        //�Ӷ��������ж�̬��ȡ���ı������
        "out_trade_no"		=> $out_trade_no,
        "subject"			=> $subject,
        "body"				=> $body,
        "total_fee"			=> $total_fee,

        //��չ���ܲ�������������ǰ
        "paymethod"			=> $paymethod,
        "defaultbank"		=> $defaultbank,

        //��չ���ܲ�������������
        "anti_phishing_key"	=> $anti_phishing_key,
		"exter_invoke_ip"	=> $exter_invoke_ip,

		//��չ���ܲ��������Զ������
		"buyer_email"		=> $buyer_email,
        "extra_common_param"=> $extra_common_param,
		
		//��չ���ܲ�����������
        "royalty_type"		=> $royalty_type,
        "royalty_parameters"=> $royalty_parameters
);

//����������
$alipay = new alipay_service($parameter,$key,$sign_type);
$sHtmlText = $alipay->build_form();

?>
<html>
    <head>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
        <title>֧������ʱ֧��</title>
        <style type="text/css">
            .font_content{
                font-family:"����";
                font-size:14px;
                color:#FF6600;
            }
            .font_title{
                font-family:"����";
                font-size:16px;
                color:#FF0000;
                font-weight:bold;
            }
            table{
                border: 1px solid #CCCCCC;
            }
        </style>
    </head>
    <body>

        <table align="center" width="350" cellpadding="5" cellspacing="0">
            <tr>
                <td align="center" class="font_title" colspan="2">����ȷ��</td>
            </tr>
            <tr>
                <td class="font_content" align="right">�����ţ�</td>
                <td class="font_content" align="left"><?php echo $out_trade_no; ?></td>
            </tr>
            <tr>
                <td class="font_content" align="right">�����ܽ�</td>
                <td class="font_content" align="left"><?php echo $total_fee; ?></td>
            </tr>
            <tr>
                <td align="center" colspan="2"><?php echo $sHtmlText; ?></td>
            </tr>
        </table>
    </body>
</html>
