﻿function showMessageDiv(id){
	if (document.getElementById("tcc"))
		document.getElementById("tcc").style.display = "block";
	document.getElementById("showTitle").innerHTML = $("messageTitle"+id).innerHTML;
	var content = $("messageContent"+id).innerHTML;
	var contentPart = content;
	if(content.length>140){
		contentPart = content.substr(0,140)+"...";
		if (document.getElementById("wenziName"))
			document.getElementById("wenziName").style.display = "block";
			document.getElementById("key").style.display="";
	}else{
		document.getElementById("key").style.display="none";
	}
	document.getElementById("showContent").innerHTML = contentPart;
	document.getElementById("showContentAll").innerHTML = content;
}
function closeShowMessage(){
	display_part();
	if (document.getElementById("tcc"))
		document.getElementById("tcc").style.display = "none";
}


function display_all(){
	document.getElementById("showContentAll").style.display="";
	document.getElementById("showContent").style.display="none";
	document.getElementById("descLink").href="javascript:display_part();";
	document.getElementById("key").innerHTML="鍏抽棴"; 
}
function display_part(){
	document.getElementById("showContentAll").style.display="none";
	document.getElementById("showContent").style.display="";
	document.getElementById("descLink").href="javascript:display_all();";
	document.getElementById("key").innerHTML="灞曞紑";
}
function check(){
	if(rtrim(document.getElementById('username').value)==""){
		alert("瀵逛笉璧�,璇疯緭鍏ユ偍鐨勭敤鎴峰悕鎴栭偖绠憋紒");
		document.getElementById('username').select();
		return false;
	}/*
	if(!checkEmail(document.getElementById('username').value)){
		alert("瀵逛笉璧�,鎮ㄧ殑鐧诲綍閭涓嶇鍚堣姹傦紒");
		document.getElementById('username').select();
		return false;
	}*/
	if(rtrim(document.getElementById('password').value)==""){
		alert("璇疯緭鍏ュ瘑鐮侊紒");
		document.getElementById('password').focus();
		b=false;
		return b;
	} 
	return true;
}
var topCart = "read";
var dayCart = "today";
function changTopNum(str){
	topCart = str;
	document.getElementById("readLi").className = "ahover";
	document.getElementById("goodLi").className = "ahover";
	if(str=="read"){	//闃呰鎺ㄨ崘
		document.getElementById("readLi").className = "active";
	}else if(str=="good"){	//濂借瘎鎺ㄨ崘
		document.getElementById("goodLi").className = "active";
	}
	changeShowTopDiv();
}
function changeDayNum(str){
	dayCart = str;
	document.getElementById("todayLi").className = "ahover";
	document.getElementById("weekLi").className = "ahover";
	document.getElementById("monthLi").className = "ahover";
	if(str=="today"){
		document.getElementById("todayLi").className = "active";
	}else if(str=="week"){
		document.getElementById("weekLi").className = "active";
	}else if(str=="month"){
		document.getElementById("monthLi").className = "active";
	}
	changeShowTopDiv();
}
function changeShowTopDiv(){
	closeTopDiv();
	if(topCart=="read"){
		if(dayCart=="today"){
			document.getElementById("readToday").style.display = "";
		}else if(dayCart=="week"){
			document.getElementById("readWeek").style.display = "";
		}else if(dayCart=="month"){
			document.getElementById("readmonth").style.display = "";
		}
	}
}
function closeTopDiv(){
	document.getElementById("readToday").style.display = "none";
	document.getElementById("readWeek").style.display = "none";
	document.getElementById("readmonth").style.display = "none";
}

//澶у閮借浜嗕粈涔�
function moveAllRead(num){
	$("allreadDiv1").style.display = "none";
	$("allreadDiv2").style.display = "none";
	$("allreadDiv3").style.display = "none";
	$("allreadDiv"+num).style.display = "block";
}

