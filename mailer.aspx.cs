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
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;

public partial class mailer : System.Web.UI.Page
{
    //http://yousystem2000.de/mailer.aspx?kunden_mail=pizzakunde@gmail.com&bestellungsnummer=676&dauer_der_bestelllung=30&vorwahl=49
    DataSet2TableAdapters.bestellungTableAdapter ta_bestellung = new DataSet2TableAdapters.bestellungTableAdapter();
    DataSet2TableAdapters.Kunden1TableAdapter ta_k1 = new DataSet2TableAdapters.Kunden1TableAdapter();
    //DataSet2TableAdapters.hauptMp3TableAdapter ta_hauptMp4 = new DataSet2TableAdapters.hauptMp3TableAdapter();
    int vorwahl = 0;
    protected void Page_Load(object sender, EventArgs e)
    {string fehler_bericht = "start  \n";mini_Zelle_logo = ""; 
        string bestelllungssnummer = Request["bestellungsnummer"];
        string alles_anschrift = ta_bestellung.GetDataById(bestelllungssnummer)[0]["anschrift"].ToString();
        fax_optionen = alles_anschrift.Split('=')[8];
        string kunden_mail = alles_anschrift.Split('=')[0];
        try { vorwahl = int.Parse(Request["vorwahl"]); }
        catch { vorwahl = 49; }string bestellung_zustand = ta_bestellung.GetDataById(bestelllungssnummer)[0]["Ip"].ToString();
        if (int.Parse(bestellung_zustand) == 0)
        {/*sprache*/try{sprache(vorwahl);fehler_bericht += "1: Page_Load() Sprache abgeschlossen mit vorwahl: +" + vorwahl + " \n";schild.InnerHtml = "<img src=Bilder/send3.png width=100%>";}catch{fehler_bericht += "XXX1: Page_Load Sprache nicht abgeschlossen mit vorwahl: (+" + vorwahl + ") \n";schild.InnerHtml = "<img src=Bilder/delete.png width=100%>";}
            try
            {
                send_bestellung_von_gmail(
                                          alles_anschrift.Split('=')[1],//Request["Pizzaria_mail_drucker"],
                                          "", //zweite Mail
                                          alles_anschrift.Split('=')[2],//Request["plz"],
                                          alles_anschrift.Split('=')[3],//Request["besteller"],
                                          Request["dauer_der_bestelllung"],
                                          alles_anschrift.Split('=')[4],//Request["fax_aktiv_1"],//jpg nur im falle fax ist aktiv (felan)
                                          Request["bestellungsnummer"],
                                          alles_anschrift.Split('=')[6],//Request["empaenger_paket"],
                                          alles_anschrift.Split('=')[10],//Request["faxnummer"],//kundenId_extern
                                          alles_anschrift.Split('=')[12],//Request["orginal_info"],//
                                          fehler_bericht,
                                          alles_anschrift.Split('=')[13],//Request["rh_restaurant_name"],//rh_restaurant_name
                                          alles_anschrift.Split('=')[11],//Request["vorwahl"],
                                          alles_anschrift.Split('=')[14],//Request["rh_pic_link"]
                                          alles_anschrift.Split('=')[15]//rh_restaurant_id
                                          );//default.aspx 8uuioh7di
                
           }catch{schild.InnerHtml = "ERORE bei send_besteellung_von_gmail\n<br>";schild.InnerHtml = "fax_optionen=" + fax_optionen + "\n<br>";schild.InnerHtml += "Parameter check:\n<br>";schild.InnerHtml +=alles_anschrift.Split('=')[1];schild.InnerHtml += "leer:" + "" + "\n<br>"; schild.InnerHtml += "plz:" + alles_anschrift.Split('=')[2];schild.InnerHtml += "besteller:" + alles_anschrift.Split('=')[3];schild.InnerHtml += "dauer_der_bestellung:" + Request["dauer_der_bestelllung"] + "\n<br>";schild.InnerHtml += "fax_aktiv_1:" + alles_anschrift.Split('=')[4];schild.InnerHtml += "bestellungsnummer:" + Request["bestellungsnummer"] + "\n<br>";schild.InnerHtml += "empaenger_paket:" + alles_anschrift.Split('=')[6];schild.InnerHtml += "faxnummer:" + alles_anschrift.Split('=')[10];schild.InnerHtml += "orginal_info:" + alles_anschrift.Split('=')[12];schild.InnerHtml += "fehler_bericht:" + fehler_bericht + "\n<br>";schild.InnerHtml += "rh_restaurant_name:" + alles_anschrift.Split('=')[13];;schild.InnerHtml += "vorwahl:" + alles_anschrift.Split('=')[11];schild.InnerHtml += "rh_pic_link:" + alles_anschrift.Split('=')[14];string code = "start code abfrage";try{string nummmer_der_bestellllung = Request["bestellungsnummer"];code = ta_bestellung.GetDataById(nummmer_der_bestellllung)[0]["string"].ToString();}catch { int ali = 8; };schild.InnerHtml += "code:" + code + "\n<br>";}

        }else /*Diese Bestellung wurde bereits bestätigt*/ { schild.InnerHtml = "<img src=Bilder/send-r.png width=100%>";  }
    }

