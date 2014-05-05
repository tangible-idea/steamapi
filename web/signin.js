

window.onload= init();
//
function init()
{
    //alert("init");
   Parse.initialize("V9qM2MTpfW6TFeaud1GEh5uIGKmMOa94N8NQDAdb", "9bkxnxKoZQiDl8KR6aKk5C6G5OR9ZQK8IvKwAARE");
}

function getNumberOnly(val)
{
  var returnval = val;
  returnval = new String(returnval);
  var regex = /[^0-9]/g;
  returnval = returnval.replace(regex, '');

  return returnval;
}

function emailCheck(email_address)
{		
	email_regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/i;
	if(!email_regex.test(email_address)){ 
		return false; 
	}else{
		return true;
	}
}

// 쿠키 생성
function setCookie(cName, cValue, cDay)
{
      var expire = new Date();
      expire.setDate(expire.getDate() + cDay);
      cookies = cName + '=' + escape(cValue) + '; path=/ '; // 한글 깨짐을 막기위해 escape(cValue)를 합니다.
      if(typeof cDay != 'undefined') cookies += ';expires=' + expire.toGMTString() + ';';
      document.cookie = cookies;
}

 // 쿠키 가져오기
function getCookie(cName)
{
      cName = cName + '=';
      var cookieData = document.cookie;
      var start = cookieData.indexOf(cName);
      var cValue = '';
      if(start != -1){
           start += cName.length;
           var end = cookieData.indexOf(';', start);
           if(end == -1)end = cookieData.length;
           cValue = cookieData.substring(start, end);
      }
      return unescape(cValue);
}

// 엔터 이벤트 처리.
function hitEnterKey(e)
{
  if(e.keyCode == 13)
  {
      onLogin();
  }else{
    e.keyCode == 0;
    return;
  }
} 

function onLogin()
{
    //alert('onLogin');
    var inputEmail = $("#inputEmail1");
    var inputPW = $("#inputPassword1");
    
    var email= inputEmail.val();
    if(emailCheck(inputEmail.val()) == true)
    {
    }else{
        alert("올바른 이메일을 입력해주세요 :)");
        return;
    }
    
    var pw= inputPW.val();
    if(pw.length <= 5)
    {
        alert("패스워드를 6자 이상으로 입력해주세요 :)");
        return;
    }
    
    //alert(email);
    //alert(pw);

    // 로그인 시도 (parse back end server)
    Parse.User.logIn(email, pw, {
      success: function(user) {
          setCookie("login", true, 1);
          var url = "http://raimsoft.com/steam/";    
          $(location).attr('href',url);
      },
      error: function(user, error) {
          alert("잘못된 이메일 또는 패스워드 입니다.");
      }
    });
}

    