function selectSearchLoginDiv(sContent,selfObj){
	// 鎿嶄綔鏍囩
	var gb_search = document.getElementById("login_tag").getElementsByTagName("li");
	var gb_searchlength = gb_search.length;
	for(i=0; i<gb_searchlength; i++){
		gb_search[i].className = "";
	}
	selfObj.parentNode.className = "selectTag";
	// 鎿嶄綔鍐呭
	for(i=0; j=document.getElementById("login_tagnum"+i); i++){
		j.style.display = "none";
	}
	document.getElementById(sContent).style.display = "block";
	var login_tagnum1 = document.getElementById("login_tagnum1");
	if(login_tagnum1.style.display=="block")
	{
		gb_search[1].className = "selectTag";
		}
}

function refCode(){
	var d, s = "";
	var c = "";
	d = new Date();
	s += d.getYear()+c;
	s += (d.getMonth() + 1) + c;
	s += d.getDate() + c;
	s += d.getHours() + c;
	s += d.getMinutes() + c;
	s += d.getSeconds() + c;
	s += d.getMilliseconds();
	$('regimg').src="/servlet/getimg?"+s;
}

//棣栭〉v4_1鐗堝垎绫绘帹鑽愭樉绀�
function index_showcateRecommend(index){
	var tmp = "<img src='http://img.wanlibo.com/images_cn/index/inco_classon.gif' />";
	if(index_cateid!="0"){
		$("cateurlname"+index_cateid).innerHTML = index_catename;
		$("cateurlname_link"+index_cateid).className = "";
		index_cateid = index;
		index_catename = $("cateurlname"+index).innerHTML;
		$("cateurlname"+index).innerHTML = index_catename+tmp;
		$("cateurlname_link"+index).className = "catechoose";
	}
	index_cateid = index;
	document.getElementById("cateRecommend68").style.display = "none";
	document.getElementById("cateRecommend3").style.display = "none";
	document.getElementById("cateRecommend65").style.display = "none";
	document.getElementById("cateRecommend6").style.display = "none";
	document.getElementById("cateRecommend67").style.display = "none";
	document.getElementById("cateRecommend4").style.display = "none";
	document.getElementById("cateRecommend66").style.display = "none";
	document.getElementById("cateRecommend2").style.display = "none";
	document.getElementById("cateRecommend7").style.display = "none";
	document.getElementById("cateRecommend8").style.display = "none";
	document.getElementById("cateRecommend9").style.display = "none";
	document.getElementById("cateRecommend5").style.display = "none";
	document.getElementById("cateRecommend70").style.display = "none";
	$("cateRecommend"+index).style.display = "block";
}

//棣栭〉v4_1鐗� 娉ㄥ唽楠岃瘉

var index_reg_name = true;
var index_reg_name_ishave = false;
var index_reg_email = true;
var index_reg_email_ishave = false;
var index_reg_password = true;
var index_reg_rand = false;

