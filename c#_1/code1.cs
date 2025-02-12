

<!DOCTYPE HTML SYSTEM>


<html>


	<head>


		<title>Mario Kart PC</title>


<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">


<meta name="author" content="Timothé Malahieude" />


<meta name="description" content="Free online Mario Kart game" />


<meta name="keywords" content="Mario, Kart, PC, game, race, free game, multiplayer, track builder" />


<meta name="viewport" content="width=device-width, user-scalable=no" />


<meta name="thumbnail" content="https://mkpc.malahieude.net/images/screenshots/ss1.png" />


<meta property="og:image" content="https://mkpc.malahieude.net/images/screenshots/ss1.png" />


	<link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" /><link rel="stylesheet" media="screen" type="text/css" href="styles/mariokart.css" />


<link rel="stylesheet" media="screen" type="text/css" href="styles/collabs.css" />


<script defer type="text/javascript" src="scripts/collabs.js?reload=1"></script><link rel="stylesheet" media="screen" type="text/css" href="styles/comments.css?reload=1" /><link rel="stylesheet" type="text/css" href="styles/online.css" />


<script defer src="scripts/online.js"></script><script type="text/javascript">


var selectedPlayers = 19;


var selectedTeams = 0;


var selectedDifficulty = 1;


var challenges = {"mcup":[],"cup":[],"track":[]};


var clRewards = [];


var clId = 0;


var language = true;


var recorder = "";


var lCircuits = ["&nbsp;"];


var cupOpts = {};


var cp = {


	"mario":[0.5,0.5,0.5,0.5],


	"luigi":[0.625,0.5,0.375,0.5],


	"peach":[0.75,0.375,0.75,0.25],


	"toad":[0.625,0.375,0.625,0],


	"yoshi":[0.5,0.5,0.5,0.5],


	"bowser":[0,1,0.125,1],


	"donkey-kong":[0.25,0.875,0,0.875],


	"daisy":[1,0.375,1,0.25],


	"wario":[0.5,0.75,0,0.75],


	"koopa":[0.375,0.5,0.625,0.375],


	"waluigi":[0.875,0.25,0.625,0.625],


	"maskass":[0.625,0.5,0.375,0.5],


	"birdo":[0.875,0.125,0.875,0.5],


	"roi_boo":[0.375,0.75,0.125,0.75],


	"frere_marto":[0.125,0.625,0.375,0.625],


	"bowser_skelet":[0.25,0.875,0.125,0.875],


	"flora_piranha":[0.25,1,0,1],


	"link":[0.75,0.5,0.25,0.625],


	"bowser_jr":[0.75,0.375,0.5,0.375],


	"harmonie":[0,0.625,0.5,0.625],


	"diddy-kong":[0.5,0.375,0.75,0],


	"skelerex":[0.25,0.5,0.75,0.25],


	"funky-kong":[0.25,0.75,0.25,0.875],


	"toadette":[0.75,0.25,0.75,0]


};


var pUnlocked = [1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];


var baseOptions = {


	quality: localStorage.getItem("iQuality") ? +localStorage.getItem("iQuality") : 5,


	music: localStorage.getItem("bMusic") ? +localStorage.getItem("bMusic"):0,


	sfx: localStorage.getItem("iSfx") ? +localStorage.getItem("iSfx"):0,


	screenscale: localStorage.getItem("iScreenScale") ? +localStorage.getItem("iScreenScale"):(screen.width<800)?((screen.width<480)?4:6):((screen.width<1500)?8:10)};


var page = "CI";


var PERSOS_DIR = "images/sprites/uploads/";


var isBattle = false;


var isCup = true;


var isSingle = true;


var complete = false;


var simplified = true;


var nid = null;


var edittingCircuit = true;


var NBCIRCUITS = 1;


