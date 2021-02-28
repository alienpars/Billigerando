// JScript File
var daten_sxl='';var gruppen_breite=0;var hoehe=0;var seiten_top=0;
    var col='58682a';//'b8935f';//'d8ac6f';//'75b200';//'c2c72c';//'ffc215';
    var fcol='000000';//'d52b1e';
    var fcol_gelb = 'ffbc20';//'ffbc20';
    var div_farbe='e2dece';
function xystart()
{
    hoehe=(screen.width * 0.25);
    gruppen_breite=(screen.width* 0.55);
    window.document.title='GießenGastro';
    var my_client_count = $('#Cm52_anzahl').text();
    for (var i2 = 0; i2 < my_client_count; i2++) {

        var Z_Y_return = $('#C791_mob_div_timer_info_hide' + i2).text();
        if (Z_Y_return != "") {

            //string Z_Y_return = ny_cls.ccl_karte.Z_YAB(hauptId, mp3_von_haupt);
            var tagesangebot_des_restaurants = "";//133
            var time_bescreibung = "";
            var op_1_off_0 = 0;
            var restzeit = "";
            //lade tafel string
            time_bescreibung = Z_Y_return.split('╚')[0];
            // tagesangebot_des_restaurants = Z_Y_return.split('╚')[1];
            //op_1_off_0 = Z_Y_return.split('╚')[2];
            var resttage = Z_Y_return.split('╚')[4];

            restzeit = Z_Y_return.split('╚')[3];
            //string offnung_zeiten_str = time_bescreibung + "╚" + tagesangebot_des_restaurants + "╚" + op_1_off_0.ToString() + "╚" + restzeit + "╚" + Z_Y_return.Split('╚')[5] + "╚" + Z_Y_return.Split('╚')[4];


            fctoin_timer(resttage, time_bescreibung, restzeit, i2);
        }
    }
    freshman();
}
function fctoin_timer(resttage, time_bescreibung, restzeit, i2) {

    var monat_idh7i = restzeit.split(',')[1]; monat_idh7i = monat_idh7i - 1;
    var target_date = new Date(restzeit.split(',')[0], monat_idh7i, restzeit.split(',')[2], restzeit.split(',')[3], restzeit.split(',')[4], restzeit.split(',')[5]);
    var individuell_tex_mob = "Tagen ";
    if(resttage == 0)
        individuell_tex_mob = ""
    if (resttage == 1) {
        var individuell_tex_mob = "Tag ";
    }
    if (resttage >= 2) {
        var individuell_tex_mob = "Tagen ";
    }
    if (resttage != 99) {
        $('#c884_tag' + i2).text(individuell_tex_mob);
        $('#C791_mob_div_timer_tafel' + i2).text(time_bescreibung);
        $("div#C792_mob_div_timer" + i2).countdown(target_date.valueOf(), function (event) {
            $this = $(this);
            switch (event.type) {
                case "seconds":
                case "minutes":
                case "hours":
                case "days":
                case "weeks":
                case "daysLeft":
                    $this.find('span#' + event.type).html(event.value);
                    break;
                case "finished":
                    location.reload();
                    break;
            }
        });
    }
    else//muster
    {
        $('#C791_mob_div_timer_tafel' + i2).text(med + time_bescreibung);
    }
}

