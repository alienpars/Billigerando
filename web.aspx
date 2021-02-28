
<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="web.aspx.cs" Inherits="Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
     
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="https://www.paypalobjects.com/api/checkout.js"></script>
<script type="text/javascript" >
    urll = window.location;
     if( /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) 
        {
               var jko=urll+"";
               document.location= "mob/?"+jko.split('?')[1];
        }
</script>
<style type="text/css">
 
 .fix { position:fixed; z-index:2;}
 .fix2 { position:fixed; z-index:3;}
 .ui-effects-transfer {  /* style the transfer element */border: black 3px solid;z-index:100;}
 .map{  /* style the transfer element */z-index:1;border-radius: 5px;}
 .ui-autocomplete {max-height: 350px;overflow-y: auto;/* prevent horizontal scrollbar*/ overflow-x: hidden;/* add padding to account for vertical scrollbar */padding-right: 20px;}
 .rand{  /* style the transfer element */border-radius: 5px; border: black 1px solid;z-index:10;margin-bottom:1%;} 
 .rand:hover{  /* style the transfer element */border-radius: 5px; border: red 2px solid;z-index:10;margin-bottom:1%;} 
#C352_html_body_div {
    z-index:1;
}
#C352_table1_in_foto {
    margin:0 auto;
    Width:50%;
    z-index:1;
}
</style>
    <!--<script src="js/jquery.min.js" type="text/javascript";></script>-->
	<!--ohne js/jquery-ui-1.10.3.custom.js transfer geht nocht mehr mouseover animation geht auch nicht mehr-->
	<!--<script src="js/jquery-ui-1.10.3.custom.js" type="text/javascript";></script>-->
    
    
    <!--<link rel="stylesheet" href="/resources/demos/style.css">-->
    
    <!-- bringt grafik durcheinander
    <link rel="stylesheet" href="css/main.css" type="text/css"/>
	<script type="text/javascript" src="js/jquery.infobox.js"></script><link rel="stylesheet" type="text/css" href="css/infobox_plugin.css" />
    -->
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="fsw/css/web_ninja_efekt.css"/>
	    <!--  start new    -->
    <link href="css_gin/bootstrap.css" rel='stylesheet' type='text/css' />
    <link href="css_gin/style.css" rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Raleway:100,200,300,400,500,600,700,800,900' rel='stylesheet' type='text/css'>
    
</head>
<body id="mybody" runat="server" >
<!-- start facebook-->
    <div id="fb-root"></div>

    <!-- ende facebook-->
      <form id="form1" runat="server" style="">
            <div class="container"> 

            </div>
		<div id="pointer" >
    </form>
	<script  type="text/javascript" src="fsw/js/jquery-1.12.4.js" ></script>
	<script  type="text/javascript" src="fsw/js/ui1.12.1jquery-ui.js" ></script>
    


	<script type="text/javascript" src="fsw/js/jquery.cycle.all.min.js" ></script>
	<script type="text/javascript" src="fsw/js/jquery.dualsystem.js" ></script>
	<script type="text/javascript" src="fsw/js/ds_ldn.js" ></script>
	<script type="text/javascript" src="fsw/js/ds_dg.js" ></script>
	<script type="text/javascript" src="fsw/js/ds_calc.js" ></script>
	<script type="text/javascript" src="fsw/js/ds_kche.js" ></script>

    <script src="fsw/js/jquery.countdown.js"></script>
	<script type="text/javascript" src="fsw/js/w.eWagen.js" ></script>
	<script type="text/javascript" src="fsw/js/w.kche.js" ></script>
    <script   type="text/javascript" src="fsw/js/w.logt.js"></script>
    <script   type="text/javascript" src="fsw/js/w.elmts.js"></script>
    <script   type="text/javascript" src="fsw/js/w.menu.js"></script>
    <script src="fsw/js/jquery.cookie.js"></script>

	<link rel="shortcut icon" id="Link1" type="image/png" />

    <!-- archive
	    <script src="https://code.jquery.com/jquery-1.12.4.js" type="text/javascript";></script>
	    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    -->

</body>
</html>