    string diagnose = "";
    string ersatzt_fuer_parallewelt = "";
    string bestellungsnummer = "";
    int kundenId_extern = 0;
    string fax_optionen = "";
    string mini_Zelle_logo = "";//133
    protected void send_bestellung_von_gmail(string pizzaria_erste_mail, string pizzaria_zweiter_email, string plz, string besteller, string dauer_der_bestellung, string fax_aktiv_1, string BestellungId, string empaenger_paket, string faxnummer, string orginal_info, string fehler_bericht, string rh_restaurant_name, string rh_vorwahl, string rh_pic_link, string rh_retaurant_id)
    {
        int fax_laenge = 0;
        fehler_bericht = "";
        string antwort_fuer_link = "";

        string bestellung_code = "";
        try
        {
            bestellung_code = ta_bestellung.GetDataById(BestellungId)[0]["string"].ToString();
            fehler_bericht += "1: send_besteellung_von_gmail() bestellung satzt wurde gefunden \n";
        }
        catch
        {
            fehler_bericht += "X1: send_besteellung_von_gmail() bestellung satzt wurde nicht gefunden \n";
        }
        string Html = "";
        try
        {
            Html = Html_umwandler_alt(bestellung_code, empaenger_paket, "2@" + orginal_info, 1, BestellungId, fax_laenge, rh_restaurant_name,
                rh_pic_link, rh_vorwahl, rh_retaurant_id);
            fehler_bericht += privat_fehler_bericht_Html_string_umwandler;
            privat_fehler_bericht_Html_string_umwandler = "";
            
            fehler_bericht += "2: send_besteellung_von_gmail() HTML der bestellung wurde umgesetzt \n";

        }
        catch
        {
            Html = "Fehler bei System!!! bitte versuchen Sie sich telefonisch zu verbinden";
            fehler_bericht += "XXXXX2: send_besteellung_von_gmail() HTML der bestellung wurde nicht umgesetzt \n";
        }
        try
        {//////////////////////////////////// PRINTER
            if (rh_vorwahl == "98")
            {fehler_bericht += "iran ins noch baustelle";//Gmail_send("shop@mihanfood.com", pizzaria_erste_mail, "", fax_aktiv_1, faxnummer,"an Printer confirmed ORDE:" + besteller + " " + plz, Html, "0", 0, privat_fax_laenge_fuer_Html_string_umwandler,fehler_bericht, "shop@mihanfood.com", "sakdbt74", "webmail.mihanfood.com", 25, false);
            }
            else
            {
                fehler_bericht += Gmail_send(pizzaria_erste_mail,"an Printer confirmed ORDE:" + besteller + " " + plz, Html, privat_fax_laenge_fuer_Html_string_umwandler);
            }
                
            diagnose = "gesendet";
        }
        catch
        {
            fehler_bericht += "XXXX3 117 send_besteellung_von_gmail: Gmail_seend an pizzaria erste mail oder fax(" + pizzaria_erste_mail + ") nicht gesendet\n";
        }
        string align = "left";
        if (rh_vorwahl == "98") align = "right";
        

        string html_mit_confirm = "<table width='100%'  >";
        html_mit_confirm += "<tr>";
        html_mit_confirm += "<td align='" + align + "'>";//
        html_mit_confirm += "<span style='font-family:Arial;'><font size='" + fax_optionen.Split('!')[0].Split('|')[3].Split('^')[1] +"'>";
        html_mit_confirm += sp_sehr_geerte_d_u_h + "<br><br> ";
        string kunden_meil_betreff = "";
        if (dauer_der_bestellung == "0")
        {
            html_mit_confirm += sp_ablehnung;
            kunden_meil_betreff = sp_ablehnung;
            fehler_bericht += "4: send_besteellung_von_gmail() Bestellung Abgelehnt!!!";
        }
        else
        {
            html_mit_confirm += sp_ihre_bestellung_wurde_bestaetigt_usw;
            html_mit_confirm += dauer_der_bestellung + sp_minuten;
            html_mit_confirm += sp_bei_ihnen_eintreffen + "<br><br>";
            kunden_meil_betreff = sp_bestaeting_ihrer_bestellung;
            fehler_bericht += "4: send_besteellung_von_gmail() Bestellung angenommen in (" + dauer_der_bestellung + ") minuten";
        }
        html_mit_confirm += sp_vielen_dank + "<br>";
        html_mit_confirm += "</font></span>";
        html_mit_confirm += "</a>";
        html_mit_confirm += "</td>";
        html_mit_confirm += "</tr>";
        html_mit_confirm += "</table>";
        int fax_laenge_zusatzt_wegen_sehr_geehrte_damen_und_herrn = 310;
        privat_fax_laenge_fuer_Html_string_umwandler += fax_laenge_zusatzt_wegen_sehr_geehrte_damen_und_herrn;
        try
        {/////////////////////////////////////////// KUNDE
            if (rh_vorwahl == "98"){fehler_bericht += "iran baustelle";//Gmail_send("shop@mihanfood.com", empaenger_paket.Split('$')[8], "", "0", "000", rh_restaurant_name,html_mit_confirm+ Html, "0", 0, privat_fax_laenge_fuer_Html_string_umwandler, "", "shop@mihanfood.com", "sakdbt74","webmail.mihanfood.com", 25, false);
            }
            else
            {
                fehler_bericht += Gmail_send(empaenger_paket.Split('$')[8], kunden_meil_betreff, html_mit_confirm+ Html, privat_fax_laenge_fuer_Html_string_umwandler);
            }
        }
        catch
        {
            fehler_bericht += "XXXX5: send_besteellung_von_gmail() Bestätigung an Kunden(" + empaenger_paket.Split('$')[8] + ") von faxitwey@gmail.com nicht gesendet\n";
        }
        //bestellungsnummer Deaktivieren
        try{ta_bestellung.UpdateQueryClosed("99", BestellungId);}catch{fehler_bericht += "xxx6: send_besteellung_von_gmail() Bestellung: " + BestellungId + " wurde in tabelle nicht als closed makiert.\n";fehler_bericht += "Ende";}
    }
    string privat_fehler_bericht_Html_string_umwandler = ""; int privat_fax_laenge_fuer_Html_string_umwandler = 0;