/************ 楠岃瘉娉ㄥ唽閭鏄惁姝ｇ‘骞跺瓨鍦� *********************/
function index_checkRegName(type){
	document.getElementById("showBlurUserName").className = "val dpb";
	var loginName = trim(document.getElementById("regloginname").value);
	var desc = '';
	
	
	if(loginName==''){
		desc = "鐢ㄦ埛鍚嶄笉鑳戒负绌猴紝璇峰～鍐欙紒";
	}
	var c = new RegExp();   
	c = /^[A-Za-z0-9_-]+$/;    
	if(!c.test(loginName)){
		desc = "鐢ㄦ埛鍚嶅彧鏀寔鑻辨枃 鏁板瓧鐨勭粍鍚堬紝璇锋纭～鍐�!";
	}
	if(loginName.length>20){
		desc = "鐢ㄦ埛鍚嶇殑闀垮害涓嶈兘澶т簬20!"
	}  
	if(loginName.toUpperCase().indexOf("DOCIN")>-1 || loginName.toUpperCase().indexOf("VONIBO")>-1 || loginName.toUpperCase().indexOf("BBS")>-1 ){
		desc = "璇ョ敤鎴峰悕宸茬粡瀛樺湪锛岃閲嶆柊杈撳叆锛�";
	}
	if(desc != ""){
		if(type=="blur"){
			document.getElementById("showBlurUserName").src = "http://img.wanlibo.com/images_cn/registration/reg_icon_cw.gif";
			document.getElementById("showBlurUserName").alt = desc;
		}else{
			index_reg_name = false;
			alert(desc);
			document.getElementById('regloginname').focus();
		}
		return;
	}else{
		index_reg_name = true;
	}
	
	if(index_reg_name){
		//checkLoginDwr.checkLoginName(loginName,
			jQuery("#a5").load('/jsp_cn/jquery/login/reg_check.jsp?flag=name&loginName='+loginName,
			function (data){
				data = trim(data.replace(/\r\n/gim, "")); 
				if(data=="true"){
					if(type=="blur"){
						document.getElementById("showBlurUserName").src = "http://img.wanlibo.com/images_cn/registration/reg_zq.gif";
					}else{
						index_reg_name_ishave = true;
						index_checkRegEmail('button');
					}
				}else{
					if(type=="blur"){
						document.getElementById("showBlurUserName").src = "http://img.wanlibo.com/images_cn/registration/reg_icon_cw.gif";
						document.getElementById("showBlurUserName").alt = "璇ョ敤鎴峰悕宸茬粡瀛樺湪锛岃閲嶆柊杈撳叆";
					}else{
						alert("璇ョ敤鎴峰悕宸茬粡瀛樺湪锛岃閲嶆柊杈撳叆");
						index_reg_name_ishave = false;
						document.getElementById('regloginname').focus();
					}
				}
			}
		);
	}
}
function index_checkRegEmail(type){
	document.getElementById("showBlurEmail").className = "val dpb";
	var loginEmail = document.getElementById("regloginemail").value;
	var desc='';
	if(loginEmail.indexOf(" ")>-1){
		desc='閭涓嶈兘鍖呭惈绌烘牸!';
	}else {
		loginEmail=trim(loginEmail);
		if(loginEmail==''){
			desc='璇锋偍杈撳叆閭!';
		}else if(!checkEmail(loginEmail)){
			desc='閭鏍煎紡涓嶆纭�,璇烽噸鏂拌緭鍏�';
		}else if (new RegExp("[,]","g").test(loginEmail)){
			desc='鍚湁闈炴硶瀛楃'
		}else if(loginEmail.length>100){
			desc='閭闀垮害搴斿皬浜�涓瓧绗�';
		}
	}
	if(desc!=''){
		if(type=="blur"){
			document.getElementById("showBlurEmail").src = "http://img.wanlibo.com/images_cn/registration/reg_icon_cw.gif";
			document.getElementById("showBlurEmail").alt = desc;
		}else{
			index_reg_email = false;
			alert(desc);
			document.getElementById('regloginemail').focus();
		}
		return;
	}else{
		index_reg_email = true;
	}
	if(index_reg_email){
		loginEmail = trim(loginEmail);
		
		jQuery("#a5").load('/jsp_cn/jquery/login/reg_check.jsp?flag=email&loginEmail='+loginEmail,
			function (data){
				data = trim(data.replace(/\r\n/gim, "")); 
				if(data=="true"){
					if(type=="blur"){
						document.getElementById("showBlurEmail").src = "http://img.wanlibo.com/images_cn/registration/reg_zq.gif";
					}else{
						index_reg_email_ishave = true;
						index_checkRegPassword('button');
					}
				}else{
					if(type=="blur"){
						document.getElementById("showBlurEmail").src = "http://img.wanlibo.com/images_cn/registration/reg_icon_cw.gif";
						document.getElementById("showBlurEmail").alt = "璇ラ偖绠卞凡缁忓瓨鍦紝璇烽噸鏂拌緭鍏�";
					}else{
						alert("璇ラ偖绠卞凡缁忓瓨鍦紝璇烽噸鏂拌緭鍏�");
						index_reg_email_ishave = false;
						document.getElementById('regloginemail').focus();
					}
				}
			}
		);
		
		
	}
}
/************ 楠岃瘉瀵嗙爜鏄惁杈撳叆姝ｇ‘ *********************/
function index_checkRegPassword(type){
	document.getElementById("showBlurPwd").className = "val dpb";
	var v = document.getElementById("regpassword").value;
	var desc='';
	if(v.indexOf(" ")>-1){
		desc='瀵嗙爜涓嶈兘鍖呭惈绌烘牸';
	}else{
		v=trim(v);
		var c = new RegExp();   
		c = /^[A-Za-z0-9_-]+$/;  
		if(v==''){
			desc='璇锋偍杈撳叆瀵嗙爜';
		}else if(v.length<6){
			desc='瀵嗙爜闀垮害涓嶈兘灏忎簬6';
		}else if(v.length>16){
			desc='瀵嗙爜闀垮害涓嶈兘澶т簬16';
		}else if(!c.test(v)){
			desc = "鍙敮鎸佽嫳鏂� 鏁板瓧鐨勭粍鍚堬紝璇锋纭～鍐�!";
		}
	}
	if(desc!=''){
		if(type=="blur"){
			document.getElementById("showBlurPwd").src = "http://img.wanlibo.com/images_cn/registration/reg_icon_cw.gif";
			document.getElementById("showBlurPwd").alt = desc;
		}else{
			index_reg_password = false;
			alert(desc);
			document.getElementById('regpassword').focus();
		}
		return;
	}else{
		if(type=="blur"){
			document.getElementById("showBlurPwd").src = "http://img.wanlibo.com/images_cn/registration/reg_zq.gif";
		}else{
			index_reg_password = true;
			index_checkCode();
		}
		return;
	}
}
/************ 楠岃瘉楠岃瘉鐮� *********************/
function index_checkCode(){
	var code = trim(document.getElementById("yanzhengma").value);
	if(code==""){	alert("璇疯緭鍏ラ獙璇佺爜");	return;	}
	//checkLoginDwr.checkCode(code,index_showCheckCodeResult);
	jQuery("#a5").load('/jsp_cn/jquery/login/reg_check.jsp?flag=code&code='+code,index_showCheckCodeResult);
	
}
function index_showCheckCodeResult(data){
	data = trim(data.replace(/\r\n/gim,""));
	if(data=="true"){
		index_reg_rand = true;
		index_submit();
	}else{
		alert("楠岃瘉鐮佽緭鍏ラ敊璇紝璇烽噸鏂拌緭鍏�");
		index_reg_rand = false;
		document.getElementById('yanzhengma').focus();
	}
}