function listMaps() {


	return {"map1":{	"map" : "?p0=5&p1=9&p2=9&p3=4&p4=5&p5=4&p6=6&p7=4&p8=5&p9=7&p10=8&p11=8&p12=11&p13=8&p14=6&p15=4&p16=0&p17=8&p18=11&p19=8&p20=11&p21=6&p22=7&p23=8&p24=5&p25=7&p26=5&p27=9&p28=4&p29=8&p30=6&p31=9&p32=7&p33=11&p34=6&p35=7&a0=563,240&a1=529,381&a2=545,504&a3=551,105&b0=197,547&c0=156,179&c1=127,297&c2=157,409&c3=46,507&d0=163,48&d1=301,43&map=43",


	"tours" : 9,


	"music" : 30,


	"w" : 600,


	"h" : 600,


		"skin" : 43,


	"bgcolor" : [65,40,20],


	"fond" : ["wariosky","tribune","wariobanner"],	"collision" : [


		[[100,28],[70,37],[45,56],[28,79],[28,100],[0,100],[0,0],[100,0]],[[72,100],[72,97],[97,72],[100,72],[100,100]],[100,0,100,28],[100,72,100,28],[200,0,100,28],[200,72,100,28],[[372,97],[392,77],[392,37],[363,8],[323,8],[303,28],[300,28],[300,0],[400,0],[400,100],[372,100]],[[328,100],[320,82],[300,73],[300,100]],[[500,28],[470,37],[445,56],[428,79],[428,100],[400,100],[400,0],[500,0]],[[472,100],[472,97],[497,72],[500,72],[500,100]],[[572,97],[592,77],[592,37],[563,8],[523,8],[503,28],[500,28],[500,0],[600,0],[600,100],[572,100]],[[528,100],[520,82],[500,73],[500,100]],[[72,100],[72,111],[96,128],[100,128],[100,100]],[[28,100],[30,136],[54,164],[76,172],[100,172],[100,200],[0,200],[0,100]],[[172,197],[192,177],[192,137],[163,108],[123,108],[103,128],[100,128],[100,100],[200,100],[200,200],[172,200]],[[128,200],[120,182],[100,173],[100,200]],[[300,128],[270,137],[245,156],[228,179],[228,200],[200,200],[200,100],[300,100]],[[272,200],[272,197],[297,172],[300,172],[300,200]],[[328,100],[321,122],[300,128],[300,100]],[[300,172],[322,172],[348,166],[368,148],[372,126],[372,100],[400,100],[400,200],[300,200]],[400,100,28,100],[472,100,28,100],[500,100,28,100],[572,100,28,100],[0,200,100,100],[100,200,28,100],[172,200,28,100],[[272,200],[272,211],[296,228],[300,228],[300,200]],[[228,200],[230,236],[254,264],[276,272],[300,272],[300,300],[200,300],[200,200]],[[372,297],[392,277],[392,237],[363,208],[323,208],[303,228],[300,228],[300,200],[400,200],[400,300],[372,300]],[[328,300],[320,282],[300,273],[300,300]],[400,200,28,100],[472,200,28,100],[500,200,28,100],[572,200,28,100],[0,300,100,100],[100,300,28,100],[172,300,28,100],[200,300,100,100],[[372,300],[372,311],[396,328],[400,328],[400,300]],[[328,300],[330,336],[354,364],[376,372],[400,372],[400,400],[300,400],[300,300]],[[428,300],[421,322],[400,328],[400,300]],[[400,372],[422,372],[448,366],[468,348],[472,326],[472,300],[500,300],[500,400],[400,400]],[500,300,28,100],[572,300,28,100],[[100,428],[70,437],[45,456],[28,479],[28,500],[0,500],[0,400],[100,400]],[[72,500],[72,497],[97,472],[100,472],[100,500]],[[128,400],[121,422],[100,428],[100,400]],[[100,472],[122,472],[148,466],[168,448],[172,426],[172,400],[200,400],[200,500],[100,500]],[[300,428],[270,437],[245,456],[228,479],[228,500],[200,500],[200,400],[300,400]],[[272,500],[272,497],[297,472],[300,472],[300,500]],[300,400,100,28],[300,472,100,28],[[472,497],[492,477],[492,437],[463,408],[423,408],[403,428],[400,428],[400,400],[500,400],[500,500],[472,500]],[[428,500],[420,482],[400,473],[400,500]],[500,400,28,100],[572,400,28,100],[[72,500],[72,511],[96,528],[100,528],[100,500]],[[28,500],[30,536],[54,564],[76,572],[100,572],[100,600],[0,600],[0,500]],[100,500,100,28],[100,572,100,28],[[228,500],[221,522],[200,528],[200,500]],[[200,572],[222,572],[248,566],[268,548],[272,526],[272,500],[300,500],[300,600],[200,600]],[300,500,100,100],[[472,500],[472,511],[496,528],[500,528],[500,500]],[[428,500],[430,536],[454,564],[476,572],[500,572],[500,600],[400,600],[400,500]],[[528,500],[521,522],[500,528],[500,500]],[[500,572],[522,572],[548,566],[568,548],[572,526],[572,500],[600,500],[600,600],[500,600]],	],	"startposition" : [459,297,0],


	"startdirection" : 6,


	"startrotation" : 0,


	"checkpoint" : [


		[404,284,93,1],[400,300,97,1],[386,300,97,0],[300,286,97,1],[286,200,97,0],[204,186,97,1],[300,100,97,0],[300,86,97,1],[86,4,97,0],[4,100,97,1],[100,104,97,0],[100,400,97,1],[86,404,97,0],[4,500,97,1],[200,500,97,0],[204,486,97,1],[400,404,97,0],[404,500,97,1],[500,500,97,0],[500,86,97,1],[486,4,97,0],	],


	trous:{cp:[]},	"sauts" : [


			],


	"accelerateurs" : [


		[563,240],[529,381],[545,504],[551,105],[197,547],[156,179],[127,297],[157,409],[46,507],[163,48],[301,43],	],


	"arme" : [


		[369,323],[350,337],[357,334],[361,330],[365,327],[342,342],[373,325],[370,107],[361,108],[357,108],[332,107],[341,107],[348,108],[357,106],[364,105],[357,105],[338,105],[337,103],[64,40],[71,42],[74,53],[82,63],[85,65],[96,69],[85,61],[75,53],[70,48],[167,429],[164,429],[152,425],[141,428],[133,428],[128,428],[132,429],[158,429],[151,428],[149,428],[218,534],[208,564],[209,564],[209,559],[209,557],[211,552],[217,541],[217,541],[215,540],[212,545],[213,547],[431,513],[440,512],[461,509],[459,509],[447,512],[440,513],[446,512],[454,511],[459,511],[478,507],[532,280],[541,279],[560,280],[581,278],[563,281],[563,281],[551,283],[545,281],[552,280],[554,280],[580,278],[581,280],[469,196],[464,196],[458,196],[436,196],[436,196],[457,196],[445,194],[443,195],[442,197],[436,196],	],


		"horspistes" : {


		choco:[[[375,100],[352,48],[300,25],[300,0],[400,0],[400,100]],[[575,100],[552,48],[500,25],[500,0],[600,0],[600,100]],[[175,200],[152,148],[100,125],[100,100],[200,100],[200,200]],[[375,300],[352,248],[300,225],[300,200],[400,200],[400,300]],[[475,500],[452,448],[400,425],[400,400],[500,400],[500,500]],]	},


		"aipoints" : [


		[439,339],[360,339],[339,260],[260,239],[260,160],[339,139],[339,60],[250,50],[150,50],[60,60],[60,139],[139,160],[150,250],[150,350],[139,439],[60,460],[60,539],[150,550],[239,539],[260,460],[350,450],[439,460],[460,539],[539,539],[550,450],[550,350],[550,250],[550,150],[539,60],[460,60],[450,150],[450,250],	],


	"decor" : {


		"firering":[[251,207],[350,325],[265,472],[456,522],[50,526]],"fire3star":[[555,100],[533,377],[567,235],[50,516],[160,49],[301,46],[133,306],[162,416],[161,186]]	}


		,


	"decorparams" : {


				"firering": [


			{dir:2.3561944901923},{dir:-0.78539816339745},{dir:3.9269908169872},{dir:-0.78539816339745},{dir:2.3561944901923}		]


		,		"fire3star": [


			{dir:4.7123889803847},{dir:1.5707963267949},{dir:4.7123889803847},{dir:-0.78539816339745},{dir:3.1415926535898},{dir:-0.78539816339745},{dir:4.7123889803847},{dir:0.78539816339745},{dir:2.3561944901923}		]


			}


			}};


}


