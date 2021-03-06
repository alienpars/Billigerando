using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;//stream reader und file.
using System.Net;//network credential

public partial class Default : System.Web.UI.Page
{
    static string wochentag = "";//58-id|name|gn2=Zeitfenster|
    public void Page_Load(object sender, EventArgs e)
    {
        wochentag = DateTime.Now.DayOfWeek.ToString();
        create_elements();
        lade_mp3();
    }

    protected void lade_mp3()
    {
        System.Web.UI.HtmlControls.HtmlGenericControl FORM_HTML = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        FORM_HTML = new System.Web.UI.HtmlControls.HtmlGenericControl("FORM"); form1.Controls.Add(FORM_HTML);

        System.Web.UI.HtmlControls.HtmlGenericControl div_mob_jquery_page = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_mob_jquery_page = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); FORM_HTML.Controls.Add(div_mob_jquery_page);
        div_mob_jquery_page.Attributes.Add("data-role", "page");//zentiert conten div
        div_mob_jquery_page.Attributes.Add("data-theme", "b");
        div_mob_jquery_page.ID = "CG-page_home";
        //menu
        System.Web.UI.HtmlControls.HtmlGenericControl div_navibar = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_navibar = new System.Web.UI.HtmlControls.HtmlGenericControl("div"); div_mob_jquery_page.Controls.Add(div_navibar);
        //div_navibar.ID = "C38_titel";
        div_navibar.Attributes.Add("class", "C38_titel");


        System.Web.UI.HtmlControls.HtmlGenericControl div_login_content = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_login_content = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_mob_jquery_page.Controls.Add(div_login_content);
        div_login_content.Attributes.Add("data-role", "content");
        System.Web.UI.HtmlControls.HtmlGenericControl ul_list_view = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        ul_list_view = new System.Web.UI.HtmlControls.HtmlGenericControl("UL"); div_login_content.Controls.Add(ul_list_view);
        ul_list_view.Attributes.Add("data-role", "listview");
        ul_list_view.Attributes.Add("data-inset", "true");
        ul_list_view.Style.Add("padding-top", "6px");