    public string Html_umwandler_alt(string body, string empaenger_paket, string parallel_welt, int konfirm_0_bestellung_1, string BestellungId,
        int fax_laenge, string rh_restaurant_name, string rh_pic_link, string rh_vorwahl, string rh_retaurant_id)
    {
        //open empfaenger paket
        fax_laenge += 210;
        string empaenger = "";string strasse = "";string h_nummer = "";string plz = "";string bemerkung = "";string zeitId = "";string pswort = "";string fahrtkosten = "";string kunden_mail = "";string tel = "";
        //lade string
        try{empaenger = empaenger_paket.Split('$')[0];strasse = empaenger_paket.Split('$')[1];h_nummer = empaenger_paket.Split('$')[2];plz = empaenger_paket.Split('$')[3];bemerkung = empaenger_paket.Split('$')[4];zeitId = empaenger_paket.Split('$')[5];pswort = empaenger_paket.Split('$')[6];fahrtkosten = empaenger_paket.Split('$')[7];kunden_mail = empaenger_paket.Split('$')[8];tel = empaenger_paket.Split('$')[9];privat_fehler_bericht_Html_string_umwandler += "1: Html_b_umwandler() empaenger_paket.Split geladen name: " + empaenger_paket.Split('$')[0] + " \n";}
        catch{privat_fehler_bericht_Html_string_umwandler += "X1: Html_b_umwandler()empaenger_paket.Split nicht geladen name: " + empaenger_paket.Split('$')[0] + " \n";}
        
        string antwort = "";
        int gesamt_betrag = 0;
        string bis_jetzt_summe = "";
        if (konfirm_0_bestellung_1 == 1)
        {
            try{
                //addire gesamt summe
                kundenId_extern = int.Parse(Request["kundenId_extern"]);bis_jetzt_summe = ta_k1.GetDataById(kundenId_extern)[0]["gesamt_summe"].ToString();privat_fehler_bericht_Html_string_umwandler += "2: Html_b_umwandler() bisherige Gesamtsumme des Kunden erfolgreich ermitellt \n";
            }catch{privat_fehler_bericht_Html_string_umwandler += "X2: Html_b_umwandler() bisherige Gesamtsumme des Kunden nicht ermitellt \n";}
        }
        if (konfirm_0_bestellung_1 == 1)bestellungsnummer = BestellungId;
        if (konfirm_0_bestellung_1 == 1)
        {//gesamt summe
            try{
                int neue_summe = int.Parse(bis_jetzt_summe) + gesamt_betrag;
                ta_k1.UpdateQueryGesamt_summe(neue_summe, kundenId_extern);
                privat_fehler_bericht_Html_string_umwandler += "3: Html_b_umwandler() bisherige Gesamtsumme des Kunden(" + neue_summe + ")Addiert \n";
            }catch{privat_fehler_bericht_Html_string_umwandler += "X3: Html_b_umwandler() bisherige Gesamtsumme des Kunden nicht addiert \n";}
        }
        string mail = "";
        try{
            mail = ta_k1.GetDataById(kundenId_extern)[0]["email"].ToString();
            //DataSet2TableAdapters.Kunden2TableAdapter ta_tel = new DataSet2TableAdapters.Kunden2TableAdapter();
            tel = ta_k1.Gettelefon(kundenId_extern)[0]["telefon"].ToString();
            privat_fehler_bericht_Html_string_umwandler += "4: Html_b_umwandler() Telefon oder eMail des Kunden(" + mail + ")(" + tel + ") wurde gefunden \n";
        }catch{privat_fehler_bericht_Html_string_umwandler += "X4: Html_b_umwandler()  Telefon eMail nicht gefunden \n";}
        //string laden
        string Titelbild = "";string produkt_bild_groesse = "";string Anschrift_Font = ""; string page_Font = "";string Zutat_Font = ""; string Kunden_Analyse = ""; string Aktiv = "";string kopf_zeile = ""; string fuss_zeile = ""; 
        try{Titelbild = fax_optionen.Split('!')[0].Split('|')[0].Split('^')[1];
            produkt_bild_groesse = fax_optionen.Split('!')[0].Split('|')[0].Split('^')[1];
            Anschrift_Font = fax_optionen.Split('!')[0].Split('|')[2].Split('^')[1];
            page_Font = fax_optionen.Split('!')[0].Split('|')[3].Split('^')[1];
            Zutat_Font = fax_optionen.Split('!')[0].Split('|')[4].Split('^')[1];Kunden_Analyse = fax_optionen.Split('!')[0].Split('|')[5].Split('^')[1];kopf_zeile = fax_optionen.Split('!')[0].Split('|')[7].Split('^')[1];fuss_zeile = fax_optionen.Split('!')[0].Split('|')[8].Split('^')[1];privat_fehler_bericht_Html_string_umwandler += "5: Html_b_umwandler() Fax-Optionen erfolgreich geladen \n";}
        catch{privat_fehler_bericht_Html_string_umwandler += "X5:  Html_b_umwandler() Fax-Optionen nicht geladen  \n";}

        diagnose = "";
        //diagnose = "Ihre Bestellung konnte leider nicht weiter geleitet werden.";

        //////////////////////////LOGO
        try{
            antwort += fax_logo(antwort, produkt_bild_groesse, "", rh_retaurant_id, rh_pic_link);
            fax_laenge += privat_fax_laenge_von_fax_l_logo;privat_fax_laenge_von_fax_l_logo = 0;
            privat_fehler_bericht_Html_string_umwandler += "6: Html_b_umwandler() Fax-Logo erfolgreich geladen \n";
        }
        catch{antwort += "";privat_fehler_bericht_Html_string_umwandler += "X6: Html_b_umwandler() Fax-Logo nicht geladen \n";}
        //titel
        
        antwort += "<table width='100%'><tr>";
        antwort += "<td><span style='font-family:Arial;'><font size='" + page_Font + "'>" + sp_bestellungsnummer + " " + bestellungsnummer + "</font></span></td>";
        antwort += "<td align='right'><span style='font-family:Verdana;'><font size='" + page_Font + "'>" + sp_datum + " " + DateTime.Now + "</font></span></td>";
        antwort += "</tr></table>";
        //kopfzeile
        if (kopf_zeile != "1"){antwort += "<span style='font-family:Arial;'><font size='" + page_Font + "'>" + kopf_zeile + "</font></span>";fax_laenge += 80;}
        
        antwort += "<table width='100%' border='0'>";
        /////Liefer Anschrift
        string align = "left"; 
        if (rh_vorwahl == "98")
        {
            align = "right";
            antwort += "<tr><td colspan='2'   width='100%' height='2' bgcolor='#000000'></td></tr>";
            antwort += "<tr><td align='right'><span ><font size='" + Anschrift_Font + "'>" + sp_empfaenger + "</font></span></td></tr>";
            antwort += "<tr><td align='right'><span ><font size='" + Anschrift_Font + "'>" + empaenger + "</font></span></td></tr>";

            antwort += "<tr><td colspan='2'   width='100%' height='2' bgcolor='#000000'></td></tr>";
            antwort += "<tr><td align='right'><span ><font size='" + Anschrift_Font + "'>" + sp_tel + "</font></span></td></tr>";
            antwort += "<tr><td align='right'><span ><font size='" + Anschrift_Font + "'>" + tel + "</font></span></td></tr>";

            antwort += "<tr><td colspan='2'   width='100%' height='2' bgcolor='#000000'></td></tr>";
            antwort += "<tr><td align='right'><span><font size='" + Anschrift_Font + "'>" + sp_anschrift + "</font></span></td></tr>";
            antwort += "<tr><td align='right'><span><font size='" + Anschrift_Font + "'>" + strasse + " " + h_nummer + "</font></span></td></tr>";

            antwort += "<tr><td colspan='2'  align='right'><span><font size='" + Anschrift_Font + "'>" + plz + "</font></span></td></tr>";
        }
        else
        {
            antwort += "<tr><td><span style='font-family:Arial;'><font size='" + Anschrift_Font + "'>" + sp_empfaenger + "</font></span></td>";
            antwort += "<td><span style='font-family:Arial;'><font size='" + Anschrift_Font + "'>" + empaenger + "</font></span></td></tr>";
            antwort += "<tr><td><span style='font-family:Arial;'><font size='" + Anschrift_Font + "'>" + sp_tel + "</font></span></td>";
            antwort += "<td><span style='font-family:Arial;'><font size='" + Anschrift_Font + "'>" + tel + "</font></span></td></tr>";
            antwort += "<tr><td><span style='font-family:Arial;'><font size='" + Anschrift_Font + "'>" + sp_anschrift + "</font></span></td>";
            antwort += "<td><span style='font-family:Arial;'><font size='" + Anschrift_Font + "'>" + strasse + " " + h_nummer + "</font></span></td></tr>";
            antwort += "<tr><td colspan='2'><span style='font-family:Arial;'><font size='" + Anschrift_Font + "'>" + plz + "</font></span></td></tr>";
        }
        //antwort += "</table>";
        //antwort += "</td>";
        if (bemerkung != "")
        {
            antwort += "<tr><td align='" + align + "' colspan='2'>";
            antwort += "<table border='1'><tr><td  align='" + align + "'><span><font size='" + Anschrift_Font + "'><b><u>" + sp_bemerkung + "</u></b><br>" + bemerkung + "</font></span></td></tr></table>";
            antwort += "</td></tr>";
        }
        antwort += "</table>";
        string fehler_bericht="";
        int privat_fax_laenge_html_umw = 0;
        try/*Alarm test*/{
            for (int i = 0; i < body.Split(',').Length; i++)
            {
                try //mirza
                {
                    //
                    fehler_bericht += "\n\n\n\n8. orginal test ok::\n";
                    string orginal_test = ""; try { orginal_test = "N"; if (body.Split(',')[i] == parallel_welt.Split(',')[i])orginal_test = "O"; ersatzt_fuer_parallewelt += orginal_test + "|"; /*fehler_bericht += "8:  Html_umwandler() orginaltest bei produkt" + i + "mit Innerhalt:" + body.Split(',')[i] + "\n\n";*/ }
                    catch { fehler_bericht += "X8:  Html_umwandler() orginaltest bei produkt" + i + "mit Innerhalt:" + body.Split(',')[i] + " gescheiter\n\n"; }
                    //lade strings
                    string produkt_bild = body.Split(',')[i].Split('!')[2].Split('|')[5]; string position_x = body.Split(',')[i].Split('!')[2].Split('|')[1]; string position_x2 = body.Split(',')[i].Split('!')[2].Split('|')[3]; string position_y = body.Split(',')[i].Split('!')[2].Split('|')[0]; string position_y2 = body.Split(',')[i].Split('!')[2].Split('|')[2]; string preis_des_produkts = body.Split(',')[i].Split('!')[20]; string bemerkung_des_produktes = body.Split(',')[i].Split('!')[11]; string pizzaria_bemerkung = body.Split(',')[i].Split('!')[14]; gesamt_betrag += int.Parse(preis_des_produkts); string format_bild = ""; string format_x = ""; string format_x2 = ""; string format_y = ""; string format_y2 = ""; if (body.Split(',')[i].Split('!')[3] != "0") { try/*jpeg version*/{ format_bild = body.Split(',')[i].Split('!')[3].Split('|')[5]; format_x = body.Split(',')[i].Split('!')[3].Split('|')[1]; format_x2 = body.Split(',')[i].Split('!')[3].Split('|')[3]; format_y = body.Split(',')[i].Split('!')[3].Split('|')[0]; format_y2 = body.Split(',')[i].Split('!')[3].Split('|')[2]; fehler_bericht += "8a. jpeg n\n"; } catch/*html version*/{ format_bild = body.Split(',')[i].Split('!')[3]; fehler_bericht += "8a. hrml n\n"; } }
                    string produkt_nuummmer = body.Split(',')[i].Split('!')[2].Split('|')[6];
                    // lade zutat string
                    fehler_bericht += "\n\n\n\n8b. lade zutat:\n"; string zutat_text = ""; try { string zutat_tabelle = body.Split(',')[i].Split('!')[7]; for (int i2 = 0; i2 < zutat_tabelle.Split('~').Length - 1; i2++) { if (zutat_tabelle.Split('~')[i2].Split('|')[4] == "3") { zutat_text += sp_mit; } if (int.Parse(zutat_tabelle.Split('~')[i2].Split('|')[5]) >= 2) { zutat_text += zutat_tabelle.Split('~')[i2].Split('|')[5]; zutat_text += " x "; } if (zutat_tabelle.Split('~')[i2].Split('|')[5] == "0") { zutat_text += sp_ohne; } zutat_text += zutat_tabelle.Split('~')[i2].Split('|')[0]; zutat_text += ", "; } fehler_bericht += "8b. lade zutat ok: \n\n"; }
                    catch { fehler_bericht += "X8b. lade zutat Error \n\n"; }
                    //antwort += "<table width='100%'><tr><td height='2px'  width='100%' bgcolor='#000000'></td></tr></table>";
                      antwort += "<table width='100%'><tr><td height='4px'  width='100%' bgcolor='#000000'></td></tr></table>";

                    antwort += "<table width='100%' border='0'>";
                    antwort += "";
                    string andaze = produkt_bild_groesse.Replace('.', ','); decimal breite = 999; string tdzahl = "5";
                    if (rh_vorwahl == "98")
                    {
                        /*Orginal*/
                        antwort += "<tr><td align='left' width='16px'><span><font size='5px'>" + orginal_test + " </font></span></td></tr>";
                        /*nummer*/
                        antwort += "<tr><td align='center'  colspan='2'><span><font size='" + page_Font + "px'>" + produkt_nuummmer + " </font></span></td><tr>";
                        
                        /*name*/
                        antwort += "<tr><td align='center' colspan='2'><span><font size='" + page_Font + "px'>" + produkt_bild + "</font></span> </td>";
                        if (body.Split(',')[i].Split('!')[3] != "0") { antwort += "<td  align='right'><span><font size='" + page_Font + "px'> " + format_bild + " </font></span></nobr></td>"; tdzahl = "6"; }
                        antwort += "</tr>";
                        
                        /*preis*/
                        antwort += "<tr><td nowrap align='right'><nobr><font size='" + page_Font + "px'>" + sp_waehrung + " </font></td>";
                        antwort += "<td align='left'><font size='" + page_Font + "px'> " + betrag_format(preis_des_produkts) + "</font></td><tr>";
                        /*format td*/
                        
                        
                    }
                    else
                    {
                        /*Orginal*/
                        antwort += "<tr><td  align='left' width='16px'><span style='font-family:Arial;'><font size='" + Zutat_Font + "'>" + orginal_test + "</font></span></td>";
                        /*nummer*/
                        antwort += "<td  align='left'><nobr><span style='font-family:Arial;'><font size='" + page_Font + "'><b>" + produkt_nuummmer + " </b></font></span></nobr></td>";
                        /*name*/
                        antwort += "<td  align='left'><nobr><span style='font-family:Arial;'><font size='" + page_Font + "'><b>" + produkt_bild + " </td>";
                        /*format td*/
                        if (body.Split(',')[i].Split('!')[3] != "0") { antwort += "<td> " + format_bild + " </b></font></span></nobr></td>"; tdzahl = "6"; }
                        /*preis*/
                        antwort += "<td   nowrap align='right'><nobr><span style='font-family:Arial;'><font size='" + page_Font + "'><b>" + betrag_format(preis_des_produkts) + "</td><td><font size='" + page_Font + "'><b> " + sp_waehrung + "</b></font></span></nobr></td>";
                    }
                    antwort += "</tr>";

                    privat_fax_laenge_html_umw += privat_fax_laenge_von_div_bild2; privat_fax_laenge_von_div_bild2 = 0; fehler_bericht += "9: Html_umwandler() Bilder Information==  @@td_ breite.ToString()" + breite.ToString() + "@@Produkt_bild: " + produkt_bild + "@@position_x: " + position_x + "@@position_y: " + position_y + "@@position_x2: " + position_x2 + "@@position_y2: " + position_y2 + "@@produkt_billd_groesse: " + produkt_bild_groesse + "@@i: " + i + "\n";

                    string menu_selected = body.Split(',')[i].Split('!')[12];
                    if (pizzaria_bemerkung != "0" && menu_selected == "")
                    {
                        antwort += "<tr>"; antwort += "<td  align='" + align + "' colspan='" + tdzahl + "'><span><font size='" + Zutat_Font + "'>" + pizzaria_bemerkung + " </font></span></td></tr>";
                        privat_fax_laenge_html_umw += 35;
                    }
                    //zutaten
                    if (zutat_text != "")
                    {
                        antwort += "<tr>"; 
                        antwort += "<td  align='" + align + "' colspan='" + tdzahl + "'><span><font size='" + Zutat_Font + "'><b>" + zutat_text + " </b></font></span></td></tr>"; 
                        privat_fax_laenge_html_umw += 35;
                    }
                    //menu

                    string menu_oder_speise = body.Split(',')[i].Split('!')[12];
                    if (menu_selected != "")
                    {
                        string menu_tabelle = body.Split(',')[i].Split('!')[12];
                        string menu_coordinaten = "";
                        string menue_text = "";
                        for (int i2 = 0; i2 < menu_selected.Split('~').Length - 1; i2++)
                        {
                            if (menu_selected.Split('~')[i2].Split('|')[2] != "0")
                            {
                                antwort += "<tr>";
                                menu_coordinaten = menu_selected.Split('~')[i2].Split('^')[1]; format_bild = menu_coordinaten.Split('|')[5]; format_x = menu_coordinaten.Split('|')[1]; format_x2 = menu_coordinaten.Split('|')[3]; format_y = menu_coordinaten.Split('|')[0]; format_y2 = menu_coordinaten.Split('|')[2];
                                // menu Bild
                                antwort += "<td ></td ><td  align='" + align + "'  colspan='" + tdzahl + "'><nobr><span style='font-family:Arial;'><font size='" + page_Font + "'><b>" + div_bild2(format_bild, format_x, format_y, format_x2, format_y2, produkt_bild_groesse, i, 1) + "</b></font></span></nobr></td>";
                                antwort += "</tr>";
                                privat_fax_laenge_html_umw += privat_fax_laenge_von_div_bild2;
                                privat_fax_laenge_von_div_bild2 = 0;
                                //zutat
                                string zutat_tabelle_menu = menu_selected.Split('~')[i2].Split('^')[3];
                                string zutat_text_menu = "";
                                for (int i4 = 0; i4 < zutat_tabelle_menu.Split('$').Length - 1; i4++){if (zutat_tabelle_menu.Split('$')[i4].Split('|')[4] == "3"){zutat_text_menu += sp_mit;}if (int.Parse(zutat_tabelle_menu.Split('$')[i4].Split('|')[5]) >= 2){zutat_text_menu += zutat_tabelle_menu.Split('$')[i4].Split('|')[5];zutat_text_menu += " x ";}if (zutat_tabelle_menu.Split('$')[i4].Split('|')[5] == "0"){zutat_text_menu += sp_ohne;}zutat_text_menu += zutat_tabelle_menu.Split('$')[i4].Split('|')[0];zutat_text_menu += ", ";}
                                //end for zutat
                                if (zutat_text_menu != "")
                                {
                                    antwort += "<tr>";
                                    antwort += "<td ></td ><td  align='"+align+"' colspan='" + 3 + "'><span style='font-family:Arial;'><font size='" + Zutat_Font + "'>" + zutat_text_menu + " </font></span></td>";
                                    antwort += "</tr>";
                                    privat_fax_laenge_html_umw += 35;
                                }
                            }//end if
                        }//enf for sp_i_m
                    }//end if
                    //bemerkung
                    if (bemerkung_des_produktes != "11_bemerkung")
                    {//ohne bemerkung kein tr
                        antwort += "<tr>";
                        antwort += "<td  align='center' colspan='3'><font size='" + Zutat_Font + "'>" + bemerkung_des_produktes + "</font></td>";
                        antwort += "</tr>";
                        privat_fax_laenge_html_umw += 35;
                    }
                    antwort += "</table>";
                    fehler_bericht += " 10:  Html_umwandler()     produkt " + i + "erfolgreich addiert \n\n";

                }//end try
                catch { fehler_bericht += "X10: Html_umwandler() Error bei produkt produkt" + i + "mit Innerhalt:" + body.Split(',')[i] + " \n\n"; }
            }//end for

        }
        catch { fehler_bericht += "\n\n GESAMT ALARM:  Html_umwandler() bestellung for nicht beendet bestellung abgestuerzt \n\n\n\n"; fehler_bericht += "XXXX:  Html_umwandler() bestellung for nicht beendet bestellung abgestuerzt \n\n"; }

        antwort += "<table width='100%'><tr><td height='2px'  width='100%' bgcolor='#000000'></td></tr></table>";
        ///////////////////////produkte
        //string einbild = "";

        //fahrtkosten
        antwort += "<table width='100%' border='0'><tr>";
        if (rh_vorwahl == "98")//
        {
            antwort += "<td align='center' colspan='2'><nobr><font size='" + Zutat_Font + "'>" + sp_fahrtkosten + "</font></nobr></td>";
            antwort += "</tr>";

            //antwort += "<tr><td align='right'><font size='" + Zutat_Font + "px'> " + sp_waehrung + "</font></td>";
            antwort += "<tr><td nowrap align='right'><nobr><font size='" + page_Font + "px'>" + sp_waehrung + " </font></nobr></td>";
            //antwort += "<td align='left'><font size='" + Zutat_Font + "px'>" + betrag_format(fahrtkosten.ToString()) + "</font></td>";
            string tettt = betrag_format(fahrtkosten.ToString());
            antwort += "<td align='left' width='50%'><font size='" + page_Font + "px'>" + tettt + "</font></td>";
        }
        else
        {
            antwort += "<td align='left'><span style='font-family:Arial;'><font size='" + Zutat_Font + "'>" + sp_fahrtkosten + "</font></span></td>";
            antwort += "<td align='right'>";
            antwort += "<span style='font-family:Arial;'><font size='" + Zutat_Font + "'>" + " " + betrag_format(fahrtkosten.ToString()) + " " + sp_waehrung + "</font></span><br>";
            antwort += "</td>";
        }
        antwort += "</tr></table>";
        //gesamt_betrag page_Font
        
        gesamt_betrag = gesamt_betrag + int.Parse(fahrtkosten);
        if (rh_vorwahl == "98")
        {
            antwort += "<table width='100%' >"; antwort += "<tr>";
            antwort += "<td align='left' width='70px'><font size='" + page_Font + "'>" + sp_waehrung + "</font></td>";
            antwort += "<td align='left'><font size='" + page_Font + "'>" + " " + betrag_format(gesamt_betrag.ToString()) + "</font></td>";
            antwort += "</tr></table>";
        }
        else
        {
            antwort += "<table width='100%' >"; antwort += "<tr><td align='right'>"; antwort += "<span style='font-family:Arial;'><b><u><font size='" + page_Font + "'>" + " " + betrag_format(gesamt_betrag.ToString()) + " " + sp_waehrung + "</font></u></b></span><br>"; 
            antwort += "</td></tr>"; antwort += "</table>";
        }
        fax_laenge += 37;
        antwort += "</td></tr>";
        antwort += "</table>";
       
        fax_laenge += 37;
        antwort += "</td></tr>";
        antwort += "</table>";
        diagnose = "bestellung konnte nicht weiter geleitet werden \n";


        if (fuss_zeile != "1")
        {
            antwort += "<table><tr><td><div><span style='font-family:Arial;'><font size='" + page_Font + "'>" + fuss_zeile + "</font></span></div></td></tr></table>";
            fax_laenge += 80;
        }
        privat_fax_laenge_fuer_Html_string_umwandler = fax_laenge;
        antwort += "";
        return antwort;
    }
    public string Gmail_send(string emfpaenger1, string betriff, string Html_boyd, int fax_laenge)
    {
        MailMessage message = new MailMessage();
        SmtpClient smtp2 = new SmtpClient();
        message.From = new MailAddress("mastoreh2@gmail.com");
        message.To.Add(new MailAddress(emfpaenger1));
        message.Subject = betriff;
        /**/
        string myString = "";
        StreamReader reader = new StreamReader(Server.MapPath("~/HTMLPage.htm"));
        string readFile = reader.ReadToEnd();
        myString = readFile;
        myString = myString.Replace("$$Body$$", Html_boyd);


        message.Body = myString.ToString();
        //message.Body = "Die Meldung lautet: ";
        // creat foto //string url_jpg = string.Format("http://{0}", "localhost:12241/exit/HTMLPage.htm");if (jpg_aktiv == "1"){try{int width = 1000; int height = fax_laenge;Thumbnail thumbnail = new Thumbnail(url_jpg, width, height, width, height, Html_boyd);System.Drawing.Image image = thumbnail.GenerateThumbnail();MemoryStream memStream = new MemoryStream(); image.Save(memStream, ImageFormat.Jpeg);memStream.Position = 0; Attachment attach = new Attachment(memStream, "bestellung.jpg");message.Attachments.Add(attach); fehler_bericht += "7004: Gmail__send() jpg wurde erfolgreich addiert \n\n";}catch { fehler_bericht += "X 7004:  Gmail__send() jpg kann nicht erzeugt werden \n\n"; }}
        smtp2.Port = 587;
        smtp2.Host = "smtp.gmail.com";
        smtp2.EnableSsl = true;
        message.IsBodyHtml = true;
        smtp2.UseDefaultCredentials = false;
        //smtp2.Credentials = new NetworkCredential("faxitwey@gmail.com", "rdhydv64s");//Gmail is having authentication problems. Some features may not work. Try  logging in  to fix the problem.
        smtp2.Credentials = new NetworkCredential("mastoreh2@gmail.com", "sakdbt74");
        smtp2.DeliveryMethod = SmtpDeliveryMethod.Network; string report = "";
        try { smtp2.Send(message); }
        catch { report += "\n XXX 130 Gmail_send: absender mastoreh2@gmail.com hat nicht geschaft zu senden an (" + emfpaenger1 + ") \n"; } return report;
    }