function freshman()
{
    $('#toggle').remove();$('#toggle-btn').remove();$('.nav-icon').remove();$('#js_39').remove();$('#js_44').remove();$('#js_48').remove();
    //titel
    $('.C38_titel').text('GiessenGastro.de');
    $('.C38_titel').css({"color":'#f89b30','padding-top':'9px','padding-left':'15px','font-size':'24px','font-family':'sans-serif','font-weight':'bold'}); 
    
    var fm_input = zero('input',0,0,0,0,document.body);fm_input.type = 'checkbox';fm_input.id='toggle';
    var fm_label = zero('label',0,0,0,0,document.body);fm_label.id='toggle-btn';$(fm_label).attr('for','toggle');
    var fm_div = zero('div',0,0,0,0,document.body);$(fm_div).attr('class','nav-icon');fm_div.id='js_39';
    var fm_nav = zero('nav',0,0,0,0,document.body);$(fm_nav).attr('data-state','close');fm_nav.id='js_44';
    var fm_ul = zero('ul',0,0,0,0,fm_nav);fm_ul.id='js_48';
    
    var fm_li = zero('li',0,0,0,0,fm_ul);var fm_a = zero('a',0,0,0,0,fm_li);
    $(fm_a).html('Lieferdienste');
    $(fm_a).attr("href", "#CG-page_home");
    $(fm_a).click(function() {
        freshman();
    })
    
    var fm_li1 = zero('li',0,0,0,0,fm_ul);var fm_a1 = zero('a',0,0,0,0,fm_li1);
    $(fm_a1).html('über uns');
    $(fm_a1).attr("href", "#CG-ueber_uns");
    $(fm_a1).click(function() {freshman();
        $('#C1594_universal_div-ueber_uns').html(DS_readTextFile('ueber_uns.txt'));
    })
    
    var fm_li2 = zero('li',0,0,0,0,fm_ul);var fm_a2 = zero('a',0,0,0,0,fm_li2);
    $(fm_a2).html('Impressum');
    $(fm_a2).attr("href", "#CG-Impressum");
    $(fm_a2).click(function() {freshman();
        $('#C1594_universal_div-Impressum').html(DS_readTextFile('Impressum.txt'));
    })
    
    var fm_li3 = zero('li',0,0,0,0,fm_ul);var fm_a3 = zero('a',0,0,0,0,fm_li3);
    $(fm_a3).html('Kontakt');
    $(fm_a3).attr("href", "#CG-Kontakt");
    $(fm_a3).click(function() {freshman();
        $('#C1594_universal_div-Kontakt').html(DS_readTextFile('Kontakt.txt'));
    })
    
    var fm_li4 = zero('li',0,0,0,0,fm_ul);var fm_a4 = zero('a',0,0,0,0,fm_li4);
    $(fm_a4).html('AGBs');
    $(fm_a4).attr("href", "#CG-AGBs");
    $(fm_a4).click(function() {
        freshman();
        $('#C1594_universal_div-AGBs').html(DS_readTextFile('fsw/txt_agb.txt'));
    })
    
    var fm_li5 = zero('li',0,0,0,0,fm_ul);var fm_a5 = zero('a',0,0,0,0,fm_li5);
    $(fm_a5).html('Haftungsausschluss');
    $(fm_a5).attr("href", "#CG-Haftungsausschluss");
    $(fm_a5).click(function() {freshman();
        $('#C1594_universal_div-Haftungsausschluss').html(DS_readTextFile('Haftungsausschluss.txt'));
    })
}
function DS_readTextFile(file)
{
    var antwort = "";
    var rawFile = new XMLHttpRequest();
    rawFile.open("GET", file, false);
    rawFile.overrideMimeType('text/xml; charset=iso-8859-1');//umlau zeiger
    rawFile.onreadystatechange = function ()
    {
        if(rawFile.readyState === 4)
        {
            if(rawFile.status === 200 || rawFile.status == 0)
            {
                var allText = rawFile.responseText;
                antwort = allText;
            }
        }
    }
    rawFile.send(null);
    return antwort;
}
function td_raiting(element,vote,fahrtgeld,aufgeld)
{
    var tdname_div = element;//zero('div', 0, 0, 0, 0,tdname);
    $(tdname_div).raty({
        scoreName : 'entity.score',
        number    : 10,
        score    : vote,
        size      : 24,
        half      : true,
        readOnly : true,
      starHalf  : 'star-half-big.png',
      starOff   : 'star-off-big.png',
      starOn    : 'star-on-big.png'
    });
}



 function oben()
{
    //schmal oben
    var f254 = zero('div',0,0,0,0,document.body);$(f254).css({'top':'0px','position':'fixed','background-color':'#'+col,'width':'100%', 'height':'7px',  'z-index':'22',});
    var f255 = zero('div',0,0,0,0,document.body);$(f255).css({'top':'0px','position':'fixed','background-color':'#'+fcol_gelb,'width':'100%',
      'z-index':'2','height':'50px','opacity': '0.7'});
    
    var table=zero('table',0,0,0,0,document.body);var body=zero('tbody',0,0,0,0,table);var tr=zero('tr',0,0,0,0,body);body.id='io438ju0';
    $(table).css({'position':'fixed','left':'15px','top':'0px','z-index':'3',});
    var td1=zero('td',0,0,0,0,tr);
    var div_n206 = zero('div',0,0,0,0,td1);
    $(div_n206).css({
    'height':'32px', 
    });
    var img_logo = zero('img','Bilder/gastro.jpg',0,150,0,div_n206);
    $(img_logo).css({'padding-left':'5px','padding-right':'5px','padding-bottom':'5px',
    'padding-top':'0px','background-color':'#'+col,'color':'#'+fcol_gelb,
    'border-radius': '5px','cursor': 'pointer',
    });
    div_n206.onmousedown=function(){navi_clc("pizzaria_");};
    
    //Home
    var td_vuoto = zero('td',0,80,0,0,tr);
    var td_48 = zero('td',0,0,0,0,tr);
    var div_49 = zero('div',0,0,0,0,td_48);div_49.className='sub_menu';
    
    $(div_49).text('Home');
    div_49.onmousedown=function(){navi_clc("pizzaria_");};
    
    //ueber uns
    var td_vuoto = zero('td',0,25,0,0,tr);var td_46_us = zero('td',0,0,0,0,tr);var div_47_us = zero('div',0,0,0,0,td_46_us);div_47_us.className='sub_menu';
    $(div_47_us).text('über uns');div_47_us.onmousedown=function(){navi_clc("us_");};
    $('#'+'C_97_uber_uns'+'C_td_head_box').text('über uns');
    $('#'+'C_97_uber_uns'+'C_textarea_box').text(ueberuns_text);
    
    var td_vuoto = zero('td',0,25,0,0,tr);var td_54 = zero('td',0,0,0,0,tr);var div_54 = zero('div',0,0,0,0,td_54);div_54.className='sub_menu';
    $(div_54).text('Impressum');div_54.onmousedown=function(){navi_clc("impressum_");};
    $('#'+'C_100_impressum'+'C_td_head_box').text('Impressum');
    $('#'+'C_100_impressum'+'C_textarea_box').text(Impressum_text);
    
    var td_vuoto = zero('td',0,25,0,0,tr);
    var td_58 = zero('td',0,0,0,0,tr);
    var div_63 = zero('div',0,0,0,0,td_58);div_63.className='sub_menu';
    $(div_63).text('Kontakt');div_63.onmousedown=function(){navi_clc("Kontakt_");};
    $('#'+'C_101_Kontakt'+'C_td_head_box').text('Kontakt');
    $('#'+'C_101_Kontakt'+'C_textarea_box').text(kontakt_text);
    
    var td_vuoto = zero('td',0,25,0,0,tr);var td_63 = zero('td',0,0,0,0,tr);var div_64_us = zero('div',0,0,0,0,td_63);div_64_us.className='sub_menu';
    $(div_64_us).text("AGB's");
    div_64_us.onmousedown=function()
    {
        navi_clc("agb_");
    };
    $('#'+'C_102_agb'+'C_td_head_box').text("AGB's");
    $('#'+'C_102_agb'+'C_textarea_box').html(DS_readTextFile('fsw/txt_agb.txt'));
    
    var td_vuoto = zero('td',0,25,0,0,tr);
    var td_76 = zero('td',0,0,0,0,tr);
    var div_78 = zero('div',0,0,0,0,td_76);div_78.className='sub_menu';
    $(div_78).text("Haftungsausschluss");div_78.onmousedown=function(){navi_clc("haftung_");};
    $('#'+'C_103_haftung'+'C_td_head_box').text("Haftungsausschluss");
    $('#'+'C_103_haftung'+'C_textarea_box').text(haftungsausschluss_text);
    
    $('.sub_menu').css({
        'font-family': 'Arial',"font-size": "15px",'padding-left':'10px','padding-right':'10px','padding-bottom':'2px','padding-top':'2px',
        'top':'11px','font-weight':'bold','background-color':'#'+col,'color':'#'+fcol_gelb,'border-radius': '5px',"position":"relative",
    });
    $('.sub_menu').hover(function(){ $(this).css({'cursor': 'pointer','background-color':'#'+fcol_gelb,'color':'#'+col,});}, function () {
        $(this).css({'background-color':'#'+col,'cursor': 'default','color':'#'+fcol_gelb,});});        
}
function DS_readTextFile(file)
{
    var antwort = "";
    var rawFile = new XMLHttpRequest();
    rawFile.open("GET", file, false);
    rawFile.overrideMimeType('text/xml; charset=iso-8859-1');//umlau zeiger
    rawFile.onreadystatechange = function ()
    {
        if(rawFile.readyState === 4)
        {
            if(rawFile.status === 200 || rawFile.status == 0)
            {
                var allText = rawFile.responseText;
                antwort = allText;
            }
        }
    }
    rawFile.send(null);
    return antwort;
}
var agi='pizzaria_';
function navi_clc(ngi)//anti dual calabr
{if(agi!=ngi){
    $(window).scrollTop(0);
    $('.'+ngi+'C_Class_center_table').css({"display": "block ",});
    $('.'+ngi+'C_Class_center_table').animate({'opacity': '1'}, 500);
    //$('.'+ngi+'C_Class_center_table').buttonsetv();
    
    $('.'+agi+'C_Class_center_table').css({"display": "none ",});
    $('.'+agi+'C_Class_center_table').css({"opacity": "0 ",});
    agi=ngi;
}}
function class_modul()//shekl
{
   
    $('.class_navi').css({
        'padding-bottom':'0px','padding-top':'0px','margin-bottom':'1px','margin-right':'5px','cursor': 'pointer','text-align': 'left',"font-size": "12px",
        'color':'#'+fcol,'font-family': 'Arial','padding-left':'15px','padding-right':'15px','cellspacing':'0px','font-weight': 'bold',
    });
    $('#CDiv_generaldiv_center').css({
        "position":"relative","top": "55px",'margin': ' auto',
        "width":'55%',
        //"width":weite_in_pzt+'%',
    })
    
    $('#Ctable_center_table').css({
        "width":'100%',
    })
    $('.C_class_box_titel').css({
            'font-family': 'arial',
            'color':'#'+ fcol_gelb,
            "font-size": 25+ "px",
            "background-color":'#'+col,
            'text-align':'center',
            //'padding-left':'11px', 'padding-right':'11px',
            'padding-top':'5px', 'padding-bottom':'5px',
            'border-top-right-radius': '10px', 'border-top-left-radius': '10px', 'font-weight': 'bold',
            'border-color':'#'+col, "border-width":"4px", "border-style":"solid",
    });
    $('.C_class_box_beschreibung').css({
            'font-family': 'arial',
            'color':'#'+ col,
            "font-size": 15+ "px",
            "background-color":'#'+div_farbe,
            'text-align':'center',
            'padding-left':'0px', 'padding-right':'0px', 'padding-top':'10px', 'padding-bottom':'10px',
            'border-bottom-right-radius': '10px', 'border-bottom-left-radius': '10px', 'font-weight': 'bold',
            //'width':'99%', 
            'height':'99%',//'width':foto_verhaeltnis+'px',
            'border-color':'#'+col, "border-width":"4px", "border-style":"solid", 'white-space': 'pre',
    });//C_class_box_beschreibung
   //$('#'+'C_102_agb'+'C_textarea_box').css({'text-align':'left','height':'90%','overflow': 'auto',});
     //$('#'+'C_102_agb'+'C_textarea_box').css({'width':'280px',});
    
}
//function gps(){if (navigator.geolocation) {navigator.geolocation.getCurrentPosition(success, error);} else {alert("GeoLocation API ist NICHT verfügbar!");}}
//function success(position) {lat = position.coords.latitude;long = position.coords.longitude;}
//function error(msg) {console.log(typeof msg == 'string' ? msg : "error");}