function index_createuser(){
	var che=document.getElementById("chAgree");
	
	if(che.checked==false){
		alert("鎮ㄨ繕娌℃湁鎺ュ彈鏉℃");
		return;
	}
	index_checkRegName('button');
	
}
function index_submit(){
	if(index_reg_name && index_reg_name_ishave && index_reg_email==true&&index_reg_email_ishave==true&&index_reg_password==true&&index_reg_rand==true){
		document.getElementById("loginForm").submit();
	}else{
		return;
	}
}

function searchGroup(){
	var searchKey = document.getElementById("searchKey");
	if(searchKey.value == "" || searchKey.value == "鎼滅储鎴戠殑灏忕粍"){
		return
	}
	var strLen = (searchKey.value.length);
	if(strLen> 32){
		alert("鎼滅储鐨勫叧閿瓧杩囬暱,璇烽噸鏂拌緭鍏�");
		searchKey.focus();
		return;
	}
	window.location.href = "/app/groupList/searchGroup?searchKey="+encodeURI(searchKey.value);
}

/*****************login-after-index  user-status***********************/
function menuPanel(obj){
	var obj = document.getElementById(obj);
	if(!obj) return false;
	var uls = obj.getElementsByTagName("ul");
	var ulcur = obj.getElementsByTagName("li")[0];
	uls[1].style.display="none";
	var divElement = document.createElement("div");
	divElement.setAttribute("id","panel_tips")
	obj.appendChild(divElement);
	ulcur.onclick = function(){
		if(uls[1].style.display=="block"){
			uls[1].style.display="none";
			uls[0].className="cur";
			document.getElementById("panel_tips").style.display="none";
		}
		else{
			uls[1].style.display="block";
			uls[0].className="active";
			document.getElementById("panel_tips").style.display="block";
		}
	}
}