    public string betrag_format(string speise_preis)
    {
        string preis_mit_koma = "";
        if (vorwahl != 98)
        {
            speise_preis = string.Format("{0:#.00}", Convert.ToDecimal(speise_preis) / 100);
            return speise_preis;
        }
        else { return speise_preis; }
    }
    public string betrag_format_alt(string speise_preis)
    {
        string preis_mit_koma = "";
        for (int i2 = 0; i2 < speise_preis.Length; i2++)
        {
            //age 2 ya 1 sefre ye sefre dige behesh ezafe kone
            if (speise_preis.Length == 1)
                speise_preis = "00" + speise_preis;
            if (speise_preis.Length == 2)
                speise_preis = "0" + speise_preis;
            if (i2 == speise_preis.Length - 2)
                preis_mit_koma += ",";
            preis_mit_koma += speise_preis[i2];
        }
        return preis_mit_koma;
    }
    int privat_fax_laenge_von_fax_l_logo = 0;
    public string fax_logo(string body, string mini1, string rh_mini_Zelle_logo, string rh_retaurant_id, string rh_pic_link)
    {
        //mini1 = mini1.Replace('.', ','); 
        decimal mini = decimal.Parse(mini1);
        body = "<table width='90%'  align='center'>";
        body += "<tr align='center'>";
        body += "<th align='center'>";

        //body += "<img src=" + rh_pic_link + "/karte/" + rh_restaurant_name + "/mlogo.png height='" + (100 * mini) + "'>";
        body += "<img src=" + rh_pic_link + "/album_privat/&" + rh_retaurant_id + ".png height='" + (100 * mini) + "'>";

        body += "</th>";

        body += "</tr>";
        body += "</table>";
        return body;
    }
    int privat_fax_laenge_von_div_bild2 = 0;
    public string div_bild2(string bild, string x1, string y1, string x2, string y2, string mini, int i, int f_oder_s)
    {
        mini = mini.Replace('.', ',');
        try
        {
            int.Parse(bild);
            decimal logo_breit = decimal.Parse(x2) - decimal.Parse(x1); decimal reale_breite = Math.Round((logo_breit * decimal.Parse(mini)), 0); decimal logo_hoehe = decimal.Parse(y2) - decimal.Parse(y1); decimal reale_hoehe = Math.Round((logo_hoehe * decimal.Parse(mini)), 0);
            if (f_oder_s == 1) privat_fax_laenge_von_div_bild2 += Convert.ToInt32(reale_hoehe) + 12;
            string body = "<img src=http://yousystem2000.de/gtocrop.aspx?id=" + bild + "&w=" + logo_breit +/*cheghadr az akse orginal gheychi kokne*/"&h=" + logo_hoehe +/*cheghadr az akse orginal gheychi kokne*/"&x=" + x1 +/*koja ax axe orginal shuru kone*/"&y=" + y1 +/*koja ax axe orginal shuru kone*/"&oh=" + reale_hoehe +/*axo chetori press kone ya keshesh bede*/"&ow=" + reale_breite + " height='" + reale_hoehe + "' width='" + reale_breite + "'>";

            return body;
        }
        catch
        {
            //alert("html");
            return bild;
        }
    }




