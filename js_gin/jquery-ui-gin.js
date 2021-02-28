// JScript File
var daten_sxl='';var gruppen_breite=0;var hoehe=0;var seiten_top=0;
    var col='58682a';//'b8935f';//'d8ac6f';//'75b200';//'c2c72c';//'ffc215';
    var fcol='000000';//'d52b1e';
    var fcol_gelb = 'ffbc20';//'ffbc20';linear-gradient(SlateBlue, RoyalBlue)
    var div_farbe='e2dece';
    var psnl=0;
function xystart()
{
    hoehe=(screen.width * 0.25);
    gruppen_breite=(screen.width* 0.55);
    window.document.title='GießenGastro';
    daten_sxl=$('#C103jax').text();
    oben();
    gr_liste();
    //plz_feld();//gps();
    class_modul();
    //Contacs();
    //$('body').css({"background-image":'url(Bilder/bg.jpg)',}); 
    $('#home').css({'cursor': 'pointer',}); 
    $('#home').click(function(){
        //$(this).parent().addClass("active");$(this).parent().siblings().removeClass("active");
        $('html, body').animate({scrollTop: $('#pointer').offset().top+(4*1)}, 1200);
    });
    //conzenr_tools();  
    //var bottom = $(window).height() - top - link.height();
    var bottom = (screen.height*0.72);
    bottom =Math.round(bottom);
    $('html, body').animate({scrollTop: $('#pointer').offset().top-(bottom*1)}, 1200);
    psnl = $('#C263_show_it').text();
    if(psnl==1)psnl_icon(); 
}

function psnl_icon() //gli
{
     var menu_mini_td = zero('div',0,0,0,0,document.body);
   $(menu_mini_td).css({'right':'15px','bottom':'10px',
            'position':'fixed','padding-top':'4px',
           'z-index': '21',});
    //var menu_mini_div = zero('div',0,0,0,0,menu_mini_td);$(menu_mini_div).attr('class','dfgv');
    // a kontakt
    var menu_mini_div = zero('div',0,0,0,0,menu_mini_td);$(menu_mini_div).attr('class','dfgv');
    var okiijh=zero('nobr',0,0,0,0,menu_mini_div);
    $(okiijh).css({'padding-right':'7px','padding-left':'7px',});
    $(okiijh).html('LOGIN');
    $(okiijh).css('cursor', 'pointer');
    var bhy66=0;
    okiijh.onmousedown = function(){
        window.open('psnl.aspx', '_blank');
    }
}

