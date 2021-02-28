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
    daten_sxl=$('#C103jax').text();
    gr_liste();
    //plz_feld();//gps();
    
    oben();
    class_modul();
    setTimeout( function() {
        $('.mdown').animate({'opacity':'0'},3000);
        setTimeout( function() {
            $('.mdown').remove();
        }, 500);
        
    }, 200);
    $('body').css({"background-image":'url(Bilder/bg2.jpg)',}); 
}

function gr_liste() //gli
{
    //var gruppen = daten_sxl ;
    var tr_abstand=45;                
    var Ctable_center_table =document.getElementById('CDiv_generaldiv_center');
    var idbig=1; 
    var Identitaet;
    for (var i2 = 0; i2 < daten_sxl.split("←").length-1; i2++) 
    {//try{
        var id = daten_sxl.split("←")[i2].split("↑")[0].split('~')[1];
        
        var div_alles=zero('div',0,0,0,0,Ctable_center_table);
        $(div_alles).css({
        //'position': 'relative',
        'left': '0',
        'right': '0',
        //'display': 'flex',
        'justify-content': 'space-around',
        'align-items': 'center',
        'flex-wrap': 'wrap',
        'padding-bottom':'40px',
        //'background-color':'green',
        'width':'800px',
        });
        div_alles.className='pizzaria_C_Class_center_table';
        
        var div_ampel=zero('div',0,0,0,0,div_alles);$(div_ampel).buttonsetv();
        var div_pizzaria=zero('div',0,0,0,0,div_alles);$(div_pizzaria).buttonsetv();
        $(div_pizzaria).css({"border-radius":"27px", 'background-color':'#'+div_farbe, 'border-color':'#'+col, 
            "border-width":"4px","border-style":"solid",});//
        
        //var div_zw=zero('div',0,0,0,0,td_center_table_body);
        div_pizzaria.id=id;
        //"border-radius":"20px",})
        $(div_pizzaria).hover(function(){ $(this).css({'cursor': 'pointer','background-color':'#f9f9f9',});}, function () {$(this).css({'background-color':'#'+div_farbe,'cursor': 'default',});});
        $(div_pizzaria).click(function() 
        {
            if( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) 
                window.open('http://www.m.giessengastro.de/mob.aspx?'+this.id, '_blank');
            else{
                window.open('http://www.web.giessengastro.de/web.aspx?'+this.id, '_blank');}
        });
        //lade string
        var pic_link='http://pics.alice-eur.it';
        var gmp32 = daten_sxl.split("←")[i2].split("↑")[0].split("~");
        idbig++;
        Identitaet=idbig;
        var mindestens_ein_kind=0;
        var foto_daten = gmp32[4].split("^")[1];
        var name = gmp32[0];
        var angebot =       daten_sxl.split("←")[i2].split("↑")[1].split("|")[2];
        var auf_oder_zu =   daten_sxl.split("←")[i2].split("↑")[1].split("|")[0];
        var von_bis =       daten_sxl.split("←")[i2].split("↑")[1].split("|")[1];
        var gruppen_liste = daten_sxl.split("←")[i2].split("↑")[1].split("|")[3];
        var sorte = gmp32[5].split("^")[1];
        //name
        var div_name=zero('div',0,0,0,0,div_pizzaria);
        $(div_name).text(sorte+' '+name);div_name.className='C_class_box_titel';
        //$(div_name).css({'font-family': 'Arial','text-align':'center','font-weight':'bold','background-color':'#'+col,'color':'#'+fcol_gelb,});
        //logo
        var div_logo=zero('div',0,0,0,0,div_pizzaria);$(div_logo).buttonsetv();
        td_logo(div_logo,i2,id,pic_link,auf_oder_zu,von_bis,div_ampel);
        var div_gruppen=zero('div',0,0,0,0,div_pizzaria);$(div_gruppen).buttonsetv();
        td_gruppen(div_gruppen,gruppen_liste);
        var div_zeiten=zero('div',0,0,0,0,div_pizzaria);$(div_zeiten).buttonsetv();
        externe_oeffnungzeiten(id,div_zeiten,daten_sxl.split("←")[i2].split("↑")[0]);
        //tr_Angebote(tbody_zero,angebot,1);
        
        //raiting
        var div_bewertung=zero('div',0,0,0,0,div_pizzaria);$(div_bewertung).css({'width':'100%','align':'center','padding-left':'10px'});
        //var tr_down=zero('tr',0,0,0,0,tbody_zero);
        var vote=0;if(i2==0||i2==1||i2==3)vote=8.5;if(i2==2)vote=9.9;if(i2==4)vote=7.5;
        td_raiting(div_bewertung,vote,10,2);
        //fasele
    //}catch(e){var popup = zero('div',0,0,0,0,document.body);$(popup).text(daten_sxl.split("←")[i2].split("↑")[0].split('~')[1]);$(popup).css({'background-color':'red',});};
    }
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
function td_gruppen(element,grups)
{
    $(element).css({'padding-top':'4px','padding-bottom':'10px','padding-left':'10px',"width": "250px","verticalAlign": "top",});
    
    var z_titel2 = zero('fieldset',0,0,0,0,element);$(z_titel2).css({'border-color':'black',"width": "90%",});
    var elemen_legend= zero('legend', 0, 0, 0, 0,z_titel2);$(elemen_legend).css({'color':'black','font-size':'26px','font-weight':'bold',});
    $(elemen_legend).text('Karte');
    for (var i2 = 0; i2 < grups.split("^").length-1; i2++) 
    {
        var div_gruppe = zero('div',0,0,0,0,z_titel2);
        $(div_gruppe).text(grups.split("^")[i2]);
        div_gruppe.className='class_navi';
    }
}

function tr_Angebote(element,angebot,tempo) //gli
{
    if(angebot!='')
    {
        var tr_angebot=zero('tr',0,0,0,0,element);//tr_angebot.width='50%';
        var td_marque = zero('td', 0, 0, 0, 0,tr_angebot);td_marque.colSpan=10;
        var div_marque = zero('div', 0, 0, 0, 0,td_marque);$(div_marque).css({"width":'45%',});
        div_marque.className='class_navi';
        var marquee = zero('marquee', 0,0, 0, 0,div_marque);
        marquee.scrollDelay=tempo;
        $(marquee).text(angebot);
    }
}


function td_logo(element,i2,restaurantId,pic_link,auf_oder_zu,von_bis,elem2)//aks
{
    //var div_geoffnet = zero('div', 0, 0, 0, 0,element);$(div_geoffnet).css({'width':'150px','text-aligh':'center','padding-left':'15px'});
    $(element).css({'padding-top':'4px','padding-bottom':'10px','padding-left':'10px',"width": "190px","verticalAlign": "top",});
    var z_titel2 = zero('fieldset',0,0,0,0,element);$(z_titel2).css({'border-color':'black',"width": "90%",'text-align':'center','align':'center'});
    var elemen_legend= zero('legend', 0, 0, 0, 0,z_titel2);$(elemen_legend).css({'color':'black','font-size':'26px','font-weight':'bold',});
    //$(elemen_legend).text(sp_oeffnungszeiten);
    
    
    //ampel
    if(auf_oder_zu=="auf"){$(elemen_legend).text('Geöffnet');//$(elemen_legend).css({'color':'green',});
        var img_ampel = zero('img','Bilder/greenw.png',40,0,0,elem2);
    }
    else{/*zu*/$(elemen_legend).text('Geschlossen');//$(elemen_legend).css({'color':'red',});
        var img_ampel = zero('img','Bilder/rotw.png',40,0,0,elem2);
    }
    
    
    var divlogo = zero('div', 0, 0, 0, 0,z_titel2);$(divlogo).css({'width':'150px','text-aligh':'center','padding-left':'15px'});
    var myImg2 = zero('img',pic_link+'/album_privat/&'+restaurantId+'.png',140,100,0,divlogo);
    
    var div_rabbat = zero('div', 0, 0, 0, 0,z_titel2);$(div_rabbat).css({'width':'150px','text-aligh':'center','padding-left':'15px','padding-bottom':'15px'});
    var myImg2 = zero('img','Bilder/5prz.png',140,0,0,div_rabbat);
}
//start offnungszeiten
var sp_montag='Mo.';var sp_dienstag='Di.';var sp_mitwoch='Mi.';var sp_donnerstag='Do.';var sp_freitag='Fr.';var sp_samstag='Sa.';var sp_sonntag='So.';var sp_oeffnungszeiten='Öffnungszeiten';
function externe_oeffnungzeiten(id,element,zeit_tabelle)
{
    $(element).css({'padding-top':'4px','padding-bottom':'10px','padding-left':'10px',"width": "190px","verticalAlign": "top",});
    var z_titel2 = zero('fieldset',0,0,0,0,element);$(z_titel2).css({'border-color':'black',"width": "90%",'text-align':'center','align':'center'});
    var elemen_legend= zero('legend', 0, 0, 0, 0,z_titel2);$(elemen_legend).css({'color':'black','font-size':'23px','font-weight':'bold',});
    $(elemen_legend).text(sp_oeffnungszeiten);
    var mon='';var dien='';var mit='';var don='';var frei='';var sam='';var sonn='';var feiert='';
    for (var i = 0; i < zeit_tabelle.split("#").length - 1; i++)
    {
        var heute_tag = zeit_tabelle.split("#")[i].split("|")[0];
        var time='';
        var flextag='';
        if(heute_tag==1)mon  = hilf_kalkulator_for_zeit_lader(mon,zeit_tabelle.split("#")[i]);
        if(heute_tag==2)dien = hilf_kalkulator_for_zeit_lader(dien,zeit_tabelle.split("#")[i]);
        if(heute_tag==3)mit  = hilf_kalkulator_for_zeit_lader(mit,zeit_tabelle.split("#")[i]);
        if(heute_tag==4)don  = hilf_kalkulator_for_zeit_lader(don,zeit_tabelle.split("#")[i]);
        if(heute_tag==5)frei = hilf_kalkulator_for_zeit_lader(frei,zeit_tabelle.split("#")[i]);
        if(heute_tag==6)sam  = hilf_kalkulator_for_zeit_lader(sam,zeit_tabelle.split("#")[i]);
        if(heute_tag==7)sonn = hilf_kalkulator_for_zeit_lader(sonn,zeit_tabelle.split("#")[i]);
        if(heute_tag==9)feiert = hilf_kalkulator_for_zeit_lader(feiert,zeit_tabelle.split("#")[i]);
        
    }
    //geschlossen text
    if(mon=='')mon='Geschlossen';if(dien=='')dien='Geschlossen';if(mit=='')mit='Geschlossen';if(don=='')don='Geschlossen';if(frei=='')frei='Geschlossen';if(sam=='')sam='Geschlossen';if(sonn=='')sonn='Geschlossen';
    //mont
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(sp_montag);
    var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(mon);//$(tr_titel).attr('class','cl_time_div');
    $(tr_titel).css({"width": "60%","border-width":"1px", "border-style":"solid",'border-radius': '7px','padding-left':'15px','padding-right':'15px'});
    $(tr_titel).buttonsetv();
    if(mon=='Geschlossen')$(tr_titel).css({'background-color':'#f97a7a',}); 
    else{$(tr_titel).css({'background-color':'#'+col ,'color':'#'+fcol_gelb,});}; 
    var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    
    //dienstad
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(sp_dienstag);var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(dien);$(tr_titel).css({"width": "60%","border-width":"1px", "border-style":"solid",'border-radius': '7px','padding-left':'15px','padding-right':'15px'});$(tr_titel).buttonsetv();
    if(dien=='Geschlossen')$(tr_titel).css({'background-color':'#f97a7a',}); else{$(tr_titel).css({'background-color':'#'+col ,'color':'#'+fcol_gelb,});}; var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    //mitwoch
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(sp_mitwoch);var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(mit);$(tr_titel).css({"width": "60%","border-width":"1px", "border-style":"solid",'border-radius': '7px','padding-left':'15px','padding-right':'15px'});$(tr_titel).buttonsetv();
    if(mit=='Geschlossen')$(tr_titel).css({'background-color':'#f97a7a',}); else{$(tr_titel).css({'background-color':'#'+col ,'color':'#'+fcol_gelb,});}; var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    //donnerstag
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(sp_donnerstag);var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(don);$(tr_titel).css({"width": "60%","border-width":"1px", "border-style":"solid",'border-radius': '7px','padding-left':'15px','padding-right':'15px'});$(tr_titel).buttonsetv();
    if(don=='Geschlossen')$(tr_titel).css({'background-color':'#f97a7a',}); else{$(tr_titel).css({'background-color':'#'+col ,'color':'#'+fcol_gelb,});}; var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    //freitag
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(sp_freitag);var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(frei);$(tr_titel).css({"width": "60%","border-width":"1px", "border-style":"solid",'border-radius': '7px','padding-left':'15px','padding-right':'15px'});$(tr_titel).buttonsetv();
    if(frei=='Geschlossen')$(tr_titel).css({'background-color':'#f97a7a',}); else{$(tr_titel).css({'background-color':'#'+col ,'color':'#'+fcol_gelb,});}; var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
     //samstag
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(sp_samstag);var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(sam);$(tr_titel).css({"width": "60%","border-width":"1px", "border-style":"solid",'border-radius': '7px','padding-left':'15px','padding-right':'15px'});$(tr_titel).buttonsetv();
    if(sam=='Geschlossen')$(tr_titel).css({'background-color':'#f97a7a',}); else{$(tr_titel).css({'background-color':'#'+col ,'color':'#'+fcol_gelb,});}; var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    //Sonntag
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(sp_sonntag);var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(sonn);$(tr_titel).css({"width": "60%","border-width":"1px", "border-style":"solid",'border-radius': '7px','padding-left':'15px','padding-right':'15px'});$(tr_titel).buttonsetv();
    if(sonn=='Geschlossen')$(tr_titel).css({'background-color':'#f97a7a',}); else{$(tr_titel).css({'background-color':'#'+col ,'color':'#'+fcol_gelb,});}; var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    //feiertage
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text('Fei.');var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    var tr_titel=zero('div',0,0,0,0,z_titel2);$(tr_titel).text(feiert);$(tr_titel).css({"width": "60%","border-width":"1px", "border-style":"solid",'border-radius': '7px','padding-left':'15px','padding-right':'15px'});$(tr_titel).buttonsetv();
    if(feiert=='Geschlossen')$(tr_titel).css({'background-color':'#f97a7a',}); else{$(tr_titel).css({'background-color':'#'+col ,'color':'#'+fcol_gelb,});}; var tr_titel=zero('div',0,10,0,0,z_titel2);$(tr_titel).buttonsetv();
    var tr_titel=zero('div',0,0,10,0,z_titel2);

}
function hilf_kalkulator_for_zeit_lader(der_tag,daten){var von = daten.split('|')[1];var bis = daten.split('|')[2];if(der_tag=='')/*hanuz khalie*/{der_tag += ' '+von+'-'+bis+' ';}else /*khate dowwomie*/ {var von_in_frei = der_tag.split('-')[0];if(von_in_frei>=von)/*age von tu var dirtare bere dowwom*/der_tag = von+'-'+bis+' '+der_tag;else /* von tu var zoodtare bemoone awwal*/{der_tag += ' '+von+'-'+bis+'  ';}}return der_tag;}

function g (id){try{return document.getElementById(id);}catch(e){alert(id);}}
//ende offnungszeiten

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
    $(div_n206).css({'padding-left':'15px','padding-right':'15px','padding-bottom':'13px','padding-top':'0px','background-color':'#'+col,'color':'#'+fcol_gelb,
    'height':'32px',  'border-radius': '5px','cursor': 'pointer',
    });
    var img_logo = zero('img','Bilder/gastro.jpg',0,40,0,div_n206);
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
    $(div_64_us).text("AGB's");div_64_us.onmousedown=function(){navi_clc("agb_");};
    $('#'+'C_102_agb'+'C_td_head_box').text("AGB's");
    $('#'+'C_102_agb'+'C_textarea_box').text($('#agb_div').text());
    
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

function plz_feld() //gli
{   
    var input_plz = document.getElementById('query');
    $(input_plz).val(35390);
    $(input_plz).css({color:'#041d5f', 'font-size': '155%'});
     $(function() {
        var availableTags = [
        "ActionScript",
        "AppleScript",
        "Asp",
        "BASIC",
        "C",
        "C++",
        "Clojure",
        "COBOL",
        "ColdFusion",
        "Erlang",
        "Fortran",
        "Groovy",
        "Haskell",
        "Java",
        "JavaScript",
        "Lisp",
        "Perl",
        "PHP",
        "Python",
        "Ruby",
        "Scala",
        "Scheme"
        ];
        $(input_plz).autocomplete(availableTags);
    });
    
}
/*
function td_sorte(element,name,angebot){var tdname_anschrift = zero('td', 0, 0, 0, 0,element);var table3=zero('table',0,0,0,0,tdname_anschrift);var body3=zero('tbody',0,0,0,0,table3);var tr3=zero('tr',0,0,0,0,body3);var tdname = zero('td', 0, 0, 0, 0,tr3);$(tdname).text(name);tdname.className='innen';}
*/
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
'Telefon: 0641 640 49 22 \n E-Mail: info@giessengastro.de \n Internetadresse: www.GiessenGastro.de';

var Impressum_text =
    'Angaben gemäß § 5 TMG \n'+'Geschäftsführer: M.R.Agha Milani \n'+'Liebigstrasse. 23\n'+'35390 Giessen'+
    '\n 0641 460 49 22 \n GiessenGastro UG (haftungsbeschränkt) \n ';
   
 

