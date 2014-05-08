 //alert("init");

window.onload= init();



function init()
{                
   Parse.initialize("V9qM2MTpfW6TFeaud1GEh5uIGKmMOa94N8NQDAdb", "9bkxnxKoZQiDl8KR6aKk5C6G5OR9ZQK8IvKwAARE");
    
    $(document).ready(function(){
            $(".my-popup").popover({
                placement : 'bottom'
            });
        });
    
    checkLogin();
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
      onNext();
  }else{
    e.keyCode == 0;
    return;
  }
} 


function checkLogin()
{
        // signup 을 띄울 것인지, dashboard로 가는 버튼을 띄울 것인지
    //var cookie= getCookie("login");
    var currentUser = Parse.User.current();
        
    var dom1= $("div .jumbotron");
    var dom2= $("#top3");    
        
    if(currentUser)    // 로그인 되어있으면...
    {
        dom1.append('<p><a class="btn btn-lg btn-success" data-loading-text="Loading..." href="board.html">성향 분석</a></p>');
        dom2.html("Logout");
    }else{
        dom1.append('<p><a class="btn btn-lg btn-success" data-loading-text="Loading..." href="signup.html">가입하기</a></p>');
        dom2.html("Login");
    }
    // 버튼 누를때 로딩으로 바꾸는 부분 (boostrap)
    $('a[data-loading-text]')
    .click(function () {
    var btn = $(".btn-success")
    btn.button('loading')
    setTimeout(function () {
        btn.button('reset')
    }, 30000)
    });

}

function onLogInStat()
{    
    var top3= $("#top3");     
    if(top3.html() == "Login")
    {
        var url = "http://steamob.com/steam/signin.html";    
        $(location).attr('href',url);
    }
    else
    {
        Parse.User.logOut();    // 로그 아웃
        //setCookie("login", 0, -1);  // 쿠키 삭제.
        
        var url = "http://steamob.com/steam/";    
        $(location).attr('href',url);
    }
}


function onNext()
{
    var inputEmail = $("#inputEmail1");
    var inputPW = $("#inputPassword1");
    var inputCount = $("#gameCount");
    var inputSteamID = $("#steamID");
    
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
    
    var query = new Parse.Query(Parse.User);
    query.equalTo("steam_id", getNumberOnly(inputSteamID.text()) );  // find all the women
    query.find({
      success: function(existSteamIdUsers)
      {
        if(existSteamIdUsers.length != 0) // 이미 같은 스팀ID로 가입되어 있는 회원이 있으면 안됨.
        {
            alert("해당 스팀ID로 가입된 유저가 이미 존재합니다.");
            return;
        }
          
        var user = new Parse.User();
        //user.set("username", getNumberOnly(inputSteamID.text()) );
        user.set("username", inputEmail.val());
        user.set("email", inputEmail.val());
        user.set("password", inputPW.val());
        user.set("steam_id", getNumberOnly(inputSteamID.text()) );
        user.set("steam_game_count", getNumberOnly(inputCount.text()) );

         // other fields can be set just like with Parse.Object
         //user.set("phone", "650-555-0000");

         user.signUp(null, {
           success: function(user) {
              // Hooray! Let them use the app now.
              setCookie("login", true, 1);
              alert("가입이 완료되었습니다.\n이메일 인증을 완료하시면 추후 비밀번호를 찾을 때 도움이 됩니다.");

              var url = "http://raimsoft.com/steam/";    
              $(location).attr('href',url);
           },
           error: function(user, error) {
             // Show the error message somewhere and let the user try again.
             if(error.code == 202)
             {
                 alert("해당 이메일로 가입된 유저가 이미 존재합니다.");
             }else{
                alert("Error: " + error.code + " " + error.message);
             }
           }
         });
      }
    });
    

    if(ExistCount != 0)
        return;
    
    
    
}
// function handleButtonClick(e) 
// {
//     alert("Please enter a song"); // 버튼을 누르면 나오게 되는 메세지.

//     var user = new Parse.User();
//     user.set("username", "my name");
//     user.set("password", "my pass");
//     user.set("email", "email@example.com");
      
//     // other fields can be set just like with Parse.Object
//     user.set("phone", "650-555-0000");
      
//     user.signUp(null, {
//       success: function(user) {
//         // Hooray! Let them use the app now.
//       },
//       error: function(user, error) {
//         // Show the error message somewhere and let the user try again.
//         alert("Error: " + error.code + " " + error.message);
//       }
//     });
// }

