function documentwrite(text){
    document.write(text);
}

function flashVersion() {
	var ua = navigator.userAgent.toLowerCase();
	var isIE = (ua.indexOf("msie") != -1 && ua.indexOf("opera") == -1 && ua.indexOf("webtv") == -1);
	var version = 0;
	var lastVersion = 10;
	var i;
	if (isIE) {
		var IEoffset = ua.indexOf("msie ");
		var IEVersion = parseFloat(ua.substring(IEoffset+5, ua.indexOf(";", IEoffset)));
		if(IEVersion<5){
			version = 0;	
		} else {
			/*@cc_on @*/
			/*@if (@_jscript_version >= 5)
			   	try {
					for (i = 3; i <= lastVersion; i++) {
						if (eval('new ActiveXObject("ShockwaveFlash.ShockwaveFlash.'+i+'")')) {
							version = i;
						}
					}
				} catch(e) {}
			 @*/
			/*@end @*/
		}
	} else {
		for (i = 0; i < navigator.plugins.length; i++) {
			if (navigator.plugins[i].name.indexOf('Flash') > -1) {
				version = (parseInt(navigator.plugins[i].description.charAt(16)) > version) ? parseInt(navigator.plugins[i].description.charAt(16)) : version;
			}
		}
	}
	return version;
}