    public void sende_fehler_bericht(string email, string code, string betriff)
    {
        //string diagnose;

        MailMessage message_bericht = new MailMessage();
        SmtpClient smtp2 = new SmtpClient();
        message_bericht.From = new MailAddress("mastoreh2@gmail.com");//mastoreh2@gmail.com

        //email
        message_bericht.To.Add(new MailAddress(email));
        message_bericht.Subject = betriff;
        message_bericht.Body = "Die Meldung lautet: " + code;
        smtp2.Port = 587;
        smtp2.Host = "smtp.gmail.com";
        smtp2.EnableSsl = true;
        smtp2.UseDefaultCredentials = false;
        smtp2.Credentials = new NetworkCredential("mastoreh2@gmail.com", "sakdbt74");
        smtp2.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp2.Send(message_bericht);/**/
    }
    static string sp_bestellungsnummer = "";
    static string sp_datum = "";
    static string sp_empfaenger = "";
    static string sp_tel = "";
    static string sp_anschrift = "";
    static string sp_bemerkung = "";
    static string sp_fahrtkosten = "";
    static string sp_heute = "";
    static string sp_morgen = "";
    static string sp_Lieferung = "";
    static string sp_sehr_geerte_d_u_h = "";
    static string sp_ihre_bestellung_wurde_bestaetigt_usw = "";
    static string sp_minuten = "";
    static string sp_bei_ihnen_eintreffen = "";
    static string sp_vielen_dank = "";
    static string sp_bestaeting_ihrer_bestellung = "";
    static string sp_ablehnung = "";//
    static string sp_ablehnung_betreff = "";//sp_ablehnung_betreff
    static string sp_ohne = "";
    static string sp_mit = "";
    static string sp_waehrung = "";

