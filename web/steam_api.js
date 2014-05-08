var apikey= "DE028A2732887BCDB1CCE803B9A1A24D"; // put your API key here
var domain= "steamob.com"; // put your domain


function GetOwnedGames(steamid)
{
    var url= 'http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=' + apikey + '&steamids=' + steamid;
    
    $.getJSON(url, null, function(data, status)
    {
        alert(data);    
        alert(status);
    }
    //var obj = jQuery.parseJSON(  );
    return obj.response;
}