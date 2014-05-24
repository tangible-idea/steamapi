<?php
error_reporting(E_ERROR | E_PARSE | E_WARNING);

$steam_api = new steam_api;
$steam_api->apikey = "DE028A2732887BCDB1CCE803B9A1A24D"; // put your API key here
$steam_api->domain = "steamob.com"; // put your domain


class steam_api
{
    public static $apikey;
    public static $domain;
    
    public function GetPlayerSummaries ($steamid)
    {
        $response = file_get_contents('http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=' . $this->apikey . '&steamids=' . $steamid);
        $json = json_decode($response);
        return $json->response->players[0];
    }

    public function GetOwnedGames ($steamid)
    {
        //http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=DE028A2732887BCDB1CCE803B9A1A24D&steamid=76561198013979478
        $response = file_get_contents('http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=' . $this->apikey . '&steamid=' . $steamid);
        $json = json_decode($response);
        return $json->response;
    }

    public function GetFriendList ($steamid)
    {
        $response = file_get_contents('http://api.steampowered.com/ISteamUser/GetFriendList/v0001/?key=' . $this->apikey . '&steamid=' . $steamid);
        $json = json_decode($response);
        return $json->friendslist;
    }
}