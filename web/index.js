window.onload= init();

function init()
{
        //alert("init");
   Parse.initialize("V9qM2MTpfW6TFeaud1GEh5uIGKmMOa94N8NQDAdb", "9bkxnxKoZQiDl8KR6aKk5C6G5OR9ZQK8IvKwAARE");        
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