function conzenr_tools() //gli
{
    //facebook
    setTimeout( function() {
        (function(d, s, id) {
          var js, fjs = d.getElementsByTagName(s)[0];
          if (d.getElementById(id)) return;
          js = d.createElement(s); js.id = id;
          js.src = "//connect.facebook.net/de_DE/sdk.js#xfbml=1&version=v2.8";
          fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
        //google_counter
        /*
        setTimeout( function() {
          (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
          (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
          m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
          })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

          ga('create', 'UA-93568301-1', 'auto');
          ga('send', 'pageview');
        },1400);
        */
    },400);
}

function Contacs() //gli
{
    //var div_Contacs = zero('div',0,0,0,0,document.body);
    //$('#js_ji43').remove();
    var div_Contacs = zero('div',0,0,0,0,document.getElementById('C_101_KontaktCC_122'));
    //$(div_Contacs).attr('class','contact');//$(div_Contacs).css({'padding-top':'80px',});
    div_Contacs.id='js_ji43';
    //var h3_cont = zero('h3',0,0,0,0,div_Contacs);$(h3_cont).attr('class','tz-title-2');var span_cont = zero('span',0,0,0,0,h3_cont);$(span_cont).attr('class','tzweight_Bold');$(span_cont).text('Kontakt');
    var div_43w = zero('div',0,0,0,0,div_Contacs);$(div_43w).attr('class','about_desc');
    //var div_logo = zero('img','images/logo.png',0,0,0,div_43w);
    //var p_43w = zero('p',0,0,0,0,div_43w);$(p_43w).attr('class','about_para');$(p_43w).html(DS_readTextFile('Kontakt.txt'));
    //$(p_43w).css('padding-bottom','40px');
    //$(span_cont).css({'color':'#fff',});
    //$(p_43w).css({'color':'#ffa500',});
    
    var div_logo = zero('div',0,0,0,0,div_43w);
    //$(div_Contacs).css({'background-image':'url(Bilder/bg.jpg)',});//
    //$(div_Contacs).css({'background-color':'#c0392b',});//c0392b
    //var img_logo = zero('img','images/logo.png',0,0,0,div_logo);
    
    var div_fb = zero('div',0,0,0,0,div_logo);
    $(div_fb).css({'align':'center','padding-bottom':'35px'});
    var fb_html ='<div class="fb-page" data-href="https://www.facebook.com/giessengastro.de/" data-tabs="timeline" data-height="100" data-small-header="false" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="false"><blockquote cite="https://www.facebook.com/giessengastro.de/" class="fb-xfbml-parse-ignore"><a href="https://www.facebook.com/giessengastro.de/">GiessenGastro</a></blockquote></div>';
    $(div_fb).html(fb_html);
    
    var div_box = zero('div',0,0,0,0,div_Contacs);$(div_box).attr('class','contact_box');
    var div_form = zero('div',0,0,0,0,div_box);$(div_form).attr('class','col-md-6 contact_form');
    var form_form = zero('form',0,0,0,0,div_form);
    var div__in_form = zero('div',0,0,0,0,form_form);$(div__in_form).attr('class','column_2');
    var input_1 = zero('input',0,0,0,0,div__in_form);$(div__in_form).attr({'class':'text',
        'value':'Name',
        'onfocus':'this.value',
    });
    $(input_1).val('Name');
    $(input_1).focus(function () {$(this).css({ 'background': '#dbeca8' }); $(this).select();});
    
    var input_2 = zero('input',0,0,0,0,div__in_form);$(div__in_form).attr({'class':'text',
        'value':'Email',
        'value':'Name',
        'onfocus':'this.value',
        'style':'margin-left:2.7%',
    });
    $(input_2).val('Email');
    $(input_2).focus(function () {$(this).css({ 'background': '#dbeca8' }); $(this).select();});
    
    var div_ds = zero('div',0,0,0,0,form_form);$(div_ds).attr('class','column_3');
    var textarea_tg = zero('textarea',0,0,0,0,div_ds);$(textarea_tg).attr('class','column_3');
    var div_subm = zero('div',0,0,0,0,form_form);$(div_subm).attr('class','form-submit1');
    var labl_subm = zero('label',0,0,0,0,div_subm);$(labl_subm).attr('class','btn btn-primary btn-normal btn-inline');
    var icon_subm = zero('input',0,0,0,0,labl_subm);icon_subm.type='submit';$(icon_subm).val('senden');
    $(icon_subm).click(function() {
            $(textarea_tg).val(Default.send_mail_box($(textarea_tg).val(),$(input_1).val(),$(input_2).val()).value);
    });
    //send_mail_box
    //karte
    var div_map = zero('div',0,0,0,0,div_box);$(div_map).attr('class','col-md-6');
    var div_map_2 = zero('div',0,0,0,0,div_map);$(div_map_2).attr('class','map');
    var iftaam_iinn = 'https://www.google.com/maps/embed?pb=!1m10!1m8!1m3!1d20266.602527595613!2d8.6806432!3d50.5839065!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sde!2sde!4v1489512512203';
    var ifrm=zero('iframe',iftaam_iinn,0,0,0,div_map_2);
   
}
function gr_liste() //gli
{
    var tr_abstand=45;                
    var Ctable_center_table =document.getElementById('CDiv_generaldiv_center');
    var idbig=1; 
    var Identitaet;
    var pic_link='http://album.giessengastro.de';
    var div_container = zero('div',0,0,0,0,document.body);
    $(div_container).attr('class','contact');
    $(div_container).css({'padding-top':'80px'});
    //var div_objekte = zero('div',0,0,0,0,div_container);$(div_objekte).attr('class','announce');
    var h3_cont = zero('h1',0,0,0,0,div_container);$(h3_cont).attr('class','tz-title-4 tzcolor-blue');
    var span_cont = zero('span',0,0,0,0,h3_cont);$(span_cont).attr('class','tzweight_Bold');
    $(span_cont).text('Lieferdienste');
    var p_43w = zero('p',0,0,0,0,h3_cont);$(p_43w).attr('class','tzweight_Bold');$(p_43w).html('einfach einen Lieferdienst wählen und bestellen');
        
    $(span_cont).css({'color':'#ffa500',});
    $(p_43w).css({'color':'#ffa500',});
    var div_grupe = zero('div',0,0,0,0,div_container);$(div_grupe).attr('class','section_group');
    $(div_grupe).css({
        'margin': ' auto',
        "width":'95%',
    })
    
    for (var i2 = 0; i2 < daten_sxl.split("←").length-1; i2++) 
    {
        var id = daten_sxl.split("←")[i2].split("↑")[0].split('~')[1];
        var gmp32 = daten_sxl.split("←")[i2].split("↑")[0].split("~");
        idbig++;
        Identitaet=idbig;
        var name = gmp32[0];
        var foto_daten = gmp32[4].split("^")[1];
        //var auf_oder_zu = daten_sxl.split("←")[i2].split("↑")[1].split("|")[0];
        var auf_oder_zu = daten_sxl.split("←")[i2].split("↑")[1].split('╚')[2];
        var restzeit = daten_sxl.split("←")[i2].split("↑")[1].split('╚')[3];
        var time_bescreibung = daten_sxl.split("←")[i2].split("↑")[1].split('╚')[0];
        var tagesangebot_des_restaurants = daten_sxl.split("←")[i2].split("↑")[1].split('╚')[1];
        var resttage = daten_sxl.split("←")[i2].split("↑")[1].split('╚')[4];
        
        var div_paddin_0 = zero('div',0,0,0,0,div_grupe);$(div_paddin_0).css({'padding': '10px',});$(div_paddin_0).buttonsetv();
        var div_paddin = zero('div',0,0,0,0,div_paddin_0);
        $(div_paddin).css({"border-style":"solid",'border-color':'#f89b30','border-width':'1px'});
        $(div_paddin).buttonsetv();
        var div_ampel=zero('div',0,0,0,0,div_paddin);$(div_ampel).buttonsetv();
        
        var div_1_5 = zero('div',0,0,0,0,div_paddin);$(div_1_5).buttonsetv();//$(div_1_5).attr('class','col_1_of_5 span_1_of_5');
        div_1_5.id=id;
        $(div_1_5).click(function() 
        {
            if( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) 
                window.open('http://www.web.giessengastro.de/mob.aspx?'+this.id, '_blank');
            else{
                window.open('http://www.web.giessengastro.de/web.aspx?'+this.id, '_blank');}
        });
        //$(div_1_5).css({"border":"1px solid black",'background-color':'#f89b30',
            //'border-radius': '3px','height': '155px','padding': '7px',"background-image":'url(Bilder/transparent.png)',
           // });
        $(div_1_5).attr('class','btn btn-primary btn-normal btn-inline');
        var div_col = zero('div',0,0,0,0,div_1_5);//$(div_col).attr('class','col_1');
        var image_t6y = zero('img','fsw/logos/'+id+'.png',0,60,0,div_col);//$(image_t6y).attr('class','img-responsive');
        var div_desc = zero('div',0,0,0,0,div_1_5);//$(div_desc).attr('class','desc');
        var h3_cont = zero('h3',0,0,0,0,div_desc);var span_cont = zero('span',0,0,0,0,h3_cont);
        $(span_cont).attr('class', 'tzweight_Bold'); $(span_cont).text(name);
        var div_counter = zero('div', 0, 0, 0, 0, div_1_5);//$(div_desc).attr('class','desc');
        div_counter.id = "js_238_web_div_timer_tafel" + i2;
        fctoin_timer(resttage, time_bescreibung, restzeit, i2);

        if (auf_oder_zu == "1") {
            var img_ampel = zero('img', 'Bilder/greenw.png', 30, 0, 0, div_ampel);
            $(img_ampel).css({ 'padding': '4px', });
        }
        else {
            var img_ampel = zero('img', 'Bilder/rotw.png', 30, 0, 0, div_ampel);
            $(img_ampel).css({ 'padding': '4px', });
        }
        var sorte = gmp32[5].split("^")[1];
    }
    var div_43w = zero('div',0,0,0,0,div_grupe);$(div_43w).attr('class','about_desc');
    var div_logo = zero('img','images/logo.png',0,0,0,div_43w);
    var div_leer = zero('div',0,0,300,0,div_grupe);//$(div_43w).attr('class','about_desc');
}
function fctoin_timer(resttage, time_bescreibung, restzeit, i2) {
    //dg_string += "¶" + sender + "§fctoin_timer";
    //var target_date = new Date(2017, 12, 25, 23, 0, 0);//Thu Jan 25 2018 23:00:00 GMT+0100
    var monat_idh7i = restzeit.split(',')[1]; monat_idh7i = monat_idh7i - 1;
    var target_date = new Date(restzeit.split(',')[0], monat_idh7i, restzeit.split(',')[2], restzeit.split(',')[3], restzeit.split(',')[4], restzeit.split(',')[5]);
    var individuell_tex = "";
    if (resttage == 0)
        individuell_tex = '%H:%M:%S';
    if (resttage == 1) {
        individuell_tex = '%-n Tag %H:%M:%S';
    }
    if (resttage >= 2) {
        individuell_tex = '%-n Tagen  %H:%M:%S';
    }
    if (resttage != 99) {
        $("#js_238_web_div_timer_tafel" + i2).countdown(target_date, function (event) {
                $(this).text(time_bescreibung + event.strftime(individuell_tex));
            }).on('finish.countdown', function () {
                location.reload();
            });
    }
    else//muster
    {
        $('#js_238_web_div_timer_tafel' + i2).text(med + time_bescreibung);
        //$('#C791_mob_div_timer_tafel').text(med + time_bescreibung);
    }
}

function gr_liste_alt() //gli
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
        $(div_pizzaria).css({"border-radius":"15px", 'background-color':'#'+div_farbe, 'border-color':'#'+col, 
            "border-width":"4px","border-style":"solid",});//
        
        //var div_zw=zero('div',0,0,0,0,td_center_table_body);
        div_pizzaria.id=id;
        $(div_pizzaria).hover(function(){ $(this).css({'cursor': 'pointer','background-color':'#f9f9f9',});}, function () {$(this).css({'background-color':'#'+div_farbe,'cursor': 'default',});});
        $(div_pizzaria).click(function() 
        {
            if( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) 
                window.open('http://www.web.giessengastro.de/mob.aspx?'+this.id, '_blank');
            else{
                window.open('http://www.web.giessengastro.de/web.aspx?'+this.id, '_blank');}
        });
        //lade string
        var pic_link='http://album.giessengastro.de';
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
    var myImg2 = zero('img','fsw/logos/'+restaurantId+'.png',140,100,0,divlogo);
    
    var div_rabbat = zero('div', 0, 0, 0, 0,z_titel2);$(div_rabbat).css({'width':'150px','text-aligh':'center','padding-left':'15px','padding-bottom':'15px'});
    var myImg2 = zero('img','Bilder/5prz.png',140,0,0,div_rabbat);
}

function oben()
{
    $('#aspx_label').css({"font-weight":"Bold",'font-size':'80px','letter-spacing': '0.2em'});
    var div_header = zero('div',0,0,0,0,document.body);$(div_header).attr('class','header-home');
    //var div_header = zero('div',0,0,0,0,document.getElementById('pointer'));$(div_header).attr('class','header-home');

    //var div_container = zero('div',0,0,0,0,div_header);$(div_container).css('height','500px');
    var div_container = zero('div',0,0,0,0,div_header);$(div_container).attr('class','container');
    var div_fixed_header = zero('div',0,0,0,0,div_container);$(div_fixed_header).attr('class','fixed-header');
    var div_h_menu4 = zero('div',0,0,0,0,div_fixed_header);$(div_h_menu4).attr('class','h_menu4');
    var hi9=0;
    var ul_nav = zero('ul',0,0,0,0,div_h_menu4);$(ul_nav).attr('class','nav');
    //var myImg2 = zero('img','images/logo2.png',0,46,0,ul_nav);
        var li_1 = zero('li',0,0,0,0,ul_nav);$(li_1).attr('class','active');var li_1_a = zero('a',0,0,0,0,li_1);$(li_1_a).attr('class','scroll');$(li_1_a).text('Lieferdienste');$(li_1_a).click(function() { navi_clc("pizzaria_"); });
        var li_1 = zero('li',0,0,0,0,ul_nav);$(li_1).attr('class','active');var li_1_a = zero('a',0,0,0,0,li_1);$(li_1_a).attr('class','scroll');$(li_1_a).text('über uns');$(li_1_a).click(function() { $('#'+'C_97_uber_uns'+'C_textarea_box').html(DS_readTextFile('ueber_uns.txt')); navi_clc("us_"); });
        var li_1 = zero('li',0,0,0,0,ul_nav);$(li_1).attr('class','active');var li_1_a = zero('a',0,0,0,0,li_1);$(li_1_a).attr('class','scroll');$(li_1_a).text('Impressum');$(li_1_a).click(function() {     $('#'+'C_100_impressum'+'C_textarea_box').html(DS_readTextFile('Impressum.txt'));    navi_clc("impressum_"); });
        var li_1 = zero('li',0,0,0,0,ul_nav);$(li_1).attr('class','active');var li_1_a = zero('a',0,0,0,0,li_1);$(li_1_a).attr('class','scroll');$(li_1_a).text('Haftungsausschluss');$(li_1_a).click(function() {     $('#'+'C_103_haftung'+'C_textarea_box').html(DS_readTextFile('Haftungsausschluss.txt'));   navi_clc("haftung_"); });
        var li_1 = zero('li',0,0,0,0,ul_nav);$(li_1).attr('class','active');var li_1_a = zero('a',0,0,0,0,li_1);$(li_1_a).attr('class','scroll');$(li_1_a).text('AGB´s');$(li_1_a).click(function() { 
            $('#'+'C_102_agb'+'C_textarea_box').html(DS_readTextFile('fsw/txt_agb.txt')); navi_clc("agb_"); });
        var li_1 = zero('li',0,0,0,0,ul_nav);$(li_1).attr('class','active');var li_1_a = zero('a',0,0,0,0,li_1);$(li_1_a).attr('class','scroll');$(li_1_a).text('Kontakt');$(li_1_a).click(function() { 
            //$('html, body').animate({scrollTop: $('#js_ji43').offset().top+(4*1)}, 500); });
            if(hi9==0){
                Contacs();
                conzenr_tools();
                }
            hi9++;
            navi_clc("Kontakt_"); 
            $('#'+'C_101_Kontakt'+'C_textarea_box').html(DS_readTextFile('Kontakt.txt'));
            });
    //var myImg2 = zero('img','images/logo2.png',0,60,0,ul_nav);
    
    $(".scroll").css('cursor', 'pointer');
    //klicked orange scroll
    $(".nav li a").click(function(){$(this).parent().addClass("active");$(this).parent().siblings().removeClass("active");});
    //oben fixer
    var navoffeset=$(".header-home").offset().top;$(window).scroll(function(){var scrollpos=$(window).scrollTop(); if(scrollpos >=navoffeset){$(".header-home").addClass("fixed");}else{$(".header-home").removeClass("fixed");}});
}
function DS_readTextFile(file)
{
    var antwort = "";
    var rawFile = new XMLHttpRequest();
    rawFile.open("GET", file, false);
    rawFile.overrideMimeType('text/xml; charset=iso-8859-1');
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
{
    $('html, body').animate({scrollTop: $('#pointer').offset().top+(4*1)}, 1000);
    if(agi!=ngi){
        //$(window).scrollTop($('#pointer').top);
        //$('html, body').animate({scrollTop: $('#pointer').top-90}, 1000);
        
        
        $('.'+ngi+'C_Class_center_table').css({"display": "block ",});
        $('.'+ngi+'C_Class_center_table').animate({'opacity': '1'}, 1000);
        
        $('.'+agi+'C_Class_center_table').css({"display": "none ",});
        //$('.'+agi+'C_Class_center_table').css({"opacity": "0 ",});
        $('.'+agi+'C_Class_center_table').animate({'opacity': '0'}, 1000);
        agi=ngi;
    }
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
function class_modul()//shekl
{
   
    $('.class_navi').css({
        'padding-bottom':'0px','padding-top':'0px','margin-bottom':'1px','margin-right':'5px','cursor': 'pointer','text-align': 'left',"font-size": "12px",
        'color':'#'+fcol,'font-family': 'Arial','padding-left':'15px','padding-right':'15px','cellspacing':'0px','font-weight': 'bold',
    });
    $('#CDiv_generaldiv_center').css({
        "position":"relative","top": "85px",'margin': ' auto',
        "width":'55%',
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


/*
function td_sorte(element,name,angebot){var tdname_anschrift = zero('td', 0, 0, 0, 0,element);var table3=zero('table',0,0,0,0,tdname_anschrift);var body3=zero('tbody',0,0,0,0,table3);var tr3=zero('tr',0,0,0,0,body3);var tdname = zero('td', 0, 0, 0, 0,tr3);$(tdname).text(name);tdname.className='innen';}
*/
function zero(element, src, width, height, border, vater){var d = document.createElement(element);d.border = border;if (src != 0)d.src = src;if (width != 0)d.style.width = width + 'px';if (height != 0) d.style.height = height + 'px';if (vater != 0) vater.appendChild(d);return d;};

   
 