function zero(element, src, width, height, border, vater){var d = document.createElement(element);d.border = border;if (src != 0)d.src = src;if (width != 0)d.style.width = width + 'px';if (height != 0) d.style.height = height + 'px';if (vater != 0) vater.appendChild(d);return d;};
var haftungsausschluss_text='Haftungsausschluss1. \n '+
'Inhalt des OnlineangebotesDer Autor übernimmt \n '+
'keinerlei Gewähr für die Aktualität,\n '+
' Richtigkeit und Vollständigkeit der bereitgestellten \n '+
'Informationen auf unserer \n '+
'Website/Online-Shop. Haftungsansprüche gegen \n '+
'den Autor, welche sich auf Schäden \n '+
'materieller oder ideeller Art beziehen, die \n '+
'durch die Nutzung oder Nichtnutzung der \n '+
'dargebotenen Informationen bzw. durch die \n '+
'Nutzung fehlerhafter und unvollständiger \n '+
'Informationen verursacht wurden, sind grundsätzlich\n '+
' ausgeschlossen, sofern seitens des \n '+
'Autors kein nachweislich vorsätzliches oder \n '+
'grob fahrlässiges Verschulden vorliegt.\n '+
'Alle Angebote sind freibleibend und unverbindlich. \n '+
'Der Autor behält es sich ausdrücklich \n '+
'vor, Teile der Seiten oder das gesamte Angebot \n '+
'ohne gesonderte Ankündigung zu verändern, \n '+
'zu ergänzen, zu löschen oder die Veröffentlichung\n '+
' zeitweise oder endgültig einzustellen.\n\n\n\n '+
'2. Verweise und Links \n '+
'Bei direkten oder indirekten Verweisen auf fremde \n '+
'Webseiten (“Hyperlinks”), die außerhalb \n '+
'des Verantwortungsbereiches des Autors liegen,\n '+
' würde eine Haftungsverpflichtung ausschließlich \n '+
'in dem Fall in Kraft treten, in dem der Autor \n '+
'von den Inhalten Kenntnis hat und es \n '+
'ihm technisch möglich und zumutbar wäre, \n '+
'die Nutzung im Falle rechtswidriger Inhalte zu \n '+
'verhindern.Der Autor erklärt hiermit ausdrücklich,\n '+
' dass zum Zeitpunkt der Linksetzung keine \n '+
'illegalen Inhalte auf den zu verlinkenden Seiten\n '+
' erkennbar waren. Auf die aktuelle und zukünftige \n '+
'Gestaltung, die Inhalte oder die Urheberschaft der\n '+
' verlinkten/verknüpften Seiten hat der Autor\n '+
' keinerlei Einfluss. Deshalb distanziert er sich\n '+
' hiermit ausdrücklich von allen Inhalten aller \n '+
'verlinkten /verknüpften Seiten, die nach der\n '+
' Linksetzung verändert wurden. Diese Feststellung \n '+
'gilt für alle innerhalb des eigenen Internetangebotes \n '+
'gesetzten Links und Verweise sowie für \n '+
'Fremdeinträge in vom Autor eingerichteten Gästebüchern,\n '+
' Diskussionsforen, Linkverzeichnissen,\n '+
' Mailinglisten und in allen anderen Formen von\n '+
' Datenbanken, auf deren Inhalt externe \n '+
'Schreibzugriffe möglich sind. Für illegale,\n '+
' fehlerhafte oder unvollständige Inhalte und \n '+
'insbesondere für Schäden, die aus der Nutzung\n '+
' oder Nichtnutzung solcherart dargebotener \n '+
'Informationen entstehen, haftet allein der \n '+
'Anbieter der Seite, auf welche verwiesenwurde,\n '+
' nicht derjenige, der über Links auf die \n '+
'jeweilige Veröffentlichung lediglich verweist.\n\n\n\n '+
'3. Urheber-und Kennzeichenrecht\n'+
'Der Autor ist bestrebt, in allen Publikationen\n '+
' die Urheberrechte der verwendeten Bilder, \n '+
'Grafiken, Tondokumente, Videosequenzen und \n '+
'Texte zu beachten, von ihm selbst erstellte Bilder, \n '+
'Grafiken, Tondokumente, Videosequenzen und \n '+
'Texte zu nutzen oder auf lizenzfreie Grafiken, \n '+
'Tondokumente, Videosequenzen und Texte zurückzugreifen.\n '+
'Alle innerhalb des Internetangebotes \n '+
'genannten und ggf. durch Dritte geschützten \n '+
'Marken-und Warenzeichen unterliegen uneingeschränkt \n '+
'den Bestimmungen des jeweils gültigen Kennzeichenrechts\n '+
' und den Besitzrechten der jeweiligen \n '+
'eingetragenen Eigentümer. Allein aufgrund der \n '+
'bloßen Nennung ist nicht der Schluss zu ziehen, \n '+
'dass Markenzeichen nicht durch Rechte Dritter\n '+
' geschützt sind!Das Copyright für veröffentlichte, \n '+
'vom Autor selbst erstellte Objekte bleibt allein \n '+
'beim Autor der Seiten. Eine Vervielfältigung oder \n '+
'Verwendung solcher Grafiken, Tondokumente,\n '+
' Videosequenzen und Texte in anderen elektronischen oder \n '+
'gedruckten Publikationen ist ohne ausdrückliche \n '+
'Zustimmung des Autors nicht gestattet.\n\n\n\n '+
'4. Datenschutz\n'+
'Sofern innerhalb des Internetangebotes die \n '+
'Möglichkeit zur Eingabe persönlicher oder\n '+
' geschäftlicher\n '+
' Daten (Emailadressen, Namen, Anschriften) besteht,\n '+
' so erfolgt die Preisgabe dieser Daten seitens \n '+
'des Nutzers auf ausdrücklich freiwilliger Basis.\n '+
' Die Inanspruchnahme und Bezahlung aller angebotenen \n '+
'Dienste ist –soweit technisch möglich und zumutbar \n '+
'–auch ohne Angabe solcher Daten bzw. unter Angabe\n '+
' anonymisierter Daten oder eines Pseudonyms gestattet.\n '+
' Die Nutzung der im Rahmen des Impressums oder \n '+
'vergleichbarer Angaben veröffentlichten Kontaktdaten \n '+
'wie Postanschriften, Telefon-und Faxnummern \n '+
'sowie Emailadressen durch Dritte zur Übersendung von\n '+
' nicht ausdrücklich angeforderten Informationen \n '+
'ist nicht gestattet. Rechtliche Schritte gegen die\n '+
' Versender von sogenannten Spam-Mails bei \n '+
'Verstössen gegen dieses Verbot sind ausdrücklich \n '+
'vorbehalten.\n\n\n\n '+
'5. Google AdsenseDiese \n '+
'Website/Online-Shopbenutzt Google Adsense, einen\n '+
' Webanzeigendienst der Google Inc., USA (“Google”).\n '+
' Google Adsense verwendet sog. “Cookies” (Textdateien),\n '+
' die auf Ihrem Computer gespeichert werden \n '+
'und die eine Analyse der Benutzung der \n '+
'Website/Online-Shopdurch Sie ermöglicht. Google Adsense \n '+
'verwendet auch sog. “Web Beacons” (kleine unsichtbare Grafiken)\n '+
' zur Sammlung von Informationen.\n '+
' Durch die Verwendung des Web Beacons können \n '+
'einfache Aktionen wie der Besucherverkehr auf der \n '+
'Webseite aufgezeichnet und gesammelt werden.\n '+
' Die durch den Cookie und/oder Web Beacon erzeugten \n '+
'Informationen über Ihre Benutzung diese\n '+
' Website/Online-Shop(einschließlich Ihrer IP-Adresse) \n '+
'werden an einen Server von Google in den USA\n '+
' übertragen und dort gespeichert. Google wirddiese \n '+
'Informationen benutzen, um Ihre Nutzung der\n '+
' Website/Online-Shopim Hinblick auf die Anzeigen \n '+
'auszuwerten, um Reports über die \n '+
'Website/Online-Shopaktivitäten und Anzeigen für die \n '+
'Website/Online-Shopbetreiber zusammenzustellen \n '+
'und um weitere mit der Website/Online-Shopnutzung \n '+
'und der Internetnutzung verbundene Dienstleistungen \n '+
'zu erbringen. Auch wird Google diese \n '+
'Informationen gegebenenfalls an Dritte übertragen,\n '+
' sofern dies gesetzlich vorgeschrieben oder \n '+
'soweit Dritte diese Daten im Auftrag von \n '+
'Googleverarbeiten. Google wird in keinem Fall Ihre \n '+
'IP-Adresse mit anderen Daten der Google in \n '+
'Verbindung bringen. Das Speichern von Cookies auf \n '+
'Ihrer Festplatte und die Anzeige von Web Beacons\n '+
' können Sie verhindern, indem Sie in Ihren \n '+
'Browser-Einstellungen “keine Cookies akzeptieren”\n '+
' wählen (Im MS Internet-Explorer unter “Extras >\n '+
' Internetoptionen > Datenschutz > Einstellung”; \n '+
'im Firefox unter “Extras > Einstellungen > \n '+
'Datenschutz > Cookies”); wir weisen Sie jedoch \n '+
'darauf hin, dass Sie in diesem Fall \n '+
'gegebenenfalls nicht sämtliche Funktionen dieser \n '+
'Website/Online-Shopvoll umfänglich nutzen können.\n '+
' Durch die Nutzung dieser Website/Online-Shoperklären \n '+
'Sie sich mit der Bearbeitung der über Sie \n '+
'erhobenen Daten durch Google in der zuvor \n '+
'beschriebenen Art und Weise und zu dem zuvor \n '+
'benannten Zweck einverstanden.\n\n\n\n '+
'6. Google Analytics\n '+
'Diese Website/Online-Shopbenutzt Google Analytics,\n '+
' einen Webanalysedienst der Google Inc.\n '+
' (“Google”). Google Analytics verwendet sog. “Cookies”,\n '+
' Textdateien, die auf Ihrem Computer \n '+
'gespeichert werden und die eine Analyse der Benutzung\n '+
' der Website/Online-Shopdurch Sie ermöglicht. \n '+
'Die durch den Cookie erzeugten Informationen über\n '+
' Ihre Benutzung diese Website/Online-Shop\n '+
'(einschließlich Ihrer IP-Adresse) wird an einen Server von Google in \n '+
'denUSA übertragen und dort\n '+
' gespeichert. Google wird diese Informationen benutzen, um Ihre Nutzung \n '+
'der Website/Online-Shopauszuwerten,\n '+
' um Reports über die Website/Online-Shopaktivitäten für die \n '+
'Website/Online-Shopbetreiber \n '+
'zusammenzustellen und um weitere mit der Website/Online-Shopnutzung und \n '+
'der Internetnutzung verbundene\n '+
' Dienstleistungen zu erbringen. Auch wird Google diese Informationen \n '+
'gegebenenfalls an Dritte übertragen,\n '+
' sofern dies gesetzlich vorgeschrieben oder soweit Dritte diese Daten \n '+
'im Auftrag vonGoogle verarbeiten. \n '+
'Google wird in keinem Fall Ihre IP-Adresse mit anderen Daten \n '+
'der Google in Verbindung bringen. Sie können \n '+
'die Installation der Cookies durch eine entsprechende\n '+
' Einstellung Ihrer Browser Software \n '+
'verhindern; wir weisen Sie jedoch daraufhin, dass Sie \n '+
'in diesem Fall gegebenenfalls nicht sämtliche \n '+
'Funktionen dieser Website/Online-Shopvoll umfänglich \n '+
'nutzen können. Durch die Nutzung dieser \n '+
'Website/Online-Shoperklären Sie sich mit der Bearbeitung \n '+
'der über Sie erhobenen Daten durch Google \n '+
'in der zuvor beschriebenen Art und Weise und zu \n '+
'dem zuvor benannten Zweck einverstanden.\n\n\n\n '+
' 7. Facebook\n '+
'Diese Webseite nutzt Plugins des Anbieters Facebook.com,\n '+
' welche durch das Unternehmen \n '+
'Facebook Inc., 1601 S. California Avenue, Palo Alto,\n '+
' CA 94304 in den USA bereitgestellt werden.\n '+
' Nutzer unserer Webseite, auf der das Facebook-Plugin\n '+
' installiert ist, werden hiermit darauf \n '+
'hingewiesen, dass durch das Plugin eine Verbindung zu\n '+
' Facebook aufgebaut wird, wodurch eine \n '+
'Übermittlung an Ihren Browser durchgeführt wird, \n '+
'damit das Plugin auf der Webseite erscheint.\n '+
'Des Weiteren werden durch die Nutzung Daten an die\n '+
' Facebook-Server weitergeleitet,\n '+
' welche Informationen über Ihre Webseitenbesuche \n '+
'auf unserer Homepage enthalten. \n '+
'Dies hat für eingeloggte Facebook-Nutzer zur Folge,\n '+
' dass die Nutzungsdaten ihrem persönlichen \n '+
'Facebook-Account zugeordnet werden.Sobald Sie als\n '+
' eingeloggter Facebook-Nutzer aktiv das \n '+
'Facebook-Plugin nutzen (z.B. durch das Klicken auf den\n '+
' „Gefällt mir“ Knopf oder die Nutzung \n '+
'der Kommentarfunktion), werden diese Daten zu Ihrem\n '+
' Facebook-Account übertragen und veröffentlicht.\n '+
' Dies können Sie nur durch vorheriges Ausloggen aus\n '+
' Ihrem Facebook-Account umgehen.Weitere \n '+
'Information bezüglich der Datennutzung durch \n '+
'Facebook entnehmen Sie bitte den \n '+
'datenschutzrechtlichen Bestimmungen auf Facebook.\n\n\n\n '+
'8. Rechtswirksamkeit dieses Haftungsausschlusses\n '+
'Dieser Haftungsausschluss ist als Teil des \n '+
'Internetangebotes zu betrachten, von \n '+
'dem ausauf diese Seite verwiesen wurde. Sofern\n '+
' Teile oder einzelne Formulierungen dieses \n '+
'Textes der geltenden Rechtslage nicht, nicht mehr\n '+
' oder nicht vollständig entsprechen sollten,\n '+
' bleiben die übrigen Teile des Dokumentes in ihrem\n '+
' Inhalt und ihrer Gültigkeit davon unberührt. ';

var ueberuns_text =
'giessenGastro.de ist die Bestell-Plattform im Giessen,\n '+
' die das Essen bestellen vom Lieferservice einfach \n '+
'und schnell ermöglicht. Einfach Adresse eingeben und aus\n '+
' der Übersicht einen Bestellservice auswählen \n '+
'und deine Bestellung abschicken. Sobald es dann \n '+
'an der Tür klingelt, kannst du dein Essen vom \n '+
'Lieferdienst genießen.';

var kontakt_text =
'Telefon: +49 176 881 483 81 \n E-Mail: info@giessengastro.de \n Internetadresse: www.GiessenGastro.de';

var Impressum_text =
    'Angaben gemäß § 5 TMG \n'+'Geschäftsführer: M.R.Agha Milani \n'+'Liebigstrasse. 23\n'+'35390 Giessen'+
    '\n +49 176 881 483 81 \n GiessenGastro UG (haftungsbeschränkt) \n ';
   
 