//tagSwitch("panel-status","panel-menu","panel-cont","div");
//menuPanel("panel-status");

function addLoadEvent(func) {
  var oldonload = window.onload;
  if (typeof window.onload != 'function') {
    window.onload = func;
  } else {
    window.onload = function() {
      oldonload();
      func();
    }
  }
}
var naa, movenum=1;
function moveElement(elementID,stepupId,nextId,as,interval) {
	var d = document,
		elem = d.getElementById(elementID),
		boxwidth= d.getElementById(elementID).parentNode.clientWidth,
		lis = elem.getElementsByTagName("li"),
		lislength =lis.length,
		xposmax = Math.ceil(lislength/3);
		
	elem.movement&&clearTimeout(elem.movement);
	var stepup = d.getElementById(stepupId),
		next = d.getElementById(nextId);
	if(as=="lt"){
	naa=-boxwidth*movenum;
	}
	if(as=="rt"){
	naa=-boxwidth*(movenum-2);
	}
	if(as=="lt"&&movenum>(xposmax-1)){
	naa=-(boxwidth*(xposmax-1));
	num=xposmax;
	}
	if(as=="rt"&&movenum<2){
	naa=0;
	movenum=1;
	}

	if (!elem.style.left) {
	elem.style.left = "0px";
	}
	var xpos = parseInt(elem.style.left);
	if (xpos == naa) {
	if(as=="lt"&&movenum<xposmax){
	movenum++;
	}
	if(as=="rt"&&movenum>1){
	movenum--;
	}
	if(movenum>(xposmax-2))
	{
	stepup.className="left"
	next.className="noright"
	}
	if(movenum<2)
	{
	stepup.className="noleft"
	next.className="right"
	}
	if(movenum>=2&&movenum<=(xposmax-1))
	{
	stepup.className="left"
	next.className="right"
	}
	return true;
	}
	if (xpos > naa) {
	var dist = Math.ceil((xpos - naa)/10);
	xpos = xpos - dist;
	}
	if (xpos < naa) {
	var dist = Math.ceil((naa - xpos)/10);
	xpos = xpos + dist;
	}
	elem.style.left = xpos + "px";
	var repeat = "moveElement('"+elementID+"','"+stepupId+"','"+nextId+"','"+as+"','"+interval+"')";
	elem.movement = setTimeout(repeat,interval);
}

function prepareSlideshow() {
	var d = document,s=d.getElementById("hot_wrapper");
 if(!s) return false;
		links = s.getElementsByTagName("span");
		elemqq = d.getElementById("hot_container");
	elemqq = setInterval("moveElement('hot_container','stepup','next','lt',30)",3000);
    links[0].onmousedown = function() {
		moveElement("hot_container","stepup","next","lt",30);
		clearInterval(elemqq);
      }
	links[1].onmousedown = function() {
        moveElement("hot_container","stepup","next","rt",30);
		clearInterval(elemqq);
      }
}
addLoadEvent(prepareSlideshow);