</script>


<script type="text/javascript" src="scripts/mk.v269.js"></script><script type="text/javascript">


function saveRace() {


document.getElementById("cAnnuler").disabled = true;


document.getElementById("cAnnuler").className = "cannotChange";


document.getElementById("cEnregistrer").disabled = true;


document.getElementById("cEnregistrer").className = "cannotChange";


var $form = document.getElementById("cSave");


var formData = new FormData($form);


if (!$form.elements["name_tr"].checked) {


formData.delete("name_en");


formData.delete("name_fr");


}


formData.delete("name_tr");






var extraData = {"map":43,"p0":5,"p1":9,"p2":9,"p3":4,"p4":5,"p5":4,"p6":6,"p7":4,"p8":5,"p9":7,"p10":8,"p11":8,"p12":11,"p13":8,"p14":6,"p15":4,"p16":0,"p17":8,"p18":11,"p19":8,"p20":11,"p21":6,"p22":7,"p23":8,"p24":5,"p25":7,"p26":5,"p27":9,"p28":4,"p29":8,"p30":6,"p31":9,"p32":7,"p33":11,"p34":6,"p35":7,"nl":9,"a0":"563,240","a1":"529,381","a2":"545,504","a3":"551,105","b0":"197,547","c0":"156,179","c1":"127,297","c2":"157,409","c3":"46,507","d0":"163,48","d1":"301,43","o0":"369,323","o1":"350,337","o2":"357,334","o3":"361,330","o4":"365,327","o5":"342,342","o6":"373,325","o7":"370,107","o8":"361,108","o9":"357,108","o10":"332,107","o11":"341,107","o12":"348,108","o13":"357,106","o14":"364,105","o15":"357,105","o16":"338,105","o17":"337,103","o18":"64,40","o19":"71,42","o20":"74,53","o21":"82,63","o22":"85,65","o23":"96,69","o24":"85,61","o25":"75,53","o26":"70,48","o27":"167,429","o28":"164,429","o29":"152,425","o30":"141,428","o31":"133,428","o32":"128,428","o33":"132,429","o34":"158,429","o35":"151,428","o36":"149,428","o37":"218,534","o38":"208,564","o39":"209,564","o40":"209,559","o41":"209,557","o42":"211,552","o43":"217,541","o44":"217,541","o45":"215,540","o46":"212,545","o47":"213,547","o48":"431,513","o49":"440,512","o50":"461,509","o51":"459,509","o52":"447,512","o53":"440,513","o54":"446,512","o55":"454,511","o56":"459,511","o57":"478,507","o58":"532,280","o59":"541,279","o60":"560,280","o61":"581,278","o62":"563,281","o63":"563,281","o64":"551,283","o65":"545,281","o66":"552,280","o67":"554,280","o68":"580,278","o69":"581,280","o70":"469,196","o71":"464,196","o72":"458,196","o73":"436,196","o74":"436,196","o75":"457,196","o76":"445,194","o77":"443,195","o78":"442,197","o79":"436,196","t0":"251,207","t1":"350,325","t2":"265,472","t3":"456,522","t4":"50,526","t1_0":"555,100","t1_1":"533,377","t1_2":"567,235","t1_3":"50,516","t1_4":"160,49","t1_5":"301,46","t1_6":"133,306","t1_7":"162,416","t1_8":"161,186"};


for (var key in extraData)


formData.append(key, extraData[key]);






fetch("api/saveCreation.php", {


body: formData,


method: "POST"


}).then(function(res) {


return res.text();


}).then(function(reponse) {


if (reponse && !isNaN(reponse)) {


var cP = document.createElement("p");


cP.style.margin = "5px";


cP.style.textAlign = "center";


cP.innerHTML = 'Your circuit has just been added to the <a href="creations.php" target="_blank">list</a>!<br /><br />';


var cCont = document.createElement("input");


cCont.type = "button";


cCont.value = language ? "Continue":"Continuer";


cCont.onclick = function() {


document.location.href = "?id="+ reponse; };


cP.appendChild(cCont);


document.getElementById("cTable").innerHTML = '<tr><td id="cTableSingleCell"></td></tr>';


document.getElementById("cTableSingleCell").appendChild(cP);


document.getElementById("changeRace").onclick = function() {


document.location.href = "create.php?id="+ reponse +"";


};


cCont.focus();


}


else


throw new Error();


}).catch(function() {


alert(language ? "An error occured while saving" : "Une erreur est survenue lors de l'enregistrement");


document.getElementById("cAnnuler").disabled = false;


document.getElementById("cAnnuler").className = "";


document.getElementById("cEnregistrer").disabled = false;


document.getElementById("cEnregistrer").className = "";


});


}


