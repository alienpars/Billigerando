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
using System.Net;//network credential

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


        string neu_aj_p_str = "00.01";
        if (Request["neu_aj_p"] != null) neu_aj_p_str = Request["neu_aj_p"];
        System.Web.UI.HtmlControls.HtmlGenericControl neu_aj = default(System.Web.UI.HtmlControls.HtmlGenericControl);
        neu_aj = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV"); form1.Controls.Add(neu_aj);
        neu_aj.ID = "neu_aj_p";
        neu_aj.Style.Add("display", "none");
        neu_aj.InnerHtml = neu_aj_p_str;
        //mybody.Attributes.Add("onload", "xystart();");
    }

    [AjaxPro.AjaxMethod()]//wird benutzt von javascript
    public string DS_sendMail(string body, string besteller, string strasse, string h_nummer, string plz, string stadt, string bemerkung,
        string zeitId, string pswort, string parallel_welt, string fahrtkosten, string kunden_mail, string mit_oder_ohne_email_confirm, string Mail,
        string telefon_46, string packet_mail_adressen, string rh_fax_optionen, string reserve27, string rh_kunden_id, string rh_vorwahl,
        string rabatt_summe, string rh_jpg_aktiv, string rh_restaurant_name, string rh_pic_link, string rh_retaurant_id, string moblile, 
        string open_it, string rh_link, string rh_ip_user, string payp_bezahlt_info)
    {
        string ke = "";
        ke = send_fraction.CL_sendMail(body, besteller, strasse, h_nummer, plz, stadt, bemerkung,
         zeitId, pswort, parallel_welt, fahrtkosten, kunden_mail, mit_oder_ohne_email_confirm, Mail,
         telefon_46, packet_mail_adressen, rh_fax_optionen, reserve27, rh_kunden_id, rh_vorwahl,
         rabatt_summe, rh_jpg_aktiv, rh_restaurant_name, rh_pic_link, rh_retaurant_id, moblile, open_it, rh_link, rh_ip_user, payp_bezahlt_info);
        return ke;
    }
    static string ip = HttpContext.Current.Request.UserHostAddress.ToString();



}