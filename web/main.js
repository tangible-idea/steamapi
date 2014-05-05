 //alert("init");
 init();

$(document).ready(function(){
            $(".my-popup").popover({
                placement : 'bottom'
            });
        });

function init()
{

   Parse.initialize("V9qM2MTpfW6TFeaud1GEh5uIGKmMOa94N8NQDAdb", "9bkxnxKoZQiDl8KR6aKk5C6G5OR9ZQK8IvKwAARE");

    //alert("Parse init successful");    
    //var inputEmail= $("inputEmail1");
    //alert(inputEmail);
    
	//var button = document.getElementById("signup_next"); // 아이디를 이용하여서 버튼의 정보를 얻고
    //alert(button);
	//button.onclick = OnNext; // 버튼 클릭시에 handleButtonClick을 호출하게 함.
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
        alert("패스워드를 6~10자로 입력해주세요 :)");
        return;
    }
    
    //alert(inputEmail.val());
    //alert(inputPW.val());
    //alert( getNumberOnly(inputCount.text()) );
    //alert( getNumberOnly(inputSteamID.text()) );
        
     var user = new Parse.User();
    user.set("username", getNumberOnly(inputSteamID.text()) );
    user.set("email", inputEmail.val());
    user.set("password", inputPW.val());
    //user.set("steam_id", getNumberOnly(inputSteamID.text()) );
    user.set("steam_game_count", getNumberOnly(inputCount.text()) );
      
     // other fields can be set just like with Parse.Object
     //user.set("phone", "650-555-0000");
        
     user.signUp(null, {
       success: function(user) {
          // Hooray! Let them use the app now.
          alert("가입 완료!");
           
          var url = "http://raimsoft.com/steam/";    
          $(location).attr('href',url);
       },
       error: function(user, error) {
         // Show the error message somewhere and let the user try again.
         if(error.code == 202)
         {
             alert("해당 스팀ID로 가입된 유저가 이미 존재합니다.");
         }else{
            alert("Error: " + error.code + " " + error.message);
         }
       }
     });
    
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

