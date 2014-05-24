<?php
include("steam_api.php");

if(!$_COOKIE['steamID'])  // 연동 전
{
    print ('<form action="steam_user.php?login" method="post">
        <input type="image" src="http://cdn.steamcommunity.com/public/images/signinthroughsteam/sits_large_border.png"/>
        </form>');
    print('스팀 계정으로 로그인 연동 합니다.');
}
else  // 연동 후...
{
    echo('<form action="steam_user.php?logout" method="post">
            <button title="Logout" class="btn btn-default name="logout">연동 해제</button>
            <a href="#" class="btn btn-default my-popup" data-toggle="popover" title="게임 개수를 확인하는 이유" data-content="당신의 성향을 파악하기 위한 최소한의 보유 게임 개수가 필요합니다.">?</a></form>');

ob_start();
    echo('<p>잠시만 기다려주세요...</p>');
    $steam_name= $steam_api->GetPlayerSummaries($_COOKIE['steamID'])->personaname;
    $steam_id= $steam_api->GetPlayerSummaries($_COOKIE['steamID'])->steamid;
    $nOwnedGameCount= $steam_api->GetOwnedGames($_COOKIE['steamID'])->game_count;
ob_end_clean();

    print('</p>아이디 : ');
    echo $steam_name;
    print('</br>인증키 : ');
    echo('<label class="control-label" id="steamID">' .$steam_id .'</label>');

    if($nOwnedGameCount > 50)
    {
      echo('<div class="form-group has-success has-feedback">
      <label class="control-label" for="inputSuccess2" id="gameCount">'.'소유 게임 개수 : ' .$nOwnedGameCount .'개</label>
      <span class="glyphicon glyphicon-ok form-control-feedback"></span>
      </div>');

      echo('<p><input type="email" class="form-control" id="inputEmail1" maxlength="50" placeholder="Email"></p>');
      echo('<p><input type="password" class="form-control" id="inputPassword1" maxlength="20" placeholder="Password" onKeypress="hitEnterKey(event)"></p>');

      echo('<p><a herf="#" class="btn btn-success" onclick="onNext()">회원가입</a></p>');
    }
    else
    {
      echo('<div class="form-group has-error has-feedback">
      <label class="control-label" for="inputError2">'.'소유 게임 개수 : ' .$nOwnedGameCount .'개</label>
      <span class="glyphicon glyphicon-remove form-control-feedback"></span>
      </div>');
    }
}
?>