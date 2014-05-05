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

    alert("Parse init successful");    
	//var button = document.getElementById("addButton"); // 아이디를 이용하여서 버튼의 정보를 얻고
	//button.onclick = handleButtonClick; // 버튼 클릭시에 handleButtonClick을 호출하게 함.
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