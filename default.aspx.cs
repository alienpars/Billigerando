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

using AjaxPro;
using System.Net.Mail;
using System.Net;//network credential
using System.IO;//stream reader und file.





public partial class Default : System.Web.UI.Page
{
    static string wochentag = "";//58-id|name|gn2=Zeitfenster|
    public void Page_Load(object sender, EventArgs e)
    {
        wochentag = DateTime.Now.DayOfWeek.ToString();
        create_elements();
        lade_mp3();
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Default), this.Page);
    }

    protected void lade_mp3()
    {
        //info_div_zeitfenster
        System.Web.UI.HtmlControls.HtmlGenericControl info_div_zeitfenster = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        info_div_zeitfenster = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");form1.Controls.Add(info_div_zeitfenster);
        info_div_zeitfenster.ID = "C103jax";
        info_div_zeitfenster.Style.Add("display", "none");
        
        //string my_plz_liste = "2577|46086|2353|46117|46146|46173|";
        //string my_plz_liste = "46349|46086|46313|46117|46146|46173|46260|46462|";
        //string my_plz_liste = "46349|46086|46313|46117|46146|46173|46260|";
        //string my_plz_liste = "46349|46086|46313|46117|46146|46173|46260|46489|";//46524
        //string my_plz_liste = "46349|46086|46313|46117|46146|46173|46260|46489|46524|";//
        //string my_plz_liste = "46349|46086|46313|46117|46146|46173|46260|46489|46524|46592|";//
        //WebClient webClient = new WebClient();
        string my_plz_liste = "";
        string path_server_haupt0 = "";
        path_server_haupt0 = Server.MapPath(@"~/ldst.txt");
        string attach_file = path_server_haupt0;
        my_plz_liste = File.ReadAllText(attach_file);

        //string my_plz_liste = "46086|46117|46146|46173|";
        for (int i3 = 0; i3 < my_plz_liste.Split('|').Length ; i3++)
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

                // schliesst in  ╚╚1╚2017,10,07,22,45,00╚46379╚0
                //string offnung_zeiten_str = offnung_zeiten(mp3_von_haupt);
                //auf|bis: 22:45||PIZZA ^PIZZA NEUHEITEN ^CALZONE ^ VORSPEISE ^ PASTA ^ ROLLOS ^ GEMÜSEAUFLAUF ^ BAGUETTES ^ SALATE ^ FLEISCHGERICHTE ^ SCHNITZELAUFLAUF ^ GETRÄNKE ^ DESSERT ^ CHINA HUHN ^ CHINA RIND ^ CHINA SCHWEIN ^ CHINA ENTE ^ HUMMERKRABBEN ^ GEBRATENE REIS - NUDEL ^ BEILAGEN ^ GYROS ^ SPECIAL FOOD ^ FLAMMKUCHEN ^ MAM BURGER ^ KID´S MENÜ^ gruppe11 ^

                info_div_zeitfenster.InnerHtml += mp3_von_haupt + "↑" + offnung_zeiten_str + "↑←";
                //}
            }
            catch { int eins = 1; };
        }
        string show_it = "0"; try { show_it = Request.Url.Query.Split('?')[1]; }
        catch { show_it = "0"; }; System.Web.UI.HtmlControls.HtmlGenericControl div_show_it = default(System.Web.UI.HtmlControls.HtmlGenericControl); div_show_it = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_show_it.ID = "C263_show_it"; form1.Controls.Add(div_show_it); div_show_it.Style.Add("display", "none"); div_show_it.InnerHtml = show_it;

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
            }
            anhangsuche_aktivieren = 0;
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
        System.Web.UI.HtmlControls.HtmlGenericControl div_nix = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_nix = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); form1.Controls.Add(div_nix);
        //uber uns
        menu_box_table(med, show_it, div_nix, "us_", "C_97_uber_uns", "über uns");
        menu_box_table(med, show_it, div_nix, "impressum_", "C_100_impressum", "Impressum");
        menu_box_table(med, show_it, div_nix, "Kontakt_", "C_101_Kontakt", "Kontakt");
        menu_box_table(med, show_it, div_nix, "agb_", "C_102_agb", "AGB's");
        menu_box_table(med, show_it, div_nix, "haftung_", "C_103_haftung", "Haftung");
    }
    protected void menu_box_table(string med, string show_it, HtmlGenericControl div_rand, string class_zusatz, string element_id, string titel_name)
    {
        //string withh = "600";
        System.Web.UI.HtmlControls.HtmlGenericControl div_titel_text = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_titel_text = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_rand.Controls.Add(div_titel_text);
        div_titel_text.Attributes.Add("class", class_zusatz + "C_Class_center_table");
        div_titel_text.Style.Add("display", "none");
        //div_titel_text.Style.Add("align", "right");

        System.Web.UI.HtmlControls.HtmlGenericControl div_titel = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_titel = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_titel_text.Controls.Add(div_titel);
        div_titel.ID = element_id + "C_td_head_box";
        div_titel.Attributes.Add("class", "contact");
        div_titel.Style.Add("padding-top", "80px");
        System.Web.UI.HtmlControls.HtmlGenericControl h3_cont = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        h3_cont = new System.Web.UI.HtmlControls.HtmlGenericControl("H3"); div_titel.Controls.Add(h3_cont);
        h3_cont.Attributes.Add("class", "tz-title-2");

        System.Web.UI.HtmlControls.HtmlGenericControl span_cont = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        span_cont = new System.Web.UI.HtmlControls.HtmlGenericControl("SPAN"); h3_cont.Controls.Add(span_cont);
        span_cont.Attributes.Add("class", "tzweight_Bold");
        span_cont.ID = element_id + "C_td_head_box";
        span_cont.InnerText = titel_name;
        span_cont.Style.Add("color", "#ffa500");


        System.Web.UI.HtmlControls.HtmlGenericControl div_43w = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_43w = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_titel.Controls.Add(div_43w);
        div_43w.Attributes.Add("class", "about_desc");
        //div_43w.ID = "CC_122";
        //div_text.Style.Add("width", withh + "px");
        System.Web.UI.HtmlControls.HtmlGenericControl p_43w = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        p_43w = new System.Web.UI.HtmlControls.HtmlGenericControl("P"); div_43w.Controls.Add(p_43w);
        p_43w.Attributes.Add("class", "about_para");
        p_43w.Style.Add("color", "#ffa500");
        p_43w.ID = element_id + "C_textarea_box";
        p_43w.Style.Add("padding-bottom", "40px");
        System.Web.UI.HtmlControls.HtmlGenericControl div_abstand = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_abstand = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_titel_text.Controls.Add(div_abstand);
        //div_abstand.Style.Add("height", "250px");
        div_abstand.Attributes.Add("class", "about_desc");
        //div_abstand.Style.Add("background-image", "url(Bilder/bg.jpg)");
        div_abstand.Style.Add("background-color", "#c0392b");
        System.Web.UI.HtmlControls.HtmlGenericControl div_titel_bild = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_titel_bild = new System.Web.UI.HtmlControls.HtmlGenericControl("img"); div_abstand.Controls.Add(div_titel_bild);
        div_titel_bild.Attributes.Add("src", "images/logo.png");
        System.Web.UI.HtmlControls.HtmlGenericControl div_43ww2 = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_43ww2 = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); div_titel.Controls.Add(div_43ww2);
        div_43ww2.Attributes.Add("class", "about_desc");
        div_43ww2.ID = element_id + "CC_122";
        
    }
    [AjaxPro.AjaxMethod()]
    public static string send_mail_box(string Html_boyd,string name,string mail)
    {
        string antwort = "";
        try
        {
            MailMessage message = new MailMessage();
            message.To.Add(new MailAddress("info@giessengastro.de"));
            message.To.Add(new MailAddress("bestellungsfach@giessengastro.de"));
            message.Subject = "Nachricht von Besucher";
            message.From = new MailAddress("technik@giessengastro.de");
            SmtpClient smtp2 = new SmtpClient("smtp.1and1.com");
            message.Body = mail + "<br>" + name + "<br><br>" + Html_boyd;
            smtp2.Port = 25;
            smtp2.Host = "smtp.1and1.com";
            smtp2.EnableSsl = true;
            message.IsBodyHtml = true;
            smtp2.UseDefaultCredentials = false;
            smtp2.Credentials = new NetworkCredential("technik@giessengastro.de", "behnammehdi1.2");
            smtp2.Send(message);
            antwort = "Ihre Nachricht wurde gesendet";
        }
        catch
        {
            antwort = "Fehler: \n Verbingsaufbau nicht möglich!";
        }
        return antwort;
    }
   
    protected void menu_box_table_alt(string med, string show_it, HtmlGenericControl div_rand, string class_zusatz, string element_id)
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