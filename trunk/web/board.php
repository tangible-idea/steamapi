<?php

include("steam_api.php");

$map_id= array();
$map_genre= array();
$map_all= array();

//function findGenre($match_id)
//{
//    echo(count($map_id));
//    for($i=0; $i < count($map_id); $i++)
//    {
//        echo($i);
//        if( $map_id[$i] == $match_id )
//        {
//            return $map_genre[i];
//        }
//    }
//}


if(!$_COOKIE['steamID'])  // 연동 전
{
    echo('<p>not login</p>');
}
else
{
    echo('<p>already login</p>');

    // genre 텍스트 읽어서 데이터 매핑...
    $fp = fopen("steam_app_genres.json","r");    
    while( !feof($fp) ) // 한 줄씩 읽자
    {
        $data = fgets($fp);

        $data= str_replace("'", "", $data);
        $data= str_replace("(", "", $data);
        $data= str_replace(")", "", $data);
        $data= str_replace(" ", "", $data);

        $info= explode(",", $data);
        
        $map_all[$info[0]]= $info[1];
        //array_push($map_id, $info[0]);
        //array_push($map_genre, $info[1]);        
        //echo "<p>game_id: " .$info[0] ." \tgenre: " .$info[1] ."</p>";
    }
    fclose($fp);
    
    // 스팀 API로 유저 게임 정보 읽어서 맵핑된 정보에 매칭시킴.    
    $steamID= $steam_api->GetPlayerSummaries($_COOKIE['steamID'])->steamid;
    $Owned= $steam_api->GetOwnedGames($steamID);

    echo('<p>' .$Owned->game_count .'</p>');
    for($i= 0; $i < $Owned->game_count; $i++)
    {
        //echo('<p>game_id: ' .$Owned->games[$i]->appid .'</p>');
        //echo( findGenre($Owned->games[$i]->appid) );
        echo( $map_all[$Owned->games[$i]->appid] );
        
    }

}

?>