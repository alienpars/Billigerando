
<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="paypal.aspx.cs" Inherits="Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
     
<head id="Head1" runat="server">

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="https://www.paypalobjects.com/api/checkout.js"></script>
	<!-- 
    <img src="https://www.paypalobjects.com/webstatic/en_US/i/buttons/PP_logo_h_100x26.png" alt="PayPal Logo">
        -->

</head>


<body id="mybody" runat="server" >
    <style>
    
    /* Media query for mobile viewport */
    @media screen and (max-width: 400px) {
        #paypal-button-container {
            width: 100%;
        }
    }
    
    /* Media query for desktop viewport */
    @media screen and (min-width: 400px) {
        #paypal-button-container {
            width: 250px;
            display: inline-block;
        }
    }
    
</style>
    <div id="paypal-button-container"></div>
    <form id="form1" runat="server" style="">
    </form>
    <script>
        //alert($("#test").text());



        var wert = document.getElementById('neu_aj_p').innerHTML;
        paypal.Button.render({
            env: 'production', // sandbox | production
            // PayPal Client IDs - replace with your own
            // Create a PayPal app: https://developer.paypal.com/developer/applications/create
            client: {
                sandbox: 'AR1mpHAuhB-6tVlFopCttV3Jvft7nuUteDUyvk7FjwXhcAToNBCs03gzLVq0ndLcVpOZPK7TFuUg2UXA',
                production: 'AV4gQSDFjNqCAI9fIY4NaO8wXUY4V85DGh_z9vaTb43-GdkjCc7GULo93pzh3yZn4Z_h-qXzllXb9a5d'
            },
            style: {
                label: 'generic',  // checkout | credit | pay | buynow | generic
                size: 'responsive', // small | medium | large | responsive
                shape: 'rect',   // pill | rect
                color: 'blue'   // gold | blue | silver | black
            },
            // Show the buyer a 'Pay Now' button in the checkout flow
            commit: true,

            // payment() is called when the button is clicked
            payment: function (data, actions) {

                // Make a call to the REST api to create the payment
                return actions.payment.create({
                    payment: {
                        transactions: [
                            {
                                amount: { total: wert, currency: 'EUR' }
                            }
                        ]
                    }
                });
            },

            // onAuthorize() is called when the buyer approves the payment
            onAuthorize: function (data, actions) {

                // Make a call to the REST api to execute the payment
                return actions.payment.execute().then(function () {
                    var produkt_id_b=localStorage.getItem("produkt_id_b");
                    var name = localStorage.getItem("name");
                    var strasse=localStorage.getItem("strasse");
                    var nr =localStorage.getItem("nr");
                    var plz=localStorage.getItem("plz");
                    var stadt=localStorage.getItem("stadt");
                    var bemer=localStorage.getItem("bemer");
                    var id=localStorage.getItem("id");
                    var parallel_welt=localStorage.getItem("parallel_welt");
                    var fahrtkosten=localStorage.getItem("fahrtkosten");
                    var kunden_mail=localStorage.getItem("kunden_mail");
                    var mit_oder_ohne_email_confirm=localStorage.getItem("mit_oder_ohne_email_confirm");
                    var kunden_tel=localStorage.getItem("kunden_tel");
                    var packet_mail_adressen=localStorage.getItem("packet_mail_adressen");
                    var fax_daten=localStorage.getItem("fax_daten");
                    var kunden_id=localStorage.getItem("kunden_id");
                    var vorwahl=localStorage.getItem("vorwahl");
                    var rabatt_summe=localStorage.getItem("rabatt_summe");
                    var rh_jpg_aktiv=localStorage.getItem("rh_jpg_aktiv");
                    var restaurant_name=localStorage.getItem("restaurant_name");
                    var pic_link=localStorage.getItem("pic_link");
                    var retaurant_id=localStorage.getItem("retaurant_id");
                    var pc_mobile=localStorage.getItem("pc_mobile");
                    var open_it=localStorage.getItem("open_it");
                    var rh_link=localStorage.getItem("rh_link");
                    var rh_ip_user=localStorage.getItem("rh_ip_user");

                    var ruckmeldung = Default.DS_sendMail(produkt_id_b + '', name + '', strasse + '', nr + '', plz + '', stadt + '', bemer + '', id + '', 'pwort', parallel_welt + '', fahrtkosten + '', kunden_mail + '',
                        mit_oder_ohne_email_confirm + '', '', kunden_tel + '', packet_mail_adressen + '', fax_daten + '', 'reserve27', kunden_id, vorwahl + '',
                        rabatt_summe + '', rh_jpg_aktiv + '', restaurant_name + '', pic_link, retaurant_id + '', pc_mobile + '', open_it + '', rh_link + '', rh_ip_user + '', 'paypal.aspx').value;
                    //this.remove();
                    window.parent.location.reload();

                    setTimeout(function () {
                        //C# zeit check negativ
                        if (ruckmeldung.split(" ")[0] == "Onlineverkauf") {
                            if (show_it == 1) med = 'js-DS-2452 ';
                            alert(med);
                        }
                        //C# fehler
                        if (ruckmeldung == null) {
                            if (show_it == 1) med = '121 '; ruckmeldung = med + "verbindung_aufbau_nicht_moeglich";

                            alert(ruckmeldung);
                            $('body').removeClass('ui-loading');
                        }
                        //gesendet
                        if (ruckmeldung == "gesendet") {
                            produkt_id_b = '';
                            anzahl_produkte_in_korb = 0;
                            alert("Ihre Bestellung wurde gesendet. Sie bekommen eine Bestätigung als E-Mail.");
                            $('body').removeClass('ui-loading');
                            $('#js_738').remove();
                        }
                        //keine Verbindung
                        if (ruckmeldung == '14') {
                            if (show_it == 1) med = '2148 '; ruckmeldung = med + "verbindung_aufbau_nicht_moeglich";
                            $('body').removeClass('ui-loading');
                            alert(ruckmeldung);
                            $('#js_738').remove();
                        }
                        //window.parent.location.reload();
                        //window.top.location.reload();

                    }, 500);//end time out
                    //window.alert(ruckmeldung);
                });
            }

        }, '#paypal-button-container');

    </script>
</body>

</html>

