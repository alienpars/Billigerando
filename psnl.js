// JScript File

function psnl_start()//page load 
{
    var icon_universal = k_m_f('101','Gutscheine eintragen',document.body,'',10,'on','');
    icon_universal.onclick = function(){
        gutschein_insert();
    }
    var icon_universal = k_m_f('101','Gutscheine check',document.body,'',10,'on','');
    icon_universal.onclick = function(){
        gutschein_view();
    }
    var icon_universal = k_m_f('101','Bestellungen',document.body,'',10,'on','');
    icon_universal.onclick = function(){
        bestellungen_view();
    }
};

function bestellungen_view()
{
    var div_fenster = fct_fenster('Gutschein Info');
    var div_117= zero('div', 0, 0, 0, 0,div_fenster);
    var table_uni=zero('table',0,0,0,1,div_117);var body66=zero('tbody',0,0,0,0,table_uni);
    var tr73=zero('tr',0,0,0,0,body66);
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text('Lieferdienst');
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text('Gesamt Anzahl');
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text('Summe');
    tr_lieferdienste(body66,'0,50 €','#gutscheine_50','#aktiv_gutscheine_50');
};

function gutschein_view()
{
    var div_fenster = fct_fenster('Gutschein Info');
    var div_117= zero('div', 0, 0, 0, 0,div_fenster);
    var table_uni=zero('table',0,0,0,1,div_117);var body66=zero('tbody',0,0,0,0,table_uni);
    var tr73=zero('tr',0,0,0,0,body66);
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text('Gutschein Wert');
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text('Gesamt Anzahl');
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text('Aktive');
    
   
    tr_gutscheine(body66,'0,50 €','#gutscheine_50','#aktiv_gutscheine_50');
    tr_gutscheine(body66,'100 €','#gutscheine_100','#aktiv_gutscheine_100');
    tr_gutscheine(body66,'150 €','#gutscheine_150','#aktiv_gutscheine_150');
    tr_gutscheine(body66,'200 €','#gutscheine_200','#aktiv_gutscheine_200');
    tr_gutscheine(body66,'250 €','#gutscheine_250','#aktiv_gutscheine_250');
    tr_gutscheine(body66,'300 €','#gutscheine_300','#aktiv_gutscheine_300');
    
    
};

function tr_gutscheine(body66,val_1,val_2,val_3)
{//leider Kompliziert
    var tr73=zero('tr',0,0,0,0,body66);
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text(val_1);
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text($(val_2).text());
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text($(val_3).text());
};
function tr_lieferdienste(body66,val_1,val_2,val_3)
{//leider Kompliziert
    var tr73=zero('tr',0,0,0,0,body66);
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text(val_1);
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text($(val_2).text());
    var td78=zero('td',0,0,0,0,tr73);
    $(td78).text($(val_3).text());
};

function gutschein_insert()
{
    var div_fenster = fct_fenster('gse');
    var div_117= zero('div', 0, 0, 0, 0,div_fenster);
    $(div_117).css({ 'height' :'90%', });
    var name_textarea = zero('textarea', 0, 0, 0, 0, div_117);name_textarea.id='my_Gutschein_textarea';
    $(name_textarea).css({'height':'90%','width':'95%','position':'relative',});$(name_textarea).val();

    var speichern_icon = k_m_f('y83imk','Speichern',div_fenster,'',10,'on','');
    speichern_icon.onclick = function()
    {
        alert(psnl.insert_gutscheine($('#my_Gutschein_textarea').val()).value +' wurden eingetragen');
    };
}




















function k_m_f(button_id,txt, vater,color,radius,on_off,icon)
{
    var adresse_send_icon_k = document.createElement('A');
    $(adresse_send_icon_k).html(txt);
    $(adresse_send_icon_k).button({
            //text: txt,
            icons: {
                primary: "ui-icon-"+icon   // Custom icon
            }
        });
    //adresse_send_icon_k.type='button';
    adresse_send_icon_k.id =button_id;
    //if (txt != 0)adresse_send_icon_k.value = txt;
    //$(adresse_send_icon_k).css({'background-color':'#'+titel5,'border-radius': radius+'px','font-weight':'Bold','font-size': fo_si+'px','border-color' : '#'+titel2,'text-align':'center','padding-left':'7px','padding-right':'7px','padding-top':'5px','padding-bottom':'5px','align':'center','color':'#'+ titel2,"border-width":"4px",});
    if (vater != 0) vater.appendChild(adresse_send_icon_k);
    if(on_off=='on')adresse_send_icon_k.style.visibility='visible';
    if(on_off=='off')adresse_send_icon_k.style.visibility='hidden';
    return adresse_send_icon_k;
}
function zero(element, src, width, height, border, vater)
{
    var d = document.createElement(element);
    d.border = border;
    if (src != 0)d.src = src;
    if (width != 0)d.style.width = width + 'px';//height
    if (height != 0) d.style.height = height + 'px';//+'px';//
        if (vater != 0) vater.appendChild(d);
    return d;
};
function close_me_knopf(element)//kok
{
        $(element).css({"position": "relativ"});
        var d = zero('div',0,0,0,0,element);
        $(d).css({"position": "absolute"});
        $(d).css({'right' : '45px' , 'top' : '5px'});
        var zutztpic = zero('img','Bilder/delete.png', 40, 40, 0, d);
        $(zutztpic).css({"position": "fixed"});
        
        zutztpic.onmousedown=function()
        {
            $(element).remove();
            
        }    
}
function fct_fenster(id_text)
{
    $('#Div_universal').remove();
    var Div_wochen_93_optionen= zero('div', 0, 0, 0, 0,document.body);
    $(Div_wochen_93_optionen).css({'top' : '50px','position':'fixed','z-index':'50','background-color':'#16ffe6','width' :'95%' ,
         'height' :'83%', 'left' :'3%',"border":"3px solid black",'border-color': '#CCC','overflow':'auto','padding':'10px'});
    Div_wochen_93_optionen.id='Div_universal';
    $(Div_wochen_93_optionen).text(id_text);
    close_me_knopf(Div_wochen_93_optionen);
    return Div_wochen_93_optionen;
};