function getValue(name) {


var $form = document.getElementById("cSave");


return encodeURIComponent($form.elements[name].value);


}


function showPrefixHelp() {


alert(language ? "Will appear before the circuit name, this allows to disambiguate 2 circuits of the same name in a different series (Ex: SNES Rainbow Road / DS Rainbow Road)" : "Apparaitra avant le nom du circuit, permet de lever l'ambiguité entre 2 circuits du même nom mais d'une série différente (Ex : SNES Route Arc-en-Ciel / DS Route Arc-en-Ciel)");


}


function toggleShareForm(show) {


var $form = document.getElementById("cSave");


if (show) {


$form.style.display = 'flex';


if (getValue("cPseudo"))


$form.elements["cName"].select();


else


$form.elements["cPseudo"].select();


document.addEventListener("keydown", closeShareFormOnEscape);


}


else {


var $cancelBtn = document.getElementById('cAnnuler');


if (!$cancelBtn || $cancelBtn.disabled)


return;


$form.style.display = 'none';


document.removeEventListener("keydown", closeShareFormOnEscape);


}


}


function handleShareBackdropClick(e) {


if (e.target.id === "cSave")


toggleShareForm(false);


}


function closeShareFormOnEscape(e) {


if (e.keyCode === 27) {


e.stopPropagation();


toggleShareForm(false);


}


}