    private void sprache(int vorwahl)
    {

        if (vorwahl == 49)
        {
            sp_bestellungsnummer = "Bestellungsnummer: "; sp_datum = "Datum: "; sp_empfaenger = "Emfpänger: "; sp_tel = "Tel: "; sp_anschrift = "Anschrift: "; sp_bemerkung = "Bemerkung: "; sp_fahrtkosten = "Fahrtkosten: "; sp_heute = "Heute: "; sp_morgen = "Morgen: "; sp_Lieferung = "Lieferung in "; sp_minuten = " Minuten"; sp_sehr_geerte_d_u_h = "Sehr geehrte Damen und Herrn,"; sp_ihre_bestellung_wurde_bestaetigt_usw = "Ihre Bestellung wurde eben bestätigt und wird in etwa "; sp_bei_ihnen_eintreffen = " bei Ihnen eintreffen."; sp_vielen_dank = "Vielen Dank."; sp_bestaeting_ihrer_bestellung = "Bestätigung Ihrer Bestellung"; sp_ablehnung = "Wir bedauern diese Bestellung nicht liefern zu konnen.";
            sp_ablehnung_betreff = "Ablehnung";
            sp_waehrung = "€";
        }
        if (vorwahl == 98)
        {
            sp_bestellungsnummer = "شماره سفارش: "; sp_datum = "تاریخ: "; sp_empfaenger = ": نام"; sp_tel = ": تلفن"; sp_anschrift = ": نشانی"; sp_bemerkung = ": شرح نشانی"; sp_fahrtkosten = ": هزینه ارسال"; sp_heute = ": "; sp_morgen = ": "; sp_Lieferung = "مدت زمان ارسال "; sp_minuten = " دقیقه"; sp_sehr_geerte_d_u_h = "کاربر گرامی"; sp_ihre_bestellung_wurde_bestaetigt_usw = "سفارش شما دریافت شد و تا "; sp_bei_ihnen_eintreffen = " ارسال خواهد گردید"; sp_vielen_dank = "با تشکر"; sp_bestaeting_ihrer_bestellung = "تایید سفارش"; sp_ablehnung = "در حال حاضر پذیرش مقدور نمی باشد";
            sp_ablehnung_betreff = "پذیرش مقدور نیست";
            sp_waehrung = "تومان";
        }
        if (vorwahl == 39)
        {
            sp_bestellungsnummer = "numero di ordine: "; sp_datum = "data: "; sp_empfaenger = "nome: "; sp_tel = "tel: "; sp_anschrift = "indirizzo: "; sp_bemerkung = "note: "; sp_fahrtkosten = "addebbitati per il transporto: "; sp_heute = "oggi: "; sp_morgen = "domani: "; sp_Lieferung = "arrive tra "; sp_minuten = " minuti"; sp_sehr_geerte_d_u_h = "Gentile Cliente,"; sp_ihre_bestellung_wurde_bestaetigt_usw = "La informiamo che l`ordinazione è stata eseguita, saremmo da` voi entro: "; sp_bei_ihnen_eintreffen = ""; sp_vielen_dank = "Grazie per l`ordinazione."; sp_bestaeting_ihrer_bestellung = "Il Suo Ordine"; sp_ablehnung = "siamo spiacenti di informarLa che che i ordinatione nn po stere accetata.";
            sp_ablehnung_betreff = "Ablehnung";
            sp_waehrung = "€";
        }
        if (vorwahl == 31)
        {
            sp_bestellungsnummer = "Ordernummer: ";
            sp_datum = "Datum:";
            sp_empfaenger = "Naam: ";
            sp_tel = "Telefoonnummer: ";
            sp_anschrift = "Adres: ";
            sp_bemerkung = "Opmerkingen: ";
            sp_fahrtkosten = "Verzendkosten: ";
            sp_heute = "Vandaag: ";
            sp_morgen = "Morgen: ";
            sp_Lieferung = "bei Kunden in ";
            sp_minuten = " Minuten";
            sp_sehr_geerte_d_u_h = "Geachte De heer / Mevrouw,";
            sp_ihre_bestellung_wurde_bestaetigt_usw = "Uw bestelling is bevestigd en verwerk. ";
            sp_bei_ihnen_eintreffen = " Bij u bezorgd.";
            sp_vielen_dank = "Bedankt voor uw bestelling bij ons!";
            sp_bestaeting_ihrer_bestellung = "bevestiging van uw bestelling";
            sp_ablehnung = "Wir bedauern diese Bestellung nicht liefern zu konnen.";
            sp_ablehnung_betreff = "Ablehnung";
            sp_waehrung = "€";
        }
        if (vorwahl == 1)
        {
            sp_bestellungsnummer = "Bestellungsnummer: ";
            sp_datum = "Datum: ";
            sp_empfaenger = "Emfpänger: ";
            sp_tel = "Tel: ";
            sp_anschrift = "Anschrift: ";
            sp_bemerkung = "Bemerkung: ";//Note
            sp_fahrtkosten = "Fahrtkosten: ";
            sp_heute = "Heute: ";
            sp_morgen = "Morgen: ";
            sp_Lieferung = "Lieferung in ";
            sp_minuten = " Minuten";
            sp_sehr_geerte_d_u_h = "Sehr geehrte Damen und Herrn,";
            sp_ihre_bestellung_wurde_bestaetigt_usw = "Ihre Bestellung wurde eben bestätigt und wird in etwa ";
            sp_bei_ihnen_eintreffen = " bei Ihnen eintreffen.";
            sp_vielen_dank = "Vielen Dank.";
            sp_bestaeting_ihrer_bestellung = "Bestätigung Ihrer Bestellung";
            sp_ablehnung = "Wir bedauern diese Bestellung nicht liefern zu konnen.";
            sp_ablehnung_betreff = "Ablehnung";
            sp_waehrung = "$";
        }

    }
    public string div_bild2_alt(string bild, string x1, string y1, string x2, string y2, string mini, int i, int f_oder_s)
    {
        mini = mini.Replace('.', ',');
        //mini = "0.5";// mini.Replace('.', ',');
        decimal logo_breit = decimal.Parse(x2) - decimal.Parse(x1);
        decimal reale_breite = Math.Round((logo_breit * decimal.Parse(mini)), 0);
        decimal logo_hoehe = decimal.Parse(y2) - decimal.Parse(y1);
        decimal reale_hoehe = Math.Round((logo_hoehe * decimal.Parse(mini)), 0);
        if (f_oder_s == 1)
            privat_fax_laenge_von_div_bild2 += Convert.ToInt32(reale_hoehe) + 12;

        string body = "<img src=http://yousystem2000.de/gtocrop.aspx?id=" + bild +
                                                "&w=" + logo_breit +//cheghadr az akse orginal gheychi kokne
                                                "&h=" + logo_hoehe +//cheghadr az akse orginal gheychi kokne
                                                "&x=" + x1 +//koja ax axe orginal shuru kone
                                                "&y=" + y1 +//koja ax axe orginal shuru kone
                                                "&oh=" + reale_hoehe +//axo chetori press kone ya keshesh bede
                                                "&ow=" + reale_breite +
                                                " height='" + reale_hoehe + "' width='" + reale_breite + "'>";//

        return body;
    }
    public string fax_logo_alt(string body, string mini1)
    {
        mini1 = mini1.Replace('.', ',');
        decimal mini = decimal.Parse(mini1);
        decimal logo_breit = decimal.Parse(mini_Zelle_logo.Split('!')[0].Split('|')[3]) - decimal.Parse(mini_Zelle_logo.Split('!')[0].Split('|')[1]);
        decimal reale_breite = Math.Round((logo_breit * mini), 0);
        decimal logo_hoehe = decimal.Parse(mini_Zelle_logo.Split('!')[0].Split('|')[2]) - decimal.Parse(mini_Zelle_logo.Split('!')[0].Split('|')[0]);
        decimal reale_hoehe = Math.Round((logo_hoehe * mini), 0);
        privat_fax_laenge_von_fax_l_logo += Convert.ToInt32(reale_hoehe);
        string logo_x = mini_Zelle_logo.Split('!')[0].Split('|')[1];
        string logo_y = mini_Zelle_logo.Split('!')[0].Split('|')[0];
        string logo_Bild = mini_Zelle_logo.Split('!')[0].Split('|')[5];
        body = "<table width='100%'  align='center'>";
        body += "<tr align='center'>";
        body += "<th align='center'>";
        body += "<img src=http://yousystem2000.de/gtocrop.aspx?id=" + logo_Bild +
                                                "&w=" + logo_breit +//cheghadr az akse orginal gheychi kokne
                                                "&h=" + logo_hoehe +//cheghadr az akse orginal gheychi kokne
                                                "&x=" + logo_x +//koja ax axe orginal shuru kone
                                                "&y=" + logo_y +//koja ax axe orginal shuru kone
                                                "&oh=" + reale_hoehe +//axo chetori press kone ya keshesh bede
                                                "&ow=" + reale_breite +
                                                " height='" + reale_hoehe + "' width='" + reale_breite + "'>";
        /*
        body += "<div  style='width:" + reale_breite.ToString() + "px;height:" + reale_hoehe.ToString() + "px;" +
                            //"background-image:url(http://yousystem2000.de/gtocrop.aspx?id=" + logo_Bild +
                            "background-image:url(http://vulkan-giessen.de/gtocrop.aspx?id=" + logo_Bild +
                                                "&w=" + logo_breit +
                                                "&h=" + logo_hoehe +
                                                "&x=" + logo_x +
                                                "&y=" + logo_y +
                                                "&oh=" + reale_hoehe +
                                                "&ow=" + reale_breite + ");" +

                            "';></div>";
        */
        body += "</th>";

        body += "</tr>";
        body += "</table>";
        return body;
    }
}