        //infodiv
        System.Web.UI.HtmlControls.HtmlGenericControl info_div_zeitfenster = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        info_div_zeitfenster = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); form1.Controls.Add(info_div_zeitfenster);
        info_div_zeitfenster.ID = "Cm52_anzahl";
        info_div_zeitfenster.Style.Add("display", "none");
        //WebClient webClient = new WebClient();

        //string my_plz_liste = "46349|46086|46313|46117|46146|46173|46260|46462|";
        //string my_plz_liste = "46349|46086|46313|46117|46146|46173|46260|";
        //string my_plz_liste = "46349|46086|46313|46117|46146|46173|46260|46489|";
        //string my_plz_liste = "46349|46086|46313|46117|46146|46173|46260|46489|46524|";//
        //string my_plz_liste = "46349|46086|46313|46117|46146|46173|46260|46489|46524|46592|";//
        string my_plz_liste = "";
        string path_server_haupt0 = "";
        path_server_haupt0 = Server.MapPath(@"~/ldst.txt");
        string attach_file = path_server_haupt0;
        my_plz_liste = File.ReadAllText(attach_file);
        info_div_zeitfenster.InnerText = my_plz_liste.Split('|').Length.ToString();

        for (int i3 = 0; i3 < my_plz_liste.Split('|').Length; i3++)
        {
            try
            {
                string hauptId = my_plz_liste.Split('|')[i3];
                string path_server_haupt = Server.MapPath(@"~/fsw/ablage/" + hauptId);
                //string path_server_haupt = "http://album.giessengastro.de/ablage/" + hauptId;

                string mp3_von_haupt = File.ReadAllText(path_server_haupt + "/h-" + hauptId + ".txt");
                //string mp3_von_haupt = webClient.DownloadString(path_server_haupt + "/h-" + hauptId + ".txt");

                string plattform = mp3_von_haupt.Split('~')[16].Split('^')[16].Split('|')[0];
                //if (plattform == "giessen3")
                //{
                string Z_Y_return = ny_cls.ccl_karte.Z_YAB(hauptId, mp3_von_haupt);
                string tagesangebot_des_restaurants = "";//133
                string time_bescreibung = "";
                int op_1_off_0 = 0;
                string restzeit = "";
                //lade tafel string
                time_bescreibung = Z_Y_return.Split('╚')[0];
                tagesangebot_des_restaurants = Z_Y_return.Split('╚')[1];
                op_1_off_0 = int.Parse(Z_Y_return.Split('╚')[2]);
                restzeit = Z_Y_return.Split('╚')[3];
                string offnung_zeiten_str = time_bescreibung + "╚" + tagesangebot_des_restaurants + "╚" + op_1_off_0.ToString() + "╚" + restzeit + "╚" + Z_Y_return.Split('╚')[5] + "╚" + Z_Y_return.Split('╚')[4];

                //string offnung_zeiten_str = offnung_zeiten(mp3_von_haupt);
                    //info_div_zeitfenster.InnerHtml += mp3_von_haupt + "↑" + offnung_zeiten_str + "↑←";
                    string pzzaria_daten = mp3_von_haupt;
                    pizzaria_element(ul_list_view, pzzaria_daten, offnung_zeiten_str,i3);
                //}
            }
            catch { int eins = 1; };
        }
        mob_titel_u_body(FORM_HTML, "ueber_uns");
        mob_titel_u_body(FORM_HTML, "Impressum");
        mob_titel_u_body(FORM_HTML, "Kontakt");
        mob_titel_u_body(FORM_HTML, "AGBs");
        mob_titel_u_body(FORM_HTML, "Haftungsausschluss");
    }
    protected void mob_titel_u_body(System.Web.UI.HtmlControls.HtmlGenericControl FORM_HTML, string body_id)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl div_gruppen_page = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_gruppen_page = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); FORM_HTML.Controls.Add(div_gruppen_page);
        div_gruppen_page.Attributes.Add("data-role", "page");//zentiert conten div
        div_gruppen_page.Attributes.Add("data-theme", "b");
        div_gruppen_page.ID = "CG-" + body_id;
        //menu
        System.Web.UI.HtmlControls.HtmlGenericControl div_navibar = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_navibar = new System.Web.UI.HtmlControls.HtmlGenericControl("div"); div_gruppen_page.Controls.Add(div_navibar);
        div_navibar.Attributes.Add("class", "C38_titel");

        System.Web.UI.HtmlControls.HtmlGenericControl div_ewagen_content = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_ewagen_content = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_gruppen_page.Controls.Add(div_ewagen_content);
        div_ewagen_content.Attributes.Add("data-role", "content");

        System.Web.UI.HtmlControls.HtmlGenericControl ul_gesamt_packet = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        ul_gesamt_packet = new System.Web.UI.HtmlControls.HtmlGenericControl("UL"); div_ewagen_content.Controls.Add(ul_gesamt_packet);
        ul_gesamt_packet.Attributes.Add("data-role", "listview");
        ul_gesamt_packet.Attributes.Add("data-inset", "true");
        ul_gesamt_packet.ID = body_id;
        ul_gesamt_packet.Style.Add("padding-top", "6px");

        System.Web.UI.HtmlControls.HtmlGenericControl li_body = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        li_body = new System.Web.UI.HtmlControls.HtmlGenericControl("Li"); ul_gesamt_packet.Controls.Add(li_body);
        System.Web.UI.HtmlControls.HtmlGenericControl div_gesamt_list = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_gesamt_list = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); li_body.Controls.Add(div_gesamt_list);
        div_gesamt_list.ID = "C1594_universal_div-" + body_id;
        //div_gesamt_list.InnerText = "ich bin C1594_agb_text_div";
    }
    protected static void zero_icon(System.Web.UI.HtmlControls.HtmlGenericControl vater, string this_id, string icon, int line, string href)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl A_zero = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        A_zero = new System.Web.UI.HtmlControls.HtmlGenericControl("A"); vater.Controls.Add(A_zero);
        A_zero.Attributes.Add("data-role", "button");
        A_zero.ID = this_id;
        if (icon != "")
            A_zero.Attributes.Add("data-icon", icon);
        if (href != "")
            A_zero.Attributes.Add("href", "#CG-" + href);//zentiert conten div

    }

    protected void pizzaria_element(System.Web.UI.HtmlControls.HtmlGenericControl ul_list_view, string zelle,string offnung_zeiten_str,int i3)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl zwieschen_li = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        zwieschen_li = new System.Web.UI.HtmlControls.HtmlGenericControl("li"); ul_list_view.Controls.Add(zwieschen_li);

        System.Web.UI.HtmlControls.HtmlGenericControl end_a = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        end_a = new System.Web.UI.HtmlControls.HtmlGenericControl("A"); zwieschen_li.Controls.Add(end_a);
        end_a.InnerText = zelle.Split('~')[0];
        end_a.Attributes.Add("href", "http://www.web.giessengastro.de/mob.aspx?" + zelle.Split('~')[1]);
        //ampel
        System.Web.UI.HtmlControls.HtmlGenericControl navi_td_pic2 = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        navi_td_pic2 = new System.Web.UI.HtmlControls.HtmlGenericControl("img"); end_a.Controls.Add(navi_td_pic2);
        navi_td_pic2.Style.Add("Height", "60px");
        navi_td_pic2.Style.Add("padding-top", "15px");
        navi_td_pic2.Style.Add("padding-left", "10px");
        if (offnung_zeiten_str.Split('╚')[2] == "1")
            navi_td_pic2.Attributes.Add("src", "Bilder/greenw.png");
        else {
            navi_td_pic2.Attributes.Add("src", "Bilder/rotw.png");
        }
        System.Web.UI.HtmlControls.HtmlGenericControl navi_td_pic1 = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        navi_td_pic1 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); end_a.Controls.Add(navi_td_pic1);
        navi_td_pic1.Style.Add("Height", "30px");

        System.Web.UI.HtmlControls.HtmlGenericControl navi_td_pic = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        navi_td_pic = new System.Web.UI.HtmlControls.HtmlGenericControl("img"); navi_td_pic1.Controls.Add(navi_td_pic);
        navi_td_pic.Style.Add("Height", "30px");
        //navi_td_pic.Attributes.Add("src", "http://album.giessengastro.de/album_privat/&" + zelle.Split('~')[1] + ".png");
        navi_td_pic.Attributes.Add("src", "fsw/logos/" + zelle.Split('~')[1] + ".png");



        System.Web.UI.HtmlControls.HtmlGenericControl div_timer_tafel = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_timer_tafel = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); zwieschen_li.Controls.Add(div_timer_tafel);
        div_timer_tafel.ID = "C791_mob_div_timer_tafel"+ i3.ToString(); div_timer_tafel.Style.Add("text-align", "center");
        System.Web.UI.HtmlControls.HtmlGenericControl div_timer = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_timer = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); zwieschen_li.Controls.Add(div_timer);
        div_timer.ID = "C792_mob_div_timer" + i3.ToString(); div_timer.Style.Add("text-align", "center");
        C_zero(div_timer, "span", "daysLeft" + i3.ToString(), "", 883);
        C_zero(div_timer, "span", "c884_tag" + i3.ToString(), "", 884);
        C_zero(div_timer, "span", "hours", "", 885);
        C_zero(div_timer, "span", "c886_", ":", 886);
        C_zero(div_timer, "span", "minutes", "", 889);
        C_zero(div_timer, "span", "c_890", ":", 890);
        C_zero(div_timer, "span", "seconds", "", 891);

        System.Web.UI.HtmlControls.HtmlGenericControl div_timer_info_hide = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_timer_info_hide = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); zwieschen_li.Controls.Add(div_timer_info_hide);
        div_timer_info_hide.ID = "C791_mob_div_timer_info_hide" + i3.ToString(); //div_titel_ueber_menu.Style.Add("text-align", "center");
        div_timer_info_hide.Style.Add("display", "none");
        div_timer_info_hide.InnerText = offnung_zeiten_str;

    }
    public static System.Web.UI.HtmlControls.HtmlGenericControl C_zero(System.Web.UI.HtmlControls.HtmlGenericControl vater, string element_type, string this_id, string txt, int line_from)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl span_day = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        span_day = new System.Web.UI.HtmlControls.HtmlGenericControl(element_type); vater.Controls.Add(span_day);
        span_day.ID = this_id;
        span_day.InnerHtml = txt;
        return span_day;
    }
    protected void create_elements()
    {
        string med = ""; string show_it = "0"; try { show_it = Request.Url.Query.Split('?')[2]; }
        catch { show_it = "0";/*zutat*/ };
        //div
        System.Web.UI.HtmlControls.HtmlGenericControl div_rand = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_rand = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");form1.Controls.Add(div_rand);
        div_rand.ID = "CDiv_generaldiv_center";

        


        Table ganze_liste_table = new Table();
        ganze_liste_table.ID = "Ctable_center_table";
        //ganze_liste_table.Attributes.Add("class", "pizzaria_C_Class_center_table");
        div_rand.Controls.Add(ganze_liste_table);
        //ganze_liste_table.Style.Add("width", "90%");
        //uber uns
        menu_box_table(med, show_it, div_rand, "us_", "C_97_uber_uns");
        menu_box_table(med, show_it, div_rand, "impressum_", "C_100_impressum");
        menu_box_table(med, show_it, div_rand, "Kontakt_", "C_101_Kontakt");
        menu_box_table(med, show_it, div_rand, "agb_", "C_102_agb");
        menu_box_table(med, show_it, div_rand, "haftung_", "C_103_haftung");
    }
    protected void menu_box_table(string med, string show_it, HtmlGenericControl div_rand, string class_zusatz, string element_id)
    {
        string withh = "600";
        System.Web.UI.HtmlControls.HtmlGenericControl div_titel_text = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_titel_text = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_rand.Controls.Add(div_titel_text);
        div_titel_text.Attributes.Add("class", class_zusatz + "C_Class_center_table");
        div_titel_text.Style.Add("display", "none");
        div_titel_text.Style.Add("align", "right");


        System.Web.UI.HtmlControls.HtmlGenericControl div_titel = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_titel = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_titel_text.Controls.Add(div_titel);
        div_titel.ID = element_id + "C_td_head_box";
        div_titel.Attributes.Add("class", "C_class_box_titel");
        //div_titel.Style.Add("width", withh + "px");

        System.Web.UI.HtmlControls.HtmlGenericControl div_text = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_text = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_titel_text.Controls.Add(div_text);
        div_text.Attributes.Add("class", "C_class_box_beschreibung");
        div_text.ID = element_id + "C_textarea_box";
        //div_text.Style.Add("width", withh + "px");

        System.Web.UI.HtmlControls.HtmlGenericControl div_abstand= default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_abstand = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_titel_text.Controls.Add(div_abstand);
        div_abstand.Style.Add("height", "250px");

    }
    protected string offnung_zeiten(string hauptM3)
    {//entweder return=1 yanee ist auf oder nexte von-bis
        string von_bis = "";
        string gruppen_liste = "";
        string zustand = "zu";//auf
        string heute = "8";
        if (wochentag == "Friday") heute = "5";
        if (wochentag == "Sunday") heute = "7";
        if (wochentag == "Saturday") heute = "6";
        if (wochentag == "Thursday") heute = "4";
        if (wochentag == "Wednesday") heute = "3";
        if (wochentag == "Tuesday") heute = "2";
        if (wochentag == "Monday") heute = "1";
        string zeit_jetzt = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
        //suche in zeitfenster nach passende zeit
        string zielId = "00";
        int anhangsuche_aktivieren = 0; string angebot = ""; string von_bis_mitternachtanhang = "";
        string alle_zeiten = hauptM3.Split('~')[2];
        for (int i = 0; i < alle_zeiten.Split('#').Length - 1; i++)
        {
            string heute_tag = alle_zeiten.Split('#')[i].Split('|')[0];
            if (int.Parse(heute_tag) == int.Parse(heute))//der Tag wurde gefunden
            {
                string von1 = alle_zeiten.Split('#')[i].Split('|')[1];
                string bis1 = alle_zeiten.Split('#')[i].Split('|')[2];
                if (DateTime.Parse(zeit_jetzt) <= DateTime.Parse(bis1) && DateTime.Parse(zeit_jetzt) >= DateTime.Parse(von1))
                {
                    zielId = alle_zeiten.Split('#')[i].Split('|')[3];
                    zustand = "auf";
                    von_bis = "bis: " + bis1;
                    angebot = alle_zeiten.Split('#')[i].Split('|')[4];
                    int ali = alle_zeiten.Split('#')[i].Split('|').Length;
                    if (alle_zeiten.Split('#')[i].Split('|').Length == 7)
                        gruppen_liste = alle_zeiten.Split('#')[i].Split('|')[5];
                    if (bis1 == "23:59")
                    {
                        anhangsuche_aktivieren = 1;
                    }
                }
            }
        }
        if (anhangsuche_aktivieren == 1)
        {
            for (int i = 0; i < alle_zeiten.Split('#').Length - 1; i++)
            {
                string heute_tag = alle_zeiten.Split('#')[i].Split('|')[0];
                //wird ein tag abgezogen damit zeiten,die nach mitternacht kommen, noch gesehen werden
                int heute_tag_int = int.Parse(heute_tag); if (heute_tag_int == 0) heute_tag_int = 7; else { heute_tag_int = heute_tag_int - 1; }
                if (heute_tag_int == int.Parse(heute))//der Tag wurde gefunden
                {
                    string von1 = alle_zeiten.Split('#')[i].Split('|')[1]; string bis1 = alle_zeiten.Split('#')[i].Split('|')[2];
                    if ("00:00" == von1)// das muss ein anhang sein.anhang bedeuted alle zeiten, die nach mitternacht kommen
                    { von_bis_mitternachtanhang = "356^bis: " + bis1; }
                }
            } anhangsuche_aktivieren = 0;
        }
        //peyda nakard boro time baadi tu hamoon rooz
        if (zielId == "00")
        {
            for (int i = 0; i < alle_zeiten.Split('#').Length - 1; i++)
            {
                string heute_tag = alle_zeiten.Split('#')[i].Split('|')[0];
                if (int.Parse(heute_tag) == int.Parse(heute))//der Tag wurde gefunden
                {
                    string von1 = alle_zeiten.Split('#')[i].Split('|')[1];
                    string bis1 = alle_zeiten.Split('#')[i].Split('|')[2];
                    if (DateTime.Parse(zeit_jetzt) <= DateTime.Parse(bis1))
                    {
                        zielId = alle_zeiten.Split('#')[i].Split('|')[3];
                        zustand = "zu";
                        von_bis = "Heute " + von1 + "-" + bis1;
                        if (alle_zeiten.Split('#')[i].Split('|').Length == 7)
                            gruppen_liste = alle_zeiten.Split('#')[i].Split('|')[5];
                    }
                }
            }
        }
        //tu hamoon rooz dige time nist boro baraye farda
        if (zielId == "00")
        {
            for (int i = 0; i < alle_zeiten.Split('#').Length - 1; i++)
            {
                string heute_tag = alle_zeiten.Split('#')[i].Split('|')[0];
                if (int.Parse(heute) == 7) heute = "0";//ke az yekschnabe bere doshanbe
                if (int.Parse(heute_tag) == int.Parse(heute) + 1)//der Tag wurde gefunden
                {
                    string von1 = alle_zeiten.Split('#')[i].Split('|')[1];
                    string bis1 = alle_zeiten.Split('#')[i].Split('|')[2];
                    zielId = alle_zeiten.Split('#')[i].Split('|')[3];
                    zustand = "zu";
                    von_bis = "Morgen " + von1 + "-" + bis1;
                    if (alle_zeiten.Split('#')[i].Split('|').Length == 7)
                        gruppen_liste = alle_zeiten.Split('#')[i].Split('|')[5];
                }
            }
        }
        //fardash ham nadare boro muster ro bede
        if (zielId == "00")
        {
            for (int i = 0; i < alle_zeiten.Split('#').Length - 1; i++)
            {
                string heute_tag = alle_zeiten.Split('#')[i].Split('|')[0];
                if (int.Parse(heute_tag) == 8)//der Tag wurde gefunden
                {
                    string von1 = alle_zeiten.Split('#')[i].Split('|')[1];
                    string bis1 = alle_zeiten.Split('#')[i].Split('|')[2];
                    zielId = alle_zeiten.Split('#')[i].Split('|')[3];
                    zustand = "zu";
                    von_bis = "Morgen " + von1 + "-" + bis1;
                    if (alle_zeiten.Split('#')[i].Split('|').Length == 7)
                        gruppen_liste = alle_zeiten.Split('#')[i].Split('|')[5];
                }
            }
        }
        return zustand + "|" + von_bis + "|" + angebot + "|" + gruppen_liste;// +"|" + gruppen_liste;//= coords + 1 + "!" + 1 + "!" + 1 + "!133!29800!0!" + 1 + "!g" + 1 + "!@";
    }
    protected string offnung_zeiten_modern(string hauptM3)
    {//entweder return=1 yanee ist auf oder nexte von-bis
        string von_bis = "";
        string gruppen_liste = "";
        string zustand = "zu";
        string heute = "8";
        if (wochentag == "Friday") heute = "5";
        if (wochentag == "Sunday") heute = "7";
        if (wochentag == "Saturday") heute = "6";
        if (wochentag == "Thursday") heute = "4";
        if (wochentag == "Wednesday") heute = "3";
        if (wochentag == "Tuesday") heute = "2";
        if (wochentag == "Monday") heute = "1";
        string zeit_jetzt = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
        //suche in zeitfenster nach passende zeit
        string zielId = "00";
        int anhangsuche_aktivieren = 0; string angebot = ""; string von_bis_mitternachtanhang = "";
        string alle_zeiten = hauptM3.Split('~')[2];
        DataTable table_data_alle_zeiten = new DataTable();
        table_data_alle_zeiten.Columns.Add("dat_tag_nummer", typeof(string));//[0]
        table_data_alle_zeiten.Columns.Add("dat_von", typeof(string));//[1]
        table_data_alle_zeiten.Columns.Add("dat_bis", typeof(string));//[2]
        table_data_alle_zeiten.Columns.Add("dat_zielId", typeof(string));//[3]
        table_data_alle_zeiten.Columns.Add("dat_angebot", typeof(string));//[4]
        table_data_alle_zeiten.Columns.Add("dat_gruppen_liste", typeof(string));//[5]
        for (int i = 0; i < alle_zeiten.Split('#').Length - 1; i++)
        {
            int geh = int.Parse(alle_zeiten.Split('#')[i].Split('|')[0]);
            string geh2 = geh.ToString();
            table_data_alle_zeiten.Rows.Add(
                geh2, alle_zeiten.Split('#')[i].Split('|')[1],
                alle_zeiten.Split('#')[i].Split('|')[2],alle_zeiten.Split('#')[i].Split('|')[3],
                alle_zeiten.Split('#')[i].Split('|')[4],alle_zeiten.Split('#')[i].Split('|')[5]);
        }
        try //jetzt offen
        {
            DataRow[] foundRows = table_data_alle_zeiten.Select("dat_tag_nummer = " + heute );
            string von1 = foundRows[0][1].ToString();
            string bis1 = foundRows[0][2].ToString();
            bis1 = bis1;
            if (DateTime.Parse(zeit_jetzt) <= DateTime.Parse(bis1) && DateTime.Parse(zeit_jetzt) >= DateTime.Parse(von1))
            {
                zielId = foundRows[0][3].ToString();
                zustand = "auf";
                von_bis = "bis: " + bis1;
                angebot = foundRows[0][4].ToString();
                gruppen_liste = foundRows[0][5].ToString();
                //if (bis1 == "23:59"){anhangsuche_aktivieren = 1;}
                zielId = zielId;
            }
        }
        catch { zielId = "00"; }

        if (anhangsuche_aktivieren == 1)
        {for (int i = 0; i < alle_zeiten.Split('#').Length - 1; i++){string heute_tag = alle_zeiten.Split('#')[i].Split('|')[0];
                //wird ein tag abgezogen damit zeiten,die nach mitternacht kommen, noch gesehen werden
                int heute_tag_int = int.Parse(heute_tag);if (heute_tag_int == 0)heute_tag_int = 7;else{heute_tag_int = heute_tag_int - 1;}
                if (heute_tag_int == int.Parse(heute))//der Tag wurde gefunden
                {string von1 = alle_zeiten.Split('#')[i].Split('|')[1];string bis1 = alle_zeiten.Split('#')[i].Split('|')[2];
                    if ("00:00" == von1)// das muss ein anhang sein.anhang bedeuted alle zeiten, die nach mitternacht kommen
                    {von_bis_mitternachtanhang = "356^bis: " + bis1;}}}anhangsuche_aktivieren = 0;
        }
        //peyda nakard boro time baadi tu hamoon rooz
        if (zielId == "00")
        {
            try
            {
                DataRow[] foundRows = table_data_alle_zeiten.Select("dat_tag_nummer = " + heute);
                string von1 = foundRows[0][1].ToString();
                string bis1 = foundRows[0][2].ToString();
                if (DateTime.Parse(zeit_jetzt) <= DateTime.Parse(bis1))
                {
                    zielId = foundRows[0][3].ToString();
                    zustand = "zu";
                    von_bis = "Heute " + von1 + "-" + bis1;
                    //if (alle_zeiten.Split('#')[i].Split('|').Length == 7)
                    gruppen_liste = foundRows[0][5].ToString();
                }
            }
            catch { zielId = "00"; }
        }
        
        //fardash ham nadare boro muster ro bede
        if (zielId == "00")
        {
            DataRow[] foundRows = table_data_alle_zeiten.Select("dat_tag_nummer = '8'");
            string von1 = foundRows[0][1].ToString();
            string bis1 = foundRows[0][2].ToString();
            zielId = foundRows[0][3].ToString();
            zustand = "zu";
            von_bis = "Morgen " + von1 + "-" + bis1;
            gruppen_liste = foundRows[0][5].ToString();
        }
        return zustand + "|" + von_bis + "|" + angebot+"|"+gruppen_liste;// +"|" + gruppen_liste;//= coords + 1 + "!" + 1 + "!" + 1 + "!133!29800!0!" + 1 + "!g" + 1 + "!@";
    }
 }