function toggleAdvancedOptions(show) {


var $table = document.getElementById("cTable");


if (show)


$table.classList.add("cShowAdvanced");


else


$table.classList.remove("cShowAdvanced");


}


function removeThumbnail() {


var $form = document.getElementById("cSave");


$form.querySelector(".cThumbnailValue").removeChild($form.querySelector(".cThumbnailCurrent"));


$form.elements["thumbnail_unset"].value = "1";


}


function toggleNameTr(show) {


var $table = document.getElementById("cTable");


if (show) {


$table.classList.add("cShowTr");


var $mainLanguage = document.getElementById(language ? "cNameEn" : "cNameFr");


var $otherLanguage = document.getElementById(language ? "cNameFr" : "cNameEn");


if (!$mainLanguage.value)


$mainLanguage.value = document.getElementById("cName").value;


$otherLanguage.select();


}


else


$table.classList.remove("cShowTr");


}


	circuitName = "", circuitAuthor = "", circuitDesc = null, circuitNote = 0, circuitNotes = 0,


	circuitDate = "";


	var circuitUser = null;


</script>


<script type="text/javascript" src="scripts/ratings.js"></script>


<script src="scripts/jquery.min.js"></script>


<script type="text/javascript">$(document).ready(MarioKart);</script>


</head>


<body>


<div id="mariokartcontainer"></div>






<div id="virtualkeyboard"></div>






<form name="modes" method="get" action="#null" onsubmit="return false">


<div id="options-ctn">


<table cellpadding="3" cellspacing="0" border="0" id="options" class="ct-actions">


<tr>


<td id="pSize">&nbsp;</td>


<td id="vSize">


</td>


<td rowspan="4" id="commandes">&nbsp;</td>


<td rowspan="4" id="shareParams">


<input type="button" id="changeRace" onclick="document.location.href='create.php'+document.location.search" value="Edit circuit" /><br /> <br />


<input type="button" id="shareRace" onclick="toggleShareForm(true)" value="Share circuit" /></td></tr>


<tr><td id="pMusic">


&nbsp;


</td>


<td id="vMusic">


&nbsp;


</td></tr>


<tr><td id="pSfx">


&nbsp;


</td>


<td id="vSfx">


&nbsp;


</td></tr>


<tr><td id="pFps">


&nbsp;


</td>


<td id="vFps">


&nbsp;


</td></tr>


</table>


</div>


<div id="vPub"><script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>


<!-- Mario Kart PC -->


<ins class="adsbygoogle"


style="display:inline-block;width:468px;height:60px"


data-ad-client="ca-pub-1340724283777764"


data-ad-slot="6691323567"></ins>


<script>


(adsbygoogle = window.adsbygoogle || []).push({});


</script><script async type="text/javascript" src="scripts/grlp.js?reload=1"></script></div></form>


<div id="confirmSuppr" onclick="handleUnshareBackdropClick(event)">


<div class="confirmSupprDialog">


<p id="supprInfos">Stop sharing this circuit?<br />


The circuit will be only removed from the list:<br />


data will be recoverable.</p>


<p id="supprButtons"><input type="button" value="Cancel" id="sAnnuler" onclick="document.getElementById('confirmSuppr').style.display='none'" /> &nbsp; <input type="button" value="Delete" id="sConfirmer" onclick="supprRace()" /></p>


</div>


</div>


<form id="cSave" method="post" action="" onclick="handleShareBackdropClick(event)" onsubmit="saveRace();return false">


<table id="cTable">


<tr><td class="cLabel"><label for="cPseudo">Enter a username:</label></td><td><input type="text" name="auteur" id="cPseudo" value="" placeholder="Yoshi64" /></td></tr>


