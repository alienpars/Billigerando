/*
# Infobox 0.3
# Author: keepMinecraft, HTMLworld
# CC-BY 2013 by fricke webdesign / www.tok85-dev.blogspot.de
# Feedback: frickewebdesign@yahoo.de / blueplant@medionmail.com
# Web: www.htmlworldblog.de
*/
jQuery.fn.infobox = function(box, text, speed) {
	this.each(function(){
	
	if(!box) {box = "#infobox";}
	if(!speed) {speed = 300;}
	
	jQuery(this).mouseover(function (){
		jQuery(box).fadeIn(speed);
		if(text) {$(box).html(text);}
	});
	
	jQuery(this).mousemove(function (e){
		jQuery(box).css({"top": (e.pageY + 15) + "px", "left": (e.pageX + 15) + "px"});
	});
	
	jQuery(this).mouseout(function (){
		jQuery(box).fadeOut(speed);
	});
	
	});
};