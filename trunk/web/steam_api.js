var apikey= "DE028A2732887BCDB1CCE803B9A1A24D"; // put your API key here
var domain= "steamob.com"; // put your domain


function GetOwnedGames(steamid)
{
    var myurl = 'http://wikidata.org/w/api.php?action=wbgetentities&sites=frwiki&titles=France&languages=zh-hans|zh-hant|fr&props=sitelinks|labels|aliases|descriptions&format=json';
    //http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=DE028A2732887BCDB1CCE803B9A1A24D&steamids=76561198013979478
    //var myurl= 'http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=' + apikey + '&steamids=' + steamid;
    //var myAPI1= "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002";
    
//    $.getJSON( url + '&callback=?', function(data)
//    {
//        alert(data);
//    });
    
//    $.ajax({
//    url : myurl,
//    dataType : "jsonp",
//    jsonp : "callback",
//    success: function(data)
//    {
//        if(data != null)
//        {
//            alert(data.result + ", " +  data.go);
//        }
//    }
//    });
    
    $.ajax({
    url: myurl,
    dataType: 'jsonp',
    jsonpCallback: "myCallback",
    success: function(data) {
      console.log('성공 - ', data);
    },
    error: function(xhr) {
      console.log('실패 - ', xhr);
    }
  });
}