<tr><td class="cLabel"><label for="cName">Circuit name:</label></td><td><input type="text" name="nom" id="cName" value="" placeholder="Mario Circuit" /></td></tr>


<tr class="cAdvanced"><td colspan="2" class="cToggle"><label><input type="checkbox" name="name_tr" onclick="toggleNameTr(this.checked)" /> Translate circuit name</label></td></tr>


<tr class="cAdvanced cTogglable-cNameTr"><td class="cLabel"><label for="cNameEn">Circuit name [EN]:</label></td><td><input type="text" name="name_en" id="cNameEn" value="" placeholder="Mario Circuit" /></td></tr>


<tr class="cAdvanced cTogglable-cNameTr"><td class="cLabel"><label for="cNameFr">Circuit name [FR]:</label></td><td><input type="text" name="name_fr" id="cNameFr" value="" placeholder="Circuit Mario" /></td></tr>


<tr class="cAdvanced"><td colspan="2">


<div class="cThumbnail">


<label for="cThumbnail">Thumbnail:</label>


<div class="cThumbnailValue">


<div class="cThumbnailInput">


<input type="file" name="thumbnail" id="cThumbnail" accept="image/png,image/gif,image/jpeg" /></td></tr>


</div>


</div>


<tr class="cAdvanced"><td class="cLabel"><label for="cPrefix">Prefix<a class="cHelp" href="javascript:showPrefixHelp()">[?]</a>:</label></td><td><input type="text" name="prefix" id="cPrefix" value="" placeholder="DS" /></td></tr>


<tr><td colspan="2" id="cSubmit">


<div class="cSubmit">


<div class="cActions">


<input type="button" class="cSecondary" value="Cancel" id="cAnnuler" onclick="toggleShareForm(false)" /> &nbsp; <input type="submit" value="Share" id="cEnregistrer" />


</div>


<div class="cOptions">


<div class="cOptionsShow"><a href="javascript:toggleAdvancedOptions(true)">More options</a> &gt;</div>


<div class="cOptionsHide">&lt; <a href="javascript:toggleAdvancedOptions(false)"> Less options</a></div>


</div>


</div>


</td></tr>


</table>


</form>


<div id="dMaps"></div>


<div id="scroller">


	<div style="position: absolute">


		<img class="aObjet" alt="." src="images/items/fauxobjet.png" /><br />&nbsp;<br />


		<img class="aObjet" alt="." src="images/items/banane.png" /><br />&nbsp;<br />


		<img class="aObjet" alt="." src="images/items/carapace.png" /><br />&nbsp;<br />


		<img class="aObjet" alt="." src="images/items/bobomb.png" /><br />&nbsp;<br />


		<img class="aObjet" alt="." src="images/items/carapacerouge.png" /><br />&nbsp;<br />


		<img class="aObjet" alt="." src="images/items/carapacebleue.png" /><br />&nbsp;<br />


		<img class="aObjet" alt="." src="images/items/champi.png" /><br />&nbsp;<br />


		<img class="aObjet" alt="." src="images/items/megachampi.png" /><br />&nbsp;<br />


		<img class="aObjet" alt="." src="images/items/etoile.png" /><br />&nbsp;<br />


		<img class="aObjet" alt="." src="images/items/eclair.png" /><br />&nbsp;<br />


		<img class="aObjet" alt="." src="images/items/billball.png" /><br />&nbsp;<br />


		<img class="aObjet" alt="." src="images/items/champior.png" /><br />


	</div>


</div><p id="presentation">


<strong><a href="index.php">Mario Kart PC</a></strong><br />


Challenge up to 8 players in 6 game modes !<br />


In the <strong>Grand Prix</strong> tournaments, win 5 cups of 4 races in order to unlock the 9 secret characters !<br />


With the <strong>Time trial</strong> mode, break the other players' <a href="classement.php" target="_blank">records</a> and become world champion !<br />


In <strong>VS</strong> races, confront CPUs and/or a friend on not less than 20 races !<br />


On <strong>battle mode</strong>, destroy your opponents' balloons in fierce fighting !<br />


With the <strong>track builder</strong>, create as many circuits and courses as you want, with your imagination the only limit !<br />


On <strong><a href="online.php">online mode</a></strong>, compete against players from around the world and climb in the <a href="bestscores.php" target="_blank">rankings</a> !


	</p></body>


</html>

