<%
	/*
	 ���ܣ�֧�����˿����ģ��ҳ
	 *�汾��3.1
	 *���ڣ�2010-12-02
	 *˵����
	 *���´���ֻ��Ϊ�˷����̻����Զ��ṩ���������룬�̻����Ը����Լ���վ����Ҫ�����ռ����ĵ���д,����һ��Ҫʹ�øô��롣
	 *�ô������ѧϰ���о�֧�����ӿ�ʹ�ã�ֻ���ṩһ���ο���

	 */
%>
<%@ page language="java" contentType="text/html; charset=GBK"
	pageEncoding="GBK"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=GBK">
		<title>֧���������˿�ӿ�</title>
		<style type="text/css">
			.form-left{
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
		</style>
		<SCRIPT language=JavaScript>
		function CheckForm()
		{
			if (document.alipayment.batch_num.value.length == 0) {
				alert("�������˿����.");
				document.alipayment.batch_num.focus();
				return false;
			}
			if (document.alipayment.detail_data.value.length == 0) {
				alert("�������˿���ϸ.");
				document.alipayment.detail_data.focus();
				return false;
			}
		
		}  
		</SCRIPT>
	</head>
<body>
    <center>
        <form id="alipayment" name="alipayment" action="refund.jsp" method="post" onsubmit="return CheckForm();">
            <table cellspacing="0" cellpadding="0" width="450" border="0">
                <tr>
                    <td class="font_title" valign="middle" height="40">
                        ֧�����˿�</td>
                </tr>
                <tr>
                    <td align="center">
                        <hr width="450" size="2" color="#999999">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table cellspacing="0" cellpadding="0" width="350" border="0">
                            <tr>
                                <td class="form-left">
                                    �˿������</td>
                                <td>
                                    <input size="30" name="batch_num" maxlength="30"></td>
                            </tr>
                            <tr>
                                <td class="form-left">
                                    �˿���ϸ��</td>
                                <td>
                                    <input size="30" name="detail_data" value="20100801001^0.01^��ע˵��һ"></td>
                            </tr>
                            <tr>
                                <td class="form-left">
                                </td>
                                <td>
                                    <input name="pay" id="pay" value="�˿�" type="submit"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </form>
    </center>
	</body>
</html>
