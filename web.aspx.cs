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
using System.IO;//stream reader und file.
using System.Net.Mail;
using System.Net;// for FtpWebRequest und Webclient

public partial class Default : System.Web.UI.Page
{
    string id = "";//?1=id;2=show_it; 3=open_it;4=read from lokalhost;5=zeitfenster_id
    public void Page_Load(object sender, EventArgs e)
    {
        //mybody.Style.Add("background-color", "#58682a");//58682a
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Default), this.Page);

        string windowUrl = Request.Url.ToString().Split('?')[0]; try { id = Request.Url.Query.Split('?')[1]; }
        catch { id = "387";/*zutat*/ };
        string path_server_haupt = ""; string hauptM3 = "";
        string localhost_version = "0";
        try { localhost_version = Request.Url.ToString().Split('?')[4]; }
        catch { };
        //WebClient webClient = new WebClient();
        //if (localhost_version == "1") 
        //{ 
        path_server_haupt = Server.MapPath(@"~/fsw/ablage/" + id);
        string attach_file = path_server_haupt + "/h-" + id + ".txt";
        hauptM3 = File.ReadAllText(attach_file);
        //} 
        //else 
        //{
        // //path_server_haupt = "http://komod.giessen3.de/komod/Giessengastro_html/ablage/" + id;
        // path_server_haupt = "http://album.giessengastro.de/ablage/" + id;
        //  hauptM3 = webClient.DownloadString(path_server_haupt + "/h-" + id + ".txt");
        //}
        //neu_aj
        System.Web.UI.HtmlControls.HtmlGenericControl neu_aj = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        neu_aj = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); form1.Controls.Add(neu_aj);
        neu_aj.ID = "neu_aj";
        neu_aj.Style.Add("display", "none");
        neu_aj.InnerHtml = hauptM3;

        string Z_Y_return = ny_cls.ccl_karte.Z_YAB(id, hauptM3);
        string tagesangebot_des_restaurants = "";//133
        string time_bescreibung = "";
        int op_1_off_0 = 0;
        string restzeit = "";
        //lade tafel string
        time_bescreibung = Z_Y_return.Split('╚')[0];
        tagesangebot_des_restaurants = Z_Y_return.Split('╚')[1];
        op_1_off_0 = int.Parse(Z_Y_return.Split('╚')[2]);
        restzeit = Z_Y_return.Split('╚')[3];
        //open it vor tafel
        string open_it = "0"; try { open_it = Request.Url.Query.Split('?')[3]; }
        catch { open_it = "0"; }; if (open_it == "1") op_1_off_0 = 1;
        System.Web.UI.HtmlControls.HtmlGenericControl div_open_it = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_open_it = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); form1.Controls.Add(div_open_it);
        div_open_it.ID = "div_open_it";
        div_open_it.Style.Add("display", "none"); div_open_it.InnerHtml = open_it;
        //show_it 
        string show_it = "0"; try { show_it = Request.Url.Query.Split('?')[2]; }
        catch { show_it = "0"; };
        System.Web.UI.HtmlControls.HtmlGenericControl div_show_it = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        div_show_it = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); form1.Controls.Add(div_show_it);
        div_show_it.ID = "C263_show_it";
        div_show_it.Style.Add("display", "none"); div_show_it.InnerHtml = show_it;
        //tafel informationen
        System.Web.UI.HtmlControls.HtmlGenericControl von_bis_div = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        von_bis_div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); form1.Controls.Add(von_bis_div);
        von_bis_div.ID = "von_bis_div";
        von_bis_div.Style.Add("display", "none");
        //von_bis_div.InnerHtml = von_bis + "|" + time_bescreibung + "|" + tagesangebot_des_restaurants + "|" + op_1_off_0.ToString() + "|" + restzeit + "|" + Z_Y_return.Split('╚')[6];
        von_bis_div.InnerHtml = time_bescreibung + "╚" + tagesangebot_des_restaurants + "╚" + op_1_off_0.ToString() + "╚" + restzeit + "╚" + Z_Y_return.Split('╚')[5] + "╚" + Z_Y_return.Split('╚')[4];
        //ip_
        System.Web.UI.HtmlControls.HtmlGenericControl user_ip = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        user_ip = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); form1.Controls.Add(user_ip);
        user_ip.ID = "C_user_ip";
        user_ip.Style.Add("display", "none");
        user_ip.InnerHtml = HttpContext.Current.Request.UserHostAddress.ToString();


        string zielId = Z_Y_return.Split('╚')[4];

        //string path_server = Server.MapPath(@"~/fsw/ablage/" + id);
        string mp3_text = "";
        //if (localhost_version == "1")
        //{
        mp3_text = File.ReadAllText(path_server_haupt + "/" + zielId + ".web.txt");
        //}
        //else
        //{

        //  mp3_text = webClient.DownloadString(path_server_haupt + "/" + zielId + ".web.txt");
        //mp3_text = File.ReadAllText(mp3_text);
        //mp3_text = raplase_deytscu(mp3_text);
        //}

        System.Web.UI.HtmlControls.HtmlGenericControl div_xh = default(System.Web.UI.HtmlControls.HtmlGenericControl); div_xh = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); form1.Controls.Add(div_xh); div_xh.InnerHtml = mp3_text;
        mybody.Attributes.Add("onload", "xystart();");
    }

    [AjaxPro.AjaxMethod()]//wird benutzt von javascript
    public string DS_sendMail(string body, string besteller, string strasse, string h_nummer, string plz, string stadt, string bemerkung,
        string zeitId, string pswort, string parallel_welt, string fahrtkosten, string kunden_mail, string mit_oder_ohne_email_confirm, string Mail,
        string telefon, string packet_mail_adressen, string rh_fax_optionen, string rh_von_bis, string rh_kunden_id, string rh_vorwahl,
        string rabatt_summe, string rh_jpg_aktiv, string rh_restaurant_name, string rh_pic_link, string rh_retaurant_id, string moblile,
        string open_it, string rh_link, string rh_ip_user,string payp_bezahlt_info)
    {
        string ke = "";
        ke = send_fraction.CL_sendMail(body, besteller, strasse, h_nummer, plz, stadt, bemerkung,
         zeitId, pswort, parallel_welt, fahrtkosten, kunden_mail, mit_oder_ohne_email_confirm, Mail,
         telefon, packet_mail_adressen, rh_fax_optionen, rh_von_bis, rh_kunden_id, rh_vorwahl,
         rabatt_summe, rh_jpg_aktiv, rh_restaurant_name, rh_pic_link, rh_retaurant_id, moblile, open_it, rh_link, rh_ip_user, payp_bezahlt_info);
        return ke;
    }
    static string ip = HttpContext.Current.Request.UserHostAddress.ToString();
    [AjaxPro.AjaxMethod()]
    public string besucherRegister(string register_info, string retaurant_id)
    {
        string antwort = "";
        
        ip = HttpContext.Current.Request.UserHostAddress.ToString();
        DataSet2TableAdapters.Ip_registerTableAdapter ip_reg = new DataSet2TableAdapters.Ip_registerTableAdapter();
        string jahr = DateTime.Now.Year.ToString();
        string monat = DateTime.Now.Month.ToString();
        string datum = DateTime.Now.Day.ToString();
        string Zeit = DateTime.Now.TimeOfDay.ToString();
        //string MIn = DateTime.Now.Minute.ToString();
        string Zeit2 = datum + "/" + monat + "/" + jahr + " " + Zeit;
        register_info += "@Enter time:" + "enter_time";//enter_time sollte in pageload zusammengestellt werden (sep 2016)
        //register_info += "@Exit time:" + Zeit2;

        DataSet2TableAdapters.Kunden1TableAdapter ta_k1 = new DataSet2TableAdapters.Kunden1TableAdapter();

        try
        {
            //ip_reg.InsertQueryAll(retaurant_id, register_info, ip);
            //ip_reg.InsertQueryAll(register_info, retaurant_id);
            //antwort += ip_reg.GetData()[0]["text"].ToString() + "\n";
            antwort += "emali("+ta_k1.GetDataById(101)[0]["javad"].ToString() + ")\n";
            antwort += "emali Erfolgreich \n\n\n";
        }
        catch (Exception exception)
        {
            antwort += "email Gescheitert \n\n\n";
            antwort += exception + "\n\n\n";
        };
        try
        {
            //ip_reg.InsertQueryAll(retaurant_id, register_info, ip);
            //ip_reg.UpdateQuery_test1("IP_all");
            antwort += "101-telefon(" + ta_k1.GetDataById(101)[0]["datum"].ToString() + ")\n";// ASC
            antwort += "28-telefon(" + ta_k1.GetDataById(28)[0]["datum"].ToString() + ")\n";// ASC
            antwort += "39-telefon(" + ta_k1.GetDataById(39)[0]["datum"].ToString() + ")\n";// ASC
            antwort += "43-telefon(" + ta_k1.GetDataById(43)[0]["telefon"].ToString() + ")\n";// ASC
            antwort += "8-telefon(" + ta_k1.GetDataById(8)[0]["telefon"].ToString() + ")\n";// ASC
            antwort += "pwort(" + ta_k1.GetDataById(101)[0]["pwort"].ToString() + ")\n";//pwort ASC
            antwort += "datum2(" + ta_k1.GetDataById(101)[0]["datum2"].ToString() + ")\n";//pwort ASC
            antwort += "222222 Erfolgreich \n";
        }
        catch (Exception exception)
        {
            antwort += "222222 Update Gescheitert \n\n\n";
            antwort += exception + "\n\n\n"; 
        };
        try
        {
            antwort += ta_k1.GetDataBy_id2_test(101)[0]["telefon"].ToString();
            
            antwort += "3333333 Erfolgreich \n\n\n";
        }
        catch (Exception exception)
        {
            antwort += "33333333 insert Gescheitert \n";
            antwort += exception + "\n\n\n";
        };
        try
        {
            ip_reg.UpdateQuery_test3("pappapa","kakaka");// .InsertQuery_para_convert("ip", "text", "ip2");
            antwort += "444444444 Erfolgreich \n";
        }
        catch (Exception exception)
        {
            antwort += "444444444 insert Gescheitert \n";
            antwort += exception + "\n\n\n";
        };
        return antwort;
    }
    private static readonly object syncLock = new object();
    [AjaxPro.AjaxMethod()]//wird benutzt von jabascript
    public string update_kunden_adresse(string daten, string rh_kundenId)//07,12,13
    {
        string antwort = "C101 Update erfolgreich";
        
        DataSet2TableAdapters.Kunden1TableAdapter ta_k1 = new DataSet2TableAdapters.Kunden1TableAdapter();
        try
        {
            ta_k1.UpdateQueryDaten(daten, int.Parse(rh_kundenId));
        }
        catch { antwort = "C108 Update Gescheitert"; };
        return antwort;
    }
    
   // static string zeit_tabelle = "";
    [AjaxPro.AjaxMethod()]// wird benutzt von javascript
    public string C97_login(string body, string user, string pwort, string retaurant_id)
    {
        return CL_login.Cl_login(body, user, pwort, retaurant_id);
    }
    [AjaxPro.AjaxMethod()]// wird benutzt von javascript
    public string C161_gutschein(string gts_nummer)
    {
        return CL_login.gutschein_einloesen(gts_nummer);
    }
    [AjaxPro.AjaxMethod()]
    public string insertkunde(string body, string telefon, string empaenger, string strasse, string h_nummer, string plz, string stadt, string bemerkung, string zeitId, string email, string pwort)
    {
        string ret = "";
        ret = CL_login.cl_insertkunde(body, telefon, empaenger, strasse, h_nummer, plz, stadt, bemerkung, zeitId, email, pwort);
        return ret;
    }
    [AjaxPro.AjaxMethod()]
    public static string send_mail_box(string Html_boyd, string name, string mail, string betreff)
    {
        string antwort = "";
        try
        {
            MailMessage message = new MailMessage();
            message.To.Add(new MailAddress("info@giessengastro.de"));
            message.To.Add(new MailAddress("bestellungsfach@giessengastro.de"));
            message.Subject = "an " + betreff + " Nachricht von Besucher";
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
}