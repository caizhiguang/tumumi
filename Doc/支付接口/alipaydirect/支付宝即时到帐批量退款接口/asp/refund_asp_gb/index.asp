<%
	'���ܣ�֧�����˿����ģ��ҳ
	'�汾��3.1
	'���ڣ�2010-12-02
	'˵����
	'���´���ֻ��Ϊ�˷����̻����Զ��ṩ���������룬�̻����Ը����Լ���վ����Ҫ�����ռ����ĵ���д,����һ��Ҫʹ�øô��롣
	'�ô������ѧϰ���о�֧�����ӿ�ʹ�ã�ֻ���ṩһ���ο���
%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML XMLNS:CC>
<HEAD>
<TITLE>֧���� - ����֧�� ��ȫ���٣�</TITLE>
<META http-equiv=Content-Type content="text/html; charset=gb2312">
<META content=���Ϲ���/����֧��/��ȫ֧��/��ȫ����/�����ȫ/֧��,��ȫ/֧����/��ȫ,֧��/��ȫ������/֧��, 
name=description ���� ����,�տ� ����,ó�� ����ó��.>
<META content=���Ϲ���/����֧��/��ȫ֧��/��ȫ����/�����ȫ/֧��,��ȫ/֧����/��ȫ,֧��/��ȫ������/֧��, name=keywords 
���� ����,�տ� ����,ó�� ����ó��.>
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
</HEAD>
<BODY text=#000000 bgColor=#ffffff leftMargin=0 topMargin=4>
<CENTER>
  <BR />
  <FORM name=alipayment onSubmit="return CheckForm();" action=refund.asp 
method=post target="_blank">
    <TABLE cellSpacing=0 cellPadding=0 width=450 border=0>
      <TR>
        <TD class=font_title valign="middle" height="40">֧�����˿�</TD>
      </TR>
      <TR>
        <TD align="center"><HR width=450 SIZE=2 color="#999999"></TD>
      </TR>
      <tr>
        <td align="center"><TABLE cellSpacing=0 cellPadding=0 width=350 border=0>
            <TR>
              <TD class=form-left>�˿������</TD>
              <TD class=form-right><INPUT size=30 name=batch_num maxlength="30"></TD>
            </TR>
            <TR>
              <TD class=form-left>�˿���ϸ��</TD>
              <TD class=form-right><INPUT size=30 name=detail_data value="20100801001^0.01^��ע˵��һ"></TD>
            </TR>
            <TR>
              <TD class=form-left></TD>
              <TD class=form-right><input name="pay" id="pay" value="�˿�" type="submit"></TD>
            </TR>
          </TABLE></td>
      </tr>
    </TABLE>
  </FORM>
</CENTER>
</BODY>
</HTML>
