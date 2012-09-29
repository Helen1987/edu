var g_version = "8.0.2027.0127";
function GetSingleton( singletonID )
{
var ancestorWindow = window.top;
return ancestorWindow[singletonID];
}
function GlobalTracer()
{
var traceManager = GetSingleton( "0adf1023-1023-1023-0123-330fdea0" );
var emptyFunc = function(){}
this.GetTraceLines = emptyFunc;
this.GetTraceClasses = emptyFunc;
this.EnterFunc = emptyFunc;
this.LeaveFunc = emptyFunc;
this.WriteLine = emptyFunc;
this.WriteData = emptyFunc;
this.WriteWarning = emptyFunc;
this.WriteError = emptyFunc;
this.Wrap = emptyFunc;
if( traceManager )
{
this.GetTraceLines = traceManager.GetTraceLines;
this.GetClassTracers = traceManager.GetClassTracers;
this.WriteLine = traceManager.WriteLine;
this.WriteData = traceManager.WriteData;
this.WriteWarning = traceManager.WriteWarning;
this.WriteError = traceManager.WriteError;
this.Wrap = function( funcName )
{
traceManager.Wrap( window, funcName );
}
}
}
var Trace = new GlobalTracer();
function OOP()
{
}
OOP.Inherit = function( childFunc, parentFunc )
{
var parentObj = new parentFunc();
for( var name in parentObj )
{
childFunc.prototype[ name ] = parentObj[ name ];
}
if( !( "_OOP_PARENT_FUNCS_" in childFunc ) )
{
childFunc._OOP_PARENT_FUNCS_ = new Array();
}
childFunc._OOP_PARENT_FUNCS_.push( parentFunc );
}
OOP.IsInheritFrom = function( obj, baseFunc )
{
for( var i=0; i<obj.constructor._OOP_PARENT_FUNCS_.length; i++ )
{
if( obj.constructor._OOP_PARENT_FUNCS_[i] == baseFunc )
{
return true;
}
}
return ( obj.constructor === baseFunc );
}
OOP.CallParentConstructor = function( obj,classObj )
{
if( "_OOP_PARENT_FUNCS_" in classObj )
{
{
for( var i=0; i<classObj._OOP_PARENT_FUNCS_.length; i++ )
{
classObj._OOP_PARENT_FUNCS_[i].call( obj );
}
}
}
}
OOP.ApplyInstance = function( obj, ctor )
{
for( var name in ctor.prototype )
{
obj[ name ] = ctor.prototype[ name ];
}
ctor.apply( obj );
}
function CreateLMTimer( obj, onTimerFunc, interval )
{
return new LMTimer( obj, onTimerFunc, interval );
}
function EnableLMTimer( timer, isEnabled )
{
timer.SetEnable( isEnabled );
}
function DestoryLMTimer( timer )
{
timer.Release();
timer = null;
}
function LMTimer( obj, onTimerFunc, interval )
{
this._interval = interval;
this._func = Delegate( obj, onTimerFunc );
this._enabled = false;
this._released = false;
this._timerId = 0;
}
LMTimer.prototype.SetEnable = function( isEnabled )
{
if ( isEnabled == this._enabled )
{
return;
}
this._enabled = isEnabled;
if ( isEnabled )
{
this._timerID = window.setInterval( this._func, this._interval );
}
else if ( this._timerID != 0 )
{
window.clearInterval( this._timerID );
}
else
{
}
}
LMTimer.prototype.Release = function()
{
if ( this._enabled )
{
this.SetEnable( false );
}
this._released = true;
}
var Constant =
{
NULL:function(){}
}
var _MsgAssert = function ( msg )
{
var strMsg = "";
if (msg)
{
strMsg = msg;
}
if (window.confirm("ASSERTION FAILED.\r\n" + strMsg + "\n\nInvoke Debugger?"))
{
eval("debugger;");
}
}
function ASSERTNUM( exp, msg )
{
if (
( typeof(exp) != "number")
|| ( isNaN( exp ) )
)
{
_MsgAssert( msg );
}
}
function ASSERTVALID( exp, msg )
{
if (( exp == null )||( exp == undefined ))
{
_MsgAssert( msg );
}
}
function ASSERT( exp, msg )
{
if (!exp)
{
_MsgAssert( msg );
}
}
Array.FromArguments = function( args )
{
var array = new Array();
for( var i=0; i<args.length; i++ )
{
array.push( args[i] );
}
return array;
}
Object.GetPropertyCount = function( obj )
{
var count = 0;
for( var name in obj )
{
count ++;
}
return count;
}
Object.ForEach = function( obj, func )
{
var args = Array.FromArguments( arguments );
for( var name in obj )
{
func.apply( obj[name], args.slice( 2 ) );
}
}
Object.RegisterDomEvent = function( obj, domEventName, domEventHandler )
{
if ( obj._domEventList == null )
obj._domEventList = new Array();
obj[ domEventName ] = domEventHandler;
obj._domEventList.push( domEventName );
}
Object.UnregisterAllEvents = function( obj )
{
if ( obj._domEventList != null )
{
for( var i=0; i<obj._domEventList.length; i++ )
{
var eventName = obj._domEventList[ i ];
obj[ eventName ] = null;
}
}
}
function TimeFormat()
{
}
TimeFormat.FormatTime = function ( value )
{
var hi = Math.floor( value / 10 );
var low = value - hi * 10;
return hi.toString() + low.toString();
}
TimeFormat.GetTimeString = function ( time )
{
var hours = Math.floor( time / 3600 );
time -= hours * 3600;
var minutes = Math.floor( time / 60 );
time -= minutes * 60;
var seconds = Math.floor( time );
var strTime = (
TimeFormat.FormatTime( hours ) + ":" +
TimeFormat.FormatTime( minutes ) + ":" +
TimeFormat.FormatTime( seconds ) );
return strTime;
}
function IsSafari()
{
var userAgent = navigator.userAgent;
if( userAgent.indexOf("Safari") == -1 )
{
return false;
}
else
{
return true;
}
}
function GetPageRoot()
{
var re = new RegExp( "^(.*/)[^/]+\\.[^/\\.]+([?#].*)?$", "i" );
var href = window.location.href;
var matchResult = href.match( re );
if( matchResult == null )
{
alert( "The location is not a valid URL. " );
}
var root = matchResult[1];
try{
if( IsSafari() )
{
root = UriUtils.EncodeUri( root );
}
if( UriUtils.IsWebUrl( root ) )
{
root = UriUtils.DecodeUri( root );
root = UriUtils.EncodeUri( root );
}
}catch(e)
{
root = matchResult[1];
}
return root;
}
function MoveTheFirstLittle( arr )
{
if ( arr.length == 0 )
{
return;
}
if ( arr[0].time != 0 )
{
return;
}
if ( arr.length == 1 )
{
arr[0].time = MeetingSettings.VerySmallTime;
}
else
{
var half = arr[1].time / 2;
if ( half > MeetingSettings.VerySmallTime )
{
arr[0].time = MeetingSettings.VerySmallTime;
}
else
{
arr[0].time = half;
}
}
}
function CreateNonIEXMLHttp()
{
var _xmlhttp = null;
if ( typeof XMLHttpRequest!='undefined' )
{
try
{
_xmlhttp = new XMLHttpRequest();
}
catch (e)
{
_xmlhttp = null;
}
}
if ( !_xmlhttp && window.createRequest )
{
try
{
_xmlhttp = window.createRequest();
}
catch (e)
{
_xmlhttp = null;
}
}
return _xmlhttp;
}
function CreateIEXMLHttp()
{
var _xmlhttp = null;
try
{
_xmlhttp = new ActiveXObject( "Msxml2.XMLHTTP" );
}
catch (e)
{
try
{
_xmlhttp = new ActiveXObject( "Microsoft.XMLHTTP" );
}
catch (E)
{
_xmlhttp = null;
}
}
return _xmlhttp;
}
function _IEHttpCheckFileExist( url )
{
if ( !url )
{
return false;
}
if ( !_IEHttpCheckFileExist.xmlHttp )
{
_IEHttpCheckFileExist.xmlHttp = CreateIEXMLHttp();
}
if ( !_IEHttpCheckFileExist.xmlHttp )
{
return false;
}
try
{
_IEHttpCheckFileExist.xmlHttp.open("get", url, false );
_IEHttpCheckFileExist.xmlHttp.send( );
}
catch( e )
{
return false;
}
if ( _IEHttpCheckFileExist.xmlHttp.statusText == "OK" )
{
return true;
}
else
{
return false;
}
}
function _IELocalCheckFileExist( url )
{
if ( !url )
{
return false;
}
return true;
}
function _IECheckFileExist( url )
{
if ( !url )
{
return false;
}
if ( UriUtils.IsWebUrl( url ) )
{
return _IEHttpCheckFileExist( url );
}
else
{
return _IELocalCheckFileExist( url );
}
}
function _NonIECheckFileExist( url )
{
if ( !url )
{
return false;
}
if ( window.XMLHttpRequest )
{
if ( !_NonIECheckFileExist.xmlHttp )
{
_NonIECheckFileExist.xmlHttp = CreateNonIEXMLHttp();
}
if ( !_NonIECheckFileExist.xmlHttp )
{
return false;
}
try
{
_NonIECheckFileExist.xmlHttp.open( "Get", url, false );
_NonIECheckFileExist.xmlHttp.send( null );
}
catch( e )
{
return false;
}
if ( _NonIECheckFileExist.xmlHttp.readyState == 4 )
{
if ( _NonIECheckFileExist.xmlHttp.statusText == "Not Found" )
{
return false;
}
return true;
}
else
{
return false;
}
}
else
{
return false;
}
}
function CheckFileExist( url )
{
if ( !url )
{
return false;
}
if ( window.ActiveXObject )
{
return _IECheckFileExist( url );
}
else
{
return _NonIECheckFileExist( url );
}
}
function KeyTable()
{
}
KeyTable.VK_TAB = 0x09;
KeyTable.VK_RETURN = 0x0d;
KeyTable.VK_ESCAPE = 0x1b;
KeyTable.VK_SPACE = 0x20;
KeyTable.VK_LEFT = 0x25;
KeyTable.VK_UP = 0x26;
KeyTable.VK_RIGHT = 0x27;
KeyTable.VK_DOWN = 0x28;
var UriUtils = new Object();
UriUtils.decodeReplaceTable =
{
"%23":"#",
"%3b":";",
"%26":"&"
};
UriUtils.encodeReplaceTable =
{
"#":"%23",
";":"%3b",
"&":"%26"
}
UriUtils.EncodeUri = function( uri )
{
if( uri == null )
{
return null;
}
uri = encodeURI( uri );
uri = ReplaceSpecialCharacters( uri, UriUtils.encodeReplaceTable );
return uri;
}
UriUtils.DecodeUri = function( uri )
{
if( uri == null )
{
return null;
}
uri = ReplaceSpecialCharacters( uri, UriUtils.decodeReplaceTable );
try
{
uri = decodeURI( uri );
}catch(e)
{
throw e;
}
return uri;
}
UriUtils.GetFullUri = function( root, relativeUri )
{
if( root.match( /[\\\/]$/ ) == null )
{
root = root + "/";
}
while( relativeUri.match( /^\.\.[\\\/]/ ) != null )
{
var matchResult = root.match( /^(.*[\\\/])[^\\\/]+[\\\/]$/ )
if( matchResult != null )
{
root = matchResult[1];
}
else
{
break;
}
relativeUri = relativeUri.substr( 3 );
}
return root + relativeUri;
}
UriUtils.IsUrl = function( href )
{
var re = new RegExp( "^\\w+://" );
return ( href.match( re ) != null );
}
UriUtils.IsWebUrl = function( uri )
{
uri += "";
var reg = new RegExp( "^https?://", "i" );
var matchResult = uri.match( reg );
return matchResult != null;
}
UriUtils.FilePath2Url = function( path )
{
var url = path.replace( /\\/g, "\/" );
var prefix = "";
var re = new RegExp( "^//" );
if( url.match( re ) == null )
{
prefix = "file:///";
}
else
{
prefix = "file:";
}
return prefix + url;
}
function SafeStrGetter()
{
}
SafeStrGetter._replaceTable = {
"<":"&lt;",
">":"&gt;",
"\"":"&quot;",
"'":"&#39;",
"&":"&amp;",
"\t":"    ",
"\r":"",
"\n":"<br/>"
};
function GetSafeText( text )
{
text = text + "";
var _replaceMatchString = "[";
for ( var c in SafeStrGetter._replaceTable )
{
_replaceMatchString += c;
}
_replaceMatchString += "]";
var reg = new RegExp( _replaceMatchString, "g" );
text = text.replace( reg, function( $0 ){ return SafeStrGetter._replaceTable[ $0 ]; } );
text = text.replace( / /g, "&nbsp;" );
return text;
}
function GetSizeofText( text, font, textInfoDiv )
{
var safeText = GetSafeText( text );
return GetSizeofSafeText( safeText, font, textInfoDiv );
}
function GetSizeofSafeText( safeText, font, textInfoDiv )
{
try
{
textInfoDiv.style.font = font;
}
catch ( e )
{
textInfoDiv.style.font = "normal normal normal 12pt Arial";
}
textInfoDiv.innerHTML = safeText;
var res = {};
res.width = textInfoDiv.scrollWidth;
res.height = textInfoDiv.scrollHeight;
textInfoDiv.innerHTML = "";
return res;
}
function GetDataString( data )
{
if( !data )
{
return data;
}
var str = "";
if( data.toString )
{
str = data.toString();
}
return str;
}
function EncodeLessThanSign( str )
{
if( str != null )
{
var re = /</g;
str = str.replace( re, "&lt;" );
}
return str;
}
function FormatString( )
{
var args = arguments;
var formatString = GetDataString( args[0] );
if( formatString )
{
formatString = formatString.replace( /%/g, "%A" );
formatString = formatString.replace( /%A%A/g, "%B" );
var params = new Array();
for( var i=1; i<args.length; i++ )
{
params[i] = GetDataString( args[i] );
if( params[i] )
{
params[i] = params[i].replace( /%/g, "%C" );
}
}
for( var i=1; i<args.length; i++ )
{
var re = new RegExp( "%A" + i, "g" );
formatString = formatString.replace( re, params[i] );
}
formatString = formatString.replace( /%A/g, "" );
formatString = formatString.replace( /%B|%C/g, "%" );
}
return formatString;
}
function CompareVersion( v1, v2 )
{
var vlist1 = v1.split( "." );
var vlist2 = v2.split( "." );
if ( vlist1.length > vlist2.length )
{
for ( var i = 0; i < vlist1.length - vlist2.length; i ++ )
{
vlist2.push( "0" );
}
}
else
{
for ( var i = 0; i < vlist2.length - vlist1.length; i ++ )
{
vlist1.push( "0" );
}
}
var retval = 0;
for( var i = 0; i < vlist1.length; i++ )
{
if ( parseInt(vlist1[i]) < parseInt(vlist2[i]) )
{
retval = -1;
break;
}
else if ( parseInt(vlist1[i]) > parseInt(vlist2[i]) )
{
retval = 1;
break;
}
}
return retval;
}
function ReplaceSpecialCharacters ( str, replaceTable )
{
if( str == null )
{
return "";
}
var _replaceMatchString = "";
for ( var s in replaceTable )
{
_replaceMatchString += s+"|";
}
if( _replaceMatchString.length > 0)
{
_replaceMatchString = _replaceMatchString.substr(0, _replaceMatchString.length -1);
}
if( _replaceMatchString.length >0 )
{
var reg = new RegExp( _replaceMatchString, "gi" );
var replacedStr  = str.replace( reg, function( $0 ){ return replaceTable[ $0.toLowerCase() ]; } );
return replacedStr;
}
else
{
return str;
}
}
function Delegate( obj, func )
{
if( typeof( func ) != "function" )
{
}
var delegate = function()
{
if ( typeof(Delegate)=="undefined"  || Delegate.DisableAll )
{
return null;
}
return func.apply( obj, arguments );
}
delegate.Clear = function()
{
obj = null;
func = null;
}
delegate._ORIGINAL_FUNC_ = func;
delegate._ORIGINAL_OBJECT_ = obj;
return delegate;
}
Delegate.DisableAll = false;
function DelegateWithArgs()
{
if ( arguments.length < 2 )
{
return;
}
if( typeof( arguments[1] ) != "function" )
{
return;
}
var obj = arguments[0];
var func = arguments[1];
var presetArgs = new Array();
for( var i = 2; i < arguments.length; i++ )
{
presetArgs.push( arguments[i] );
}
var delegate = function()
{
if( typeof(Delegate)=="undefined"  || Delegate.DisableAll )
{
return;
}
var inputArgs = new Array();
for( var i=0; i<presetArgs.length; i++ )
{
inputArgs[i] = presetArgs[i];
}
for ( var i = 0; i < arguments.length; i++ )
{
inputArgs.push( arguments[i] );
}
if ( inputArgs.length > 0 )
{
return func.apply( obj, inputArgs );
}
else
{
return func.call( obj );
}
}
delegate.Clear = function()
{
obj = null;
func = null;
presetArgs = null;
}
delegate._ORIGINAL_FUNC_ = func;
delegate._ORIGINAL_OBJECT_ = obj;
delegate._ORIGINAL_ARGS_ = presetArgs;
return delegate;
}
function Event()
{
var _delegates = new Array();
var eventFunc = function()
{
if ( Delegate.DisableAll )
{
return;
}
for( var i=0; i<_delegates.length; i++ )
{
if ( arguments.length > 1 )
{
_delegates[i].apply( null, arguments );
}
else if ( arguments.length == 1 )
{
_delegates[i].call( null, arguments[0] );
}
else
{
_delegates[i].call( null );
}
}
}
eventFunc.PostFire = function()
{
for( var i=0; i<_delegates.length; i++ )
{
setTimeout( DelegateWithArgs( _delegates[i], _delegates[i].apply, null, arguments ), 10 );
}
}
eventFunc.Add = function( delegate )
{
var i = 0;
while( i < _delegates.length )
{
if ( _delegates[i] == delegate )
{
return;
}
i++;
}
_delegates[ _delegates.length ] = delegate;
}
eventFunc.Remove = function ( delegate )
{
var i = 0;
while( i < _delegates.length )
{
if ( _delegates[i] == delegate )
{
_delegates.splice( i, 1 );
return;
}
i++;
}
}
eventFunc.GetDelegateCount = function()
{
return _delegates.length;
}
eventFunc.Clear = function()
{
_delegates = [];
}
return eventFunc;
}
Event.CancelBubble = function( eventObj )
{
eventObj.cancelBubble = true;
}
function EventsManager()
{
var _events = new Object();
this.AddEvent = function( eventName )
{
if( eventName in _events )
{
alert( "The event has been added. " );
}
_events[ eventName ] = new Event();
}
this.GetEvent = function( eventName )
{
return _events[ eventName ];
}
this.AddEventHandlers = function ( eventHandlers )
{
for( var eventName in eventHandlers )
{
var currentEvent = _events[ eventName ];
if( currentEvent )
{
currentEvent.Add(
eventHandlers[ eventName ] );
}
}
}
this.FireEvent = function ( eventName )
{
if( typeof( eventName ) != "string" )
{
return;
}
var currentEvent = _events[ eventName ];
if( currentEvent )
{
if( arguments.length > 1 )
{
var inputArgs = new Array();
for( var i=1; i<arguments.length; i++ )
{
inputArgs[i - 1] = arguments[i];
}
currentEvent.apply( currentEvent, inputArgs );
}
else
{
currentEvent();
}
}
}
}
function NavigatorInfoDetector()
{
this.features = {
"wmv":{"checked":false, "enabled":false},
"flash":{"checked":false, "enabled":false},
"animation":{"checked":false, "enabled":false},
"annotation":{"checked":false, "enabled":false},
"image":{"checked":false, "enabled":false},
"cookie":{"checked":false, "enabled":false}
};
this.browser = {
"name":"unknown",
"version":"9999"
};
this.os = {
"name":"unknown",
"type":"unknown",
"version":"9999"
};
this.language = {
"system":"en",
"user":"en",
"browser":"en"
};
this.FinishedEvent = new Event();
this.checkWMV = true;
this.checkAnimation = true;
this.checkFlash = true;
this._userAgent = new Object();
this._checkingDiv = null;
}
NavigatorInfoDetector.WMVCHECK = "WMV_CHECK";
NavigatorInfoDetector.MSOANIMCHECK = "MSOANIM_CHECK";
NavigatorInfoDetector.MSOTIMECHECK = "MSOTIME_CHECK";
NavigatorInfoDetector.FLASHCHECK = "FLASH_CHECK";
NavigatorInfoDetector.QUICKTIMECHECK = "QUICKTIME_CHECK";
NavigatorInfoDetector.prototype.GetBrowserName = function()
{
return this.browser.name;
}
NavigatorInfoDetector.prototype.GetBrowserVersion = function()
{
return this.browser.version;
}
NavigatorInfoDetector.prototype.GetBrowser = function()
{
return this.GetBrowserName() +
"/" +
this.GetBrowserVersion();
}
NavigatorInfoDetector.prototype.IsIE = function()
{
return this.GetBrowserName() == "MSIE";
}
NavigatorInfoDetector.prototype.IsSafari = function()
{
return this.GetBrowserName() == "Safari";
}
NavigatorInfoDetector.prototype.IsFirefox = function()
{
return this.GetBrowserName() == "Firefox";
}
NavigatorInfoDetector.prototype.IsMozilla = function()
{
return this.GetBrowserName() == "Mozilla";
}
NavigatorInfoDetector.prototype.IsNetscape = function()
{
return this.GetBrowserName() == "Netscape";
}
NavigatorInfoDetector.prototype.GetOSName = function()
{
return this.os.name;
}
NavigatorInfoDetector.prototype.GetOSType = function()
{
return this.os.type;
}
NavigatorInfoDetector.prototype.GetOSVersion = function()
{
return this.os.version;
}
NavigatorInfoDetector.prototype.GetOS = function()
{
return this.GetOSName() + " " +
this.GetOSType() + " " +
this.GetOSVersion();
}
NavigatorInfoDetector.prototype.GetBrowserLanguage = function()
{
return this.language.browser;
}
NavigatorInfoDetector.prototype.GetUserLanguage = function()
{
return this.language.user;
}
NavigatorInfoDetector.prototype.GetSystemLanguage = function()
{
return this.language.system;
}
NavigatorInfoDetector.prototype.ActiveXSupported = function()
{
var obj = null;
var retval = true;
try
{
obj = new ActiveXObject( "Microsoft.XMLDOM" );
}
catch( e )
{
retval = false;
}
delete obj;
return retval;
}
NavigatorInfoDetector.prototype.AnimationEnabled = function()
{
return this.features.animation.enabled;
}
NavigatorInfoDetector.prototype.ImageEnabled = function()
{
return this.features.image.enabled;
}
NavigatorInfoDetector.prototype.AnnotationEnabled = function()
{
return this.features.annotation.enabled;
}
NavigatorInfoDetector.prototype.WmvEnabled = function()
{
return this.features.wmv.enabled;
}
NavigatorInfoDetector.prototype.FlashEnabled = function()
{
return this.features.flash.enabled;
}
NavigatorInfoDetector.prototype.CookieEnabled = function()
{
return this.features.cookie.enabled;
}
NavigatorInfoDetector.prototype._GetLanguages = function()
{
if( this.IsIE() )
{
this.language.browser = navigator.browserLanguage;
this.language.user = navigator.userLanguage;
this.language.system = navigator.systemLanguage;
}
else
{
this.language.browser = navigator.language;
this.language.user = navigator.language;
this.language.system = navigator.language;
}
}
NavigatorInfoDetector.prototype._CheckCookie = function()
{
this.features.cookie.enabled = navigator.cookieEnabled;
this.features.cookie.checked = true;
}
NavigatorInfoDetector.prototype._ParseUserAgent = function()
{
var parseString = navigator.userAgent;
var numInfo = 0;
var tmpInfo;
var parts = this._SplitString(parseString, " ");
if( parts == null || parts.length <2)
{
this._SetNonStandardUserAgentInfo();
return;
}
var part0 = parts[0].match(/^\s*([^()\s]*)\/([^()\s]*)\s*$/);
if( part0 == null )
{
this._SetNonStandardUserAgentInfo();
return;
}
var part1 = parts[1].match(/^\s*\((.*)\)\s*$/);
if( part1 == null )    {
this._SetNonStandardUserAgentInfo();
return;
}
var commentInfo = this._SplitString(part1[1],";");
var part2 = new Array();
for(var i=2;i<parts.length;i++)
{
if((tmpInfo=parts[i].match(/^\s*([^()\s]*)\s*$/))!=null)
{
part2.push(tmpInfo[1]);
}
}
this._userAgent.appName = navigator.appName;
this._userAgent.appCodeName = part0[1];
this._userAgent.appVersion = part0[2];
this._userAgent.appAttributes = commentInfo;
this._userAgent.appExtensions = part2;
}
NavigatorInfoDetector.prototype._FindTopLevelMatchedSymbolPair = function(input,fromIndex,leftSymbol,rightSymbol)
{
if( leftSymbol == rightSymbol )
{
throw Exception("Left symbol can't equal to right symbol");
}
var startPosition = -1;
var counter = 0;
var index = -1;
index = input.indexOf(leftSymbol,fromIndex);
if( index == -1 )
{
index = input.indexOf(rightSymbol,fromIndex);
if( index != -1 )
{
throw Exception("Invalid format string");
}
return null;
}
startPosition = index;
counter++;
index = input.indexOf(rightSymbol,fromIndex);
if(index < startPosition)
{
throw Exception("Invalid format string");
}
index = startPosition;
while(counter>0)
{
index++;
if(index>=input.length)
{
throw Exception("Invalid string");
}
if(input.charAt(index) == leftSymbol)
{
counter++;
}
else
if(input.charAt(index) == rightSymbol)
{
counter--;
}
}
var result = new Object();
result.start = startPosition;
result.end = index;
return result;
}
NavigatorInfoDetector.prototype._SplitString = function(inputString,separator )
{
var replacedStrings = new Array();
var tmpInfo;
var tmpString = "";
var fromIndex = 0;
try
{
while((tmpInfo = this._FindTopLevelMatchedSymbolPair(inputString,fromIndex,"(",")"))!= null)
{
replacedStrings.push(inputString.substring(tmpInfo.start,tmpInfo.end+1));
tmpString = tmpString+inputString.substring(fromIndex,tmpInfo.start+1)+(replacedStrings.length-1)+")";
fromIndex = tmpInfo.end+1;
}
}catch(e)
{
return null;
}
tmpString += inputString.substring(fromIndex);
var parts = tmpString.split(separator);
var i = 0;
var current = 0;
while( i<replacedStrings.length )
{
var from = 0;
var tmp = "";
var pos = -1;
while((pos=parts[current].indexOf("(",from))!=-1)
{
tmp = tmp + parts[current].substring(from,pos)+replacedStrings[i];
from = pos+(""+i).length+2;
i++;
}
tmp += parts[current].substring(from);
parts[current] = tmp;
current++;
}
return parts;
}
NavigatorInfoDetector.prototype._SetNonStandardUserAgentInfo = function()
{
this._userAgent.appName = navigator.appName;
this._userAgent.appCodeName = "unknown";
this._userAgent.appVersion = "9999";
this._userAgent.appAttributes = new Array();
this._userAgent.appExtensions = new Array();
}
NavigatorInfoDetector.prototype._CollectBrowserInfo = function()
{
this.browser.name = this._userAgent.appName;
this.browser.version = this._userAgent.appVersion;
if( this._userAgent.appName == "Microsoft Internet Explorer" )
{
for( var i=0; i<this._userAgent.appAttributes.length; i++ )
{
var prop = this._userAgent.appAttributes[i];
var matchResult = prop.match( /^\s*MSIE ([^\s]*)\s*/i );
if( matchResult )
{
this.browser.name = "MSIE";
this.browser.version = matchResult[1];
}
}
}
else
{
var bGecko = false;
var bFirefox = false;
var verFirefox = "0.0";
for( var i = 0; i < this._userAgent.appExtensions.length; i++ )
{
var part = this._userAgent.appExtensions[i].split( "/" );
if ( part && part.length > 1 )
{
if ( part[0] == "Gecko" )
{
bGecko = true;
}
else if ( part[0].toLowerCase() == "firefox" )
{
bFirefox = true;
verFirefox = part[1];
}
}
}
if ( bFirefox )
{
this.browser.name = "Firefox";
this.browser.version = verFirefox;
}
else if ( bGecko )
{
this.browser.name = this._userAgent.appCodeName;
this.browser.version = this._userAgent.appVersion;
}
else
{
for( var i=0; i<this._userAgent.appExtensions.length; i++ )
{
var prop = this._userAgent.appExtensions[i];
var matchResult = prop.match( /(.*)\/(.*)/ );
if( matchResult )
{
if( matchResult[1].toLowerCase() == "safari" )
{
this.browser.name = "Safari";
this.browser.version = matchResult[2];
break;
}
else
{
this.browser.name = matchResult[1];
this.browser.version = matchResult[2];
}
}
}
}
}
}
NavigatorInfoDetector.prototype._CollectOSInfo = function()
{
for( var i=0; i<this._userAgent.appAttributes.length; i++ )
{
var prop = this._userAgent.appAttributes[i];
var matchResult = prop.match( /Windows NT (.*)/ );
if( matchResult )
{
this.os.name = "Windows";
this.os.type = "NT";
this.os.version = matchResult[1];
}
matchResult = prop.match( /(Mac\s*OS)\s*(.*)$/ );
if( matchResult )
{
this.os.name = "Mac OS";
this.os.type = prop;
this.os.version = matchResult[2];
}
}
}
NavigatorInfoDetector.prototype._CheckPlugins = function()
{
if( this.IsIE() )
{
if ( this.checkWMV )
{
this.features.wmv.enabled = ( document.getElementById( NavigatorInfoDetector.WMVCHECK ) != null );
}
if ( this.checkAnimation )
{
this.features.animation.enabled =
( document.getElementById( NavigatorInfoDetector.MSOANIMCHECK ) != null ) &&
( document.getElementById( NavigatorInfoDetector.MSOTIMECHECK ) != null );
}
if ( this.checkFlash )
{
var flashObj = document.getElementById( NavigatorInfoDetector.FLASHCHECK );
if( flashObj == null || typeof(flashObj.movie)!="string" )
{
this.features.flash.enabled = false;
}
else
{
this.features.flash.enabled = true;
}
}
this.features.wmv.checked = true;
this.features.animation.checked = true;
this.features.flash.checked = true;
}
else
{
var oPlugins = navigator.plugins;
var bQuickTime = false;
var bFlip4Mac = false;
for( var i=0; i<oPlugins.length; i++ )
{
var pluginName = oPlugins[i].name;
if( pluginName.match( /Windows Media Player/i ) )
{
this.features.wmv.enabled = true;
}
if( pluginName.match( /QuickTime Plug-in/i ) )
{
bQuickTime = true;
}
if( pluginName.match( /Flip4Mac Windows Media/i ) )
{
bFlip4Mac = true;
}
if( pluginName.match( /Shockwave Flash/i ) )
{
this.features.flash.enabled = true;
}
}
if( this.IsSafari())
{
if( this.features.flash.enabled )
{
var flashDiv = document.createElement( "div" );
this._checkingDiv.appendChild( flashDiv );
flashDiv.innerHTML += "<embed id='FLASH_CHECK' type='application/x-shockwave-flash' width=0 height=0 tabIndex='-1' src='blank.swf'/><span>FLASH</span></embed>";
var flashObject = document.getElementById( NavigatorInfoDetector.FLASHCHECK );
if( flashObject == null || !flashObject.TGetProperty)
{
this.features.flash.enabled = false;
}
}
if( bQuickTime )
{
var quickTimeDiv = document.createElement( "div" );
this._checkingDiv.appendChild( quickTimeDiv );
quickTimeDiv.innerHTML += "<embed id='"+NavigatorInfoDetector.QUICKTIMECHECK+"' type='video/quicktime' />";
oQuickTime = document.getElementById( NavigatorInfoDetector.QUICKTIMECHECK );
if( oQuickTime == null || oQuickTime.GetQuickTimeVersion == null )
{
bQuickTime = false;
}
}
if( bQuickTime && bFlip4Mac )
{
this.features.wmv.enabled = true;
}
else
{
this.features.wmv.enabled = false;
}
}
this.features.wmv.checked = true;
this.features.flash.checked = true;
this.features.animation.checked = true;
}
}
NavigatorInfoDetector.prototype._CheckImage = function()
{
this.features.image.enabled = g_imageEnabled;
this.features.image.checked = true;
}
NavigatorInfoDetector.prototype._CheckAnnotation = function()
{
if( this.IsIE() )
{
this.features.annotation.enabled = ( this.browser.version >= "5.5" );
this.features.annotation.checked = true;
}
else
{
this.features.annotation.checked = true;
}
}
NavigatorInfoDetector.prototype._BeginSettingChecking = function()
{
var oDiv = document.createElement( "div" );
oDiv.style.visibility = "hidden";
oDiv.id = "SettingCheckDiv";
document.body.appendChild( oDiv );
this._checkingDiv = oDiv;
}
NavigatorInfoDetector.prototype._VerifySettingChecking = function()
{
var checked = true;
for( var name in this.features )
{
if( !this.features[ name ].checked )
{
checked = false;
break;
}
}
return checked;
}
NavigatorInfoDetector.prototype._EndSettingChecking = function()
{
for( var name in this.features )
{
if( !this.features[ name ].checked )
{
alert( name );
}
}
if( this._checkingDiv != null )
{
document.body.removeChild( this._checkingDiv );
}
this.FinishedEvent();
}
NavigatorInfoDetector.prototype.Initialize = function()
{
this._ParseUserAgent();
this._CollectBrowserInfo();
this._CollectOSInfo();
this._GetLanguages();
}
NavigatorInfoDetector.prototype.DetectBrowserSettings = function()
{
this._BeginSettingChecking();
this._CheckCookie();
this._CheckImage();
this._CheckPlugins();
this._CheckAnnotation();
this._EndSettingChecking();
}
NavigatorInfoDetector.prototype.IsVista = function()
{
var osName = NavigatorInfo.GetOSName();
var osType = NavigatorInfo.GetOSType();
var osVer  = NavigatorInfo.GetOSVersion();
if ( osName == "Windows"
&& osType == "NT"
&& CompareVersion( osVer, "6.0" ) >= 0
)
{
return true;
}
else
{
return false;
}
}
Trace.Wrap( "NavigatorInfoDetector" );
var NavigatorInfo = new NavigatorInfoDetector();
NavigatorInfo.Initialize();
function BaseXMLDataBuilder( strURI, bCaseSensitive )
{
Trace.WriteLine( "XMLDataBuilder: Loading " + strURI );
if( navigator.appName == "Microsoft Internet Explorer" )
{
if( !UriUtils.IsWebUrl( strURI ) )
{
try
{
strURI = decodeURI( strURI );
}catch(e)
{
}
}
}
this._strURI = strURI;
this._bSensitive = bCaseSensitive;
this._bCleanedup = true;
this.Result = null;
this.ItemVisitedEvent = new Event();
this._innerResultGotEvent = new Event();
this._innerResultGotEvent.Add( Delegate( this, BaseXMLDataBuilder.prototype._ResultGotHandler ) );
this._innerErrorEvent = new Event();
this._innerErrorEvent.Add( Delegate( this, BaseXMLDataBuilder.prototype._ErrorHandler ) );
this.ResultGotEvent = new Event();
this.ErrorEvent = new Event();
}
BaseXMLDataBuilder.prototype._ResultGotHandler = function( doc, rootNode )
{
this.ResultGotEvent( doc, rootNode );
this.CleanUp();
}
BaseXMLDataBuilder.prototype._ErrorHandler = function( errorId, uri )
{
this.ErrorEvent( errorId, uri );
this.CleanUp();
}
BaseXMLDataBuilder.prototype._PostProcess = function( rootNode )
{
}
BaseXMLDataBuilder.prototype.Execute = function()
{
this._bCleanedup = false;
this._Initialize();
this._LoadXML( this._strURI );
}
BaseXMLDataBuilder.prototype._Initialize = function()
{
if (window.ActiveXObject)
{
this.xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
this.xmlDoc.async = "true";
this.xmlDoc.onreadystatechange = Delegate( this, BaseXMLDataBuilder.prototype._ReadyStateChange );
}
else if ( window.XMLHttpRequest )
{
this.xmlHttpRequest = new XMLHttpRequest();
this.xmlHttpRequest.onreadystatechange = Delegate( this, BaseXMLDataBuilder.prototype._ReadyStateChange );
}
else
{
this._innerErrorEvent( E_HTTPREQUEST_NOT_SUPPORTED );
}
}
BaseXMLDataBuilder.prototype._ReadyStateChange = function ()
{
if ( this.xmlDoc )
{
if ( this.xmlDoc.readyState == 4 )
{
this._XMLOnload();
}
}
else if ( this.xmlHttpRequest )
{
if ( this.xmlHttpRequest.readyState == 4 )
{
if( NavigatorInfo.IsSafari() && this.xmlHttpRequest.responseText == null )
{
this._innerErrorEvent( E_LOAD_XML_FAILED, this._strURI );
}
else
{
this._XMLOnload();
}
}
}
}
BaseXMLDataBuilder.prototype.CleanUp = function()
{
if ( this._bCleanedup )
{
return;
}
this._bCleanedup = true;
if (window.ActiveXObject)
{
if ( this.xmlDoc )
{
this.xmlDoc.onreadystatechange = Constant.NULL;
delete this.xmlDoc;
}
}
else if ( window.XMLHttpRequest )
{
if ( this.xmlHttpRequest )
{
this.xmlHttpRequest.onreadystatechange = null;
delete this.xmlHttpRequest;
}
}
}
BaseXMLDataBuilder.prototype._LoadXML = function( strURI )
{
Trace.WriteLine( "Loading XML " + strURI );
if (window.ActiveXObject)
{
var retval = false;
try
{
retval = this.xmlDoc.load( strURI );
}
catch( e )
{
retval = false;
}
if ( !retval )
{
this._innerErrorEvent( E_LOAD_XML_FAILED, strURI );
}
}
else
{
try
{
this.xmlHttpRequest.open( "GET", strURI, true );
this.xmlHttpRequest.send( null );
}
catch( e )
{
this._innerErrorEvent( E_LOAD_XML_FAILED, strURI );
}
}
}
BaseXMLDataBuilder.prototype._XMLOnload = function()
{
if (this.xmlHttpRequest)
{
this.xmlDoc = this.xmlHttpRequest.responseXML;
}
if ( !this.xmlDoc )
{
this._innerErrorEvent( E_INVALID_XML, this._strURI );
return;
}
var rootnode = null;
var tmp = this.xmlDoc.firstChild;
while( tmp )
{
if ( tmp.nodeType == 1 )
{
rootnode = tmp;
break;
}
tmp = tmp.nextSibling;
}
if ( rootnode )
{
this._PostProcess( rootnode );
}
else
{
this._innerErrorEvent( E_INVALID_XML, this._strURI );
}
}
function XMLDataBuilder( strURI, bCaseSensitive )
{
BaseXMLDataBuilder.call( this, strURI, bCaseSensitive );
}
OOP.Inherit( XMLDataBuilder, BaseXMLDataBuilder );
XMLDataBuilder.prototype._PostProcess = function( rootNode )
{
var dataBuilder = new XMLDomDataBuilder(
rootNode,
Delegate(this, this._innerResultGotEvent),
Delegate(this, this.ItemVisitedEvent),
this._bSensitive );
dataBuilder.Execute();
}
function DirectXMLDataBuilder( strURI, bCaseSensitive )
{
BaseXMLDataBuilder.call( this, strURI, bCaseSensitive );
}
OOP.Inherit( DirectXMLDataBuilder, BaseXMLDataBuilder );
DirectXMLDataBuilder.prototype._PostProcess = function( rootNode )
{
this._innerResultGotEvent( this.xmlDoc, rootNode );
}
function XMLDomDataBuilder( root, resultGotCallBack, itemVisitCallBack, sensitive )
{
this.root = root;
this.sensitive = sensitive;
this.obj = null;
this.resultGotCallBack = resultGotCallBack;
this.itemVisitCallBack = itemVisitCallBack;
this._visitStack = [];
}
XMLDomDataBuilder.ASyncCoef = 30;
XMLDomDataBuilder.prototype.Execute = function()
{
this.obj = XMLDomDataBuilder.GetObjFromSingleNode(
this.root,
this.sensitive
);
this._visitStack.push(
XMLDomDataBuilder.CreateStackObj( this.root, this.obj, 0 )
);
this._timerHandler = setTimeout(
Delegate( this, XMLDomDataBuilder.prototype.RevisitTree ),
10
);
}
XMLDomDataBuilder.prototype.GetResultAndDispose = function()
{
this._resultGot = true;
this.resultGotCallBack( this.obj );
this.Dispose();
}
XMLDomDataBuilder.prototype.Dispose = function()
{
clearTimeout( this._timerHandler );
this.root = null;
this.obj = null;
}
XMLDomDataBuilder.prototype.RevisitTree = function()
{
var bDone = false;
for ( var i = 0; i < XMLDomDataBuilder.ASyncCoef && !bDone; i++ )
{
bDone = this._VisitElement();
}
if ( bDone )
{
return;
}
this._timerHandler = setTimeout(
Delegate( this, XMLDomDataBuilder.prototype.RevisitTree ),
10
);
}
XMLDomDataBuilder.prototype._VisitElement = function()
{
if ( this._visitStack.length == 0 )
{
this.GetResultAndDispose();
return true;
}
var stackObj = this._visitStack[ this._visitStack.length - 1];
var parentdata = stackObj.parentdata;
var data = null;
var parentnode = stackObj.parentnode;
while ( stackObj.childId < parentnode.childNodes.length
&& parentnode.childNodes[stackObj.childId].nodeType != 1 )
{
stackObj.childId++;
}
var childId = stackObj.childId;
if ( childId < parentnode.childNodes.length )
{
data = XMLDomDataBuilder.GetObjFromSingleNode( parentnode.childNodes[childId], this._sensitive );
XMLDomDataBuilder.HookDataToParent( parentdata, data );
this._visitStack.push(
XMLDomDataBuilder.CreateStackObj(
parentnode.childNodes[childId],
data,
0
)
);
}
else
{
this.itemVisitCallBack( parentdata );
this._visitStack.pop();
if ( this._visitStack.length > 0 )
{
this._visitStack[ this._visitStack.length - 1 ].childId++;
}
}
return false;
}
XMLDomDataBuilder.CreateStackObj = function( parentnode, parentdata, childId )
{
return { "parentnode":parentnode,"parentdata":parentdata,"childId":childId };
}
XMLDomDataBuilder.HookDataToParent = function( obj, childobj )
{
var arrayName = childobj._name;
if ( obj[arrayName] == null )
{
obj[arrayName] = [];
}
obj[arrayName].push( childobj );
}
XMLDomDataBuilder.GetObjFromSingleNode = function( node, sensitive )
{
if (!node)
{
return null;
}
var resObj = new Object();
resObj._name = XMLDomDataBuilder.GetNameFromSingleNode( node, sensitive );
resObj.value = XMLDomDataBuilder.GetTextValueFromSingleNode( node );
resObj.attributes = XMLDomDataBuilder.GetAttributesFromSingleNode( node, sensitive );
return resObj;
}
XMLDomDataBuilder.GetNameFromSingleNode = function( node, sensitive )
{
var retval = "";
if ( node.nodeName )
{
if ( sensitive )
{
retval = node.nodeName;
}
else
{
retval = node.nodeName.toLowerCase();
}
}
return retval;
}
XMLDomDataBuilder.GetAttributesFromSingleNode = function( node, sensitive )
{
if ( !node.attributes )
{
return null;
}
var attributes = new Object();
for(var i = 0; i < node.attributes.length; i++ )
{
var attr = node.attributes[i];
var attrName = "";
if ( sensitive )
{
attrName = attr.name;
}
else
{
attrName = attr.name.toLowerCase();
}
if( NavigatorInfo.IsSafari() )
{
attributes[ attrName ] = XMLUtils.ReplacePredefinedEntityReferences( attr.value );
}
else
{
attributes[ attrName ] = attr.value;
}
}
return attributes;
}
XMLDomDataBuilder.GetTextValueFromSingleNode = function( node )
{
var retval = "";
if (node.nodeValue)
{
retval = node.nodeValue;
}
var childNode = node.firstChild;
while( childNode )
{
if ( childNode.nodeType == 3 )
{
var s = childNode.nodeValue;
s = s.replace( /^\s*/, "" );
s = s.replace( /\s*$/, "" );
retval += s;
}
else if (childNode.nodeType == 4 )
{
var val = childNode.nodeValue;
if( NavigatorInfo.IsSafari() )
{
val = val.replace( /\r\n/g, "\n" );
}
retval += val;
}
childNode = childNode.nextSibling;
}
if( NavigatorInfo.IsSafari() )
{
retval = XMLUtils.ReplacePredefinedEntityReferences( retval );
}
return retval;
}
function AsyncJS()
{
}
AsyncJS.ASYNC_COEF = 49;
AsyncJS.VisitArray = function(
list,
startIndex,
endIndex,
nodeProc,
finishedDelegate,
verifyCancelDelegate,
canceledDelegate )
{
if ( verifyCancelDelegate && verifyCancelDelegate() )
{
if ( canceledDelegate )
{
canceledDelegate();
}
return;
}
var targetIndex = Math.min( startIndex + AsyncJS.ASYNC_COEF, endIndex - 1 );
for ( var i = startIndex; i <= targetIndex; i++ )
{
nodeProc( list[i] );
}
if ( targetIndex == endIndex - 1 )
{
setTimeout( finishedDelegate, 0 );
}
else
{
setTimeout( DelegateWithArgs(
null,
AsyncJS.VisitArray,
list,
targetIndex + 1,
endIndex,
nodeProc,
finishedDelegate,
verifyCancelDelegate,
canceledDelegate
), 0 );
}
}
function XMLUtils()
{
}
XMLUtils.GetFirstElementChild = function( node )
{
var resNode = null;
var i = 0;
while ( i < node.childNodes.length )
{
if ( node.childNodes[i].nodeType == 1 )
{
resNode = node.childNodes[i];
break;
}
i++;
}
return resNode;
}
XMLUtils.PredefinedEntityReferences =
{
"&#60;":"<",
"&#62;":">",
"&#38;":"&",
"&#34;":"\"",
"&#39;":"'"
};
XMLUtils.ReplacePredefinedEntityReferences = function( value )
{
value = ReplaceSpecialCharacters( value, XMLUtils.PredefinedEntityReferences );
return value;
}
function GradedInfo( defaultInfo )
{
this.InfoChanged = new Event();
this._info = new Array();
this._defaultInfo = defaultInfo;
this._topGrade = GradedInfo._invalidGrade;
this._topGradeInfo = this._defaultInfo;
}
GradedInfo._invalidGrade = -1;
GradedInfo.grades = {
error: 0,
warning: 1,
information: 2 };
GradedInfo.prototype.SetInformation = function( grade, text )
{
this._info[ grade ] = text;
this._CheckInfoChanged();
}
GradedInfo.prototype.ClearInformation = function( level )
{
this._info[ level ] = null;
this._CheckInfoChanged();
}
GradedInfo.prototype.GetTopGradeInformation = function()
{
return this._topGradeInfo;
}
GradedInfo.prototype.GetDefaultInformation = function()
{
return this._defaultInfo;
}
GradedInfo.prototype.ClearAllInformations = function( forceUpdate )
{
for( var i=0; i<this._info.length; i++ )
{
this._info[ i ] = null;
}
this._CheckInfoChanged( forceUpdate );
}
GradedInfo.prototype.ForceUpdateInformation = function()
{
this.InfoChanged( this._topGradeInfo );
}
GradedInfo.prototype._CheckInfoChanged = function( forceUpdate )
{
var topGrade = this._GetTopGrade();
if( topGrade == GradedInfo.invalidGrade )
{
if( this._topGrade == topGrade )
{
if( forceUpdate )
{
this.InfoChanged( this._topGradeInfo );
}
return;
}
else
{
this._topGrade = topGrade;
this._topGradeInfo = this._defaultInfo;
this.InfoChanged( this._topGradeInfo );
return;
}
}
var topGradeInfo = this._info[ topGrade ];
if( topGrade != this._topGrade )
{
this._topGrade = topGrade;
this._topGradeInfo = topGradeInfo;
this.InfoChanged( this._topGradeInfo );
return;
}
if( this._topGradeInfo != topGradeInfo )
{
this._lastGrade = topGrade;
this._topGradeInfo = topGradeInfo;
this.InfoChanged( this._topGradeInfo );
return;
}
if( forceUpdate )
{
this.InfoChanged( this._topGradeInfo );
}
return;
}
GradedInfo.prototype._GetTopGrade = function()
{
var grade = GradedInfo._invalidGrade;
for( var i=0; i<this._info.length; i++ )
{
info = this._info[ i ];
if( info != null )
{
grade = i;
break;
}
}
return grade;
}
function ErrorHandling()
{
this.ErrorOccuredEvent = new Event();
this.WarningOccuredEvent = new Event();
this._warningDuringLoading = false;
this._step = ErrorHandling.Step.Loading;
}
ErrorHandling.Step = {};
ErrorHandling.Step.Loading = 0;
ErrorHandling.Step.Runtime = 1;
ErrorHandling.prototype.EndLoadingProcess = function()
{
this._step = ErrorHandling.Step.Runtime;
if ( this._warningDuringLoading )
{
var msg = this._GetMSG( EE_LOADINGWARNING );
this.WarningOccuredEvent( msg );
}
}
ErrorHandling.prototype.ShowCustomWarning = function( msg, showrightnow )
{
if ( (this._step == ErrorHandling.Step.Loading) && (!showrightnow) )
{
this._warningDuringLoading = true;
}
else
{
this.WarningOccuredEvent( msg );
}
}
ErrorHandling.prototype.ShowCustomError = function( msg )
{
this.ErrorOccuredEvent( msg );
}
ErrorHandling.prototype.ShowWarning = function( messageid )
{
var msg = this._GetMSG( messageid );
if ( this._step == ErrorHandling.Step.Loading )
{
this._warningDuringLoading = true;
}
else
{
this.WarningOccuredEvent( msg );
}
}
ErrorHandling.prototype.ShowError = function( messageid )
{
var msg = this._GetMSG( messageid );
this.ErrorOccuredEvent( msg );
}
var E_DATAPATHNOTPROVIDED       = 0x000000;
var E_MEETINGINFONOTPROVIDED    = 0x000001;
var E_CURRENTNOTPROVIDED        = 0x000002;
var E_HTTPREQUEST_NOT_SUPPORTED = 0xA00000;
var E_LOAD_XML_FAILED           = 0xA00001;
var E_INVALID_XML               = 0xA00002;
var E_INDEXNOTPROVIDED          = 0x000003;
var EE_LOADINGWARNING            = 0x0000FF;
var E_PAGENOTEXIST              = 0x000100;
var E_ATTENDEEDUPLICATED        = 0x000200;
var E_UNSECUREURL               = 0x000300;
var E_MMCNOFORMAT               = 0x040000;
var E_MMCBADMESSAGE             = 0x040001;
var E_BADTEXTMESSAGE            = 0x040100;
var E_TEXTFULL                  = 0x040101;
var E_BADPOLLMESSAGE            = 0x040200;
var E_ANNONOTSUPPORTED          = 0x050000;
var E_IISNOTSUPPORTED           = 0x050001;
var E_BADCLIPWIDTH              = 0x050100;
var E_BADCLIPHEIGHT             = 0x050101;
var E_ANNOELMIDNOTEXISTED       = 0x051000;
var E_ANNOELMIDHASEXISTED       = 0x051001;
var E_BADANNODATA               = 0x051002;
var E_INVALIDINDEXITEM          = 0x060001;
var E_INVALIDINDEXITEMTIME      = 0x060002;
var E_INVALIDOPTDATANODE        = 0xB00001;
var E_INVALIDOPTDATANODETIME    = 0xB00002;
var E_INVALIDOPTSNAPSHOT        = 0xB00003;
var E_INVALIDARG                = 0xFF0000;
ErrorHandling.prototype._GetMSG = function( msgId )
{
var localizedMsgId = "";
switch ( msgId )
{
case E_DATAPATHNOTPROVIDED:
localizedMsgId = UISettings.ErrorHandling_DataPathNotProvided;
break;
case E_HTTPREQUEST_NOT_SUPPORTED:
localizedMsgId = UISettings.ErrorHandling_HttpRequestNotSupported;
break;
case E_LOAD_XML_FAILED:
case E_INVALID_XML:
case E_MEETINGINFONOTPROVIDED:
case E_CURRENTNOTPROVIDED:
localizedMsgId = UISettings.ErrorHandling_BadMeetingData;
break;
case EE_LOADINGWARNING:
localizedMsgId = UISettings.ErrorHandling_WarningOccurredDuringLoading;
break;
case E_INDEXNOTPROVIDED:
localizedMsgId = UISettings.ErrorHandling_BadIndex;
break;
case E_PAGENOTEXIST:
localizedMsgId = UISettings.ErrorHandling_PageNotExist;
break;
case E_ANNONOTSUPPORTED:
localizedMsgId = UISettings.ErrorHandling_AnnoNotSupported;
break;
case E_IISNOTSUPPORTED:
localizedMsgId = UISettings.ErrorHandling_SVGNotSupported;
break;
case E_ATTENDEEDUPLICATED:
case E_TEXTFULL:
case E_ANNOELMIDNOTEXISTED:
case E_ANNOELMIDHASEXISTED:
case E_BADANNODATA:
case E_BADTEXTMESSAGE:
case E_BADPOLLMESSAGE:
case E_MMCBADMESSAGE:
case E_MMCNOFORMAT:
case E_INVALIDARG:
case E_INVALIDINDEXITEM:
case E_INVALIDINDEXITEMTIME:
case E_INVALIDOPTDATANODE:
case E_INVALIDOPTDATANODETIME:
case E_INVALIDOPTSNAPSHOT:
case E_BADCLIPWIDTH:
case E_BADCLIPHEIGHT:
case E_UNSECUREURL:
localizedMsgId = UISettings.ErrorHandling_WarningOccurredRuntime;
break;
default:
}
return LocaleInfo.GetText( localizedMsgId );
}
var g_ErrorHandling = new ErrorHandling();
Trace.Wrap( "ErrorHandling" );
var LocaleDefaultRegions = {
en: "US",
de: "DE",
es: "ES",
fr: "FR",
it: "IT",
ja: "JP",
ko: "KR",
pt: "BR",
zh: "CN",
da: "DK",
fi: "FI",
nl: "NL",
sv: "SE"
};
function LocaleInfoImpl()
{
this.LoadedEvent = new Event();
this.language = "en";
this.region = "us";
this._relativePath = "";
this._currentLoadingIndex = -1;
this._textItems = new Object();
this._isLoaded = false;
this._defaultRegions = LocaleDefaultRegions;
}
LocaleInfoImpl.prototype.Initialize = function( relativePath )
{
this._relativePath = relativePath + "";
this._isLoaded = false;
}
LocaleInfoImpl.prototype.Load = function()
{
var languageString = NavigatorInfo.GetBrowserLanguage();
var language = null;
var region = null;
var dashPos = languageString.indexOf( "-" );
if( dashPos >= 0 )
{
language = languageString.substr( 0, dashPos ).toLowerCase();
region = languageString.substr( dashPos + 1 ).toUpperCase();
}
else
{
language = languageString.toLowerCase();
}
this.Reload( language, region );
}
LocaleInfoImpl.prototype.GetText = function( name )
{
return this._textItems[ name ];
}
LocaleInfoImpl.prototype.Reload = function( language, region )
{
this.language = language;
this.region = region;
var resFileName = "res";
var xmlFileNames = new Array();
if( region != null )
{
xmlFileNames.push( resFileName + "_" + language + "_" + region + ".xml" );
}
else if( language in this._defaultRegions )
{
xmlFileNames.push( resFileName + "_" + language + "_" + this._defaultRegions[ language ] + ".xml" );
}
xmlFileNames.push( resFileName + "_en_us" + ".xml" );
xmlFileNames.push( resFileName + ".xml" );
this._LoadOneFile( xmlFileNames, 0 );
}
LocaleInfoImpl.prototype._LoadOneFile = function( files, index )
{
if( index < files.length )
{
this._currentLoadingIndex = index;
var xmlBuilder = new XMLDataBuilder(
GetPageRoot() + this._relativePath + files[ index ] );
xmlBuilder.ResultGotEvent.Add( DelegateWithArgs( this, this._XMLResultHandler, files, index ) );
xmlBuilder.ErrorEvent.Add( DelegateWithArgs( this, this._XMLErrorHandler, files, index ) );
xmlBuilder.Execute();
}
else
{
this._currentLoadingIndex ++;
this._OnLoaded( false );
}
}
LocaleInfoImpl.prototype._XMLResultHandler = function( files, index, data )
{
if( data == null )
{
if( index == this._currentLoadingIndex )
{
this._LoadOneFile( files, index + 1 );
}
return;
}
var properties = data.property;
if ( properties == null )
{
if ( index >= files.length - 1 )
{
this._OnLoaded( false );
}
else
{
this._LoadOneFile( files, index + 1 );
}
return;
}
for( var i=0; i<properties.length; i++ )
{
if( properties[i].attributes == null )
{
continue;
}
var propertyName = properties[i].attributes.name;
var propertyValue = properties[i].value;
this._textItems[ propertyName ] = propertyValue;
}
this._OnLoaded( true );
}
LocaleInfoImpl.prototype._XMLErrorHandler = function( files, index, eMsg )
{
Trace.WriteLine( "Error occured when parse the resource file " + files[ index ] + ". " + eMsg );
if( index == this._currentLoadingIndex )
{
this._LoadOneFile( files, index + 1 );
}
}
LocaleInfoImpl.prototype._OnLoaded = function( isSucceeded, errorMessage )
{
this._isLoaded = true;
this.LoadedEvent( isSucceeded, errorMessage );
}
Trace.Wrap( "LocaleInfoImpl" );
function MeetingSettings()
{
}
MeetingSettings.MeetingState = new Object();
MeetingSettings.MeetingState.Undefined = 0;
MeetingSettings.MeetingState.Stopped = 1;
MeetingSettings.MeetingState.Paused = 2;
MeetingSettings.MeetingState.Playing = 3;
MeetingSettings.MeetingState.ScanForward = 4;
MeetingSettings.MeetingState.ScanReverse = 5;
MeetingSettings.MeetingState.Buffering = 6;
MeetingSettings.MeetingState.Waiting = 7;
MeetingSettings.MeetingState.MediaEnded = 8;
MeetingSettings.MeetingState.Transitioning = 9;
MeetingSettings.MeetingState.Ready = 10;
MeetingSettings.MeetingState.Reconnecting = 11;
MeetingSettings.DID = new Object();
MeetingSettings.DID.Yes = 1;
MeetingSettings.DID.No = 2;
MeetingSettings.DID.Always = 256;
MeetingSettings.DID.YesToAll = MeetingSettings.DID.Yes + MeetingSettings.DID.Always;
MeetingSettings.DID.NoToAll = MeetingSettings.DID.No + MeetingSettings.DID.Always;
MeetingSettings.PageType = new Object();
MeetingSettings.PageType.Audio = "Audio";
MeetingSettings.PageType.QCIFVideo = "QCIFVideo";
MeetingSettings.PageType.PanoVideo = "PanoVideo";
MeetingSettings.PageType.Ppt = "Ppt";
MeetingSettings.PageType.Text = "Text";
MeetingSettings.PageType.Web = "Web";
MeetingSettings.PageType.Poll = "Poll";
MeetingSettings.PageType.Image = "Image";
MeetingSettings.PageType.MMC = "MMC";
MeetingSettings.PageType.Modi = "Modi";
MeetingSettings.PageType.Whiteboard = "Whiteboard";
MeetingSettings.PageType.AppSharing = "AppSharing";
MeetingSettings.VirtualPageType = new Object();
MeetingSettings.VirtualPageType.Anno = "Anno";
MeetingSettings.VirtualPageType.Start = "Start";
MeetingSettings.VirtualPageType.Notes = "Notes";
MeetingSettings.DownloadTimeMin = 5000;
MeetingSettings.VerySmallTime = 0.0001;
MeetingSettings.Index = new Object();
MeetingSettings.Index.ContentName = "content";
MeetingSettings.Index.SpeakerName = "speaker";
MeetingSettings.MaxPollChoiceCount = 7;
MeetingSettings.WaitResumeAVRate = 0.0001;
MeetingSettings.MeetingStateClass = function ( state, speed, vol, ismute, pos, isSeeking)
{
this.State = state;
this.Speed = speed;
this.Volume = vol;
this.IsMute = ismute;
this.MeetingPos = pos;
this.IsSeeking = isSeeking;
}
var g_MeetingState = new MeetingSettings.MeetingStateClass(
MeetingSettings.MeetingState.Undefined,
1.0,
1.0,
false,
0,
false
);
function UISettings()
{
this._engineRoot = GetPageRoot();
this._imageRoot = "img/";
}
UISettings.prototype.GetImage = function( imageName )
{
var imageId = imageName + "Image";
return this._engineRoot + this._imageRoot + UISettings[ imageId ];
}
UISettings.prototype.SetImageRoot = function( imageRoot )
{
this._imageRoot = imageRoot;
}
UISettings.unloadPrompt = "Window_UnloadPrompt";
UISettings.informationImage = "information.png";
UISettings.informationTopMargin = 10;
UISettings.informationRightMargin = 10;
UISettings.meetingStateBufferingText = "MeetingState_Buffering";
UISettings.meetingStateStoppedText = "MeetingState_Stopped";
UISettings.meetingStatePlayingText = "MeetingState_Playing";
UISettings.meetingStatePausedText = "MeetingState_Paused";
UISettings.borderFrameId = "BorderFrame";
UISettings.mainFrameId = "MainFrame";
UISettings.mainFrameWidthMin = 640;
UISettings.mainFrameHeightMin = 480;
UISettings.brandAreaId = "BrandArea";
UISettings.workAreaId = "WorkArea";
UISettings.notificationPaneId = "NotificationPane";
UISettings.confirmPaneId = "ConfirmPane";
UISettings.errorPaneId = "ErrorPane";
UISettings.brandPaneId = "BrandPane";
UISettings.downloadFrameId = "DownloadFrame";
UISettings.playbackFrameId = "PlaybackFrame";
UISettings.errorPaneTextBoxId = "ErrorPaneText";
UISettings.errorPaneButtonId = "ErrorPaneButton";
UISettings.errorPaneButtonText = "ErrorPane_ButtonText";
UISettings.errorPaneButtonTooltip = "ErrorPane_ButtonTooltip";
UISettings.brandHeight = 46;
UISettings.productLogoId = "ProductLogo";
UISettings.productLogoImage = "header-lmlogo.gif";
UISettings.corpLogoId = "CorpLogo";
UISettings.corpImageTop = 5;
UISettings.corpImageRightMargin = 7;
UISettings.maxCorpImageWidth = 192;
UISettings.maxCorpImageHeight = 34;
UISettings.corpImageInnerBorderWidth = 1;
UISettings.corpImageOuterBorderWidth = 1;
UISettings.corpImageInnerBorderColor = "#DBE0E7";
UISettings.corpImageOuterBorderColor = "#999FA9";
UISettings.notificationTextId = "NotificationText";
UISettings.notificationPadding = 10;
UISettings.notificationQueueLengthMax = 10;
UISettings.notificationLaunchTimeout = 1000;
UISettings.notificationCloseTimeout = 10000;
UISettings.notificationBackgroundColor = "#A2B4CA";
UISettings.notificationBorderColor = "#4080c0";
UISettings.confirmCloseTimeout = 10000;
UISettings.confirmBackgroundColor = "#A2B4CA";
UISettings.confirmButtonAreaId = "ConfirmPaneButtonArea";
UISettings.confirmPaneWidth = 500;
UISettings.confirmPaneButtonAreaWidth = 140;
UISettings.confirmPanePromptTextPaddingTop = 13;
UISettings.confirmPanePromptTextPaddingLeft = 14;
UISettings.confirmPaneComponentTextPaddingTop = 18;
UISettings.confirmPaneComponentTextPaddingLeft = 37;
UISettings.confirmPaneComponentTextPaddingBottom = 18;
UISettings.confirmPaneCheckBoxPaddingLeft = 12;
UISettings.confirmPaneCheckBoxPaddingRight = 5;
UISettings.confirmPaneCheckBoxPaddingBottom = 10;
UISettings.confirmPaneButtonAreaMarginBottom = 5;
UISettings.confirmPaneButtonAreaMarginRight = 5;
UISettings.confirmPaneButtonDistance = 6;
UISettings.confirmPaneOkButtonText = "ConfirmPane_OkButtonText";
UISettings.confirmPaneOkButtonTooltip = "ConfirmPane_OkButtonTooltip";
UISettings.confirmPaneCancelButtonText = "ConfirmPane_CancelButtonText";
UISettings.confirmPaneCancelButtonTooltip = "ConfirmPane_CancelButtonTooltip";
UISettings.confirmPanePromptText = "ConfirmPane_PromptText";
UISettings.confirmPaneCheckBoxText = "ConfirmPane_CheckBoxText";
UISettings.confirmPaneDefaultMsgId = "BWQCIF";
UISettings.errorBackgroundColor = "#ffffc0";
UISettings.downloadAnimationImage = "download-animation.gif";
UISettings.downloadSeperatorImage = "download-pg-separator.gif";
UISettings.downloadSubjectId = "DownloadSubject";
UISettings.downloadMeetingInfoId = "DownloadMeetingInfo";
UISettings.downloadPromptId = "DownloadPrompt";
UISettings.downloadAnimationId = "DownloadAnimation";
UISettings.downloadSeperatorId = "DownloadSeperator";
UISettings.downloadSeperatorWrapperId = "DownloadSeperatorWrapper";
UISettings.downloadBrowserSettingId = "DownloadBrowserSetting";
UISettings.downloadContinueButtonAreaId = "DownloadContinueButtonArea";
UISettings.downloadContinueButtonId = "DownloadContinueButton";
UISettings.downloadCloseButtonId = "DownloadCloseButton";
UISettings.downloadDefaultSubject = "Download_DefaultSubject";
UISettings.downloadPromptText = "Download_DownloadingPrompt";
UISettings.downloadStartTimePrompt = "Download_StartTimePrompt";
UISettings.downloadStopTimePrompt = "Download_StopTimePrompt";
UISettings.downloadDurationPrompt = "Download_DurationPrompt";
UISettings.downloadStartTimeDefaultString = "Download_StartTimeDefaultString";
UISettings.downloadStopTimeDefaultString = "Download_StopTimeDefaultString";
UISettings.downloadDurationDefaultString = "Download_DurationDefaultString";
UISettings.downloadContinueButtonText = "Download_ContinueButtonText";
UISettings.downloadCloseButtonText = "Download_CloseButtonText";
UISettings.downloadContinueButtonTooltip = "Download_ContinueButtonTooltip";
UISettings.downloadCloseButtonTooltip = "Download_CloseButtonTooltip";
UISettings.downloadBrowserNameCheckResult = "Download_BrowserNameCheckResult";
UISettings.downloadBrowserVersionCheckResult = "Download_BrowserVersionCheckResult";
UISettings.downloadCookieCheckResult = "Download_CookieCheckResult";
UISettings.downloadImageCheckResult = "Download_ImageCheckResult";
UISettings.downloadWmvCheckResult = "Download_WmvCheckResult";
UISettings.downloadFlashCheckResult = "Download_FlashCheckResult";
UISettings.downloadAnimationCheckResult = "Download_AnimationCheckResult";
UISettings.downloadAnnotationCheckResult = "Download_AnnotationCheckResult";
UISettings.downloadCheckResultEndingSentence = "Download_CheckResultEndingSentence";
UISettings.downloadMeetingInfoHeightMin = 24;
UISettings.downloadBrowserSettingHeightMin = 16;
UISettings.controlHeight = 32;
UISettings.primVideoHWRatio = 0.75;
UISettings.primVideoWidth = 203;
UISettings.primVideoHeight = 156;
UISettings.notesQaWidth = 203;
UISettings.mainVertSplitterWidth = 2;
UISettings.mainHorzSplitterHeight = 2;
UISettings.dataSplitterWidth = 2;
UISettings.controlPaneId = "ControlPane";
UISettings.primVideoPaneId = "PrimVideoPane";
UISettings.panoVideoPaneId = "PanoVideoPane";
UISettings.audioPaneId = "AudioPane";
UISettings.indexPaneId = "IndexPane";
UISettings.qaPaneId = "QaPane";
UISettings.notesPaneId = "NotesPane";
UISettings.dataPaneId = "DataPane";
UISettings.mainVertSplitterId = "MainVertSplitter";
UISettings.mainHorzSplitterId = "MainHorzSplitter";
UISettings.dataSplitterId = "DataSplitter";
UISettings.frameTitleClassName = "FrameTitle";
UISettings.dummyId = "DummyThumb";
UISettings.dummyImage = "dummy-thumbnail.gif";
UISettings.timeSliderId = "TimeSlider";
UISettings.timeSliderTopLineId = "TimeSliderTopLine";
UISettings.timeSliderBottomLineId = "TimeSliderBottomLine";
UISettings.timeSliderHeight = 7;
UISettings.timeSliderTopLineHeight = 1;
UISettings.timeSliderBottomLineHeight = 1;
UISettings.timeSliderWidth = 19;
UISettings.timeTextId = "TimeText";
UISettings.timeTextHeight = 23;
UISettings.timeTextWidth = 118;
UISettings.timeTextRightMargin = 0;
UISettings.paneMenuId = "MainMenu_View";
UISettings.paneMenuWidth = 204;
UISettings.paneMenuHeight = 23;
UISettings.paneMenuLeft = 0;
UISettings.showSpeakerMenuItemId = "ViewMenu_Speaker";
UISettings.showPanoramaMenuItemId = "ViewMenu_Panorama";
UISettings.showIndexMenuItemId = "ViewMenu_Index";
UISettings.showNotesMenuItemId = "ViewMenu_Notes";
UISettings.showQaMenuItemId = "ViewMenu_QA";
UISettings.showSpeakerMenuItemDescription = "ViewMenu_Speaker_Description";
UISettings.showPanoramaMenuItemDescription = "ViewMenu_Panorama_Description";
UISettings.showIndexMenuItemDescription = "ViewMenu_Index_Description";
UISettings.showNotesMenuItemDescription = "ViewMenu_Notes_Description";
UISettings.showQaMenuItemDescription = "ViewMenu_QA_Description";
UISettings.viewMenuButtonImage = "menu-button-view.png";
UISettings.viewMenuExpandImage = "dropdown-arrow.gif";
UISettings.buttonsAreaWidth = 213;
UISettings.buttonsAreaHeight = 23;
UISettings.buttonsAreaImage = "play-back-middle.gif";
UISettings.buttonsLeftAreaWidth = 9;
UISettings.buttonsRightAreaWidth = 12;
UISettings.buttonsLeftAreaImage = "play-back-left.gif";
UISettings.buttonsRightAreaImage = "play-back-right.gif";
UISettings.playButtonHeight = 23;
UISettings.playButtonWidth = 18;
UISettings.playButtonHorzMargin = 3;
UISettings.buttonSeperatorHorzMargin = 6;
UISettings.buttonSeperatorWidth = 2;
UISettings.volumeSliderId = "ControlButton_Volume";
UISettings.volumeSliderLeftMargin = 3;
UISettings.volumeSliderHeight = 8;
UISettings.volumeSliderWidth = 12;
UISettings.volumeTrackWidth = 65;
UISettings.playButtonId = "ControlButton_Play";
UISettings.pauseButtonId = "ControlButton_Pause";
UISettings.stopButtonId = "ControlButton_Stop";
UISettings.previousButtonId = "ControlButton_Prev";
UISettings.nextButtonId = "ControlButton_Next";
UISettings.muteButtonId = "ControlButton_Mute";
UISettings.unmuteButtonId = "ControlButton_Unmute";
UISettings.normalPlayButtonImage = "play-active.gif";
UISettings.downPlayButtonImage = "play-click.gif";
UISettings.disabledPlayButtonImage = "play-inactive.gif";
UISettings.highlightPlayButtonImage = "play-hover.gif";
UISettings.normalStopButtonImage = "stop-active.gif";
UISettings.downStopButtonImage = "stop-click.gif";
UISettings.disabledStopButtonImage = "stop-inactive.gif";
UISettings.highlightStopButtonImage = "stop-hover.gif";
UISettings.normalPauseButtonImage = "paused-active.gif";
UISettings.downPauseButtonImage = "paused-click.gif";
UISettings.disabledPauseButtonImage = "paused-inactive.gif";
UISettings.highlightPauseButtonImage = "paused-hover.gif";
UISettings.normalPrevButtonImage = "prev-active.gif";
UISettings.downPrevButtonImage = "prev-click.gif";
UISettings.disabledPrevButtonImage = "prev-inactive.gif";
UISettings.highlightPrevButtonImage = "prev-hover.gif";
UISettings.normalNextButtonImage = "next-active.gif";
UISettings.downNextButtonImage = "next-click.gif";
UISettings.disabledNextButtonImage = "next-inactive.gif";
UISettings.highlightNextButtonImage = "next-hover.gif";
UISettings.normalMuteButtonImage = "unmuted-active.gif";
UISettings.downMuteButtonImage = "unmuted-click.gif";
UISettings.disabledMuteButtonImage = "unmuted-inactive.gif";
UISettings.highlightMuteButtonImage = "unmuted-hover.gif";
UISettings.normalUnmuteButtonImage = "muted-active.gif";
UISettings.downUnmuteButtonImage = "muted-click.gif";
UISettings.disabledUnmuteButtonImage = "muted-inactive.gif";
UISettings.highlightUnmuteButtonImage = "muted-hover.gif";
UISettings.timeUnelapsedImage = "progress-back.gif";
UISettings.timeElapsedImage = "progress-green.gif";
UISettings.timeSliderImage = "progress-thumb.gif";
UISettings.timeHeadImage = "progress-green.gif";
UISettings.timeTailImage = "progress-back.gif";
UISettings.volumeUnelapsedImage = "vol-track-active.gif";
UISettings.volumeElapsedImage = "vol-track-active.gif";
UISettings.volumeSliderImage = "vol-slider-active.gif";
UISettings.volumeHeadImage = "vol-track-active.gif";
UISettings.volumeTailImage = "vol-track-active.gif";
UISettings.controlLeftBackgroundImage = "bottom-left.gif";
UISettings.controlRightBackgroundImage = "bottom-right.gif";
UISettings.controlBackgroundImage = "bottom-back.gif";
UISettings.generalButtonBackgroundNormalLeftImage = "button-left.gif";
UISettings.generalButtonBackgroundPushedLeftImage = "button-click-left.gif";
UISettings.generalButtonBackgroundHighlightedLeftImage = "button-hover-left.gif";
UISettings.generalButtonBackgroundDisabledLeftImage = "button-left.gif";
UISettings.generalButtonBackgroundNormalMiddleImage = "button-middle.gif";
UISettings.generalButtonBackgroundPushedMiddleImage = "button-click-middle.gif";
UISettings.generalButtonBackgroundHighlightedMiddleImage = "button-hover-middle.gif";
UISettings.generalButtonBackgroundDisabledMiddleImage = "button-middle.gif";
UISettings.generalButtonBackgroundNormalRightImage = "button-right.gif";
UISettings.generalButtonBackgroundPushedRightImage = "button-click-right.gif";
UISettings.generalButtonBackgroundHighlightedRightImage = "button-hover-right.gif";
UISettings.generalButtonBackgroundDisabledRightImage = "button-right.gif";
UISettings.primVideoRendererId = "PrimVideoRenderer";
UISettings.primVideoPanePadding = 5;
UISettings.bizCardRendererId = "BizCardRenderer";
UISettings.bizCardNameId = "BizCard_Name";
UISettings.bizCardCompanyId = "BizCard_Company";
UISettings.bizCardTitleId = "BizCard_Title";
UISettings.bizCardEmailId = "BizCard_Email";
UISettings.bizCardPhoneId = "BizCard_Phone";
UISettings.bizCardImageId = "BizCard_Image";
UISettings.bizCardBackgroundImage = "cc-background.gif";
UISettings.bizCardDefaultPhotoImage = "cc-default-image.gif";
UISettings.XStampAnnoImage = "X.png";
UISettings.CheckStampAnnoImage = "Check.png";
UISettings.ArrowStampAnnoImage = "Arrow.png";
UISettings.panoVideoRendererId = "PanoVideoRenderer";
UISettings.panoVideoPanePadding = 5;
UISettings.audioRendererId = "AudioRenderer";
UISettings.indexCategoriesId = "IndexCategories";
UISettings.indexTabContentId = "IndexTab_Content";
UISettings.indexTabSpeakerId = "IndexTab_Speaker";
UISettings.indexCategoryLeftMargin = 3;
UISettings.indexCategoryRightMargin = 3;
UISettings.indexCategoryTopMargin = 3;
UISettings.indexCategoryBottomMargin = 0;
UISettings.indexCategoryHeight = 22;
UISettings.indexCategoryNormalLeftClassName = "IndexTabNormalLeft";
UISettings.indexCategoryNormalRightClassName = "IndexTabNormalRight";
UISettings.indexCategoryNormalMiddleClassName = "IndexTabNormalMiddle";
UISettings.indexCategoryHighlightedLeftClassName = "IndexTabHighlightedLeft";
UISettings.indexCategoryHighlightedRightClassName = "IndexTabHighlightedRight";
UISettings.indexCategoryHighlightedMiddleClassName = "IndexTabHighlightedMiddle";
UISettings.indexCategoryClassName = "IndexTab";
UISettings.indexListsLeftMargin = 3;
UISettings.indexListsRightMargin = 3;
UISettings.indexListsTopMargin = 0;
UISettings.indexListsBottomMargin = 3;
UISettings.contentIndexListId = "ContentIndex";
UISettings.contentListLeftPadding = 3;
UISettings.contentListRightPadding = 3;
UISettings.contentListItemVertMargin = 4;
UISettings.contentListItemWidth = 173;
UISettings.contentListItemHeight = 119;
UISettings.contentListItemPaddingLeft = 13;
UISettings.contentListItemPaddingRight = 13;
UISettings.contentListItemPaddingTop = 15;
UISettings.contentListItemImageWidth = 97;
UISettings.contentListItemImageHeight = 77;
UISettings.contentListItemTimeMarginLeft = 4;
UISettings.contentListItemTitleMarginTop = 4;
UISettings.contentIndexNormalItemClassName = "ContentIndexNormalItem";
UISettings.contentIndexHighlightedItemClassName = "ContentIndexHighlightedItem";
UISettings.contentIndexSeperatorClassName = "ContentIndexSeperator";
UISettings.speakerIndexListId = "SpeakerIndex";
UISettings.speakerIndexHeadSeperatorId = "SpeakerIndexHeadSeperator";
UISettings.speakerIndexSelectAllId = "SpeakerIndexSelectAll";
UISettings.speakerIndexSelectAllTextId = "SpeakerIndex_SelectAll";
UISettings.speakerIndexDeselectAllId = "SpeakerIndexDeselectAll";
UISettings.speakerIndexDeselectAllTextId = "SpeakerIndex_DeselectAll";
UISettings.speakerIndexUnknownSpeakerName = "SpeakerIndex_UnknownSpeakerName";
UISettings.speakerIndexItemClassName = "SpeakerIndexItem";
UISettings.speakerIndexNormalNameClassName = "SpeakerIndexNormalName";
UISettings.speakerIndexHighlightedNameClassName = "SpeakerIndexHighlightedName";
UISettings.speakerIndexTimeListClassName = "SpeakerIndexTimeList";
UISettings.speakerIndexNormalTimeClassName = "SpeakerIndexNormalTime";
UISettings.speakerIndexHighlightedTimeClassName = "SpeakerIndexHighlightedTime";
UISettings.speakerIndexNameCheckBoxAreaWidth = 16;
UISettings.speakerIndexNameExpandBoxAreaWidth = 16;
UISettings.speakerIndexNameTimeAreaWidth = 56;
UISettings.speakerIndexNameCountAreaWidth = 24;
UISettings.speakerIndexPlusId = "SpeakerIndexPlus";
UISettings.speakerIndexMinusId = "SpeakerIndexMinus";
UISettings.speakerIndexPlusImage = "index-plus.gif";
UISettings.speakerIndexMinusImage = "index-minus.gif";
UISettings.qaPaneTitleId = "PaneTitle_QA";
UISettings.qaRendererId = "QaRenderer";
UISettings.qaNoItemPromptId = "QaNoItemPrompt";
UISettings.qaPaneTitleHeight = 18;
UISettings.qaPanePadding = 3;
UISettings.qaQuestionText = "QaPrompt_Question";
UISettings.qaAnswerText = "QaPrompt_Answer";
UISettings.qaNoDataText = "QaPrompt_NoData";
UISettings.qaNormalItemClassName = "QaNormalItem";
UISettings.qaHighlightedItemClassName = "QaHighlightedItem";
UISettings.qaSeperatorClassName = "QaSeperator";
UISettings.notesPaneTitleId = "PaneTitle_Notes";
UISettings.notesNoDataText = "NotesPrompt_NoData";
UISettings.notesRendererId = "NotesRenderer";
UISettings.notesPaneTitleHeight = 18;
UISettings.notesPanePadding = 3;
UISettings.dummyRendererId = "DummyRenderer";
UISettings.pptRendererId = "PptRenderer";
UISettings.imageRendererId = "imageRenderer";
UISettings.pollRendererId = "pollRenderer";
UISettings.whiteboardRendererId = "whiteboardRenderer";
UISettings.textRendererId = "textRenderer";
UISettings.webRendererId = "webRenderer";
UISettings.mmcRendererId = "mmcRenderer";
UISettings.modiRendererId = "modiRenderer";
UISettings.asRendererId = "asRenderer";
UISettings.annotationRendererId = "annotationRenderer";
UISettings.dataPanePadding = 2;
UISettings.dataPaneInfoWidgetId = "dataPaneBackgroundWidget";
UISettings.dataPaneInfoWidgetHeight = 16;
UISettings.dataPaneInfoWidgetColor = "#FEEA09";
UISettings.dataAreaBottomRightImage = "dummy-slide-corner-graphic.gif";
UISettings.dummySubjectTextId = "DummySubjectText";
UISettings.dummyTimeTextId = "DummyTimeText";
UISettings.dummyBottomRightImageId = "DummyBottomRightImage";
UISettings.mmcWmvWidgetId = "mmcWmvWidget";
UISettings.mmcFlashWidgetId = "mmcFlashWidget";
UISettings.asWmvWidgetId = "asWmvWidget";
UISettings.asImageWidgetId = "asImageWidget";
UISettings.asBottomRightImageId = "AsBottomRightImage";
UISettings.asContentStaticTextId = "AsContentStaticText";
UISettings.asContentStaticImage = "start-pg-lmlogo.gif";
UISettings.asStaticContentText = "AsSlide_StaticContentText";
UISettings.pollPromptQuestionText = "PollPrompt_Question";
UISettings.pollPromptChoicesText = "PollPrompt_Choices";
UISettings.pollPromptResultsText = "PollPrompt_Results";
UISettings.pollPromptPollsOpenText = "PollPrompt_PollsOpen";
UISettings.pollPromptPollsClosedText = "PollPrompt_PollsClosed";
UISettings.pollPromptResultsShownText = "PollPrompt_ResultsShown";
UISettings.pollPromptResultsHiddenText = "PollPrompt_ResultsHidden";
UISettings.pollChoiceCountMax = 7;
UISettings.pollChoiceAreaPaddingLeft = 10;
UISettings.pollChoiceAreaPaddingTop = 10;
UISettings.pollChoiceAreaPaddingBottom = 10;
UISettings.pollChoiceAreaPaddingRight = 10;
UISettings.pollChoiceItemHeight = 32;
UISettings.pollChoiceFontSizeLevels = 4;
UISettings.pollChoiceIconWidth = 32;
UISettings.pollChoiceTextWidthMin = 100;
UISettings.pollChoiceItemVertMargin = 10;
UISettings.pollChoiceItemHorzMargin = 10;
UISettings.pollResultAreaPaddingLeft = 10;
UISettings.pollResultAreaPaddingRight = 10;
UISettings.pollResultFontSize = 24;
UISettings.pollResultRatioWidth = 150;
UISettings.pollResultCountWidth = 36;
UISettings.pollResultItemHorzMargin = 5;
UISettings.pollPagePaddingLeft = 10;
UISettings.pollPagePaddingTop = 10;
UISettings.pollPagePaddingRight = 10;
UISettings.pollPagePaddingBottom = 10;
UISettings.pollChoiceResultMargin = 10;
UISettings.pollResultAreaWidth = UISettings.pollResultAreaPaddingLeft + UISettings.pollResultAreaPaddingRight +
UISettings.pollResultCountWidth + UISettings.pollResultRatioWidth +
UISettings.pollResultItemHorzMargin;
UISettings.pollChoiceAreaWidthMin = UISettings.pollChoiceAreaPaddingLeft + UISettings.pollChoiceAreaPaddingRight +
UISettings.pollChoiceIconWidth + UISettings.pollChoiceTextWidthMin +
UISettings.pollChoiceItemHorzMargin;
UISettings.pollPageWidthMin = UISettings.pollPagePaddingLeft + UISettings.pollPagePaddingRight +
UISettings.pollChoiceAreaWidthMin + UISettings.pollResultAreaWidth +
UISettings.pollChoiceResultMargin;
UISettings.pollQuestionLabelHeight = 16;
UISettings.pollQuestionLabelBottomMargin = 2;
UISettings.pollQuestionAreaHeight = 80;
UISettings.pollChoiceLabelHeight = 16;
UISettings.pollChoiceLabelTopMargin = 10;
UISettings.pollChoiceLabelBottomMargin = 2;
UISettings.pollChoiceAreaHeightMin = UISettings.pollChoiceAreaPaddingTop + UISettings.pollChoiceAreaPaddingBottom +
( UISettings.pollChoiceItemHeight + UISettings.pollChoiceItemVertMargin ) * UISettings.pollChoiceCountMax;
UISettings.pollStateLabelTopMargin = 2;
UISettings.pollStateLabelHeight = 16;
UISettings.pollPageHeightMin = UISettings.pollPagePaddingTop + UISettings.pollPagePaddingBottom +
UISettings.pollQuestionLabelHeight + UISettings.pollQuestionLabelBottomMargin +
UISettings.pollQuestionAreaHeight +
UISettings.pollChoiceLabelTopMargin + UISettings.pollChoiceLabelHeight +
UISettings.pollChoiceLabelBottomMargin +
UISettings.pollChoiceAreaHeightMin +
UISettings.pollStateLabelTopMargin + UISettings.pollStateLabelHeight;
UISettings.webUrlId = "WebUrl";
UISettings.webWarningId = "WebWarning";
UISettings.webSnapshotBoundId = "WebSnapshotBound";
UISettings.webSnapshotBorderId = "WebSnapshotBorder";
UISettings.webSnapshotId = "WebSnapshot";
UISettings.webBottomRightImageId = "WebBottomRightImage";
UISettings.webSlideUriTooltipId = "WebSlide_UriTooltip";
UISettings.webSlideWarningTextId = "WebSlide_WarningText";
UISettings.webUnavailableUrlId = "WebSlide_UnavailableUrl";
UISettings.webUnavailableUrlWarningTextId = "WebSlide_UnavailableUrlWarningText";
UISettings.webSnapshotPaddingLeft = 10;
UISettings.webSnapshotPaddingTop = 10;
UISettings.webSnapshotPaddingRight = 10;
UISettings.webSnapshotPaddingBottom = 10;
UISettings.tabIndexDisable = -1;
UISettings.tabIndexDefault = 0;
UISettings.tabIndexCategoryList = 10;
UISettings.tabIndexContentIndexList = 20;
UISettings.tabIndexSpeakerIndexList = 21;
UISettings.tabIndexTimeSlider = 30;
UISettings.tabIndexPlayButton = 40;
UISettings.tabIndexPauseButton = 41;
UISettings.tabIndexStopButton = 50;
UISettings.tabIndexPreviousButton = 60;
UISettings.tabIndexNextButton = 70;
UISettings.tabIndexMuteButton = 80;
UISettings.tabIndexUnmuteButton = 81;
UISettings.tabIndexVolumeSlider = 90;
UISettings.tabIndexPaneMenu = 100;
UISettings.WmvError_PlayerNotAvailable = "WmvError_PlayerNotAvailable";
UISettings.WmvError_GetMediaUriFailed = "WmvError_GetMediaUriFailed";
UISettings.WmvError_PublishMediaError = "WmvError_PublishMediaError";
UISettings.WmvError_CodecRequired = "WmvError_CodecRequired";
UISettings.WmvError_PlayFailed = "WmvError_PlayFailed";
UISettings.WmvError_AudioErrorPrefix = "WmvError_AudioErrorPrefix";
UISettings.WmvError_Msa1CodecRequired_InfoText = "WmvError_Msa1CodecRequired_InfoText";
UISettings.WmvError_Msa1CodecRequired_DownloadFormatText = "WmvError_Msa1CodecRequired_DownloadFormatText";
UISettings.WmvError_Msa1CodecRequired_DownloadArgText = "WmvError_Msa1CodecRequired_DownloadArgText";
UISettings.WmvInfo_MediaNotReady = "WmvInfo_MediaNotReady";
UISettings.MmcInfo_InteractionEnabled = "MmcInfo_InteractionEnabled";
UISettings.ErrorHandling_DataPathNotProvided = "ErrorHandling_DataPathNotProvided";
UISettings.ErrorHandling_BadMeetingData = "ErrorHandling_BadMeetingData";
UISettings.ErrorHandling_ActiveXNotSupported = "ErrorHandling_ActiveXNotSupported";
UISettings.ErrorHandling_HttpRequestNotSupported = "ErrorHandling_HttpRequestNotSupported";
UISettings.ErrorHandling_WarningOccurredDuringLoading = "ErrorHandling_WarningOccurredDuringLoading";
UISettings.ErrorHandling_WarningOccurredRuntime = "ErrorHandling_WarningOccurredRuntime";
UISettings.ErrorHandling_BadIndex = "ErrorHandling_BadIndex";
UISettings.ErrorHandling_SVGNotSupported = "ErrorHandling_SVGNotSupported";
UISettings.ErrorHandling_PageNotExist = "ErrorHandling_PageNotExist";
UISettings.ErrorHandling_AnnoNotSupported = "ErrorHandling_AnnoNotSupported";
UISettings.QCIFDefaultWidth = 352;
UISettings.QCIFDefaultHeight = 288;
UISettings.PanoDefaultWidth = 1056;
UISettings.PanoDefaultHeight = 144;
Trace.Wrap( "UISettings" );
var uiSettings = new UISettings();
function AutoCloser( target, timeout )
{
this._target = target;
this._timeout = timeout;
this._closeTimer = null;
this._enabled = true;
this.AutoClosedEvent = new Event();
}
AutoCloser.prototype.LaunchTarget = function()
{
this._target.SetStyle( "visibility", "inherit" );
if( this._closeTimer != null )
{
clearTimeout( this._closeTimer );
this._closeTimer = null;
}
this.Enable( true );
}
AutoCloser.prototype.CloseTarget = function()
{
this._target.SetStyle( "visibility", "hidden" );
this.Enable( false );
}
AutoCloser.prototype._OnTimeout = function()
{
this._closeTimer = null;
this.CloseTarget();
this.AutoClosedEvent();
}
AutoCloser.prototype.Enable = function( enabled )
{
this._enabled = enabled;
if( enabled )
{
if( this._closeTimer == null )
{
this._closeTimer = setTimeout(
Delegate( this, AutoCloser.prototype._OnTimeout ),
this._timeout );
}
}
else
{
if( this._closeTimer != null )
{
clearTimeout( this._closeTimer );
this._closeTimer = null;
}
}
}
function WidgetFitter( registerParentResizedEvent )
{
OOP.CallParentConstructor( this, arguments.callee );
this.childLeft = 0;
this.childTop = 0;
this.childWidth = 100;
this.childHeight = 100;
this.PositionChangedEvent = new Event();
this._fitStyle = "fill";
this._registerParentResizedEvent = true;
this._parentWidget = null;
this._childWidget = null;
this._childOringalSizeChangeHandler =
Delegate( this, WidgetFitter.prototype._ChildOriginalSizeChanged );
this._parentResizeHandler =
Delegate( this, WidgetFitter.prototype._ParentResized );
this._posParams = new Array();
if( registerParentResizedEvent != undefined )
{
this._registerParentResizedEvent = registerParentResizedEvent ;
}
}
WidgetFitter.prototype.Unbind = function()
{
if( this._childWidget )
{
this._childWidget.OriginalSizeChanged.Remove(
this._childOringalSizeChangeHandler );
this._childWidget = null;
}
if( this._parentWidget != null )
{
if( this._registerParentResizedEvent )
{
this._parentWidget._Resized.Remove(
this._parentResizeHandler );
}
this._parentWidget = null;
}
}
WidgetFitter.prototype.Bind = function( parent, child, fitStyle )
{
fitStyle = fitStyle.toLowerCase();
this.Unbind();
this._parentWidget = parent;
this._childWidget = child;
this._childWidget.OriginalSizeChanged.Add(
this._childOringalSizeChangeHandler
);
if( this._registerParentResizedEvent )
{
this._parentWidget._Resized.Add(
this._parentResizeHandler
);
}
this._fitStyle = fitStyle;
var args = Array.FromArguments( arguments );
this._NormalizePositionParameters( args.slice( 3 ) );
this.RecalculatePosition();
}
WidgetFitter.prototype._NormalizePositionParameters = function( params )
{
for( var i=0; i<4; i++ )
{
if( params[i] != null )
{
this._posParams[i] = params[i];
}
else
{
this._posParams[i] = 0;
}
}
}
WidgetFitter.prototype._ChildOriginalSizeChanged = function()
{
this.RecalculatePosition();
}
WidgetFitter.prototype._ParentResized = function()
{
this.RecalculatePosition();
}
WidgetFitter.prototype.RecalculatePosition = function()
{
var func = WidgetFitter.fitFunctions[ this._fitStyle ];
func.call( this );
var paddingLeft = this._posParams[0];
var paddingTop = this._posParams[1];
this.childLeft += paddingLeft;
this.childTop += paddingTop;
this._childWidget.SetUIPosition(
true,
this.childLeft,
this.childTop,
this.childWidth,
this.childHeight );
this.PositionChangedEvent( this._parentWidget, this.childLeft, this.childTop, this.childWidth, this.childHeight );
}
WidgetFitter.prototype._GetParentClientWidth = function()
{
var clientWidth = this._parentWidget.GetClientWidth() - this._posParams[0] - this._posParams[2];
if( clientWidth < 0 )
{
clientWidth = 0;
}
return clientWidth;
}
WidgetFitter.prototype._GetParentClientHeight = function()
{
var clientHeight = this._parentWidget.GetClientHeight() - this._posParams[1] - this._posParams[3];
if( clientHeight < 0 )
{
clientHeight = 0;
}
return clientHeight;
}
WidgetFitter.prototype._FillFit = function()
{
var clientWidth = this._GetParentClientWidth();
var clientHeight = this._GetParentClientHeight();
this.childLeft = 0;
this.childTop = 0;
this.childWidth = clientWidth;
this.childHeight = clientHeight;
}
WidgetFitter.prototype._ProportionalFit = function()
{
var clientWidth = this._GetParentClientWidth();
var clientHeight = this._GetParentClientHeight();
var child = this._childWidget;
var hwRatio = child.GetAspectRatio();
if( clientWidth * hwRatio < clientHeight )
{
this.childWidth = clientWidth;
this.childHeight = clientWidth * hwRatio;
this.childLeft = 0;
this.childTop = ( clientHeight - this.childHeight ) / 2;
}
else
{
this.childWidth = clientHeight / hwRatio;
this.childHeight = clientHeight;
this.childLeft = ( clientWidth - this.childWidth ) / 2;
this.childTop = 0;
}
}
WidgetFitter.prototype._CenterFit = function()
{
var clientWidth = this._GetParentClientWidth();
var clientHeight = this._GetParentClientHeight();
var child = this._childWidget;
var left = 0;
var top = 0;
var width = child._originalWidth;
var height = child._originalHeight;
if( width < clientWidth )
{
left = ( clientWidth - width ) / 2;
}
if( height < clientHeight )
{
top = ( clientHeight - height ) / 2;
}
this.childLeft = left;
this.childTop = top;
this.childWidth = width;
this.childHeight = height;
}
WidgetFitter.prototype._CenterProportionalFit = function()
{
var clientWidth = this._GetParentClientWidth();
var clientHeight = this._GetParentClientHeight();
var child = this._childWidget;
var hwRatio = child.GetAspectRatio();
var left = 0;
var top = 0;
var width = child._originalWidth;
var height = child._originalHeight;
if( width <= clientWidth && height <= clientHeight )
{
this._CenterFit();
}
else
{
this._ProportionalFit();
}
}
WidgetFitter.prototype._TopRightFit = function()
{
var clientWidth = this._GetParentClientWidth();
var clientHeight = this._GetParentClientHeight();
var child = this._childWidget;
var top = 0;
var width = child._originalWidth;
var height = child._originalHeight;
var left = clientWidth - width;
this.childLeft = left;
this.childTop = top;
this.childWidth = width;
this.childHeight = height;
}
WidgetFitter.prototype._TopLeftFit = function()
{
var clientWidth = this._GetParentClientWidth();
var clientHeight = this._GetParentClientHeight();
var child = this._childWidget;
var left = 0;
var top = 0;
var width = child._originalWidth;
var height = child._originalHeight;
this.childLeft = left;
this.childTop = top;
this.childWidth = width;
this.childHeight = height;
}
WidgetFitter.prototype._BottomRightFit = function()
{
var clientWidth = this._GetParentClientWidth();
var clientHeight = this._GetParentClientHeight();
var child = this._childWidget;
var width = child._originalWidth;
var height = child._originalHeight;
var top = clientHeight - height;
var left = clientWidth - width;
this.childLeft = left;
this.childTop = top;
this.childWidth = width;
this.childHeight = height;
}
WidgetFitter.prototype._BottomLeftFit = function()
{
var clientWidth = this._GetParentClientWidth();
var clientHeight = this._GetParentClientHeight();
var child = this._childWidget;
var left = 0;
var width = child._originalWidth;
var height = child._originalHeight;
var top = clientHeight - height;
this.childLeft = left;
this.childTop = top;
this.childWidth = width;
this.childHeight = height;
}
WidgetFitter.fitFunctions = {
"fill":WidgetFitter.prototype._FillFit,
"center":WidgetFitter.prototype._CenterFit,
"center_proportional":WidgetFitter.prototype._CenterProportionalFit,
"proportional":WidgetFitter.prototype._ProportionalFit,
"topright": WidgetFitter.prototype._TopRightFit,
"topleft": WidgetFitter.prototype._TopLeftFit,
"bottomright": WidgetFitter.prototype._BottomRightFit,
"bottomleft": WidgetFitter.prototype._BottomLeftFit
};
Trace.Wrap( "WidgetFitter" );
function PreDownloader( owner )
{
this._owner = owner;
this._counter = -1;
this._isSelfLoad = true;
this.PreloadFinishedEvent = new Event();
}
PreDownloader.prototype.BeginPreDownload = function()
{
this._counter = 0;
for( var i=0; i<this._owner.ownedWidgets.length; i++ )
{
if ( this._owner.ownedWidgets[i].preDownloader != null )
{
this._counter++;
}
}
if ( this._counter > 0 )
{
for( var i=0; i<this._owner.ownedWidgets.length; i++ )
{
if ( this._owner.ownedWidgets[i].preDownloader != null )
{
this._owner.ownedWidgets[i].preDownloader.PreloadFinishedEvent.Add(
Delegate( this, PreDownloader.prototype._OnPreloadFinished ) );
this._owner.ownedWidgets[i].preDownloader.BeginPreDownload();
}
}
}
else
{
this._CheckAndSendEvent();
}
}
PreDownloader.prototype._OnPreloadFinished = function()
{
this._counter--;
this._CheckAndSendEvent();
}
PreDownloader.prototype.BeginSelfLoad = function()
{
this._isSelfLoad = false;
}
PreDownloader.prototype.OnSelfLoad = function()
{
this._isSelfLoad = true;
this._CheckAndSendEvent();
}
PreDownloader.prototype._CheckAndSendEvent = function()
{
if ( ( this._counter == 0 ) && ( this._isSelfLoad == true ) )
{
this._counter = -1;
this.PreloadFinishedEvent();
}
}
Trace.Wrap( "PreDownloader" );
function EventsReadyChecker()
{
OOP.CallParentConstructor( this, arguments.callee );
this._eventCheckers = new Object();
}
EventsReadyChecker.prototype.AddEventReadyCheck = function( event, id, readyHandler )
{
var eventChecker = new Object();
event.Add( DelegateWithArgs( this, EventsReadyChecker.prototype._OnEventReady, id ) );
eventChecker["event"] = event;
eventChecker["readyflag"] = false;
eventChecker["readyevent"] = new Event();
eventChecker["readyevent"].Add( readyHandler );
this._eventCheckers[id] = eventChecker;
}
EventsReadyChecker.prototype.AreAllEventsReady = function()
{
for( var id in this._eventCheckers )
{
if( !this._eventCheckers[ id ]["readyflag"] )
{
return false;
}
}
return true;
}
EventsReadyChecker.prototype._OnEventReady = function( id )
{
if( this._eventCheckers[ id ]["readyflag"] == false )
{
this._eventCheckers[ id ]["readyflag"] = true;
this._eventCheckers[ id ]["readyevent"]();
}
}
EventsReadyChecker.prototype.SetEventReady = function( id )
{
this._OnEventReady( id );
}
function MediaList()
{
this._isParsingUri = false;
this._enableReadyStateChecking = false;
this.GetUriFailed = new Event();
this.GetUriSucceeded = new Event();
}
MediaList.error = new Array();
MediaList.error.AsxLoadFailed = 100;
MediaList.error.AsxNoData = 101;
MediaList.error.AsxNoEntry = 102;
MediaList.error.AsxNoEnoughEntries = 103;
MediaList.error.AsxEntryNoRef = 104;
MediaList.error.AsxEntryNoHref = 105;
MediaList.error.MediaNotReady = 200;
MediaList.error.MediaPublishError = 201;
MediaList.prototype.EnableReadyStateChecking = function( enable )
{
this._enableReadyStateChecking = enable;
}
MediaList.prototype.GetMediaUri = function( uri, entry )
{
if( uri == null || uri.match( /\.xml$/i ) == null )
{
return false;
}
if( typeof( entry ) != "number" )
{
Trace.WriteLine( "Entry in media list is not a number. " + entry );
return false;
}
if( isNaN( entry ) )
{
Trace.WriteLine( "Entry in media list is NaN. " );
return false;
}
if( entry < 0 )
{
return false;
}
this._entry = entry;
var matchResult = uri.match( /(.*[\\\/])[^\\\/]+\.xml/i );
if( matchResult != null )
{
this._xmlListDir = matchResult[1];
}
else
{
this._xmlListDir = "";
}
this._isParsingUri = true;
var asxLoader = new XMLDataBuilder( uri );
asxLoader.ResultGotEvent.Add( DelegateWithArgs( this, MediaList.prototype._LoadAsxSuceeded, uri ) );
asxLoader.ErrorEvent.Add( DelegateWithArgs( this, MediaList.prototype._LoadAsxFailed ) );
asxLoader.Execute();
return true;
}
MediaList.prototype._LoadAsxFailed = function()
{
this._isParsingUri = false;
this.GetUriFailed( MediaList.error.AsxLoadFailed );
}
MediaList.prototype._LoadAsxSuceeded = function( uri, data )
{
this._isParsingUri = false;
if( data == null )
{
this.GetUriFailed( MediaList.error.AsxNoData );
return;
}
if( this._enableReadyStateChecking )
{
var readyState = "ready";
if( data.attributes != null &&
data.attributes.state != null )
{
readyState = data.attributes.state;
}
readyState = readyState.toLowerCase();
var returnNeeded = true;
switch( readyState )
{
case "ready":
returnNeeded = false;
break;
case "notready":
this.GetUriFailed( MediaList.error.MediaNotReady );
break;
default:
this.GetUriFailed( MediaList.error.MediaPublishError );
break;
}
if( returnNeeded )
{
return;
}
}
var entries = data.entry;
if( entries == null )
{
this.GetUriFailed( MediaList.error.AsxNoEntry );
return;
}
if( this._entry >= entries.length )
{
this.GetUriFailed( MediaList.error.AsxNoEnoughEntries );
return;
}
var entryRefs = entries[ this._entry ].ref;
if( entryRefs == null )
{
this.GetUriFailed( MediaList.error.AsxEntryNoRef, "The entry " + this._entry + " in A/V xml file has no child node 'ref'. " );
return;
}
var entryRef = entryRefs[0];
if( entryRef.attributes == null )
{
this.GetUriFailed( MediaList.error.AsxEntryNoHref, "The entry " + this._entry + " in A/V xml file has no attributes. " );
return;
}
var href = entryRef.attributes.href;
if( href == null )
{
this.GetUriFailed( MediaList.error.AsxEntryNoHref, "href attribute of entry node in A/V xml file is null. " );
return;
}
if( !UriUtils.IsUrl( href ) )
{
href = UriUtils.GetFullUri( this._xmlListDir, UriUtils.EncodeUri(href) );
}
else
{
href = UriUtils.EncodeUri( href );
}
this.GetUriSucceeded( href );
}
MediaList.prototype.IsParsingUri = function()
{
return this._isParsingUri;
}
function BasicWidget()
{
this._htmlObject = null;
this.owner = null;
this.ownedWidgets = new Array();
this._Created = new Event();
this._PostCreated = new Event();
this._Resized = new Event();
this._Destroyed = new Event();
this._defaultOriginalWidth = 100;
this._defaultOriginalHeight = 100;
this.OriginalSizeChanged = new Event();
this._originalWidth = this._defaultOriginalWidth;
this._originalHeight = this._defaultOriginalHeight;
this._aspectRatioEnabled = false;
this._registeredEvents = new Array();
this.preDownloader = new PreDownloader( this );
}
BasicWidget.prototype.SetDefaultOriginalSize = function( width, height )
{
this._defaultOriginalWidth = width;
this._defaultOriginalHeight = height;
}
BasicWidget.prototype.ApplyDefaultOriginalSize = function()
{
this.SetOriginalSize(
this._defaultOriginalWidth,
this._defaultOriginalHeight );
}
BasicWidget.prototype.SetOriginalSize = function( width, height )
{
var oldAspectRatio = this.GetAspectRatio();
this._originalWidth = width;
this._originalHeight = height;
var newAspectRatio = this.GetAspectRatio();
this._OnOriginalSizeChanged();
}
BasicWidget.prototype._OnOriginalSizeChanged = function()
{
this.OriginalSizeChanged( this );
}
BasicWidget.prototype.GetAspectRatio = function()
{
return this._originalHeight / this._originalWidth;
}
BasicWidget.prototype.SetItemClassName = function( target, className )
{
this._itemClassNames[ target ] = className;
}
BasicWidget.prototype.SetItemClassNames = function( classNameTable )
{
for( var name in classNameTable )
{
this._itemClassNames[ name ] = classNameTable[ name ];
}
}
BasicWidget.prototype.Length2Value = function( side, objectLength )
{
if( objectLength == null )
{
return 0;
}
side = side.toLowerCase();
var INCH_PIXEL = 96;
if( navigator.appName == "Microsoft Internet Explorer" )
{
var oWindow = this._htmlObject.ownerDocument.parentWindow;
if( side == "width" )
{
INCH_PIXEL = oWindow.screen.logicalXDPI;
}
else
{
INCH_PIXEL = oWindow.screen.logicalYDPI;
}
}
else
{
INCH_PIXEL = 120;
}
var val = parseFloat( objectLength );
var unitMatchResult = objectLength.match( /\d([^\d]*)$/ );
if( unitMatchResult == null )
{
return 0;
}
if( unitMatchResult.length < 2 )
{
unitMatchResult[1] = "";
}
var unit = unitMatchResult[1];
switch( unit )
{
case "%":
var parentLength = 0;
if( side == "width" )
{
parentLength = parseFloat( this._htmlObject.parentNode.clientWidth );
}
else
{
parentLength = parseFloat( this._htmlObject.parentNode.clientHeight );
}
val *= parentLength / 100.0;
break;
case "em":
alert( "It is not implemented yet. " );
break;
case "ex":
alert( "It is not implemented yet. " );
break;
case "in":
val *= INCH_PIXEL;
break;
case "pt":
val *= INCH_PIXEL / 72.0;
break;
case "pc":
val *= INCH_PIXEL / 6.0;
break;
case "mm":
val *= INCH_PIXEL / 2.54;
break;
case "cm":
val *= INCH_PIXEL / 0.254;
break;
default:
break;
}
return val;
}
BasicWidget.prototype.GetId = function()
{
return this._htmlObject.id;
}
BasicWidget.prototype.IsCreated = function()
{
return ( this._htmlObject != null );
}
BasicWidget.prototype._InitSettings = function()
{
this._htmlObject._WIDGET_ = this;
}
BasicWidget.prototype.AttachById = function( id, ownerWidget )
{
var obj = document.getElementById( id );
this.Attach( obj, ownerWidget );
}
BasicWidget.prototype.Attach = function( htmlObject, ownerWidget )
{
this._htmlObject = htmlObject;
if( ownerWidget )
{
this.SetOwner( ownerWidget );
}
this._InitSettings();
this._OnCreate();
}
BasicWidget.prototype.CreateElement = function( elementName, parentWidget, id )
{
var currentDocument = null;
if( !parentWidget )
{
currentDocument = document;
}
else
{
currentDocument = parentWidget._htmlObject.ownerDocument;
}
var obj = currentDocument.createElement( elementName );
if( id != null )
{
obj.setAttribute( "id", id );
}
BasicWidget._SetParent( obj, parentWidget );
this.Attach( obj, parentWidget );
}
BasicWidget.prototype.Create = function( parentWidget, id )
{
this.CreateElement( "div", parentWidget, id );
}
BasicWidget._SetParent = function( htmlObject, parentWidget )
{
if( parentWidget )
{
parentWidget._htmlObject.appendChild( htmlObject );
}
else
{
document.body.appendChild( htmlObject );
}
}
BasicWidget.prototype.SetOwner = function( owner )
{
owner.ownedWidgets.push( this );
this.owner = owner;
}
BasicWidget.prototype.Destroy = function()
{
for( var i=0; i<this.ownedWidgets.length; i++ )
{
this.ownedWidgets[i].Destroy();
}
this.ownedWidgets = [];
for( var i=0; i<this._registeredEvents.length; i++ )
{
var eventName = this._registeredEvents[ i ];
this._htmlObject[ eventName ] = null;
}
this._OnDestroy();
this._htmlObject._WIDGET_ = null;
this._htmlObject = null;
this.owner = null;
}
BasicWidget.prototype.RegisterEvent = function( eventName, eventFunc )
{
this._htmlObject[ eventName ] = eventFunc;
this._registeredEvents.push( eventName );
}
BasicWidget.prototype._OnCreate = function()
{
this._Created();
this._PostCreated();
}
BasicWidget.prototype._OnResize = function()
{
if( this.IsCreated() )
{
this._Resized();
}
}
BasicWidget.prototype._OnDestroy = function()
{
this._Destroyed();
}
BasicWidget.prototype._IsNonNagativeNumber = function( num )
{
if( parseFloat( num ) >= 0 )
{
return true;
}
else
{
return false;
}
}
BasicWidget.prototype.GetNonClientWidth = function()
{
return (
this.Length2Value( "width", this.GetStyle( "borderLeftWidth" ) ) +
this.Length2Value( "width", this.GetStyle( "borderRightWidth" ) ) +
this.Length2Value( "width", this.GetStyle( "paddingLeft" ) ) +
this.Length2Value( "width", this.GetStyle( "paddingRight" ) ) );
}
BasicWidget.prototype.GetNonClientHeight = function()
{
return (
this.Length2Value( "height", this.GetStyle( "borderTopWidth" ) ) +
this.Length2Value( "height", this.GetStyle( "borderBottomWidth" ) ) +
this.Length2Value( "height", this.GetStyle( "paddingTop" ) ) +
this.Length2Value( "height", this.GetStyle( "paddingBottom" ) ) );
}
BasicWidget.prototype.SetLeft = function( left )
{
this._htmlObject.style.left = left;
}
BasicWidget.prototype.SetTop = function( top )
{
this._htmlObject.style.top = top;
}
BasicWidget.prototype.SetWidth = function( width, holdRefresh )
{
if( !isNaN(width) )
{
if( !NavigatorInfo.IsIE() )
{
width -=
this.Length2Value( "width", this.GetStyle( "borderLeftWidth" ) ) +
this.Length2Value( "width", this.GetStyle( "borderRightWidth" ) ) +
this.Length2Value( "width", this.GetStyle( "paddingLeft" ) ) +
this.Length2Value( "width", this.GetStyle( "paddingRight" ) );
}
if( width < 0 )
{
Trace.WriteLine( "The width " + width + " is less than 0. " );
return;
}
}
this._htmlObject.style.width = width;
if( !holdRefresh )
{
this._OnResize();
}
}
BasicWidget.prototype.SetHeight = function( height, holdRefresh )
{
if( !isNaN(height) )
{
if( !NavigatorInfo.IsIE() )
{
height -=
this.Length2Value( "height", this.GetStyle( "borderTopWidth" ) ) +
this.Length2Value( "height", this.GetStyle( "borderBottomWidth" ) ) +
this.Length2Value( "height", this.GetStyle( "paddingTop" ) ) +
this.Length2Value( "height", this.GetStyle( "paddingBottom" ) );
}
if( height < 0 )
{
Trace.WriteLine( "The height " + height + " is less than 0. " );
return;
}
}
this._htmlObject.style.height = height;
if( !holdRefresh )
{
this._OnResize();
}
}
BasicWidget.prototype.SetSize = function( width, height, holdRefresh )
{
this.SetWidth( width, true );
this.SetHeight( height, holdRefresh );
}
BasicWidget.prototype.SetLocation = function( left, top )
{
this.SetLeft( left );
this.SetTop( top );
}
BasicWidget.prototype.SetUIPosition = function( isAbsolute, left, top, width, height, holdRefresh )
{
Trace.WriteLine( "SetUIPosition parameters: %1, %2, %3, %4, %5",
isAbsolute, left, top, width, height );
if( isAbsolute )
{
this._htmlObject.style.position = "absolute";
}
else
{
this._htmlObject.style.position = "relative";
}
this.SetLeft( left );
this.SetTop( top );
this.SetWidth( width, true );
this.SetHeight( height, true );
if( !holdRefresh )
{
this._OnResize();
}
}
BasicWidget.prototype.ResetStyle = function( styleName )
{
this._htmlObject.style[ BasicWidget.ConvertStyleName(styleName) ] = "";
}
BasicWidget.prototype.SetStyle = function( styleName, styleValue )
{
this._htmlObject.style[ BasicWidget.ConvertStyleName(styleName) ] = styleValue;
}
BasicWidget.prototype.GetStyle = function( styleName )
{
return BasicWidget.GetHtmlObjectStyle( styleName, this._htmlObject );
}
BasicWidget.prototype.SetAttribute = function( attrName, attrValue )
{
this._htmlObject[ attrName ] = attrValue;
}
BasicWidget.prototype.GetAttribute = function( attrName )
{
return this._htmlObject[ attrName ];
}
BasicWidget.prototype.SetBorderWidth = function( leftWidth, topWidth, rightWidth, bottomWidth, holdRefresh )
{
this._htmlObject.style.borderLeftWidth = leftWidth;
this._htmlObject.style.borderTopWidth = topWidth;
this._htmlObject.style.borderRightWidth = rightWidth;
this._htmlObject.style.borderBottomWidth = bottomWidth;
if( !holdRefresh )
{
this._OnResize();
}
}
BasicWidget.prototype.SetBorder = function( style, left, top, right, bottom, holdRefresh )
{
this.SetStyle( "borderStyle",  style );
this.SetBorderWidth( left, top, right, bottom, holdRefresh );
}
BasicWidget.prototype.SetPadding = function( paddingLeft, paddingTop, paddingRight, paddingBottom, holdRefresh )
{
this._htmlObject.style.paddingLeft = paddingLeft;
this._htmlObject.style.paddingTop = paddingTop;
this._htmlObject.style.paddingRight = paddingRight;
this._htmlObject.style.paddingBottom = paddingBottom;
if( !holdRefresh )
{
this._OnResize();
}
}
BasicWidget.prototype.GetClientWidth = function()
{
var clientWidth = 0;
clientWidth = parseFloat( this._htmlObject.clientWidth );
clientWidth -=
this.Length2Value( "width", this.GetStyle( "paddingLeft" ) ) +
this.Length2Value( "width", this.GetStyle( "paddingRight" ) );
return clientWidth;
}
BasicWidget.prototype.GetClientHeight = function()
{
var clientHeight = 0;
clientHeight = parseFloat( this._htmlObject.clientHeight );
clientHeight -=
this.Length2Value( "height", this.GetStyle( "paddingTop" ) ) +
this.Length2Value( "height", this.GetStyle( "paddingBottom" ) );
return clientHeight;
}
BasicWidget.prototype.GetLeft = function()
{
var length = this._htmlObject.offsetLeft;
return length;
}
BasicWidget.prototype.GetTop = function()
{
var length = this._htmlObject.offsetTop;
return length;
}
BasicWidget.prototype.GetWidth = function()
{
var width = this._htmlObject.offsetWidth;
return width;
}
BasicWidget.prototype.GetHeight = function()
{
var height = this._htmlObject.offsetHeight;
return height;
}
BasicWidget.prototype.GetWidthWithMargin = function()
{
var width = 0;
width = this.GetWidth() +
this.Length2Value( "width",  this.GetStyle( "marginLeft" ) ) +
this.Length2Value( "width",  this.GetStyle( "marginRight" ) );
return width;
}
BasicWidget.prototype.GetHeightWithMargin = function()
{
var height = 0;
height = this.GetHeight() +
this.Length2Value( "height",  this.GetStyle( "marginTop" ) ) +
this.Length2Value( "height",  this.GetStyle( "marginBottom" ) );
return height;
}
BasicWidget.prototype.GetPaddedWidth = function()
{
var paddingWidth = 0;
paddingWidth = this.GetWidth() -
this.Length2Value( "width",  this.GetStyle( "borderLeftWidth" ) ) -
this.Length2Value( "width",  this.GetStyle( "borderRightWidth" ) );
return paddingWidth;
}
BasicWidget.prototype.GetPaddedHeight = function()
{
var paddingHeight = 0;
paddingHeight = this.GetHeight() -
this.Length2Value( "height",  this.GetStyle( "borderTopWidth" ) ) -
this.Length2Value( "height",  this.GetStyle( "borderBottomWidth" ) );
return paddingHeight;
}
BasicWidget.prototype.GetScrollLeft = function()
{
var scrollLeft = 0;
scrollLeft = this._htmlObject.scrollLeft;
return scrollLeft;
}
BasicWidget.prototype.GetScrollTop = function()
{
var scrollTop = 0;
scrollTop = this._htmlObject.scrollTop;
return scrollTop;
}
BasicWidget.prototype.GetScrollWidth = function()
{
var scrollWidth = 0;
scrollWidth = this._htmlObject.scrollWidth;
return scrollWidth;
}
BasicWidget.prototype.GetScrollHeight = function()
{
var scrollHeight = 0;
scrollHeight = this._htmlObject.scrollHeight;
return scrollHeight;
}
BasicWidget.prototype.FindHtmlChild = function( obj )
{
var parentNode = obj.parentNode;
while( parentNode != this._htmlObject && parentNode != null && parentNode != window )
{
parentNode = parentNode.parentNode;
}
var found = false;
if( parentNode == this._htmlObject )
{
found = true;
}
return found;
}
BasicWidget.prototype.GetTopInBody = function()
{
return BasicWidget._GetCoordInBody( this._htmlObject, "Top" );
}
BasicWidget.prototype.GetLeftInBody = function()
{
return BasicWidget._GetCoordInBody( this._htmlObject, "Left" );
}
BasicWidget.prototype._GetChildObjectEventString = function( objId, eventName )
{
var str = "<script language='JScript' for=" + objId + " event=\"" + eventName + "\">" +
"try{ var obj = document.getElementById( '" + objId + "' );" +
"var widget = obj.parentNode._WIDGET_;" +
"widget._" + eventName + ";}catch( e ){}</script>";
return str;
}
BasicWidget.prototype.SetTabIndex = function( index )
{
if(this._htmlObject)
{
this._htmlObject.tabIndex = index;
}
}
BasicWidget.prototype.GetTabIndex = function( )
{
if(this._htmlObject)
{
return this._htmlObject.tabIndex;
}
else
{
return -1;
}
}
BasicWidget.prototype.SetFocus = function()
{
if(this._htmlObject)
{
try
{
this._htmlObject.focus();
}
catch (ex)
{
}
}
}
BasicWidget.prototype.SetFocusDashedBorder = function()
{
if( this._htmlObject )
{
var margin = parseFloat( this.GetStyle("marginTop") );
if( margin == 0 )
{
this.SetStyle("marginTop", 1 );
}
margin = parseFloat( this.GetStyle("marginBottom") );
if( margin == 0 )
{
this.SetStyle("marginBottom", 1 );
}
margin = parseFloat( this.GetStyle("marginLeft") );
if( margin == 0 )
{
this.SetStyle("marginLeft", 1);
}
margin = parseFloat( this.GetStyle("marginRight") );
if( margin == 0 )
{
this.SetStyle("marginRight", 1);
}
}
}
BasicWidget.GetOriginalEvent = function( eventObj, srcObj )
{
if( NavigatorInfo.IsIE() )
{
var oWindow = srcObj.ownerDocument.parentWindow;
eventObj = oWindow.event;
}
return eventObj;
}
BasicWidget.TranslateEvent = function( eventObj, srcObj )
{
var result = null;
if( NavigatorInfo.IsIE() )
{
var oWindow = srcObj.ownerDocument.parentWindow;
eventObj = oWindow.event;
}
Trace.WriteData( eventObj, 1 );
if( NavigatorInfo.IsIE() )
{
result = eventObj;
}
else
{
result = new Object();
var srcElement = null;
if( eventObj.originalTarget )
{
srcElement = eventObj.originalTarget;
}
else
{
srcElement = eventObj.srcElement;
}
Trace.WriteData( srcElement, 1 );
result.offsetX = eventObj.layerX;
result.offsetY = eventObj.layerY;
result.clientX = eventObj.clientX;
result.clientY = eventObj.clientY;
result.screenX = eventObj.screenX;
result.screenY = eventObj.screenY;
result.button = eventObj.which;
result.srcElement = srcElement;
result.keyCode = eventObj.which;
}
return result;
}
BasicWidget._GetCoordInBody = function( htmlObj, dir )
{
var oDocument = htmlObj.ownerDocument;
var coord = 0;
var dirName = "offset" + dir;
var offsetParent = "offsetParent";
while( htmlObj != oDocument.body && htmlObj != oDocument )
{
coord += htmlObj[ dirName ];
if( htmlObj[ offsetParent ] == null )
{
alert( "Get the " + dirName + " of htmlObject failed. " );
return -1;
}
htmlObj = htmlObj[ offsetParent ];
}
return coord;
}
BasicWidget.GetKey = function( keyEvent )
{
return keyEvent.keyCode;
}
BasicWidget.IsHiddenInBody = function( htmlObj, checkDisplayStyle )
{
if( htmlObj == null )
{
return true;
}
var oDocument = htmlObj.ownerDocument;
var oWindow = null;
if(NavigatorInfo.IsIE())
{
oWindow = oDocument.parentWindow;
}
else
{
oWindow = oDocument.defaultView;
}
var isHidden = false;
while( oWindow != null )
{
while( htmlObj != oDocument.body && htmlObj != oDocument )
{
if( BasicWidget.GetHtmlObjectStyle( "visibility", htmlObj ) == "hidden" )
{
isHidden = true;
break;
}
if( checkDisplayStyle && BasicWidget.GetHtmlObjectStyle("display",htmlObj) == "none" )
{
isHidden = true;
break;
}
if( htmlObj.parentNode == null )
{
isHidden = true;
break;
}
htmlObj = htmlObj.parentNode;
}
if(oWindow == window)
{
break;
}
htmlObj = oWindow.frameElement;
oWindow = oWindow.parent;
if(htmlObj == null)
{
break;
}
oDocument = htmlObj.ownerDocument;
}
return isHidden;
}
BasicWidget.ConvertStyleName = function( styleName )
{
if(NavigatorInfo.IsSafari())
{
var reg = new RegExp("[A-Z]","g");
return styleName.replace(reg,function( $0 ){ return ("-"+$0).toLowerCase();});
}
else
{
return styleName;
}
}
BasicWidget.GetHtmlObjectStyle = function( styleName, htmlObject )
{
var styleValue = "";
if( NavigatorInfo.IsIE() )
{
styleValue = htmlObject.currentStyle[ styleName ];
}
else
if( NavigatorInfo.IsSafari() )
{
var oDocument = htmlObject.ownerDocument;
var style = oDocument.defaultView.getComputedStyle( htmlObject, null );
if( style == null )
{
styleValue = "";
}
else
{
styleValue = style.getPropertyValue( this.ConvertStyleName(styleName) );
}
}
else
{
var oDocument = htmlObject.ownerDocument;
var style = oDocument.defaultView.getComputedStyle( htmlObject, null );
styleValue = style[ styleName ];
}
return styleValue;
}
Trace.Wrap( "BasicWidget" );
function IFrameWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._iframe = null;
this._src = null;
this.iframeIsLoaded = false;
this.iframeLoadedEvent = new Event();
this._Created.Add( Delegate( this, IFrameWidget.prototype._WidgetCreated ) );
this._Destroyed.Add( Delegate( this, IFrameWidget.prototype._WidgetDestroyed ) );
}
OOP.Inherit( IFrameWidget, BasicWidget );
IFrameWidget.defaultBlankPageUri = "BlankWithCss.htm";
IFrameWidget.prototype._WidgetCreated = function()
{
var currentDocument = this._htmlObject.ownerDocument;
var oIFrame = currentDocument.createElement( "iframe" );
oIFrame.frameBorder = "no";
oIFrame.style.position = "absolute";
oIFrame.style.width = "100%";
oIFrame.style.height = "100%";
oIFrame.style.visibility = "hidden";
if( NavigatorInfo.IsIE() )
{
Object.RegisterDomEvent( oIFrame, "onreadystatechange", Delegate(this,IFrameWidget.prototype._OnIFrameLoad ) );
}
else
{
Object.RegisterDomEvent( oIFrame, "onload", Delegate(this,IFrameWidget.prototype._OnIFrameLoad ) );
}
if( this._src == null )
{
oIFrame.src = IFrameWidget.defaultBlankPageUri;
}
else
{
oIFrame.src = this._src;
}
this._htmlObject.appendChild(oIFrame);
this._iframe = oIFrame;
oIFrame = null;
}
IFrameWidget.prototype._WidgetDestroyed = function()
{
if ( !this._iframe )
{
return;
}
try
{
if ( this._iframe.contentWindow != null &&
this._iframe.contentWindow.document != null )
{
Object.UnregisterAllEvents( this._iframe.contentWindow.document );
}
}
catch( e )
{
}
Object.UnregisterAllEvents( this._iframe );
this._iframe = null;
}
IFrameWidget.prototype.SetIFrameSrc = function( src )
{
this._src = src;
if( this._iframe != null )
{
this._iframe.src = src;
}
}
IFrameWidget.prototype.CreateChildWidget = function( childWidget, id )
{
var currentDocument = this._iframe.contentWindow.document;
var oDiv = currentDocument.createElement("div");
oDiv.id = id;
oDiv.style.position = "absolute";
oDiv.style.overflow = "hidden";
oDiv.style.width = "100%";
oDiv.style.height = "100%";
oDiv.style.left = 0;
oDiv.style.top = 0;
currentDocument.body.appendChild( oDiv );
childWidget.Attach( oDiv, this );
}
IFrameWidget.prototype.SetIFrameBodyStyle = function( styleName, styleValue )
{
this._iframe.contentWindow.document.body.style[ BasicWidget.ConvertStyleName(styleName) ] = styleValue;
}
IFrameWidget.prototype._OnIFrameLoad = function( parentWidget )
{
if( NavigatorInfo.IsIE() )
{
if( this._iframe.readyState != "complete" )
{
return;
}
}
Object.RegisterDomEvent( this._iframe.contentWindow.document, "onclick",
Delegate( this, IFrameWidget.prototype._OnContentClick ) );
Object.RegisterDomEvent( this._iframe.contentWindow.document, "oncontextmenu",
Delegate( this, IFrameWidget.prototype._OnContextMenu ) );
Object.RegisterDomEvent( this._iframe.contentWindow.document, "onmousemove",
Delegate( this, IFrameWidget.prototype._OnMouseMove ) );
Object.RegisterDomEvent( this._iframe.contentWindow.document, "onmouseup",
Delegate( this, IFrameWidget.prototype._OnMouseUp ) );
this._iframe.style.visibility = "inherit";
this.iframeIsLoaded = true;
this.iframeLoadedEvent();
}
IFrameWidget.prototype._OnContentClick = function()
{
UIManager.ChildClickedEvent();
}
IFrameWidget.prototype._OnContextMenu = function()
{
return false;
}
IFrameWidget.prototype._OnMouseMove = function( eventObj )
{
var screenX = 0;
var screenY = 0;
if( NavigatorInfo.IsIE() )
{
screenX = this._iframe.contentWindow.event.screenX;
screenY = this._iframe.contentWindow.event.screenY;
}
else
{
eventObj = BasicWidget.TranslateEvent( eventObj, null );
screenX = eventObj.screenX;
screenY = eventObj.screenY;
}
UIManager.MouseMoveEvent( screenX, screenY );
}
IFrameWidget.prototype._OnMouseUp = function()
{
UIManager.OnMouseUp();
}
Trace.Wrap( "IFrameWidget" );
function InfoIconWidgetFactory()
{
}
InfoIconWidgetFactory.GetInfoIconWidget = function( useIFrame, parent )
{
if( useIFrame )
{
var iframeObject = new InfoIconIFrameWidget();
iframeObject.Create( parent );
return iframeObject;
}
else
{
var imageObject = new InfoIconImageWidget();
imageObject.Create( parent );
return imageObject;
}
}
Trace.Wrap( "InfoIconWidgetFactory" );
function InfoIconImageWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._iconImage = new ImageWidget();
this.iconImageClickedEvent = new Event();
this.LoadedEvent = new Event();
this.isLoaded = false;
}
InfoIconImageWidget.prototype.Create = function( parent )
{
this._iconImage.Create( parent );
this._iconImage.ImageLoadedEvent.Add( Delegate( this, InfoIconImageWidget.prototype._IconImageLoaded ) );
this._iconImage.SetURI( uiSettings.GetImage( "information" ), true );
this._iconImage.RegisterEvent("onclick", Delegate( this, InfoIconImageWidget.prototype._OnClick ) );
this.isLoaded = true;
this.LoadedEvent();
}
InfoIconImageWidget.prototype._OnClick = function()
{
this.iconImageClickedEvent();
}
InfoIconImageWidget.prototype._IconImageLoaded = function()
{
this._iconImage._OnResize();
}
InfoIconImageWidget.prototype.GetIconWidget = function()
{
return this._iconImage;
}
InfoIconImageWidget.prototype.SetInformation = function( infoString )
{
this._iconImage.SetAttribute(
"title",
infoString );
}
Trace.Wrap( "InfoIconImageWidget" );
function InfoIconIFrameWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._iconIFrame = new IFrameWidget();
this._iconContainer = new BasicWidget();
this._iconImage = new ImageWidget();
this.iconImageClickedEvent = new Event();
this.LoadedEvent = new Event();
this.isLoaded = false;
}
InfoIconIFrameWidget.prototype.Create = function( parent )
{
this._iconIFrame.iframeLoadedEvent.Add( Delegate(this, InfoIconIFrameWidget.prototype._OnIconIFrameLoad) );
this._iconIFrame.Create( parent );
this._iconIFrame.SetStyle("visibility","hidden");
}
InfoIconIFrameWidget.prototype._OnIconIFrameLoad = function()
{
this._iconIFrame.SetIFrameBodyStyle("backgroundColor","transparent");
this._iconIFrame.CreateChildWidget( this._iconContainer );
this._iconContainer.SetStyle("backgroundColor","transparent");
this._iconImage.Create( this._iconContainer );
this._iconImage.ImageLoadedEvent.Add( Delegate( this, InfoIconIFrameWidget.prototype._IconImageLoaded ) );
this._iconImage.SetURI( uiSettings.GetImage( "information" ) );
this._iconImage.RegisterEvent("onclick", Delegate( this, InfoIconIFrameWidget.prototype._OnClick ) );
this.isLoaded = true;
this.LoadedEvent();
}
InfoIconIFrameWidget.prototype._OnClick = function()
{
this.iconImageClickedEvent();
}
InfoIconIFrameWidget.prototype._IconImageLoaded = function()
{
var width = this._iconImage._originalWidth;
var height = this._iconImage._originalHeight;
this._iconIFrame.SetOriginalSize( width, height );
this._iconIFrame._OnResize();
}
InfoIconIFrameWidget.prototype.GetIconWidget = function()
{
return this._iconIFrame;
}
InfoIconIFrameWidget.prototype.SetInformation = function( infoString )
{
this._iconImage.SetAttribute(
"title",
infoString );
}
Trace.Wrap( "InfoIconImageWidget" );
function InformationWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._infoObject = null;
this._fitter = new WidgetFitter();
this._textArea = new TextWidget();
this._infoString = null;
this.InformationVisibilityChanged = new Event();
}
InformationWidget.prototype.Create = function( parent )
{
this._infoObject = InfoIconWidgetFactory.GetInfoIconWidget( !NavigatorInfo.IsIE(), parent );
this._textArea.Create(parent);
this._textArea.SetPadding(20, 0, 0, 0);
this._textArea._htmlObject.style.width = "100%";
if( !this._infoObject.isLoaded )
{
this._infoObject.LoadedEvent.Add(
Delegate( this, InformationWidget.prototype.InfoObjectLoaded ) );
}
}
InformationWidget.prototype.GetHeight = function()
{
return this._textArea.GetHeight();
}
InformationWidget.prototype.Bind = function( parent, fitStyle )
{
var args = Array.FromArguments( arguments );
var posParams = args.slice( 2 );
var fitterArgs = [ parent, this._infoObject.GetIconWidget(), fitStyle ];
fitterArgs = fitterArgs.concat( posParams );
this._fitter.Bind.apply(
this._fitter,
fitterArgs );
}
InformationWidget.prototype.ShowInformation = function( infoText, downloadFormatText, downloadArgText, downloadArgUrl )
{
if( infoText == null )
{
downloadArgUrl = null;
}
this._infoString = infoText;
if (downloadArgUrl != null && downloadArgUrl != "undefined" && downloadArgUrl != "")
{
var downloadAnchor = "<a href='" + downloadArgUrl + "'>" + TextWidget.GetSafeText(downloadArgText) + "</a>";
var downloadHtml = FormatString(TextWidget.GetSafeText(downloadFormatText), downloadAnchor);
var fullText = TextWidget.GetSafeText(infoText) + "<br/><br/>" + downloadHtml;
this._textArea._htmlObject.innerHTML = fullText;
}
else
{
this._textArea._htmlObject.innerHTML = "";
}
if( this._infoObject.isLoaded )
{
this._InnerShowInformation();
}
}
InformationWidget.prototype.InfoObjectLoaded = function()
{
this._InnerShowInformation();
}
InformationWidget.prototype._InnerShowInformation = function()
{
if( this._infoString )
{
this._SetInformation( this._infoString );
this._infoObject.GetIconWidget().SetStyle( "visibility", "inherit" );
this._textArea.SetStyle("visibility", "inherit");
}
else
{
this._SetInformation( "" );
this._infoObject.GetIconWidget().SetStyle( "visibility", "hidden" );
this._textArea.SetStyle("visibility", "hidden");
}
setTimeout( this.InformationVisibilityChanged, 0 );
}
InformationWidget.prototype._SetInformation = function( infoString )
{
this._infoObject.SetInformation( infoString );
}
InformationWidget.prototype.IsShown = function()
{
var visibility = this._infoObject.GetIconWidget().GetStyle("visibility");
if( visibility == "hidden" )
{
return false;
}
else
{
return true;
}
}
Trace.Wrap( "InformationWidget" );
function ClipWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._clipFitter = new WidgetFitter();
this._contentFitter = new WidgetFitter();
this._clip = new IFrameWidget();
this._clippedWidget = null;
this._clipEnabled = true;
this.clippedWidgetCreatedEvent = new Event();
this.iframeLoadedEvent.Add( Delegate( this, ClipWidget.prototype._WidgetCreated ) );
this._Destroyed.Add(Delegate(this, ClipWidget.prototype._WidgetDestroyed));
}
OOP.Inherit( ClipWidget, IFrameWidget );
ClipWidget.defaultBlankPageUri = "ClipWidget.htm";
ClipWidget.prototype._WidgetCreated = function()
{
this._clipIFrameLoaded = false;
this._clip.SetIFrameSrc(ClipWidget.defaultBlankPageUri);
this._clip.iframeLoadedEvent.Add( Delegate(this, ClipWidget.prototype._OnClipIFrameLoad) );
this.CreateChildWidget( this._clip );
}
ClipWidget.prototype._WidgetDestroyed = function()
{
this._clippedWidget = null;
this._clip = null;
}
ClipWidget.prototype._OnClipIFrameLoad = function()
{
this._clip.SetIFrameBodyStyle( "overflow","hidden" );
}
ClipWidget.prototype.CreateClippedWidget = function( widget, id )
{
if( this._clip.iframeIsLoaded )
{
this._CreateClippedWidgetInIFrame( widget, id );
}
else
{
this._clip.iframeLoadedEvent.Add(
DelegateWithArgs(this,ClipWidget.prototype._CreateClippedWidgetInIFrame, widget,id )
);
}
}
ClipWidget.prototype.SetClipRect = function( clipLeft, clipTop, clipWidth, clipHeight, holdRefresh )
{
if( clipWidth < 0 || clipHeight < 0 )
{
return;
}
this._clip.SetOriginalSize( clipWidth, clipHeight );
this._CalculatePosition( clipLeft, clipTop );
}
ClipWidget.prototype.EnableClip = function( enableClip )
{
this._clipEnabled = enableClip;
if( this._clippedWidget != null )
{
this._InnerEnableClip( enableClip );
}
}
ClipWidget.prototype._InnerEnableClip = function( enableClip )
{
if( enableClip )
{
this._clipFitter.Bind( this, this._clip, "center" );
this._contentFitter.Unbind();
}
else
{
if( NavigatorInfo.IsFirefox() )
{
this._clipFitter.Bind( this, this._clip, "center" );
}
else
{
this._clipFitter.Bind( this, this._clip, "fill" );
}
this._contentFitter.Bind( this._clip, this._clippedWidget, "fill" );
}
}
ClipWidget.prototype._CalculatePosition = function( clipLeft, clipTop )
{
if( this._clippedWidget == null )
{
return;
}
if( this._clipEnabled )
{
this._clip.SetSize(
this._clip._originalWidth,
this._clip._originalHeight );
this._clippedWidget.SetUIPosition(
true,
-clipLeft,
-clipTop,
this._clippedWidget._originalWidth,
this._clippedWidget._originalHeight );
}
else
{
if( NavigatorInfo.IsFirefox() )
{
this._clip.SetSize(
this._clip._originalWidth,
this._clip._originalHeight );
}
else
{
}
}
}
ClipWidget.prototype._CreateClippedWidgetInIFrame = function( widget, id )
{
this._clip.CreateChildWidget( widget, id );
widget.SetStyle( "visibility", "hidden" );
this._clippedWidget = widget;
this._OnContentCreated();
}
ClipWidget.prototype._OnContentCreated = function()
{
this._InnerEnableClip( this._clipEnabled );
this.clippedWidgetCreatedEvent();
}
Trace.Wrap( "ClipWidget" );
function UIManagerImpl()
{
OOP.CallParentConstructor( this, arguments.callee );
this.backgroundFrame = new BasicWidget();
this.backgroundHelper = new BasicWidget();
this.WindowResizedEvent = new Event();
this.DocumentClickedEvent = new Event();
this.ChildClickedEvent = new Event();
this.MouseMoveEvent = new Event();
this.MouseUpEvent = new Event();
this.RefreshScreenEvent = new Event();
this._discardFrame = new BasicWidget();
this.zoomLevel = 1;
}
UIManagerImpl.prototype.Create = function()
{
Object.RegisterDomEvent( window, "onresize", Delegate( this, this.OnWindowResized ) );
Object.RegisterDomEvent( document, "onclick", Delegate( this, this.OnDocumentClicked ) );
Object.RegisterDomEvent( document, "onmousemove", Delegate( this, this.OnMouseMove ) );
Object.RegisterDomEvent( document, "onmouseup", Delegate( this, this.OnMouseUp ) );
this.backgroundHelper.Create( null );
this.backgroundHelper.SetUIPosition(true,0,0,1,1);
this.backgroundHelper.SetStyle( "visibility", "hidden" );
this.backgroundHelper.SetStyle( "overflow", "hidden" );
if( NavigatorInfo.IsIE() )
{
this.backgroundHelper.RegisterEvent("onclick", Delegate( this, UIManagerImpl.prototype._CalculateZoomLevel ));
}
this.backgroundFrame.Create( this.backgroundHelper );
this.backgroundFrame.SetSize( 10000, 10000 );
this._discardFrame.Create( this.backgroundHelper );
this._discardFrame.SetSize( 100, 100 );
}
UIManagerImpl.prototype._CalculateZoomLevel = function()
{
var eventObj = window.event;
var offsetX = eventObj.offsetX;
var clientX = eventObj.clientX;
if( offsetX != 0 )
{
this.zoomLevel = Math.floor((clientX/offsetX)*100)/100;
}
}
UIManagerImpl.prototype._FireOnClickEvent = function()
{
var eventObj = document.createEventObject();
eventObj.offsetX = 2048;
eventObj.offsetY = 0;
this.backgroundHelper._htmlObject.fireEvent( "onclick", eventObj );
}
UIManagerImpl.prototype.DiscardDomElement = function( obj )
{
this._discardFrame._htmlObject.appendChild( obj );
this._discardFrame.SetAttribute( "innerHTML", "" );
}
UIManagerImpl.prototype.Destroy = function()
{
this.backgroundHelper.Destroy();
}
UIManagerImpl.prototype.OnWindowResized = function()
{
if( NavigatorInfo.IsIE() )
{
this._FireOnClickEvent();
}
this.WindowResizedEvent();
}
UIManagerImpl.prototype.OnDocumentClicked = function( eventObj )
{
eventObj = BasicWidget.TranslateEvent( eventObj, document.body );
if( NavigatorInfo.IsFirefox() && eventObj.button == "3")
{
return;
}
this.DocumentClickedEvent( eventObj );
}
UIManagerImpl.prototype.OnMouseMove = function( eventObj )
{
eventObj = BasicWidget.TranslateEvent( eventObj, document.body );
var screenX = eventObj.screenX;
var screenY = eventObj.screenY;
this.MouseMoveEvent( screenX, screenY );
}
UIManagerImpl.prototype.OnMouseUp = function()
{
this.MouseUpEvent();
}
Trace.Wrap( "UIManagerImpl" );
var UIManager = new UIManagerImpl();
function TextWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._text = "";
this._isVertAlignMiddle = false;
this._insertWhiteSpace = false;
this._multipleLinesEnabled = true;
this._Created.Add( Delegate( this, TextWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, TextWidget.prototype._WidgetResized ) );
}
OOP.Inherit( TextWidget, BasicWidget );
TextWidget.prototype._WidgetCreated = function()
{
this.SetStyle( "cursor", "default" );
this._RefreshSafeText();
}
TextWidget.prototype._WidgetResized = function()
{
if( this._isVertAlignMiddle )
{
var height = this.GetHeight();
var paddedHeight = this.GetPaddedHeight();
var lineHeight = this.GetLinesHeight( 1 );
var paddingTop = ( paddedHeight - lineHeight ) / 2;
if( paddingTop < 0 )
{
paddingTop = 0;
}
this.SetStyle( "paddingTop", paddingTop );
if( !NavigatorInfo.IsIE() )
{
this.SetHeight( height,true );
}
}
}
TextWidget.prototype.EnableMultipleLines = function( enable )
{
this._multipleLinesEnabled = enable;
if( !enable )
{
this.SetStyle( "textOverflow", "ellipsis" );
this.SetAttribute( "noWrap", "noWrap" );
}
else
{
this.SetStyle( "textOverflow", "clip" );
this.SetAttribute( "noWrap", "" );
}
}
TextWidget._replaceTable = {
"<":"&lt;",
">":"&gt;",
"\"":"&quot;",
"'":"&#39;",
"&":"&amp;",
"\t":"    ",
"\r":""
};
TextWidget._replaceMatchString = "[<>\"'&\t\r]";
TextWidget.GetSafeText = function( text, isSingleLine )
{
text = text + "";
var reg = new RegExp( TextWidget._replaceMatchString, "g" );
text = text.replace( reg, function( $0 ){ return TextWidget._replaceTable[ $0 ]; } );
if( isSingleLine )
{
text = text.replace( "^(.*)\n(.*)$", "$1" );
text = text.replace( / /g, "&nbsp;" );
}
else
{
reg = new RegExp( "\n", "g" );
text = text.replace( reg, "<br/>" );
reg = new RegExp( "  ", "g" );
text = text.replace( reg, "&nbsp; " );
text = text.replace( reg, " &nbsp;" );
}
return text;
}
TextWidget.prototype._RefreshSafeText = function()
{
try
{
var text = TextWidget.GetSafeText( this._text, !this._multipleLinesEnabled );
if( this._insertWhiteSpace && this._multipleLinesEnabled )
{
var re = new RegExp( "(&[^;]+;|<[^>]+>|.){1,8}", "g" );
if( NavigatorInfo.IsIE() )
{
this.SetStyle( "wordBreak", "break-all" );
}
else
if( NavigatorInfo.IsSafari() )
{
text = text.replace( re, function( $0 ){ return $0 + "&shy;";} );
}
else
{
text = text.replace( re, function( $0 ){ return $0 + "<wbr/>";} );
}
}
this._htmlObject.innerHTML = text;
}
catch( e )
{
}
}
TextWidget.prototype.SetText = function( text, insertWhiteSpace )
{
this._text = text;
this._insertWhiteSpace = insertWhiteSpace;
this._RefreshSafeText();
}
TextWidget.prototype.SetVertAlignMiddle = function( enable )
{
this._isVertAlignMiddle = enable;
}
TextWidget.ClearTestText = function()
{
var oText = TextWidget._CreateTestText.oText;
if ( oText )
{
UIManager.backgroundFrame._htmlObject.removeChild( oText );
UIManager.DiscardDomElement( oText );
TextWidget._CreateTestText.oText = null;
}
}
TextWidget._CreateTestText = function( textWidget )
{
var oText = TextWidget._CreateTestText.oText;
if( oText != null )
{
TextWidget.ClearTestText();
}
oText = document.createElement( "div" );
UIManager.backgroundFrame._htmlObject.appendChild( oText );
oText.style.position = "absolute";
TextWidget._CreateTestText.oText = oText;
oText.style.fontFamily = textWidget.GetStyle( "fontFamily" );
oText.style.fontSize = textWidget.GetStyle( "fontSize" );
oText.style.fontWeight = textWidget.GetStyle( "fontWeight" );
oText.innerHTML = textWidget._htmlObject.innerHTML;
return oText;
}
TextWidget.prototype.FitTextByChangeFont = function()
{
var oTestText = TextWidget._CreateTestText( this );
var width = this.GetClientWidth();
var height = this.GetClientHeight();
if( width < 1 || height < 1 )
{
return;
}
oTestText.style.width = width;
if( NavigatorInfo.IsIE() )
{
oTestText.style.wordBreak = "break-all";
}
var minSize = 1;
var maxSize = 64;
while( maxSize - minSize > 1.1 )
{
meanSize = ( maxSize + minSize ) / 2;
oTestText.style.fontSize = Math.floor( meanSize );
if( oTestText.clientHeight > height )
{
maxSize = meanSize;
}
else
{
minSize = meanSize;
}
oTestText.innerHTML = "";
oTestText.innerHTML = this._htmlObject.innerHTML;
}
this.SetStyle( "fontSize", Math.floor( minSize ) );
}
TextWidget.prototype.GetTextWidth = function()
{
var oTestText = TextWidget._CreateTestText( this );
return oTestText.offsetWidth;
}
TextWidget.prototype.GetTextHeight = function()
{
var oTestText = TextWidget._CreateTestText( this );
return oTestText.offsetHeight;
}
TextWidget.prototype.SetTextColor = function( color )
{
this._htmlObject.style.color = color;
}
TextWidget.prototype.TestTextHeight = function( width )
{
var oTestText = TextWidget._CreateTestText( this );
oTestText.style.height = "";
oTestText.style.width = width;
var height = oTestText.offsetHeight;
return height;
}
TextWidget.prototype.TestTextWidth = function( height )
{
var oTestText = TextWidget._CreateTestText( this );
oTestText.style.width = "";
oTestText.style.height = height;
var width = oTestText.offsetWidth;
return width;
}
TextWidget.prototype.GetLinesHeight = function( lineCount )
{
if( lineCount <= 0 )
{
return 0;
}
var oTestText = TextWidget._CreateTestText( this );
oTestText.style.height = "";
oTestText.style.width = 1000000;
var str = "a";
for( var i=1; i<lineCount; i++ )
{
str += "<br/>a";
}
oTestText.innerHTML = str;
return oTestText.offsetHeight;
}
TextWidget.prototype.IsAllTextVisible = function()
{
var width = this.GetWidth();
var height = this.GetHeight();
return this.TestTextHeight( width ) <= height;
}
Trace.Wrap( "TextWidget" );
function TableWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( TableWidget, BasicWidget );
TableWidget.prototype.Create = function( parentWidget, id )
{
this.CreateElement( "table", parentWidget, id );
this.SetAttribute( "border", 0 );
this.SetAttribute( "cellPadding", 0 );
this.SetAttribute( "cellSpacing", 0 );
}
TableWidget.prototype.AddCell = function( bodyIndex, rowIndex, rowSpan, colSpan, id )
{
var oTable = this._htmlObject;
if( oTable.tBodies.length <= bodyIndex )
{
for( var i=oTable.tBodies.length; i<bodyIndex + 1; i++ )
{
this._AddBody();
}
}
var oBody = oTable.tBodies[ bodyIndex ];
if( oBody.rows.length <= rowIndex )
{
for( var i=oBody.rows.length; i<rowIndex + 1; i++ )
{
this._AddRow( bodyIndex );
}
}
var oRow = oBody.rows[ rowIndex ];
var currentDocument = this._htmlObject.ownerDocument;
var oCell = currentDocument.createElement( "td" );
oRow.appendChild( oCell );
if( id != null )
{
oCell.id = id;
}
oCell.rowSpan = rowSpan;
oCell.colSpan = colSpan;
var widget = new BasicWidget();
widget.Attach( oCell, this );
return widget;
}
TableWidget.prototype._AddBody = function()
{
var currentDocument = this._htmlObject.ownerDocument;
var oBody = currentDocument.createElement( "tbody" );
this._htmlObject.appendChild( oBody );
}
TableWidget.prototype._AddRow = function( bodyIndex )
{
var currentDocument = this._htmlObject.ownerDocument;
var oRow = currentDocument.createElement( "tr" );
this._htmlObject.tBodies[ bodyIndex ].appendChild( oRow );
return oRow;
}
TableWidget.prototype.AddBody = function()
{
this._AddBody();
}
TableWidget.prototype.AddRow = function( bodyIndex )
{
if ( bodyIndex == null )
{
bodyIndex = 0;
}
return this._AddRow( bodyIndex );
}
Trace.Wrap( "TableWidget" );
function HTMLWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._iframe = null;
this._safariPatch = new HTMLWidgetSafariPatch( this );
this._isLoaded = false;
this._innerHTML = null;
this._backgroundColor = "#ffffff";
this._IFrameCreatedEvent = new Event();
this._AfterLoadedEvent = new Event();
this._BeforeUnloadEvent = new Event();
this.blankPageUri = HTMLWidget.defaultBlankPageUri;
this._currentUri = null;
this._Created.Add( Delegate( this, HTMLWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, HTMLWidget.prototype._WidgetResized ) );
this._Destroyed.Add( Delegate( this, HTMLWidget.prototype._WidgetDestroyed ) );
}
OOP.Inherit( HTMLWidget, BasicWidget );
HTMLWidget.defaultBlankPageUri = "blank.htm";
HTMLWidget.prototype.AllowTransparency = function( allow )
{
this._iframe.allowTransparency = allow;
var color = allow ? "transparent" : this._backgroundColor;
this._iframe.style.backgroundColor = color;
if ( this._iframe.contentWindow
&& this._iframe.contentWindow.document
&& this._iframe.contentWindow.document.body
&& this._iframe.contentWindow.document.body.style  )
{
this._iframe.contentWindow.document.body.style.backgroundColor = color;
}
}
HTMLWidget.prototype._SetupMouse = function()
{
Object.RegisterDomEvent( this._iframe.contentWindow.document, "onclick",
Delegate( this, HTMLWidget.prototype._OnContentClick ) );
Object.RegisterDomEvent( this._iframe.contentWindow.document, "oncontextmenu",
Delegate( this, HTMLWidget.prototype._OnContextMenu ) );
Object.RegisterDomEvent( this._iframe.contentWindow.document, "onmousemove",
Delegate( this, HTMLWidget.prototype._OnMouseMove ) );
Object.RegisterDomEvent( this._iframe.contentWindow.document, "onmouseup",
Delegate( this, HTMLWidget.prototype._OnMouseUp ) );
}
HTMLWidget.prototype._OnContentClick = function()
{
UIManager.ChildClickedEvent();
}
HTMLWidget.prototype._OnContextMenu = function()
{
return false;
}
HTMLWidget.prototype._OnMouseMove = function( eventObj )
{
var screenX = 0;
var screenY = 0;
if( NavigatorInfo.IsIE() )
{
screenX = this._iframe.contentWindow.event.screenX;
screenY = this._iframe.contentWindow.event.screenY;
}
else
{
eventObj = BasicWidget.TranslateEvent( eventObj, null );
screenX = eventObj.screenX;
screenY = eventObj.screenY;
}
UIManager.MouseMoveEvent( screenX, screenY );
}
HTMLWidget.prototype._OnMouseUp = function()
{
UIManager.OnMouseUp();
}
HTMLWidget.prototype._WidgetCreated = function()
{
}
HTMLWidget.prototype._WidgetDestroyed = function()
{
this._DeleteIFrame();
}
HTMLWidget.prototype._WidgetResized = function()
{
}
HTMLWidget.prototype._OnReadyStateChange = function()
{
if( this._iframe.readyState == "complete" )
{
this._OnLoad();
}
}
HTMLWidget.prototype._OnLoad = function()
{
var doc = null;
try
{
doc = this._iframe.contentWindow.document;
}
catch(e)
{
if (this._currentUri == this.blankPageUri)
return;
this._DeleteIFrame();
this.SetURI(null);
this._AfterLoadedEvent();
return;
}
if( this._innerHTML != null )
{
var doc = this._iframe.contentWindow.document;
doc.write( this._innerHTML );
this._innerHTML = null;
doc.close();
return;
}
this._isLoaded = true;
this._SetupMouse();
this._AfterLoadedEvent();
}
HTMLWidget.prototype._CreateIFrame = function( uri )
{
var oIFrame = document.createElement( "iframe" );
oIFrame.src = uri;
oIFrame.id = this.GetId() + "_IFrame";
oIFrame.frameBorder = "no";
oIFrame.style.width = "100%";
oIFrame.style.height = "100%";
oIFrame.style.backgroundColor = this._backgroundColor;
oIFrame.tabIndex = UISettings.tabIndexDisable;
this._iframe = oIFrame;
if( NavigatorInfo.IsIE() )
{
Object.RegisterDomEvent( oIFrame, "onreadystatechange", Delegate( this, this._OnReadyStateChange ) );
}
else
{
Object.RegisterDomEvent( oIFrame, "onload", Delegate( this, this._OnLoad ) );
}
this._htmlObject.appendChild( oIFrame );
this._IFrameCreatedEvent();
}
HTMLWidget.prototype._DeleteIFrame = function()
{
if( !this._iframe )
{
return;
}
try
{
if ( this._iframe.contentWindow != null &&
this._iframe.contentWindow.document != null )
{
Object.UnregisterAllEvents( this._iframe.contentWindow.document );
}
}
catch( e )
{
}
Object.UnregisterAllEvents( this._iframe );
this._htmlObject.removeChild( this._iframe );
this._iframe = null;
}
HTMLWidget.prototype._InternalSetURI = function( uri )
{
if( uri == null )
{
uri = this.blankPageUri;
}
this._safariPatch.SetURI( uri );
if( this._iframe != null )
{
if( this._isLoaded )
{
this._BeforeUnloadEvent();
}
this._isLoaded = false;
try
{
this._iframe.contentWindow.location.replace( uri );
}
catch( e )
{
}
}
else
{
this._isLoaded = false;
this._CreateIFrame( uri );
}
this._currentUri = uri;
}
HTMLWidget.prototype.SetURI = function( uri )
{
this._innerHTML = null;
this._InternalSetURI( uri );
}
HTMLWidget.prototype.SetHTML = function( str )
{
this._innerHTML = str;
this._InternalSetURI( this.blankPageUri );
}
Trace.Wrap( "HTMLWidget" );
function HTMLWidgetSafariPatch( widget )
{
this._htmlWidget = widget;
this._timerHandle = null;
}
HTMLWidgetSafariPatch.prototype.SetURI = function( uri )
{
if (!NavigatorInfo.IsSafari())
{
return;
}
if ( this._timerHandle != null )
{
clearTimeout( this._timerHandle );
}
if ( uri == null )
{
return;
}
uri = uri.toLowerCase();
if ( !uri.match( /^http/ ) )
{
this._timerHandle = setTimeout(
Delegate( this, HTMLWidgetSafariPatch.prototype._Exec ),
10000 );
}
}
HTMLWidgetSafariPatch.prototype._Exec = function()
{
this._htmlWidget._AfterLoadedEvent();
this._timerHandle = null;
}
function ImageWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this.ImageLoadedEvent = new Event();
this._AfterLoadedEvent = new Event();
this._preloadImage = null;
this._imageLoadSuccess = false;
this._Created.Add( Delegate( this, ImageWidget.prototype._WidgetCreated ) );
this._Destroyed.Add( Delegate( this, ImageWidget.prototype._WidgetDestroyed ) );
}
OOP.Inherit( ImageWidget, BasicWidget );
ImageWidget.ImageContainer = null;
ImageWidget.IdCount = 0;
ImageWidget.prototype.Create = function( parent, id )
{
this.CreateElement( "img", parent, id );
if (ImageWidget.ImageContainer == null)
{
ImageWidget.ImageContainer = document.createElement( "div" );
UIManager.backgroundFrame._htmlObject.appendChild( ImageWidget.ImageContainer );
}
this.SetAttribute( "galleryImg", false );
if( NavigatorInfo.IsFirefox() )
{
this.RegisterEvent("onload", Delegate( this, ImageWidget.prototype._ShowImage ) );
}
}
ImageWidget.prototype._WidgetCreated = function()
{
this.SetStyle( "visibility", "hidden" );
}
ImageWidget.prototype._WidgetDestroyed = function()
{
if( this._preloadImage )
{
Object.UnregisterAllEvents( this._preloadImage );
this._preloadImage._WIDGET_ = null;
this._preloadImage = null;
}
}
ImageWidget.prototype.SetURI = function( uri, bInitHidden )
{
var bCallOnLoad = false;
this.SetStyle( "visibility", "hidden" );
if( this._preloadImage == null )
{
var oPreloadImage = null;
if ( NavigatorInfo.IsSafari() )
{
var objId = "ImageWidget_" + ImageWidget.IdCount;
ImageWidget.IdCount++;
var str = "var obj = document.getElementById( '" + objId + "' );" +
"var widget = obj._WIDGET_;" +
"widget._OnLoadError();";
ImageWidget.ImageContainer.innerHTML = "<img id = \"" + objId + "\" src=\"" + uri + "\" onerror=\"" + str + "\"></img>";
oPreloadImage = document.getElementById( objId );
oPreloadImage._WIDGET_ = this;
if ( ImageWidget.ImageContainer.children( 0 ) )
{
oPreloadImage = ImageWidget.ImageContainer.removeChild( ImageWidget.ImageContainer.children( 0 ) );
}
}
else
{
oPreloadImage = document.createElement( "img" );
}
oPreloadImage.style.position = "absolute";
UIManager.backgroundFrame._htmlObject.appendChild( oPreloadImage );
if( NavigatorInfo.IsIE() )
{
Object.RegisterDomEvent( oPreloadImage, "onreadystatechange", Delegate( this, this._OnReadyStateChange ) );
}
else
{
Object.RegisterDomEvent( oPreloadImage, "onload", Delegate( this, this._OnLoad ) );
}
if ( !NavigatorInfo.IsSafari() )
{
Object.RegisterDomEvent( oPreloadImage, "onerror", Delegate( this, this._OnLoadError ) );
}
this._preloadImage = oPreloadImage;
}
else
{
if( NavigatorInfo.IsSafari() && this._preloadImage._src==uri && this._imageLoadSuccess )
{
bCallOnLoad = true;
}
}
if ( bInitHidden != null )
{
this._bInitHidden = bInitHidden;
}
else
{
this._bInitHidden = false;
}
this.preDownloader.BeginSelfLoad();
this._imageLoadSuccess = false;
this._preloadImage.src = uri;
this._preloadImage._src = uri;
this._currentUri = uri;
if( bCallOnLoad )
{
this._OnLoad();
}
}
ImageWidget.prototype._OnReadyStateChange = function()
{
if( this._preloadImage.readyState == "complete" )
{
this._OnLoad();
}
}
ImageWidget.prototype._ShowImage = function()
{
if( ( this.GetStyle( "visibility" ) == "hidden" ) && ( this._bInitHidden == false ) )
{
this.SetStyle( "visibility", "inherit" );
}
}
ImageWidget.prototype._OnLoad = function()
{
this.SetAttribute( "src", this._preloadImage.src );
if( !NavigatorInfo.IsFirefox() )
{
this._ShowImage();
}
var imageWidth = this._preloadImage.scrollWidth;
var imageHeight = this._preloadImage.scrollHeight;
if( imageWidth > 0 && imageHeight > 0 )
{
this.SetOriginalSize( imageWidth, imageHeight );
}
else
{
this.ApplyDefaultOriginalSize();
}
this.ImageLoadedEvent();
this._AfterLoadedEvent();
this._imageLoadSuccess = true;
this.preDownloader.OnSelfLoad();
}
ImageWidget.prototype._OnLoadError = function()
{
this.SetStyle( "visibility", "hidden" );
this._AfterLoadedEvent();
this._imageLoadSuccess = false;
this.preDownloader.OnSelfLoad();
}
Trace.Wrap( "ImageWidget" );
function CheckWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( CheckWidget, BasicWidget );
CheckWidget.prototype.Create = function( parentWidget, id )
{
var currentDocument = null;
if( parentWidget && parentWidget.IsCreated() )
{
currentDocument = parentWidget._htmlObject.ownerDocument;
}
else
{
currentDocument = document;
}
var checkbox = currentDocument.createElement( "input" );
checkbox.type = "checkbox";
BasicWidget._SetParent( checkbox, parentWidget );
this.Attach( checkbox, parentWidget, id );
}
Trace.Wrap( "CheckWidget" );
function SplitterWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( SplitterWidget, BasicWidget );
Trace.Wrap( "SplitterWidget" );
function SliderWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this.ValueChangingEvent = new Event();
this.ValueChangedEvent = new Event();
this.MouseMoveEvent = new Event();
this._imgHead = new ImageWidget();
this._imgTail = new ImageWidget();
this._imgElapsed = new ImageWidget();
this._imgUnelapsed = new ImageWidget();
this._imgSlider = new ImageWidget();
this._minValue = 0;
this._maxValue = 1;
this._currentValue = 0;
this._validMaxValue = this._maxValue;
this._sliderWidth = 5;
this._dragStates = new Object();
this._dragStates._isDragging = false;
this._dragStates._leftAtDragStart = -1;
this._dragStates._screenXAtDragStart = -1;
this._dragStates._isChangingValue = false;
this._divSlider = new BasicWidget();
this._Created.Add( Delegate( this, SliderWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, SliderWidget.prototype._WidgetResized ) );
this._Destroyed.Add( Delegate( this, SliderWidget.prototype._WidgetDestroyed ) );
}
OOP.Inherit( SliderWidget, BasicWidget );
SliderWidget.prototype._WidgetCreated = function()
{
this.RegisterEvent( "onkeydown", Delegate ( this, this._OnKeyDown ) );
this.RegisterEvent( "onmousemove", Delegate( this, this._OnMouseMove ) );
this.RegisterEvent( "onmousedown", Delegate( this, SliderWidget.prototype._OnMouseDown ) );
this._imgUnelapsed.Create( this, this.GetId() + "Unelapsed" );
this._imgElapsed.Create( this, this.GetId() + "Elapsed" );
this._imgSlider.Create( this, this.GetId() + "Slider" );
this._imgHead.Create( this, this.GetId() + "Head" );
this._imgTail.Create( this, this.GetId() + "Tail" );
this._imgUnelapsed._htmlObject.style.position = "absolute";
this._imgElapsed._htmlObject.style.position = "absolute";
this._imgSlider._htmlObject.style.position = "absolute";
this._imgHead._htmlObject.style.position = "absolute";
this._imgTail._htmlObject.style.position = "absolute";
this._imgUnelapsed.SetStyle( "zIndex", 1 );
this._imgTail.SetStyle( "zIndex", 1 );
this._imgHead.SetStyle( "zIndex", 2 );
this._imgElapsed.SetStyle( "zIndex", 2 );
this._imgSlider.SetStyle( "zIndex", 3 );
if( NavigatorInfo.IsFirefox() )
{
this._divSlider.Create(this, this.GetId() + "Surface" );
this._divSlider.SetStyle( "cursor", "pointer" );
this._divSlider.SetStyle( "position", "absolute" );
this._divSlider.SetStyle("zIndex", 4 );
}
else
{
this._imgSlider.SetStyle( "cursor", "pointer" );
this.RegisterEvent( "ondragstart", Delegate( this,SliderWidget.prototype._OnDrag ) );
}
UIManager.MouseUpEvent.Add( Delegate( this, SliderWidget.prototype._OnMouseUp ) );
UIManager.MouseMoveEvent.Add( Delegate( this, SliderWidget.prototype._OnMouseMoveInWindow ) );
this._ChangeLayout();
}
SliderWidget.prototype._WidgetDestroyed = function()
{
}
SliderWidget.prototype._WidgetResized = function()
{
this._ChangeLayout();
}
SliderWidget.prototype._ChangeLayout = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
if( clientWidth < this._sliderWidth )
{
clientWidth = this._sliderWidth;
}
var sliderWidth_2 = this._sliderWidth / 2;
this._minPos = sliderWidth_2;
this._maxPos = clientWidth + sliderWidth_2 - this._sliderWidth;
this._imgUnelapsed._htmlObject.style.height = clientHeight;
this._imgElapsed._htmlObject.style.height = clientHeight;
this._imgSlider._htmlObject.style.height = clientHeight;
this._imgHead._htmlObject.style.height = clientHeight;
this._imgTail._htmlObject.style.height = clientHeight;
this._imgUnelapsed._htmlObject.style.top = 0;
this._imgElapsed._htmlObject.style.top = 0;
this._imgSlider._htmlObject.style.top = 0;
this._imgHead._htmlObject.style.top = 0;
this._imgTail._htmlObject.style.top = 0;
this._imgTail._htmlObject.style.left = this._maxPos;
this._imgUnelapsed._htmlObject.style.left = this._minPos;
this._imgElapsed._htmlObject.style.left = this._minPos;
this._imgHead.SetWidth( this._minPos );
this._imgTail.SetWidth( clientWidth - this._maxPos );
this._imgUnelapsed.SetWidth( this._maxPos - this._minPos );
this._imgSlider.SetWidth( this._sliderWidth );
if( NavigatorInfo.IsFirefox() )
{
this._divSlider._htmlObject.style.width = 0;
this._divSlider._htmlObject.style.height = 0;
this._divSlider.SetBorder( "solid", clientWidth, clientHeight, 0, 0, true );
this._divSlider.SetStyle( "borderColor", "transparent" );
this._divSlider.SetStyle( "left", 0 );
this._divSlider.SetStyle( "top", 0 );
this._divSlider.SetStyle( "overflow", "hidden" );
}
this._OnUpdateValue();
}
SliderWidget.prototype._ConvertPositionToValue = function( pos )
{
var pos2value = ( this._maxValue - this._minValue ) / ( this._maxPos - this._minPos );
var value = this._minValue + ( pos - this._minPos ) * pos2value;
return value;
}
SliderWidget.prototype._GetValueFromEvent = function( eventObj )
{
var currentPos = this._GetCoordXFromEvent( eventObj );
if( currentPos > this._maxPos )
{
Trace.WriteLine(
"The current pos is bigger than max pos. It is limited to max pos" );
currentPos = this._maxPos;
}
if( currentPos < this._minPos )
{
Trace.WriteLine(
"The current pos is smaller than min pos. It is limited to min pos" );
currentPos = this._minPos;
}
var currentValue = this._ConvertPositionToValue( currentPos );
Trace.WriteLine( "The min pos is: " + this._minPos );
Trace.WriteLine( "The max pos is: " + this._maxPos );
Trace.WriteLine( "The min value is: " + this._minValue );
Trace.WriteLine( "The max value is: " + this._maxValue );
Trace.WriteLine( "The current pos is: " + currentPos );
Trace.WriteLine( "The current value is: " + currentValue );
return currentValue;
}
SliderWidget.prototype._IsValidValue = function( value )
{
return ( value <= this._validMaxValue && value >= this._minValue );
}
SliderWidget.prototype._OnValueChanging = function( value )
{
if( this._IsValidValue( value ) )
{
this.ValueChangingEvent( value );
}
}
SliderWidget.prototype._OnMouseMove = function( eventObj )
{
eventObj = this._TranslateMouseEvent(eventObj);
var currentValue = this._GetValueFromEvent( eventObj );
if( this._IsValidValue( currentValue ) )
{
this.MouseMoveEvent( currentValue );
}
}
SliderWidget.prototype._OnKeyDown = function ( eventObj )
{
eventObj = BasicWidget.TranslateEvent( eventObj, this._htmlObject );
var theKey = BasicWidget.GetKey( eventObj );
if( theKey != KeyTable.VK_LEFT && theKey != KeyTable.VK_RIGHT)
{
return;
}
var interval = (this._maxValue - this._minValue)/100;
var currentValue;
switch(theKey)
{
case KeyTable.VK_LEFT:
currentValue = (this._currentValue - interval)>=this._minValue?(this._currentValue - interval):this._minValue;
break;
case KeyTable.VK_RIGHT:
currentValue = (this._currentValue + interval)<=this._maxValue?(this._currentValue + interval):this._maxValue;
break;
default:
break;
}
this._OnValueChanging(currentValue);
return false;
}
SliderWidget.prototype._OnUpdateValue = function( )
{
var elapsedLength = 0;
var value2pos = ( this._maxPos - this._minPos ) / ( this._maxValue - this._minValue );
elapsedLength = ( this._currentValue - this._minValue ) * value2pos;
this._MoveSlider( elapsedLength );
}
SliderWidget.prototype.SetSliderWidth = function( width )
{
this._sliderWidth = width;
this._ChangeLayout();
}
SliderWidget.prototype.SetValue = function( value )
{
if( value > this._maxValue )
{
Trace.WriteLine(
"The input value %1 is larger than the max value %2. It has been limited to max value. ",
value,
this._maxValue );
value = this._maxValue;
}
if( value < this._minValue )
{
Trace.WriteLine(
"The input value %1 is smaller than the min value %2. It has been limited to min value",
value,
this._minValue );
value = this._minValue;
}
this._currentValue = value;
this.ValueChangedEvent();
if( !this._dragStates._isDragging && !this._dragStates._isChangingValue)
{
this._OnUpdateValue();
}
}
SliderWidget.prototype.GetValue = function()
{
return this._currentValue;
}
SliderWidget.prototype.SetValueRange = function( minValue, maxValue )
{
this._validMaxValue = maxValue;
if( maxValue - minValue < 1e-6 )
{
this._maxValue = minValue + 1e-6;
}
else
{
this._maxValue = maxValue;
}
this._minValue = minValue;
this._currentValue = minValue;
}
SliderWidget.prototype.SetUnelapsedImage = function( uri )
{
this._imgUnelapsed.SetURI( uri );
}
SliderWidget.prototype.SetElapsedImage = function( uri )
{
this._imgElapsed.SetURI( uri );
}
SliderWidget.prototype.SetSliderImage = function( uri )
{
this._imgSlider.SetURI( uri );
}
SliderWidget.prototype.SetHeadImage = function( uri )
{
this._imgHead.SetURI( uri );
}
SliderWidget.prototype.SetTailImage = function( uri )
{
this._imgTail.SetURI( uri );
}
SliderWidget.prototype._OnDrag = function()
{
return false;
}
SliderWidget.prototype._TranslateMouseEvent = function( eventObj )
{
if( NavigatorInfo.IsFirefox() )
{
var offsetX = this._CalculateOffsetXForFirefox( eventObj );
eventObj = BasicWidget.TranslateEvent( eventObj, this._htmlObject );
eventObj.offsetX = offsetX;
}
else
{
eventObj = BasicWidget.TranslateEvent( eventObj, this._htmlObject );
}
return eventObj;
}
SliderWidget.prototype._CalculateOffsetXForFirefox = function( eventObj )
{
var pageX = eventObj.pageX;
var leftInBody = BasicWidget._GetCoordInBody( eventObj.originalTarget,"Left" );
return pageX - leftInBody;
}
SliderWidget.prototype._OnMouseDown = function( eventObj )
{
eventObj = this._TranslateMouseEvent( eventObj );
if( eventObj.button != "1" )
{
return;
}
this._dragStates._screenXAtDragStart = eventObj.screenX;
var coordX = this._GetCoordXFromEvent( eventObj );
this._dragStates._leftAtDragStart = coordX - this._sliderWidth + this._sliderWidth/2;
if( coordX < this._minPos )
{
this._dragStates._screenXAtDragStart = this._dragStates._screenXAtDragStart + (this._minPos - coordX)*UIManager.zoomLevel;
this._dragStates._leftAtDragStart = 0;
}
if (coordX > this._maxPos )
{
this._dragStates._screenXAtDragStart = this._dragStates._screenXAtDragStart - (coordX - this._maxPos)*UIManager.zoomLevel;
this._dragStates._leftAtDragStart = this._maxPos - this._sliderWidth + this._sliderWidth/2;
}
this._MoveSlider( this._dragStates._leftAtDragStart );
if( this._htmlObject.setCapture )
{
this._htmlObject.setCapture();
}
this.SetFocus();
this._dragStates._isDragging = true;
}
SliderWidget.prototype._OnMouseMoveInWindow = function( screenX, screenY )
{
if( !this._dragStates._isDragging )
{
return;
}
var distance = screenX - this._dragStates._screenXAtDragStart;
var elapsedLength = this._dragStates._leftAtDragStart + distance/UIManager.zoomLevel;
if( elapsedLength < 0 )
{
elapsedLength = 0;
}
var maxLeft = this._maxPos -this._sliderWidth + this._sliderWidth/2;
if( elapsedLength > maxLeft )
{
elapsedLength = maxLeft;
}
this._MoveSlider( elapsedLength );
}
SliderWidget.prototype._GetValueFromSliderPosition = function()
{
var currentPos = this._imgSlider.GetLeft();
currentPos = currentPos + this._sliderWidth - this._sliderWidth/2;
var currentValue = this._ConvertPositionToValue( currentPos );
return currentValue;
}
SliderWidget.prototype._OnMouseUp = function()
{
if( !this._dragStates._isDragging )
{
return;
}
this._dragStates._screenXAtDragStart = -1;
this._dragStates._leftAtDragStart = -1;
if( this._htmlObject.releaseCapture )
{
this._htmlObject.releaseCapture();
}
var currentValue = this._GetValueFromSliderPosition();
this._dragStates._isChangingValue = true;
this._dragStates._isDragging = false;
this._OnValueChanging(currentValue);
this._dragStates._isChangingValue = false;
this.SetFocus();
}
SliderWidget.prototype._GetCoordXFromEvent = function( eventObj )
{
var coordX = eventObj.offsetX + eventObj.srcElement.offsetLeft;
return coordX;
}
SliderWidget.prototype._MoveSlider = function( left )
{
this._imgElapsed.SetWidth( left );
this._imgSlider.SetStyle( "left", left );
}
SliderWidget.prototype.SetTabIndex = function( index )
{
if(this._imgSlider)
{
this._imgSlider.SetTabIndex( index );
}
}
SliderWidget.prototype.GetTabIndex = function( )
{
if(this._imgSlider)
{
return this._imgSlider.GetTabIndex();
}
else
{
return -1;
}
}
SliderWidget.prototype.SetFocus = function()
{
if(this._imgSlider)
{
this._imgSlider.SetFocus();
}
}
Trace.Wrap( "SliderWidget" );
function ButtonWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this.ClickEvent = new Event();
this.KeyDownEvent = null;
this._isEnabled = true;
this._borderWidth = 2;
this._surface = null;
this._surfaceMarginLeft = 1;
this._surfaceMarginTop = 1;
this._surfaceMarginRight = 2;
this._surfaceMarginBottom = 2;
this._Created.Add( Delegate( this, ButtonWidget.prototype._WidgetCreated ) );
this._PostCreated.Add( Delegate( this, ButtonWidget.prototype._WidgetPostCreated ) );
}
OOP.Inherit( ButtonWidget, BasicWidget );
ButtonWidget.prototype._WidgetCreated = function()
{
this.SetStyle( "cursor", "pointer" );
this.RegisterEvent( "onclick", Delegate( this, this._OnClick ) );
this.RegisterEvent( "onkeydown", Delegate ( this, this._OnKeyDown ) );
this.RegisterEvent( "onmousedown", Delegate( this, this._OnMouseDown ) );
this.RegisterEvent( "onmouseup", Delegate( this, this._OnMouseUp ) );
this.RegisterEvent( "onmouseover", Delegate( this, this._OnMouseOver ) );
this.RegisterEvent( "onmouseout", Delegate( this, this._OnMouseOut ) );
this.SetStyle( "textAlign", "left" );
this.SetAttribute( "title", "button" );
}
ButtonWidget.prototype._WidgetPostCreated = function()
{
this._OnButtonUpdate();
}
ButtonWidget.prototype.SetSurfaceMargin = function( marginLeft, marginTop, marginRight, marginBottom )
{
this._surfaceMarginLeft = marginLeft;
this._surfaceMarginTop = marginTop;
this._surfaceMarginRight = marginRight;
this._surfaceMarginBottom = marginBottom;
this._WidgetResized();
}
ButtonWidget.prototype.SetButtonBorderWidth = function( width )
{
this._borderWidth = width;
}
ButtonWidget.prototype.EnableButton = function( enable )
{
if( enable == this._isEnabled )
{
return;
}
this._isEnabled = enable;
this._OnButtonUpdate();
}
ButtonWidget.prototype._OnButtonUpdate = function()
{
if( this._htmlObject == null )
{
return;
}
if( this._isEnabled )
{
Trace.WriteLine( "Set the normal image: " + this._normalImage );
this._ShowNormalState();
}
else
{
Trace.WriteLine( "Set the disabled image: " + this._disabledImage );
this._ShowDisableState();
}
}
ButtonWidget.prototype._OnClick = function( eventObj )
{
Trace.WriteLine( "button " + this.GetId() + " clicked. " );
var translatedEvent = BasicWidget.TranslateEvent( eventObj, this._htmlObject );
var originalEvent = BasicWidget.GetOriginalEvent( eventObj, this._htmlObject );
if( this._isEnabled && this.ClickEvent )
{
this.ClickEvent( this, translatedEvent, originalEvent );
}
}
ButtonWidget.prototype._OnKeyDown = function ( eventObj )
{
eventObj = BasicWidget.TranslateEvent( eventObj, this._htmlObject );
if( this.KeyDownEvent )
{
this.KeyDownEvent( eventObj );
}
else
{
var theKey = BasicWidget.GetKey( eventObj );
if( theKey == KeyTable.VK_SPACE || theKey == KeyTable.VK_RETURN)
{
this._OnClick( eventObj );
}
}
}
ButtonWidget.prototype._OnMouseDown = function()
{
if( this._isEnabled )
{
this._ShowDownState();
}
}
ButtonWidget.prototype._OnMouseUp = function()
{
if( this._isEnabled )
{
this._ShowHighlightState();
}
}
ButtonWidget.prototype._OnMouseOver = function()
{
if( this._isEnabled )
{
this._ShowHighlightState();
}
}
ButtonWidget.prototype._OnMouseOut = function()
{
if( this._isEnabled )
{
this._ShowNormalState();
}
}
ButtonWidget.prototype._ShowDownState = function()
{
this.SetBorder( "inset",
this._borderWidth,
this._borderWidth,
this._borderWidth,
this._borderWidth );
}
ButtonWidget.prototype._ShowNormalState = function()
{
this.SetBorder( "outset",
this._borderWidth,
this._borderWidth,
this._borderWidth,
this._borderWidth );
}
ButtonWidget.prototype._ShowHighlightState = function()
{
this.SetBorder( "outset",
this._borderWidth,
this._borderWidth,
this._borderWidth,
this._borderWidth );
}
ButtonWidget.prototype._ShowDisableState = function()
{
this.SetBorder( "outset",
this._borderWidth,
this._borderWidth,
this._borderWidth,
this._borderWidth );
}
ButtonWidget.prototype.SetTabIndex = function( index )
{
if(this._surface)
{
this._surface.SetTabIndex( index );
}
else
{
BasicWidget.prototype.SetTabIndex.call( this, index );
}
}
ButtonWidget.prototype.GetTabIndex = function( )
{
if(this._surface)
{
return this._surface.GetTabIndex();
}
else
{
return BasicWidget.prototype.GetTabIndex.call( this );
}
}
ButtonWidget.prototype.SetFocus = function()
{
if(this._surface)
{
this._surface.SetFocus();
}
else
{
BasicWidget.prototype.SetFocus.call( this );
}
}
Trace.Wrap( "ButtonWidget" );
function ImageButton()
{
OOP.CallParentConstructor( this, arguments.callee );
this._normalImage = null;
this._downImage = null;
this._disabledImage = null;
this._highlightImage = null;
this._surface = null;
this._Resized.Add( Delegate( this, ImageButton.prototype._WidgetResized ) );
}
OOP.Inherit( ImageButton, ButtonWidget );
ImageButton.prototype._WidgetResized = function()
{
if( this._surface )
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
this._surface.SetUIPosition( true,
this._surfaceMarginLeft,
this._surfaceMarginTop,
clientWidth - this._surfaceMarginLeft - this._surfaceMarginRight,
clientHeight -this._surfaceMarginTop - this._surfaceMarginBottom
);
}
}
ImageButton.prototype._CreateChildImage = function( imageWidget, imageUrl, initShown )
{
imageWidget.Create( this );
imageWidget.SetSize( "100%", "100%" );
imageWidget.SetURI( imageUrl, initShown );
imageWidget.SetStyle( "position", "absolute" );
imageWidget.SetLocation( 0, 0 );
imageWidget.SetStyle( "cursor", "pointer" );
}
ImageButton.prototype.SetImages = function(
normalImage,
downImage,
disabledImage,
highlightImage )
{
if ( this._normalImage != null )
{
this._normalImage.Destroy();
}
if ( this._downImage != null )
{
this._downImage.Destroy();
}
if ( this._disabledImage != null )
{
this._disabledImage.Destroy();
}
if ( this._highlightImage != null )
{
this._highlightImage.Destroy();
}
if( this._surface != null )
{
this._surface.Destroy();
}
if ( this._normalImage == null )
{
this._normalImage = new ImageWidget();
}
this._CreateChildImage( this._normalImage, normalImage, false );
if( downImage )
{
if ( this._downImage == null )
{
this._downImage = new ImageWidget();
}
this._CreateChildImage( this._downImage, downImage, true );
}
else
{
this._downImage = null;
}
if( disabledImage )
{
if ( this._disabledImage == null )
{
this._disabledImage = new ImageWidget();
}
this._CreateChildImage( this._disabledImage, disabledImage, true );
}
else
{
this._disabledImage = null;
}
if( highlightImage )
{
if ( this._highlightImage == null )
{
this._highlightImage = new ImageWidget();
}
this._CreateChildImage( this._highlightImage, highlightImage, true );
}
else
{
this._highlightImage = null;
}
if( this._surface == null )
{
this._surface = new BasicWidget();
}
this._surface.Create( this );
this._surface.SetSize( "100%","100%");
this._surface.SetStyle("position","absolute");
this._surface.SetLocation( 0, 0 );
this._OnButtonUpdate();
}
ImageButton.prototype._HideAllImages = function()
{
if ( this._normalImage != null )
{
this._normalImage.SetStyle( "visibility", "hidden" );
}
if ( this._downImage != null )
{
this._downImage.SetStyle( "visibility", "hidden" );
}
if ( this._disabledImage != null )
{
this._disabledImage.SetStyle( "visibility", "hidden" );
}
if ( this._highlightImage != null )
{
this._highlightImage.SetStyle( "visibility", "hidden" );
}
}
ImageButton.prototype._ShowDownState = function()
{
this._HideAllImages();
if( this._downImage != null )
{
this.SetBorderWidth( 0, 0, 0, 0 );
this._downImage.SetStyle( "visibility", "inherit" );
}
else if( this._normalImage != null )
{
this.SetBorderWidth( 0, 0, 0, 0 );
this._normalImage.SetStyle( "visibility", "inherit" );
}
else
{
ButtonWidget.prototype._ShowDownState.call( this );
}
}
ImageButton.prototype._ShowNormalState = function()
{
this._HideAllImages();
if( this._normalImage != null )
{
this.SetBorderWidth( 0, 0, 0, 0 );
this._normalImage.SetStyle( "visibility", "inherit" );
}
else
{
ButtonWidget.prototype._ShowNormalState.call( this );
}
}
ImageButton.prototype._ShowHighlightState = function()
{
this._HideAllImages();
if( this._highlightImage != null )
{
this.SetBorderWidth( 0, 0, 0, 0 );
this._highlightImage.SetStyle( "visibility", "inherit" );
}
else if( this._normalImage != null )
{
this.SetBorderWidth( 0, 0, 0, 0 );
this._normalImage.SetStyle( "visibility", "inherit" );
}
else
{
ButtonWidget.prototype._ShowHighlightState.call( this );
}
}
ImageButton.prototype._ShowDisableState = function()
{
this._HideAllImages();
if( this._disabledImage != null )
{
this.SetBorderWidth( 0, 0, 0, 0 );
this._disabledImage.SetStyle( "visibility", "inherit" );
}
else if( this._normalImage != null )
{
this.SetBorderWidth( 0, 0, 0, 0 );
this._normalImage.SetStyle( "visibility", "inherit" );
}
else
{
ButtonWidget.prototype._ShowDisableState.call( this );
}
}
function SimpleTextButton()
{
OOP.CallParentConstructor( this, arguments.callee );
this._text = new TextWidget();
this._enableTextColor = "#000000";
this._disableTextColor = "#808080";
this._textVertMargin = 0;
this._textHorzMargin = 5;
this._Created.Add( Delegate( this, SimpleTextButton.prototype._WidgetCreated ) );
}
OOP.Inherit( SimpleTextButton, ButtonWidget );
SimpleTextButton.prototype._WidgetCreated = function()
{
this._text.Create( this );
this._text.SetStyle( "zIndex", 30000 );
this._text.SetSize( "100%", "100%" );
this._text.SetStyle( "textAlign", "center" );
this._text.SetVertAlignMiddle( true );
this._text.EnableMultipleLines( false );
this.SetStyle( "cursor", "pointer" );
this._text.SetStyle( "cursor", "pointer" );
}
SimpleTextButton.prototype.SetText = function( text )
{
if( text != "" && text != null )
{
this._text.SetText( text );
}
}
SimpleTextButton.prototype.GetTextWidth = function()
{
return this._text.GetTextWidth() + 2 * this._textHorzMargin;
}
SimpleTextButton.prototype.FitTextWidth = function()
{
this.SetWidth( this.GetTextWidth() );
}
SimpleTextButton.prototype.GetTextHeight = function()
{
return this._text.GetTextHeight() + 2 * this._textVertMargin;
}
SimpleTextButton.prototype._ShowDownState = function()
{
this.SetBorder( "inset",
this._borderWidth,
this._borderWidth,
this._borderWidth,
this._borderWidth );
this._text.SetTextColor( this._enableTextColor );
}
SimpleTextButton.prototype._ShowNormalState = function()
{
this.SetBorder( "outset",
this._borderWidth,
this._borderWidth,
this._borderWidth,
this._borderWidth );
this._text.SetTextColor( this._enableTextColor );
}
SimpleTextButton.prototype._ShowHighlightState = function()
{
this.SetBorder( "outset",
this._borderWidth,
this._borderWidth,
this._borderWidth,
this._borderWidth );
this._text.SetTextColor( this._enableTextColor );
}
SimpleTextButton.prototype._ShowDisableState = function()
{
this.SetBorder( "outset",
this._borderWidth,
this._borderWidth,
this._borderWidth,
this._borderWidth );
this._text.SetTextColor( this._disableTextColor );
}
function TextButton()
{
OOP.CallParentConstructor( this, arguments.callee );
this._leftBackground = new BasicWidget();
this._rightBackground = new BasicWidget();
this._middleBackground = new BasicWidget();
this._text = new TextWidget();
this._surface =  new BasicWidget();
this._surfaceMarginLeft = 2;
this._surfaceMarginTop = 2;
this._surfaceMarginRight = 2;
this._surfaceMarginBottom = 2;
this._itemClassNames = {
"left":"",
"right":"",
"middle":""
};
this._Created.Add( Delegate( this, TextButton.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, TextButton.prototype._WidgetResized ) );
}
OOP.Inherit( TextButton, SimpleTextButton );
TextButton.prototype._WidgetCreated = function()
{
this._leftBackground.Create( this );
this._middleBackground.Create( this );
this._rightBackground.Create( this );
this._surface.Create( this );
this._leftBackground.SetStyle( "cursor", "pointer" );
this._middleBackground.SetStyle( "cursor", "pointer" );
this._rightBackground.SetStyle( "cursor", "pointer" );
this._leftBackground.SetStyle( "display", "block" );
this._middleBackground.SetStyle( "display", "block" );
this._rightBackground.SetStyle( "display", "block" );
this._leftBackground.SetStyle( "position", "absolute" );
this._middleBackground.SetStyle( "position", "absolute" );
this._rightBackground.SetStyle( "position", "absolute" );
this.SetButtonBorderWidth( 0 );
this.ApplyDomClasses();
this._surface.SetStyle("position","absolute");
}
TextButton.prototype.ApplyDomClasses = function()
{
this._leftBackground.SetAttribute( "className", this._itemClassNames[ "left" ] );
this._rightBackground.SetAttribute( "className", this._itemClassNames[ "right" ] );
this._middleBackground.SetAttribute( "className", this._itemClassNames[ "middle" ] );
this._ResizeBackground();
}
TextButton.prototype._WidgetResized = function()
{
this._ResizeBackground();
this._text.SetSize(
this.GetWidth(),
this.GetHeight()
);
}
TextButton.prototype._ResizeBackground = function()
{
var width = this.GetClientWidth();
var height = this.GetClientHeight();
var leftWidth = this._leftBackground.GetWidth();
var rightWidth = this._rightBackground.GetWidth();
var middleWidth = width - leftWidth - rightWidth;
if( middleWidth < 0 )
{
middleWidth = 0;
}
var leftPosLeft = 0;
var middlePosLeft = leftPosLeft + leftWidth;
var rightPosLeft = middlePosLeft + middleWidth;
this._leftBackground.SetLocation(leftPosLeft,0);
this._leftBackground.SetStyle( "height", height );
this._middleBackground.SetLocation( middlePosLeft, 0 );
this._middleBackground.SetStyle( "height", height );
this._middleBackground.SetStyle( "width", middleWidth );
this._rightBackground.SetLocation( rightPosLeft, 0 );
this._rightBackground.SetStyle( "height", height );
this._surface.SetUIPosition( true,
this._surfaceMarginLeft,
this._surfaceMarginTop,
width - this._surfaceMarginLeft - this._surfaceMarginRight,
height -this._surfaceMarginTop - this._surfaceMarginBottom
);
}
function ListWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this.SingleItemSelectEvent = new Event();
this._itemClassNames = {
"normal":"",
"highlighted":"",
"seperator":""
};
this._itemArray = new Array();
this._seperatorArray = new Array();
this._listData = new Array();
this._activeIndex = -1;
this._Created.Add( Delegate( this, ListWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, ListWidget.prototype._WidgetResized ) );
this._Destroyed.Add( Delegate( this, ListWidget.prototype._WidgetDestroyed ) );
this._oldClientWidth = 0;
}
OOP.Inherit( ListWidget, BasicWidget );
ListWidget.prototype._WidgetCreated = function()
{
this.SetStyle( "overflow", "auto" );
this.RegisterEvent( "onscroll", Delegate( this, ListWidget.prototype._ScrollPosChanged ) );
}
ListWidget.prototype._WidgetDestroyed = function()
{
}
ListWidget.prototype._ScrollPosChanged = function()
{
var x = this._htmlObject.scrollLeft;
var y = this._htmlObject.scrollTop;
}
ListWidget.prototype._GetActiveItemBorderWidth = function()
{
var borderWidth = 2;
if( this._IsIndexValid( this._activeIndex ) )
{
var activeItem = this._itemArray[this._activeIndex];
if( activeItem != null )
{
var borderLeftWidth = activeItem.Length2Value( "width", activeItem.GetStyle( "borderLeftWidth" ) );
var borderRightWidth = activeItem.Length2Value( "width", activeItem.GetStyle( "borderRightWidth" ) );
borderWidth = borderLeftWidth + borderRightWidth;
}
}
return borderWidth;
}
ListWidget.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
clientWidth = this.GetClientWidth();
if( clientWidth == this._oldClientWidth )
{
return;
}
this._ResizeAllItems( clientWidth );
}
ListWidget.prototype._ResizeAllItems = function( clientWidth )
{
var itemWidth = clientWidth;
if( !NavigatorInfo.IsIE() )
{
itemWidth = itemWidth - this._GetActiveItemBorderWidth();
}
var originalClassName = null;
if( NavigatorInfo.IsFirefox() && this._itemArray.length > 0 )
{
var firstItem = this._itemArray[0];
originalClassName = firstItem.GetAttribute( "className" );
if( this._IsHighlighted(0) )
{
firstItem.SetAttribute( "className", this._itemClassNames[ "normal" ] );
}
else
{
firstItem.SetAttribute( "className", this._itemClassNames[ "highlighted" ] );
}
}
for( var i=0; i<this._itemArray.length; i++ )
{
var item = this._itemArray[i];
item.SetWidth( itemWidth );
}
for( var i=0; i<this._seperatorArray.length; i++ )
{
var item = this._seperatorArray[i];
item.SetWidth( itemWidth );
}
if( NavigatorInfo.IsFirefox() && this._itemArray.length > 0 )
{
this._itemArray[0].SetAttribute( "className", originalClassName );
}
this._oldClientWidth = clientWidth;
}
ListWidget.prototype._OnClick = function( listItem, mouseEvent )
{
mouseEvent = BasicWidget.TranslateEvent( mouseEvent, listItem._htmlObject );
var htmlObj = mouseEvent.srcElement;
var found = false;
for( var i = 0; i<this._itemArray.length; i++ )
{
var item = this._itemArray[i];
if( item.FindHtmlChild( htmlObj ) || item._htmlObject == htmlObj )
{
found = true;
break;
}
}
if( found )
{
this.SelectSingleItem( i );
}
}
ListWidget.prototype.SelectSingleItem = function( index )
{
this.SingleItemSelectEvent( index );
}
ListWidget.prototype._IsIndexValid = function( index )
{
if( typeof( index ) != "number" )
{
Trace.WriteWarning( "The list index should be a number. " );
return false;
}
if( index < 0 )
{
Trace.WriteLine( "The list index should be larger than or equal to 0. " );
return false;
}
if( index >= this.GetItemCount() )
{
Trace.WriteLine( "The list index should be less than the index item count. " );
return false;
}
return true;
}
ListWidget.prototype.HighlightItem = function( index, highlight )
{
if( !this._IsIndexValid( index ) )
{
return;
}
var item = this._itemArray[ index ];
if( highlight )
{
item.SetAttribute( "className", this._itemClassNames[ "highlighted" ] );
}
else
{
item.SetAttribute( "className", this._itemClassNames[ "normal" ] );
}
}
ListWidget.prototype.HighlightSingleItem = function( index )
{
if( typeof( index ) != "number" )
{
Trace.WriteWarning( "The list index should be a number. " );
return;
}
var originalIndex = this._activeIndex;
if( originalIndex >= 0 && originalIndex < this.GetItemCount() )
{
this.HighlightItem( originalIndex, false );
}
if( index >= 0 && index < this.GetItemCount() )
{
this.HighlightItem( index, true );
this.ScrollToItem( index );
}
this._activeIndex = index;
}
ListWidget.prototype.GetHighlightItem = function()
{
return this._activeIndex;
}
ListWidget.prototype.ScrollToItem = function( index )
{
if( !this._IsIndexValid( index ) )
{
return;
}
var item = this._itemArray[ index ];
var itemTop = item._htmlObject.offsetTop;
var itemHeight = item._htmlObject.clientHeight;
var clientTop = this._htmlObject.scrollTop;
var clientHeight = this._htmlObject.clientHeight;
Trace.WriteLine(
"Item top: %1, height: %2. Client top: %3, height: %4",
itemTop,
itemHeight,
clientTop,
clientHeight );
if( clientTop + clientHeight < itemTop + itemHeight )
{
var scrollTop = itemTop + itemHeight - clientHeight;
this._htmlObject.scrollTop = scrollTop > 0 ? scrollTop : 0;
}
else if( clientTop > itemTop )
{
this._htmlObject.scrollTop = itemTop;
}
}
ListWidget.prototype.AddItem = function( item, disableClick )
{
if( item._htmlObject == null )
{
item.Create( this );
}
else
{
}
if( !disableClick )
{
item.RegisterEvent( "onclick", DelegateWithArgs( this, this._OnClick, item ) );
}
item.SetStyle( "position", "relative" );
var clientWidth = this.GetClientWidth();
if( clientWidth > 0 )
{
item.SetWidth( clientWidth );
}
item.SetAttribute( "className", this._itemClassNames[ "normal" ] );
if( this._itemArray.length == this._activeIndex )
{
this.HighlightSingleItem( this._activeIndex );
}
this._itemArray.push( item );
}
ListWidget.prototype.AddSeperator = function( seperator )
{
if( seperator._htmlObject == null )
{
seperator.Create( this );
seperator.innerHTML = "&nbsp;";
}
else
{
}
var clientWidth = this.GetClientWidth();
if( clientWidth > 0 )
{
seperator.SetWidth( clientWidth );
}
seperator.SetAttribute( "className", this._itemClassNames[ "seperator" ] );
this._seperatorArray.push( seperator );
}
ListWidget.prototype.GetItemCount = function()
{
return this._itemArray.length;
}
ListWidget.prototype.GetNearestHighlightedItem = function( index )
{
var highlightedIndex = 0;
for( var i=0; i<this._itemArray.length; i++ )
{
if( this._IsHighlighted( index + i ) )
{
highlightedIndex = index + i;
break;
}
if( this._IsHighlighted( index - i ) )
{
highlightedIndex = index - i;
break;
}
}
return highlightedIndex;
}
ListWidget.prototype._IsHighlighted = function( index )
{
if( index >= this._itemArray.length || index < 0 )
{
return false;
}
var item = this._itemArray[ index ];
return ( item.GetAttribute( "className" ) == this._itemClassNames[ "highlighted" ] );
}
ListWidget.prototype._AddDisplayItem = function( index )
{
}
ListWidget.prototype._AsyncAddNextItem = function( nextIndex )
{
if( nextIndex < this._listData.length )
{
this._AddDisplayItem( nextIndex );
setTimeout(
DelegateWithArgs(
this,
this._AsyncAddNextItem,
nextIndex + 1 ),
0 );
}
else
{
this._OnResize();
}
}
Trace.Wrap( "ListWidget" );
function DefaultMenuItem()
{
OOP.CallParentConstructor( this, arguments.callee );
this._oRow = null;
this._checked = false;
this.ClickedEvent = new Event();
this._checkArea = new BasicWidget();
this._textArea = new BasicWidget();
this._hotkeyArea = new TextWidget();
this._popupArea = new BasicWidget();
this._checkImage = new ImageWidget();
this._titleArea = new TextWidget();
this._descArea = new TextWidget();
this._popupAreaWidth = 16;
this._enableTextColor = "";
this._disableTextColor = "#808080";
this._disabled = false;
this._itemsInfo = null;
}
DefaultMenuItem.ImgCheck = "img/dialogue-selected.gif";
DefaultMenuItem.ImgNonCheck = "";
DefaultMenuItem.prototype.SetTitleClass = function( className )
{
this._titleArea.SetAttribute( "className", className );
}
DefaultMenuItem.prototype.SetDescClass = function( className )
{
this._descArea.SetAttribute( "className", className );
}
DefaultMenuItem.prototype.SetCheckAreaClass = function( className )
{
this._checkArea.SetAttribute( "className", className );
}
DefaultMenuItem.prototype.SetCheckSymbAreaClass = function( className )
{
this._checkImage.SetAttribute( "className", className );
}
DefaultMenuItem.prototype.Enable = function( enable )
{
this._disabled = !enable;
var color = ( enable == true ) ? this._enableTextColor : this._disableTextColor;
this._titleArea.SetTextColor( color );
this._descArea.SetTextColor( color );
this._hotkeyArea.SetTextColor( color );
}
DefaultMenuItem.prototype.Free = function()
{
this._oRow = null;
}
DefaultMenuItem.prototype._CreateItemArea = function( areaWidget, parentWidget )
{
areaWidget.Create( parentWidget );
areaWidget.SetStyle( "position", "static" );
}
DefaultMenuItem.prototype.CreateCheckArea = function( parentWidget )
{
this._CreateItemArea( this._checkArea, parentWidget );
this._checkImage.Create( this._checkArea );
}
DefaultMenuItem.prototype.CreateTextArea = function( parentWidget )
{
this._CreateItemArea( this._textArea, parentWidget );
}
DefaultMenuItem.prototype.CreateHotkeyArea = function( parentWidget )
{
this._CreateItemArea( this._hotkeyArea, parentWidget );
}
DefaultMenuItem.prototype.CreatePopupArea = function( parentWidget )
{
this._CreateItemArea( this._popupArea, parentWidget );
}
DefaultMenuItem.prototype.CreateTitleArea = function( parentWidget )
{
this._CreateItemArea( this._titleArea, parentWidget );
}
DefaultMenuItem.prototype.CreateDescArea = function( parentWidget )
{
this._CreateItemArea( this._descArea, parentWidget );
}
DefaultMenuItem.prototype.SetRow = function( oRow )
{
this._oRow = oRow;
}
DefaultMenuItem.prototype._OnClick = function( eventObject )
{
if( this._disabled )
{
var originalEvent = BasicWidget.GetOriginalEvent( eventObject, this._oRow );
Event.CancelBubble( originalEvent );
}
else
{
this.ClickedEvent( this._checked );
}
}
DefaultMenuItem.prototype.OnKeyPress = function ( eventObject )
{
var theKey = BasicWidget.GetKey( eventObject);
if( theKey == KeyTable.VK_SPACE || theKey == KeyTable.VK_RETURN)
{
if( !this._disabled )
{
this.ClickedEvent( this._checked );
}
}
}
DefaultMenuItem.prototype.SetItemText = function( text, desc )
{
this._titleArea.SetText( text );
this._descArea.SetText( desc );
}
DefaultMenuItem.prototype.SetHotkeyText = function( text )
{
this._hotkeyArea.SetText( text );
}
DefaultMenuItem.prototype.SetCheck = function( check )
{
this._checked = check;
if ( check )
{
this._checkImage.SetURI( DefaultMenuItem.ImgCheck );
this._checkImage.SetStyle( "visibility", "inherit" );
}
else
{
this._checkImage.SetURI( DefaultMenuItem.ImgNonCheck );
this._checkImage.SetStyle( "visibility", "hidden" );
}
}
DefaultMenuItem.prototype.SetItemsInfo = function( itemsInfo )
{
this._itemsInfo = itemsInfo;
}
function MenuManagerImpl()
{
this._menus = new Array();
UIManager.DocumentClickedEvent.Add( Delegate( this, MenuManagerImpl.prototype._ClickedHandler ) );
UIManager.ChildClickedEvent.Add( Delegate( this, MenuManagerImpl.prototype._ChildClickedHandler ) );
UIManager.WindowResizedEvent.Add( Delegate( this, MenuManagerImpl.prototype._ResizedHandler ) );
}
MenuManagerImpl.prototype._ClickedHandler = function()
{
this.HideMenus();
}
MenuManagerImpl.prototype._ChildClickedHandler = function()
{
this.HideMenus();
}
MenuManagerImpl.prototype._ResizedHandler = function()
{
this.HideMenus();
}
MenuManagerImpl.prototype.RegisterMenu = function( menu )
{
this._menus.push( menu );
}
MenuManagerImpl.prototype.HideMenus = function()
{
for( var i=0; i<this._menus.length; i++ )
{
this._menus[i].Hide();
}
}
function MenuWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._menuArea = new BasicWidget();
this._tableObject = null;
this._leftBackArea = null;
this._activeBackArea = null;
this._itemsInfo = new Object();
this._itemsInfo._itemsId = new Array();
this._focusIndex = -1;
this._itemsInfo._items = new Object();
this._activeItem = null;
this._backgroundColor = "#ffffff";
this._activeColor = "#0000ff";
this._itemClassNames = {
"menuItemTitle":"",
"menuItemDesc":"",
"checkArea":"",
"checkSymbArea":"",
"checkCell":"",
"popupCell":""
};
this.iframeLoadedEvent.Add( Delegate( this, MenuWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, MenuWidget.prototype._WidgetResized ) );
this._Destroyed.Add( Delegate( this, MenuWidget.prototype._WidgetDestroyed ) );
this._eventManager = null;
}
OOP.Inherit( MenuWidget, IFrameWidget );
MenuWidget._manager = new MenuManagerImpl();
MenuWidget.prototype._WidgetCreated = function()
{
this.CreateChildWidget( this._menuArea, this.GetId() );
var menuParent = MenuWidget._manager;
this._tableObject = new TableWidget();
this._leftBackArea = new BasicWidget();
this._activeBackArea = new ImageWidget();
menuParent.RegisterMenu( this );
this.Hide();
this._leftBackArea.Create( this._menuArea );
this._leftBackArea.SetAttribute( "className", "MenuLeftBackArea" );
this._leftBackArea.SetStyle( "position", "absolute" );
this._leftBackArea.SetStyle( "height", "100%" );
this._activeBackArea.Create( this._menuArea );
this._activeBackArea.SetStyle( "position", "absolute" );
this._activeBackArea.SetAttribute( "src", "img/thumbnail-selection.gif" );
this._activeBackArea.SetAttribute( "className", "MenuItemSelected" );
this._tableObject.Create( this._menuArea );
this._tableObject._htmlObject.border = 0;
this._tableObject._htmlObject.cellPadding = 0;
this._tableObject._htmlObject.cellSpacing = 0;
this._tableObject.SetAttribute( "className", "MenuTable" );
this._tableObject.SetStyle( "position", "relative" );
this.SetStyle( "position", "absolute" );
this.SetStyle( "borderStyle",  "solid" );
this.SetStyle( "borderColor", "#5C6D8B" );
this.SetBorderWidth( 2, 2, 2, 2 );
this.SetStyle( "zIndex", 65535 );
this._menuArea.RegisterEvent( "onclick", DelegateWithArgs( this, this._OnClick, this._menuArea._htmlObject ) );
this.SetIFrameBodyStyle( "backgroundColor",  this._backgroundColor );
}
MenuWidget.prototype._WidgetDestroyed = function()
{
for ( var id in this._itemsInfo._items )
{
Object.UnregisterAllEvents( this._itemsInfo._items[ id ]._oRow );
this._itemsInfo._items[ id ]._itemsInfo = null;
this._itemsInfo._items[ id ] = null;
}
this._itemsInfo._items = null;
this._itemsInfo = null;
this._activeItem = null;
this._tableObject = null;
this._leftBackArea = null;
this._activeBackArea = null;
this._menuArea = null;
}
MenuWidget.prototype._WidgetResized = function()
{
var height = this._menuArea.GetClientHeight();
this._leftBackArea.SetStyle( "height", height );
}
MenuWidget.prototype._OnMouseOver = function( oRow, mouseEvent )
{
this._FocusItem(false);
this._activeItem = oRow;
this._focusIndex = this._GetMenuIndex( oRow );
this._activeBackArea.SetStyle( "visibility", "visible" );
this._HighlightItem( oRow );
}
MenuWidget.prototype._OnMouseOut = function( mouseEvent )
{
if ( this._activeBackArea._htmlObject )
{
if ( this._activeBackArea._htmlObject.style.visibility != "hidden" )
{
this._activeBackArea.SetStyle( "visibility", "hidden" );
}
}
}
MenuWidget.prototype.AddItem = function( id, menuText, desc, holdRefresh )
{
var currentDocument = this._iframe.contentWindow.document;
var menuItem = new DefaultMenuItem();
this._itemsInfo._items[ id ] = menuItem;
this._itemsInfo._itemsId.push(id);
menuItem._menuId = id;
if ( this._tableObject._htmlObject.tBodies.length == 0 )
{
this._tableObject.AddBody();
}
var oRow = this._tableObject.AddRow();
oRow.style.height = "50px";
oRow.id = id;
Object.RegisterDomEvent( oRow, "onmouseover", DelegateWithArgs( this, this._OnMouseOver, oRow ) );
Object.RegisterDomEvent( oRow, "onmouseout", Delegate( this, this._OnMouseOut ) );
var oCell = null;
var cellWidget = null;
oCell = currentDocument.createElement( "td" );
oCell.id = id + "_check";
oCell.className = this._itemClassNames.checkCell;
oRow.appendChild( oCell );
cellWidget = new BasicWidget();
cellWidget.Attach( oCell, this._tableObject );
menuItem.CreateCheckArea( cellWidget );
oCell = currentDocument.createElement( "td" );
oCell.id = id + "_text";
oRow.appendChild( oCell );
cellWidget = new BasicWidget();
cellWidget.Attach( oCell, this._tableObject );
menuItem.CreateTextArea( cellWidget );
menuItem._textArea._htmlObject.innerHTML =
"<table><tr style='height:20px'><td id=" + id + "_title" +
"></td></tr><tr style='height:20px'><td id=" + id + "_desc" +
"></td></tr></table>";
var textCell = null;
textCell = currentDocument.getElementById( id + "_title" );
cellWidget = new BasicWidget();
cellWidget.Attach( textCell, this._tableObject );
menuItem.CreateTitleArea( cellWidget );
textCell = currentDocument.getElementById( id + "_desc" );
cellWidget = new BasicWidget();
cellWidget.Attach( textCell, this._tableObject );
menuItem.CreateDescArea( cellWidget );
oCell = currentDocument.createElement( "td" );
oCell.id = id + "_hotkey";
oRow.appendChild( oCell );
cellWidget = new BasicWidget();
cellWidget.Attach( textCell, this._tableObject );
menuItem.CreateHotkeyArea( cellWidget );
oCell = currentDocument.createElement( "td" );
oCell.id = id + "_popup";
oCell.className = this._itemClassNames.popupCell;
oRow.appendChild( oCell );
cellWidget = new BasicWidget();
cellWidget.Attach( oCell, this._tableObject );
menuItem.CreatePopupArea( cellWidget );
Object.RegisterDomEvent( oRow, "onclick", Delegate( menuItem, DefaultMenuItem.prototype._OnClick ) );
menuItem.SetRow( oRow );
menuItem.SetItemText( menuText, desc );
menuItem.SetTitleClass( this._itemClassNames.menuItemTitle );
menuItem.SetDescClass( this._itemClassNames.menuItemDesc );
menuItem.SetCheckAreaClass( this._itemClassNames.checkArea );
menuItem.SetCheckSymbAreaClass( this._itemClassNames.checkSymbArea );
menuItem.SetItemsInfo( this._itemsInfo );
if( !holdRefresh )
{
this._OnResize();
}
}
MenuWidget.prototype.GetItem = function( id )
{
if( id in this._itemsInfo._items )
{
return this._itemsInfo._items[ id ];
}
else
{
return null;
}
}
MenuWidget.prototype.EnableItem = function( id, enable )
{
var item = this.GetItem( id );
if( item )
{
item.Enable( enable );
}
}
MenuWidget.prototype._OnClick = function( srcObject, mouseEvent )
{
var originalEvent = BasicWidget.GetOriginalEvent( mouseEvent, srcObject );
Event.CancelBubble( originalEvent );
MenuWidget._manager.HideMenus();
}
MenuWidget.prototype._HighlightItem = function( oRow )
{
if( NavigatorInfo.IsSafari() )
{
var currentDocument = this._iframe.contentWindow.document;
var checkArea = currentDocument.getElementById( oRow.id+"_check" );
var textArea = currentDocument.getElementById( oRow.id+"_text" );
var left = oRow.offsetLeft;
var top = checkArea.offsetTop < textArea.offsetTop? checkArea.offsetTop: textArea.offsetTop;
var height = checkArea.offsetHeight > textArea.offsetHeight? checkArea.offsetHeight: textArea.offsetHeight;
this._activeBackArea.SetStyle( "left", left + 1 );
this._activeBackArea.SetStyle( "top", top + 1 );
this._activeBackArea.SetStyle( "width", "97%" );
this._activeBackArea.SetStyle( "height", height);
}
else
{
var left = oRow.offsetLeft;
var top = oRow.offsetTop;
var width = oRow.clientWidth;
var height = oRow.clientHeight;
this._activeBackArea.SetStyle( "left", left + 1 );
this._activeBackArea.SetStyle( "top", top + 1 );
this._activeBackArea.SetStyle( "width", width - 4 );
this._activeBackArea.SetStyle( "height", height - 4 );
}
this._activeBackArea.SetStyle( "visibility", "visible" );
}
MenuWidget.prototype._FocusItem = function ( isFocus )
{
if(this._focusIndex != -1)
{
var itemId = this._itemsInfo._itemsId[this._focusIndex];
var item = this._itemsInfo._items[itemId];
var oRow = item._oRow;
if(isFocus)
{
this._HighlightItem( oRow );
}
else
{
this._activeBackArea.SetStyle( "visibility", "hidden" );
}
}
}
MenuWidget.prototype._OnKeyDown = function (eventObj)
{
var theKey = BasicWidget.GetKey( eventObj );
switch(theKey)
{
case KeyTable.VK_ESCAPE:
this.Hide();
break;
case KeyTable.VK_RETURN:
case KeyTable.VK_SPACE:
if( this._focusIndex != -1 )
{
this._itemsInfo._items[this._itemsInfo._itemsId[this._focusIndex]].OnKeyPress(eventObj);
this.Hide();
}
else
{
this.Hide();
}
break;
case KeyTable.VK_UP:
if( this._focusIndex == -1 )
{
this._focusIndex = this._itemsInfo._itemsId.length -1;
}
else
{
this._FocusItem(false);
if((this._focusIndex -1)>=0)
{
this._focusIndex = this._focusIndex - 1;
}
else
{
this._focusIndex = 0;
}
}
this._FocusItem(true);
break;
case KeyTable.VK_DOWN:
if(this._focusIndex == -1)
{
this._focusIndex = 0;
}
else
{
this._FocusItem(false);
if((this._focusIndex+1)< this._itemsInfo._itemsId.length)
{
this._focusIndex = this._focusIndex + 1;
}
else
{
this._focusIndex = this._itemsInfo._itemsId.length - 1;
}
}
this._FocusItem(true);
break;
default:
break;
}
}
MenuWidget.prototype._GetMenuIndex = function(oRow)
{
var menuIndex = -1;
for(var i=0;i<this._itemsInfo._itemsId.length;i++)
{
if(this._itemsInfo._itemsId[i] == oRow.id)
{
menuIndex = i;
break;
}
}
return menuIndex;
}
MenuWidget.prototype.InitializeFocusIndex = function()
{
this._focusIndex = -1;
}
MenuWidget.prototype.UninitializeFocusIndex = function()
{
this._FocusItem(false);
this._focusIndex = -1;
}
MenuWidget.prototype.AddSeperator = function()
{
var currentDocument = this._iframe.contentWindow.document;
var oRow = currentDocument.createElement( "tr" );
oRow.appendChild( currentDocument.createElement( "td" ) );
var oCell = currentDocument.createElement( "td" );
var oHr = currentDocument.createElement( "hr" );
oRow.style.height = 3;
oRow.appendChild( oCell );
oCell.colSpan = 3;
oCell.appendChild( oHr );
this._tableObject._htmlObject.tBodies[0].appendChild( oRow );
}
MenuWidget.prototype.Hide = function()
{
if( this.IsVisible() )
{
this.UninitializeFocusIndex();
this.SetStyle( "visibility","hidden" );
this.SetUIPosition( true,0,0,UISettings.mainFrameWidthMin, UISettings.mainFrameHeightMin, true );
UIManager.RefreshScreenEvent();
this._OnMouseOut();
}
}
MenuWidget.prototype.Show = function()
{
if( !this.IsVisible() )
{
this.SetStyle( "visibility","visible" );
this._OnResize();
this.InitializeFocusIndex();
}
}
MenuWidget.prototype.IsVisible = function()
{
return ( this.GetStyle( "visibility" )  != "hidden" );
}
MenuWidget.prototype.GetMenuWidth = function()
{
var tableWidth = this._tableObject.GetWidth();
var paddingLeft = this.Length2Value("width", this.GetStyle("paddingLeft"));
var paddingRight = this.Length2Value("width", this.GetStyle("paddingRight" ));
var marginLeft = this.Length2Value("width", this.GetStyle("marginLeft" ));
var marginRight = this.Length2Value("width", this.GetStyle("marginRight" ));
var borderLeft = this.Length2Value("width", this.GetStyle("borderLeftWidth" ));
var borderRight = this.Length2Value("width", this.GetStyle("borderRightWidth" ));
var menuWidth = tableWidth + paddingLeft + paddingRight + marginLeft + marginRight + borderLeft + borderRight;
return menuWidth;
}
MenuWidget.prototype.GetMenuHeight = function()
{
var tableHeight = this._tableObject.GetHeight();
var paddingTop = this.Length2Value("height", this.GetStyle("paddingTop"));
var paddingBottom = this.Length2Value("height", this.GetStyle("paddingBottom" ));
var marginTop = this.Length2Value("height", this.GetStyle("marginTop" ));
var marginBottom = this.Length2Value("height", this.GetStyle("marginBottom" ));
var borderTop = this.Length2Value("height", this.GetStyle("borderTopWidth" ));
var borderBottom = this.Length2Value("height", this.GetStyle("borderBottomWidth" ));
var menuHeight = tableHeight + paddingTop + paddingBottom + marginTop + marginBottom + borderTop + borderBottom;
return menuHeight;
}
Trace.Wrap( "MenuWidget" );
function ButtonBarWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this.ActiveItemChangedEvent = new Event();
this._uiCount = 0;
this._buttonWidth = 30;
this._buttonHeight = 30;
this._buttonHorzMargin = 5;
this._buttons = new Object();
this._buttonUIArray = new Array();
}
OOP.Inherit( ButtonBarWidget, BasicWidget );
ButtonBarWidget.prototype.SetUILayout = function( uiCount, width, height, hMargin )
{
this._uiCount = uiCount;
this._buttonWidth = width;
this._buttonHeight = height;
this._buttonHorzMargin = hMargin;
}
ButtonBarWidget.prototype.GetContentWidth = function()
{
var buttonUICount = this._uiCount;
if( buttonUICount == 0 )
{
width = 0;
}
else
{
width = buttonUICount * this._buttonWidth +
( buttonUICount + 1 ) * this._buttonHorzMargin;
}
return width;
}
ButtonBarWidget.prototype.GetContentHeight = function()
{
var height = this._buttonHeight;
return height;
}
ButtonBarWidget.prototype.AddButton = function(
id,
text,
normalImage,
downImage,
disabledImage,
highlightImage )
{
var button = new ImageButton();
button.Create( this, id );
button.SetStyle( "visibility",  "hidden" );
button.SetImages( normalImage, downImage, disabledImage, highlightImage );
button.SetAttribute( "title", text );
this._buttons[ id ] = button;
}
ButtonBarWidget.prototype.GetButton = function( name )
{
var oButton = this._buttons[ name ];
return oButton;
}
ButtonBarWidget.prototype.ShowButton = function( name, index )
{
var originalName = this._buttonUIArray[ index ];
var originalButton = this._buttons[ originalName ];
if( originalButton )
{
originalButton.SetStyle( "visibility",  "hidden" );
}
var button = this._buttons[ name ];
var buttonLeft = this._buttonHorzMargin + index * ( this._buttonWidth + this._buttonHorzMargin );
var buttonTop = 0;
button.SetUIPosition(
true,
buttonLeft,
buttonTop,
this._buttonWidth,
this._buttonHeight );
button.SetStyle( "visibility",  "inherit" );
this._buttonUIArray[ index ] = name;
}
ButtonBarWidget.prototype.EnableButton = function( name, enable )
{
var button = this.GetButton( name );
button.EnableButton( enable );
}
Trace.Wrap( "ButtonBarWidget" );
function Horz3PartsImages()
{
OOP.CallParentConstructor( this, arguments.callee );
this.leftPartWidth = 2;
this.rightPartWidth = 2;
this.leftPart = new ImageWidget();
this.middlePart = new ImageWidget();
this.rightPart = new ImageWidget();
this._Created.Add( Delegate( this, Horz3PartsImages.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, Horz3PartsImages.prototype._WidgetResized ) );
}
OOP.Inherit( Horz3PartsImages, BasicWidget );
Horz3PartsImages.prototype._WidgetCreated = function()
{
this.leftPart.Create( this );
this.middlePart.Create( this );
this.rightPart.Create( this );
}
Horz3PartsImages.prototype._WidgetResized = function()
{
var width = this.GetWidth();
var height = this.GetHeight();
var leftPartWidth = this.leftPartWidth;
var rightPartWidth = this.rightPartWidth;
this.leftPart.SetUIPosition(
true,
0,
0,
this.leftPart._originalWidth,
height );
this.middlePart.SetUIPosition(
true,
leftPartWidth,
0,
width - leftPartWidth - rightPartWidth,
height );
this.rightPart.SetUIPosition(
true,
width - rightPartWidth,
0,
this.rightPart._originalWidth,
height );
}
function MenuBarButtonForeground()
{
OOP.CallParentConstructor( this, arguments.callee );
this._table = new TableWidget();
this._image = new ImageWidget();
this._text = new TextWidget();
this._expandIcon = new ImageWidget();
this._imageWidth = 16;
this._expandIconWidth = 16;
this._Created.Add( Delegate( this, MenuBarButtonForeground.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, MenuBarButtonForeground.prototype._WidgetResized ) );
}
OOP.Inherit( MenuBarButtonForeground, BasicWidget );
MenuBarButtonForeground.prototype._WidgetCreated = function()
{
this._table.Create( this );
var item;
item = this._table.AddCell( 0, 0, 1, 1 );
item.SetStyle( "width", this._imageWidth );
this._image.Create( item );
item = this._table.AddCell( 0, 0, 1, 1 );
this._text.Create( item );
item = this._table.AddCell( 0, 0, 1, 1 );
this.SetStyle( "width", this._expandIconWidth );
this._expandIcon.Create( item );
this._text.SetStyle( "position", "static" );
this._text.EnableMultipleLines( false );
this.SetStyle( "cursor", "pointer" );
this._text.SetStyle( "cursor", "pointer" );
}
MenuBarButtonForeground.prototype._WidgetResized = function()
{
var width = this.GetWidth();
var height = this.GetHeight();
this._table.SetUIPosition(
true,
0,
0,
width,
height );
var textWidth = width - this._imageWidth - this._expandIconWidth;
this._text.SetStyle( "width", textWidth );
}
MenuBarButtonForeground.prototype.SetIcon = function( uri )
{
this._image.SetURI( uri );
}
MenuBarButtonForeground.prototype.SetExpandIcon = function( uri )
{
this._expandIcon.SetURI( uri );
}
MenuBarButtonForeground.prototype.SetText = function( text )
{
if( text == null )
{
text = "";
}
this._text.SetText( text );
}
function MenuBarButton()
{
OOP.CallParentConstructor( this, arguments.callee );
this.backgrounds = {
normal: new Horz3PartsImages(),
highlighted: new Horz3PartsImages(),
pushed: new Horz3PartsImages(),
disabled: new Horz3PartsImages() };
this.foreground = new MenuBarButtonForeground();
this._backgroundImages = null;
this.foregroundLeftMargin = 3;
this.foregroundRightMargin = 3;
this._Created.Add( Delegate( this, MenuBarButton.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, MenuBarButton.prototype._WidgetResized ) );
}
OOP.Inherit( MenuBarButton, ButtonWidget );
MenuBarButton.prototype.SetBackgroundImages = function( images )
{
this._backgroundImages = images;
}
MenuBarButton.prototype._WidgetCreated = function()
{
Object.ForEach( this.backgrounds, BasicWidget.prototype.Create, this );
this.foreground.Create( this );
this.backgrounds.normal.leftPart.SetURI( this._backgroundImages[ "normalLeft" ] );
this.backgrounds.normal.middlePart.SetURI( this._backgroundImages[ "normalMiddle" ] );
this.backgrounds.normal.rightPart.SetURI( this._backgroundImages[ "normalRight" ] );
this.backgrounds.disabled.leftPart.SetURI( this._backgroundImages[ "disabledLeft" ] );
this.backgrounds.disabled.middlePart.SetURI( this._backgroundImages[ "disabledMiddle" ] );
this.backgrounds.disabled.rightPart.SetURI( this._backgroundImages[ "disabledRight" ] );
this.backgrounds.highlighted.leftPart.SetURI( this._backgroundImages[ "highlightedLeft" ] );
this.backgrounds.highlighted.middlePart.SetURI( this._backgroundImages[ "highlightedMiddle" ] );
this.backgrounds.highlighted.rightPart.SetURI( this._backgroundImages[ "highlightedRight" ] );
this.backgrounds.pushed.leftPart.SetURI( this._backgroundImages[ "pushedLeft" ] );
this.backgrounds.pushed.middlePart.SetURI( this._backgroundImages[ "pushedMiddle" ] );
this.backgrounds.pushed.rightPart.SetURI( this._backgroundImages[ "pushedRight" ] );
}
MenuBarButton.prototype._WidgetResized = function()
{
var width = this.GetWidth();
var height = this.GetHeight();
Object.ForEach( this.backgrounds, BasicWidget.prototype.SetUIPosition, true, 0, 0, width, height );
this.foreground.SetUIPosition(
true,
this.foregroundLeftMargin,
0,
width - this.foregroundLeftMargin - this.foregroundRightMargin,
height );
}
MenuBarButton.prototype._ShowDownState = function()
{
for( var name in this.backgrounds )
{
var visibility = ( ( name == "pushed" ) ? "inherit" : "hidden" );
this.backgrounds[ name ].SetStyle( "visibility", visibility );
}
}
MenuBarButton.prototype._ShowNormalState = function()
{
for( var name in this.backgrounds )
{
var visibility = ( ( name == "normal" ) ? "inherit" : "hidden" );
this.backgrounds[ name ].SetStyle( "visibility", visibility );
}
}
MenuBarButton.prototype._ShowHighlightState = function()
{
for( var name in this.backgrounds )
{
var visibility = ( ( name == "highlighted" ) ? "inherit" : "hidden" );
this.backgrounds[ name ].SetStyle( "visibility", visibility );
}
}
MenuBarButton.prototype._ShowDisableState = function()
{
for( var name in this.backgrounds )
{
var visibility = ( ( name == "disabled" ) ? "inherit" : "hidden" );
this.backgrounds[ name ].SetStyle( "visibility", visibility );
}
}
function MenuBarWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this.popDown = false;
this.leftMargin = 5;
this.rightMargin = 5;
this.topMargin = 1;
this.bottomMargin = 1;
this.seperatorWidth = 5;
this._horzMargin = 5;
this._buttons = new Object();
this._menus = new Object();
this._menuAreaWidth = -1;
this._Resized.Add( Delegate( this, MenuBarWidget.prototype._WidgetResized ) );
}
OOP.Inherit( MenuBarWidget, BasicWidget );
MenuBarWidget.prototype._WidgetResized = function()
{
this._ResizeButtons();
}
MenuBarWidget.prototype._ResizeButtons = function()
{
var buttonCount = Object.GetPropertyCount( this._buttons );
if( buttonCount < 1 )
{
return;
}
var clientHeight = this.GetClientHeight();
var clientWidth = this.GetClientWidth();
var buttonTop = this.topMargin;
var buttonHeight = clientHeight - buttonTop - this.bottomMargin;
var buttonLeft = this.leftMargin;
var totalButtonWidth = clientWidth - buttonLeft - this.rightMargin;
var buttonWidth = ( totalButtonWidth - ( buttonCount - 1 ) * this.seperatorWidth ) / buttonCount;
for( var itemName in this._buttons )
{
var menuButton = this._buttons[ itemName ];
menuButton.SetUIPosition(
true,
buttonLeft,
buttonTop,
buttonWidth,
buttonHeight );
buttonLeft += buttonWidth + this.seperatorWidth;
}
}
MenuBarWidget.prototype.SetButtonBackgroundImages = function( images )
{
this._buttonBackgroundImages = images;
}
MenuBarWidget.prototype.AddMenu = function(
id,
text,
iconUrl,
expandIconUrl )
{
var item = new MenuBarButton();
item.SetBackgroundImages( this._buttonBackgroundImages );
item._itemClassNames = this._itemClassNames;
item.Create( this, id + "_button" );
item.foreground.SetIcon( iconUrl );
item.foreground.SetExpandIcon( expandIconUrl );
item.ClickEvent = new Event();
item.ClickEvent.Add( DelegateWithArgs( this, this._OnItemClicked, id ) );
item.KeyDownEvent = new Event();
item.KeyDownEvent.Add( DelegateWithArgs( this, this._OnKeyDown, id ) );
item.SetAttribute( "title", text );
item.foreground.SetText( text );
this._buttons[ id ] = item;
var menu = new MenuWidget();
menu.Create( null, id );
menu.SetOwner( this );
menu.SetUIPosition( true,0,0,UISettings.mainFrameWidthMin, UISettings.mainFrameHeightMin,true );
this._menus[ id ] = menu;
return menu;
}
MenuBarWidget.prototype.GetMenu = function( id )
{
var menu = this._menus[ id ];
return menu;
}
MenuBarWidget.prototype.GetItem = function(id)
{
var item = this._buttons[ id ];
return item;
}
MenuBarWidget.prototype._OnItemClicked = function( itemId, sender, translatedEvent, originalEvent )
{
Event.CancelBubble( originalEvent );
var menu = this._menus[ itemId ];
if( menu.IsVisible() )
{
menu.Hide();
}
else
{
this._ShowMenu( itemId );
}
}
MenuBarWidget.prototype._ShowMenu = function( itemId )
{
var menu = this._menus[ itemId ];
MenuWidget._manager.HideMenus();
var item = this._buttons[ itemId ];
var itemPageLeft = item.GetLeftInBody();
var itemPageTop = item.GetTopInBody();
var menuWidth = menu.GetMenuWidth();
var menuLeft = itemPageLeft;
if( this._menuAreaWidth > 0 )
{
if( menuLeft + menuWidth > this._menuAreaWidth )
{
menuWidth = this._menuAreaWidth - itemPageLeft;
}
}
if( menuLeft + menuWidth > document.body.offsetWidth )
{
menuWidth = document.body.offsetWidth - itemPageLeft;
}
menu.Show();
menu.SetWidth( menuWidth );
var menuHeight = menu.GetMenuHeight();
if( NavigatorInfo.IsSafari() )
{
menuHeight = menu.GetMenuHeight();
}
var menuTop = itemPageTop + item.GetHeight();
if( !this.popDown )
{
menuTop = itemPageTop - menuHeight;
}
menu.SetUIPosition(true, menuLeft, menuTop, menuWidth, menuHeight, true);
}
MenuBarWidget.prototype._OnKeyDown = function( itemId, eventObj )
{
var menu = this._menus[ itemId ];
var theKey = BasicWidget.GetKey( eventObj );
if( menu.IsVisible())
{
if(theKey == KeyTable.VK_TAB)
{
menu.Hide();
}
else
{
menu._OnKeyDown( eventObj );
}
}
else
{
if( theKey == KeyTable.VK_SPACE || theKey == KeyTable.VK_RETURN)
{
this._ShowMenu( itemId );
}
}
}
MenuBarWidget.prototype.SetMenuAreaWidth = function( menuAreaWidth )
{
this._menuAreaWidth = menuAreaWidth;
}
Trace.Wrap( "MenuBarWidget" );
function TabBarWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this.ActiveItemChangedEvent = new Event();
this._items = new Object();
this._itemArray = new Array();
this._highlightedItemCommandId = null;
this._focusIndex = -1;
this._tabIndex =  0;
this._firstItemLeftMargin = 8;
this._lastItemRightMargin = 8;
this._highlightedItemTop = 0;
this._highlightedItemHeight = 22;
this._normalItemTop = 2;
this._normalItemHeight = 19;
this._itemTextPaddingLeft = 8;
this._itemTextPaddingRight = 8;
this._itemClassNames = {
"highlightedLeft":"",
"highlightedMiddle":"",
"highlightedRight":"",
"normalLeft":"",
"normalMiddle":"",
"normalRight":""
};
this._Created.Add( Delegate( this, TabBarWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, TabBarWidget.prototype._WidgetResized ) );
}
OOP.Inherit( TabBarWidget, BasicWidget );
TabBarWidget.prototype._WidgetCreated = function()
{
this.SetTabIndex(UISettings.tabIndexDisable);
}
TabBarWidget.prototype._WidgetResized = function()
{
this._ResizeItems();
}
TabBarWidget.prototype._ResizeItems = function()
{
var leftMargin = this._firstItemLeftMargin;
var rightMargin = this._lastItemRightMargin;
var clientWidth = this.GetClientWidth();
var itemCount = this._itemArray.length;
var highlightedItem = this._GetItemByCommandId( this._highlightedItemCommandId );
var left = leftMargin;
var width = ( clientWidth - leftMargin - rightMargin ) / itemCount;
for( var i=0; i<this._itemArray.length; i++ )
{
var item = this._itemArray[i];
var top = this._normalItemTop;
var height = this._normalItemHeight;
if( highlightedItem === item )
{
top = this._highlightedItemTop;
height = this._highlightedItemHeight;
}
item.SetUIPosition(
true,
left,
top,
width,
height );
left += width;
}
}
TabBarWidget.prototype.AddItem = function(
id,
commandId,
text )
{
var item = new TextButton();
item.SetButtonBorderWidth( 0 );
item.Create( this, id );
item.ClickEvent.Add( DelegateWithArgs( this, this._OnItemClicked, commandId ) );
item.KeyDownEvent = new Event();
item.KeyDownEvent.Add( Delegate( this, this._OnKeyDown ) );
item.SetAttribute( "title", text );
item._text.SetStyle( "paddingLeft", this._itemTextPaddingLeft );
item._text.SetStyle( "paddingRight", this._itemTextPaddingRight );
item.SetText( text );
this._SetItemClasses( item, "normal" );
item.commandId = commandId;
this._items[ commandId ] = item;
this._itemArray.push( item );
if( this._focusIndex == -1 )
{
this._focusIndex = 0;
this._itemArray[this._focusIndex].SetTabIndex( this._tabIndex );
}
}
TabBarWidget.prototype._GetItemByCommandId = function( commandId )
{
var item = this._items[ commandId ];
return item;
}
TabBarWidget.prototype._OnItemClicked = function( commandId )
{
if( this.ActiveItemChangedEvent != null )
{
this.ActiveItemChangedEvent( commandId );
}
else
{
this.ActiveItemByCommandId( commandId );
}
this._FocusItem();
}
TabBarWidget.prototype._SetItemClasses = function( item, type )
{
item.SetItemClassName(
"middle",
this._itemClassNames[ type + "Middle" ] );
item.SetItemClassName(
"left",
this._itemClassNames[ type + "Left" ] );
item.SetItemClassName(
"right",
this._itemClassNames[ type + "Right" ] );
item.ApplyDomClasses();
}
TabBarWidget.prototype.ActiveItemByCommandId = function( commandId )
{
if( commandId == this._highlightedItemCommandId )
{
return;
}
var originalItem = this._GetItemByCommandId( this._highlightedItemCommandId );
if( originalItem != null )
{
this._SetItemClasses( originalItem, "normal" );
this._highlightedItemCommandId = null;
}
var item = this._GetItemByCommandId( commandId );
if( item != null )
{
this._SetItemClasses( item, "highlighted" );
this._highlightedItemCommandId = commandId;
this._highlightedItemCommandId = commandId;
this._ChangeFocusIndex( this._highlightedItemCommandId );
this._FocusItem();
}
this._ResizeItems();
}
TabBarWidget.prototype._ChangeFocusIndex = function( commandId )
{
this._itemArray[this._focusIndex].SetTabIndex(UISettings.tabIndexDisable);
this._focusIndex = this.GetArrayIndexByCommandId( commandId );
this._itemArray[this._focusIndex].SetTabIndex(this._tabIndex);
}
TabBarWidget.prototype._OnKeyDown = function ( eventObj )
{
if(this._focusIndex != -1)
{
var theKey = BasicWidget.GetKey( eventObj );
var index = -1;
switch (theKey)
{
case KeyTable.VK_LEFT:
if((this._focusIndex-1)>=0)
{
index = this._focusIndex - 1;
}
else
{
index = 0;
}
this._OnItemClicked(this._itemArray[index].commandId);
break;
case KeyTable.VK_RIGHT:
if((this._focusIndex+1)<this._itemArray.length)
{
index = this._focusIndex + 1;
}
else
{
index = this._itemArray.length-1;
}
this._OnItemClicked(this._itemArray[index].commandId);
break;
default:
break;
}
}
}
TabBarWidget.prototype._FocusItem = function ()
{
if(this._focusIndex != -1 )
{
this._itemArray[this._focusIndex].SetFocus();
}
}
TabBarWidget.prototype.GetArrayIndexByCommandId = function ( commandId )
{
var index = -1;
for(var i = 0; i<this._itemArray.length; i++)
{
if(this._itemArray[i].commandId == commandId)
{
index = i;
}
}
return index;
}
Trace.Wrap( "TabBarWidget" );
function WmvWidget()
{
if( window.ActiveXObject )
{
OOP.ApplyInstance( this, WmvObjectWidget );
}
else
if( NavigatorInfo.IsSafari())
{
OOP.ApplyInstance( this, WmvQuickTimeWidget );
}
else
{
OOP.ApplyInstance( this, WmvEmbededWidget );
}
}
WmvWidget.blankWmvUri = "blank.wmv";
WmvWidget.playState = new Object();
WmvWidget.playState.Undefined = 0;
WmvWidget.playState.Stopped = 1;
WmvWidget.playState.Paused = 2;
WmvWidget.playState.Playing = 3;
WmvWidget.playState.ScanForward = 4;
WmvWidget.playState.ScanReverse = 5;
WmvWidget.playState.Buffering = 6;
WmvWidget.playState.Waiting = 7;
WmvWidget.playState.MediaEnded = 8;
WmvWidget.playState.Transitioning = 9;
WmvWidget.playState.Ready = 10;
WmvWidget.playState.Reconnecting = 11;
WmvWidget.openState = new Object();
WmvWidget.openState.BeginCodecAcquisition = 14;
WmvWidget.openState.EndCodecAcquisition = 15;
WmvWidget.error = new Object();
WmvWidget.error.PlayerNotAvailable = 1;
WmvWidget.error.GetMediaUriError = 100;
WmvWidget.error.MediaPublishError = 201;
WmvWidget.error.GeneralError = 300;
WmvWidget.error.MediaNotReady = 0x10000001;
WmvWidget.error.InteractionEnabled = 0x10000002;
WmvWidget.error.MinWmpError = 0x80000000;
WmvWidget.displaySize = new Object();
WmvWidget.displaySize.MpDefaultSize = 0;
WmvWidget.displaySize.MpFitToSize = 4;
function WmvWidgetBase()
{
OOP.CallParentConstructor( this, arguments.callee );
this.VisibilityChangeEvent = new Event();
this._mmObject = null;
this._mediaList = new MediaList();
this._preSettings = new Object();
this._preSettings.audioEnabled = true;
this._preSettings.autoStart = true;
this._preSettings.uiEnabled = false;
this._preSettings.displaySize = WmvWidget.displaySize.MpFitToSize;
this._preSettings.defaultWidth = 0;
this._preSettings.defaultHeight = 0;
this._preSettings.windowlessVideo = false;
this._enableInteraction = false;
this._targetUri = new Object();
this._targetUri.value = "";
this._targetUri.modified = false;
this._targetStates = new Object();
this._targetStates.value = WmvWidget.playState.Stopped;
this._targetStates.modified = false;
this._targetRate = new Object();
this._targetRate.modified = false;
this._targetRate.value = 1.0;
this._targetPosition = new Object();
this._targetPosition.modified = false;
this._targetPosition.currentPosition = 0;
this._targetInteractionFlag = new Object();
this._targetInteractionFlag.modified = false;
this._targetInteractionFlag.enableInteraction = false;
this._needUpdateInnerSettings = new Object();
this._innerState = WmvWidget.playState.Undefined;
this._isFilePlayable = true;
this._simpleState = WmvWidget.playState.Stopped;
this.playStateChangedEvent = new Event();
this.positionChangedEvent = new Event();
this.seekCompletedEvent = new Event();
this.errorEvent = new Event();
this.infoEvent = new Event();
this.showCodecMissingEvent = new Event();
this.beginCodecDownloadEvent = new Event();
this.endCodecDownloadEvent = new Event();
this._codecState = new Object();
this._codecState.missingState = false;
this._codecState.wmvFileName = "";
this._isCheckingCodec = false;
this._timerForParamsUpdating = null;
this._Created.Add( Delegate( this, WmvWidgetBase.prototype._WidgetCreated ) );
this._Destroyed.Add( Delegate( this, WmvWidgetBase.prototype._WidgetDestroyed ) );
}
OOP.Inherit( WmvWidgetBase, BasicWidget );
WmvWidgetBase.prototype._WidgetCreated = function()
{
this._mediaList.GetUriFailed.Add(
Delegate( this, WmvWidgetBase.prototype._GetMediaUriFailed ) );
this._mediaList.GetUriSucceeded.Add(
Delegate( this, WmvWidgetBase.prototype._GetMediaUriSucceeded ) );
this._timerForParamsUpdating = setInterval(
Delegate( this, WmvWidgetBase.prototype._OnTimerForParamsUpdating ),
500 );
}
WmvWidgetBase.prototype._WidgetDestroyed = function()
{
this.Stop();
if( this._timerForParamsUpdating )
{
clearInterval( this._timerForParamsUpdating );
this._timerForParamsUpdating = null;
}
if( this._mmObject )
{
this._mmObject = null;
this._htmlObject.innerHTML = "";
}
}
WmvWidgetBase.prototype.CheckEnabled = function()
{
if( !NavigatorInfo.WmvEnabled() )
{
this._OnError( WmvWidget.error.PlayerNotAvailable );
}
}
WmvWidgetBase.prototype._GetWmpId = function()
{
return this.GetId() + "_WMP";
}
WmvWidgetBase.prototype.EnableReadyStateChecking = function( enable )
{
this._mediaList.EnableReadyStateChecking( enable );
}
WmvWidgetBase.prototype.SetAutoStart = function( autoStart )
{
this._preSettings.autoStart = autoStart;
}
WmvWidgetBase.prototype.EnableAudio = function( enable )
{
this._preSettings.audioEnabled = enable;
if ( !enable )
{
this.Mute( true );
}
}
WmvWidgetBase.prototype.IsAudioEnabled = function()
{
return this._preSettings.audioEnabled;
}
WmvWidgetBase.prototype.GetSimpleState = function()
{
return this._simpleState;
}
WmvWidgetBase.prototype._IsValidActionState = function( state )
{
return (
( state == WmvWidget.playState.Playing ) ||
( state == WmvWidget.playState.Paused ) ||
( state == WmvWidget.playState.Stopped ) );
}
WmvWidgetBase.prototype._ClearState = function()
{
this._targetPosition.modified = false;
this._targetPosition.currentPosition = 0;
this._targetStates.modified = false;
this._targetStates.value = WmvWidget.playState.Stopped;
this._targetUri.modified = false;
this._targetUri.value = "";
this._codecState.missingState = false;
this._codecState.wmvFileName = "";
this._targetRate.value = 1.0;
this._targetRate.modified = false;
this._simpleState = WmvWidget.playState.Stopped;
this._isFilePlayable = true;
this._lastErrorCode = 0;
}
WmvWidgetBase.prototype.SetURI = function( state, uri, entry, startTime )
{
if( this._IsCodecMissing() )
{
this._CodecMissingHandler();
return;
}
if( !NavigatorInfo.WmvEnabled() )
{
this._OnError( WmvWidget.error.PlayerNotAvailable );
this._isCheckingCodec = false;
setTimeout(
DelegateWithArgs(
this,
WmvWidgetBase.prototype.FirePlayStateChangedEvent,
this._simpleState ),
0
);
return;
}
if( uri == null )
{
uri = "";
}
this._ClearState();
if( this._isCheckingCodec )
{
setTimeout(
DelegateWithArgs(
this,
WmvWidgetBase.prototype.FirePlayStateChangedEvent,
WmvWidget.playState.Buffering ),
0
);
}
if( typeof( startTime ) != "number" )
{
startTime = 0;
}
this._SetTargetPosition( startTime );
this._SetTargetState( state );
if( uri.match( /\.xml$/i ) )
{
if( !this._mediaList.GetMediaUri( uri, entry ) )
{
this._SetTargetUri( "" );
this._UpdateParams();
}
}
else
{
this._SetTargetUri( uri );
this._UpdateParams();
}
}
WmvWidgetBase.prototype.Reset = function()
{
if( this._targetUri.value == "" )
{
if( this._lastErrorCode != 0 )
{
this._OnError( this._lastErrorCode );
}
}
else
{
this._isFilePlayable = true;
this._targetUri.modified = true;
this._UpdateParams();
}
}
WmvWidgetBase.prototype._GetMediaUriFailed = function( errorCode )
{
var newErrorCode = WmvWidget.error.GetMediaUriError;
switch( errorCode )
{
case MediaList.error.MediaPublishError:
newErrorCode = WmvWidget.error.MediaPublishError;
break;
case MediaList.error.MediaNotReady:
newErrorCode = WmvWidget.error.MediaNotReady;
break;
default:
break;
}
this._SetTargetUri( "" );
this._UpdateParams();
this._OnError( newErrorCode );
}
WmvWidgetBase.prototype._GetMediaUriSucceeded = function( href )
{
this._SetTargetUri( href );
this._UpdateParams();
}
WmvWidgetBase.prototype.SeekWithoutCompletedEvent = function( pos, state )
{
this.SetPosition( pos, state );
}
WmvWidgetBase.prototype.Seek = function( pos, state )
{
this.SetPosition( pos, state );
setTimeout( Delegate( this, this.seekCompletedEvent ), 0 );
}
WmvWidgetBase.prototype.SetPosition = function( pos, state )
{
if( this._IsValidPos( pos ) )
{
this._SetTargetPosition( pos );
this._UpdateParams();
this._SetTargetState( state );
this._UpdateParams();
}
else
{
this._InvalidPositionHandler( pos, state );
}
}
WmvWidgetBase.prototype._InvalidPositionHandler = function( pos, state )
{
this.UpdateCurrentPosition( pos );
if( this._simpleState == WmvWidget.playState.Stopped )
{
setTimeout( DelegateWithArgs( this, WmvWidgetBase.prototype.FirePlayStateChangedEvent, this._simpleState ) ,0 );
}
else
{
this._SetTargetState(WmvWidget.playState.Stopped);
this._UpdateParams();
}
}
WmvWidgetBase.prototype.UpdateCurrentPosition = function( pos )
{
this._targetPosition.currentPosition = pos;
}
WmvWidgetBase.prototype._OnError = function( errorCode, errorDescription )
{
if ( errorCode != 0xC00D11D4 )
{
this.errorEvent( errorCode, errorDescription );
this._isFilePlayable = false;
this._lastErrorCode = errorCode;
if( this._isCheckingCodec )
{
this.codecDownloadedEvent();
this._isCheckingCodec = false;
}
}
}
WmvWidgetBase.prototype._DecodeWmvUri = function( uri )
{
if( uri == "" || uri == null )
{
return "";
}
if( UriUtils.IsWebUrl( uri ) || !NavigatorInfo.IsIE() )
{
try
{
uri = UriUtils.DecodeUri( uri );
}catch(e)
{
throw e;
}
}
else
{
uri = unescape( uri );
}
return uri;
}
WmvWidgetBase.prototype._SetTargetUri = function( uri )
{
if( uri == null )
{
uri = "";
this._OnError(WmvWidget.error.GetMediaUriError);
}
try
{
uri = this._DecodeWmvUri( uri );
}catch(e)
{
uri = "";
this._OnError(WmvWidget.error.GetMediaUriError);
}
this._targetUri.value = uri;
this._targetUri.modified = true;
}
WmvWidgetBase.prototype._SetTargetState = function( state )
{
this._targetStates.value = state;
this._targetStates.modified = true;
}
WmvWidgetBase.prototype._SetTargetPosition = function( pos )
{
this._targetPosition.currentPosition = pos;
this._targetPosition.modified = true;
}
WmvWidgetBase.prototype._SetTargetInteractionFlag = function( enable )
{
this._targetInteractionFlag.enableInteraction = enable;
this._targetInteractionFlag.modified = true;
}
WmvWidget.prototype.EnableInteraction = function( enable, forceUpdate )
{
if( this._IsCodecMissing() )
{
this._CodecMissingHandler();
return;
}
this._SetTargetInteractionFlag( enable );
if( forceUpdate )
{
this._ApplyInteractionFlag();
}
}
WmvWidgetBase.prototype.IsInteractionEnabled = function()
{
return this._enableInteraction;
}
WmvWidgetBase.prototype._OnInteractionEnabled = function( enable )
{
if( this._IsCodecMissing() )
{
this._CodecMissingHandler();
return;
}
if( enable )
{
this.infoEvent( WmvWidget.error.InteractionEnabled );
}
else
{
this.infoEvent( null );
}
}
WmvWidgetBase.prototype._ChangeVisibility = function( show )
{
if( this._preSettings.uiEnabled || this._enableInteraction )
{
show = true;
}
if( this._mmObject != null && this._mmObject.parentNode != null )
{
if( show )
{
this._mmObject.style.visibility = "inherit";
}
else
{
this._mmObject.style.visibility = "hidden";
}
setTimeout( DelegateWithArgs(this, this.VisibilityChangeEvent, show ), 0 );
}
}
WmvWidgetBase.prototype._OnTimerForParamsUpdating = function()
{
if( !this._targetUri.modified  &&
!this._targetStates.modified &&
!this._targetPosition.modified &&
!this._targetRate.modified &&
!this._InnerSettingsNeedUpdated())
{
return;
}
this._UpdateParams();
}
WmvWidgetBase.prototype._InnerSettingsNeedUpdated = function()
{
for( var innerSetting in this._needUpdateInnerSettings )
{
if( this._needUpdateInnerSettings[ innerSetting ] )
{
return true;
}
}
return false;
}
WmvWidgetBase.prototype._IsValidPos = function( pos )
{
var duration = this.GetDuration();
if( duration > 0 && pos > duration )
{
return false;
}
return true;
}
WmvWidgetBase.prototype._IsCodecMissing = function()
{
return this._codecState.missingState;
}
WmvWidgetBase.prototype.SetCodecMissingFlag = function( codecMissingFlag, wmvFileName )
{
this._codecState.missingState = codecMissingFlag;
this._codecState.wmvFileName = wmvFileName;
}
WmvWidgetBase.prototype._CodecMissingHandler = function()
{
setTimeout( DelegateWithArgs( this, WmvWidgetBase.prototype.FirePlayStateChangedEvent, WmvWidget.playState.Ready ), 0 );
this.showCodecMissingEvent();
}
WmvWidgetBase.prototype.SetCodecCheckerFlag = function( flag )
{
this._isCheckingCodec = false;
}
WmvWidgetBase.prototype.FirePlayStateChangedEvent = function( state )
{
if( this._isCheckingCodec )
{
this.playStateChangedEvent( WmvWidget.playState.Buffering );
}
else
{
this.playStateChangedEvent( state );
}
}
WmvWidgetBase.prototype.DeleteWMVObject = function()
{
}
WmvWidgetBase.prototype.SetVolume = function()
{
}
WmvWidgetBase.prototype.Mute = function( toMute)
{
}
WmvWidgetBase.prototype.SetDisplaySize = function( displaySize, defaultWidth, defaultHeight )
{
this._preSettings.displaySize = displaySize;
this._preSettings.defaultWidth = defaultWidth;
this._preSettings.defaultHeight = defaultHeight;
}
WmvWidgetBase.prototype.SetWindowlessVideo = function( windowlessVideo )
{
this._preSettings.windowlessVideo = windowlessVideo;
}
Trace.Wrap( "WmvWidgetBase" );
function WmvObjectWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._guarder = new WmpGuarder( this );
this._duration = 0;
this._volume = 1;
this._mute = false;
this._everPlayOverZeroSecond = false;
this._Created.Add( Delegate( this, WmvObjectWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, WmvObjectWidget.prototype._WidgetResized ) );
}
OOP.Inherit( WmvObjectWidget, WmvWidgetBase );
WmvObjectWidget.prototype._WidgetCreated = function()
{
if( !NavigatorInfo.WmvEnabled() )
{
return;
}
this._DisableSelectWMVObject();
this.VisibilityChangeEvent.Add( Delegate( this, WmvObjectWidget.prototype._OnVisibilityChange) );
this._CreateWMVObject();
this._InitializeWMVObject();
}
WmvObjectWidget.prototype._CreateWMVObject = function( showControlUi )
{
this._mmObject = null;
var wmpId = this._GetWmpId();
var str = "";
str += this._GetChildObjectEventString( wmpId, "playStateChange(NewState)" );
str += this._GetChildObjectEventString( wmpId, "positionChange(OldPosition,NewPosition)" );
str += this._GetChildObjectEventString( wmpId, "error()" );
str += this._GetChildObjectEventString( wmpId, "openStateChange(NewState)" );
this._htmlObject.innerHTML = "<OBJECT ID=" + wmpId +
" CLASSID='CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6'>" +
"<PARAM name='uiMode' value='" +
( ( this._preSettings.uiEnabled || this._enableInteraction ) ? "full" : "none" )+"' />" +
"<PARAM name='enableContextMenu' value='false' />" +
"<PARAM name='windowlessVideo' value='"+(this._preSettings.windowlessVideo?"true":"false")+"' />" +
"<span>WMV</span>" +
"</OBJECT>" + str;
}
WmvObjectWidget.prototype._InitializeWMVObject = function()
{
var wmpId = this._GetWmpId();
var currentDocument = this._htmlObject.ownerDocument;
oMM = currentDocument.getElementById( wmpId );
if( oMM != null )
{
try
{
oMM.settings.autoStart = this._preSettings.autoStart;
oMM.stretchToFit = true;
oMM.settings.setMode( "autoRewind", false );
oMM.settings.enableErrorDialogs = false;
}catch(e)
{
this._DeleteWMVObject();
this._OnError( WmvWidget.error.PlayerNotAvailable );
return;
}
oMM.style.visibility = ( this._preSettings.uiEnabled || this._enableInteraction ) ? "inherit" : "hidden";
oMM.tabIndex = UISettings.tabIndexDisable;
}
else
{
this._DeleteWMVObject();
this._OnError( WmvWidget.error.PlayerNotAvailable );
return;
}
this._mmObject = oMM;
oMM = null;
Trace.WriteData( this._mmObject, 1, "WMVObject" );
}
WmvObjectWidget.prototype._OnVisibilityChange = function( show )
{
if( show )
{
this._DisableFullScreenMode();
}
}
WmvObjectWidget.prototype._DisableFullScreenMode = function()
{
if( this._mmObject )
{
try
{
var isFullScreen = this._mmObject.fullScreen;
}catch( e )
{
}
}
}
WmvObjectWidget.prototype._DisableSelectWMVObject = function()
{
this.RegisterEvent("onselectstart", Delegate( this, WmvObjectWidget.prototype._OnMouseSelect ) );
}
WmvObjectWidget.prototype._OnMouseSelect = function()
{
return false;
}
WmvObjectWidget.prototype.NormalizeErrorCode = function( errorCode )
{
if( errorCode < 0 )
{
errorCode = 0x100000000 + errorCode;
}
return errorCode;
}
WmvObjectWidget.prototype._error = function()
{
var errorCode = WmvWidget.error.GeneralError;
var errorDescription = "";
try
{
errorCode = this.NormalizeErrorCode( this._mmObject.error.item(0).errorCode );
errorDescription = this._mmObject.error.item(0).errorDescription;
}catch(e)
{
errorCode = WmvWidget.error.GeneralError;
errorDescription = "";
}
setTimeout(
DelegateWithArgs(
this,
WmvObjectWidget.prototype._OnError,
errorCode,
errorDescription ),
0 );
}
WmvObjectWidget.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
if( clientWidth <= 0 )
{
clientWidth = 1;
}
if( clientHeight <= 0 )
{
clientHeight = 1;
}
if( this._mmObject )
{
this._mmObject.style.width = clientWidth;
this._mmObject.style.height = clientHeight;
}
}
WmvObjectWidget.prototype._UpdatePosition = function()
{
if( !this._targetPosition.modified )
{
return;
}
var duration = this.GetDuration();
if ( duration == 0 && this._simpleState != WmvWidget.playState.Stopped )
{
return;
}
else
if( duration > 0 && this._targetPosition.currentPosition > duration )
{
if( this._simpleState == WmvWidget.playState.Playing )
{
this._SetTargetState( WmvWidget.playState.Stopped );
}
}
else
{
try
{
this._mmObject.controls.currentPosition = this._targetPosition.currentPosition;
}catch(e)
{
return;
}
}
this._targetPosition.modified = false;
}
WmvObjectWidget.prototype._UpdateRate = function()
{
if( !this._targetRate.modified )
{
return;
}
try
{
this._mmObject.settings.rate = this._targetRate.value;
}catch(e)
{
return;
}
var currentRate = this.GetRate();
if ( Math.abs( this._targetRate.value - currentRate ) < 0.0001 )
{
this._targetRate.modified = false;
}
}
WmvObjectWidget.prototype._ApplyInteractionFlag = function()
{
if( this._IsCodecMissing() )
{
this._targetInteractionFlag.modified = false;
this._CodecMissingHandler();
return;
}
if( !this._targetInteractionFlag.modified || this._mmObject == null )
{
return;
}
if( this._targetInteractionFlag.enableInteraction )
{
this._ChangeVisibility( true );
}
if( this._enableInteraction != this._targetInteractionFlag.enableInteraction )
{
this._enableInteraction = this._targetInteractionFlag.enableInteraction;
setTimeout( DelegateWithArgs( this, WmvObjectWidget.prototype._ChangeUiMode ), 0);
}
this._targetInteractionFlag.modified = false;
this._OnInteractionEnabled( this._enableInteraction );
}
WmvObjectWidget.prototype._ChangeUiMode = function()
{
var enableUI = this._preSettings.uiEnabled || this._enableInteraction;
if( this._mmObject )
{
try
{
if( enableUI )
{
this._mmObject.uiMode = "full";
}
else
{
this._mmObject.uiMode = "none";
}
}catch(e)
{
this._needUpdateInnerSettings.uiMode = true;
return;
}
this._DisableFullScreenMode( this._mmObject );
}
this._needUpdateInnerSettings.uiMode = false;
}
WmvObjectWidget.prototype.Play = function()
{
if( this._IsValidPos( this._targetPosition.currentPosition ) )
{
this._SetTargetState( WmvWidget.playState.Playing );
this._UpdateParams();
}
else
{
this._InvalidPositionHandler( this._targetPosition.currentPosition, WmvWidget.playState.Playing );
}
}
WmvObjectWidget.prototype.Stop = function()
{
this._SetTargetState( WmvWidget.playState.Stopped );
this._SetTargetPosition( 0 );
this._UpdateParams();
}
WmvObjectWidget.prototype.Pause = function()
{
if( this._IsPaused() )
{
this._simpleState = WmvWidget.playState.Paused;
return;
}
this._SetTargetState( WmvWidget.playState.Paused );
this._UpdateParams();
}
WmvObjectWidget.prototype._IsPaused = function()
{
return (
this._innerState == WmvWidget.playState.Paused ||
this._innerState == WmvWidget.playState.Ready );
}
WmvObjectWidget.prototype.GetRelativePosition = function()
{
var pos = this._targetPosition.currentPosition;
if( this._mmObject )
{
try
{
pos = this._mmObject.controls.currentPosition;
}catch(e)
{
pos = this._targetPosition.currentPosition;
}
}
return pos;
}
WmvObjectWidget.prototype.Mute = function( toMute )
{
if( !this._preSettings.audioEnabled )
{
toMute = true;
}
this._mute = toMute;
if( this._IsCodecMissing() )
{
this._needUpdateInnerSettings.mute = false;
this._CodecMissingHandler();
return;
}
if( this._mmObject && this.IsMuted() != toMute )
{
try
{
this._mmObject.settings.mute = toMute;
}catch(e)
{
this._needUpdateInnerSettings.mute = true;
return;
}
if( !toMute )
{
this.SetVolume( this._volume );
}
}
this._needUpdateInnerSettings.mute = false;
}
WmvObjectWidget.prototype.IsMuted = function()
{
var isMuted = this._mute;
if( this._mmObject )
{
try
{
isMuted = this._mmObject.settings.mute;
}
catch( e )
{
isMuted = this._mute;
}
}
else
{
isMuted = this._mute;
}
return isMuted;
}
WmvObjectWidget.prototype.SetVolume = function( volume )
{
this._volume = volume;
if( this._IsCodecMissing() )
{
this._needUpdateInnerSettings.volume = false;
this._CodecMissingHandler();
return;
}
var isMuted = this.IsMuted();
if( this._mmObject && !isMuted)
{
volume *= 100;
try
{
this._mmObject.settings.volume = volume;
}catch(e)
{
this._needUpdateInnerSettings.volume = true;
return;
}
}
this._needUpdateInnerSettings.volume = false;
}
WmvObjectWidget.prototype.GetVolume = function()
{
var volume = this._volume;
if( this._mmObject )
{
try
{
volume = this._mmObject.settings.volume;
}catch(e)
{
volume = this._volume;
}
}
return volume;
}
WmvObjectWidget.prototype._SetTargetRate = function( rate )
{
this._targetRate.value = rate;
this._targetRate.modified = true;
}
WmvObjectWidget.prototype.SetRate = function( rate )
{
if( this._mmObject )
{
var currentRate = this.GetRate();
if ( Math.abs( rate - currentRate ) > 0.0001 )
{
this._SetTargetRate( rate );
this._UpdateParams();
}
else
{
this._targetRate.modified = false;
}
}
}
WmvObjectWidget.prototype.GetRate = function()
{
var rate = this._targetRate.value;
if( this._mmObject )
{
try
{
rate = this._mmObject.settings.rate;
}catch(e)
{
rate = this._targetRate.value;
}
}
return rate;
}
WmvObjectWidget.prototype.GetState = function()
{
return this._innerState;
}
WmvObjectWidget.prototype.GetDuration = function()
{
var duration = 0;
if( this._mmObject && this._mmObject.controls.isAvailable( "currentItem" ) )
{
try
{
duration = this._mmObject.controls.currentItem.duration;
}catch(e)
{
}
}
return duration;
}
WmvObjectWidget.prototype.IsBuffering = function()
{
if( this._isCheckingCodec )
{
return true;
}
if( this._IsCodecMissing() )
{
return false;
}
var buffering = false;
switch( this._innerState )
{
case WmvWidget.playState.Buffering:
case WmvWidget.playState.Waiting:
case WmvWidget.playState.Transitioning:
case WmvWidget.playState.Reconnecting:
buffering = true;
break;
default:
break;
}
return buffering;
}
WmvObjectWidget.prototype._UpdateUri = function()
{
if( !this._targetUri.modified )
{
return;
}
this._ApplyInteractionFlag();
var wmpError = this._mmObject.error;
if( wmpError )
{
wmpError.clearErrorQueue();
}
try
{
if( UriUtils.IsWebUrl( this._targetUri.value ) )
{
this._mmObject.URL = UriUtils.EncodeUri( this._targetUri.value );
}
else
{
this._mmObject.URL = this._targetUri.value;
}
this._everPlayOverZeroSecond = false;
this._targetUri.modified = false;
}
catch( e )
{
var errorCode = this.NormalizeErrorCode( e.number );
this._mmObject.URL = "";
this._OnError( errorCode );
}
}
WmvObjectWidget.prototype._UpdateStates = function()
{
if( !this._targetStates.modified )
{
return;
}
this._ApplyInteractionFlag();
var playAction = null;
var show = true;
switch( this._targetStates.value )
{
case WmvWidget.playState.Playing:
playAction = "play";
show = true;
break;
case WmvWidget.playState.Paused:
playAction = "pause";
show = false;
break;
case WmvWidget.playState.Stopped:
playAction = "stop";
show = false;
break;
default:
return;
}
this._ChangeVisibility( show );
if( this._mmObject.URL == "" ||
this._targetStates.value == this._simpleState )
{
this._simpleState = this._targetStates.value;
setTimeout(
DelegateWithArgs(
this,
WmvWidgetBase.prototype.FirePlayStateChangedEvent,
this._simpleState ),
0
);
this._targetStates.modified = false;
return;
}
var available = this._mmObject.controls.isAvailable(
playAction );
if( available )
{
try
{
this._mmObject.controls[ playAction ]();
}
catch( e )
{
return;
}
}
else
{
return;
}
this._simpleState = this._targetStates.value;
setTimeout(
DelegateWithArgs(
this,
WmvWidgetBase.prototype.FirePlayStateChangedEvent,
this._simpleState ),
0
);
this._targetStates.modified = false;
}
WmvObjectWidget.prototype._positionChange = function( oldPosition, newPosition )
{
if ( newPosition > 0 )
{
this._everPlayOverZeroSecond = true;
}
setTimeout( DelegateWithArgs( this, this.positionChangedEvent, oldPosition, newPosition ), 0 );
}
WmvObjectWidget.prototype._playStateChange = function( newState )
{
this._innerState = newState;
switch( newState )
{
case WmvWidget.playState.Undefined:
case WmvWidget.playState.Stopped:
case WmvWidget.playState.Ready:
this._simpleState = WmvWidget.playState.Stopped;
break;
case WmvWidget.playState.Paused:
this._simpleState = WmvWidget.playState.Paused;
break;
case WmvWidget.playState.MediaEnded:
if( this._isCheckingCodec )
{
this._isCheckingCodec = false;
}
case WmvWidget.playState.Buffering:
case WmvWidget.playState.Waiting:
case WmvWidget.playState.Transitioning:
case WmvWidget.playState.Reconnecting:
case WmvWidget.playState.Playing:
case WmvWidget.playState.ScanForward:
case WmvWidget.playState.ScanReverse:
this._simpleState = WmvWidget.playState.Playing;
break;
default:
break;
}
if( !this._preSettings.audioEnabled )
{
this.Mute( true );
}
var outputState = this._simpleState;
setTimeout(
DelegateWithArgs(
this,
WmvWidgetBase.prototype.FirePlayStateChangedEvent,
outputState ),
0 );
}
WmvObjectWidget.prototype._UpdateParams = function()
{
if( this._IsCodecMissing() )
{
this._targetStates.modified = false;
this._targetPosition.modified = false;
this._targetRate.modified = false;
this._targetUri.modified = false;
this._CodecMissingHandler();
return;
}
if( this._mediaList.IsParsingUri() )
{
return;
}
if( this._mmObject == null )
{
this._simpleState = WmvWidget.playState.Stopped;
this._targetStates.modified = false;
return;
}
if( this._targetUri.modified )
{
this._UpdateUri();
}
if( !this._targetUri.modified && this._targetStates.modified && this._IsStableState() )
{
this._UpdateStates();
}
if( !this._targetUri.modified && !this._targetStates.modified && this._IsStableState() )
{
this._UpdatePosition();
this._UpdateRate();
}
if( this._InnerSettingsNeedUpdated() )
{
this._UpdateInnerSettings();
}
}
WmvObjectWidget.prototype._UpdateInnerSettings = function()
{
if( this._needUpdateInnerSettings.mute )
{
this.Mute( this._mute );
}
if( this._needUpdateInnerSettings.volume )
{
this.SetVolume( this._volume );
}
if( this._needUpdateInnerSettings.uiMode )
{
this._ChangeUiMode();
}
}
WmvObjectWidget.prototype._IsStableState = function()
{
if( this._mmObject == null )
{
return false;
}
var state = WmvWidget.playState.Undefined;
try
{
state = this._mmObject.playState;
}catch(e)
{
return false;
}
switch( state )
{
case WmvWidget.playState.Undefined:
case WmvWidget.playState.Stopped:
case WmvWidget.playState.Ready:
case WmvWidget.playState.Paused:
case WmvWidget.playState.Playing:
case WmvWidget.playState.ScanForward:
case WmvWidget.playState.ScanReverse:
case WmvWidget.playState.MediaEnded:
return true;
default:
return false;
}
}
WmvObjectWidget.prototype._openStateChange = function( state )
{
switch( state )
{
case WmvWidget.openState.BeginCodecAcquisition:
setTimeout( Delegate( this, WmvObjectWidget.prototype._OnBeginCodecAcquisition ), 0 );
break;
case WmvWidget.openState.EndCodecAcquisition:
setTimeout( Delegate( this, WmvObjectWidget.prototype._OnEndCodecAcquisition ), 0 );
break;
default:
}
}
WmvObjectWidget.prototype._OnBeginCodecAcquisition = function()
{
this._codecState.missingState = true;
this._isCheckingCodec = true;
this.beginCodecDownloadEvent( this._targetUri.value );
}
WmvObjectWidget.prototype._OnEndCodecAcquisition = function()
{
this._codecState.missingState = true;
this._isCheckingCodec = false;
this._DeleteWMVObject();
this.endCodecDownloadEvent();
this.FirePlayStateChangedEvent( WmvWidget.playState.Ready );
}
WmvObjectWidget.prototype._DeleteWMVObject = function()
{
this._mmObject = null;
this._htmlObject.innerHTML = "";
}
WmvObjectWidget.prototype.SetCodecCheckerFlag = function( flag )
{
this._isCheckingCodec = flag;
}
Trace.Wrap( "WmvObjectWidget" );
function WmpGuarder( wmvObj )
{
this._wmvObj = wmvObj;
this._timer = setInterval( Delegate( this, WmpGuarder.prototype.OnTimer ), 500 );
}
WmpGuarder.prototype.OnTimer = function()
{
if ( this._wmvObj._targetStates.playState == WmvWidget.playState.Playing )
{
if ( this._wmvObj._innerState == WmvWidget.playState.Ready )
{
try
{
this._wmvObj.Play();
}catch(e)
{
}
}
else if ( (this._wmvObj._innerState == WmvWidget.playState.Stopped) && (!this._wmvObj._everPlayOverZeroSecond) )
{
try
{
this._wmvObj.Play();
}catch(e)
{
}
}
}
}
Trace.Wrap( "WmpGuarder" );
function WmvEmbededWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._mute = "0";
this._volume = 100;
this._timerForUpdateVolume = null;
this._isRefreshingScreen = false;
this._Created.Add( Delegate( this, WmvEmbededWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, WmvEmbededWidget.prototype._WidgetResized ) );
}
OOP.Inherit( WmvEmbededWidget, WmvWidgetBase );
WmvEmbededWidget.prototype._ConvertVolumeValue = function( value )
{
var scaledValue = 0;
if(value <= 0)
{
scaledValue = -10000;
}
else
if(value >=100)
{
scaledValue = 0;
}
else
{
scaledValue = (Math.log(value*100)/Math.log(10))*2500 - 10000;
}
return scaledValue;
}
WmvEmbededWidget.prototype._GetWmpDisplayWidth = function()
{
var width = 0;
switch( this._preSettings.displaySize )
{
case WmvWidget.displaySize.MpDefaultSize:
width = this._preSettings.defaultWidth+2;
break;
default:
width = this.GetClientWidth();
break;
}
if( width < 1 ) width = 1;
return width;
}
WmvEmbededWidget.prototype._GetWmpDisplayHeight = function()
{
var height = 0;
switch( this._preSettings.displaySize )
{
case WmvWidget.displaySize.MpDefaultSize:
height = this._preSettings.defaultHeight+2;
break;
default:
height = this.GetClientHeight();
break;
}
if( height < 1 )
{
height = 1;
}
return height;
}
WmvEmbededWidget.prototype._ReconfigWmp = function( isPlaying )
{
var oWMP = this._mmObject;
var currentDocument = this._htmlObject.ownerDocument;
if( oWMP == null )
{
var wmpId = this._GetWmpId();
var width = this._GetWmpDisplayWidth();
var height = this._GetWmpDisplayHeight();
oWMP = currentDocument.createElement("embed");
oWMP.setAttribute("id", wmpId);
oWMP.setAttribute("type", "application/asx");
oWMP.setAttribute("width",""+width);
oWMP.setAttribute("height",""+height);
oWMP.setAttribute("animationatstart",""+0);
oWMP.setAttribute("autoSize","1");
oWMP.setAttribute("allowChangeDisplaySize","1");
oWMP.setAttribute("displaySize",""+0);
oWMP.setAttribute( "enablecontextmenu", "0" );
oWMP.tabIndex = UISettings.tabIndexDisable;
}
oWMP.setAttribute( "src", this._targetUri.value );
oWMP.setAttribute( "mute", this._mute );
oWMP.setAttribute( "volume", this._ConvertVolumeValue(this._volume) );
oWMP.setAttribute( "currentPosition", this._targetPosition.currentPosition );
oWMP.setAttribute( "showcontrols", ( this._enableInteraction|| this._preSettings.uiEnabled ? "1" : "0" ) );
oWMP.setAttribute("autoStart",""+ ( isPlaying ? 1 : 0 ) );
oWMP.setAttribute( "uiMode", (this._enableInteraction|| this._preSettings.uiEnabled)?"full":"none");
if( this._preSettings.displaySize == WmvWidget.displaySize.MpDefaultSize )
{
this.SetStyle( "overflow", "auto" );
}
else
{
this.SetStyle( "overflow", "hidden" );
}
this._htmlObject.appendChild( oWMP );
this._mmObject = currentDocument.getElementById( this._GetWmpId() );
oWMP = null;
}
WmvEmbededWidget.prototype._ChangeParamForEmbeded = function()
{
this._ApplyInteractionFlag();
if( this._mediaList.IsParsingUri() || this._isRefreshingScreen )
{
return;
}
if( this._mmObject )
{
if( this._mmObject.parentNode == this._htmlObject )
{
try{
if( this._htmlObject.firstChild == this._mmObject )
{
this._htmlObject.removeChild( this._mmObject );
}
else
{
return;
}
}catch( e )
{
return;
}
}
}
var isPlaying = ( this._targetStates.value == WmvWidget.playState.Playing );
if( ( isPlaying || this._enableInteraction ) && this._targetUri.value != "" )
{
if( !BasicWidget.IsHiddenInBody( this._htmlObject,false ) )
{
this._ReconfigWmp( isPlaying );
this._targetPosition.modified = false;
this._targetStates.modified = false;
this._targetUri.modified = false;
}
}
else
{
this._targetPosition.modified = false;
this._targetStates.modified = false;
this._targetUri.modified = false;
}
this._simpleState = this._targetStates.value;
this.VisibilityChangeEvent( this._simpleState == WmvWidget.playState.Playing );
setTimeout( DelegateWithArgs( this, this.playStateChangedEvent, this._simpleState ), 0 );
}
WmvEmbededWidget.prototype._WidgetCreated = function()
{
if( NavigatorInfo.WmvEnabled() )
{
this.RegisterEvent( "onscroll", Delegate ( this, this._RefreshScreen ) );
UIManager.RefreshScreenEvent.Add( Delegate( this, WmvEmbededWidget.prototype._RefreshScreen ) );
}
}
WmvEmbededWidget.prototype._WidgetResized = function()
{
if( this._mmObject )
{
this._mmObject.width = this._GetWmpDisplayWidth();
this._mmObject.height = this._GetWmpDisplayHeight();
if( this._mmObject.parentNode == this._htmlObject )
{
this._targetStates.modified = true;
this._ChangeParamForEmbeded();
}
}
}
WmvEmbededWidget.prototype.EnableInteraction = function( enable, forceUpdate )
{
this._SetTargetInteractionFlag( enable );
if( forceUpdate )
{
this._ChangeParamForEmbeded();
}
}
WmvEmbededWidget.prototype._ApplyInteractionFlag = function()
{
if( !this._targetInteractionFlag.modified )
{
return;
}
this._enableInteraction = this._targetInteractionFlag.enableInteraction;
this._targetInteractionFlag.modified = false;
this._OnInteractionEnabled( this._enableInteraction );
}
WmvEmbededWidget.prototype.Play = function()
{
this._SetTargetState( WmvWidget.playState.Playing );
this._UpdateParams();
}
WmvEmbededWidget.prototype.Stop = function()
{
this._SetTargetState( WmvWidget.playState.Stopped );
this._UpdateParams();
}
WmvEmbededWidget.prototype.Pause = function()
{
this._SetTargetState( WmvWidget.playState.Paused );
this._UpdateParams();
}
WmvEmbededWidget.prototype.IsBuffering = function()
{
return false;
}
WmvEmbededWidget.prototype.GetRelativePosition = function()
{
var pos = 0;
return pos;
}
WmvEmbededWidget.prototype.Mute = function( toMute )
{
if( !this._preSettings.audioEnabled )
{
toMute = true;
}
this._mute = toMute?"1":"0";
this._targetStates.modified = true;
this._ChangeParamForEmbeded();
}
WmvEmbededWidget.prototype.IsMuted = function()
{
return this._mute=="1";
}
WmvEmbededWidget.prototype.SetVolume = function( volume )
{
this._volume = volume*100;
var isMuted = this.IsMuted();
if( isMuted )
{
return;
}
if( this._timerForUpdateVolume == null )
{
this._timerForUpdateVolume = setTimeout( Delegate( this, WmvEmbededWidget.prototype._UpdateVolume ), 1000 );
}
}
WmvEmbededWidget.prototype._UpdateVolume = function()
{
this._timerForUpdateVolume = null;
this._targetStates.modified = true;
this._ChangeParamForEmbeded();
}
WmvEmbededWidget.prototype.GetVolume = function()
{
return this._volume;
}
WmvEmbededWidget.prototype.SetRate = function( rate )
{
}
WmvEmbededWidget.prototype.GetRate = function()
{
var rate = 1;
return rate;
}
WmvEmbededWidget.prototype.GetState = function()
{
var state = WmvWidget.playState.Undefined;
state = this._simpleState;
return state;
}
WmvEmbededWidget.prototype.GetDuration = function()
{
var duration = 0;
return duration;
}
WmvEmbededWidget.prototype._UpdateParams = function()
{
if( this._targetUri.modified || this._targetStates.modified || this._targetPosition.modified || this._targetRate.modified )
{
this._ChangeParamForEmbeded();
}
if( this._InnerSettingsNeedUpdated() )
{
this._UpdateInnerSettings();
}
}
WmvEmbededWidget.prototype.SetPosition = function( pos, state )
{
this.positionChangedEvent( this.GetRelativePosition(), pos );
this._SetTargetPosition( pos );
this._SetTargetState( state );
this._UpdateParams();
}
WmvEmbededWidget.prototype.DeleteWMVObject = function()
{
if(  this._mmObject != null && this._mmObject.parentNode == this._htmlObject )
{
try{
this._htmlObject.removeChild( this._mmObject );
}catch(e)
{}
}
this._mmObject = null;
this._htmlObject.innerHTML = "";
}
WmvEmbededWidget.prototype._RefreshScreen = function()
{
if(  this._mmObject != null && this._mmObject.parentNode == this._htmlObject )
{
this._isRefreshingScreen = true;
setTimeout(Delegate(this, WmvEmbededWidget.prototype._HideWmp), 0);
}
}
WmvEmbededWidget.prototype._HideWmp = function()
{
this._mmObject.style.visibility = "hidden";
setTimeout(Delegate(this,WmvEmbededWidget.prototype._ShowWmp), 100);
}
WmvEmbededWidget.prototype._ShowWmp = function( )
{
this._mmObject.style.visibility = "inherit";
this._isRefreshingScreen = false;
}
WmvEmbededWidget.prototype._CheckCurrentUiMode = function()
{
if( this._mmObject && this._mmObject.parentNode == this._htmlObject )
{
var enableUI = this._enableInteraction || this._preSettings.uiEnabled;
var uiMode = enableUI?"full":"none";
var currentUiMode = "undefined";
try
{
currentUiMode = this._mmObject.uiMode;
}catch( e )
{
}
if( uiMode != currentUiMode )
{
this._needUpdateInnerSettings.uiMode = true;
}
else
{
this._needUpdateInnerSettings.uiMode = false;
}
}
else
{
this._needUpdateInnerSettings.uiMode = false;
}
}
WmvEmbededWidget.prototype._InnerSettingsNeedUpdated = function()
{
this._CheckCurrentUiMode();
return WmvWidgetBase.prototype._InnerSettingsNeedUpdated.call( this );
}
WmvEmbededWidget.prototype._UpdateInnerSettings = function()
{
if( this._needUpdateInnerSettings.uiMode )
{
this._ChangeUiMode();
}
}
WmvEmbededWidget.prototype._ChangeUiMode = function()
{
if( this._mmObject && this._mmObject.parentNode == this._htmlObject )
{
var enableUI = this._enableInteraction || this._preSettings.uiEnabled;
var uiMode = enableUI?"full":"none";
try
{
this._mmObject.uiMode = uiMode;
}catch(e)
{
}
}
this._needUpdateInnerSettings.uiMode = false;
}
Trace.Wrap( "WmvEmbededWidget" );
function WmvQuickTimeWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._timerForParamsUpdating = null;
this._volume = 1;
this._mute = false;
this._rate = 1;
this._Created.Add( Delegate( this, WmvQuickTimeWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, WmvQuickTimeWidget.prototype._WidgetResized ) );
}
OOP.Inherit( WmvQuickTimeWidget, WmvWidgetBase );
WmvQuickTimeWidget.prototype._WidgetCreated = function()
{
if( NavigatorInfo.WmvEnabled() )
{
var qtObject = null;
var wmpId = this._GetWmpId();
var innerHTML = "<EMBED ID=" + wmpId +
" src='Wvc1.wmv' " +
" type=video/quicktime "+
"enablejavascript=true "+
"autoplay=true "+
"controller="+(this._enableInteraction?"true":"false")+" "+
"scale='aspect' "+
"saveembedtags=true "+
"volume="+(this._volume*255) +
" mute="+(this._mute?"true ":"false ") +
"><span>QuickTime</span></EMBED>" ;
this._htmlObject.innerHTML = innerHTML;
var currentDocument = this._htmlObject.ownerDocument;
qtObject = currentDocument.getElementById( wmpId );
if( qtObject != null )
{
qtObject.style.visibility = ( this._preSettings.uiEnabled || this._enableInteraction ) ? "inherit" : "hidden";
qtObject.tabIndex = UISettings.tabIndexDisable;
}
else
{
this._OnError( WmvWidget.error.PlayerNotAvailable );
}
this._mmObject = qtObject;
qtObject = null;
Trace.WriteData( this._mmObject, 1, "WmvQuickTimeWidget" );
}
}
WmvQuickTimeWidget.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
if( clientWidth <= 0 )
{
clientWidth = 1;
}
if( clientHeight <= 0 )
{
clientHeight = 1;
}
if( this._mmObject )
{
this._mmObject.style.width = clientWidth;
this._mmObject.style.height = clientHeight;
this._mmObject.width = clientWidth;
this._mmObject.height = clientHeight;
}
}
WmvQuickTimeWidget.prototype.Play = function()
{
if( this._IsValidPos( this._targetPosition.currentPosition ) )
{
this._SetTargetState( WmvWidget.playState.Playing );
this._UpdateParams();
}
else
{
this._InvalidPositionHandler( this._targetPosition.currentPosition, WmvWidget.playState.Playing );
}
}
WmvQuickTimeWidget.prototype.Stop = function()
{
this._SetTargetState( WmvWidget.playState.Stopped );
this._UpdateParams();
}
WmvQuickTimeWidget.prototype.Pause = function()
{
this._SetTargetState( WmvWidget.playState.Paused );
this._UpdateParams();
}
WmvQuickTimeWidget.prototype.IsBuffering = function()
{
return false;
}
WmvQuickTimeWidget.prototype.GetRelativePosition = function()
{
var pos = this._targetPosition.currentPosition;
if( this._mmObject )
{
try
{
pos = this._mmObject.GetTime()/this._mmObject.GetTimeScale();
}catch(e)
{
pos = this._targetPosition.currentPosition;
}
}
return pos;
}
WmvQuickTimeWidget.prototype.Mute = function( toMute )
{
if( !this._preSettings.audioEnabled )
{
toMute = true;
}
this._mute = toMute;
if( this._mmObject )
{
try
{
this._mmObject.SetMute(toMute);
}catch(e)
{
this._needUpdateInnerSettings.mute = true;
return;
}
if( !toMute )
{
this.SetVolume( this._volume );
}
}
this._needUpdateInnerSettings.mute = false;
}
WmvQuickTimeWidget.prototype.IsMuted = function()
{
var isMuted = this._mute;
if( this._mmObject )
{
try
{
isMuted = this._mmObject.GetMute();
}
catch( e )
{
isMuted = this._mute;
}
}
else
{
isMuted = this._mute;
}
return isMuted;
}
WmvQuickTimeWidget.prototype.SetVolume = function( volume )
{
this._volume = volume;
var isMuted = this.IsMuted();
if( this._mmObject && !isMuted)
{
volume *= 255;
if( volume < 1)
{
volume = 1;
}
try
{
this._mmObject.SetVolume(volume);
}catch(e)
{
this._needUpdateInnerSettings.volume = true;
return;
}
}
this._needUpdateInnerSettings.volume = false;
}
WmvQuickTimeWidget.prototype.GetVolume = function()
{
var volume = this._volume;
if( this._mmObject )
{
try
{
volume = this._mmObject.GetVolume()/255;
}catch(e)
{
volume = this._volume;
}
}
return volume;
}
WmvQuickTimeWidget.prototype.SetRate = function( rate )
{
this._rate = rate;
if( this._mmObject )
{
if( this._targetStates.value == WmvWidget.playState.Playing )
{
try
{
this._mmObject.SetRate( rate );
}catch(e)
{
this._needUpdateInnerSettings.rate = true;
return;
}
}
}
this._needUpdateInnerSettings.rate = false;
}
WmvQuickTimeWidget.prototype.GetRate = function()
{
var rate = this._rate;
if( this._mmObject )
{
try
{
rate = this._mmObject.GetRate();
}catch(e)
{
}
}
return rate;
}
WmvQuickTimeWidget.prototype.GetState = function()
{
var state = WmvWidget.playState.Undefined;
state = this._simpleState;
return state;
}
WmvQuickTimeWidget.prototype.GetDuration = function()
{
var duration = 0;
if( this._mmObject )
{
try
{
duration = this._mmObject.GetDuration()/this._mmObject.GetTimeScale();
}catch(e)
{
}
}
return duration;
}
WmvQuickTimeWidget.prototype._UpdatePosition = function()
{
if( !this._targetPosition.modified )
{
return;
}
if( this._StatusIsError() )
{
this._OnError(WmvWidget.error.GeneralError, this._GetPluginStatusString());
this._targetPosition.modified = false;
return;
}
if( !this._StatusIsPlayable() )
{
return;
}
var duration = this.GetDuration();
if ( duration == 0 && this._simpleState != WmvWidget.playState.Stopped )
{
return;
}
else
if( duration > 0 && this._targetPosition.currentPosition > duration )
{
if( this._simpleState == WmvWidget.playState.Playing )
{
this._SetTargetState( WmvWidget.playState.Stopped );
}
}
else
{
try
{
var pos = this._targetPosition.currentPosition*this._mmObject.GetTimeScale();
this._mmObject.SetTime(pos);
if(this._simpleState == WmvWidget.playState.Playing)
{
this._mmObject.Stop();
this._mmObject.Play();
}
}catch(e)
{
return;
}
if( this._StatusIsError() )
{
this._OnError(WmvWidget.error.GeneralError,this._GetPluginStatusString());
}
}
this._targetPosition.modified = false;
}
WmvQuickTimeWidget.prototype._UpdateUri = function()
{
if( !this._targetUri.modified )
{
return;
}
var url = this._targetUri.value;
url = UriUtils.EncodeUri( url );
try
{
this._mmObject.SetURL( url );
}catch(e)
{
return;
}
this._targetUri.modified = false;
}
WmvQuickTimeWidget.prototype._UpdateStates = function()
{
if( !this._targetStates.modified )
{
return;
}
this._UpdateInteractionFlag();
this._SetQuickTimeObjectProperties();
if( this._StatusIsError() )
{
this._OnError(WmvWidget.error.GeneralError, this._GetPluginStatusString());
this._ChangeVisibility( false );
this._targetStates.value = WmvWidget.playState.Stopped;
this._simpleState = WmvWidget.playState.Stopped;
}
else
{
if( this._StatusIsWaiting() )
{
return;
}
try
{
switch( this._targetStates.value )
{
case WmvWidget.playState.Playing:
this._ChangeVisibility( true );
this._mmObject.Stop();
this._mmObject.Play();
break;
case WmvWidget.playState.Paused:
this._mmObject.Stop();
this._ChangeVisibility( false );
break;
case WmvWidget.playState.Stopped:
this._mmObject.Rewind();
this._mmObject.Stop();
this._ChangeVisibility( false );
break;
default:
}
}catch(e)
{
return;
}
this._simpleState = this._targetStates.value;
}
setTimeout( DelegateWithArgs( this, this.playStateChangedEvent, this._simpleState ),0 );
this._targetStates.modified = false;
}
WmvQuickTimeWidget.prototype._UpdateParams = function()
{
if( this._mediaList.IsParsingUri() || this.GetStyle("display") == "none" )
{
return;
}
if( this._mmObject == null )
{
this._simpleState = WmvWidget.playState.Stopped;
this._targetStates.modified = false;
return;
}
if( this._targetUri.modified )
{
this._UpdateUri();
}
if( (!this._targetUri.modified) && this._targetStates.modified )
{
this._UpdateStates();
}
if( (!this._targetUri.modified) && (!this._targetStates.modified)&& this._targetPosition.modified )
{
this._UpdatePosition();
}
if( this._InnerSettingsNeedUpdated() )
{
this._UpdateInnerSettings();
}
}
WmvQuickTimeWidget.prototype._GetPluginStatusString = function()
{
if( !this._mmObject )
{
return "";
}
try
{
var status = this._mmObject.GetPluginStatus();
return status;
}catch(e)
{
return "";
}
}
WmvQuickTimeWidget.prototype._StatusIsError = function()
{
var status = this._GetPluginStatusString();
if( status == "" || status.match( /Error/i ))
{
return true;
}
return false;
}
WmvQuickTimeWidget.prototype._StatusIsWaiting = function()
{
var status = this._GetPluginStatusString();
if( status.match( /Waiting/i ) )
{
return true;
}
else
{
return false;
}
}
WmvQuickTimeWidget.prototype._StatusIsPlayable = function()
{
if( this._mmObject == null )
{
return false;
}
var status = this._GetPluginStatusString();
if( status.match( /Playable/i ) || status.match( /Complete/i ) )
{
return true;
}
else
{
return false;
}
}
WmvQuickTimeWidget.prototype.SetPosition = function( pos, state )
{
WmvWidgetBase.prototype.SetPosition.call( this, pos, state );
this.positionChangedEvent( this.GetRelativePosition(), pos );
}
WmvQuickTimeWidget.prototype._SetQuickTimeObjectProperties = function()
{
this.SetVolume(this._volume);
this.Mute( this._mute );
this.SetRate( this._rate );
this._ShowQuickTimeController( this._enableInteraction );
}
WmvQuickTimeWidget.prototype._ShowQuickTimeController = function( show )
{
this._needUpdateInnerSettings.uiMode = true;
this._SetQuickTimeControllerVisible( show );
}
WmvQuickTimeWidget.prototype._SetQuickTimeControllerVisible = function( visible )
{
if( this._mmObject != null )
{
try
{
this._mmObject.SetControllerVisible( visible );
}catch(e)
{
return;
}
}
this._needUpdateInnerSettings.uiMode = false;
}
WmvQuickTimeWidget.prototype._UpdateInteractionFlag = function()
{
if( !this._targetInteractionFlag.modified || this._mmObject == null )
{
return;
}
this._enableInteraction = this._targetInteractionFlag.enableInteraction;
this._targetInteractionFlag.modified = false;
this._OnInteractionEnabled( this._enableInteraction );
}
WmvQuickTimeWidget.prototype._ApplyInteractionFlag = function()
{
if( !this._targetInteractionFlag.modified || this._mmObject == null )
{
return;
}
this._enableInteraction = this._targetInteractionFlag.enableInteraction;
this._targetInteractionFlag.modified = false;
this._ShowQuickTimeController( this._enableInteraction );
this._OnInteractionEnabled( this._enableInteraction );
}
WmvQuickTimeWidget.prototype._UpdateInnerSettings = function()
{
if( this._needUpdateInnerSettings.mute )
{
this.Mute( this._mute );
}
if( this._needUpdateInnerSettings.volume )
{
this.SetVolume( this._volume );
}
if( this._needUpdateInnerSettings.uiMode )
{
this._SetQuickTimeControllerVisible( this._enableInteraction );
}
if( this._needUpdateInnerSettings.rate )
{
this.SetRate( this._rate );
}
}
Trace.Wrap( "WmvQuickTimeWidget" );
function TargetStates()
{
}
TargetStates.prototype.Init = function( name, value )
{
this[ name ] = {
target: value,
current: value,
modified: false };
}
TargetStates.prototype.Set = function( name, value )
{
this[ name ].target = value;
this[ name ].modified = true;
}
TargetStates.prototype.Reset = function( name )
{
this[ name ].current = this[ name ].target;
this[ name ].modified = false;
}
TargetStates.prototype.IsModified = function( name )
{
return this[ name ].modified;
}
TargetStates.prototype.GetTargetValue = function( name )
{
return this[ name ].target;
}
TargetStates.prototype.GetCurrentValue = function( name )
{
return this[ name ].current;
}
function FlashWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._createMMObject = true;
this._mmObject = null;
this._url = null;
this._readyState = FlashWidget.readyState.Uninitialized;
this._simpleState = FlashWidget.playState.Stopped;
this.playStateChangedEvent = new Event();
this.operationFailedEvent = new Event();
this.infoEvent = new Event();
this._targetStates = new TargetStates();
this._timerForUpdateStates = null;
this._Created.Add( Delegate( this, FlashWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, FlashWidget.prototype._WidgetResized ) );
this._Destroyed.Add( Delegate( this, FlashWidget.prototype._WidgetDestroyed ) );
}
OOP.Inherit( FlashWidget, BasicWidget );
FlashWidget.playState = new Object();
FlashWidget.playState.Undefined = 0;
FlashWidget.playState.Stopped = 1;
FlashWidget.playState.Paused = 2;
FlashWidget.playState.Playing = 3;
FlashWidget.playState.Buffering = 6;
FlashWidget.playState.Ready = 10;
FlashWidget.readyState = new Object();
FlashWidget.readyState.Loading = 0;
FlashWidget.readyState.Uninitialized = 1;
FlashWidget.readyState.Loaded = 2;
FlashWidget.readyState.Interactive = 3;
FlashWidget.readyState.Complete = 4;
FlashWidget.ExtRegExp = new RegExp( "(\.swf)$", "i" );
FlashWidget.prototype.SetMMObjectFlag = function( createMMObject )
{
this._createMMObject = createMMObject;
}
FlashWidget.prototype._GetFlashId = function()
{
return this.GetId() + "_SWP";
}
FlashWidget.prototype._WidgetCreated = function()
{
if( this._timerForUpdateStates == null )
{
this._timerForUpdateStates = setInterval( Delegate( this, FlashWidget.prototype._UpdateStates ), 100 );
}
this._ResetStates();
}
FlashWidget.prototype._LoadFile = function()
{
var uri = this._url;
if ( !this._createMMObject )
{
return;
}
var flashId = this._GetFlashId();
var str = "";
var enableMenu = this._targetStates.GetTargetValue( "interaction" );
if( NavigatorInfo.IsIE() )
{
str += "<OBJECT type=\"application/x-shockwave-flash\" ID=\"" + flashId +
"\" data=\"" + uri + "\" play=\"false\">" +
"<param name=\"movie\" value=\"" + uri + "\"/>" +
"<param name=\"wmode\" value=\"opaque\">" +
"<param name=\"play\" value=\"false\">" +
"<param name=\"menu\" value=\"" + enableMenu + "\">" +
"<param name=\"allowScriptAccess\" value=\"never\" >" +
"<span>FLASH</span></OBJECT>";
}
else
{
var wmode = NavigatorInfo.IsFirefox()?"window":"opaque";
str += "<embed type=\"application/x-shockwave-flash\" ID=\"" + flashId +
"\" src=\"" + uri +
"\" menu=\"" + enableMenu + "\" play=\"0\" wmode=\""+wmode+"\" allowScriptAccess=\"never\" />";
}
this._htmlObject.innerHTML = str;
var currentDocument = this._htmlObject.ownerDocument;
this._mmObject = currentDocument.getElementById( flashId );
this._OnResize();
}
FlashWidget.prototype._UnloadFile = function()
{
if( this._mmObject )
{
this._htmlObject.removeChild( this._mmObject );
this._mmObject = null;
}
}
FlashWidget.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
if( clientWidth <= 0 )
{
clientWidth = 1;
}
if( clientHeight <= 0 )
{
clientHeight = 1;
}
if( this._mmObject )
{
this._mmObject.style.width = clientWidth;
this._mmObject.style.height = clientHeight;
}
}
FlashWidget.prototype._WidgetDestroyed = function()
{
this._UnloadFile();
if( this._timerForUpdateStates != null )
{
try{
clearInterval( this._timerForUpdateStates );
this._timerForUpdateStates = null;
}catch(e){}
}
}
FlashWidget.prototype.IsValid = function()
{
return this._mmObject != null;
}
FlashWidget.prototype._ResetStates = function()
{
this._targetStates.Init( "playState", FlashWidget.playState.Undefined );
this._targetStates.Init( "interaction", false );
}
FlashWidget.prototype.SetURI = function( state, uri, layer, startPos )
{
this._ResetStates();
if( uri == null )
{
this.operationFailedEvent( "SetURI" );
return;
}
if( !this._IsValidFlashURI( uri ) )
{
g_ErrorHandling.ShowCustomWarning( "The url " + uri + " is not a valid Shockwave Flash file. " );
this.operationFailedEvent( "SetURI" );
return;
}
this._url = uri;
this._UnloadFile();
this._LoadFile();
if( !this.IsValid() )
{
this.operationFailedEvent( "SetURI" );
return;
}
this.SetPosition( startPos, state );
}
FlashWidget.prototype.Play = function()
{
if( !this.IsValid() )
{
this.operationFailedEvent( "Play" );
return;
}
this._targetStates.Set( "playState", FlashWidget.playState.Playing );
this._UpdateStates();
}
FlashWidget.prototype.Stop = function()
{
if( !this.IsValid() )
{
this.operationFailedEvent( "Stop" );
return;
}
this._targetStates.Set( "playState", FlashWidget.playState.Stopped );
this._UpdateStates();
}
FlashWidget.prototype.Pause = function()
{
if( !this.IsValid() )
{
this.operationFailedEvent( "Pause" );
return;
}
this._targetStates.Set( "playState", FlashWidget.playState.Paused );
this._UpdateStates();
}
FlashWidget.prototype.SetPosition = function( pos, state )
{
if( !this.IsValid() )
{
this.operationFailedEvent( "SetPosition" );
return;
}
this._targetStates.Set( "playState", state );
this._UpdateStates();
}
FlashWidget.prototype.IsBuffering = function()
{
if( !this.IsValid() )
{
return false;
}
if( this._IsPlayable() )
{
return false;
}
else
{
return true;
}
}
FlashWidget.prototype.GetDuration = function()
{
var duration = 0;
if( !this.IsValid() )
{
return duration;
}
try
{
}
catch( e )
{
Trace.WriteLine( e.message );
}
if( isNaN( duration ) )
{
duration = 0;
}
return duration;
}
FlashWidget.prototype.GetRelativePosition = function()
{
var pos = 0;
if( !this.IsValid() )
{
return pos;
}
if( this._IsPlayable() )
{
try
{
}
catch( e )
{
Trace.WriteLine( e.message );
}
}
if( isNaN( pos ) )
{
pos = 0;
}
return pos;
}
FlashWidget.prototype.Mute = function( toMute )
{
if( !this.IsValid() )
{
return;
}
return;
}
FlashWidget.prototype.IsMuted = function()
{
var isMuted = false;
return isMuted;
}
FlashWidget.prototype.SetVolume = function( volume )
{
}
FlashWidget.prototype.GetVolume = function()
{
var volume = 0;
return volume;
}
FlashWidget.prototype.SetRate = function( rate )
{
}
FlashWidget.prototype.GetRate = function()
{
var rate = 1;
return rate;
}
FlashWidget.prototype.GetState = function()
{
var state = FlashWidget.playState.Stopped;
if( !this.IsValid() )
{
return state;
}
if( this._IsPlayable() )
{
try
{
if( this._mmObject.IsPlaying() )
{
this._simpleState = FlashWidget.playState.Playing;
}
else
{
this._simpleState = FlashWidget.playState.Stopped;
}
}catch(e)
{
this._simpleState = FlashWidget.playState.Buffering;
}
}
else
{
this._simpleState = FlashWidget.playState.Buffering;
}
return this._simpleState;
}
FlashWidget.prototype._OnReadyStateChange = function( state )
{
Trace.WriteLine( "State: " + state );
this._readyState = state;
this._simpleState = this.GetState();
this.playStateChangedEvent( this._simpleState );
}
FlashWidget.prototype._OnProgress = function( percent )
{
}
FlashWidget.prototype._FSCommand = function( command, args )
{
Trace.WriteData( command, 1, "command" );
Trace.WriteData( args, 2, "command args" );
}
FlashWidget.prototype.GetSimpleState = function()
{
return this._simpleState;
}
FlashWidget.prototype.EnableInteraction = function( enable, forceUpdate )
{
this._targetStates.Set( "interaction", enable );
if( forceUpdate )
{
this._UpdateStates();
}
}
FlashWidget.prototype._IsValidFlashURI = function( uri )
{
if( uri.match( FlashWidget.ExtRegExp ) == null )
{
return false;
}
if(uri.match( new RegExp("[<>\"]", "i" ) ))
{
return false;
}
return true;
}
FlashWidget.prototype._IsPlayable = function()
{
if( this._mmObject == null )
{
return false;
}
else
{
try{
this._mmObject.IsPlaying();
return true;
}catch(e)
{
return false;
}
}
}
FlashWidget.prototype._UpdateStates = function()
{
this._UpdateInteractionState();
this._UpdatePlayState();
}
FlashWidget.prototype._UpdateInteractionState = function()
{
if( !this._targetStates.IsModified( "interaction" ) || this._mmObject == null )
{
return;
}
if( this._targetStates.GetCurrentValue( "interaction" ) != this._targetStates.GetTargetValue( "interaction" ) )
{
this._UnloadFile();
this._LoadFile();
}
this._targetStates.Reset( "interaction" );
this._OnInteractionEnabled( this._targetStates.GetCurrentValue( "interaction" ) );
}
FlashWidget.prototype.IsInteractionEnabled = function()
{
return this._targetStates.GetCurrentValue( "interaction" );
}
FlashWidget.prototype._OnInteractionEnabled = function( enable )
{
if( enable )
{
this.infoEvent( WmvWidget.error.InteractionEnabled );
}
else
{
this.infoEvent( null );
}
}
FlashWidget.prototype._UpdatePlayState = function()
{
if( !this._targetStates.IsModified( "playState" ) || this._mmObject == null)
{
return;
}
if( !this._IsPlayable() )
{
return;
}
switch( this._targetStates.GetTargetValue( "playState" ) )
{
case FlashWidget.playState.Playing:
try{
this._mmObject.Play();
}catch(e)
{}
break;
case FlashWidget.playState.Stopped:
try{
this._mmObject.StopPlay();
}catch(e)
{}
if( this._targetStates.GetCurrentValue("playState") != FlashWidget.playState.Stopped )
{
this._UnloadFile();
this._LoadFile();
}
break;
case FlashWidget.playState.Paused:
try{
this._mmObject.StopPlay();
}catch(e)
{}
break;
default:
break;
}
this._simpleState = this._targetStates.playState;
this._targetStates.Reset( "playState" );
this.playStateChangedEvent( this._simpleState );
}
FlashWidget.blankSwfUri = "blank.swf";
Trace.Wrap( "FlashWidget" );
function WmvErrorHandler()
{
OOP.CallParentConstructor( this, arguments.callee );
}
WmvErrorHandler.GetErrorString = function( errorCode, errorDescription )
{
if( errorCode == null )
{
return null;
}
if( errorCode >= WmvWidget.error.MinWmpError )
{
errorDescription = WmvErrorHandler._GetWmpError( errorCode, errorDescription );
}
else
{
errorDescription = WmvErrorHandler._GetWmvWidgetError( errorCode, errorDescription );
}
return "(0x" + errorCode.toString( 16 ) + "): " + errorDescription;
}
WmvErrorHandler._GetWmpError = function( errorCode, errorDescription )
{
switch( errorCode )
{
case 0xc00d11c8:
errorDescription = LocaleInfo.GetText( UISettings.WmvError_CodecRequired );
break;
case 0xc00d132b:
case 0xc00d11b1:
errorDescription = LocaleInfo.GetText( UISettings.WmvError_PlayFailed );
break;
default:
break;
}
return errorDescription;
}
WmvErrorHandler._GetWmvWidgetError = function( errorCode, errorDescription )
{
switch( errorCode )
{
case WmvWidget.error.PlayerNotAvailable:
errorDescription = LocaleInfo.GetText( UISettings.WmvError_PlayerNotAvailable );
break;
case WmvWidget.error.GetMediaUriError:
errorDescription = LocaleInfo.GetText( UISettings.WmvError_GetMediaUriFailed );
break;
case WmvWidget.error.MediaNotReady:
errorDescription = LocaleInfo.GetText( UISettings.WmvInfo_MediaNotReady );
break;
case WmvWidget.error.MediaPublishError:
errorDescription = LocaleInfo.GetText( UISettings.WmvError_PublishMediaError );
break;
case WmvWidget.error.InteractionEnabled:
errorDescription = LocaleInfo.GetText( UISettings.MmcInfo_InteractionEnabled );
break;
case WmvWidget.error.GeneralError:
errorDescription = LocaleInfo.GetText( UISettings.WmvError_PlayFailed );
break;
default:
break;
}
return errorDescription;
}
Trace.Wrap( "WmvErrorHandler" );
function SessionInfo(infoText, downloadFormatText, downloadArgText, downloadArgUrl)
{
this.Text = infoText;
this.DownloadFormatText = downloadFormatText;
this.DownloadArgText = downloadArgText;
this.DownloadArgUrl= downloadArgUrl;
}
function RenderingSession()
{
this._sessionObject = new Object();
this._sessionObject.active = false;
this.SessionInformationChanged = new Event();
this.SessionChanged = new Event();
this.gradedInfo = new GradedInfo( new SessionInfo("", null) );
this.gradedInfo.InfoChanged.Add(
Delegate( this, RenderingSession.prototype._InfoChanged ) );
}
RenderingSession.prototype.StartSession = function()
{
this._OnSessionChanged( this._sessionObject.active );
this.ResetAllInformations();
}
RenderingSession.prototype.StopSession = function()
{
this.ResetAllInformations();
}
RenderingSession.prototype.ResetSession = function()
{
this.ResetAllInformations();
}
RenderingSession.prototype.ActivateSession = function( active )
{
this._sessionObject.active = active;
this._OnSessionChanged( this._sessionObject.active );
this.gradedInfo.ForceUpdateInformation();
}
RenderingSession.prototype.SetInformation = function( level, infoText, downloadFormatText, downloadArgText, downloadArgUrl )
{
this.gradedInfo.SetInformation( level, new SessionInfo(infoText, downloadFormatText, downloadArgText, downloadArgUrl) );
}
RenderingSession.prototype.ResetAllInformations = function()
{
this.gradedInfo.ClearAllInformations( true );
}
RenderingSession.prototype._OnSessionChanged = function( active )
{
this.SessionChanged( this._sessionObject, active );
}
RenderingSession.prototype._InfoChanged = function( str )
{
this.SessionInformationChanged( this._sessionObject, str );
}
function InformationRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._sessionObject = null;
}
OOP.Inherit( InformationRenderer, InformationWidget );
InformationRenderer.prototype.BindInformationSession = function( session )
{
session.SessionChanged.Add(
Delegate( this, InformationRenderer.prototype._SessionChanged ) );
session.SessionInformationChanged.Add(
Delegate( this, InformationRenderer.prototype._SessionInformationChanged ) );
}
InformationRenderer.prototype._SessionChanged = function( sessionObj, active )
{
if( active )
{
this._sessionObject = sessionObj;
}
}
InformationRenderer.prototype._SessionInformationChanged = function( sessionObj, info )
{
if( !sessionObj.active )
{
return;
}
if( !( sessionObj === this._sessionObject ) )
{
return;
}
if (info != null && info.Text != "undefined")
{
this.ShowInformation( info.Text, info.DownloadFormatText, info.DownloadArgText, info.DownloadArgUrl );
}
else
{
this.ShowInformation(info);
}
}
function AVRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._Created.Add( Delegate( this, AVRenderer.prototype._WidgetCreated ) );
}
OOP.Inherit( AVRenderer, WmvWidget );
OOP.Inherit( AVRenderer, RenderingSession );
AVRenderer.prototype._WidgetCreated = function()
{
this.errorEvent.Add(
Delegate( this, AVRenderer.prototype._WmvErrorOccured ) );
this.infoEvent.Add(
Delegate( this, AVRenderer.prototype._WmvInfoSent ) );
this.playStateChangedEvent.Add(
Delegate( this, AVRenderer.prototype._WmvPlayStateChanged ) );
}
AVRenderer.prototype._WmvPlayStateChanged = function()
{
if( this._innerState == WmvWidget.playState.Playing )
{
this.ResetSession();
}
}
AVRenderer.prototype._WmvErrorOccured = function( errorCode, errorDescription )
{
this.SetInformation(
GradedInfo.grades.error,
WmvErrorHandler.GetErrorString( errorCode, errorDescription )
);
}
AVRenderer.prototype._WmvInfoSent = function( errorCode, errorDescription)
{
this.SetInformation(
GradedInfo.grades.information,
WmvErrorHandler.GetErrorString( errorCode, errorDescription )
);
}
function BusinessCardRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._background = new ImageWidget();
this._workArea = new BasicWidget();
this._nameText = new TextWidget();
this._companyText = new TextWidget();
this._titleText = new TextWidget();
this._emailText = new TextWidget();
this._phoneText = new TextWidget();
this._photoImage = new ImageWidget();
this._Created.Add( Delegate( this, BusinessCardRenderer.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, BusinessCardRenderer.prototype._WidgetResized ) );
}
OOP.Inherit( BusinessCardRenderer, BasicWidget );
OOP.Inherit( BusinessCardRenderer, RenderingSession );
BusinessCardRenderer.prototype._WidgetCreated = function()
{
this._background.Create( this );
this._background.SetStyle( "position", "absolute" );
this._background.SetURI( uiSettings.GetImage( "bizCardBackground" ) );
this._workArea.Create( this );
this._workArea.SetStyle( "position", "absolute");
this._workArea.SetStyle( "zIndex", "65535" );
this._photoImage.Create(
this._workArea,
UISettings.bizCardImageId );
this._nameText.Create(
this._workArea,
UISettings.bizCardNameId );
this._emailText.Create(
this._workArea,
UISettings.bizCardEmailId );
this._titleText.Create(
this._workArea,
UISettings.bizCardTitleId );
this._companyText.Create(
this._workArea,
UISettings.bizCardCompanyId );
this._phoneText.Create(
this._workArea,
UISettings.bizCardPhoneId );
this._photoImage.SetStyle( "position", "relative" );
this._nameText.SetStyle( "position", "relative" );
this._companyText.SetStyle( "position", "relative" );
this._titleText.SetStyle( "position", "relative" );
this._emailText.SetStyle( "position", "relative" );
this._phoneText.SetStyle( "position", "relative" );
this._nameText.EnableMultipleLines( false );
this._companyText.EnableMultipleLines( false );
this._titleText.EnableMultipleLines( false );
this._emailText.EnableMultipleLines( false );
this._phoneText.EnableMultipleLines( false );
this.SetData( null );
}
BusinessCardRenderer.prototype._WidgetResized = function()
{
var width = this.GetPaddedWidth();
var height = this.GetPaddedHeight();
this._background.SetUIPosition(
true,
0,
0,
width,
height );
var clientLeft = this.Length2Value( "width", this.GetStyle( "paddingLeft" ) );
var clientTop = this.Length2Value( "height", this.GetStyle( "paddingTop" ) );
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
this._workArea.SetUIPosition(
true,
clientLeft,
clientTop,
clientWidth,
clientHeight );
this._photoImage.SetHeight( 32 );
this._nameText.SetWidth( clientWidth );
this._emailText.SetWidth( clientWidth );
this._titleText.SetWidth( clientWidth );
this._companyText.SetWidth( clientWidth );
this._phoneText.SetWidth( clientWidth );
}
BusinessCardRenderer.prototype.SetData = function( cardInfo )
{
if( cardInfo == null )
{
cardInfo = new Object();
}
var name = cardInfo.fullName;
var company = cardInfo.corporation;
var title = cardInfo.title;
var email = cardInfo.email;
var phone = cardInfo.phone;
var photo = cardInfo.photo;
this._nameText.SetStyle( "display", ( name ? "" : "none" ) );
this._companyText.SetStyle( "display", ( company ? "" : "none" ) );
this._titleText.SetStyle( "display", ( title ? "" : "none" ) );
this._emailText.SetStyle( "display", ( email ? "" : "none" ) );
this._phoneText.SetStyle( "display", ( phone ? "" : "none" ) );
if( !name )
{
name = LocaleInfo.GetText( UISettings.bizCardNameId );
}
if( !company )
{
company = LocaleInfo.GetText( UISettings.bizCardCompanyId );
}
if( !title )
{
title = LocaleInfo.GetText( UISettings.bizCardTitleId );
}
if( !email )
{
email = LocaleInfo.GetText( UISettings.bizCardEmailId );
}
if( !phone )
{
phone = LocaleInfo.GetText( UISettings.bizCardPhoneId );
}
if( !photo )
{
photo = uiSettings.GetImage( "bizCardDefaultPhoto" );
}
this._nameText.SetText( name );
this._companyText.SetText( company );
this._titleText.SetText( title );
this._emailText.SetText( email );
this._phoneText.SetText( phone );
this._nameText.SetAttribute( "title", name );
this._companyText.SetAttribute( "title", company );
this._titleText.SetAttribute( "title", title );
this._emailText.SetAttribute( "title", email );
this._phoneText.SetAttribute( "title", phone );
this._photoImage.SetURI( photo );
}
Trace.Wrap( "BusinessCardRenderer" );
function DummyRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._meetingInfo = null;
this.meetingSubject = new TextWidget();
this.meetingTime = new TextWidget();
this.bottomRightImage = new ImageWidget();
this._Created.Add( Delegate( this, DummyRenderer.prototype._CreatedHandler ) );
this._Resized.Add( Delegate( this, DummyRenderer.prototype._ResizedHandler ) );
}
OOP.Inherit( DummyRenderer, BasicWidget );
OOP.Inherit( DummyRenderer, RenderingSession );
DummyRenderer.prototype._CreatedHandler = function()
{
this.bottomRightImage.Create( this, UISettings.dummyBottomRightImageId );
this.meetingSubject.Create( this, UISettings.dummySubjectTextId );
this.meetingTime.Create( this, UISettings.dummyTimeTextId );
this.bottomRightImage.SetURI( uiSettings.GetImage( "dataAreaBottomRight" ) );
}
DummyRenderer.prototype._ResizedHandler = function()
{
var clientWidth = this.GetPaddedWidth();
var clientHeight = this.GetPaddedHeight();
var minClientWidth = 200;
var minClientHeight = 200;
if( clientWidth < minClientWidth )
{
clientWidth = minClientWidth;
}
if( clientHeight < minClientHeight )
{
clientHeight = minClientHeight;
}
var imageWidth = this.bottomRightImage._originalWidth;
var imageHeight = this.bottomRightImage._originalHeight;
var imageLeft = clientWidth - imageWidth;
var imageTop = clientHeight - imageHeight;
this.bottomRightImage.SetUIPosition(
true,
imageLeft,
imageTop,
imageWidth,
imageHeight );
}
DummyRenderer.prototype.SetMeetingInfo = function( meetingInfo )
{
this._meetingInfo = meetingInfo;
var startTime = LocaleInfo.GetText( UISettings.downloadStartTimeDefaultString );
var stopTime = LocaleInfo.GetText( UISettings.downloadStopTimeDefaultString );
var timeString = "";
if ( meetingInfo.startTime != null )
{
startTime = meetingInfo.startTime.toLocaleString();
}
if ( meetingInfo.stopTime != null )
{
stopTime = meetingInfo.stopTime.toLocaleString();
}
var timeString = LocaleInfo.GetText( UISettings.downloadStartTimePrompt ) +
" " + startTime + "\n" +
LocaleInfo.GetText( UISettings.downloadStopTimePrompt ) +
" " + stopTime;
var subject = LocaleInfo.GetText( UISettings.downloadDefaultSubject );
if( meetingInfo.subject + "" != "" )
{
subject = meetingInfo.subject;
}
this.meetingSubject.SetText( subject );
this.meetingTime.SetText( timeString );
}
Trace.Wrap( "DummyRenderer" );
function SpeakerRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this.avRenderer = new AVRenderer();
this._fitter = new WidgetFitter();
this._Created.Add( Delegate( this, SpeakerRenderer.prototype._WidgetCreated ) );
}
OOP.Inherit( SpeakerRenderer, BasicWidget );
SpeakerRenderer.prototype._WidgetCreated = function()
{
this.avRenderer.Create( this, UISettings.primVideoRendererId );
this.avRenderer.EnableReadyStateChecking( true );
this.avRenderer.SetDefaultOriginalSize( 160, 120 );
this.avRenderer.ApplyDefaultOriginalSize( );
if( NavigatorInfo.IsFirefox() )
{
this.avRenderer.SetDisplaySize( WmvWidget.displaySize.MpDefaultSize,
UISettings.QCIFDefaultWidth,
UISettings.QCIFDefaultHeight );
this._fitter.Bind( this, this.avRenderer, "fill" );
}
else
{
this._fitter.Bind( this, this.avRenderer, "proportional" );
}
this.avRenderer.CheckEnabled();
}
function PanoRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this.avRenderer = new AVRenderer();
this._fitter = new WidgetFitter();
this._Created.Add( Delegate( this, PanoRenderer.prototype._WidgetCreated ) );
}
OOP.Inherit( PanoRenderer, BasicWidget );
PanoRenderer.prototype._WidgetCreated = function()
{
this.avRenderer.Create( this, UISettings.panoVideoRendererId );
this.avRenderer.EnableReadyStateChecking( true );
this.avRenderer.SetDefaultOriginalSize( 1167, 160 );
this.avRenderer.ApplyDefaultOriginalSize( );
if( NavigatorInfo.IsFirefox() )
{
this.avRenderer.SetDisplaySize( WmvWidget.displaySize.MpDefaultSize,
UISettings.PanoDefaultWidth,
UISettings.PanoDefaultHeight );
this._fitter.Bind( this, this.avRenderer, "fill" );
}
else
{
this._fitter.Bind( this, this.avRenderer, "proportional" );
}
this.avRenderer.CheckEnabled();
}
function AnnoBaseElementDrawer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._targetDoc = null;
this._group = null;
this._zIndex = 0;
this._GetAnnoAreaWidthDelegate = null;
this._pageWidth = 0;
this._pageHeight = 0;
}
AnnoBaseElementDrawer.prototype.SetPageSize = function( width, height )
{
this._pageWidth = width;
this._pageHeight = height;
}
AnnoBaseElementDrawer.prototype.SetDoc = function( doc )
{
this._targetDoc = doc;
}
AnnoBaseElementDrawer.prototype.SetGroup = function( group )
{
this._group = group;
}
AnnoBaseElementDrawer.prototype.AppendToGroup = function( element )
{
this._group.appendChild( element );
}
AnnoBaseElementDrawer.prototype.SetGetAreaWidthDelegate = function( delegate )
{
this._GetAnnoAreaWidthDelegate = delegate;
}
AnnoBaseElementDrawer.prototype.NewElement = function( elemId, type )
{
}
AnnoBaseElementDrawer.prototype.RemoveElement = function( elem )
{
}
AnnoBaseElementDrawer.prototype.Clear = function( )
{
this._group.innerHTML = "";
}
AnnoBaseElementDrawer.prototype.Query = function( elemId )
{
return this._targetDoc.getElementById( elemId )
}
AnnoBaseElementDrawer.prototype.UpdateElementPosition = function( elem )
{
}
AnnoBaseElementDrawer.prototype.UpdateElementSize = function( elem )
{
}
AnnoBaseElementDrawer.prototype.UpdateChildrenPosition = function( )
{
}
AnnoBaseElementDrawer.prototype.UpdateChildrenSize = function( )
{
}
function AnnoHTMLElementDrawer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._textInfov = null;
}
OOP.Inherit( AnnoHTMLElementDrawer, AnnoBaseElementDrawer );
AnnoHTMLElementDrawer.prototype.SetTextInfoDiv = function( div )
{
this._textInfo = div;
}
AnnoHTMLElementDrawer.prototype.UpdateElementPosition = function( elem )
{
var w = this._GetAnnoAreaWidthDelegate();
if ( this._pageWidth < 1 )
{
return;
}
var rate = w / this._pageWidth;
elem.style.left = rate * elem.x;
elem.style.top = rate * elem.y;
}
AnnoHTMLElementDrawer.prototype.UpdateElementSize = function( elem )
{
this._UpdateFont( elem );
this._UpdateSize( elem );
}
AnnoHTMLElementDrawer.prototype.UpdateChildrenPosition = function( )
{
for ( var i = 0; i < this._group.childNodes.length; i++ )
{
this.UpdateElementPosition( this._group.childNodes[i] );
}
}
AnnoHTMLElementDrawer.prototype._UpdateSize = function( elem )
{
var size = GetSizeofSafeText( elem.innerHTML, elem.style.font, this._textInfo );
elem.style.width = size.width + 1;
elem.style.height = size.height + 1;
}
AnnoHTMLElementDrawer.prototype._UpdateFont = function( elem )
{
var w = this._GetAnnoAreaWidthDelegate();
if ( this._pageWidth < 1 )
{
return;
}
var rate = w / this._pageWidth;
var nSize = rate * parseFloat(elem.fs);
if ( nSize < 8 )
{
nSize = 8;
}
elem.style.fontSize = nSize;
}
AnnoHTMLElementDrawer.prototype.UpdateChildrenSize = function()
{
for ( var i = 0; i < this._group.childNodes.length; i++ )
{
this.UpdateElementSize( this._group.childNodes[i] );
}
}
AnnoHTMLElementDrawer.prototype.NewElement = function( elemId, type )
{
if ( this._targetDoc.getElementById( elemId ) )
{
g_ErrorHandling.ShowWarning( E_ANNOELMIDHASEXISTED );
return null;
}
if ( !elemId || elemId == "" )
{
g_ErrorHandling.ShowWarning( E_INVALIDARG );
return null;
}
var elem = this._targetDoc.createElement( type );
elem.setAttribute( "id", elemId );
elem.setAttribute( "z-index", this._zIndex );
elem.style.position = "absolute";
this._zIndex += 5;
return elem;
}
AnnoHTMLElementDrawer.prototype.RemoveElement = function( elem )
{
this._group.removeChild( elem );
}
AnnoHTMLElementDrawer.prototype.GetElementById = function( elemId )
{
if ( !this._targetDoc )
{
return null;
}
return this._targetDoc.getElementById( elemId );
}
function AnnoVMLElementDrawer()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( AnnoVMLElementDrawer, AnnoBaseElementDrawer );
function AnnoSVGElementDrawer()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( AnnoSVGElementDrawer, AnnoBaseElementDrawer );
function BaseStampDrawer()
{
OOP.CallParentConstructor( this, arguments.callee );
}
BaseStampDrawer.prototype.DrawXStamp = function(
atype,
elemId,
x,
y,
color,
t1,
t2,
checkDelegate,
createDelegate )
{
}
BaseStampDrawer.prototype.DrawArrowStamp = function(
atype,
elemId,
x,
y,
color,
t1,
t2,
checkDelegate,
createDelegate )
{
}
BaseStampDrawer.prototype.DrawCheckStamp = function(
atype,
elemId,
x,
y,
color,
t1,
t2,
checkDelegate,
createDelegate )
{
}
function ImageStampDrawer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._XStampSrc = null;
this._CheckStampSrc = null;
this._ArrowStampSrc = null;
}
OOP.Inherit( ImageStampDrawer, BaseStampDrawer );
ImageStampDrawer.StampWidth = 24;
ImageStampDrawer.StampHeight = 24;
ImageStampDrawer.prototype.Initialize = function ( xSrc, checkSrc, arrowSrc )
{
this._XStampSrc = xSrc;
this._CheckStampSrc = checkSrc;
this._ArrowStampSrc = arrowSrc;
}
ImageStampDrawer.prototype._DrawGeneralStamp = function(
atype,
elemId,
x,
y,
imageSrc,
checkDelegate,
createDelegate
)
{
}
ImageStampDrawer.prototype.DrawXStamp = function(
atype,
elemId,
x,
y,
color,
t1,
t2,
checkDelegate,
createDelegate )
{
return this._DrawGeneralStamp(
atype,
elemId,
x,
y,
this._XStampSrc,
checkDelegate,
createDelegate
);
}
ImageStampDrawer.prototype.DrawArrowStamp = function(
atype,
elemId,
x,
y,
color,
t1,
t2,
checkDelegate,
createDelegate )
{
return this._DrawGeneralStamp(
atype,
elemId,
x,
y,
this._ArrowStampSrc,
checkDelegate,
createDelegate
);
}
ImageStampDrawer.prototype.DrawCheckStamp = function(
atype,
elemId,
x,
y,
color,
t1,
t2,
checkDelegate,
createDelegate )
{
return this._DrawGeneralStamp(
atype,
elemId,
x,
y,
this._CheckStampSrc,
checkDelegate,
createDelegate
);
}
function VMLImageStampDrawer()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( VMLImageStampDrawer, ImageStampDrawer );
VMLImageStampDrawer.prototype._DrawGeneralStamp = function(
atype,
elemId,
x,
y,
imageSrc,
checkDelegate,
createDelegate
)
{
if ( !checkDelegate() )
{
return null;
}
var elem = createDelegate( elemId, "v:shape", atype );
if (!elem )
{
return null;
}
elem.style.left = x - ImageStampDrawer.StampWidth / 2;
elem.style.top = y - ImageStampDrawer.StampHeight / 2;
elem.style.width =  ImageStampDrawer.StampWidth;
elem.style.height = ImageStampDrawer.StampHeight;
elem.stroked="false";
elem.innerHTML = "<v:imagedata chromakey=\"white\" src=\"" + imageSrc + "\"/>";
return elem;
}
function SVGImageStampDrawer()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( SVGImageStampDrawer, ImageStampDrawer );
SVGImageStampDrawer.prototype._DrawGeneralStamp = function(
atype,
elemId,
x,
y,
imageSrc,
checkDelegate,
createDelegate
)
{
if ( !checkDelegate() )
{
return null;
}
var elem = createDelegate( elemId, "image", atype );
if (!elem )
{
return null;
}
elem.setAttribute( "x", x - ImageStampDrawer.StampWidth / 2 );
elem.setAttribute( "y", y - ImageStampDrawer.StampHeight / 2 );
elem.setAttribute( "width", ImageStampDrawer.StampWidth );
elem.setAttribute( "height", ImageStampDrawer.StampHeight );
var xlinkns = "http://www.w3.org/1999/xlink";
elem.setAttributeNS( xlinkns, 'xlink:href', imageSrc );
return elem;
}
function AnnoBaseRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._available = false;
this._group = null;
this._targetDoc = null;
this._zIndex = 0;
this._width = 1;
this._height = 1;
this._defaultPageWidth = 400;
this._defaultPageHeight = 300;
this._annoArea = null;
this._textInfo = null;
this._stampDrawer = null;
this._AnnoAreaResizedEvent = new Event();
this.AnnoHTMLLoadedEvent = new Event();
this.htmlIsLoaded = false;
this._Created.Add( Delegate( this, AnnoBaseRenderer.prototype._WidgetCreated ) );
this._Destroyed.Add( Delegate( this, AnnoBaseRenderer.prototype._WidgetDestroyed ) );
this._AnnoAreaResizedEvent.Add( Delegate( this, AnnoBaseRenderer.prototype._WidgetResized ) );
this._AfterLoadedEvent.Add( Delegate( this, AnnoBaseRenderer.prototype._Onload ) );
}
OOP.Inherit( AnnoBaseRenderer, HTMLWidget );
OOP.Inherit( AnnoBaseRenderer, RenderingSession );
AnnoBaseRenderer.AnnoHTML = "anno.htm";
AnnoBaseRenderer.TransRate = 0.5;
AnnoBaseRenderer.AnnoAreaID = "annoArea";
AnnoBaseRenderer.TextInfoID = "textInfo";
AnnoBaseRenderer.prototype._WidgetCreated = function()
{
this.SetURI( g_lmEngineRoot + AnnoBaseRenderer.AnnoHTML );
}
AnnoBaseRenderer.prototype._WidgetDestroyed = function()
{
this._targetDoc = null;
this._group = null;
}
AnnoBaseRenderer.prototype._Onload = function()
{
this.AllowTransparency( true );
var htmlDoc = this._iframe.contentWindow.document;
this._annoArea = htmlDoc.getElementById( AnnoBaseRenderer.AnnoAreaID );
this._textInfo = htmlDoc.getElementById( AnnoBaseRenderer.TextInfoID );
this._targetDoc = this._GetDocument();
if ( this._targetDoc != null )
{
this._group = this._GetGroup();
if ( this._group )
{
this._available = true;
}
else
{
this._available = false;
}
}
else
{
g_ErrorHandling.ShowWarning( E_ANNONOTSUPPORTED );
}
if ( !this._available )
{
this.SetStyle( "visibility", "hidden" );
}
this.htmlIsLoaded = true;
this.AnnoHTMLLoadedEvent();
}
AnnoBaseRenderer.prototype.SetDefaultPageSize = function( w, h )
{
this._defaultPageWidth = w;
this._defaultPageHeight = h;
}
AnnoBaseRenderer.prototype._WidgetResized = function()
{
if ( !this.IsAvailable() )
{
return;
}
if ( !this._group )
{
return;
}
var w = this.GetAnnoAreaWidth();
var h = this.GetAnnoAreaHeight();
this._ChangeSize( w, h );
var elems = this._group.childNodes;
for( var i = 0; i < elems.length; i++ )
{
this._UpdateWeight( elems[i] );
}
}
AnnoBaseRenderer.prototype._GetDocument = function()
{
}
AnnoBaseRenderer.prototype._GetGroup = function()
{
return null;
}
AnnoBaseRenderer.prototype._UpdateWeight = function( elem )
{
}
AnnoBaseRenderer.prototype._ChangeGroupSize = function( w, h )
{
}
AnnoBaseRenderer.prototype._GetAnnoElementById = function( id )
{
}
AnnoBaseRenderer.prototype._RemoveAnnoElement = function( elem )
{
}
AnnoBaseRenderer.prototype._MoveElement = function( element, dx, dy )
{
}
AnnoBaseRenderer.prototype._ClearElements = function( isReset )
{
}
AnnoBaseRenderer.prototype._ChangeAnnoColor = function( elem, color )
{
}
AnnoBaseRenderer.prototype.DrawRect = function(
atype,
elemId,
left,
top,
width,
height,
color,
weight )
{
}
AnnoBaseRenderer.prototype.DrawRoundRect = function(
atype,
elemId,
left,
top,
width,
height,
color,
weight )
{
}
AnnoBaseRenderer.prototype.DrawText = function(
atype,
elemId,
left,
top,
color,
font,
underline,
text )
{
}
AnnoBaseRenderer.prototype.UpdateText = function(
atype,
elemId,
left,
top,
color,
font,
text )
{
}
AnnoBaseRenderer.prototype.DrawLine = function(
atype,
elemId,
fromX,
fromY,
toX,
toY,
color,
weight )
{
}
AnnoBaseRenderer.prototype.DrawArrow = function(
atype,
elemId,
fromX,
fromY,
toX,
toY,
color,
weight )
{
}
AnnoBaseRenderer.prototype.DrawOval = function(
atype,
elemId,
left,
top,
width,
height,
color,
weight,
inneropacity,
innercolor )
{
}
AnnoBaseRenderer.prototype.DrawFreeLine = function(
atype,
elemId,
keyPoints,
color,
weight )
{
}
AnnoBaseRenderer.prototype.DrawHighLighter = function(
atype,
elemId,
keyPoints,
color,
weight )
{
}
AnnoBaseRenderer.prototype.DrawXStamp = function(
atype,
elemId,
x,
y,
color,
t1,
t2 )
{
var elem = this._stampDrawer.DrawXStamp(
atype,
elemId,
x,
y,
color,
0,
0,
DelegateWithArgs( this, this._CheckStampDrawing, atype,
elemId,
x,
y,
color,
t1,
t2  ),
Delegate( this, this._NewDrawing ) );
if ( elem )
{
this._group.appendChild( elem );
}
}
AnnoBaseRenderer.prototype.DrawArrowStamp = function(
atype,
elemId,
x,
y,
color,
t1,
t2 )
{
var elem = this._stampDrawer.DrawArrowStamp(
atype,
elemId,
x,
y,
color,
0,
0,
DelegateWithArgs( this, this._CheckStampDrawing, atype,
elemId,
x,
y,
color,
t1,
t2  ),
Delegate( this, this._NewDrawing ) );
if ( elem )
{
this._group.appendChild( elem );
}
}
AnnoBaseRenderer.prototype.DrawCheckStamp = function(
atype,
elemId,
x,
y,
color,
t )
{
var elem = this._stampDrawer.DrawCheckStamp(
atype,
elemId,
x,
y,
color,
0,
0,
DelegateWithArgs( this, this._CheckStampDrawing, atype,
elemId,
x,
y,
color,
0,
0  ),
Delegate( this, this._NewDrawing ) );
if ( elem )
{
this._group.appendChild( elem );
}
}
AnnoBaseRenderer.prototype._ChangeViewSize = function( nw, nh )
{
}
AnnoBaseRenderer.prototype.Initialize = function()
{
this._Reset();
}
AnnoBaseRenderer.prototype.Uninitialize = function()
{
this.Clear();
}
AnnoBaseRenderer.prototype.SetGroupSize = function( width, height )
{
if ( !this._iframe || !this._iframe.contentWindow )
{
return;
}
var w = parseInt( width );
var h = parseInt( height );
if ( isNaN( w ) || w < 0 )
{
w = this._defaultPageWidth;
}
if ( isNaN( h ) || h < 0 )
{
h = this._defaultPageHeight;
}
this._width = w;
this._height = h;
this._ChangeGroupSize( w, h );
}
AnnoBaseRenderer.prototype.Delete = function( elemId )
{
if ( elemId == AnnoBaseRenderer.GroupID )
{
return;
}
var elem = this._GetAnnoElementById( elemId );
if ( !elem )
{
g_ErrorHandling.ShowWarning( E_ANNOELMIDNOTEXISTED );
return;
}
this._RemoveAnnoElement( elem );
}
AnnoBaseRenderer.prototype.Move = function( elemId, dx, dy )
{
if ( elemId == AnnoBaseRenderer.GroupID )
{
return;
}
if ( (typeof dx != "number") || typeof dy != "number" )
{
g_ErrorHandling.ShowWarning( E_INVALIDARG );
return;
}
var elem = this._GetAnnoElementById( elemId );
if ( !elem )
{
g_ErrorHandling.ShowWarning( E_ANNOELMIDNOTEXISTED );
return;
}
this._MoveElement( elem, dx, dy );
}
AnnoBaseRenderer.prototype.Clear = function()
{
this._ClearElements( false );
}
AnnoBaseRenderer.prototype.ChangeColor = function( elemId, color )
{
if ( elemId == AnnoBaseRenderer.GroupID )
{
return;
}
var elem = this._GetAnnoElementById( elemId );
if ( !elem )
{
g_ErrorHandling.ShowWarning( E_ANNOELMIDNOTEXISTED );
return;
}
this._ChangeAnnoColor( elem, color );
}
AnnoBaseRenderer.prototype._Reset = function()
{
if ( this._iframe && this._iframe.contentWindow )
{
this._ClearElements( true );
}
this._zIndex = 0;
}
AnnoBaseRenderer.prototype._ChangeSize = function( nw, nh )
{
if ( !this._group )
{
return;
}
if ( (typeof nw != "number") || typeof nh != "number" )
{
g_ErrorHandling.ShowWarning( E_INVALIDARG );
return;
}
if ( nw < 0 )
{
nw = this._defaultPageWidth;
}
if ( nh < 0 )
{
nh = this._defaultPageHeight;
}
this._ChangeViewSize( nw, nh );
}
AnnoBaseRenderer.prototype.IsAvailable = function()
{
return this._available;
}
AnnoBaseRenderer.prototype.SetAnnoAreaSize = function( width, height )
{
if( this._annoArea == null )
{
return;
}
this._annoArea.style.width = width;
this._annoArea.style.height = height;
this._AnnoAreaResizedEvent();
}
AnnoBaseRenderer.prototype.SetAnnoAreaPosition = function( left, top )
{
if( this._annoArea == null )
{
return;
}
this._annoArea.style.left = left;
this._annoArea.style.top = top;
}
AnnoBaseRenderer.prototype.SetScrollPosition = function( scrollLeft, scrollTop )
{
this._iframe.contentWindow.document.body.scrollLeft = scrollLeft;
this._iframe.contentWindow.document.body.scrollTop = scrollTop;
}
AnnoBaseRenderer.prototype.GetAnnoAreaWidth = function()
{
return parseFloat( this._annoArea.style.width );
}
AnnoBaseRenderer.prototype.GetAnnoAreaHeight = function()
{
return parseFloat( this._annoArea.style.height );
}
AnnoBaseRenderer.prototype.SetStampDrawer = function( stampDrawer )
{
this._stampDrawer = stampDrawer;
}
AnnoBaseRenderer.prototype._CheckStampDrawing = function()
{
return true;
}
Trace.Wrap( "AnnoBaseRenderer" );
function AnnoVMLRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._IDATypeMap = new Object();
}
OOP.Inherit( AnnoVMLRenderer, AnnoBaseRenderer );
AnnoVMLRenderer.GroupID = "G";
AnnoVMLRenderer.prototype._GetDocument = function()
{
return this._iframe.contentWindow.document;
}
AnnoVMLRenderer.prototype._GetGroup = function()
{
return this._targetDoc.getElementById( AnnoVMLRenderer.GroupID );
}
AnnoVMLRenderer.prototype._UpdateWeight = function( elem )
{
if ( elem._w != null )
{
var w = this.GetAnnoAreaWidth();
elem.strokeweight = elem._w * w / this._width + "px";
}
}
AnnoVMLRenderer.prototype._ChangeGroupSize = function( w, h )
{
this._ChangeViewSize( w, h );
this._group.coordsize = w + "," + h;
}
AnnoVMLRenderer.prototype._ChangeViewSize = function( nw, nh )
{
this._group.style.width = nw;
this._group.style.height = nh;
}
AnnoVMLRenderer.prototype._GetAnnoElementById = function( id )
{
return this._targetDoc.getElementById( id );
}
AnnoVMLRenderer.prototype._RemoveAnnoElement = function( elem )
{
this._group.removeChild( elem );
delete (this._IDATypeMap[elem.id]);
}
AnnoVMLRenderer.prototype._MoveElement = function( elem, dx, dy )
{
var left = parseFloat( elem.style.left );
var top = parseFloat( elem.style.top );
if ( isNaN( left ) ) { left = 0; };
if ( isNaN( top ) ) { top = 0; };
elem.style.left = left + dx;
elem.style.top = top + dy;
}
AnnoVMLRenderer.prototype._ClearElements = function()
{
this._group.innerHTML = "";
this._IDATypeMap = {};
}
AnnoVMLRenderer.prototype._ChangeAnnoColor = function( elem, color )
{
var elemId = elem.id;
switch ( this._IDATypeMap[elemId] )
{
case "rect":
case "roundrect":
case "oval":
case "line":
case "arrow":
case "freeline":
case "highlighter":
elem.strokecolor = color;
break;
case "xstamp":
case "arrowstamp":
case "checkstamp":
elem.fillcolor = color;
break;
case "pointer":
elem.fillcolor = color;
break;
case "text":
setTimeout( DelegateWithArgs(
this,
this._UpdateTextColor,
elem,
color ), 0 );
break;
default:
alert( this._IDATypeMap[elemId] );
}
}
AnnoVMLRenderer.prototype.DrawRect = function(
atype,
elemId,
left,
top,
width,
height,
color,
weight )
{
if ( !this._iframe || !this._iframe.contentWindow )
{
return;
}
if ( isNaN( left ) || isNaN( top ) || isNaN( width ) || isNaN( height ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var elem = this._NewDrawing( elemId, "v:rect", atype );
if (!elem )
{
return;
}
elem.style.left = left;
elem.style.top = top;
elem.style.width = width;
elem.style.height = height;
elem.strokecolor = color;
elem.strokeweight = weight;
this._UpdateWeight( elem );
var fill = this._targetDoc.createElement("v:fill");
fill.opacity = 0;
elem.appendChild( fill );
this._group.appendChild( elem );
}
AnnoVMLRenderer.prototype.DrawRoundRect = function(
atype,
elemId,
left,
top,
width,
height,
color,
weight )
{
if ( !this._iframe || !this._iframe.contentWindow )
{
return;
}
if ( isNaN( left ) || isNaN( top ) || isNaN( width ) || isNaN( height ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var elem = this._NewDrawing( elemId, "v:roundrect", atype );
if (!elem )
{
return;
}
elem.style.zindex = this._zIndex;
elem.style.left = left;
elem.style.top = top;
elem.style.width = width;
elem.style.height = height;
elem.strokecolor = color;
elem.strokeweight = weight;
elem.arcsize="5%";
this._UpdateWeight( elem );
var fill = this._targetDoc.createElement("v:fill");
fill.opacity = 0;
elem.appendChild( fill );
this._group.appendChild( elem );
}
AnnoVMLRenderer.prototype.UpdateText = function(
atype,
elemId,
left,
top,
color,
font,
underline,
text )
{
if ( this._IDATypeMap[elemId] != "text" )
{
return;
}
this._RemoveAnnoElement( this._targetDoc.getElementById(elemId) );
this.DrawText(
atype,
elemId,
left,
top,
color,
font,
underline,
text );
}
AnnoVMLRenderer.prototype._UpdateTextColor = function( txtGrp, color )
{
for ( var i = 0; i < txtGrp.childNodes.length; i++ )
{
for ( var j = 0; j < txtGrp.childNodes[i].childNodes.length; j++ )
{
if ( txtGrp.childNodes[i].childNodes[j].childNodes.length > 1 )
{
txtGrp.childNodes[i].childNodes[j].fillColor = color;
txtGrp.childNodes[i].childNodes[j].strokeColor = color;
}
else
{
txtGrp.childNodes[i].childNodes[j].strokeColor = color;
}
}
}
}
AnnoVMLRenderer.prototype._DrawSingleLineTextInGroup = function(
vGroup,
textSize,
color,
font,
underline,
text,
hint )
{
var textLine = this._targetDoc.createElement( "v:line" );
textLine.style.position = "absolute";
textLine.style.height = textSize.height;
textLine.from = "0 " + textSize.height/2;
textLine.to = textSize.width + " " + textSize.height/2;
textLine.strokecolor = color;
textLine.title = hint;
var fillLine = this._targetDoc.createElement( "v:fill" );
fillLine.on = "True";
fillLine.color = color;
var pathLine = this._targetDoc.createElement( "v:path" );
pathLine.textpathok = "True";
var tpLine = this._targetDoc.createElement( "v:textpath" );
tpLine.on = "True";
tpLine.fitpath = "True";
tpLine.string = text;
tpLine.style.font = font;
textLine.appendChild( fillLine );
textLine.appendChild( pathLine );
textLine.appendChild( tpLine );
vGroup.appendChild( textLine );
if ( underline )
{
var underline = this._targetDoc.createElement( "v:line" );
underline.style.position = "absolute";
underline.strokecolor = color;
underline.fillcolor = color;
underline.from = "0 " + textSize.height;
underline.to = textSize.width + " " + textSize.height;
vGroup.appendChild( underline );
}
}
AnnoVMLRenderer.prototype._NewSingleLineText = function(
left,
top,
color,
font,
underline,
text,
hint )
{
var textSize = GetSizeofText( text, font, this._textInfo );
AnnoVMLRenderer.prototype._NewSingleLineText.LastTextSize = textSize;
var vGroup = this._targetDoc.createElement( "v:group" );
vGroup.style.left = left;
vGroup.style.top = top;
vGroup.style.width = textSize.width;
vGroup.style.height = textSize.height;
vGroup.coordSize = textSize.width + " " + textSize.height;
if ( underline )
{
setTimeout( DelegateWithArgs(
this,
this._DrawSingleLineTextInGroup,
vGroup,
textSize,
color,
font,
underline,
text,
hint ), 0 );
}
else
{
this._DrawSingleLineTextInGroup(
vGroup,
textSize,
color,
font,
underline,
text,
hint );
}
return vGroup;
}
AnnoVMLRenderer.prototype._NewSingleLineText.LastTextSize = null;
AnnoVMLRenderer.prototype.DrawText = function(
atype,
elemId,
left,
top,
color,
font,
underline,
text )
{
if ( !this._iframe || !this._iframe.contentWindow )
{
return;
}
if ( isNaN( left ) || isNaN( top ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var textSize = GetSizeofText( text, font, this._textInfo );
var vGroup = this._NewDrawing( elemId, "v:group", atype );
if ( !vGroup )
{
return;
}
vGroup.id = elemId;
vGroup.style.left = left;
vGroup.style.top = top;
vGroup.style.width = textSize.width;
vGroup.style.height = textSize.height;
vGroup.coordSize = textSize.width + " " + textSize.height;
var lines = text.split( "\n" );
var topInGroup = 0;
for ( var i = 0; i < lines.length; i ++ )
{
var elemLine = this._NewSingleLineText(
0,
topInGroup,
color,
font,
underline,
lines[i],
text);
var size = AnnoVMLRenderer.prototype._NewSingleLineText.LastTextSize;
topInGroup += size.height + 5;
vGroup.appendChild( elemLine );
}
this._group.appendChild( vGroup );
}
AnnoVMLRenderer.prototype.DrawLine = function(
atype,
elemId,
fromX,
fromY,
toX,
toY,
color,
weight )
{
if ( !this._iframe || !this._iframe.contentWindow )
{
return;
}
if ( isNaN( fromX ) || isNaN( fromY ) || isNaN( toX ) || isNaN( toY ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var elem = this._NewDrawing( elemId, "v:line", atype );
if (!elem )
{
return;
}
elem.from = fromX + "," + fromY;
elem.to = toX + "," + toY;
elem.strokeweight = weight;
elem.strokecolor = color;
var stroke = this._targetDoc.createElement("v:stroke");
stroke.endcap = "Round";
this._UpdateWeight( elem );
elem.appendChild( stroke );
this._group.appendChild( elem );
}
AnnoVMLRenderer.prototype.DrawArrow = function(
atype,
elemId,
fromX,
fromY,
toX,
toY,
color,
weight )
{
if ( !this._iframe || !this._iframe.contentWindow )
{
return;
}
if ( isNaN( fromX ) || isNaN( fromY ) || isNaN( toX ) || isNaN( toY ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var elem = this._NewDrawing( elemId, "v:line", atype );
if (!elem )
{
return;
}
elem.from = fromX + "," + fromY;
elem.to = toX + "," + toY;
elem.strokecolor = color;
elem.strokeweight = weight;
var stroke = this._targetDoc.createElement("v:stroke");
stroke.endarrow = "classic";
stroke.endcap = "Round";
elem.appendChild( stroke );
this._UpdateWeight( elem );
this._group.appendChild( elem );
}
AnnoVMLRenderer.prototype.DrawOval = function(
atype,
elemId,
left,
top,
width,
height,
color,
weight,
inneropacity,
innercolor )
{
if ( !this._iframe || !this._iframe.contentWindow )
{
return;
}
if ( isNaN( left ) || isNaN( top ) || isNaN( width ) || isNaN( height ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var elem = this._NewDrawing( elemId, "v:oval", atype );
if (!elem )
{
return;
}
elem.style.left = left;
elem.style.top = top;
elem.style.width = width;
elem.style.height = height;
elem.strokecolor = color;
elem.strokeweight = weight;
this._UpdateWeight( elem );
var fill = this._targetDoc.createElement("v:fill");
if ( inneropacity == null )
{
inneropacity = 0;
}
fill.opacity = inneropacity;
if ( innercolor != null )
{
fill.color = innercolor;
}
elem.appendChild( fill );
this._group.appendChild( elem );
}
AnnoVMLRenderer.prototype.DrawFreeLine = function(
atype,
elemId,
keyPoints,
color,
weight )
{
if ( !this._iframe || !this._iframe.contentWindow )
{
return;
}
var elem = this._NewDrawing( elemId, "v:polyline", atype );
if (!elem )
{
return;
}
elem.style.left = 0;
elem.style.top = 0;
elem.style.width = this._width;
elem.style.height = this._height;
elem.points = keyPoints;
elem.strokecolor = color;
elem.strokeweight = weight;
this._UpdateWeight( elem );
var stroke = this._targetDoc.createElement("v:stroke");
stroke.endcap = "Round";
var fill = this._targetDoc.createElement("v:fill");
fill.opacity = 0;
elem.appendChild( stroke );
elem.appendChild( fill );
this._group.appendChild( elem );
}
AnnoVMLRenderer.prototype.DrawHighLighter = function(
atype,
elemId,
keyPoints,
color,
weight )
{
if ( !this._iframe || !this._iframe.contentWindow )
{
return;
}
var elem = this._NewDrawing( elemId, "v:polyline", atype );
if (!elem )
{
return;
}
elem.style.left = 0;
elem.style.top = 0;
elem.style.width = this._width;
elem.style.height = this._height;
elem.points = keyPoints;
elem._w = weight;
elem.strokeweight = weight;
elem.strokecolor = color;
this._UpdateWeight( elem );
var stroke = this._targetDoc.createElement("v:stroke");
stroke.opacity = AnnoBaseRenderer.TransRate;
stroke.endcap = "Round";
stroke.joinstyle="round";
var fill = this._targetDoc.createElement("v:fill");
fill.opacity = 0;
elem.appendChild( stroke );
elem.appendChild( fill );
this._group.appendChild( elem );
}
AnnoVMLRenderer.prototype._CheckStampDrawing = function(
atype,
elemId,
x,
y,
color,
t1,
t2 )
{
if ( !this._iframe || !this._iframe.contentWindow )
{
return false;
}
if ( isNaN( x ) || isNaN( y ) )
{
return false;
}
return true;
}
AnnoVMLRenderer.prototype._NewDrawing = function( elemId, type, atype )
{
if ( this._targetDoc.getElementById( elemId ) )
{
g_ErrorHandling.ShowWarning( E_ANNOELMIDHASEXISTED );
return null;
}
if ( !elemId || elemId == "" )
{
g_ErrorHandling.ShowWarning( E_INVALIDARG );
return null;
}
var elem = this._targetDoc.createElement( type );
elem.id = elemId;
elem.style.zindex = this._zIndex;
this._zIndex += 5;
this._IDATypeMap[elemId] = atype;
return elem;
}
Trace.Wrap( "AnnoVMLRenderer" );
function AnnoSVGRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._htmlObjectDrawer = new AnnoHTMLElementDrawer();
this._htmlObjectDrawer.SetGetAreaWidthDelegate( Delegate( this, this.GetAnnoAreaWidth ) );
this._svgObj = null;
this._IDATypeMap = new Object();
this._svgGroupNA = false;
this.AnnoHTMLLoadedEvent.Add( Delegate( this, AnnoSVGRenderer.prototype._HTMLLoaded ) );
this._AnnoAreaResizedEvent.Add( Delegate( this, AnnoSVGRenderer.prototype._WidgetResized ) );
}
OOP.Inherit( AnnoSVGRenderer, AnnoBaseRenderer );
AnnoSVGRenderer.SVGObjID = "_Anno";
AnnoSVGRenderer.GroupID = "_svg";
AnnoSVGRenderer.HTMLGroupID = "htmlElementGroup";
AnnoSVGRenderer.DefaultFont = "normal normal normal 24pt Arial";
AnnoSVGRenderer.prototype._GetDocument = function()
{
if ( ! this._svgObj )
{
this._svgObj = this._iframe.contentDocument.getElementById(
AnnoSVGRenderer.SVGObjID
);
}
return this._svgObj.contentDocument;
}
AnnoSVGRenderer.prototype._GetGroup = function()
{
var group = null;
try
{
group = this._targetDoc.getElementById( AnnoSVGRenderer.GroupID );
}
catch( e )
{
group = null;
}
if ( !group )
{
this._svgGroupNA = true;
g_ErrorHandling.ShowWarning( E_IISNOTSUPPORTED );
}
return group;
}
AnnoSVGRenderer.prototype._WidgetResized = function()
{
this._htmlObjectDrawer.UpdateChildrenPosition( );
this._htmlObjectDrawer.UpdateChildrenSize( );
}
AnnoSVGRenderer.prototype._UpdateHTMLElementFontSize = function( elem )
{
var w = this.GetAnnoAreaWidth();
var rate = w / this._width;
var nSize = rate * parseFloat(elem.fs);
if ( nSize < 8 )
{
nSize = 8;
}
elem.style.fontSize = nSize;
}
AnnoSVGRenderer.prototype._UpdateHTMLElementPosition = function( elem )
{
var w = this.GetAnnoAreaWidth();
var rate = w / this._width;
elem.style.left = rate * elem.x;
elem.style.top = rate * elem.y;
}
AnnoSVGRenderer.prototype._UpdateWeight = function( elem )
{
if ( this._svgGroupNA )
{
return;
}
if ( elem.preservedSizeAttributes )
{
var w = this.GetAnnoAreaWidth();
for( var name in elem.preservedSizeAttributes )
{
elem.setAttribute(
name,
elem.preservedSizeAttributes[name] * this._width / w );
}
}
}
AnnoSVGRenderer.prototype._ChangeGroupSize = function( w, h )
{
if ( this._svgGroupNA )
{
return;
}
this._htmlObjectDrawer.SetPageSize( w, h );
this._ChangeViewSize( w, h );
this._group.setAttribute( "viewBox", "0 0 " + w + " " + h );
}
AnnoSVGRenderer.prototype._ChangeViewSize = function( nw, nh )
{
if ( this._svgGroupNA )
{
return;
}
this._group.setAttribute( "width", nw );
this._group.setAttribute( "height", nh );
}
AnnoSVGRenderer.prototype._GetAnnoElementById = function( id )
{
var res = this._targetDoc.getElementById( id );
if ( !res )
{
res = this._htmlObjectDrawer.GetElementById( id );
}
return res;
}
AnnoSVGRenderer.prototype._RemoveAnnoElement = function( elem )
{
if ( this._svgGroupNA )
{
return;
}
elem.setAttribute( "visibility", "hidden" );
var atype = this._IDATypeMap[elem.id];
if ( atype == "text" )
{
this._htmlObjectDrawer.RemoveElement( elem );
}
else
{
this._group.removeChild( elem );
var arrowMarker = this._targetDoc.getElementById(
AnnoSVGRenderer.GetArrowMarkerID( elem.Id )
);
if ( arrowMarker != null )
{
this._group.removeChild( arrowMarker );
}
}
delete (this._IDATypeMap[elem.id]);
}
AnnoSVGRenderer.prototype._MoveSVGElement = function( elem, dx, dy )
{
if ( this._svgGroupNA )
{
return;
}
var transform = elem.getAttribute( "transform" );
var res = transform.match( /^\w+\(([^\)]*)\)$/ );
var resXY = res[1].match( /([^,]*),([^,]*)/ );
var x = 0;
var y = 0;
if ( resXY == null )
{
x = parseFloat( res[1] );
y = 0;
}
else
{
x = parseFloat( resXY[1] );
y = parseFloat( resXY[2] );
}
elem.setAttribute( "transform", "translate(" + (x + dx) + "," + ( y + dy ) + ")" );
}
AnnoSVGRenderer.prototype._MoveHTMLElement = function( elem, dx, dy )
{
elem.x += dx;
elem.y += dy;
this._UpdateHTMLElementPosition( elem );
}
AnnoSVGRenderer.prototype._MoveElement = function( elem, dx, dy )
{
var atype = this._IDATypeMap[elem.id];
if ( atype == "text" )
{
this._MoveHTMLElement( elem, dx, dy );
}
else
{
this._MoveSVGElement( elem, dx, dy );
}
}
AnnoSVGRenderer.prototype._ClearSVGElements = function()
{
while( this._group.childNodes.length > 0 )
{
this._group.removeChild( this._group.childNodes[0] );
}
}
AnnoSVGRenderer.prototype._ClearHTMLElements = function()
{
this._htmlObjectDrawer.Clear();
}
AnnoSVGRenderer.prototype._RefreshScreen = function()
{
this.DrawFreeLine(
"freeline",
"_er_eraser",
"-10,-10,-10,"+(this._height+10) + "," + ( this._width+10 ) + "," +(this._height+10),
"#000000",
0.1
);
}
AnnoSVGRenderer.prototype._ClearElements = function( isReset )
{
if ( this._svgGroupNA )
{
return;
}
this._ClearSVGElements();
this._ClearHTMLElements();
if ( !isReset )
{
this._RefreshScreen();
}
this._IDATypeMap = {};
}
AnnoSVGRenderer.prototype._ChangeAnnoColor = function( elem, color )
{
if ( this._svgGroupNA )
{
return;
}
var elemId = elem.id;
switch ( this._IDATypeMap[elemId] )
{
case "rect":
case "roundrect":
case "oval":
case "line":
case "freeline":
case "highlighter":
elem.setAttribute( "stroke", color );
break;
case "arrow":
elem.setAttribute( "stroke", color );
var markerId = AnnoSVGRenderer.GetArrowMarkerID( elemId );
var marker = this._targetDoc.getElementById( markerId );
marker.setAttribute( "fill", color );
break;
case "xstamp":
case "arrowstamp":
case "checkstamp":
elem.setAttribute( "fill", color );
break;
case "pointer":
elem.setAttribute( "fill", color );
break;
case "text":
elem.style.color = color;
break;
default:
alert( this._IDATypeMap[elemId] );
}
}
AnnoSVGRenderer.prototype.DrawRect = function(
atype,
elemId,
left,
top,
width,
height,
color,
weight )
{
if ( this._svgGroupNA )
{
return;
}
if ( !this._targetDoc )
{
return;
}
if ( isNaN( left ) || isNaN( top ) || isNaN( width ) || isNaN( height ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var elem = this._NewDrawing( elemId, "rect", atype );
if (!elem )
{
return;
}
elem.setAttribute( "x", left );
elem.setAttribute( "y", top );
elem.setAttribute( "width", width );
elem.setAttribute( "height", height );
elem.setAttribute( "stroke", color );
elem.setAttribute( "fill-opacity", 0.0 );
this._SetPreservedSizeAttributes( elem, { "stroke-width": weight } );
this._UpdateWeight( elem );
this._group.appendChild( elem );
}
AnnoSVGRenderer.prototype._SetPreservedSizeAttributes = function( elem, attributes )
{
elem.preservedSizeAttributes = attributes;
for( var name in attributes )
{
elem.setAttribute( name, elem.preservedSizeAttributes[ name ] );
}
}
AnnoSVGRenderer.prototype.DrawRoundRect = function(
atype,
elemId,
left,
top,
width,
height,
color,
weight )
{
if ( this._svgGroupNA )
{
return;
}
if ( !this._targetDoc )
{
return;
}
if ( isNaN( left ) || isNaN( top ) || isNaN( width ) || isNaN( height ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
this.DrawRect( atype, elemId, left, top, width, height, color, weight );
var elem = this._targetDoc.getElementById( elemId );
elem.setAttribute( "rx", 3 );
elem.setAttribute( "ry", 3 );
this._UpdateWeight( elem );
}
AnnoSVGRenderer.prototype.UpdateText = function(
atype,
elemId,
left,
top,
color,
font,
underline,
text )
{
if ( this._IDATypeMap[elemId] != "text" )
{
return;
}
var textElem = this._htmlObjectDrawer.Query( elemId );
if ( !textElem )
{
return;
}
this._htmlObjectDrawer.RemoveElement( textElem );
this.DrawText(
atype,
elemId,
left,
top,
color,
font,
underline,
text );
}
AnnoSVGRenderer.prototype.DrawText = function(
atype,
elemId,
left,
top,
color,
font,
underline,
text )
{
if ( isNaN( left ) || isNaN( top ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var elem = this._NewHTMLDrawing( elemId, "div", atype );
if (!elem )
{
return;
}
elem.x = left;
elem.y = top;
this._UpdateHTMLElementPosition( elem );
elem.style.color = color;
try
{
elem.style.font = font;
}
catch( e )
{
elem.style.font = AnnoSVGRenderer.DefaultFont;
}
elem.fs = elem.style.fontSize;
try
{
elem.style.textDecoration = underline?"underline":"none";
}
catch( e )
{
elem.style.textDecoration = "none";
}
this._UpdateHTMLElementFontSize( elem );
elem.innerHTML = GetSafeText( text );
var size = GetSizeofText( text, elem.style.font, this._textInfo );
elem.style.width = size.width + 1;
elem.style.height = size.height + 1;
elem.title = text;
this._htmlObjectDrawer.AppendToGroup( elem );
}
AnnoSVGRenderer.prototype.DrawLine = function(
atype,
elemId,
fromX,
fromY,
toX,
toY,
color,
weight )
{
if ( this._svgGroupNA )
{
return;
}
if ( !this._targetDoc )
{
return;
}
if ( isNaN( fromX ) || isNaN( fromY ) || isNaN( toX ) || isNaN( toY ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var elem = this._NewDrawing( elemId, "line", atype );
if (!elem )
{
return;
}
elem.setAttribute( "x1", fromX );
elem.setAttribute( "y1", fromY );
elem.setAttribute( "x2", toX );
elem.setAttribute( "y2", toY );
elem.setAttribute( "stroke", color );
elem.setAttribute( "stroke-linejoin", "round" );
elem.setAttribute( "stroke-linecap", "round" );
this._SetPreservedSizeAttributes( elem, {"stroke-width": weight } );
this._UpdateWeight( elem );
this._group.appendChild( elem );
}
AnnoSVGRenderer.prototype.DrawArrow = function(
atype,
elemId,
fromX,
fromY,
toX,
toY,
color,
weight )
{
if ( this._svgGroupNA )
{
return;
}
if ( !this._targetDoc )
{
return;
}
if ( isNaN( fromX ) || isNaN( fromY ) || isNaN( toX ) || isNaN( toY ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var elem = this._NewDrawing( elemId, "line", atype );
if (!elem )
{
return;
}
var marker = this._targetDoc.createElementNS(
"http://www.w3.org/2000/svg",
"marker"
);
var markerId = AnnoSVGRenderer.GetArrowMarkerID( elemId );
marker.setAttribute( "id", markerId );
marker.setAttribute( "refX", 8 );
marker.setAttribute( "refY", 5 );
marker.setAttribute( "viewBox", "0 0 10 10" );
marker.setAttribute( "preserveAspectRatio", "none" );
marker.setAttribute( "markerUnits", "strokeWidth" );
marker.setAttribute( "markerWidth", 8 );
marker.setAttribute( "markerHeight", 5 );
marker.setAttribute( "orient", "auto" );
marker.setAttribute( "fill", color );
var markerPath = this._targetDoc.createElementNS(
"http://www.w3.org/2000/svg",
"path"
);
markerPath.setAttribute( "d", "M 0 0 L 10 5 L 0 10 z" );
marker.appendChild( markerPath );
this._group.appendChild( marker );
elem.setAttribute( "x1", fromX );
elem.setAttribute( "y1", fromY );
elem.setAttribute( "x2", toX );
elem.setAttribute( "y2", toY );
elem.setAttribute( "stroke", color );
elem.setAttribute( "marker-end", "url(#" + markerId + ")" );
elem.setAttribute( "stroke-linecap", "round" );
this._SetPreservedSizeAttributes( elem, {"stroke-width": weight } );
this._UpdateWeight( elem );
this._group.appendChild( elem );
}
AnnoSVGRenderer.prototype.DrawOval = function(
atype,
elemId,
left,
top,
width,
height,
color,
weight,
inneropacity,
innercolor )
{
if ( this._svgGroupNA )
{
return;
}
if ( !this._targetDoc )
{
return;
}
if ( isNaN( left ) || isNaN( top ) || isNaN( width ) || isNaN( height ) )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var elem = this._NewDrawing( elemId, "ellipse", atype );
if (!elem )
{
return;
}
var cx = left + width / 2;
var cy = top + height / 2;
elem.setAttribute( "cx", cx );
elem.setAttribute( "cy", cy );
elem.setAttribute( "rx", width / 2 );
elem.setAttribute( "ry", height / 2 );
elem.setAttribute( "stroke", color );
elem.setAttribute( "fill-opacity", inneropacity );
elem.setAttribute( "fill", innercolor );
this._SetPreservedSizeAttributes( elem, {"stroke-width": weight } );
this._UpdateWeight( elem );
this._group.appendChild( elem );
}
AnnoSVGRenderer.prototype.DrawFreeLine = function(
atype,
elemId,
keyPoints,
color,
weight )
{
if ( this._svgGroupNA )
{
return;
}
if ( !this._targetDoc )
{
return;
}
var elem = this._NewDrawing( elemId, "polyline", atype );
if (!elem )
{
return;
}
keyPoints = keyPoints.replace( /(\d+(.\d+)?),(\d+(.\d+)?),/g, "$1,$3 " );
elem.setAttribute( "stroke", color );
elem.setAttribute( "points", keyPoints );
elem.setAttribute( "fill-opacity", 0 );
elem.setAttribute( "stroke-linejoin", "round" );
elem.setAttribute( "stroke-linecap", "round" );
this._SetPreservedSizeAttributes( elem, {"stroke-width": weight } );
this._UpdateWeight( elem );
this._group.appendChild( elem );
}
AnnoSVGRenderer.prototype.DrawHighLighter = function(
atype,
elemId,
keyPoints,
color,
weight )
{
if ( this._svgGroupNA )
{
return;
}
if ( !this._targetDoc )
{
return;
}
var elem = this._NewDrawing( elemId, "polyline", atype );
if (!elem )
{
return;
}
keyPoints = keyPoints.replace( /(\d+(.\d+)?),(\d+(.\d+)?),/g, "$1,$3 " );
elem.setAttribute( "stroke", color );
elem.setAttribute( "stroke-width", weight );
elem.setAttribute( "stroke-opacity", AnnoBaseRenderer.TransRate );
elem.setAttribute( "points", keyPoints );
elem.setAttribute( "fill-opacity", 0 );
elem.setAttribute( "stroke-linejoin", "round" );
elem.setAttribute( "stroke-linecap", "round" );
this._UpdateWeight( elem );
this._group.appendChild( elem );
}
AnnoSVGRenderer.prototype._CheckStampDrawing = function(
atype,
elemId,
x,
y,
color,
t1,
t2 )
{
if ( this._svgGroupNA )
{
return false;
}
if ( !this._targetDoc )
{
return false;
}
if ( isNaN( x ) || isNaN( y ) )
{
return false;
}
return true;
}
AnnoSVGRenderer.prototype._NewDrawing = function( elemId, type, atype )
{
if ( this._iframe.contentWindow.document.getElementById( elemId ) )
{
g_ErrorHandling.ShowWarning( E_ANNOELMIDHASEXISTED );
return null;
}
if ( !elemId || elemId == "" )
{
g_ErrorHandling.ShowWarning( E_INVALIDARG );
return null;
}
var elem = this._targetDoc.createElementNS(
"http://www.w3.org/2000/svg",
type
);
elem.setAttribute( "id", elemId );
elem.setAttribute( "z-index", this._zIndex );
elem.setAttribute( "transform", "translate(0.0,0.0)" );
this._zIndex += 5;
this._IDATypeMap[elemId] = atype;
return elem;
}
AnnoSVGRenderer.prototype._NewHTMLDrawing = function( elemId, type, atype )
{
if ( this._htmlObjectDrawer.Query( elemId ) )
{
g_ErrorHandling.ShowWarning( E_ANNOELMIDHASEXISTED );
return null;
}
var elem = this._htmlObjectDrawer.NewElement( elemId, type );
this._IDATypeMap[elemId] = atype;
return elem;
}
AnnoSVGRenderer.GetArrowMarkerID = function( elemId )
{
return "_ar_" + elemId;
}
AnnoSVGRenderer.prototype._HTMLLoaded = function()
{
this._htmlTargetDoc = this._iframe.contentWindow.document;
this._htmlObjectDrawer.SetDoc( this._iframe.contentWindow.document );
this._htmlObjectDrawer.SetGroup( this._htmlTargetDoc.getElementById( AnnoSVGRenderer.HTMLGroupID ) );
this._htmlObjectDrawer.SetTextInfoDiv( this._textInfo );
}
Trace.Wrap( "AnnoSVGRenderer" );
function PollChoiceWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._iconObject = new BasicWidget();
this._nameObject = new TextWidget();
this._resultObject = new TextWidget();
this._percentObject = new BasicWidget();
this._numberObject = new TextWidget();
this._percent = 0;
this._Created.Add( Delegate( this, PollChoiceWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, PollChoiceWidget.prototype._WidgetResized ) );
}
OOP.Inherit( PollChoiceWidget, BasicWidget );
PollChoiceWidget.prototype._WidgetCreated = function()
{
this._iconObject.Create( this );
this._nameObject.Create( this );
this._percentObject.Create( this );
this._resultObject.Create( this );
this._numberObject.Create( this );
this._resultObject.SetStyle( "textAlign", "center" );
this._resultObject.SetVertAlignMiddle( true );
this._resultObject.SetBorder( "solid", 2, 2, 2, 2 );
this._numberObject.SetVertAlignMiddle( true );
this._iconObject.SetBorder( "outset", 2, 2, 2, 2 );
}
PollChoiceWidget.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
Trace.WriteLine( "Client width is %1", clientWidth );
Trace.WriteLine( "Client height is %1", clientHeight );
var iconTop = 0;
var iconHeight = clientHeight;
var iconLeft = UISettings.pollChoiceAreaPaddingLeft;
var iconWidth = UISettings.pollChoiceIconWidth;
var numberTop = 0;
var numberHeight = clientHeight;
var numberWidth = UISettings.pollResultCountWidth;
var numberLeft = clientWidth - numberWidth - UISettings.pollChoiceAreaPaddingRight;
var resultTop = 0;
var resultHeight = clientHeight;
var resultWidth = UISettings.pollResultRatioWidth;
var resultLeft = numberLeft - UISettings.pollResultItemHorzMargin - resultWidth;
var nameLeft = iconLeft + iconWidth + UISettings.pollChoiceItemHorzMargin;
var nameTop = 0;
var nameHeight = clientHeight;
var nameWidth = resultLeft - nameLeft -
UISettings.pollResultAreaPaddingLeft -
UISettings.pollChoiceResultMargin -
UISettings.pollChoiceItemHorzMargin;
this._iconObject.SetUIPosition(
true,
iconLeft,
iconTop,
iconWidth,
iconHeight );
this._nameObject.SetUIPosition(
true,
nameLeft,
nameTop,
nameWidth,
nameHeight );
this._resultObject.SetUIPosition(
true,
resultLeft,
resultTop,
resultWidth,
resultHeight );
this._percentObject.SetUIPosition(
true,
resultLeft,
resultTop,
resultWidth * this._percent,
resultHeight );
this._numberObject.SetUIPosition(
true,
numberLeft,
numberTop,
numberWidth,
numberHeight );
}
PollChoiceWidget.prototype.ShowLines = function( lineCount )
{
var height = this.GetHeight();
var LineToFont = 0.75;
var fontHeight = height * LineToFont / lineCount;
this._nameObject.SetStyle( "fontSize", fontHeight );
return this._nameObject.IsAllTextVisible();
}
PollChoiceWidget.prototype.Initialize = function( name, color )
{
this._percent = 0;
this._iconObject.SetStyle( "backgroundColor",  color );
this._nameObject.SetText( name, true );
this._percentObject.SetStyle( "backgroundColor",  color );
this._resultObject.SetText( "0%" );
this._numberObject.SetText( "0" );
this._numberObject._htmlObject.style.textAlign = "right";
}
PollChoiceWidget.prototype.Update = function( percent, number )
{
percent = Number( percent );
if( percent < 0 ||  percent > 100 )
{
return;
}
this._percent = percent / 100;
var n = 1;
var base10 = Math.pow( 10, n );
var normalPercent = Math.round( percent * base10 ) / base10;
this._resultObject.SetText( normalPercent + "%" );
this._numberObject.SetText( String(number) );
this._percentObject.SetUIPosition(
true,
this._resultObject.GetLeft(),
this._resultObject.GetTop(),
this._resultObject.GetWidth() * this._percent,
this._resultObject.GetHeight() );
}
PollChoiceWidget.prototype.Hide = function()
{
this._resultObject.SetStyle( "visibility", "hidden");
this._percentObject.SetStyle( "visibility",  "hidden" );
this._numberObject.SetStyle( "visibility", "hidden");
}
PollChoiceWidget.prototype.Show = function()
{
this._resultObject.SetStyle( "visibility", "inherit");
this._percentObject.SetStyle( "visibility",  "inherit" );
this._numberObject.SetStyle( "visibility", "inherit");
}
Trace.Wrap( "PollChoiceWidget" );
function ImageRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this.image = new ImageWidget();
this.fitter = new WidgetFitter();
this._AfterLoadedEvent = new Event();
this.image._AfterLoadedEvent.Add( this._AfterLoadedEvent );
this._Created.Add( Delegate( this, ImageRenderer.prototype._WidgetCreated ) );
}
OOP.Inherit( ImageRenderer, BasicWidget );
OOP.Inherit( ImageRenderer, RenderingSession );
ImageRenderer.prototype._WidgetCreated = function()
{
this.image.Create( this );
this.fitter.Bind( this, this.image, "proportional" );
}
ImageRenderer.prototype.SetURI = function( uri )
{
this.image.SetURI( uri );
}
Trace.Wrap( "ImageRenderer" );
function ModiRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this.image = new ImageWidget();
this.fitter = new WidgetFitter();
this._AfterLoadedEvent = new Event();
this.image._AfterLoadedEvent.Add( this._AfterLoadedEvent );
this._Created.Add( Delegate( this, ModiRenderer.prototype._CreateEvtHandler ) );
}
OOP.Inherit( ModiRenderer, BasicWidget );
OOP.Inherit( ModiRenderer, RenderingSession );
ModiRenderer.prototype._CreateEvtHandler = function()
{
this.image.Create( this );
this.SetStyle( "overflow", "auto" );
this.fitter.Bind( this, this.image, "center" );
}
ModiRenderer.prototype.SetURI = function( uri )
{
this.image.SetURI( uri );
}
Trace.Wrap( "ModiRenderer" );
function PollRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._resultArea = new BasicWidget();
this._choiceArea = new BasicWidget();
this._questionLabel = new TextWidget();
this._resultLabel = new TextWidget();
this._choiceLabel = new TextWidget();
this._questionArea = new TextWidget();
this._stateLabel = new TextWidget();
this._visibilityLabel = new TextWidget();
this._choiceItems = new Array();
this._validCount = 0;
this._Created.Add( Delegate( this, PollRenderer.prototype._CreateEvtHandler ) );
this._Resized.Add( Delegate( this, PollRenderer.prototype._ResizeEvtHandler ) );
}
OOP.Inherit( PollRenderer, BasicWidget );
OOP.Inherit( PollRenderer, RenderingSession );
PollRenderer.prototype.Initialize = function()
{
this._Reset();
}
PollRenderer.prototype.Uninitialize = function()
{
}
PollRenderer.prototype._Reset = function()
{
this._questionLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptQuestionText ) );
this._resultLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptResultsText ));
this._choiceLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptChoicesText ));
this._stateLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptPollsOpenText ) );
this._visibilityLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptResultsShownText ));
this.SetName("");
this.SetChoices( [] );
this.Enable();
this.ShowResult();
}
PollRenderer.prototype._CreateEvtHandler = function()
{
this.SetStyle( "overflow", "auto" );
this._choiceArea.Create( this );
this._resultArea.Create( this );
this._questionLabel.Create( this );
this._resultLabel.Create( this );
this._choiceLabel.Create( this );
this._questionArea.Create( this );
this._stateLabel.Create( this );
this._visibilityLabel.Create( this );
this._questionArea.SetBorder( "solid", 1, 1, 1, 1 );
this._questionArea._htmlObject.style.borderColor = "#000000";
this._choiceArea.SetBorder( "solid", 1, 1, 1, 1 );
this._choiceArea._htmlObject.style.borderColor = "#000000";
this._resultArea.SetBorder( "solid", 1, 1, 1, 1 );
this._resultArea._htmlObject.style.borderColor = "#000000";
this.SetStyle( "backgroundColor",  "white" );
this._questionLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptQuestionText ) );
this._resultLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptResultsText ));
this._choiceLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptChoicesText ));
this._stateLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptPollsOpenText ) );
this._visibilityLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptResultsShownText ));
for( var i = 0; i < UISettings.pollChoiceCountMax; i++ )
{
this._choiceItems[i] = new PollChoiceWidget();
this._choiceItems[i].Create(this);
}
}
PollRenderer.prototype._FitChoiceTexts = function()
{
var levels = UISettings.pollChoiceFontSizeLevels;
for( var j=1; j < 1 + levels; j++ )
{
var allFitted = true;
for (var i = 0; i < this._choiceItems.length; i++)
{
if( !this._choiceItems[i].ShowLines( j ) )
{
allFitted = false;
}
}
if( allFitted )
{
break;
}
}
}
PollRenderer.prototype._ResizeEvtHandler = function()
{
var width = this.GetWidth();
var height = this.GetHeight();
var clientWidth = width;
var clientHeight = height;
if( clientWidth < UISettings.pollPageWidthMin )
{
clientWidth = UISettings.pollPageWidthMin;
}
if( clientHeight < UISettings.pollPageHeightMin )
{
clientHeight = UISettings.pollPageHeightMin;
}
var questionLabelLeft = UISettings.pollPagePaddingLeft;
var questionLabelTop = UISettings.pollPagePaddingTop;
var questionLabelHeight = UISettings.pollQuestionLabelHeight;
var questionLabelWidth = clientWidth - questionLabelLeft - UISettings.pollPagePaddingRight;
var questionAreaTop = questionLabelTop + questionLabelHeight + UISettings.pollQuestionLabelBottomMargin;
var questionAreaLeft = questionLabelLeft;
var questionAreaWidth = questionLabelWidth;
var questionAreaHeight = UISettings.pollQuestionAreaHeight;
var choiceLabelTop = questionAreaTop + questionAreaHeight + UISettings.pollChoiceLabelTopMargin;
var choiceLabelHeight = UISettings.pollChoiceLabelHeight;
var choiceLabelLeft = questionLabelLeft;
var choiceLabelWidth = questionLabelWidth - UISettings.pollChoiceResultMargin - UISettings.pollResultAreaWidth;
var resultLabelTop = choiceLabelTop;
var resultLabelWidth = UISettings.pollResultAreaWidth;
var resultLabelLeft = clientWidth - UISettings.pollPagePaddingRight - resultLabelWidth;
var resultLabelHeight = choiceLabelHeight;
var stateLabelTop = clientHeight - UISettings.pollPagePaddingBottom - UISettings.pollStateLabelHeight;
var stateLabelHeight = UISettings.pollStateLabelHeight;
var stateLabelLeft = choiceLabelLeft;
var stateLabelWidth = choiceLabelWidth;
var visibilityLabelTop = stateLabelTop;
var visibilityLabelHeight = stateLabelHeight;
var visibilityLabelLeft = resultLabelLeft;
var visibilityLabelWidth = resultLabelWidth;
var resultAreaWidth = UISettings.pollResultAreaWidth;
var resultAreaLeft = resultLabelLeft;
var resultAreaTop = resultLabelTop + resultLabelHeight + UISettings.pollChoiceLabelBottomMargin;
var resultAreaHeight = visibilityLabelTop - UISettings.pollStateLabelTopMargin - resultAreaTop;
var choiceAreaWidth = choiceLabelWidth;
var choiceAreaLeft = choiceLabelLeft;
var choiceAreaTop = choiceLabelTop + choiceLabelHeight + UISettings.pollChoiceLabelBottomMargin;
var choiceAreaHeight = resultAreaHeight;
this._questionLabel.SetUIPosition(
true,
questionLabelLeft,
questionLabelTop,
questionLabelWidth,
questionLabelHeight );
this._choiceLabel.SetUIPosition(
true,
choiceLabelLeft,
choiceLabelTop,
choiceLabelWidth,
choiceLabelHeight );
this._resultLabel.SetUIPosition(
true,
resultLabelLeft,
resultLabelTop,
resultLabelWidth,
resultLabelHeight );
this._questionArea.SetUIPosition(
true,
questionAreaLeft,
questionAreaTop,
questionAreaWidth,
questionAreaHeight );
this._choiceArea.SetUIPosition(
true,
choiceAreaLeft,
choiceAreaTop,
choiceAreaWidth,
choiceAreaHeight );
this._resultArea.SetUIPosition(
true,
resultAreaLeft,
resultAreaTop,
resultAreaWidth,
resultAreaHeight );
this._stateLabel.SetUIPosition(
true,
stateLabelLeft,
stateLabelTop,
stateLabelWidth,
stateLabelHeight );
this._visibilityLabel.SetUIPosition(
true,
visibilityLabelLeft,
visibilityLabelTop,
visibilityLabelWidth,
visibilityLabelHeight );
if ( this._choiceItems.length == 0 )
{
Trace.WriteLine( "There isn't any choice yet." );
return;
}
var choiceItemLeft = choiceAreaLeft;
var choiceItemTop = choiceAreaTop + UISettings.pollChoiceAreaPaddingTop;
var choiceItemHeight = UISettings.pollChoiceItemHeight;
var choiceItemWidth = resultAreaLeft + resultAreaWidth - choiceItemLeft;
for (var i = 0; i < this._choiceItems.length; i++)
{
this._choiceItems[i].SetUIPosition(
true,
choiceItemLeft,
choiceItemTop,
choiceItemWidth,
choiceItemHeight );
choiceItemTop += choiceItemHeight + UISettings.pollChoiceItemVertMargin;
}
this._questionArea.FitTextByChangeFont();
this._FitChoiceTexts();
if( NavigatorInfo.IsFirefox() )
{
this.SetSize( 0, 0, true );
this.SetSize( width, height, true );
}
}
PollRenderer.prototype.SetName = function( name )
{
if (typeof(name) != "string")
{
return;
}
this._questionArea.SetText( name, true );
if( this._questionArea.IsCreated() )
{
this._questionArea.FitTextByChangeFont();
}
}
PollRenderer.prototype.SetChoices = function( choices )
{
Trace.WriteLine("# of poll choice to be added: " + choices.length );
this._validCount = choices.length;
for (var i = 0; i < UISettings.pollChoiceCountMax; i++ )
{
if( i < this._validCount )
{
this._choiceItems[i].Initialize( choices[i].name, choices[i].color);
this._choiceItems[i].Update( 0, 0 );
this._choiceItems[i].SetStyle( "visibility",  "inherit" );
}
else
{
this._choiceItems[i].SetStyle( "visibility",  "hidden" );
}
}
this._FitChoiceTexts();
}
PollRenderer.prototype.UpdateCount = function( pollData )
{
if ( pollData.length != this._validCount )
{
return;
}
Trace.WriteLine("# of poll choice to be updated: " + pollData.length );
for (var i = 0; i < pollData.length; i++ )
{
this._choiceItems[i].Update( pollData[i].percent, pollData[i].number);
}
}
PollRenderer.prototype.Enable = function()
{
this._stateLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptPollsOpenText ) );
}
PollRenderer.prototype.Disable = function()
{
this._stateLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptPollsClosedText ) );
}
PollRenderer.prototype.HideResult = function()
{
for (var i = 0; i < this._choiceItems.length; i++)
{
this._choiceItems[i].Hide();
}
this._visibilityLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptResultsHiddenText ) );
}
PollRenderer.prototype.ShowResult = function()
{
for (var i = 0; i < this._choiceItems.length; i++)
{
this._choiceItems[i].Show();
}
this._visibilityLabel.SetText( LocaleInfo.GetText( UISettings.pollPromptResultsShownText ) );
}
Trace.Wrap( "PollRenderer" );
function TextRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._Created.Add( Delegate( this, TextRenderer.prototype._CreateEvtHandler ) );
}
OOP.Inherit( TextRenderer, TextWidget );
OOP.Inherit( TextRenderer, RenderingSession );
TextRenderer.prototype.Initialize = function()
{
this.SetText("");
}
TextRenderer.prototype.Uninitialize = function()
{
this.SetText("");
}
TextRenderer.prototype._CreateEvtHandler = function()
{
}
Trace.Wrap( "TextRenderer" );
function QAItemWidget()
{
OOP.CallParentConstructor( this, arguments.callee );
this._questionText = new TextWidget();
this._answerText = new TextWidget();
this._Created.Add( Delegate( this, QAItemWidget.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, QAItemWidget.prototype._WidgetResized ) );
}
OOP.Inherit( QAItemWidget, BasicWidget );
QAItemWidget.prototype._WidgetCreated = function()
{
this._questionText.Create( this );
this._answerText.Create( this );
this._questionText.ResetStyle( "height" );
this._answerText.ResetStyle( "height" );
this._questionText.SetStyle( "position", "relative" );
this._answerText.SetStyle( "position", "relative" );
this._questionText._htmlObject.style.width = "100%";
this._answerText._htmlObject.style.width = "100%";
}
QAItemWidget.prototype._WidgetResized = function()
{
}
QAItemWidget.prototype.SetQAText = function( question, answer )
{
this._questionText.SetText( LocaleInfo.GetText( UISettings.qaQuestionText ) + question, true );
this._answerText.SetText( LocaleInfo.GetText( UISettings.qaAnswerText ) + answer, true );
}
Trace.Wrap( "QAItemWidget" );
function QARenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._noItemPrompt = new TextWidget();
this._itemClassNames = {
"normal":UISettings.qaNormalItemClassName,
"highlighted":UISettings.qaHighlightedItemClassName,
"seperator":UISettings.qaSeperatorClassName
};
this._Created.Add( Delegate( this, QARenderer.prototype._WidgetCreated ) );
}
OOP.Inherit( QARenderer, ListWidget );
QARenderer.prototype._WidgetCreated = function()
{
this._noItemPrompt.Create( this, UISettings.qaNoItemPromptId );
this._noItemPrompt.SetText( LocaleInfo.GetText( UISettings.qaNoDataText ) );
this._noItemPrompt.SetLocation( 0, 0 );
}
QARenderer.prototype._AddDisplayItem = function( index )
{
var question = this._listData[ index ].question;
var answer = this._listData[ index ].answer;
var item = new QAItemWidget();
if( this.GetItemCount() > 0 )
{
this._AddQASeperator();
}
else
{
this._noItemPrompt.SetStyle( "visibility", "hidden" );
}
this.AddItem( item, true );
item.SetQAText( question, answer );
}
QARenderer.prototype._AddQASeperator = function()
{
var seperator = new BasicWidget();
this.AddSeperator( seperator );
}
QARenderer.prototype.SetQaItems = function( qaData )
{
if( qaData == null )
{
Trace.WriteLine( "There is no qa data. " );
return;
}
for( var i=0; i<qaData.length; i++ )
{
var item = qaData[i];
this._listData[i] = { "question":item.Question, "answer":item.Answer };
}
this._AsyncAddNextItem( 0 );
}
Trace.Wrap( "QARenderer" );
function WebRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._uri = null;
this._urlText = new TextWidget();
this._securityWarning = new TextWidget();
this._snapshotBound = new BasicWidget();
this._snapshotBorder = new BasicWidget();
this._snapshot = new ImageWidget();
this._snapshotFitter = new WidgetFitter();
this._bottomRightImage = new ImageWidget();
this._Created.Add( Delegate( this, WebRenderer.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, WebRenderer.prototype._WidgetResized ) );
}
OOP.Inherit( WebRenderer, BasicWidget );
OOP.Inherit( WebRenderer, RenderingSession );
WebRenderer.prototype._WidgetCreated = function()
{
this._bottomRightImage.Create( this, UISettings.webBottomRightImageId );
this._bottomRightImage.SetStyle( "position", "absolute" );
this._securityWarning.Create( this, UISettings.webWarningId );
this._urlText.Create( this, UISettings.webUrlId );
this._snapshotBound.Create( this, UISettings.webSnapshotBoundId );
this._snapshotBorder.Create( this._snapshotBound, UISettings.webSnapshotBorderId );
this._snapshot.Create( this._snapshotBound, UISettings.webSnapshotId );
this._snapshotBorder.SetStyle( "visibility", "hidden" );
this._snapshot.ImageLoadedEvent.Add( Delegate( this, WebRenderer.prototype._ShowSnapshot ) );
this._snapshotFitter.Bind(
this._snapshotBound,
this._snapshot,
"center_proportional",
UISettings.webSnapshotPaddingLeft,
UISettings.webSnapshotPaddingTop,
UISettings.webSnapshotPaddingRight,
UISettings.webSnapshotPaddingBottom );
this._snapshotFitter.PositionChangedEvent.Add(
Delegate( this, WebRenderer.prototype._ImagePositionChanged ) );
this._bottomRightImage.SetURI( uiSettings.GetImage( "dataAreaBottomRight" ) );
this._urlText.SetStyle( "cursor", "pointer" );
this._urlText.SetStyle( "textDecoration", "underline" );
this._urlText.SetAttribute(
"title",
LocaleInfo.GetText( UISettings.webSlideUriTooltipId ) );
this._urlText.RegisterEvent( "onclick", Delegate( this, WebRenderer.prototype._ShowWebPage ) );
this._urlText.EnableMultipleLines( false );
this._securityWarning.SetText( LocaleInfo.GetText( UISettings.webSlideWarningTextId ) );
}
WebRenderer.prototype._ImagePositionChanged = function( parent, left, top, width, height )
{
this._snapshotBorder.SetUIPosition(
true,
left - 1,
top - 1,
width + 2,
height + 2 );
}
WebRenderer.prototype._WidgetResized = function()
{
var paddedWidth = this.GetPaddedWidth();
var paddedHeight = this.GetPaddedHeight();
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
this._urlText.SetWidth( clientWidth );
this._securityWarning.SetWidth( clientWidth );
var urlBottom = this._urlText.GetTop() + this._urlText.GetHeight();
var snapshotHeight = clientHeight - urlBottom;
if( snapshotHeight < 0 )
{
snapshotHeight = 0;
}
this._snapshotBound.SetSize( clientWidth, snapshotHeight );
var imageWidth = this._bottomRightImage._originalWidth;
var imageHeight = this._bottomRightImage._originalHeight;
var imageLeft = paddedWidth - imageWidth;
var imageTop = paddedHeight - imageHeight;
this._bottomRightImage.SetUIPosition(
true,
imageLeft,
imageTop,
imageWidth,
imageHeight );
}
WebRenderer.prototype.SetURI = function( webUri, snapshotUri )
{
this._HideSnapshot();
this._uri = webUri;
if( webUri == null )
{
webUri = LocaleInfo.GetText( UISettings.webUnavailableUrlId );
}
this._urlText.SetText( webUri );
this._snapshot.SetURI( snapshotUri );
}
WebRenderer.prototype._HideSnapshot = function()
{
this._snapshotBorder.SetStyle( "visibility", "hidden" );
}
WebRenderer.prototype._ShowSnapshot = function()
{
this._snapshotBorder.SetStyle( "visibility", "inherit" );
}
WebRenderer.prototype._ShowWebPage = function()
{
if( this._uri != null )
{
try{
var popupWindow = window.open(
"",
"_blank" );
if( popupWindow != null )
{
popupWindow.location = this._uri;
}
}catch(e)
{
var errorMessage = LocaleInfo.GetText( UISettings.webUnavailableUrlWarningTextId );
errorMessage = FormatString( errorMessage, encodeURI( this._uri ) );
errorMessage = EncodeLessThanSign(errorMessage);
popupWindow.document.write("<html><title>"+errorMessage+ "</title></html>");
}
}
}
Trace.Wrap( "WebRenderer" );
function NotesRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._AfterLoadedEvent.Add( Delegate( this, NotesRenderer.prototype._AfterLoadedHandler ) );
}
OOP.Inherit( NotesRenderer, HTMLWidget );
NotesRenderer.prototype._AfterLoadedHandler = function()
{
var iframeWindow = this._iframe.contentWindow;
if( iframeWindow && iframeWindow.location.href == HTMLWidget.defaultBlankPageUri )
{
var htmlString = "<div style='cursor: default; color: #808080'>" +
LocaleInfo.GetText( UISettings.notesNoDataText ) +
"</div>";
if ( iframeWindow.document )
{
var iframeBody = iframeWindow.document.body;
if ( iframeBody )
{
iframeBody.innerHTML = htmlString;
}
}
}
}
Trace.Wrap( "NotesRenderer" );
function PPTAnimationEngine()
{
OOP.CallParentConstructor( this, arguments.callee );
this._cmdQueuetimerHandler  = null;
this._lastUpdatedTime       = 0;
this._cmdQueue              = new Array();
this.Rate                   = 1.0;
this._slideFrame            = null;
this._supportAnimation      = true;
}
PPTAnimationEngine.CmdSetPosition = 0;
PPTAnimationEngine.CmdControl = 1;
PPTAnimationEngine.PrevNext = 2;
PPTAnimationEngine.prototype.Initialize = function()
{
this.Reset();
}
PPTAnimationEngine.prototype.Uninitialize = function()
{
this.Reset();
if ( this._cmdQueuetimerHandler != null )
{
clearTimeout( this._cmdQueuetimerHandler );
this._cmdQueuetimerHandler = null;
}
}
PPTAnimationEngine.prototype.GetRelativePosition = function()
{
if ( !this._supportAnimation )
{
return 0;
}
return this._slideFrame.document.body.localTime;
}
PPTAnimationEngine.prototype.SetPosition = function( pos, state, isSeek )
{
this.AddCmd(
DelegateWithArgs(
this,
this.SetPositionCmd,
{"pos":pos, "state":state, "isSeek":isSeek}
),
PPTAnimationEngine.CmdSetPosition
);
}
PPTAnimationEngine.prototype.Play = function()
{
this.AddCmd(
DelegateWithArgs(
this,
this.PlayCmd,
{}
),
PPTAnimationEngine.CmdControl
);
}
PPTAnimationEngine.prototype.Start = function()
{
this.AddCmd(
DelegateWithArgs(
this,
this.StartCmd,
{}
),
PPTAnimationEngine.CmdControl
);
}
PPTAnimationEngine.prototype.Pause = function()
{
this.AddCmd(
DelegateWithArgs(
this,
this.PauseCmd,
{}
),
PPTAnimationEngine.CmdControl
);
}
PPTAnimationEngine.prototype.PrevAnimation = function( state )
{
this.AddCmd(
DelegateWithArgs(
this,
this.PrevAnimationCmd,
{"state":state}
),
PPTAnimationEngine.PrevNext
);
}
PPTAnimationEngine.prototype.StepAnimation = function( state )
{
this.AddCmd(
DelegateWithArgs(
this,
this.StepAnimationCmd,
{"state":state}
),
PPTAnimationEngine.PrevNext
);
}
PPTAnimationEngine.prototype.FinishCurrentAnimation = function( state )
{
this.AddCmd(
DelegateWithArgs(
this,
this.FinishCurrentAnimationCmd,
{"state":state}
),
PPTAnimationEngine.PrevNext
);
}
PPTAnimationEngine.prototype.FinishCurrentAnimationCmd = function( state )
{
var SlideFrame = this._slideFrame;
SlideFrame.document.body.pptNext();
SlideFrame.document.body.pptPrev();
if ( state == MeetingSettings.MeetingState.Playing )
{
SlideFrame.document.body.resume();
}
}
PPTAnimationEngine.prototype.SetPositionCmd = function ( arg )
{
var pos = arg.pos;
var state = arg.state;
var isSeek = arg.isSeek;
var SlideFrame = this._slideFrame;
Trace.WriteLine("+-slide.document.body.pause();--");
var tmOriginal = new Date();
SlideFrame.document.body.pause();
var tmForPause = 0.001 * (new Date() - tmOriginal);
var tmForSet = pos + tmForPause;
Trace.WriteLine("+-slide.document.body.localTime="+ tmForSet + ";--");
SlideFrame.document.body.localTime = tmForSet;
if ( state == MeetingSettings.MeetingState.Playing )
{
Trace.WriteLine("+-slide.document.body.resume(); --");
SlideFrame.document.body.resume();
}
this._lastUpdatedTime = pos;
}
PPTAnimationEngine.prototype.PlayCmd = function()
{
var SlideFrame = this._slideFrame;
Trace.WriteLine("+-slide.document.body.resume();--");
SlideFrame.document.body.resume();
}
PPTAnimationEngine.prototype.StartCmd = function()
{
var SlideFrame = this._slideFrame;
Trace.WriteLine("--slide.document.body.start();--");
SlideFrame.document.body.start();
}
PPTAnimationEngine.prototype.PauseCmd = function()
{
var SlideFrame = this._slideFrame;
Trace.WriteLine("+-slide.document.body.pause();--");
SlideFrame.document.body.pause();
}
PPTAnimationEngine.prototype.PrevAnimationCmd = function( arg )
{
var state = arg.state;
var SlideFrame = this._slideFrame;
Trace.WriteLine("--slide.document.body.pptPrev();--");
SlideFrame.document.body.pptPrev();
Trace.WriteLine("--slide.document.body.resume();--");
SlideFrame.document.body.resume();
Trace.WriteLine("--slide.document.body.pptPrev();--");
SlideFrame.document.body.pptPrev();
Trace.WriteLine("--slide.document.body.resume();--");
SlideFrame.document.body.resume();
Trace.WriteLine("--slide.document.body.pptNext();--");
SlideFrame.document.body.pptNext();
Trace.WriteLine("--slide.document.body.resume();--");
SlideFrame.document.body.resume();
if ( state != MeetingSettings.MeetingState.Playing  )
{
Trace.WriteLine("--slide.document.body.pause();--");
SlideFrame.document.body.pause();
}
}
PPTAnimationEngine.prototype.StepAnimationCmd = function( arg )
{
var state = arg.state;
var SlideFrame = this._slideFrame;
Trace.WriteLine("--slide.document.body.pptNext();--");
SlideFrame.document.body.pptNext();
Trace.WriteLine("+-slide.document.body.resume();--");
SlideFrame.document.body.resume();
if ( state != MeetingSettings.MeetingState.Playing  )
{
Trace.WriteLine("+-slide.document.body.pause();--");
SlideFrame.document.body.pause();
}
}
PPTAnimationEngine.prototype.ProcessCmdQueue = function( arg )
{
var cmdFailed = false;
var retryCount = arg.retryCount;
if ( this._slideFrame )
{
while( this._cmdQueue.length > 0 )
{
if (( this._cmdQueue.length > 1 )
&&( this._cmdQueue[0]._CMDTYPE == PPTAnimationEngine.CmdSetPosition )
&&( this._cmdQueue[1]._CMDTYPE == PPTAnimationEngine.CmdSetPosition ))
{
this._cmdQueue = this._cmdQueue.slice( 1 );
retryCount = 0;
continue;
}
try
{
this._cmdQueue[0]( );
this._cmdQueue = this._cmdQueue.slice( 1 );
retryCount = 0;
}
catch( e )
{
retryCount ++;
cmdFailed = true;
Trace.WriteError( e );
break;
}
}
}
if ( retryCount > 10 )
{
this._cmdQueue = this._cmdQueue.slice( 1 );
retryCount = 0;
}
if( this._cmdQueue.length > 0 )
{
this._cmdQueuetimerHandler = setTimeout( DelegateWithArgs( this, this.ProcessCmdQueue, {"retryCount":retryCount} ), 50 );
}
else
{
this._cmdQueuetimerHandler = null;
}
}
PPTAnimationEngine.prototype.AddCmd = function( cmd, cmdType )
{
if ( !this._supportAnimation )
{
return;
}
cmd._CMDTYPE = cmdType;
this._cmdQueue.push( cmd );
if( this._cmdQueuetimerHandler == null )
{
this._cmdQueuetimerHandler = setTimeout( DelegateWithArgs( this, this.ProcessCmdQueue, {"retryCount":0} ), 0 );
}
}
PPTAnimationEngine.prototype.Reset = function( )
{
this._lastUpdatedTime = 0;
this._cmdQueue = [];
this._supportAnimation = true;
}
PPTAnimationEngine.prototype.SetSlideFrame = function( slideObj )
{
this._slideFrame = slideObj;
var supportAnim = false;
if ( this._slideFrame && this._slideFrame.document && this._slideFrame.document.body )
{
supportAnim = (typeof(this._slideFrame.document.body.localTime) != 'undefined' );
}
this._supportAnimation = supportAnim;
if (!this._supportAnimation)
{
this._cmdQueue = [];
}
}
Trace.Wrap( "PPTAnimationEngine" );
function PPTHTMLRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._rate           = 1.0;
this._animationEngine     = new PPTAnimationEngine();
this._Created.Add( Delegate( this, PPTHTMLRenderer.prototype.Created ) );
this._AfterLoadedEvent.Add( Delegate( this, PPTHTMLRenderer.prototype._IFrameLoadedHandler ) );
this._BeforeUnloadEvent.Add( Delegate( this, PPTHTMLRenderer.prototype._BeforeIFrameUnloadHandler ) );
this._Destroyed.Add( Delegate( this, PPTHTMLRenderer.prototype._WidgetDestroyed ) );
}
OOP.Inherit( PPTHTMLRenderer, HTMLWidget );
OOP.Inherit( PPTHTMLRenderer, RenderingSession );
PPTHTMLRenderer.prototype._WidgetDestroyed = function()
{
this._animationEngine.SetSlideFrame( null );
}
PPTHTMLRenderer.prototype.Initialize = function()
{
this._animationEngine.Initialize();
}
PPTHTMLRenderer.prototype.Uninitialize = function()
{
this._animationEngine.Uninitialize();
}
PPTHTMLRenderer.prototype.GetRelativePosition = function()
{
return this._animationEngine.GetRelativePosition();
}
PPTHTMLRenderer.prototype.SetPosition = function( posInPage, state, isSeek )
{
this._animationEngine.SetPosition( posInPage - 0, state, isSeek );
}
PPTHTMLRenderer.prototype.Play = function()
{
this._animationEngine.Play();
}
PPTHTMLRenderer.prototype.Start = function()
{
this._animationEngine.Start();
}
PPTHTMLRenderer.prototype.Pause = function()
{
this._animationEngine.Pause();
}
PPTHTMLRenderer.prototype.PrevAnimation = function( state )
{
this._animationEngine.PrevAnimation( state );
}
PPTHTMLRenderer.prototype.StepAnimation = function( state )
{
this._animationEngine.StepAnimation( state );
}
PPTHTMLRenderer.prototype.FinishCurrentAnimation = function( state )
{
this._animationEngine.FinishCurrentAnimation( state );
}
PPTHTMLRenderer.prototype.SetRate = function( rate )
{
this._rate = rate;
this._animationEngine.Rate = rate;
}
PPTHTMLRenderer.prototype.GetRate = function()
{
return this._rate;
}
PPTHTMLRenderer.prototype.Created = function()
{
}
PPTHTMLRenderer.prototype._IFrameLoadedHandler = function()
{
this.AllowTransparency( true );
this._animationEngine.SetSlideFrame( this._iframe.contentWindow );
}
PPTHTMLRenderer.prototype._BeforeIFrameUnloadHandler = function()
{
this._animationEngine.Uninitialize();
this._animationEngine.SetSlideFrame( null );
}
Trace.Wrap( "PPTHTMLRenderer" );
function MmcRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._widgets = new Object();
this._widgetWrappers = new Object();
this._defaultClip = false;
this._currentWidget = null;
this._currentWidgetWrapper = null;
this.clippedWidgetIsCreated = false;
this._Created.Add( Delegate( this, MmcRenderer.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, MmcRenderer.prototype._WidgetResized ) );
}
OOP.Inherit( MmcRenderer, BasicWidget );
OOP.Inherit( MmcRenderer, RenderingSession );
MmcRenderer.defaultBlankPageUri = "MmcRenderer.htm";
MmcRenderer.prototype._WidgetCreated = function()
{
var wmvClipWidget = new ClipWidget();
var wmvClipWidgetId = this._GetWrapperId( UISettings.mmcWmvWidgetId );
wmvClipWidget.clippedWidgetCreatedEvent.Add( Delegate( this,MmcRenderer.prototype._ClippedWidgetCreatedHandler ) );
wmvClipWidget.SetIFrameSrc( MmcRenderer.defaultBlankPageUri );
wmvClipWidget.Create( this,  wmvClipWidgetId );
wmvClipWidget.EnableClip( this._defaultClip );
wmvClipWidget.SetStyle( "visibility", "hidden" );
this._widgetWrappers[ wmvClipWidgetId ] = wmvClipWidget;
var wmvWidget = new WmvWidget();
wmvWidget.SetDefaultOriginalSize( 640, 480 );
wmvWidget.SetAutoStart( false );
wmvClipWidget.CreateClippedWidget( wmvWidget, UISettings.mmcWmvWidgetId );
this._widgets[ UISettings.mmcWmvWidgetId ] = wmvWidget;
wmvWidget.errorEvent.Add(
Delegate( this, MmcRenderer.prototype._WmvErrorOccured ) );
wmvWidget.infoEvent.Add(
Delegate( this, MmcRenderer.prototype._WmvInfoSent ) );
wmvWidget.playStateChangedEvent.Add(
Delegate( this, MmcRenderer.prototype._WmvPlayStateChanged ) );
var flashWidget = new FlashWidget();
flashWidget.SetMMObjectFlag( NavigatorInfo.FlashEnabled() );
flashWidget.Create(this, UISettings.mmcFlashWidgetId );
flashWidget.SetStyle( "visibility", "hidden" );
this._widgets[ UISettings.mmcFlashWidgetId ] = flashWidget;
this._widgetWrappers[ this._GetWrapperId( UISettings.mmcFlashWidgetId ) ] = flashWidget;
flashWidget.infoEvent.Add(
Delegate( this, MmcRenderer.prototype._FlashInfoSent ) );
this.SetActiveWidget( UISettings.mmcWmvWidgetId );
}
MmcRenderer.prototype._ClippedWidgetCreatedHandler = function()
{
this.clippedWidgetIsCreated = true;
this.GetWidget(UISettings.mmcWmvWidgetId).CheckEnabled();
}
MmcRenderer.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
for( var widgetId in this._widgetWrappers )
{
var widget = this._widgetWrappers[ widgetId ];
widget.SetUIPosition(
true,
0,
0,
clientWidth,
clientHeight );
}
}
MmcRenderer.prototype.GetWidget = function( widgetId )
{
return this._widgets[ widgetId ];
}
MmcRenderer.prototype.GetWidgetWrapper = function( widgetId )
{
var widgetWrapperId = this._GetWrapperId( widgetId );
return this._widgetWrappers[ widgetWrapperId ];
}
MmcRenderer.prototype._GetWrapperId = function( widgetId )
{
return widgetId + "_Wrapper";
}
MmcRenderer.prototype.SetActiveWidget = function( widgetId )
{
var widget = this.GetWidget( widgetId );
if( widget == null )
{
return;
}
var widgetWrapper = this.GetWidgetWrapper( widgetId );
if( widgetWrapper != this._currentWidgetWrapper )
{
if( this._currentWidgetWrapper )
{
this._currentWidgetWrapper.SetStyle( "visibility", "hidden" );
}
widgetWrapper.SetStyle( "visibility", "" );
this._currentWidget = widget;
this._currentWidgetWrapper = widgetWrapper;
}
}
MmcRenderer.prototype.SetClipRect = function( left, top, width, height )
{
if( typeof( this._currentWidgetWrapper.SetClipRect ) != "function" )
{
return;
}
if( width >= 0 && height >= 0 )
{
this._currentWidgetWrapper.SetClipRect( left, top, width, height );
}
else
{
this._currentWidgetWrapper.SetClipRect(
left,
top,
this._currentWidget._defaultOriginalWidth,
this._currentWidget._defaultOriginalHeight );
}
}
MmcRenderer.prototype.EnableInteraction = function( isEnable, forceUpdate )
{
if( typeof( this._currentWidget.EnableInteraction ) == "function" )
{
if( !( this._currentWidgetWrapper === this._currentWidget ) && this._defaultClip )
{
this._currentWidgetWrapper.EnableClip( !isEnable );
}
this._currentWidget.EnableInteraction( isEnable, forceUpdate );
}
}
MmcRenderer.prototype.IsInteractionEnabled = function()
{
if( typeof( this._currentWidget.IsInteractionEnabled ) == "function" )
{
return this._currentWidget.IsInteractionEnabled();
}
else
{
return false;
}
}
MmcRenderer.prototype._WmvPlayStateChanged = function()
{
var wmvWidget = this.GetWidget(UISettings.mmcWmvWidgetId);
if( wmvWidget._innerState == WmvWidget.playState.Playing )
{
this.ResetSession();
}
}
MmcRenderer.prototype._WmvErrorOccured = function( errorCode, errorDescription )
{
this.SetInformation(
GradedInfo.grades.error,
WmvErrorHandler.GetErrorString( errorCode, errorDescription )
);
}
MmcRenderer.prototype._WmvInfoSent = function( errorCode, errorDescription )
{
this.SetInformation(
GradedInfo.grades.information,
WmvErrorHandler.GetErrorString( errorCode, errorDescription ) );
}
MmcRenderer.prototype._FlashInfoSent = function( errorCode, errorDescription )
{
this.SetInformation(
GradedInfo.grades.information,
WmvErrorHandler.GetErrorString( errorCode, errorDescription ) );
}
MmcRenderer.prototype.Reset = function()
{
if( this._currentWidget && this._currentWidget.Reset )
{
this._currentWidget.Reset();
}
}
Trace.Wrap( "MmcRenderer" );
function WhiteboardRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._Created.Add( Delegate( this, WhiteboardRenderer.prototype._WidgetCreated ) );
}
OOP.Inherit( WhiteboardRenderer, BasicWidget );
OOP.Inherit( WhiteboardRenderer, RenderingSession );
WhiteboardRenderer.prototype._WidgetCreated = function()
{
this.SetStyle( "backgroundColor", "#ffffff" );
}
function ASImageRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._text = new TextWidget();
this._bottomRightImage = new ImageWidget();
this._textFitter = new WidgetFitter();
this._imageFitter = new WidgetFitter();
this._Created.Add( Delegate( this, ASImageRenderer.prototype._WidgetCreated ) );
}
OOP.Inherit( ASImageRenderer, BasicWidget );
ASImageRenderer.prototype._WidgetCreated = function()
{
this._bottomRightImage.Create( this, UISettings.asBottomRightImageId );
this._text.Create( this, UISettings.asContentStaticTextId );
this._bottomRightImage.SetURI( uiSettings.GetImage( "dataAreaBottomRight" ) );
this._text.SetText( LocaleInfo.GetText( UISettings.asStaticContentText ) );
this._text.EnableMultipleLines( false );
var textHeight = this._text.GetLinesHeight( 1 );
var textWidth = this._text.TestTextWidth( textHeight );
this._text.SetOriginalSize( textWidth, textHeight );
this._textFitter.Bind( this, this._text, "center" );
this._imageFitter.Bind( this, this._bottomRightImage, "BottomRight" );
}
function ASRenderer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._widgets = new Object();
this._widgetWrappers = new Object();
this._currentWidget = null;
this._currentWidgetWrapper = null;
this.clippedWidgetIsCreated = false;
this._Created.Add( Delegate( this, ASRenderer.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, ASRenderer.prototype._WidgetResized ) );
}
OOP.Inherit( ASRenderer, BasicWidget );
OOP.Inherit( ASRenderer, RenderingSession );
ASRenderer.defaultBlankPageUri = "ASRenderer.htm";
ASRenderer.prototype._WidgetCreated = function()
{
var wmvWidgetId = UISettings.asWmvWidgetId;
var wmvClipWidget = new ClipWidget();
var wmvClipWidgetId = this._GetWrapperId( wmvWidgetId );
wmvClipWidget.clippedWidgetCreatedEvent.Add( Delegate( this,ASRenderer.prototype._ClippedWidgetCreatedHandler ) );
wmvClipWidget.SetIFrameSrc( ASRenderer.defaultBlankPageUri );
wmvClipWidget.Create( this,  wmvClipWidgetId );
wmvClipWidget.SetStyle( "visibility", "hidden" );
this._widgetWrappers[ wmvClipWidgetId ] = wmvClipWidget;
var wmvWidget = new WmvWidget();
wmvWidget.SetDefaultOriginalSize( 640, 480 );
wmvClipWidget.CreateClippedWidget( wmvWidget, wmvWidgetId );
this._widgets[ wmvWidgetId ] = wmvWidget;
wmvWidget.errorEvent.Add(
Delegate( this, ASRenderer.prototype._WmvErrorOccured ) );
wmvWidget.infoEvent.Add(
Delegate( this, ASRenderer.prototype._WmvInfoSent ) );
wmvWidget.playStateChangedEvent.Add(
Delegate( this, ASRenderer.prototype._WmvPlayStateChanged ) );
wmvWidget.showCodecMissingEvent.Add(
Delegate( this, ASRenderer.prototype._ShowCodecMissingMessage ) );
var imageWidgetId = UISettings.asImageWidgetId;
var imageWidget = new ASImageRenderer();
imageWidget.Create(this, imageWidgetId );
imageWidget.SetStyle( "visibility", "hidden" );
this._widgets[ imageWidgetId ] = imageWidget;
this._widgetWrappers[ this._GetWrapperId( imageWidgetId ) ] = imageWidget;
this.SetActiveWidget( UISettings.asImageWidgetId );
}
ASRenderer.prototype._ClippedWidgetCreatedHandler = function()
{
this.clippedWidgetIsCreated = true;
this.GetWidget(UISettings.asWmvWidgetId).CheckEnabled();
if( !this.CanPlayASWmv() )
{
}
}
ASRenderer.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
for( var widgetId in this._widgetWrappers )
{
var widget = this._widgetWrappers[ widgetId ];
widget.SetUIPosition(
true,
0,
0,
clientWidth,
clientHeight );
}
}
ASRenderer.prototype.GetWidget = function( widgetId )
{
return this._widgets[ widgetId ];
}
ASRenderer.prototype.GetWidgetWrapper = function( widgetId )
{
var widgetWrapperId = this._GetWrapperId( widgetId );
return this._widgetWrappers[ widgetWrapperId ];
}
ASRenderer.prototype._GetWrapperId = function( widgetId )
{
return widgetId + "_Wrapper";
}
ASRenderer.prototype.SetActiveWidget = function( widgetId )
{
var widget = this.GetWidget( widgetId );
if( widget == null )
{
return;
}
var widgetWrapper = this.GetWidgetWrapper( widgetId );
if( widgetWrapper != this._currentWidgetWrapper )
{
if( this._currentWidgetWrapper )
{
this._currentWidgetWrapper.SetStyle( "visibility", "hidden" );
}
widgetWrapper.SetStyle( "visibility", "" );
this._currentWidget = widget;
this._currentWidgetWrapper = widgetWrapper;
}
}
ASRenderer.prototype.SetClipRect = function( left, top, width, height )
{
if( typeof( this._currentWidgetWrapper.SetClipRect ) != "function" )
{
return;
}
if( width >= 0 && height >= 0 )
{
this._currentWidgetWrapper.SetClipRect( left, top, width, height );
}
else
{
this._currentWidgetWrapper.SetClipRect(
left,
top,
this._currentWidget._defaultOriginalWidth,
this._currentWidget._defaultOriginalHeight );
}
}
ASRenderer.prototype.EnableInteraction = function( isEnable, forceUpdate )
{
if( typeof( this._currentWidget.EnableInteraction ) == "function" )
{
this._currentWidget.EnableInteraction( isEnable, forceUpdate );
}
}
ASRenderer.prototype.IsInteractionEnabled = function()
{
if( typeof( this._currentWidget.IsInteractionEnabled ) == "function" )
{
return this._currentWidget.IsInteractionEnabled();
}
else
{
return false;
}
}
ASRenderer.prototype._WmvPlayStateChanged = function()
{
var wmvWidget = this.GetWidget(UISettings.asWmvWidgetId);
if( wmvWidget._innerState == WmvWidget.playState.Playing )
{
this.ResetSession();
}
}
ASRenderer.prototype._WmvErrorOccured = function(errorCode, errorDescription)
{
var wmvWidget = this.GetWidget(UISettings.asWmvWidgetId);
if (wmvWidget._IsCodecMissing())
{
return;
}
if (errorCode == 0xc00d11c8)
{
this._ShowCodecMissingMessage();
}
else
{
var infoText = WmvErrorHandler.GetErrorString(errorCode, errorDescription);
this.SetInformation(
GradedInfo.grades.error,
infoText
);
}
}
ASRenderer.prototype._WmvInfoSent = function( errorCode, errorDescription)
{
this.SetInformation(
GradedInfo.grades.information,
WmvErrorHandler.GetErrorString( errorCode, errorDescription )
);
}
ASRenderer.prototype._WmvShowCodecMissing = function()
{
this._ShowCodecMissingMessage();
}
ASRenderer.prototype._ShowCodecMissingMessage = function()
{
var infoText = LocaleInfo.GetText( UISettings.WmvError_Msa1CodecRequired_InfoText);
var downloadFormatText = LocaleInfo.GetText( UISettings.WmvError_Msa1CodecRequired_DownloadFormatText );
var downloadArgText = LocaleInfo.GetText( UISettings.WmvError_Msa1CodecRequired_DownloadArgText );
var downloadArgUrl = "http://go.microsoft.com/fwlink/?LinkId=160545";
this.SetInformation(
GradedInfo.grades.error,
infoText,
downloadFormatText,
downloadArgText,
downloadArgUrl);
}
ASRenderer.prototype.CanPlayASWmv= function()
{
if( NavigatorInfo.IsSafari() )
{
return false;
}
else
{
return true;
}
}
ASRenderer.prototype.Reset = function()
{
if( this._currentWidget && this._currentWidget.Reset )
{
this._currentWidget.Reset();
}
}
Trace.Wrap( "ASRenderer" );
function ContentIndexListItem()
{
OOP.CallParentConstructor( this, arguments.callee );
this.KeyDownEvent = new Event();
this._titleObject = new TextWidget();
this._timeObject = new TextWidget();
this._thumbnailBorder = new BasicWidget();
this._thumbnailObject = new ImageWidget();
this._thumbnailFitter = new WidgetFitter();
this._Created.Add( Delegate( this, ContentIndexListItem.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, ContentIndexListItem.prototype._WidgetResized ) );
this._Destroyed.Add( Delegate( this, ContentIndexListItem.prototype._WidgetDestroyed ) );
}
OOP.Inherit( ContentIndexListItem, BasicWidget );
ContentIndexListItem.prototype._WidgetCreated = function()
{
this._thumbnailBorder.Create( this );
this._thumbnailObject.Create( this._thumbnailBorder );
this._titleObject.Create( this );
this._timeObject.Create( this );
this._titleObject.EnableMultipleLines( false );
this._thumbnailBorder.SetBorder( "solid", 1, 1, 1, 1 );
this._thumbnailBorder.SetStyle( "borderColor", "#000000" );
this._thumbnailBorder.SetStyle( "backgroundColor", "#ffffff" );
this._thumbnailFitter.Bind(
this._thumbnailBorder,
this._thumbnailObject,
"proportional" );
this.RegisterEvent( "onkeydown", Delegate( this, this._OnKeyDown ) );
}
ContentIndexListItem.prototype._WidgetDestroyed = function()
{
}
ContentIndexListItem.prototype._WidgetResized = function()
{
var clientWidth = this.GetWidth();
var clientHeight = UISettings.contentListItemHeight;
var fontHeight = this._titleObject.GetLinesHeight( 1 );
var paddingLeft = UISettings.contentListItemPaddingLeft;
var paddingRight = UISettings.contentListItemPaddingRight;
var paddingTop = UISettings.contentListItemPaddingTop;
var timeMarginLeft = UISettings.contentListItemTimeMarginLeft;
var titleMarginTop = UISettings.contentListItemTitleMarginTop;
var imageLeft = paddingLeft;
var imageTop = paddingTop;
var imageWidth = UISettings.contentListItemImageWidth;
var imageHeight = UISettings.contentListItemImageHeight;
var timeLeft = imageLeft + imageWidth + timeMarginLeft;
var timeWidth = clientWidth - timeLeft;
var timeHeight = fontHeight;
var timeTop = paddingTop;
if( timeWidth < 0 )
{
Trace.WriteLine( "The list width is too small for time. " );
return;
}
var titleLeft = paddingLeft;
var titleTop = imageTop + imageHeight + titleMarginTop;
var titleHeight = fontHeight;
var titleWidth = clientWidth - paddingLeft - paddingRight;
if( titleWidth < 0 )
{
Trace.WriteLine( "The title width is less than 0. " );
return;
}
this._titleObject.SetUIPosition(
true,
titleLeft,
titleTop,
titleWidth,
titleHeight );
this._timeObject.SetUIPosition(
true,
timeLeft,
timeTop,
timeWidth,
timeHeight );
this._thumbnailBorder.SetUIPosition(
true,
imageLeft,
imageTop,
imageWidth,
imageHeight );
this.SetSize( clientWidth, clientHeight, true );
}
ContentIndexListItem.prototype.SetContentInfo = function( title, time, thumbnailUri )
{
Trace.WriteLine(
"The title is %1, the time is %2, the thumbnail uri is %3. ",
title,
time,
thumbnailUri );
this._titleObject.SetText( title );
this._titleObject.SetAttribute( "title", title );
time = TimeFormat.GetTimeString( time );
this._timeObject.SetText( time );
this._thumbnailObject.SetURI( thumbnailUri );
}
ContentIndexListItem.prototype._OnKeyDown = function( eventObj )
{
eventObj = BasicWidget.TranslateEvent( eventObj, this._htmlObject  );
var theKey = BasicWidget.GetKey( eventObj );
this.KeyDownEvent( eventObj );
if( theKey == KeyTable.VK_UP || theKey == KeyTable.VK_DOWN || theKey == KeyTable.VK_SPACE )
{
return false;
}
}
Trace.Wrap( "ContentIndexListItem" );
function ContentIndexList()
{
OOP.CallParentConstructor( this, arguments.callee );
this._focusIndex = -1;
this._tabIndex = 0;
this._changeToHighlight = true;
this._setFocus = false;
this.SetItemClassName(
"normal",
UISettings.contentIndexNormalItemClassName );
this.SetItemClassName(
"highlighted",
UISettings.contentIndexHighlightedItemClassName );
this.SetItemClassName(
"seperator",
UISettings.contentIndexSeperatorClassName );
this._Created.Add( Delegate( this, ContentIndexList.prototype._WidgetCreated ) );
}
OOP.Inherit( ContentIndexList, ListWidget );
ContentIndexList.prototype._WidgetCreated = function()
{
this.SetTabIndex( UISettings.tabIndexDisable );
}
ContentIndexList.prototype._AddDisplayItem = function( index )
{
var text = this._listData[ index ].title;
var time = this._listData[ index ].time;
var thumbnailUri = this._listData[ index ].thumbnailUri;
if( typeof( time ) != "number" )
{
Trace.WriteWarning( "The time should be a number. " );
}
if( this.GetItemCount() > 0 )
{
var seperator = new BasicWidget();
this.AddSeperator( seperator );
}
var uiItem = new ContentIndexListItem();
this.AddItem( uiItem );
uiItem.KeyDownEvent.Add( Delegate( this, this._OnKeyDown ) );
uiItem.RegisterEvent( "onfocus", DelegateWithArgs(this, this._Focus,true));
uiItem.RegisterEvent( "onblur", DelegateWithArgs(this, this._Focus, false));
uiItem.SetContentInfo( text, time, thumbnailUri );
var clientWidth = this.GetClientWidth();
if( clientWidth != this._oldClientWidth )
{
this._ResizeAllItems( clientWidth );
}
if(this._focusIndex == -1)
{
this._ChangeFocusIndex( 0 );
}
}
ContentIndexList.prototype._Focus = function ( enable )
{
this._setFocus = enable;
if( !enable )
{
if( this._changeToHighlight )
{
this._ChangeFocusIndex( this._activeIndex );
}
else
{
this._changeToHighlight = true;
}
}
}
ContentIndexList.prototype._ChangeFocusIndex = function( index )
{
if(this._focusIndex > -1 && this._focusIndex < this._itemArray.length)
{
this._itemArray[this._focusIndex].SetTabIndex( UISettings.tabIndexDisable );
}
if( this._itemArray.length == 0 )
{
index = -1;
}
else if( index >= this._itemArray.length )
{
index = 0;
}
if( index >=0 )
{
this._itemArray[ index ].SetTabIndex( this._tabIndex );
}
this._focusIndex = index;
}
ContentIndexList.prototype._FocusItem = function()
{
if(this._focusIndex != -1)
{
this.ScrollToItem(this._focusIndex);
this._itemArray[this._focusIndex].SetFocus();
}
}
ContentIndexList.prototype._OnKeyDown = function( eventObj )
{
var theKey = BasicWidget.GetKey( eventObj );
if(this._focusIndex != -1)
{
var index = -1;
switch(theKey)
{
case KeyTable.VK_SPACE:
case KeyTable.VK_RETURN:
this.SelectSingleItem( this._focusIndex );
this.ScrollToItem(this._focusIndex);
break;
case KeyTable.VK_UP:
if((this._focusIndex-1)>=0)
{
index = this._focusIndex - 1;
}
else
{
index = 0;
}
this._changeToHighlight = false;
this._ChangeFocusIndex( index );
this._FocusItem();
break;
case KeyTable.VK_DOWN:
if((this._focusIndex+1) < this._itemArray.length)
{
index = this._focusIndex + 1;
}
else
{
index = this._itemArray.length - 1;
}
this._changeToHighlight = false;
this._ChangeFocusIndex( index);
this._FocusItem();
break;
default:
break;
}
}
}
ContentIndexList.prototype.HighlightSingleItem = function( index )
{
ListWidget.prototype.HighlightSingleItem.call( this, index );
this._ChangeFocusIndex( this._activeIndex );
if( this._setFocus)
{
this._FocusItem();
}
}
ContentIndexList.prototype.GetIndexibleItemCount = function()
{
return this.GetItemCount();
}
ContentIndexList.prototype.SetContentItems = function( contentIndexList )
{
if( contentIndexList == null )
{
Trace.WriteLine( "There is no content index data" );
return;
}
var contentIndexCount = contentIndexList.length;
for( var i=0; i<contentIndexCount; i++ )
{
var item = contentIndexList[i];
if( item == null )
{
Trace.WriteLine( "There is no attributes of #%1 ContentChanged event. ", i );
continue;
}
this._listData[i] = {
"title":item.title,
"time":item.time,
"thumbnailUri":item.thumb };
}
this._AsyncAddNextItem( 0 );
}
Trace.Wrap( "ContentIndexList" );
function SpeakerItem()
{
OOP.CallParentConstructor( this, arguments.callee );
this.EnableEvent = new Event();
this.ExpandChangedEvent = new Event();
this._speakerId = null;
this._speakerIndex = -1;
this._nameItem = new SpeakerNameItem();
this._timeList = new BasicWidget();
this._totalTime = 0;
this._timeItemCount = 0;
this._Created.Add( Delegate( this, SpeakerItem.prototype._WidgetCreated ) );
this._Resized.Add( this._nameItem._Resized );
this._Resized.Add( this._timeList._Resized );
}
OOP.Inherit( SpeakerItem, BasicWidget );
SpeakerItem.prototype._WidgetCreated = function()
{
this._nameItem.Create( this );
this._timeList.Create( this );
this._nameItem.SetStyle( "position", "relative" );
this._timeList.SetStyle( "position", "relative" );
this._nameItem.SetStyle( "cursor", "default" );
this._timeList.SetStyle( "cursor", "default" );
this._nameItem.Active( false );
this._timeList.SetAttribute( "className", UISettings.speakerIndexTimeListClassName );
this.SetAttribute( "className", UISettings.speakerIndexItemClassName );
this._nameItem.ExpandEvent.Add( Delegate( this, SpeakerItem.prototype._OnExpand ) );
this._nameItem.EnableEvent.Add( this.EnableEvent );
this.Expand( false );
}
SpeakerItem.prototype.Expand = function( enable )
{
this._timeList.SetStyle( "display", enable ? "block" : "none" );
this._nameItem.SetMinusImage( enable );
this.ExpandChangedEvent();
}
SpeakerItem.prototype._OnExpand = function( expand )
{
this.Expand( expand );
}
SpeakerItem.prototype.SetName = function( name )
{
this._nameItem.SetName( name );
}
SpeakerItem.prototype.AddTimeItem = function( startTime, stopTime )
{
var timeItem = new SpeakerTimeItem();
timeItem.Create( this._timeList );
timeItem.SetStyle( "position", "relative" );
timeItem.Active( false );
timeItem.SetTime( startTime, stopTime );
this._timeItemCount += 1;
this._totalTime += ( stopTime - startTime );
this._nameItem.UpdateTimeInfo( this._timeItemCount, this._totalTime );
return timeItem;
}
SpeakerItem.prototype.GetNameItem = function()
{
return this._nameItem;
}
SpeakerItem.prototype.GetExpand = function ()
{
return this._timeList.GetStyle( "display" ) == "block" ;
}
function SpeakerNameItem()
{
OOP.CallParentConstructor( this, arguments.callee );
this.EnableEvent = new Event();
this.ExpandEvent = new Event();
this.KeyDownEvent = new Event();
this.ClickEvent = new Event();
this.speakerItem = null;
this.timeIndex = null;
this._expanded = false;
this._table = new TableWidget();
this._checkBox = new CheckWidget();
this._expandBox = new ButtonBarWidget();
this._nameText = new TextWidget();
this._countText = new TextWidget();
this._timeText = new TextWidget();
this._checkBoxWidth = UISettings.speakerIndexNameCheckBoxAreaWidth;
this._expandBoxWidth = UISettings.speakerIndexNameExpandBoxAreaWidth;
this._timeWidth = UISettings.speakerIndexNameTimeAreaWidth;
this._countWidth = UISettings.speakerIndexNameCountAreaWidth;
this._Created.Add( Delegate( this, SpeakerNameItem.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, SpeakerNameItem.prototype._WidgetResized ) );
this._Destroyed.Add( Delegate( this, SpeakerNameItem.prototype._WidgetDestroyed ) );
}
OOP.Inherit( SpeakerNameItem, BasicWidget );
SpeakerNameItem.prototype._WidgetCreated = function()
{
this.SetFocusDashedBorder();
this._table.Create( this );
var item = null;
item = this._table.AddCell( 0, 0, 1, 1 );
item.SetStyle( "width", this._checkBoxWidth );
this._checkBox.Create( item );
item = this._table.AddCell( 0, 0, 1, 1 );
item.SetStyle( "width", this._expandBoxWidth );
this._expandBox.Create( item );
item = this._table.AddCell( 0, 0, 1, 1 );
this._nameText.Create( item );
item = this._table.AddCell( 0, 0, 1, 1 );
item.SetStyle( "width", this._countWidth );
this._countText.Create( item );
item = this._table.AddCell( 0, 0, 1, 1 );
item.SetStyle( "width", this._timeWidth );
this._timeText.Create( item );
this._nameText.EnableMultipleLines( false );
this._countText.EnableMultipleLines( false );
this._timeText.EnableMultipleLines( false );
this._expandBox.SetUILayout( 1, 9, 9, 0 );
var plusImageName = uiSettings.GetImage( "speakerIndexPlus" );
var minusImageName = uiSettings.GetImage( "speakerIndexMinus" );
this._expandBox.AddButton(
UISettings.speakerIndexPlusId,
"",
plusImageName,
plusImageName,
plusImageName,
plusImageName );
this._expandBox.AddButton(
UISettings.speakerIndexMinusId,
"",
minusImageName,
minusImageName,
minusImageName,
minusImageName );
this._expandBox.SetSize( 9, 9 );
this._checkBox.SetStyle( "position", "relative" );
this._expandBox.SetStyle( "position", "relative" );
this._nameText.SetStyle( "position", "relative" );
this._countText.SetStyle( "position", "relative" );
this._timeText.SetStyle( "position", "relative" );
this._nameText.SetStyle( "cursor", "pointer" );
this._countText.SetStyle( "cursor", "pointer" );
this._timeText.SetStyle( "cursor", "pointer" );
this._checkBox.SetTabIndex( UISettings.tabIndexDisable );
this._expandBox.SetTabIndex( UISettings.tabIndexDisable );
var plusButton = this._expandBox.GetButton( UISettings.speakerIndexPlusId );
var minusButton = this._expandBox.GetButton( UISettings.speakerIndexMinusId );
plusButton.ClickEvent.Add( DelegateWithArgs( this, SpeakerNameItem.prototype._OnExpandClicked, true ) );
minusButton.ClickEvent.Add( DelegateWithArgs( this, SpeakerNameItem.prototype._OnExpandClicked, false ) );
this._checkBox.RegisterEvent( "onclick", Delegate( this, SpeakerNameItem.prototype._OnCheckBoxClicked ) );
this._nameText.RegisterEvent( "onclick", Delegate( this, SpeakerNameItem.prototype._OnClicked ) );
this._countText.RegisterEvent( "onclick", Delegate( this, SpeakerNameItem.prototype._OnClicked ) );
this._timeText.RegisterEvent( "onclick", Delegate( this, SpeakerNameItem.prototype._OnClicked ) );
this.RegisterEvent( "onkeydown", Delegate(this, this._OnKeyDown ) );
}
SpeakerNameItem.prototype._WidgetResized = function()
{
var width = this.GetClientWidth();
var height = this.GetClientHeight();
this._table.SetUIPosition(
true,
0,
0,
width,
height );
var checkBoxWidth = this._checkBoxWidth;
var expandBoxWidth = this._expandBoxWidth;
var textWidth = width -
this._checkBoxWidth - this._expandBoxWidth -
this._countWidth - this._timeWidth;
this._nameText.SetWidth( textWidth );
}
SpeakerNameItem.prototype._WidgetDestroyed = function()
{
}
SpeakerNameItem.prototype._OnCheckBoxClicked = function()
{
var checked = this._checkBox.GetAttribute( "checked" );
this.EnableEvent( checked );
this.ClickEvent(this.speakerItem);
}
SpeakerNameItem.prototype._OnExpandClicked = function( expand )
{
this.ExpandEvent( expand );
this._expanded = expand;
this.ClickEvent(this.speakerItem);
}
SpeakerNameItem.prototype._OnClicked = function()
{
var expand = !this._expanded;
this.ExpandEvent( expand );
this._expanded = expand;
this.ClickEvent(this.speakerItem);
}
SpeakerNameItem.prototype._OnKeyDown = function( eventObj )
{
eventObj = BasicWidget.TranslateEvent( eventObj, this._htmlObject );
var theKey = BasicWidget.GetKey( eventObj );
this.KeyDownEvent( eventObj );
if( (theKey >= KeyTable.VK_LEFT &&  theKey <= KeyTable.VK_DOWN) || theKey == KeyTable.VK_SPACE )
{
return false;
}
}
SpeakerNameItem.prototype.SetName = function( name )
{
this._nameText.SetText( name );
this._nameText.SetAttribute( "title", name );
}
SpeakerNameItem.prototype.UpdateTimeInfo = function( count, totalTime )
{
var countText = "(" + count + ")";
var timeText = TimeFormat.GetTimeString( totalTime );
this._countText.SetText( countText );
this._countText.SetAttribute( "title", countText );
this._timeText.SetText( timeText );
}
SpeakerNameItem.prototype.SetMinusImage = function( enable )
{
var enableId = ( enable ? UISettings.speakerIndexMinusId : UISettings.speakerIndexPlusId );
this._expandBox.ShowButton( enableId, 0 );
}
SpeakerNameItem.prototype.Active = function( enable )
{
var className = ( enable ?
UISettings.speakerIndexHighlightedNameClassName :
UISettings.speakerIndexNormalNameClassName );
this.SetAttribute( "className", className );
}
SpeakerNameItem.prototype.SetCheckState = function( check )
{
this._checkBox.SetAttribute( "checked", check );
}
SpeakerNameItem.prototype.EnableCheckBox = function( enable )
{
this._checkBox.SetAttribute( "disabled", !enable );
}
SpeakerNameItem.prototype.GetCheckState = function ( )
{
return this._checkBox.GetAttribute( "checked" );
}
SpeakerNameItem.prototype.GetTopInSpeakerItem = function()
{
var top = this._htmlObject.offsetTop;
return top;
}
function SpeakerTimeItem()
{
OOP.CallParentConstructor( this, arguments.callee );
this.ClickEvent = new Event();
this.KeyDownEvent = new Event();
this._Created.Add( Delegate( this, SpeakerTimeItem.prototype._WidgetCreated ) );
this._Destroyed.Add( Delegate( this, SpeakerTimeItem.prototype._WidgetDestroyed ) );
}
OOP.Inherit( SpeakerTimeItem, BasicWidget );
SpeakerTimeItem.prototype._WidgetCreated = function()
{
this.RegisterEvent( "onclick", this.ClickEvent );
this.RegisterEvent( "onkeydown", Delegate(this, this._OnKeyDown) );
this.SetStyle( "cursor", "pointer" );
}
SpeakerTimeItem.prototype._WidgetDestroyed = function()
{
}
SpeakerTimeItem.prototype.SetTime = function( startTime, stopTime )
{
this._htmlObject.innerHTML =
TimeFormat.GetTimeString( startTime ) + " - " +
TimeFormat.GetTimeString( stopTime );
}
SpeakerTimeItem.prototype.Active = function( enable )
{
var className = ( enable ?
UISettings.speakerIndexHighlightedTimeClassName :
UISettings.speakerIndexNormalTimeClassName );
this.SetAttribute( "className", className );
}
SpeakerTimeItem.prototype._OnKeyDown = function( eventObj )
{
eventObj = BasicWidget.TranslateEvent( eventObj, this._htmlObject );
var theKey = BasicWidget.GetKey( eventObj );
this.KeyDownEvent( eventObj );
if( (theKey >= KeyTable.VK_LEFT &&  theKey <= KeyTable.VK_DOWN) || theKey == KeyTable.VK_SPACE  )
{
return false;
}
}
SpeakerTimeItem.prototype.GetTopInSpeakerItem = function()
{
var top = this.speakerItem._timeList._htmlObject.offsetTop + this._htmlObject.offsetTop;
return top;
}
function SpeakerSelectAllItem()
{
OOP.CallParentConstructor( this, arguments.callee );
this.EnableEvent = new Event();
this.KeyDownEvent = new Event();
this.ClickEvent = new Event();
this._checkBox = new CheckWidget();
this._text = new TextWidget();
this._Created.Add( Delegate( this, SpeakerSelectAllItem.prototype._WidgetCreated ) );
this._Destroyed.Add( Delegate( this, SpeakerSelectAllItem.prototype._WidgetDestroyed ) );
}
OOP.Inherit( SpeakerSelectAllItem, BasicWidget );
SpeakerSelectAllItem.prototype._WidgetCreated = function()
{
this._checkBox.Create( this );
this._text.Create( this );
this._text.SetStyle( "display", "inline" );
this._text.SetStyle( "position", "" );
this._checkBox.SetTabIndex( UISettings.tabIndexDisable );
this._checkBox.RegisterEvent( "onclick", Delegate( this, SpeakerSelectAllItem.prototype._OnCheckBoxClicked ) );
this.RegisterEvent( "onkeydown", Delegate( this, this._OnKeyDown ) );
this.SetTabIndex(UISettings.tabIndexDisable);
}
SpeakerSelectAllItem.prototype._WidgetDestroyed = function()
{
}
SpeakerSelectAllItem.prototype._OnCheckBoxClicked = function()
{
var checked = this._checkBox.GetAttribute( "checked" );
this.EnableEvent( checked );
this.ClickEvent();
}
SpeakerSelectAllItem.prototype.SetText = function( text )
{
this._text.SetText( text );
}
SpeakerSelectAllItem.prototype.SetCheckState = function( check )
{
this._checkBox.SetAttribute( "checked", check );
}
SpeakerSelectAllItem.prototype.EnableCheckBox = function( enable )
{
this._checkBox.SetAttribute( "disabled", !enable );
}
SpeakerSelectAllItem.prototype.GetCheckState = function( )
{
return this._checkBox.GetAttribute( "checked" );
}
SpeakerSelectAllItem.prototype._OnKeyDown = function( eventObj )
{
eventObj = BasicWidget.TranslateEvent( eventObj, this._htmlObject );
var theKey = BasicWidget.GetKey( eventObj );
if( theKey == KeyTable.VK_RETURN || theKey == KeyTable.VK_SPACE )
{
this._OnCheckBoxClicked();
}
if( theKey == KeyTable.VK_SPACE )
{
return false;
}
}
function SpeakerIndexList()
{
OOP.CallParentConstructor( this, arguments.callee );
this.TimeItemSelectEvent = new Event();
this.EnableSpeakerEvent = new Event();
this.EnableAllSpeakersEvent = new Event();
this._selectAll = new SpeakerSelectAllItem();
this._deselectAll = new SpeakerSelectAllItem();
this._seperator = new BasicWidget();
this._speakers = new Object();
this._timeItems = new Array();
this._highlightedTimeIndex = null;
this._focusIndex = new Object();
this._focusIndex._speakerIndex = -2;
this._focusIndex._timeIndex = -1;
this._tabIndex = 0;
this._setFocus = false;
this._changeToHighlight = true;
this._speakersId = new Array();
this._allSelectionApplied = false;
this._allSelectionFlag = false;
this._Created.Add( Delegate( this, SpeakerIndexList.prototype._WidgetCreated ) );
}
OOP.Inherit( SpeakerIndexList, ListWidget );
SpeakerIndexList.prototype._WidgetCreated = function()
{
this._selectAll.Create( this, UISettings.speakerIndexSelectAllId );
this._deselectAll.Create( this, UISettings.speakerIndexDeselectAllId );
this._seperator.Create( this, UISettings.speakerIndexHeadSeperatorId );
this._selectAll.SetStyle( "position", "relative" );
this._deselectAll.SetStyle( "position", "relative" );
this._seperator.SetStyle( "position", "relative" );
this._selectAll.EnableEvent.Add( DelegateWithArgs( this, SpeakerIndexList.prototype._EnableAll, true ) );
this._deselectAll.EnableEvent.Add( DelegateWithArgs( this, SpeakerIndexList.prototype._EnableAll, false ) );
this._selectAll.SetText( LocaleInfo.GetText( UISettings.speakerIndexSelectAllTextId ) );
this._deselectAll.SetText( LocaleInfo.GetText( UISettings.speakerIndexDeselectAllTextId ) );
this.SetTabIndex(UISettings.tabIndexDisable);
}
SpeakerIndexList.prototype._EnableAll = function( enable )
{
this.EnableAllSpeakersEvent( enable );
}
SpeakerIndexList.prototype._AddDisplayItem = function( index )
{
var startTime = this._listData[index].startTime;
var stopTime = this._listData[index].stopTime;
var speakerId = this._listData[index].attendeeId;
var speakerName = this._listData[index].attendeeName;
if( typeof( time ) != "number" )
{
Trace.WriteWarning( "The time should be a number. " );
}
if( speakerId == null )
{
return;
}
var item = null;
if( speakerId in this._speakers )
{
item = this._speakers[ speakerId ];
}
else
{
item = new SpeakerItem();
this.AddItem( item );
item.SetName( speakerName );
item._speakerId = speakerId;
item.SetStyle( "position", "relative" );
var nameItem = item.GetNameItem();
nameItem.speakerItem = item;
item.EnableEvent.Add( DelegateWithArgs( null, this.EnableSpeakerEvent, speakerId ) );
nameItem.KeyDownEvent.Add( Delegate( this, this._OnKeyDown ) );
nameItem.ClickEvent.Add( Delegate( this, this._OnNameItemClicked ) );
item.ExpandChangedEvent.Add( Delegate( this, this._ItemExpandChanged ) );
nameItem.RegisterEvent( "onfocus", DelegateWithArgs( this, this._Focus, true ) );
nameItem.RegisterEvent( "onblur", DelegateWithArgs( this, this._Focus, false ) );
if( this._allSelectionApplied )
{
nameItem.SetCheckState( this._allSelectionFlag );
}
this._speakers[ speakerId ] = item;
this._speakersId.push( speakerId );
item._speakerIndex = this._speakersId.length -1;
}
var timeItem = item.AddTimeItem( startTime, stopTime );
timeItem.ClickEvent.Add(
DelegateWithArgs(
this,
SpeakerIndexList.prototype._OnTimeItemClicked,
index )
);
timeItem.KeyDownEvent.Add( Delegate( this, this._OnKeyDown ) );
timeItem.RegisterEvent( "onfocus",DelegateWithArgs(this, this._Focus,true) );
timeItem.RegisterEvent( "onblur",DelegateWithArgs(this,this._Focus,false) );
timeItem.speakerItem = item;
timeItem.timeIndex = index;
this._timeItems[ index ] = timeItem;
if(this._focusIndex._speakerIndex == -1)
{
this._ChangeFocusIndex(0,-1);
}
var clientWidth = this.GetClientWidth();
if( clientWidth != this._oldClientWidth )
{
this._ResizeAllItems( clientWidth );
}
}
SpeakerIndexList.prototype._ItemExpandChanged = function()
{
this.SetStyle( "visibility", "hidden" );
this.SetStyle( "visibility", "inherit" );
var clientWidth = this.GetClientWidth();
if( clientWidth != this._oldClientWidth )
{
this._ResizeAllItems( clientWidth );
}
}
SpeakerIndexList.prototype._OnTimeItemClicked = function( timeIndex )
{
this.TimeItemSelectEvent( timeIndex );
var speakerIndex = this._timeItems[timeIndex].speakerItem._speakerIndex;
var timeIndex = this.GetTimeArrayIndexByTimeIndex(this._timeItems[timeIndex].speakerItem, timeIndex);
this._ChangeFocusIndex( speakerIndex, timeIndex );
}
SpeakerIndexList.prototype._OnNameItemClicked = function( speakerItem )
{
var speakerIndex = speakerItem._speakerIndex;
var timeIndex = -1;
this._ChangeFocusIndex( speakerIndex, timeIndex );
this._FocusItem();
}
SpeakerIndexList.prototype.HighlightSingleTimeItem = function( timeIndex )
{
if( this._highlightedTimeIndex != null )
{
this._ActiveTimeItem( this._highlightedTimeIndex, false );
this._highlightedTimeIndex = null;
}
if( typeof( timeIndex ) != "number" ||
isNaN( timeIndex ) ||
timeIndex < 0 ||
timeIndex >= this._timeItems.length )
{
Trace.WriteLine( "The time index in SpeakerIndexList.ActiveTimeItem is not valid. " );
this._ChangeFocusIndexToHighlightItem();
return;
}
this._ActiveTimeItem( timeIndex, true );
this._highlightedTimeIndex = timeIndex;
this._ChangeFocusIndexToHighlightItem();
if( this._setFocus)
{
this._FocusItem();
}
}
SpeakerIndexList.prototype._ChangeFocusIndexToHighlightItem = function()
{
var speakerIndex = -1;
var timeIndex = -1;
if( this._highlightedTimeIndex == null )
{
if( this._speakersId.length >0)
{
speakerIndex = 0;
timeIndex = -1;
}
this._ChangeFocusIndex( speakerIndex, timeIndex );
return;
}
var highlightTimeItem = this._timeItems[this._highlightedTimeIndex];
if( highlightTimeItem == null )
{
if( this._speakersId.length >0)
{
speakerIndex = 0;
timeIndex = -1;
}
}
else
{
var speakerIndex = highlightTimeItem.speakerItem._speakerIndex;
var speakerId = this._speakersId[speakerIndex];
speakerItem = this._speakers[speakerId];
timeIndex = this.GetTimeArrayIndexByTimeIndex(speakerItem,this._highlightedTimeIndex);
}
this._ChangeFocusIndex( speakerIndex,timeIndex );
}
SpeakerIndexList.prototype._ActiveTimeItem = function( timeIndex, active )
{
var timeItem = this._timeItems[ timeIndex ];
if( timeItem == null )
{
return;
}
var nameItem = timeItem.speakerItem.GetNameItem();
nameItem.Active( active );
timeItem.Active( active );
}
SpeakerIndexList.prototype.EnableAllSpeakers = function( enabled, applyAll )
{
if ( applyAll )
{
for( var id in this._speakers )
{
var nameItem = this._speakers[ id ].GetNameItem();
nameItem.SetCheckState( enabled );
}
this._selectAll.EnableCheckBox( !enabled );
this._selectAll.SetCheckState( enabled );
this._deselectAll.EnableCheckBox( enabled );
this._deselectAll.SetCheckState( !enabled );
if( enabled )
{
this._selectAll.SetTabIndex( UISettings.tabIndexDisable );
this._deselectAll.SetTabIndex( this._tabIndex );
this._deselectAll.SetFocus();
}
else
{
this._selectAll.SetTabIndex( this._tabIndex );
this._deselectAll.SetTabIndex( UISettings.tabIndexDisable );
this._selectAll.SetFocus();
}
this._allSelectionFlag = enabled;
this._allSelectionApplied = true;
}
else
{
this._selectAll.EnableCheckBox( true );
this._deselectAll.EnableCheckBox( true );
this._selectAll.SetCheckState( false );
this._deselectAll.SetCheckState( false );
this._selectAll.SetTabIndex( this._tabIndex );
this._deselectAll.SetTabIndex( this._tabIndex );
}
}
SpeakerIndexList.prototype.EnableSpeaker = function( speakerId, enable )
{
if( speakerId == null )
{
return;
}
var nameItem = this._speakers[ speakerId ].GetNameItem();
nameItem.SetCheckState( enable );
}
SpeakerIndexList.prototype._FocusItem = function( )
{
if(this._focusIndex._speakerIndex == -1)
{
return;
}
var speakerIndex = this._focusIndex._speakerIndex;
var timeIndex = this._focusIndex._timeIndex;
var speakerId = this._speakersId[speakerIndex];
var speakerItem = this._speakers[speakerId];
var item = null;
if(timeIndex == -1)
{
item = speakerItem.GetNameItem();
}
else
{
item = speakerItem._timeList.ownedWidgets[ timeIndex ];
}
item.SetFocus();
}
SpeakerIndexList.prototype._OnKeyDownForLeft = function ()
{
if(this._focusIndex._speakerIndex == -1)
{
return;
}
var speakerIndex = this._focusIndex._speakerIndex;
var speakerId = this._speakersId[ speakerIndex ];
var speakerItem = this._speakers[ speakerId ];
this._changeToHighlight = false;
this._ChangeFocusIndex( speakerIndex, -1 );
speakerItem.Expand( false );
this._FocusItem();
}
SpeakerIndexList.prototype._OnKeyDownForRight = function ()
{
if(this._focusIndex._speakerIndex == -1)
{
return;
}
var speakerIndex = this._focusIndex._speakerIndex;
var speakerId = this._speakersId[ speakerIndex ];
var speakerItem = this._speakers[ speakerId ];
this._changeToHighlight = false;
if(!speakerItem.GetExpand())
{
this._ChangeFocusIndex( speakerIndex, -1);
speakerItem.Expand( true );
}
this._FocusItem();
}
SpeakerIndexList.prototype._OnKeyDownForEnterAndSpace = function ()
{
if(this._focusIndex._speakerIndex == -1)
{
return;
}
var speakerIndex = this._focusIndex._speakerIndex;
var speakerId = this._speakersId[ speakerIndex ];
var speakerItem = this._speakers[ speakerId ];
var timeIndex = this._focusIndex._timeIndex;
if(timeIndex == -1)
{
speakerItem.GetNameItem().SetCheckState(!speakerItem.GetNameItem().GetCheckState());
speakerItem.GetNameItem()._OnCheckBoxClicked();
this._FocusItem();
}
else
{
this._OnTimeItemClicked(speakerItem._timeList.ownedWidgets[timeIndex].timeIndex);
}
}
SpeakerIndexList.prototype._OnKeyDownForUp = function ()
{
if(this._focusIndex._speakerIndex == -1)
{
return;
}
var speakerIndex = this._focusIndex._speakerIndex;
var speakerId = this._speakersId[ speakerIndex ];
var timeIndex = this._focusIndex._timeIndex;
var lastTimeIndex = this._GetLastTimeIndex( speakerId, timeIndex );
switch( lastTimeIndex )
{
case -2:
if((this._focusIndex._speakerIndex -1 )>=0)
{
speakerIndex = this._focusIndex._speakerIndex - 1;
speakerId = this._speakersId[ speakerIndex ];
var speakerItem = this._speakers[speakerId];
if(speakerItem.GetExpand())
{
timeIndex = speakerItem._timeList.ownedWidgets.length -1;
}
else
{
timeIndex = -1;
}
}
else
{
speakerIndex = 0;
timeIndex = -1;
}
break;
case -1:
speakerIndex = this._focusIndex._speakerIndex;
timeIndex = -1;
break;
default:
speakerIndex = this._focusIndex._speakerIndex;
timeIndex = lastTimeIndex;
break;
}
this._changeToHighlight = false;
this._ChangeFocusIndex(speakerIndex,timeIndex);
this._FocusItem();
}
SpeakerIndexList.prototype._OnKeyDownForDown = function ()
{
if(this._focusIndex._speakerIndex == -1)
{
return;
}
var speakerIndex = -1;
var timeIndex = -1;
var nextTimeIndex = this._GetNextTimeIndex( this._speakersId[this._focusIndex._speakerIndex],this._focusIndex._timeIndex);
if( nextTimeIndex == -1)
{
if((this._focusIndex._speakerIndex+1)<this._speakersId.length)
{
speakerIndex = this._focusIndex._speakerIndex + 1;
timeIndex = -1;
}
else
{
speakerIndex = this._focusIndex._speakerIndex;;
timeIndex = this._focusIndex._timeIndex;
}
}
else
{
speakerIndex = this._focusIndex._speakerIndex;
timeIndex = nextTimeIndex;
}
this._changeToHighlight = false;
this._ChangeFocusIndex(speakerIndex,timeIndex);
this._FocusItem();
}
SpeakerIndexList.prototype._OnKeyDown = function( eventObj )
{
var theKey = BasicWidget.GetKey( eventObj );
switch(theKey)
{
case KeyTable.VK_RETURN:
case KeyTable.VK_SPACE:
this._OnKeyDownForEnterAndSpace();
break;
case KeyTable.VK_LEFT:
this._OnKeyDownForLeft();
break;
case KeyTable.VK_UP:
this._OnKeyDownForUp();
break;
case KeyTable.VK_RIGHT:
this._OnKeyDownForRight();
break;
case KeyTable.VK_DOWN:
this._OnKeyDownForDown();
break;
default:
break;
}
}
SpeakerIndexList.prototype._GetNextTimeIndex = function ( speakerId, currentTimeIndex )
{
if ( currentTimeIndex < -1)
{
}
var nextTimeIndex = -1;
if( !this._speakers[speakerId] || !this._speakers[speakerId].GetExpand())
{
nextTimeIndex = -1;
}
else
if(this._speakers[speakerId] && currentTimeIndex+1<this._speakers[speakerId]._timeList.ownedWidgets.length)
{
nextTimeIndex = currentTimeIndex + 1;
}
else
{
nextTimeIndex = -1;
}
return nextTimeIndex;
}
SpeakerIndexList.prototype._GetLastTimeIndex = function ( speakerId, currentTimeIndex )
{
if(currentTimeIndex<-1 || (this._speakers[speakerId] && currentTimeIndex >= this._speakers[speakerId]._timeList.ownedWidgets.length))
{
}
var lastTimeIndex = -2;
if( !this._speakers[speakerId] || !this._speakers[speakerId].GetExpand())
{
lastTimeIndex = -2;
}
if( currentTimeIndex-1>=-1)
{
lastTimeIndex = currentTimeIndex -1;
}
else
{
lastTimeIndex = -2;
}
return lastTimeIndex;
}
SpeakerIndexList.prototype.GetIndexibleItemCount = function()
{
return this._timeItems.length;
}
SpeakerIndexList.prototype.GetTimeArrayIndexByTimeIndex = function (speakerItem, timeIndex )
{
var index = -2;
for(var i=0;i<speakerItem._timeList.ownedWidgets.length;i++)
{
if(speakerItem._timeList.ownedWidgets[i].timeIndex == timeIndex)
{
if(speakerItem.GetExpand())
{
index = i;
}
else
{
index = -1;
}
}
}
return index;
}
SpeakerIndexList.prototype._EnableFocus = function( speakerIndex, timeIndex )
{
if( speakerIndex > -1 )
{
var speakerId = this._speakersId[speakerIndex];
var speakerItem = this._speakers[speakerId];
var item = null;
if(timeIndex == -1)
{
item = speakerItem.GetNameItem();
}
else
{
item = speakerItem._timeList.ownedWidgets[timeIndex];
}
item.SetTabIndex(this._tabIndex);
this.ScrollToItem(item);
}
}
SpeakerIndexList.prototype._DisableFocus = function( speakerIndex, timeIndex )
{
if(this._focusIndex._speakerIndex>-1)
{
var speakerId = this._speakersId[this._focusIndex._speakerIndex];
var speakerItem = this._speakers[speakerId];
if(this._focusIndex._timeIndex == -1)
{
speakerItem.GetNameItem().SetTabIndex(UISettings.tabIndexDisable);
}
else
{
speakerItem._timeList.ownedWidgets[this._focusIndex._timeIndex].SetTabIndex(UISettings.tabIndexDisable);
}
}
}
SpeakerIndexList.prototype._ChangeFocusIndex = function ( speakerIndex, timeIndex )
{
this._DisableFocus(this._focusIndex._speakerIndex, this._focusIndex._timeIndex);
this._focusIndex._speakerIndex = speakerIndex;
this._focusIndex._timeIndex = timeIndex;
this._EnableFocus(this._focusIndex._speakerIndex,this._focusIndex._timeIndex);
}
SpeakerIndexList.prototype._Focus = function( enable )
{
this._setFocus = enable;
if( !enable )
{
if( this._changeToHighlight )
{
this._ChangeFocusIndexToHighlightItem();
}
else
{
this._changeToHighlight = true;
}
}
}
SpeakerIndexList.prototype.SetSpeakerItems = function( speakerIndexList, attendeeList, duration )
{
if( speakerIndexList == null )
{
Trace.WriteLine( "There is no speaker index data" );
return;
}
if( attendeeList == null )
{
attendeeList = new Object();
}
var speakerIndexCount = speakerIndexList.length;
for( var i=0; i<speakerIndexCount; i++ )
{
var item = speakerIndexList[i];
var nextItem = speakerIndexList[ i + 1 ];
if( item == null )
{
return;
}
if( nextItem == null )
{
if( i != speakerIndexCount - 1 )
{
return;
}
else
{
nextItem = { "attendee":null, "time":duration };
}
}
var attendeeInfo = attendeeList[ item.attendee ];
var attendeeName = LocaleInfo.GetText( UISettings.speakerIndexUnknownSpeakerName );
if( attendeeInfo != null )
{
attendeeName = attendeeInfo.fullName;
}
this._listData[i] = {
"startTime":item.time,
"stopTime":nextItem.time,
"attendeeId":item.attendee,
"attendeeName":attendeeName };
}
this._AsyncAddNextItem( 0 );
}
SpeakerIndexList.prototype.ScrollToItem = function( item )
{
if( item==null )
{
return;
}
var speakerItem = item.speakerItem;
var itemTop = speakerItem._htmlObject.offsetTop + item.GetTopInSpeakerItem();
var itemHeight = item._htmlObject.clientHeight;
var clientTop = this._htmlObject.scrollTop;
var clientHeight = this._htmlObject.clientHeight;
Trace.WriteLine(
"Item top: %1, height: %2. Client top: %3, height: %4",
itemTop,
itemHeight,
clientTop,
clientHeight );
if( clientTop + clientHeight < itemTop + itemHeight )
{
var scrollTop = itemTop + itemHeight - clientHeight;
this._htmlObject.scrollTop = scrollTop > 0 ? scrollTop : 0;
}
else if( clientTop > itemTop )
{
this._htmlObject.scrollTop = itemTop;
}
}
Trace.Wrap( "SpeakerIndexList" );
function BasicPane()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( BasicPane, BasicWidget );
Trace.Wrap( "BasicPane" );
function ControlPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this.timeSliderTopLine = new BasicWidget();
this.timeSliderBottomLine = new BasicWidget();
this.timeSlider = new SliderWidget();
this.mainArea = new BasicWidget();
this.buttonsArea = new BasicWidget();
this.paneMenu = new MenuBarWidget();
this.timeText = new TextWidget();
this.buttonsLeftArea = new BasicWidget();
this.buttonsRightArea = new BasicWidget();
this.playButtons = new ButtonBarWidget();
this.volumeSlider = new SliderWidget();
this._originalTime = -1;
this._Resized.Add( Delegate( this, ControlPane.prototype._WidgetResized ) );
this._Created.Add( Delegate( this, ControlPane.prototype._WidgetCreated ) );
}
OOP.Inherit( ControlPane, BasicPane );
ControlPane.prototype._WidgetCreated = function()
{
this.timeSliderTopLine.Create( this, UISettings.timeSliderTopLineId );
this.timeSliderBottomLine.Create( this, UISettings.timeSliderBottomLineId );
this.timeSlider.Create( this, UISettings.timeSliderId );
this.mainArea.Create( this );
this.mainArea.SetStyle(
"backgroundImage",
"url(\"" + uiSettings.GetImage( "controlBackground" ) + "\")" );
this.mainArea.SetStyle( "backgroundRepeat", "repeat-x" );
this.paneMenu.Create( this.mainArea );
this.timeText.Create( this.mainArea, UISettings.timeTextId );
this.paneMenu.SetMenuAreaWidth( UISettings.primVideoWidth );
this.buttonsArea.Create( this.mainArea );
this.buttonsLeftArea.Create( this.buttonsArea );
this.buttonsRightArea.Create( this.buttonsArea );
this.playButtons.Create( this.buttonsArea );
this.volumeSlider.Create( this.buttonsArea, UISettings.volumeSliderId );
this.paneMenu.SetButtonBackgroundImages(
{
"normalLeft": uiSettings.GetImage( "generalButtonBackgroundNormalLeft" ),
"pushedLeft": uiSettings.GetImage( "generalButtonBackgroundPushedLeft" ),
"highlightedLeft": uiSettings.GetImage( "generalButtonBackgroundHighlightedLeft" ),
"disabledLeft": uiSettings.GetImage( "generalButtonBackgroundDisabledLeft" ),
"normalMiddle": uiSettings.GetImage( "generalButtonBackgroundNormalMiddle" ),
"pushedMiddle": uiSettings.GetImage( "generalButtonBackgroundPushedMiddle" ),
"highlightedMiddle": uiSettings.GetImage( "generalButtonBackgroundHighlightedMiddle" ),
"disabledMiddle": uiSettings.GetImage( "generalButtonBackgroundDisabledMiddle" ),
"normalRight": uiSettings.GetImage( "generalButtonBackgroundNormalRight" ),
"pushedRight": uiSettings.GetImage( "generalButtonBackgroundPushedRight" ),
"highlightedRight": uiSettings.GetImage( "generalButtonBackgroundHighlightedRight" ),
"disabledRight": uiSettings.GetImage( "generalButtonBackgroundDisabledRight" )
} );
var menu = this.paneMenu.AddMenu(
UISettings.paneMenuId,
LocaleInfo.GetText( UISettings.paneMenuId ),
uiSettings.GetImage( "viewMenuButton" ),
uiSettings.GetImage( "viewMenuExpand" )
);
menu.SetItemClassName(
"menuItemTitle",
"MenuItemTitle"
);
menu.SetItemClassName(
"menuItemDesc",
"MenuItemDesc"
);
menu.SetItemClassName(
"checkArea",
"MenuItemCheckArea"
);
menu.SetItemClassName(
"checkSymbArea",
"MenuItemCheckSymbArea"
);
menu.SetItemClassName(
"checkCell",
"MenuItemCheckCell"
);
menu.SetItemClassName(
"popupCell",
"MenuItemPopupCell"
);
if( menu.iframeIsLoaded )
{
this._AddPaneMenuItem( menu );
}
else
{
menu.iframeLoadedEvent.Add( DelegateWithArgs( this, ControlPane.prototype._AddPaneMenuItem, menu ) );
}
this.playButtons.SetUILayout(
5,
UISettings.playButtonWidth,
UISettings.playButtonHeight,
UISettings.playButtonHorzMargin );
this.playButtons.AddButton(
UISettings.playButtonId,
LocaleInfo.GetText( UISettings.playButtonId ),
uiSettings.GetImage( "normalPlayButton" ),
uiSettings.GetImage( "downPlayButton" ),
uiSettings.GetImage( "disabledPlayButton" ),
uiSettings.GetImage( "highlightPlayButton" ) );
this.playButtons.AddButton(
UISettings.stopButtonId,
LocaleInfo.GetText( UISettings.stopButtonId ),
uiSettings.GetImage( "normalStopButton" ),
uiSettings.GetImage( "downStopButton" ),
uiSettings.GetImage( "disabledStopButton" ),
uiSettings.GetImage( "highlightStopButton" ) );
this.playButtons.AddButton(
UISettings.pauseButtonId,
LocaleInfo.GetText( UISettings.pauseButtonId ),
uiSettings.GetImage( "normalPauseButton" ),
uiSettings.GetImage( "downPauseButton" ),
uiSettings.GetImage( "disabledPauseButton" ),
uiSettings.GetImage( "highlightPauseButton" ) );
this.playButtons.AddButton(
UISettings.previousButtonId,
LocaleInfo.GetText( UISettings.previousButtonId ),
uiSettings.GetImage( "normalPrevButton" ),
uiSettings.GetImage( "downPrevButton" ),
uiSettings.GetImage( "disabledPrevButton" ),
uiSettings.GetImage( "highlightPrevButton" ) );
this.playButtons.AddButton(
UISettings.nextButtonId,
LocaleInfo.GetText( UISettings.nextButtonId ),
uiSettings.GetImage( "normalNextButton" ),
uiSettings.GetImage( "downNextButton" ),
uiSettings.GetImage( "disabledNextButton" ),
uiSettings.GetImage( "highlightNextButton" ) );
this.playButtons.AddButton(
UISettings.muteButtonId,
LocaleInfo.GetText( UISettings.muteButtonId ),
uiSettings.GetImage( "normalMuteButton" ),
uiSettings.GetImage( "downMuteButton" ),
uiSettings.GetImage( "disabledMuteButton" ),
uiSettings.GetImage( "highlightMuteButton" ) );
this.playButtons.AddButton(
UISettings.unmuteButtonId,
LocaleInfo.GetText( UISettings.unmuteButtonId ),
uiSettings.GetImage( "normalUnmuteButton" ),
uiSettings.GetImage( "downUnmuteButton" ),
uiSettings.GetImage( "disabledUnmuteButton" ),
uiSettings.GetImage( "highlightUnmuteButton" ) );
this.playButtons.ShowButton( UISettings.playButtonId, 0 );
this.playButtons.ShowButton( UISettings.stopButtonId, 1 );
this.playButtons.ShowButton( UISettings.previousButtonId, 2 );
this.playButtons.ShowButton( UISettings.nextButtonId, 3 );
this.playButtons.ShowButton( UISettings.muteButtonId, 4 );
this.playButtons.EnableButton( UISettings.stopButtonId, false );
this.volumeSlider.SetSliderWidth( UISettings.volumeSliderWidth );
this.volumeSlider.SetAttribute( "title", LocaleInfo.GetText( UISettings.volumeSliderId ) );
this.volumeSlider.SetUnelapsedImage( uiSettings.GetImage( "volumeUnelapsed" ) );
this.volumeSlider.SetElapsedImage( uiSettings.GetImage( "volumeElapsed" ) );
this.volumeSlider.SetSliderImage( uiSettings.GetImage( "volumeSlider" ) );
this.volumeSlider.SetHeadImage( uiSettings.GetImage( "volumeHead" ) );
this.volumeSlider.SetTailImage( uiSettings.GetImage( "volumeTail" ) );
this.volumeSlider.SetValueRange( 0, 1 );
this.volumeSlider.SetValue( 0.5 );
this.timeSlider.SetSliderWidth( UISettings.timeSliderWidth );
this.timeSlider.SetUnelapsedImage( uiSettings.GetImage( "timeUnelapsed" ) );
this.timeSlider.SetElapsedImage( uiSettings.GetImage( "timeElapsed" ) );
this.timeSlider.SetSliderImage( uiSettings.GetImage( "timeSlider" ) );
this.timeSlider.SetHeadImage( uiSettings.GetImage( "timeHead" ) );
this.timeSlider.SetTailImage( uiSettings.GetImage( "timeTail" ) );
this.timeSlider.MouseMoveEvent.Add(
Delegate( this, ControlPane.prototype._TimeSliderMouseMove ) );
this.timeText.SetStyle( "textAlign", "center" );
this.timeText.SetVertAlignMiddle( true );
this.timeText.SetStyle(
"backgroundImage",
"url(\"" + uiSettings.GetImage( "controlRightBackground" ) + "\")" );
this.buttonsLeftArea.SetStyle(
"backgroundImage",
"url(\"" + uiSettings.GetImage( "buttonsLeftArea" ) + "\")" );
this.buttonsRightArea.SetStyle(
"backgroundImage",
"url(\"" + uiSettings.GetImage( "buttonsRightArea" ) + "\")" );
this.buttonsArea.SetStyle( "backgroundRepeat", "repeat-x" );
this.buttonsArea.SetStyle(
"backgroundImage",
"url(\"" + uiSettings.GetImage( "buttonsArea" ) + "\")" );
}
ControlPane.prototype._AddPaneMenuItem = function( menu )
{
menu.AddItem(
UISettings.showSpeakerMenuItemId,
LocaleInfo.GetText( UISettings.showSpeakerMenuItemId ),
LocaleInfo.GetText( UISettings.showSpeakerMenuItemDescription )
);
menu.AddItem(
UISettings.showPanoramaMenuItemId,
LocaleInfo.GetText( UISettings.showPanoramaMenuItemId ),
LocaleInfo.GetText( UISettings.showPanoramaMenuItemDescription )
);
menu.AddItem(
UISettings.showIndexMenuItemId,
LocaleInfo.GetText( UISettings.showIndexMenuItemId ),
LocaleInfo.GetText( UISettings.showIndexMenuItemDescription )
);
menu.AddItem(
UISettings.showNotesMenuItemId,
LocaleInfo.GetText( UISettings.showNotesMenuItemId ),
LocaleInfo.GetText( UISettings.showNotesMenuItemDescription )
);
menu.AddItem(
UISettings.showQaMenuItemId,
LocaleInfo.GetText( UISettings.showQaMenuItemId ),
LocaleInfo.GetText( UISettings.showQaMenuItemDescription )
);
}
ControlPane.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
var minWidth = 600;
if( clientWidth < minWidth )
{
clientWidth = minWidth;
}
if( clientHeight <= 0 )
{
return;
}
var timeSliderTopLineHeight = UISettings.timeSliderTopLineHeight;
var timeSliderTop = timeSliderTopLineHeight;
var timeSliderHeight = UISettings.timeSliderHeight;
var timeSliderBottomLineTop = timeSliderTop + timeSliderHeight;
var timeSliderBottomLineHeight = UISettings.timeSliderBottomLineHeight;
var mainAreaTop = timeSliderBottomLineTop + timeSliderBottomLineHeight;
var mainAreaHeight = clientHeight - mainAreaTop;
var mainAreaWidth = clientWidth;
var mainAreaLeft = 0;
var buttonsAreaWidth = UISettings.buttonsAreaWidth;
var buttonsAreaHeight = UISettings.buttonsAreaHeight;
var buttonsAreaLeft = ( mainAreaWidth - buttonsAreaWidth ) / 2;
var buttonsAreaTop = ( mainAreaHeight - buttonsAreaHeight ) / 2;
var buttonsLeftAreaWidth = UISettings.buttonsLeftAreaWidth;
var buttonsRightAreaWidth = UISettings.buttonsRightAreaWidth;
var buttonsRightAreaLeft = buttonsAreaWidth - buttonsRightAreaWidth;
this.timeSliderTopLine.SetUIPosition(
true,
0,
0,
clientWidth,
timeSliderTopLineHeight );
this.timeSliderBottomLine.SetUIPosition(
true,
0,
timeSliderBottomLineTop,
clientWidth,
timeSliderBottomLineHeight );
this.timeSlider.SetUIPosition(
true,
0,
timeSliderTop,
clientWidth,
timeSliderHeight );
this.mainArea.SetUIPosition(
true,
0,
mainAreaTop,
clientWidth,
mainAreaHeight );
this.buttonsArea.SetUIPosition(
true,
buttonsAreaLeft,
buttonsAreaTop,
buttonsAreaWidth,
buttonsAreaHeight );
this.buttonsLeftArea.SetUIPosition(
true,
0,
0,
buttonsLeftAreaWidth,
buttonsAreaHeight );
this.buttonsRightArea.SetUIPosition(
true,
buttonsRightAreaLeft,
0,
buttonsRightAreaWidth,
buttonsAreaHeight );
var playButtonsWidth = this.playButtons.GetContentWidth();
var playButtonsHeight = this.playButtons.GetContentHeight();
var playButtonsLeft = buttonsLeftAreaWidth;
var playButtonsTop = ( mainAreaHeight - playButtonsHeight ) / 2;
this.playButtons.SetUIPosition(
true,
playButtonsLeft,
playButtonsTop,
playButtonsWidth,
playButtonsHeight );
var volumeSliderWidth = UISettings.volumeTrackWidth;
var volumeSliderHeight = UISettings.volumeSliderHeight;
var volumeSliderTop = ( mainAreaHeight - volumeSliderHeight ) / 2;
var volumeSliderLeft = playButtonsLeft + playButtonsWidth + UISettings.volumeSliderLeftMargin;
this.volumeSlider.SetUIPosition(
true,
volumeSliderLeft,
volumeSliderTop,
volumeSliderWidth,
volumeSliderHeight );
var paneMenuWidth = UISettings.paneMenuWidth;
var paneMenuHeight = UISettings.paneMenuHeight;
var paneMenuLeft = UISettings.paneMenuLeft;
var paneMenuTop = ( mainAreaHeight - paneMenuHeight ) / 2;
this.paneMenu.SetUIPosition(
true,
paneMenuLeft,
paneMenuTop,
paneMenuWidth,
paneMenuHeight );
var timeTextWidth = UISettings.timeTextWidth;
var timeTextHeight = UISettings.timeTextHeight;
var timeTextLeft = clientWidth - timeTextWidth - UISettings.timeTextRightMargin;
var timeTextTop = ( mainAreaHeight - timeTextHeight ) / 2;
this.timeText.SetUIPosition(
true,
timeTextLeft,
timeTextTop,
timeTextWidth,
timeTextHeight );
}
ControlPane.prototype._TimeSliderMouseMove = function( value )
{
var timeString = TimeFormat.GetTimeString( value );
this.timeSlider.SetAttribute( "title", timeString );
}
ControlPane.prototype.OnMeetingStarted = function()
{
this.playButtons.ShowButton( UISettings.pauseButtonId, 0 );
this.playButtons.EnableButton( UISettings.stopButtonId, true );
}
ControlPane.prototype.OnMeetingStopped = function()
{
this.playButtons.ShowButton( UISettings.playButtonId, 0 );
this.playButtons.EnableButton( UISettings.stopButtonId, false );
}
ControlPane.prototype.OnMeetingPaused = function()
{
this.playButtons.ShowButton( UISettings.playButtonId, 0 );
}
ControlPane.prototype.OnMeetingMuted = function( muted )
{
var buttonId = muted ? UISettings.unmuteButtonId : UISettings.muteButtonId;
this.playButtons.ShowButton( buttonId, 4 );
}
ControlPane.prototype.OnVolumeChanged = function( volume )
{
this.volumeSlider.SetValue( volume );
}
ControlPane.prototype.OnTimeChanged = function( time, duration )
{
this.timeSlider.SetValue( time );
if( Math.floor( time ) != Math.floor( this._originalTime ) )
{
this._originalTime = time;
this.timeText.SetText(
TimeFormat.GetTimeString( time ) +
"/" +
TimeFormat.GetTimeString( duration ) );
}
}
ControlPane.prototype.OnMeetingIndexChanged = function( index, maxIndex )
{
this.playButtons.EnableButton( UISettings.nextButtonId, index < maxIndex - 1 );
this.playButtons.EnableButton( UISettings.previousButtonId, index > 0 );
}
Trace.Wrap( "ControlPane" );
function DataPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this.renderers = new Object();
this.annotationRenderer = null;
this._informationWidget = new InformationRenderer();
this._backgroundWidget = new BasicWidget();
this._activeRenderer = null;
this._Created.Add( Delegate( this, DataPane.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, DataPane.prototype._WidgetResized ) );
}
OOP.Inherit( DataPane, BasicPane );
DataPane.prototype.SetActiveRenderer = function( renderer, enableAnnotation )
{
if( this._activeRenderer != null )
{
this._activeRenderer.SetStyle( "visibility",  "hidden" );
this._activeRenderer.ActivateSession( false );
}
this._activeRenderer = renderer;
this.annotationRenderer.SetStyle( "visibility",  ( enableAnnotation == true ) ? "inherit" : "hidden" );
if( this._activeRenderer != null )
{
this._activeRenderer.SetStyle( "visibility",  "inherit" );
this._activeRenderer.ActivateSession( true );
this._ResizeActiveRenderer();
}
}
DataPane.prototype._CreateDataRenderer = function(
renderer,
id,
fitStyle )
{
renderer.Create( this, id );
renderer.SetStyle( "position", "absolute" );
renderer.SetStyle( "visibility", "hidden" );
this.renderers[ id ] = renderer;
renderer.OriginalSizeChanged.Add(Delegate( this, this._OnChildOriginalSizeChanged ) );
if( fitStyle == null )
{
fitStyle = "fill";
}
if( !( fitStyle in WidgetFitter.fitFunctions ) )
{
fitStyle = "fill";
}
renderer.outerFitter = new WidgetFitter( false );
renderer.fitStyle = fitStyle;
renderer.RegisterEvent( "onscroll", DelegateWithArgs(this, DataPane.prototype._ChildScrollHandler, renderer ) );
}
DataPane.prototype._WidgetCreated = function()
{
var dummyRenderer = new DummyRenderer();
this._CreateDataRenderer(
dummyRenderer,
UISettings.dummyRendererId,
"fill" );
var pptRenderer = new PPTHTMLRenderer();
this._CreateDataRenderer(
pptRenderer,
UISettings.pptRendererId,
"proportional" );
var imageRenderer = new ImageRenderer();
this._CreateDataRenderer(
imageRenderer,
UISettings.imageRendererId,
"fill" );
var modiRenderer = new ModiRenderer();
this._CreateDataRenderer(
modiRenderer,
UISettings.modiRendererId,
"fill" );
var pollRenderer = new PollRenderer();
this._CreateDataRenderer(
pollRenderer,
UISettings.pollRendererId,
"fill" );
var webRenderer = new WebRenderer();
this._CreateDataRenderer(
webRenderer,
UISettings.webRendererId,
"fill" );
var textRenderer = new TextRenderer();
this._CreateDataRenderer(
textRenderer,
UISettings.textRendererId,
"fill" );
var whiteboardRenderer = new WhiteboardRenderer();
this._CreateDataRenderer(
whiteboardRenderer,
UISettings.whiteboardRendererId,
"proportional" );
var mmcRenderer = new MmcRenderer();
this._CreateDataRenderer(
mmcRenderer,
UISettings.mmcRendererId,
"fill" );
var asRenderer = new ASRenderer();
this._CreateDataRenderer(
asRenderer,
UISettings.asRendererId,
"fill" );
var stampDrawer = null;
if ( NavigatorInfo.IsIE() )
{
stampDrawer = new VMLImageStampDrawer();
this.annotationRenderer = new AnnoVMLRenderer();
}
else
{
stampDrawer = new SVGImageStampDrawer();
this.annotationRenderer = new AnnoSVGRenderer();
}
stampDrawer.Initialize(
uiSettings.GetImage( "XStampAnno" ),
uiSettings.GetImage( "CheckStampAnno" ),
uiSettings.GetImage( "ArrowStampAnno" )
);
this.annotationRenderer.SetStampDrawer( stampDrawer );
this.annotationRenderer.Create( this, UISettings.annotationRendererId );
this.annotationRenderer.SetStyle( "visibility",  "hidden" );
this.annotationRenderer.AnnoHTMLLoadedEvent.Add( Delegate( this, DataPane.prototype._ResizeActiveRenderer) );
modiRenderer.fitter.PositionChangedEvent.Add( Delegate( this, DataPane.prototype._ChildPositionChangedHandler ) );
imageRenderer.fitter.PositionChangedEvent.Add( Delegate( this, DataPane.prototype._ChildPositionChangedHandler ) );
modiRenderer.image.ImageLoadedEvent.Add( Delegate( this, DataPane.prototype._ChildContentLoadedHandler ) );
this._backgroundWidget.Create( this, UISettings.dataPaneInfoWidgetId );
this._backgroundWidget.SetStyle("visibility","hidden");
this._backgroundWidget.SetStyle("zIndex", 0);
this._informationWidget.Create( this._backgroundWidget );
this._informationWidget.Bind(
this,
"TopLeft",
0,
0);
this._informationWidget.InformationVisibilityChanged.Add(
Delegate( this, DataPane.prototype._ShowInformationWidget ) );
for( var name in this.renderers )
{
var renderer = this.renderers[name];
this._informationWidget.BindInformationSession(
renderer );
}
}
DataPane.prototype._WidgetResized = function()
{
this._ResizeActiveRenderer();
}
DataPane.prototype._ResizeActiveRenderer = function()
{
if( this._activeRenderer == null )
{
return;
}
var width = this.GetClientWidth();
this._backgroundWidget.SetUIPosition( true, 0, 0, width, 0 );
var informationHeight = this._informationWidget.GetHeight() + this._backgroundWidget.GetNonClientHeight();
if (informationHeight < UISettings.dataPaneInfoWidgetHeight)
{
informationHeight = UISettings.dataPaneInfoWidgetHeight;
}
this._backgroundWidget.SetUIPosition( true, 0, 0, width, informationHeight );
var renderer = this._activeRenderer;
var informationVisible = this._informationWidget.IsShown();
var fitter = renderer.outerFitter;
if( informationVisible )
{
this._backgroundWidget.SetStyle("visibility","inherit");
fitter.Bind( this, renderer, renderer.fitStyle,
0, informationHeight, 0, 0);
}
else
{
this._backgroundWidget.SetStyle("visibility","hidden");
fitter.Bind( this, renderer, renderer.fitStyle );
}
if( this.annotationRenderer.GetStyle( "visibility" )!="hidden" )
{
var left = renderer.GetLeft();
var top = renderer.GetTop();
var clientWidth = renderer.GetClientWidth();
var clientHeight = renderer.GetClientHeight();
if( renderer != this.renderers[UISettings.imageRendererId] && renderer != this.renderers[UISettings.modiRendererId] )
{
this.annotationRenderer.SetAnnoAreaPosition( 0, 0 );
this.annotationRenderer.SetAnnoAreaSize( fitter.childWidth, fitter.childHeight );
}
this.annotationRenderer.SetUIPosition(
true,
left,
top,
clientWidth,
clientHeight );
this.annotationRenderer.SetScrollPosition( renderer.GetScrollLeft(), renderer.GetScrollTop() );
}
}
DataPane.prototype._OnChildOriginalSizeChanged = function( renderer )
{
if( this._activeRenderer == renderer )
{
Trace.WriteLine( "The aspect ratio of %1 has changed and applied. ", renderer.GetId() );
this._ResizeActiveRenderer();
}
else
{
Trace.WriteLine( "The aspect ratio of %1 has changed but not applied because it is not visible. ", renderer.GetId() );
}
}
DataPane.prototype._ChildScrollHandler = function( renderer )
{
var scrollLeft = renderer.GetScrollLeft();
var scrollTop = renderer.GetScrollTop();
this.annotationRenderer.SetScrollPosition( scrollLeft, scrollTop );
}
DataPane.prototype._ChildPositionChangedHandler = function( renderer, left, top, width, height )
{
if ( renderer != this._activeRenderer )
{
return;
}
var annoAreaWidth = this.annotationRenderer.GetAnnoAreaWidth();
var annoAreaHeight = this.annotationRenderer.GetAnnoAreaHeight();
this.annotationRenderer.SetAnnoAreaPosition( left, top );
this.annotationRenderer.SetAnnoAreaSize( width, height );
}
DataPane.prototype._ChildContentLoadedHandler = function()
{
this._ResizeActiveRenderer();
}
DataPane.prototype._ShowInformationWidget = function()
{
if( !this._activeRenderer )
{
return;
}
this._ResizeActiveRenderer();
}
Trace.Wrap( "DataPane" );
function NotesPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this._title = new TextWidget();
this.renderer = new NotesRenderer();
this._Created.Add( Delegate( this, NotesPane.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, NotesPane.prototype._WidgetResized ) );
}
OOP.Inherit( NotesPane, BasicPane );
NotesPane.prototype._WidgetCreated = function()
{
this._title.Create( this, UISettings.notesPaneTitleId );
this.renderer.Create( this, UISettings.notesRendererId );
this._title.SetAttribute( "className", UISettings.frameTitleClassName );
this._title.SetText( LocaleInfo.GetText( UISettings.notesPaneTitleId ) );
}
NotesPane.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
var padding = UISettings.notesPanePadding;
var titleLeft = padding;
var titleTop = padding;
var titleWidth = clientWidth - titleLeft - padding;
var titleHeight = UISettings.qaPaneTitleHeight;
this._title.SetUIPosition(
true,
titleLeft,
titleTop,
titleWidth,
titleHeight );
var rendererLeft = padding;
var rendererTop = titleTop + titleHeight;
var rendererWidth = titleWidth;
var rendererHeight = clientHeight - rendererTop - padding;
this.renderer.SetUIPosition(
true,
rendererLeft,
rendererTop,
rendererWidth,
rendererHeight );
}
Trace.Wrap( "NotesPane" );
function QAPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this._title = new TextWidget();
this.renderer = new QARenderer();
this._Created.Add( Delegate( this, QAPane.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, QAPane.prototype._WidgetResized ) );
}
OOP.Inherit( QAPane, BasicPane );
QAPane.prototype._WidgetCreated = function()
{
this._title.Create( this, UISettings.qaPaneTitleId );
this.renderer.Create( this, UISettings.qaRendererId );
this._title.SetAttribute( "className", UISettings.frameTitleClassName );
this._title.SetText( LocaleInfo.GetText( UISettings.qaPaneTitleId ) );
}
QAPane.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
var padding = UISettings.qaPanePadding;
var titleLeft = padding;
var titleTop = padding;
var titleWidth = clientWidth - titleLeft - padding;
var titleHeight = UISettings.qaPaneTitleHeight;
this._title.SetUIPosition(
true,
titleLeft,
titleTop,
titleWidth,
titleHeight );
var rendererLeft = padding;
var rendererTop = titleTop + titleHeight;
var rendererWidth = titleWidth;
var rendererHeight = clientHeight - rendererTop - padding;
this.renderer.SetUIPosition(
true,
rendererLeft,
rendererTop,
rendererWidth,
rendererHeight );}
Trace.Wrap( "QAPane" );
function IndexPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this._Created.Add( Delegate( this, IndexPane.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, IndexPane.prototype._WidgetResized ) );
this.categoryList = new TabBarWidget();
this.indexLists = new Object();
this._activeListName = null;
}
OOP.Inherit( IndexPane, BasicPane );
IndexPane.prototype._WidgetCreated = function()
{
this.categoryList.Create( this, UISettings.indexCategoriesId );
this.categoryList.SetItemClassName(
"highlightedLeft",
UISettings.indexCategoryHighlightedLeftClassName );
this.categoryList.SetItemClassName(
"highlightedRight",
UISettings.indexCategoryHighlightedRightClassName );
this.categoryList.SetItemClassName(
"highlightedMiddle",
UISettings.indexCategoryHighlightedMiddleClassName );
this.categoryList.SetItemClassName(
"normalLeft",
UISettings.indexCategoryNormalLeftClassName );
this.categoryList.SetItemClassName(
"normalRight",
UISettings.indexCategoryNormalRightClassName );
this.categoryList.SetItemClassName(
"normalMiddle",
UISettings.indexCategoryNormalMiddleClassName );
this.categoryList.SetAttribute(
"className",
UISettings.indexCategoryClassName );
this.categoryList.AddItem(
UISettings.indexTabContentId,
MeetingSettings.Index.ContentName,
LocaleInfo.GetText( UISettings.indexTabContentId )
);
this.categoryList.AddItem(
UISettings.indexTabSpeakerId,
MeetingSettings.Index.SpeakerName,
LocaleInfo.GetText( UISettings.indexTabSpeakerId )
);
var contentIndexList = new ContentIndexList();
contentIndexList.Create( this, UISettings.contentIndexListId );
contentIndexList.SetStyle( "visibility",  "hidden" );
this.indexLists[ MeetingSettings.Index.ContentName ] = contentIndexList;
var speakerIndexList = new SpeakerIndexList();
speakerIndexList.Create( this, UISettings.speakerIndexListId );
speakerIndexList.SetStyle( "visibility",  "hidden" );
this.indexLists[ MeetingSettings.Index.SpeakerName ] = speakerIndexList;
this.SetActiveIndexList( MeetingSettings.Index.ContentName );
}
IndexPane.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
var categoryLeft = UISettings.indexCategoryLeftMargin;
var categoryTop = UISettings.indexCategoryTopMargin;
var categoryWidth =
clientWidth -
UISettings.indexCategoryLeftMargin -
UISettings.indexCategoryRightMargin;
var categoryHeight = UISettings.indexCategoryHeight;
var listsLeft = UISettings.indexListsLeftMargin;
var listsTop =
categoryTop +
categoryHeight +
UISettings.indexCategoryBottomMargin +
UISettings.indexListsTopMargin;
var listsWidth =
clientWidth -
UISettings.indexListsLeftMargin -
UISettings.indexListsRightMargin;
var listsHeight =
clientHeight -
listsTop -
UISettings.indexListsBottomMargin;
this.categoryList.SetUIPosition(
true,
categoryLeft,
categoryTop,
categoryWidth,
categoryHeight );
for( var listName in this.indexLists )
{
this.indexLists[ listName ].SetUIPosition(
true,
listsLeft,
listsTop,
listsWidth,
listsHeight );
}
}
IndexPane.prototype.SetActiveIndexList = function( listName )
{
if( listName != null &&
!( listName in this.indexLists ) )
{
alert( "The set name of active index list should be in the index list array or be null. " );
return;
}
if( this._activeListName != null )
{
this.indexLists[ this._activeListName ].SetStyle( "visibility",  "hidden" );
}
if( listName != null )
{
this.indexLists[ listName ].SetStyle( "visibility",  "inherit" );
}
this._activeListName = listName;
this.categoryList.ActiveItemByCommandId( listName );
}
IndexPane.prototype.GetActiveIndexList = function()
{
if( this._activeListName == null )
{
return null;
}
return this.indexLists[ this._activeListName ];
}
Trace.Wrap( "IndexPane" );
function PrimVideoPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this.renderer = new SpeakerRenderer();
this.businessCard = new BusinessCardRenderer();
this._informationWidget = new InformationRenderer();
this._Created.Add( Delegate( this, PrimVideoPane.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, PrimVideoPane.prototype._WidgetResized ) );
}
OOP.Inherit( PrimVideoPane, BasicPane );
PrimVideoPane.prototype._WidgetCreated = function()
{
this.renderer.avRenderer.EnableAudio( false );
this.renderer.Create( this );
this.businessCard.Create( this, UISettings.bizCardRendererId );
this.businessCard.SetStyle( "visibility", "hidden" );
this.renderer.SetStyle( "visibility", "hidden" );
this._informationWidget.Create( this );
this._informationWidget.Bind(
this,
"TopLeft",
UISettings.informationTopMargin,
UISettings.informationRightMargin );
this._informationWidget.BindInformationSession(
this.renderer.avRenderer );
this._informationWidget.BindInformationSession(
this.businessCard );
this.businessCard.ActivateSession( true );
}
PrimVideoPane.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
var padding = UISettings.primVideoPanePadding;
var rendererLeft = padding;
var rendererTop = padding;
var rendererWidth = clientWidth - padding * 2;
var rendererHeight = clientHeight - padding * 2;
this.renderer.SetUIPosition(
true,
rendererLeft,
rendererTop,
rendererWidth,
rendererHeight );
var cardLeft = padding;
var cardTop = padding;
var cardWidth = clientWidth - padding * 2;
var cardHeight = clientHeight - padding * 2;
this.businessCard.SetUIPosition(
true,
cardLeft,
cardTop,
cardWidth,
cardHeight );
}
PrimVideoPane.prototype._VideoVisibilityChanged = function( visible )
{
this.renderer.avRenderer.ActivateSession( visible );
this.businessCard.ActivateSession( !visible );
this.businessCard.SetStyle( "visibility", visible ? "hidden" : "inherit" );
this.renderer.SetStyle( "visibility", visible ? "inherit" : "hidden" );
}
PrimVideoPane.prototype.ChangeBizcardVisibility = function( action )
{
if ( action == "show" )
{
this._VideoVisibilityChanged( false );
}
else
{
this._VideoVisibilityChanged( true );
}
}
Trace.Wrap( "PrimVideoPane" );
function PanoVideoPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this.renderer = new PanoRenderer();
this._informationWidget = new InformationRenderer();
this._Created.Add( Delegate( this, PanoVideoPane.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, PanoVideoPane.prototype._WidgetResized ) );
}
OOP.Inherit( PanoVideoPane, BasicPane );
PanoVideoPane.prototype._WidgetCreated = function()
{
this.renderer.avRenderer.EnableAudio( false );
this.renderer.Create( this );
this._informationWidget.Create( this );
this._informationWidget.Bind(
this,
"TopLeft",
UISettings.informationTopMargin,
UISettings.informationRightMargin );
this._informationWidget.BindInformationSession(
this.renderer.avRenderer );
this.renderer.avRenderer.ActivateSession( true );
}
PanoVideoPane.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
var padding = UISettings.panoVideoPanePadding;
var rendererLeft = padding;
var rendererTop = padding;
var rendererWidth = clientWidth - padding * 2;
var rendererHeight = clientHeight - padding * 2;
this.renderer.SetUIPosition(
true,
rendererLeft,
rendererTop,
rendererWidth,
rendererHeight );
}
Trace.Wrap( "PanoVideoPane" );
function BrandPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this._Created.Add( Delegate( this, _BrandPane_Created ) );
this._Resized.Add( Delegate( this, _BrandPane_Resized ) );
this._productLogo = new ImageWidget();
this._corpLogo = new ImageWidget();
this._corpOuterWidget = new BasicWidget();
this._corpInnerWidget = new BasicWidget();
}
OOP.Inherit( BrandPane, BasicPane );
function _BrandPane_Created()
{
this._productLogo.Create( this, UISettings.productLogoId );
this._corpOuterWidget.Create( this );
this._corpInnerWidget.Create( this._corpOuterWidget );
this._corpLogo.Create( this._corpInnerWidget, UISettings.corpLogoId );
this._corpLogo.ImageLoadedEvent.Add( Delegate( this, BrandPane.prototype._CorpImageLoaded ) );
this._productLogo.SetURI( uiSettings.GetImage( "productLogo" ) );
this._corpOuterWidget.SetStyle( "position", "absolute" );
this._corpLogo.SetStyle( "position", "relative" );
this._corpInnerWidget.SetStyle( "position", "relative" );
this._corpOuterWidget.SetStyle( "padding", 1 );
this._corpInnerWidget.SetStyle( "padding", 1 );
this._corpOuterWidget.SetStyle( "backgroundColor", UISettings.corpImageOuterBorderColor );
this._corpInnerWidget.SetStyle( "backgroundColor", UISettings.corpImageInnerBorderColor );
this._corpOuterWidget.SetStyle( "visibility", "hidden" );
}
function _BrandPane_Resized()
{
this._LocateCorpLogo();
}
BrandPane.prototype.SetCorpImage = function( url )
{
this._corpOuterWidget.SetStyle( "visibility", "hidden" );
if( url != null )
{
this._corpLogo.SetURI( url );
}
}
BrandPane.prototype._CorpImageLoaded = function()
{
this._corpOuterWidget.SetStyle( "visibility", "inherit" );
this._CalculateCorpLogoSize();
this._LocateCorpLogo();
}
BrandPane.prototype._CalculateCorpLogoSize = function()
{
var imageWidth = this._corpLogo._originalWidth;
var imageHeight = this._corpLogo._originalHeight;
var corpImageHeight = UISettings.maxCorpImageHeight -
UISettings.corpImageOuterBorderWidth * 2 -
UISettings.corpImageInnerBorderWidth * 2;
var corpImageWidth = UISettings.maxCorpImageWidth -
UISettings.corpImageOuterBorderWidth * 2 -
UISettings.corpImageInnerBorderWidth * 2;
if( imageWidth * corpImageHeight > imageHeight * corpImageWidth )
{
this._corpLogo.SetWidth( corpImageWidth );
}
else
{
this._corpLogo.SetHeight( corpImageHeight );
}
}
BrandPane.prototype._LocateCorpLogo = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
var corpImageOuterTop = ( clientHeight - this._corpLogo.GetHeight() ) / 2 -
UISettings.corpImageInnerBorderWidth -
UISettings.corpImageOuterBorderWidth;
var corpImageOuterLeft = clientWidth -
this._corpLogo.GetWidth() -
2 * UISettings.corpImageInnerBorderWidth -
2 * UISettings.corpImageOuterBorderWidth -
UISettings.corpImageRightMargin;
this._corpOuterWidget.SetLocation(
corpImageOuterLeft,
corpImageOuterTop );
}
Trace.Wrap( "BrandPane" );
function DownloadPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this.ShowCompletedEvent = new Event();
this.NeedResizeEvent = new Event();
this._durationUpdated = false;
this.meetingInfo = new TextWidget();
this.meetingSubject = new TextWidget();
this.downloadPrompt = new TextWidget();
this.downloadAnimation = new ImageWidget();
this.seperatorImage = new ImageWidget();
this.seperatorImageWrapper = new BasicWidget();
this.browserSetting = new TextWidget();
this._buttonArea = new BasicWidget();
this.continueButton = new TextButton();
this.closeButton = new TextButton();
this._browserSettingText = null;
this._heightNotIncludeBrowserSettingsElements = 0;
this._Created.Add( Delegate( this, DownloadPane.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, DownloadPane.prototype._WidgetResized ) );
}
OOP.Inherit( DownloadPane, BasicPane );
DownloadPane.prototype._WidgetCreated = function()
{
this.meetingSubject.Create( this, UISettings.downloadSubjectId );
this.meetingInfo.Create( this, UISettings.downloadMeetingInfoId );
this.downloadPrompt.Create( this, UISettings.downloadPromptId );
this.downloadAnimation.Create( this, UISettings.downloadAnimationId );
this.downloadPrompt.SetText( LocaleInfo.GetText( UISettings.downloadPromptText ) );
this.downloadAnimation.SetURI( uiSettings.GetImage( "downloadAnimation" ) );
}
DownloadPane.prototype._CreateBrowserSettingsElements = function()
{
this._heightNotIncludeBrowserSettingsElements = this.GetHeight();
this.seperatorImageWrapper.Create( this, UISettings.downloadSeperatorWrapperId );
this.browserSetting.Create( this, UISettings.downloadBrowserSettingId );
this._buttonArea.Create( this, UISettings.downloadContinueButtonAreaId );
this._buttonArea.SetStyle( "position", "relative" );
this.continueButton.Create( this._buttonArea, UISettings.downloadContinueButtonId );
this.continueButton.SetStyle( "position", "absolute" );
this.closeButton.Create( this._buttonArea, UISettings.downloadCloseButtonId );
this.closeButton.SetStyle( "position", "absolute" );
this.seperatorImage.Create( this.seperatorImageWrapper, UISettings.downloadSeperatorId );
this.seperatorImage.SetURI( uiSettings.GetImage( "downloadSeperator" ) );
this.continueButton.SetText(
LocaleInfo.GetText( UISettings.downloadContinueButtonText ) );
this.continueButton.SetAttribute(
"title",
LocaleInfo.GetText( UISettings.downloadContinueButtonTooltip ) );
this.continueButton.FitTextWidth();
this.closeButton.SetText(
LocaleInfo.GetText( UISettings.downloadCloseButtonText ) );
this.closeButton.SetAttribute(
"title",
LocaleInfo.GetText( UISettings.downloadCloseButtonTooltip ) );
this.closeButton.FitTextWidth();
this.continueButton.SetTabIndex( UISettings.tabIndexDefault );
this.continueButton.SetItemClassName( "left", "ButtonLeft" );
this.continueButton.SetItemClassName( "middle", "ButtonMiddle" );
this.continueButton.SetItemClassName( "right", "ButtonRight" );
this.continueButton.ApplyDomClasses();
this.closeButton.SetTabIndex( UISettings.tabIndexDefault );
this.closeButton.SetItemClassName( "left", "ButtonLeft" );
this.closeButton.SetItemClassName( "middle", "ButtonMiddle" );
this.closeButton.SetItemClassName( "right", "ButtonRight" );
this.closeButton.ApplyDomClasses();
this.continueButton.ClickEvent.Add( Delegate( this, this._OnContinuePlay ) );
this.closeButton.ClickEvent.Add( Delegate( this, this._OnClosePlay ) );
if( this._browserSettingText != null )
{
this.browserSetting._htmlObject.innerHTML = this._browserSettingText;
this.browserSetting.SetStyle( "display", "block" );
this.continueButton.SetStyle( "display", "block" );
this.closeButton.SetStyle( "display", "block" );
this.seperatorImageWrapper.SetStyle( "display", "block" );
}
else
{
this.browserSetting.SetStyle( "display", "none" );
this.closeButton.SetStyle( "display", "none" );
this.seperatorImageWrapper.SetStyle( "display", "none" );
}
this._Resized();
}
DownloadPane.prototype._WidgetResized = function()
{
if( this.continueButton._htmlObject )
{
var buttonMargin = 10;
var clientWidth = this.GetClientWidth();
var continueButtonWidth = this.continueButton.GetWidth();
var closeButtonWidth = this.closeButton.GetWidth();
var buttonWidth = continueButtonWidth;
if( buttonWidth < closeButtonWidth )
{
buttonWidth = closeButtonWidth;
}
var buttonCount = 2;
var buttonCollectionWidth = buttonCount * buttonWidth + ( buttonCount - 1 ) * buttonMargin;
this._buttonArea.SetWidth( clientWidth );
var left = (clientWidth - buttonCollectionWidth)/2;
this.continueButton.SetLocation( left, 0 );
this.continueButton.SetWidth( buttonWidth );
left += buttonWidth + buttonMargin;
this.closeButton.SetLocation( left, 0 );
this.closeButton.SetWidth( buttonWidth );
}
}
DownloadPane.prototype.SetMeetingInfo = function( meetingInfo, showDuration )
{
if ( showDuration )
{
this._durationUpdated = true;
}
var subject = LocaleInfo.GetText( UISettings.downloadDefaultSubject );
if( meetingInfo.subject + "" != "" )
{
subject = meetingInfo.subject;
}
this.meetingSubject.SetText( subject );
var startTimePrompt = LocaleInfo.GetText( UISettings.downloadStartTimePrompt );
var startTime = LocaleInfo.GetText( UISettings.downloadStartTimeDefaultString );
var stopTimePrompt = LocaleInfo.GetText( UISettings.downloadStopTimePrompt );
var stopTime = LocaleInfo.GetText( UISettings.downloadStopTimeDefaultString );
var durationPrompt = LocaleInfo.GetText( UISettings.downloadDurationPrompt );
var duration = LocaleInfo.GetText( UISettings.downloadDurationDefaultString );
if ( meetingInfo.startTime != null )
{
startTime = meetingInfo.startTime.toLocaleString();
}
if ( meetingInfo.stopTime != null )
{
stopTime = meetingInfo.stopTime.toLocaleString();
}
if( meetingInfo.duration != null )
{
duration = TimeFormat.GetTimeString( meetingInfo.duration );
}
var str = startTimePrompt + " " + startTime + "\n" +
stopTimePrompt + " " + stopTime;
if( this._durationUpdated )
{
str += "\n" + durationPrompt + duration;
}
else
{
str += "\n";
}
this.meetingInfo.SetText( str );
}
DownloadPane.prototype._AddInfoText = function( text )
{
if( this._browserSettingText == null )
{
this._browserSettingText = TextWidget.GetSafeText( text );
}
else
{
this._browserSettingText += "<br/>" + TextWidget.GetSafeText( text );
}
}
DownloadPane.prototype.ShowBrowserSettings = function()
{
if( !this._CheckSettings() )
{
this.ShowCompletedEvent( false );
}
else
{
this._CreateBrowserSettingsElements();
if( this.browserSetting._htmlObject != null )
{
this.browserSetting._htmlObject.innerHTML = this._browserSettingText;
this.seperatorImageWrapper.SetStyle( "display", "block" );
this.browserSetting.SetStyle( "display", "block" );
this.continueButton.SetStyle( "display", "block" );
var scrollHeight = this.GetScrollHeight();
if( scrollHeight > this.GetHeight() )
{
this.NeedResizeEvent( scrollHeight );
}
}
}
}
DownloadPane.prototype._CheckSettings = function()
{
var needConfirm = false;
needConfirm = ( needConfirm | this._CheckBrowser() | this._CheckOS() );
if( !needConfirm )
{
needConfirm = ( needConfirm | this._CheckCookie() );
if ( NavigatorInfo.checkWMV )
{
needConfirm = ( needConfirm | this._CheckWmv() );
}
if ( NavigatorInfo.checkFlash )
{
needConfirm = ( needConfirm | this._CheckFlash() );
}
if ( NavigatorInfo.checkAnimation )
{
needConfirm = ( needConfirm | this._CheckAnimation() );
}
needConfirm = ( needConfirm | this._CheckImage() );
}
this._AddInfoText( "" );
this._AddInfoText( LocaleInfo.GetText( UISettings.downloadCheckResultEndingSentence ) );
return needConfirm;
}
DownloadPane.prototype._CheckOS = function()
{
var needConfirm = true;
var osName = NavigatorInfo.GetOSName();
var osType = NavigatorInfo.GetOSType();
var osVer  = NavigatorInfo.GetOSVersion();
if ( osName == "Windows" )
{
if ( osType == "NT" )
{
needConfirm = false;
}
}
else if ( osName == "Mac OS" )
{
if ( (osVer.length > 0) && (osVer[0] == "X") )
{
needConfirm = false;
}
}
return needConfirm;
}
DownloadPane.prototype._CheckBrowser = function()
{
var needConfirm = false;
var browserName = NavigatorInfo.GetBrowserName();
var browserVersion = NavigatorInfo.GetBrowserVersion();
var supportedBrowsers = {
"MSIE":"5.5",
"Firefox":"1.5",
"Mozilla":"1.7",
"Safari":"2.0.0",
"Netscape":"8.0"
};
if( browserName in supportedBrowsers )
{
if ( CompareVersion( browserVersion, supportedBrowsers[ browserName ] ) < 0 )
{
needConfirm = true;
this._AddInfoText( LocaleInfo.GetText( UISettings.downloadBrowserVersionCheckResult ) );
}
}
else
{
needConfirm = true;
this._AddInfoText( LocaleInfo.GetText( UISettings.downloadBrowserNameCheckResult ) );
}
return needConfirm;
}
DownloadPane.prototype._CheckCookie = function()
{
var needConfirm = !NavigatorInfo.CookieEnabled();
if( needConfirm )
{
this._AddInfoText( LocaleInfo.GetText( UISettings.downloadCookieCheckResult ) );
}
return needConfirm;
}
DownloadPane.prototype._CheckWmv = function()
{
var needConfirm = !NavigatorInfo.WmvEnabled();
if( needConfirm )
{
this._AddInfoText( LocaleInfo.GetText( UISettings.downloadWmvCheckResult ) );
}
return needConfirm;
}
DownloadPane.prototype._CheckFlash = function()
{
var needConfirm = !NavigatorInfo.FlashEnabled();
if( needConfirm )
{
this._AddInfoText( LocaleInfo.GetText( UISettings.downloadFlashCheckResult ) );
}
return needConfirm;
}
DownloadPane.prototype._CheckAnimation = function()
{
var needConfirm = NavigatorInfo.IsIE() && !NavigatorInfo.AnimationEnabled();
if( needConfirm )
{
this._AddInfoText( LocaleInfo.GetText( UISettings.downloadAnimationCheckResult ) );
}
return needConfirm;
}
DownloadPane.prototype._CheckImage = function()
{
var needConfirm = !NavigatorInfo.ImageEnabled();
if( needConfirm )
{
this._AddInfoText( LocaleInfo.GetText( UISettings.downloadImageCheckResult ) );
}
return needConfirm;
}
DownloadPane.prototype._OnContinuePlay = function()
{
this.seperatorImageWrapper.SetStyle( "display", "none" );
this.browserSetting.SetStyle( "display", "none" );
this.continueButton.SetStyle( "display", "none" );
this.closeButton.SetStyle( "display", "none" );
this.NeedResizeEvent( -1 );
this.ShowCompletedEvent( true );
}
DownloadPane.prototype._OnClosePlay = function()
{
window.close();
}
Trace.Wrap( "DownloadPane" );
function PlaybackPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this.primVideoPane = new PrimVideoPane();
this.panoVideoPane = new PanoVideoPane();
this.audioRenderer = new AVRenderer();
this.indexPane = new IndexPane();
this.dataPane = new DataPane();
this.qaPane = new QAPane();
this.notesPane = new NotesPane();
this.mainVertSplitter = new SplitterWidget();
this.mainHorzSplitter = new SplitterWidget();
this.dataSplitter = new SplitterWidget();
this.controlPane = new ControlPane();
this._indexWidth = UISettings.primVideoWidth;
this._notesQaWidth = UISettings.notesQaWidth;
this._Resized.Add( Delegate( this, PlaybackPane.prototype._WidgetResized ) );
this._Created.Add( Delegate( this, PlaybackPane.prototype._WidgetCreated ) );
}
OOP.Inherit( PlaybackPane, BasicPane );
PlaybackPane.prototype._WidgetCreated = function()
{
this.primVideoPane.Create( this, UISettings.primVideoPaneId );
this.panoVideoPane.Create( this, UISettings.panoVideoPaneId );
this.audioRenderer.Create( this, UISettings.audioRendererId );
this.indexPane.Create( this, UISettings.indexPaneId );
this.dataPane.Create( this, UISettings.dataPaneId );
this.qaPane.Create( this, UISettings.qaPaneId );
this.notesPane.Create( this, UISettings.notesPaneId );
this.controlPane.Create( this, UISettings.controlPaneId );
this.mainVertSplitter.Create( this, UISettings.mainVertSplitterId );
this.mainHorzSplitter.Create( this, UISettings.mainHorzSplitterId );
this.dataSplitter.Create( this, UISettings.dataSplitterId );
this.primVideoPane.SetStyle( "visibility",  "hidden" );
this.panoVideoPane.SetStyle( "visibility",  "hidden" );
if( NavigatorInfo.IsFirefox() || NavigatorInfo.IsMozilla() )
{
this.audioRenderer.SetStyle("width",0);
this.audioRenderer.SetStyle("height",0);
this.audioRenderer.SetStyle( "visibility", "inherit");
}
else
{
this.audioRenderer.SetStyle( "visibility",  "hidden" );
}
this.indexPane.SetStyle( "visibility",  "hidden" );
this.qaPane.SetStyle( "visibility",  "hidden" );
this.qaPane.SetStyle( "display", "none" );
this.notesPane.SetStyle( "visibility",  "hidden" );
this.notesPane.SetStyle( "display", "none" );
this.mainVertSplitter.SetStyle( "visibility",  "hidden" );
this.dataSplitter.SetStyle( "visibility",  "hidden" );
}
PlaybackPane.prototype._WidgetResized = function()
{
this._ResizePanes();
}
PlaybackPane.prototype._ResizePanes = function()
{
var panoVideoVisible = ( this.panoVideoPane._htmlObject.style.visibility != "hidden" );
var primVideoVisible = ( this.primVideoPane._htmlObject.style.visibility != "hidden" );
var notesVisible = ( this.notesPane._htmlObject.style.visibility != "hidden" );
var qaVisible = ( this.qaPane._htmlObject.style.visibility != "hidden" );
var indexVisible = ( this.indexPane._htmlObject.style.visibility != "hidden" );
var dataSplitterVisible = ( this.dataSplitter._htmlObject.style.visibility != "hidden" );
var mainVertSplitterVisible = ( this.mainVertSplitter._htmlObject.style.visibility != "hidden" );
var mainHorzSplitterVisible = ( this.mainHorzSplitter._htmlObject.style.visibility != "hidden" );
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
var videoHeight = UISettings.primVideoHeight;
var controlHeight = UISettings.controlHeight;
var controlTop = clientHeight - controlHeight;
var controlLeft = 0;
var controlWidth = clientWidth;
var mainHorzSplitterTop = videoHeight;
var mainHorzSplitterHeight = UISettings.mainHorzSplitterHeight;
var mainHorzSplitterWidth = clientWidth;
if( !panoVideoVisible )
{
mainHorzSplitterWidth = this._indexWidth;
}
var mainHorzSplitterLeft = 0;
var mainHorzSplitterBottom = mainHorzSplitterTop + mainHorzSplitterHeight;
var mainVertSplitterTop = 0;
if( !primVideoVisible )
{
mainVertSplitterTop = mainHorzSplitterBottom;
}
var mainVertSplitterHeight = controlTop - mainVertSplitterTop;
if( !indexVisible & panoVideoVisible )
{
mainVertSplitterHeight = videoHeight;
}
var mainVertSplitterWidth = UISettings.mainVertSplitterWidth;
var mainVertSplitterLeft = this._indexWidth;
var mainVertSplitterRight = mainVertSplitterLeft + mainVertSplitterWidth;
var primVideoLeft = 0;
var primVideoWidth = this._indexWidth;
var primVideoHeight = videoHeight;
var primVideoTop = 0;
var indexTop = mainHorzSplitterBottom;
if( !mainHorzSplitterVisible )
{
indexTop = 0;
}
var indexHeight = controlTop - indexTop;
var indexLeft = 0;
var indexWidth = primVideoWidth;
var panoVideoHeight = videoHeight;
var panoVideoTop = 0;
var panoVideoLeft = 0;
if( mainVertSplitterVisible && primVideoVisible )
{
var panoVideoLeft = mainVertSplitterRight;
}
var panoVideoWidth = controlWidth - panoVideoLeft;
var dataSplitterWidth = UISettings.dataSplitterWidth;
var dataSplitterLeft = controlWidth - this._notesQaWidth - dataSplitterWidth;
var dataSplitterTop = 0;
if( panoVideoVisible )
{
var dataSplitterTop = mainHorzSplitterBottom;
}
var dataSplitterHeight = controlTop - dataSplitterTop;
var notesWidth = this._notesQaWidth;
var notesLeft = clientWidth - notesWidth;
var notesTop = dataSplitterTop;
var notesHeight = dataSplitterHeight;
var qaWidth = this._notesQaWidth;
var qaLeft = clientWidth - qaWidth;
var qaTop = notesTop;
var qaHeight = dataSplitterHeight;
if( qaVisible && notesVisible )
{
var qaTop = notesTop + dataSplitterHeight / 2;
var notesHeight = qaTop - notesTop;
var qaHeight = dataSplitterHeight - notesHeight;
}
var dataTop = dataSplitterTop;
var dataLeft = mainVertSplitterRight;
if( !mainVertSplitterVisible || ( !indexVisible && panoVideoVisible ) )
{
dataLeft = 0;
}
var dataHeight = dataSplitterHeight;
var dataWidth = controlWidth - dataLeft;
if( dataSplitterVisible )
{
var dataWidth = dataSplitterLeft - dataLeft;
}
this.controlPane.SetUIPosition(
true,
controlLeft,
controlTop,
controlWidth,
controlHeight );
this.mainVertSplitter.SetUIPosition(
true,
mainVertSplitterLeft,
mainVertSplitterTop,
mainVertSplitterWidth,
mainVertSplitterHeight );
this.mainHorzSplitter.SetUIPosition(
true,
mainHorzSplitterLeft,
mainHorzSplitterTop,
mainHorzSplitterWidth,
mainHorzSplitterHeight );
this.primVideoPane.SetUIPosition(
true,
primVideoLeft,
primVideoTop,
primVideoWidth,
primVideoHeight );
this.panoVideoPane.SetUIPosition(
true,
panoVideoLeft,
panoVideoTop,
panoVideoWidth,
panoVideoHeight );
this.indexPane.SetUIPosition(
true,
indexLeft,
indexTop,
indexWidth,
indexHeight );
this.dataPane.SetUIPosition(
true,
dataLeft,
dataTop,
dataWidth,
dataHeight );
this.notesPane.SetUIPosition(
true,
notesLeft,
notesTop,
notesWidth,
notesHeight );
this.qaPane.SetUIPosition(
true,
qaLeft,
qaTop,
qaWidth,
qaHeight );
this.dataSplitter.SetUIPosition(
true,
dataSplitterLeft,
dataSplitterTop,
dataSplitterWidth,
dataSplitterHeight );
}
PlaybackPane.prototype.ShowIndexPane = function( show, holdRefresh )
{
this.indexPane.SetStyle( "visibility",  show );
this._ChangeMainSplitterVisibility();
if( !holdRefresh )
{
this._ResizePanes();
}
}
PlaybackPane.prototype.ShowPrimVideoPane = function( show, holdRefresh )
{
this.primVideoPane.SetStyle( "visibility",  show );
this._ChangeMainSplitterVisibility();
if( !holdRefresh )
{
this._ResizePanes();
}
}
PlaybackPane.prototype.ShowPanoVideoPane = function( show, holdRefresh )
{
this.panoVideoPane.SetStyle( "visibility",  show );
this._ChangeMainSplitterVisibility();
if( !holdRefresh )
{
this._ResizePanes();
}
}
PlaybackPane.prototype.ShowQAPane = function( show, holdRefresh )
{
this.qaPane.SetStyle( "visibility",  show );
if( show == "hidden" )
{
this.qaPane.SetStyle( "display", "none" );
}
else
{
this.qaPane.SetStyle( "display", "block" );
}
this._ChangeDataSplitterVisibility();
if( !holdRefresh )
{
this._ResizePanes();
}
}
PlaybackPane.prototype.ShowNotesPane = function( show, holdRefresh )
{
this.notesPane.SetStyle( "visibility",  show );
if( show == "hidden" )
{
this.notesPane.SetStyle( "display", "none" );
}
else
{
this.notesPane.SetStyle( "display", "block" );
}
this._ChangeDataSplitterVisibility();
if( !holdRefresh )
{
this._ResizePanes();
}
}
PlaybackPane.prototype._ChangeMainSplitterVisibility = function()
{
if( this.primVideoPane._htmlObject.style.visibility == "hidden" &&
this.indexPane._htmlObject.style.visibility == "hidden" )
{
this.mainVertSplitter.SetStyle( "visibility",  "hidden" );
}
else
{
this.mainVertSplitter.SetStyle( "visibility",  "inherit" );
}
if( this.primVideoPane._htmlObject.style.visibility == "hidden" &&
this.panoVideoPane._htmlObject.style.visibility == "hidden" )
{
this.mainHorzSplitter.SetStyle( "visibility",  "hidden" );
}
else
{
this.mainHorzSplitter.SetStyle( "visibility",  "inherit" );
}
}
PlaybackPane.prototype._ChangeDataSplitterVisibility = function()
{
if( this.qaPane._htmlObject.style.visibility == "hidden" &&
this.notesPane._htmlObject.style.visibility == "hidden" )
{
this.dataSplitter.SetStyle( "visibility",  "hidden" );
}
else
{
this.dataSplitter.SetStyle( "visibility",  "inherit" );
}
}
Trace.Wrap( "PlaybackPane" );
function NotificationPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this._notificationQueue = new Array();
this._queueLengthMax = UISettings.notificationQueueLengthMax;
this._overflowFlag = false;
this._disabled = false;
this._notificationText = new TextWidget();
this._launchTimer = null;
this._autoCloser = new AutoCloser( this, UISettings.notificationCloseTimeout );
this._notificationCount = 0;
this._Created.Add( Delegate( this, NotificationPane.prototype._WidgetCreated ) );
this._Destroyed.Add( Delegate( this, NotificationPane.prototype._WidgetDestroyed ) );
this._Resized.Add( Delegate( this, NotificationPane.prototype._WidgetResized ) );
}
OOP.Inherit( NotificationPane, BasicPane );
NotificationPane.prototype._WidgetCreated = function()
{
this._notificationText.Create( this, UISettings.notificationTextId );
this._notificationText.SetBorder( "solid", 1, 1, 1, 1 );
this._notificationText.SetStyle( "borderColor", UISettings.notificationBorderColor );
this._notificationText.SetStyle( "overflow", "auto" );
this._notificationText.SetTabIndex( UISettings.tabIndexDisable );
this.SetStyle( "backgroundColor", UISettings.notificationBackgroundColor );
this.SetBorder( "solid", 1, 1, 1, 1 );
this.SetStyle( "visibility", "hidden" );
this._launchTimer = setInterval(
Delegate( this, NotificationPane.prototype._OnLaunchTimer ),
UISettings.notificationLaunchTimeout );
}
NotificationPane.prototype._WidgetDestroyed = function()
{
if( this._launchTimer )
{
clearInterval( this._launchTimer );
}
}
NotificationPane.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
var padding = UISettings.notificationPadding;
var textLeft = padding;
var textTop = padding;
var textWidth = clientWidth - textLeft - padding;
var textHeight = clientHeight - textTop - padding;
if( textWidth < 0 || textHeight < 0 )
{
Trace.WriteLine( "The text width or height less than 0. Width: " + textWidth + " Height: " + textHeight );
return;
}
this._notificationText.SetUIPosition(
true,
textLeft,
textTop,
textWidth,
textHeight );
}
NotificationPane.prototype.AddNotification = function( msg )
{
this._notificationCount ++;
this._notificationQueue.push( msg );
if( this._notificationQueue.length > 10000 )
{
this._notificationQueue.shift();
this._overflowFlag = true;
}
}
NotificationPane.prototype.Disable = function( disable )
{
this._disabled = disable;
}
NotificationPane.prototype._RefreshNotificationText = function()
{
var str = "";
var count = this._notificationCount;
for( var i=this._notificationQueue.length - 1; i>=0; i--, count -- )
{
var msg = count + ": " + this._notificationQueue[i];
str += msg + "\r\n";
}
if( this._overflowFlag )
{
str += "\r\nThere are more notification messages here, we ignored them because the buffer of message has been full. ";
}
this._notificationText.SetText( str, true );
this._overflowFlag = false;
}
NotificationPane.prototype._OnLaunchTimer = function()
{
if( this._notificationQueue.length > 0 && !this._disabled )
{
this._RefreshNotificationText();
this._autoCloser.LaunchTarget();
}
}
function ConfirmPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this._disabled = false;
this._autoCloser = new AutoCloser( this, UISettings.confirmCloseTimeout );
this._paneArea = new BasicWidget();
this._buttonArea = new BasicWidget();
this._okButton = new TextButton();
this._cancelButton = new TextButton();
this._promptText = new TextWidget();
this._componentText = new TextWidget();
this._disableCheckBox = new CheckWidget();
this._checkBoxText = new TextWidget();
this._callbackFunc = null;
this.iframeLoadedEvent.Add( Delegate( this, ConfirmPane.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, ConfirmPane.prototype._WidgetResized ) );
}
OOP.Inherit( ConfirmPane, IFrameWidget );
ConfirmPane.prototype._WidgetCreated = function()
{
this.CreateChildWidget( this._paneArea, this.GetId() );
this._promptText.Create( this._paneArea );
this._componentText.Create( this._paneArea );
this._checkBoxText.Create( this._paneArea );
this._disableCheckBox.Create( this._paneArea );
this._buttonArea.Create( this._paneArea, UISettings.confirmButtonAreaId );
this._okButton.Create( this._buttonArea );
this._cancelButton.Create( this._buttonArea );
this._buttonArea.SetStyle( "position", "absolute" );
this._okButton.SetStyle( "position", "absolute" );
this._cancelButton.SetStyle( "position", "absolute" );
this._promptText.SetStyle( "position", "relative" );
this._promptText.SetStyle("paddingTop", UISettings.confirmPanePromptTextPaddingTop);
this._promptText.SetStyle( "paddingLeft", UISettings.confirmPanePromptTextPaddingLeft );
this._componentText.SetStyle( "position", "relative" );
this._componentText.SetStyle( "paddingTop", UISettings.confirmPaneComponentTextPaddingTop );
this._componentText.SetStyle( "paddingLeft", UISettings.confirmPaneComponentTextPaddingLeft );
this._componentText.SetStyle( "paddingBottom", UISettings.confirmPaneComponentTextPaddingBottom );
this._disableCheckBox.SetTabIndex( UISettings.tabIndexDefault );
this._disableCheckBox.SetStyle( "position", "absolute" );
this._checkBoxText.SetStyle( "position", "relative" );
var disableCheckBoxWidth = this._disableCheckBox.GetWidth();
var checkBoxTextPaddingLeft =
UISettings.confirmPaneCheckBoxPaddingLeft
+ disableCheckBoxWidth
+ UISettings.confirmPaneCheckBoxPaddingRight;
this._checkBoxText.SetStyle( "paddingLeft",checkBoxTextPaddingLeft );
this._promptText.SetStyle( "display", "block" );
this._componentText.SetStyle( "display", "block" );
this._checkBoxText.SetStyle( "display", "block" );
this._okButton.SetTabIndex( UISettings.tabIndexDefault );
this._okButton.SetStyle( "display", "block" );
this._okButton.SetItemClassName( "left", "ButtonLeft" );
this._okButton.SetItemClassName( "middle", "ButtonMiddle" );
this._okButton.SetItemClassName( "right", "ButtonRight" );
this._okButton.ApplyDomClasses();
this._cancelButton.SetTabIndex( UISettings.tabIndexDefault );
this._cancelButton.SetStyle( "display", "block" );
this._cancelButton.SetItemClassName( "left", "ButtonLeft" );
this._cancelButton.SetItemClassName( "middle", "ButtonMiddle" );
this._cancelButton.SetItemClassName( "right", "ButtonRight" );
this._cancelButton.ApplyDomClasses();
this._okButton.SetText(
LocaleInfo.GetText( UISettings.confirmPaneOkButtonText ) );
this._cancelButton.SetText(
LocaleInfo.GetText( UISettings.confirmPaneCancelButtonText ) );
this._okButton.SetAttribute(
"title",
LocaleInfo.GetText( UISettings.confirmPaneOkButtonText ) );
this._cancelButton.SetAttribute(
"title",
LocaleInfo.GetText( UISettings.confirmPaneCancelButtonText ) );
this._okButton.FitTextWidth();
this._cancelButton.FitTextWidth();
var paddingRight = UISettings.confirmPaneButtonAreaWidth;
var okButtonWidth = this._okButton.GetWidth();
var cancelButtonWidth = this._cancelButton.GetWidth();
var realWidth = okButtonWidth
+ cancelButtonWidth
+ 2*UISettings.confirmPaneButtonDistance
+UISettings.confirmPaneButtonAreaMarginRight;
if( UISettings.confirmPaneButtonAreaWidth > realWidth )
{
paddingRight = realWidth;
}
this._promptText.SetStyle( "paddingRight", paddingRight );
this._componentText.SetStyle( "paddingRight", paddingRight );
this._checkBoxText.SetStyle( "paddingRight", paddingRight );
this._promptText.SetText( LocaleInfo.GetText( UISettings.confirmPanePromptText ) );
this._componentText.EnableMultipleLines( false );
this._componentText.SetText( LocaleInfo.GetText( UISettings.confirmPaneDefaultMsgId ) );
this._checkBoxText.SetText( LocaleInfo.GetText( UISettings.confirmPaneCheckBoxText)  );
this.SetStyle( "visibility", "hidden" );
this.SetStyle( "backgroundColor", UISettings.confirmBackgroundColor );
this.SetBorder( "solid", 1, 1, 1, 1 );
this._disableCheckBox.RegisterEvent(
"onclick",
Delegate( this, ConfirmPane.prototype._OnCheckStateChanged ) );
this._disableCheckBox.RegisterEvent(
"onkeydown",
Delegate( this, ConfirmPane.prototype._OnKeyDownOnDisableCheckBox ) );
this._okButton.ClickEvent.Add( Delegate( this, ConfirmPane.prototype._OnOK ) );
this._cancelButton.ClickEvent.Add( Delegate( this, ConfirmPane.prototype._OnCancel ) );
this._autoCloser.AutoClosedEvent.Add( Delegate( this, ConfirmPane.prototype._OnAutoClosed ) );
}
ConfirmPane.prototype._WidgetResized = function()
{
if( !this.iframeIsLoaded )
{
return;
}
var clientWidth = this.GetClientWidth();
var clientHeight = this.GetClientHeight();
this._paneArea.SetUIPosition( true, 0, 0, clientWidth, clientHeight );
var heightOfDisableCheckBox = this._disableCheckBox.GetHeight();
var heightOfCheckBoxText = this._checkBoxText.GetHeight();
var disableCheckBoxTop = 0;
if( heightOfDisableCheckBox >= heightOfCheckBoxText )
{
disableCheckBoxTop = clientHeight - heightOfDisableCheckBox - UISettings.confirmPaneCheckBoxPaddingBottom;
}
else
{
disableCheckBoxTop = clientHeight - heightOfCheckBoxText
- UISettings.confirmPaneCheckBoxPaddingBottom;
}
this._disableCheckBox.SetLocation( UISettings.confirmPaneCheckBoxPaddingLeft, disableCheckBoxTop );
var buttonAreaHeight = this._buttonArea.GetHeight();
var okButtonWidth = this._okButton.GetWidth();
var cancelButtonWidth = this._cancelButton.GetWidth();
var buttonAreaWidth = UISettings.confirmPaneButtonAreaWidth;
var buttonAreaTop = clientHeight - buttonAreaHeight - UISettings.confirmPaneButtonAreaMarginBottom;
var buttonAreaLeft = clientWidth - buttonAreaWidth;
this._buttonArea.SetUIPosition(true,buttonAreaLeft,buttonAreaTop,buttonAreaWidth,buttonAreaHeight);
var buttonTop = 0;
var buttonLeft = 0;
if( UISettings.confirmPaneButtonAreaWidth >
(okButtonWidth
+ cancelButtonWidth
+ 2*UISettings.confirmPaneButtonDistance
+UISettings.confirmPaneButtonAreaMarginRight )
)
{
buttonLeft = buttonAreaWidth - UISettings.confirmPaneButtonAreaMarginRight - cancelButtonWidth;
this._cancelButton.SetUIPosition( true, buttonLeft, buttonTop, cancelButtonWidth, buttonAreaHeight );
buttonLeft = buttonLeft - UISettings.confirmPaneButtonDistance - okButtonWidth;
this._okButton.SetUIPosition( true, buttonLeft, buttonTop, okButtonWidth, buttonAreaHeight );
}
else
{
var buttonWidth = (buttonAreaWidth
- (2*UISettings.confirmPaneButtonDistance +UISettings.confirmPaneButtonAreaMarginRight )
)/2;
buttonLeft = buttonAreaWidth -UISettings.confirmPaneButtonAreaMarginRight -buttonWidth;
this._cancelButton.SetUIPosition( true, buttonLeft, buttonTop, buttonWidth, buttonAreaHeight );
buttonLeft = buttonLeft - UISettings.confirmPaneButtonDistance - buttonWidth;
this._okButton.SetUIPosition( true, buttonLeft, buttonTop, buttonWidth, buttonAreaHeight );
}
}
ConfirmPane.prototype.ShowMessage = function( msgId, callbackFunc )
{
if( this._disabled )
{
return;
}
if( this._callbackFunc != null )
{
return;
}
this._componentText.SetText( LocaleInfo.GetText( msgId + "") );
this._disableCheckBox.SetAttribute( "checked", false );
this._autoCloser.LaunchTarget();
this._callbackFunc = callbackFunc;
this._disableCheckBox.SetFocus();
}
ConfirmPane.prototype._OnCheckStateChanged = function()
{
var checked = this._disableCheckBox.GetAttribute( "checked" );
this._autoCloser.Enable( false );
this._disabled = checked;
}
ConfirmPane.prototype._OnOK = function()
{
this._autoCloser.CloseTarget();
this._FireReturnEvent( MeetingSettings.DID.Yes );
}
ConfirmPane.prototype._OnCancel = function()
{
this._autoCloser.CloseTarget();
this._FireReturnEvent( MeetingSettings.DID.No );
}
ConfirmPane.prototype._OnAutoClosed = function()
{
this._FireReturnEvent( MeetingSettings.DID.No );
}
ConfirmPane.prototype._FireReturnEvent = function( eventId )
{
if( this._callbackFunc != null )
{
var checked = this._disableCheckBox.GetAttribute( "checked" );
if( checked )
{
eventId += MeetingSettings.DID.Always;
}
setTimeout( DelegateWithArgs( null, this._callbackFunc, eventId ) , 0 );
this._callbackFunc = null;
}
}
ConfirmPane.prototype.GetPaneHeight = function()
{
if( !this.iframeIsLoaded )
{
return 0;
}
var heightOfPromptText = this._promptText.GetHeight();
var heightOfComponentText = this._componentText.GetHeight();
var heightOfCheckBoxText = this._checkBoxText.GetHeight();
var heightOfDisableCheckBox = this._disableCheckBox.GetHeight();
return (heightOfPromptText
+ heightOfComponentText
+ (heightOfCheckBoxText>heightOfDisableCheckBox?heightOfCheckBoxText:heightOfDisableCheckBox)
+ UISettings.confirmPaneCheckBoxPaddingBottom);
}
ConfirmPane.prototype._OnKeyDownOnDisableCheckBox = function( eventObj )
{
eventObj = BasicWidget.TranslateEvent( eventObj, this._disableCheckBox._htmlObject );
var theKey = BasicWidget.GetKey( eventObj );
if( theKey == KeyTable.VK_SPACE || theKey == KeyTable.VK_RETURN)
{
this._OnCheckStateChanged();
}
}
function ErrorPane()
{
OOP.CallParentConstructor( this, arguments.callee );
this._text = new TextWidget();
this._button = new TextButton();
this._buttonArea = new BasicWidget();
this._Created.Add( Delegate( this, ErrorPane.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, ErrorPane.prototype._WidgetResized ) );
}
OOP.Inherit( ErrorPane, BasicWidget );
ErrorPane.prototype._WidgetCreated = function()
{
this._text.Create( this, UISettings.errorPaneTextBoxId );
this._buttonArea.Create( this );
this._button.Create( this._buttonArea, UISettings.errorPaneButtonId );
this._text.SetStyle( "position", "relative" );
this._buttonArea.SetHeight( this._button.GetHeight() );
this._buttonArea.SetStyle( "position", "relative" );
this._button.SetText(
LocaleInfo.GetText( UISettings.errorPaneButtonText ) );
this._button.SetAttribute(
"title",
LocaleInfo.GetText( UISettings.errorPaneButtonTooltip ) );
this._button.FitTextWidth();
this._button.SetTabIndex( UISettings.tabIndexDefault );
this._button.SetItemClassName( "left", "ButtonLeft" );
this._button.SetItemClassName( "middle", "ButtonMiddle" );
this._button.SetItemClassName( "right", "ButtonRight" );
this._button.ApplyDomClasses();
this._button.ClickEvent.Add( Delegate( this, ErrorPane.prototype._ButtonClicked ) );
}
ErrorPane.prototype._WidgetResized = function()
{
var clientWidth = this.GetClientWidth();
var buttonWidth = this._button.GetWidth();
var buttonHeight = this._button.GetHeight();
this._text.SetWidth( clientWidth );
this._buttonArea.SetWidth( clientWidth );
var top = 0;
var left = ( clientWidth - buttonWidth ) / 2;
this._button.SetUIPosition( true,left, top,buttonWidth,buttonHeight );
}
ErrorPane.prototype._ButtonClicked = function()
{
window.close();
}
ErrorPane.prototype.SetText = function( text )
{
this._text.SetText( text, true );
}
Trace.Wrap( "ErrorPane" );
function MainFrame()
{
OOP.CallParentConstructor( this, arguments.callee );
this.brandArea = new BasicWidget();
this.workArea = new BasicWidget();
this.brandPane = new BrandPane();
this.downloadFrame = new DownloadPane();
this.playbackFrame = new PlaybackPane();
this.notificationPane = new NotificationPane();
this.confirmPane = new ConfirmPane();
this.errorPane = new ErrorPane();
this._originalWidth = 0;
this._originalHeight = 0;
this._downloadFrameBeingShown = false;
this._downloadFrameRealHeight = -1;
this._resizeEventCounter = 0;
this.borderFrame = document.getElementById(UISettings.borderFrameId);
this._Created.Add( Delegate( this, MainFrame.prototype._WidgetCreated ) );
this._Resized.Add( Delegate( this, MainFrame.prototype._WidgetResized ) );
}
OOP.Inherit( MainFrame, BasicPane );
MainFrame.prototype._WidgetCreated = function()
{
this.brandArea.AttachById( UISettings.brandAreaId, this );
this.workArea.AttachById( UISettings.workAreaId, this );
this.brandArea._htmlObject.innerHTML = "";
this.workArea._htmlObject.innerHTML = "";
this.brandPane.Create( this.brandArea, UISettings.brandPaneId );
UIManager.WindowResizedEvent.Add( Delegate( this, this._OnWindowResized ) );
}
MainFrame.prototype._GetHeightMin = function()
{
var minHeight = UISettings.mainFrameHeightMin;
if( this._downloadFrameBeingShown )
{
var brandPaneHeight = this.brandArea.GetClientHeight();
var expectedHeight = this._downloadFrameRealHeight + brandPaneHeight;
if(  (this._downloadFrameRealHeight > 0)
&&  ( expectedHeight > UISettings.mainFrameHeightMin ) )
{
minHeight = expectedHeight;
}
else
{
}
}
else
{
}
return minHeight;
}
MainFrame.prototype._OnWindowResized = function()
{
var size = this._CalculateClientSize();
var clientWidth = size.clientWidth;
var clientHeight = size.clientHeight;
if( clientWidth == this._originalWidth && clientHeight == this._originalHeight )
{
return;
}
else
{
this._originalWidth = clientWidth;
this._originalHeight = clientHeight;
}
this._resizeEventCounter = this._resizeEventCounter + 1;
setTimeout(DelegateWithArgs( this, MainFrame.prototype._ChangeSize, clientWidth, clientHeight ), 0 );
}
MainFrame.prototype._ChangeSize = function(width,height)
{
this._resizeEventCounter = this._resizeEventCounter - 1;
if( this._resizeEventCounter != 0 )
{
return;
}
var clientWidth = this._GetWindowClientWidth();
var clientHeight = this._GetWindowClientHeight();
if(clientWidth>width)
{
this.borderFrame.style.width = clientWidth;
}
else
{
clientWidth = width;
}
if(clientHeight>height)
{
this.borderFrame.style.height = clientHeight;
}
else
{
clientHeight = height;
}
this.SetSize( clientWidth, clientHeight );
}
MainFrame.prototype._GetWindowClientWidth = function()
{
if(NavigatorInfo.IsMozilla())
{
return window.innerWidth;
}
else
{
return document.body.clientWidth;
}
}
MainFrame.prototype._GetWindowClientHeight = function()
{
if(NavigatorInfo.IsMozilla())
{
return window.innerHeight;
}
else
{
return document.body.clientHeight;
}
}
MainFrame.prototype._CalculateClientSize = function()
{
this.borderFrame.style.width = 1;
this.borderFrame.style.height = 1;
var clientWidth = 0;
var clientHeight = 0;
clientWidth = this._GetWindowClientWidth();
clientHeight = this._GetWindowClientHeight();
var scrollNeeded = false;
var widthMin = UISettings.mainFrameWidthMin;
var heightMin = this._GetHeightMin();
if( clientWidth < widthMin )
{
scrollNeeded = true;
clientWidth = widthMin;
this.borderFrame.style.width = clientWidth;
clientHeight = this._GetWindowClientHeight();
if( clientHeight < heightMin )
{
clientHeight = heightMin;
}
this.borderFrame.style.height = clientHeight;
}
else
if( clientHeight < heightMin )
{
scrollNeeded = true;
clientHeight = heightMin;
this.borderFrame.style.height = clientHeight;
clientWidth = this._GetWindowClientWidth();
if( clientWidth < widthMin )
{
clientWidth = widthMin;
}
this.borderFrame.style.width = clientWidth;
}
else
{
this.borderFrame.style.width = clientWidth;
this.borderFrame.style.height = clientHeight;
}
return { "clientWidth":clientWidth, "clientHeight":clientHeight, "scrollNeeded":scrollNeeded };
}
MainFrame.prototype._WidgetResized = function()
{
var clientHeight = this.GetClientHeight();
var brandAreaWidth = this.brandArea.GetClientWidth();
var brandAreaHeight = this.brandArea.GetClientHeight();
var workAreaWidth = this.workArea.GetClientWidth();
var workAreaHeight = clientHeight - brandAreaHeight;
this.workArea.SetHeight( workAreaHeight );
var brandLeft = 0;
var brandTop = 0;
var brandWidth = brandAreaWidth;
var brandHeight = brandAreaHeight;
this.brandPane.SetUIPosition(
true,
brandLeft,
brandTop,
brandWidth,
brandHeight );
var contentLeft = 0;
var contentTop = 0;
var contentWidth = workAreaWidth;
var contentHeight = workAreaHeight;
if( this.playbackFrame._htmlObject && !this._downloadFrameBeingShown )
{
this.playbackFrame.SetUIPosition(
true,
contentLeft,
contentTop,
contentWidth,
contentHeight );
}
if( this.downloadFrame._htmlObject && this._downloadFrameBeingShown )
{
this.downloadFrame.SetUIPosition(
true,
contentLeft,
contentTop,
contentWidth,
contentHeight );
var downloadFrameScrollHeight = this.downloadFrame.GetScrollHeight();
if( downloadFrameScrollHeight > this.downloadFrame.GetHeight() )
{
setTimeout( DelegateWithArgs( this, MainFrame.prototype._AdjustDownloadFrameSize, downloadFrameScrollHeight ), 0 );
}
}
if( this.errorPane._htmlObject )
{
this.errorPane.SetUIPosition(
true,
contentLeft,
contentTop,
contentWidth,
contentHeight );
}
var notificationOffset = 40;
var notificationWidth = 320;
var notificationHeight = 240;
var notificationLeft = workAreaWidth - notificationWidth - notificationOffset;
var notificationTop = workAreaHeight - notificationHeight - notificationOffset;
if( notificationLeft < 0 || notificationTop < 0 )
{
return;
}
if( this.notificationPane._htmlObject )
{
this.notificationPane.SetUIPosition(
true,
notificationLeft,
notificationTop,
notificationWidth,
notificationHeight );
}
if( this.confirmPane._htmlObject )
{
var confirmWidth = UISettings.confirmPaneWidth;
var confirmHeight = this.confirmPane.GetPaneHeight();
var confirmLeft = ( workAreaWidth - confirmWidth ) / 2;
var confirmTop = ( workAreaHeight - confirmHeight ) / 2;
this.confirmPane.SetUIPosition(
true,
confirmLeft,
confirmTop,
confirmWidth,
confirmHeight );
}
}
MainFrame.prototype._AdjustDownloadFrameSize = function ( expectHeight )
{
this._downloadFrameRealHeight = expectHeight;
document.body.scrollLeft = 0;
document.body.scrollTop = 0;
this._OnWindowResized();
this._OnWindowResized();
}
MainFrame.prototype.PrepareAssistantFrames = function()
{
this.errorPane.Create( this.workArea, UISettings.errorPaneId );
this.errorPane.SetStyle( "position", "absolute" );
this.errorPane.SetStyle( "overflow", "auto" );
this.errorPane.SetStyle( "zIndex", 65535 );
this.errorPane.SetStyle( "visibility", "hidden" );
this.notificationPane.Create( this.workArea, UISettings.notificationPaneId );
this.notificationPane.SetStyle( "zIndex", 65533 );
this.notificationPane.SetStyle( "position", "absolute" );
this.confirmPane.Create( this.workArea, UISettings.confirmPaneId );
this.confirmPane.SetStyle( "zIndex", 65534 );
this.confirmPane.SetStyle( "position", "absolute" );
this._OnResize();
}
MainFrame.prototype.PrepareDownloadFrame =  function()
{
this.downloadFrame.Create( this.workArea, UISettings.downloadFrameId );
this.downloadFrame.NeedResizeEvent.Add( Delegate( this, MainFrame.prototype._AdjustDownloadFrameSize ) );
this.downloadFrame.SetStyle( "visibility",  "hidden" );
}
MainFrame.prototype.PreparePlaybackFrame =  function()
{
this.playbackFrame.Create( this.workArea, UISettings.playbackFrameId );
this.playbackFrame.SetStyle( "visibility",  "hidden" );
}
MainFrame.prototype.ShowPlaybackFrame =  function()
{
this._downloadFrameBeingShown = false;
if( this._downloadFrameRealHeight == -1 )
{
this._Resized();
}
else
{
this._originalWidth = 0;
this._originalHeight = 0;
this._OnWindowResized();
}
this.playbackFrame.SetStyle( "visibility",  "inherit" );
this.downloadFrame.SetStyle( "visibility",  "hidden" );
}
MainFrame.prototype.ShowDownloadFrame =  function()
{
this._downloadFrameBeingShown = true;
this.downloadFrame.SetStyle( "visibility",  "inherit" );
if( this.playbackFrame._htmlObject )
{
this.playbackFrame.SetStyle( "visibility",  "hidden" );
}
this._OnResize();
}
MainFrame.prototype.ShowErrorMsg = function( msg )
{
if( this.errorPane._htmlObject != null )
{
this.errorPane.SetText( msg );
this.errorPane.SetStyle( "visibility", "inherit" );
}
else
{
if( window.confirm( msg + "\r\n\r\nClick OK to close playback window. \r\nClick Cancel to keep the current playback window but the playback will stop. " ) )
{
window.close();
}
}
}
MainFrame.prototype.ShowWarningMsg = function( msg )
{
this.notificationPane.AddNotification( msg );
}
MainFrame.prototype.PromptExclusiveMessage = function( msgId, callbackFunc )
{
this.confirmPane.ShowMessage( msgId, callbackFunc );
}
Trace.Wrap( "MainFrame" );
function ScrollingText()
{
this._text = "";
this._timer = null;
this.TextUpdated = new Event();
}
ScrollingText.updateInterval = 100;
ScrollingText.minScrollingLength = 40;
ScrollingText.tailSpaces = "          ";
ScrollingText.prototype.SetText = function( text )
{
if( text == null || text == "" )
{
this._text = "";
if( this._timer != null )
{
clearInterval( this._timer );
this._timer = null;
}
this._UpdateText();
return;
}
this._text = text + ScrollingText.tailSpaces;
if( this._timer == null )
{
this._timer = setInterval(
Delegate( this, ScrollingText.prototype._OnTimer ),
ScrollingText.updateInterval );
}
}
ScrollingText.prototype._OnTimer = function()
{
if( this._text.length > ScrollingText.minScrollingLength + ScrollingText.tailSpaces.length )
{
this._text = this._text.substr( 1 ) + this._text.substr( 0, 1 );
}
this._UpdateText();
}
ScrollingText.prototype._UpdateText = function()
{
this.TextUpdated( this._text );
}
function UIObjects()
{
OOP.CallParentConstructor( this, arguments.callee );
this._mainFrame = new MainFrame();
this._meetingInfo = null;
this._eventManager = new EventsManager();
this._eventManager.AddEvent( "Play" );
this._eventManager.AddEvent( "Stop" );
this._eventManager.AddEvent( "Pause" );
this._eventManager.AddEvent( "Next" );
this._eventManager.AddEvent( "Prev" );
this._eventManager.AddEvent( "Mute" );
this._eventManager.AddEvent( "Unmute" );
this._eventManager.AddEvent( "SeekToTime" );
this._eventManager.AddEvent( "SetVolume" );
this._eventManager.AddEvent( "JumpToIndex" );
this._eventManager.AddEvent( "EnableSpeaker" );
this._eventManager.AddEvent( "EnableAllSpeakers" );
this._eventManager.AddEvent( "SetIndexCategory" );
this._eventManager.AddEvent( "EnableQCIFVideo" );
this._eventManager.AddEvent( "EnablePanoVideo" );
this._eventManager.AddEvent( "EnableIndex" );
this._eventManager.AddEvent( "EnableQA" );
this._eventManager.AddEvent( "EnableNotes" );
this._eventHandlers = new Object();
this._eventHandlers[ "MeetingBuffering" ] = Delegate( this, this._MeetingBuffering );
this._eventHandlers[ "MeetingStarted" ] = Delegate( this, this._MeetingStarted );
this._eventHandlers[ "MeetingStopped" ] = Delegate( this, this._MeetingStopped );
this._eventHandlers[ "MeetingPaused" ] = Delegate( this, this._MeetingPaused );
this._eventHandlers[ "MeetingMuted" ] = Delegate( this, this._MeetingMuted );
this._eventHandlers[ "TimeChanged" ] = Delegate( this, this._TimeChanged );
this._eventHandlers[ "VolumeChanged" ] = Delegate( this, this._VolumeChanged );
this._eventHandlers[ "SpeakerChanged" ] = Delegate( this, this._SpeakerChanged );
this._eventHandlers[ "BizcardChanged" ] = Delegate( this, this._BizcardChanged );
this._eventHandlers[ "SpeakerIndexChanged" ] = Delegate( this, this._SpeakerIndexChanged );
this._eventHandlers[ "ContentIndexChanged" ] = Delegate( this, this._ContentIndexChanged );
this._eventHandlers[ "SpeakerEnabled" ] = Delegate( this, this._SpeakerEnabled );
this._eventHandlers[ "SpeakerAllEnabled" ] = Delegate( this, this._AllSpeakersEnabled );
this._eventHandlers[ "IndexCategoryChanged" ] = Delegate( this, this._IndexCategoryChanged );
this._eventHandlers[ "QAChanged" ] = Delegate( this, this._QAChanged );
this._eventHandlers[ "QCIFVideoEnabled" ] = Delegate( this, this._QCIFVideoEnabled );
this._eventHandlers[ "PanoVideoEnabled" ] = Delegate( this, this._PanoVideoEnabled );
this._eventHandlers[ "IndexEnabled" ] = Delegate( this, this._IndexEnabled );
this._eventHandlers[ "QAEnabled" ] = Delegate( this, this._QAEnabled );
this._eventHandlers[ "NotesEnabled" ] = Delegate( this, this._NotesEnabled );
this._eventHandlers[ "DataAvailable" ] = Delegate( this, this._DataAvailableHandler );
this.StartFrameCompleteEvent = new Event();
this.PrepareDownloadFrameCompletedEvent = new Event();
this.SettingCheckingCompleteEvent = new Event();
this.ShowDownloadCompleteEvent = new Event();
this.PreparePlaybackFrameCompletedEvent = new Event();
this._panes = new Object();
this._renderers = new Object();
this._statusText = new ScrollingText();
this._globalInfo = new GradedInfo( "" );
this._objectsReadyChecker = new EventsReadyChecker();
}
UIObjects.prototype.Initialize = function()
{
UIManager.Create();
this._statusText.TextUpdated.Add(
Delegate( this, UIObjects.prototype._StatusTextUpdated ) );
this._globalInfo.InfoChanged.Add(
Delegate( this, UIObjects.prototype._GlobalInfoChanged ) );
HTMLWidget.defaultBlankPageUri = g_lmEngineRoot + "blank.htm";
MmcRenderer.defaultBlankPageUri = g_lmEngineRoot + "MmcRenderer.htm";
ASRenderer.defaultBlankPageUri = g_lmEngineRoot + "MmcRenderer.htm";
ClipWidget.defaultBlankPageUri = g_lmEngineRoot + "ClipWidget.htm";
IFrameWidget.defaultBlankPageUri = g_lmEngineRoot + "BlankWithCss.htm";
FlashWidget.blankSwfUri = g_lmEngineRoot + "blank.swf";
WmvWidget.blankWmvUri = g_lmEngineRoot + "blank.wmv";
this._mainFrame.AttachById( UISettings.mainFrameId );
UIManager.OnWindowResized();
}
UIObjects.prototype._StatusTextUpdated = function( text )
{
window.status = text;
}
UIObjects.prototype.PrepareAssistantFrames = function()
{
this._mainFrame.PrepareAssistantFrames();
}
UIObjects.prototype.PrepareDownloadFrame = function()
{
this._mainFrame.PrepareDownloadFrame();
this._mainFrame.downloadFrame.SetMeetingInfo( this._meetingInfo, false );
this.PrepareDownloadFrameCompletedEvent();
}
UIObjects.prototype.ShowDownloadFrame = function()
{
this._mainFrame.ShowDownloadFrame();
this.ShowDownloadCompleteEvent();
}
UIObjects.prototype._AudioInfoChanged = function( str )
{
var audioPrefix = LocaleInfo.GetText(
UISettings.WmvError_AudioErrorPrefix );
if( str != null && str != "" )
{
str = audioPrefix + " - " + str;
}
this._globalInfo.SetInformation(
GradedInfo.grades.warning,
str );
}
UIObjects.prototype.PreparePlaybackFrame = function()
{
this._mainFrame.PreparePlaybackFrame();
this._mainFrame.playbackFrame.audioRenderer.gradedInfo.InfoChanged.Add(
Delegate( this, UIObjects.prototype._AudioInfoChanged ) );
this._panes[ "PanoVideo" ] = this._mainFrame.playbackFrame.panoVideoPane;
this._panes[ "Data" ] = this._mainFrame.playbackFrame.dataPane;
this._renderers[ "Audio" ] = this._mainFrame.playbackFrame.audioRenderer;
this._renderers[ "PanoVideo" ] = this._mainFrame.playbackFrame.panoVideoPane.renderer.avRenderer;
this._renderers[ "QCIFVideo" ] = this._mainFrame.playbackFrame.primVideoPane.renderer.avRenderer;
this._renderers[ "QA" ] = this._mainFrame.playbackFrame.qaPane.renderer;
this._renderers[ "Notes" ] = this._mainFrame.playbackFrame.notesPane.renderer;
this._renderers[ "Index" ] = null;
this._renderers[ "Start" ] = this._mainFrame.playbackFrame.dataPane.renderers[ UISettings.dummyRendererId ];
this._renderers[ "Ppt" ] = this._mainFrame.playbackFrame.dataPane.renderers[ UISettings.pptRendererId ];
this._renderers[ "Text" ] = this._mainFrame.playbackFrame.dataPane.renderers[ UISettings.textRendererId ];
this._renderers[ "Image" ] = this._mainFrame.playbackFrame.dataPane.renderers[ UISettings.imageRendererId ];
this._renderers[ "Modi" ] = this._mainFrame.playbackFrame.dataPane.renderers[ UISettings.modiRendererId ];
this._renderers[ "Poll" ] = this._mainFrame.playbackFrame.dataPane.renderers[ UISettings.pollRendererId ];
this._renderers[ "MMC" ] = this._mainFrame.playbackFrame.dataPane.renderers[ UISettings.mmcRendererId ];
this._renderers[ "Web" ] = this._mainFrame.playbackFrame.dataPane.renderers[ UISettings.webRendererId ];
this._renderers[ "Whiteboard" ] = this._mainFrame.playbackFrame.dataPane.renderers[ UISettings.whiteboardRendererId ];
this._renderers[ "AppSharing" ] = this._mainFrame.playbackFrame.dataPane.renderers[ UISettings.asRendererId ];
this._renderers[ "Anno" ] = this._mainFrame.playbackFrame.dataPane.annotationRenderer;
var playButton = this._mainFrame.playbackFrame.controlPane.playButtons.GetButton( UISettings.playButtonId );
playButton.ClickEvent.Add( Delegate( this, this._PlayButtonClicked ) );
var stopButton = this._mainFrame.playbackFrame.controlPane.playButtons.GetButton( UISettings.stopButtonId );
stopButton.ClickEvent.Add( this._eventManager.GetEvent( "Stop" ) );
var pauseButton = this._mainFrame.playbackFrame.controlPane.playButtons.GetButton( UISettings.pauseButtonId );
pauseButton.ClickEvent.Add( Delegate( this, this._PauseButtonClicked ) );
var nextButton = this._mainFrame.playbackFrame.controlPane.playButtons.GetButton( UISettings.nextButtonId );
nextButton.ClickEvent.Add( this._eventManager.GetEvent( "Next" ) );
var prevButton = this._mainFrame.playbackFrame.controlPane.playButtons.GetButton( UISettings.previousButtonId );
prevButton.ClickEvent.Add( this._eventManager.GetEvent( "Prev" ) );
var muteButton = this._mainFrame.playbackFrame.controlPane.playButtons.GetButton( UISettings.muteButtonId );
muteButton.ClickEvent.Add( Delegate( this, this._MuteButtonClicked ) );
var unmuteButton = this._mainFrame.playbackFrame.controlPane.playButtons.GetButton( UISettings.unmuteButtonId );
unmuteButton.ClickEvent.Add( Delegate( this, this._UnmuteButtonClicked ) );
var timeSlider = this._mainFrame.playbackFrame.controlPane.timeSlider;
timeSlider.ValueChangingEvent.Add( this._eventManager.GetEvent( "SeekToTime" ) );
var volumeSlider = this._mainFrame.playbackFrame.controlPane.volumeSlider;
volumeSlider.ValueChangingEvent.Add( this._eventManager.GetEvent( "SetVolume" ) );
var indexLists = this._mainFrame.playbackFrame.indexPane.indexLists;
var contentIndexList = indexLists[ MeetingSettings.Index.ContentName ];
contentIndexList.SingleItemSelectEvent.Add( this._eventManager.GetEvent( "JumpToIndex" ) );
var speakerIndexList = indexLists[ MeetingSettings.Index.SpeakerName ];
speakerIndexList.TimeItemSelectEvent.Add( this._eventManager.GetEvent( "JumpToIndex" ) );
speakerIndexList.EnableSpeakerEvent.Add( this._eventManager.GetEvent( "EnableSpeaker" ) );
speakerIndexList.EnableAllSpeakersEvent.Add( this._eventManager.GetEvent( "EnableAllSpeakers" ) );
var categoryList = this._mainFrame.playbackFrame.indexPane.categoryList;
categoryList.ActiveItemChangedEvent.Add( this._eventManager.GetEvent( "SetIndexCategory" ) );
var paneMenu = this._mainFrame.playbackFrame.controlPane.paneMenu.GetMenu( UISettings.paneMenuId );
var meetingDuration = this._meetingInfo.duration;
timeSlider.SetValueRange( 0, meetingDuration );
var paneMenuButton = this._mainFrame.playbackFrame.controlPane.paneMenu.GetItem (UISettings.paneMenuId );
categoryList._tabIndex = UISettings.tabIndexCategoryList;
contentIndexList._tabIndex = UISettings.tabIndexContentIndexList;
speakerIndexList._tabIndex = UISettings.tabIndexSpeakerIndexList;
timeSlider.SetTabIndex(UISettings.tabIndexTimeSlider);
paneMenuButton.SetTabIndex(UISettings.tabIndexPaneMenu);
playButton.SetTabIndex(UISettings.tabIndexPlayButton);
pauseButton.SetTabIndex(UISettings.tabIndexPauseButton);
stopButton.SetTabIndex(UISettings.tabIndexStopButton);
prevButton.SetTabIndex(UISettings.tabIndexPreviousButton);
nextButton.SetTabIndex(UISettings.tabIndexNextButton);
muteButton.SetTabIndex(UISettings.tabIndexMuteButton);
unmuteButton.SetTabIndex(UISettings.tabIndexUnmuteButton);
volumeSlider.SetTabIndex(UISettings.tabIndexVolumeSlider);
this._InitializeCodecMissingChecker();
this._InitializeObjectsReadyChecker();
}
UIObjects.prototype._InitializeCodecMissingChecker = function()
{
var qcifWmvWidget = this._renderers[ "QCIFVideo" ];
this._RegisterCodecDownloadEvent( qcifWmvWidget, "QCIFVideo" );
var panoWmvWidget = this._renderers[ "PanoVideo" ];
this._RegisterCodecDownloadEvent( panoWmvWidget, "PanoVideo" );
var mmcWmvWidget = this._renderers[ "MMC" ].GetWidget(UISettings.mmcWmvWidgetId);
this._RegisterCodecDownloadEvent( mmcWmvWidget, "MMC" );
var asWmvWidget = this._renderers[ "AppSharing" ].GetWidget(UISettings.asWmvWidgetId);
this._RegisterCodecDownloadEvent( asWmvWidget, "AppSharing" );
}
UIObjects.prototype._RegisterCodecDownloadEvent = function( wmvWidget, widgetName )
{
if( wmvWidget != null )
{
wmvWidget.beginCodecDownloadEvent.Add( DelegateWithArgs( this, UIObjects.prototype._OnBeginCodecDownload, widgetName ) );
wmvWidget.endCodecDownloadEvent.Add( DelegateWithArgs( this, UIObjects.prototype._OnEndCodecDownload, widgetName ) );
}
}
UIObjects.MMCReadyEventId = "MMC";
UIObjects.PreloadImageReadyEventId = "PreloadImage";
UIObjects.PaneMenuReadyEventId = "PaneMenu";
UIObjects.AppSharingReadyEventId = "AppSharing";
UIObjects.AnnoReadyEventId = "Anno";
UIObjects.prototype._InitializeObjectsReadyChecker = function()
{
this._objectsReadyChecker.AddEventReadyCheck(
this._renderers[ "MMC" ].GetWidgetWrapper(UISettings.mmcWmvWidgetId).clippedWidgetCreatedEvent,
UIObjects.MMCReadyEventId,
DelegateWithArgs( this, UIObjects.prototype._ObjectsReadyEventHandler,UIObjects.MMCReadyEventId )
);
this._objectsReadyChecker.AddEventReadyCheck(
this._mainFrame.preDownloader.PreloadFinishedEvent,
UIObjects.PreloadImageReadyEventId,
DelegateWithArgs( this, UIObjects.prototype._ObjectsReadyEventHandler, UIObjects.PreloadImageReadyEventId )
);
var paneMenu = this._mainFrame.playbackFrame.controlPane.paneMenu.GetMenu( UISettings.paneMenuId );
this._objectsReadyChecker.AddEventReadyCheck(
paneMenu.iframeLoadedEvent,
UIObjects.PaneMenuReadyEventId,
DelegateWithArgs( this, UIObjects.prototype._ObjectsReadyEventHandler, UIObjects.PaneMenuReadyEventId )
);
this._objectsReadyChecker.AddEventReadyCheck(
this._renderers[ "AppSharing" ].GetWidgetWrapper(UISettings.asWmvWidgetId).clippedWidgetCreatedEvent,
UIObjects.AppSharingReadyEventId,
DelegateWithArgs( this, UIObjects.prototype._ObjectsReadyEventHandler,UIObjects.AppSharingReadyEventId )
);
this._objectsReadyChecker.AddEventReadyCheck(
this._renderers[ "Anno" ].AnnoHTMLLoadedEvent,
UIObjects.AnnoReadyEventId,
DelegateWithArgs( this, UIObjects.prototype._ObjectsReadyEventHandler,UIObjects.AnnoReadyEventId )
);
if( NavigatorInfo.IsIE() && NavigatorInfo.ImageEnabled() )
{
this._mainFrame.preDownloader.BeginPreDownload();
}
else
{
this._objectsReadyChecker.SetEventReady( UIObjects.PreloadImageReadyEventId );
}
if( this._renderers[ "MMC" ].clippedWidgetIsCreated )
{
this._objectsReadyChecker.SetEventReady( UIObjects.MMCReadyEventId );
}
if( paneMenu.iframeIsLoaded )
{
this._objectsReadyChecker.SetEventReady( UIObjects.PaneMenuReadyEventId );
}
if( this._renderers[ "AppSharing" ].clippedWidgetIsCreated )
{
this._objectsReadyChecker.SetEventReady( UIObjects.AppSharingReadyEventId );
}
if( this._renderers[ "Anno" ].htmlIsLoaded )
{
this._objectsReadyChecker.SetEventReady( UIObject.AnnoReadyEventId );
}
}
UIObjects.prototype._MapShowAndHidePanesEvent = function()
{
var paneMenu = this._mainFrame.playbackFrame.controlPane.paneMenu.GetMenu( UISettings.paneMenuId );
var speakerMenuItem = paneMenu.GetItem( UISettings.showSpeakerMenuItemId );
speakerMenuItem.ClickedEvent.Add( this._eventManager.GetEvent( "EnableQCIFVideo" ) );
var panoramaMenuItem = paneMenu.GetItem( UISettings.showPanoramaMenuItemId );
panoramaMenuItem.ClickedEvent.Add( this._eventManager.GetEvent( "EnablePanoVideo" ) );
var indexMenuItem = paneMenu.GetItem( UISettings.showIndexMenuItemId );
indexMenuItem.ClickedEvent.Add( this._eventManager.GetEvent( "EnableIndex" ) );
var qaMenuItem = paneMenu.GetItem( UISettings.showQaMenuItemId );
qaMenuItem.ClickedEvent.Add( this._eventManager.GetEvent( "EnableQA" ) );
var notesMenuItem = paneMenu.GetItem( UISettings.showNotesMenuItemId );
notesMenuItem.ClickedEvent.Add( this._eventManager.GetEvent( "EnableNotes" ) );
}
UIObjects.prototype._ObjectsReadyEventHandler = function( readyEventId )
{
if( readyEventId == UIObjects.PaneMenuReadyEventId )
{
this._MapShowAndHidePanesEvent();
}
if( this._objectsReadyChecker.AreAllEventsReady() )
{
this._PreparePlaybackFrameCompleted();
}
}
UIObjects.prototype._PreparePlaybackFrameCompleted = function()
{
this.PreparePlaybackFrameCompletedEvent();
}
UIObjects.prototype.ShowPlaybackFrame = function()
{
this._mainFrame.ShowPlaybackFrame();
this.SetDefaultFocus();
}
UIObjects.prototype.Uninitialize = function()
{
this._mainFrame.Destroy();
TextWidget.ClearTestText();
UIManager.Destroy();
this._panes = {};
this._renderers = {};
}
UIObjects.prototype.ShowErrorMsg = function( msg )
{
this._mainFrame.ShowErrorMsg( msg );
}
UIObjects.prototype.ShowWarningMsg = function( msg )
{
this._mainFrame.ShowWarningMsg( msg );
}
UIObjects.prototype.SetMeetingInfo = function( info )
{
var meetingInfo = new Object();
meetingInfo.duration = info.duration;
meetingInfo.startTime = info.startTime;
meetingInfo.stopTime = info.stopTime;
meetingInfo.location = info.location;
meetingInfo.subject = info.subject;
meetingInfo.organizer = info.organizer;
meetingInfo.branding = info.branding;
this._meetingInfo = meetingInfo;
this._mainFrame.brandPane.SetCorpImage( meetingInfo.branding );
}
UIObjects.prototype.UpdateDuration = function ( durNew )
{
this._meetingInfo.duration = durNew;
this._mainFrame.downloadFrame.SetMeetingInfo( this._meetingInfo, true );
var playbackFrame = this._mainFrame.playbackFrame;
if( playbackFrame._htmlObject != null )
{
var timeSlider = playbackFrame.controlPane.timeSlider;
timeSlider.SetValueRange( 0, this._meetingInfo.duration );
}
}
UIObjects.prototype.SetQAData = function( qaData )
{
var qaRenderer = this._mainFrame.playbackFrame.qaPane.renderer;
qaRenderer.SetQaItems( qaData );
}
UIObjects.prototype.SetContentIndexData = function( contentIndexList )
{
Trace.WriteData( contentIndexList, 6 );
var indexLists = this._mainFrame.playbackFrame.indexPane.indexLists;
var contentIndexListWidget = indexLists[ MeetingSettings.Index.ContentName ];
contentIndexListWidget.SetContentItems( contentIndexList );
}
UIObjects.prototype.SetSpeakerIndexData = function( speakerIndexList, attendeeList )
{
Trace.WriteData( speakerIndexList, 6 );
var indexLists = this._mainFrame.playbackFrame.indexPane.indexLists;
var speakerIndexListRenderer = indexLists[ MeetingSettings.Index.SpeakerName ];
speakerIndexListRenderer.SetSpeakerItems( speakerIndexList, attendeeList, this._meetingInfo.duration );
}
UIObjects.prototype.SetDefaultFocus = function()
{
var categoryList = this._mainFrame.playbackFrame.indexPane.categoryList;
categoryList.SetTabIndex(UISettings.tabIndexDisable);
categoryList._FocusItem();
}
UIObjects.prototype.PromptExclusiveMessage = function( msgId, handler )
{
this._mainFrame.PromptExclusiveMessage( msgId, handler );
}
UIObjects.prototype.GetEventManager = function()
{
return this._eventManager;
}
UIObjects.prototype.GetEventHandlers = function()
{
return this._eventHandlers;
}
UIObjects.prototype.GetPane = function( paneName )
{
var pane = this._panes[ paneName ];
return pane;
}
UIObjects.prototype.GetRenderer = function( rendererName )
{
var renderer = this._renderers[ rendererName ];
return renderer;
}
UIObjects.prototype._GlobalInfoChanged = function( str )
{
this._statusText.SetText( str );
}
UIObjects.prototype._MeetingBuffering = function( buffering, playState )
{
if( buffering )
{
var str = LocaleInfo.GetText( UISettings.meetingStateBufferingText );
}
else
{
switch( playState )
{
case MeetingSettings.MeetingState.Stopped:
var str = LocaleInfo.GetText( UISettings.meetingStateStoppedText );
break;
case MeetingSettings.MeetingState.Paused:
var str = LocaleInfo.GetText( UISettings.meetingStatePausedText );
break;
case MeetingSettings.MeetingState.Playing:
var str = LocaleInfo.GetText( UISettings.meetingStatePlayingText );
break;
default:
var str = "";
break;
}
}
this._globalInfo.SetInformation(
GradedInfo.grades.information,
str );
}
UIObjects.prototype._MeetingStarted = function()
{
var controlPane = this._mainFrame.playbackFrame.controlPane;
controlPane.OnMeetingStarted();
var str = LocaleInfo.GetText( UISettings.meetingStatePlayingText );
this._globalInfo.SetInformation(
GradedInfo.grades.information,
str );
}
UIObjects.prototype._MeetingStopped = function()
{
var controlPane = this._mainFrame.playbackFrame.controlPane;
controlPane.OnMeetingStopped();
var str = LocaleInfo.GetText( UISettings.meetingStateStoppedText );
this._globalInfo.SetInformation(
GradedInfo.grades.information,
str );
}
UIObjects.prototype._MeetingPaused = function()
{
var controlPane = this._mainFrame.playbackFrame.controlPane;
controlPane.OnMeetingPaused();
var str = LocaleInfo.GetText( UISettings.meetingStatePausedText );
this._globalInfo.SetInformation(
GradedInfo.grades.information,
str );
}
UIObjects.prototype._MeetingMuted = function( muted )
{
var controlPane = this._mainFrame.playbackFrame.controlPane;
controlPane.OnMeetingMuted( muted );
}
UIObjects.prototype._VolumeChanged = function( volume )
{
var controlPane = this._mainFrame.playbackFrame.controlPane;
controlPane.OnVolumeChanged( volume );
}
UIObjects.prototype._TimeChanged = function( time )
{
var controlPane = this._mainFrame.playbackFrame.controlPane;
controlPane.OnTimeChanged( time, this._meetingInfo.duration );
}
UIObjects.prototype._SpeakerChanged = function( speakerInfo )
{
var bizCardRenderer = this._mainFrame.playbackFrame.primVideoPane.businessCard;
bizCardRenderer.SetData( speakerInfo );
}
UIObjects.prototype._BizcardChanged = function( action )
{
this._mainFrame.playbackFrame.primVideoPane.ChangeBizcardVisibility( action );
}
UIObjects.prototype._SpeakerIndexChanged = function( index )
{
var indexLists = this._mainFrame.playbackFrame.indexPane.indexLists;
var speakerIndexList = indexLists[ MeetingSettings.Index.SpeakerName ];
this._SetIndexButtons( speakerIndexList, index );
speakerIndexList.HighlightSingleTimeItem( index );
}
UIObjects.prototype._SpeakerEnabled = function( speakerId, enabled )
{
var indexLists = this._mainFrame.playbackFrame.indexPane.indexLists;
var speakerIndexList = indexLists[ MeetingSettings.Index.SpeakerName ];
speakerIndexList.EnableSpeaker( speakerId, enabled );
}
UIObjects.prototype._AllSpeakersEnabled = function( bEnable, applyAll )
{
var indexLists = this._mainFrame.playbackFrame.indexPane.indexLists;
var speakerIndexList = indexLists[ MeetingSettings.Index.SpeakerName ];
speakerIndexList.EnableAllSpeakers( bEnable, applyAll );
}
UIObjects.prototype._ActiveQAItem = function( index, active )
{
Trace.WriteLine( "The qa index is changed to " + index );
var qaRenderer = this._mainFrame.playbackFrame.qaPane.renderer;
qaRenderer.HighlightItem( index, active );
var highlightedIndex = qaRenderer.GetNearestHighlightedItem( index );
if( highlightedIndex > 0 )
{
qaRenderer.ScrollToItem( highlightedIndex );
}
else
{
qaRenderer.ScrollToItem( 0 );
}
}
UIObjects.prototype._QAChanged = function( index, active )
{
this._ActiveQAItem( index, active );
}
UIObjects.prototype._SetIndexButtons = function( list, index )
{
Trace.WriteLine( "The content index is changed to " + index );
var activeIndexList = this._mainFrame.playbackFrame.indexPane.GetActiveIndexList();
var controlPane = this._mainFrame.playbackFrame.controlPane;
if( activeIndexList == list )
{
controlPane.OnMeetingIndexChanged( index, activeIndexList.GetIndexibleItemCount() );
}
}
UIObjects.prototype._ContentIndexChanged = function( index )
{
var indexLists = this._mainFrame.playbackFrame.indexPane.indexLists;
var contentIndexList = indexLists[ MeetingSettings.Index.ContentName ];
this._SetIndexButtons( contentIndexList, index );
contentIndexList.HighlightSingleItem( index );
}
UIObjects.prototype._SetCurrentIndexCategory = function( indexListName )
{
Trace.WriteLine( "The index category is changed to " + indexListName );
var indexPane = this._mainFrame.playbackFrame.indexPane;
indexPane.SetActiveIndexList( indexListName );
var activeIndexList = this._mainFrame.playbackFrame.indexPane.GetActiveIndexList();
if( activeIndexList != null )
{
var index = activeIndexList.GetHighlightItem();
var controlPane = this._mainFrame.playbackFrame.controlPane;
controlPane.OnMeetingIndexChanged( index, activeIndexList.GetIndexibleItemCount() );
}
}
UIObjects.prototype._IndexCategoryChanged = function( indexListName )
{
this._SetCurrentIndexCategory( indexListName );
var activeIndexList = this._mainFrame.playbackFrame.indexPane.GetActiveIndexList();
}
UIObjects.prototype._QCIFVideoEnabled = function( enable )
{
var visibility = enable ? "inherit" : "hidden";
var playbackPane = this._mainFrame.playbackFrame;
playbackPane.ShowPrimVideoPane( visibility );
var paneMenu = playbackPane.controlPane.paneMenu.GetMenu( UISettings.paneMenuId );
var speakerMenuItem = paneMenu.GetItem( UISettings.showSpeakerMenuItemId );
speakerMenuItem.SetCheck( enable );
}
UIObjects.prototype._PanoVideoEnabled = function( enable )
{
var visibility = enable ? "inherit" : "hidden";
var playbackPane = this._mainFrame.playbackFrame;
playbackPane.ShowPanoVideoPane( visibility );
var paneMenu = playbackPane.controlPane.paneMenu.GetMenu( UISettings.paneMenuId );
var panoramaMenuItem = paneMenu.GetItem( UISettings.showPanoramaMenuItemId );
panoramaMenuItem.SetCheck( enable );
}
UIObjects.prototype._IndexEnabled = function( enable )
{
var visibility = enable ? "inherit" : "hidden";
var playbackPane = this._mainFrame.playbackFrame;
playbackPane.ShowIndexPane( visibility );
var paneMenu = playbackPane.controlPane.paneMenu.GetMenu( UISettings.paneMenuId );
var indexMenuItem = paneMenu.GetItem( UISettings.showIndexMenuItemId );
indexMenuItem.SetCheck( enable );
}
UIObjects.prototype._QAEnabled = function( enable )
{
var visibility = enable ? "inherit" : "hidden";
var playbackPane = this._mainFrame.playbackFrame;
playbackPane.ShowQAPane( visibility );
var paneMenu = playbackPane.controlPane.paneMenu.GetMenu( UISettings.paneMenuId );
var qaMenuItem = paneMenu.GetItem( UISettings.showQaMenuItemId );
qaMenuItem.SetCheck( enable );
}
UIObjects.prototype._NotesEnabled = function( enable )
{
var visibility = enable ? "inherit" : "hidden";
var playbackPane = this._mainFrame.playbackFrame;
playbackPane.ShowNotesPane( visibility );
var paneMenu = playbackPane.controlPane.paneMenu.GetMenu( UISettings.paneMenuId );
var notesMenuItem = paneMenu.GetItem( UISettings.showNotesMenuItemId );
notesMenuItem.SetCheck( enable );
}
UIObjects.prototype._DataAvailableHandler = function( paneId, valid )
{
var playbackPane = this._mainFrame.playbackFrame;
var paneMenu = playbackPane.controlPane.paneMenu.GetMenu( UISettings.paneMenuId );
var menuItemId = null;
switch( paneId )
{
case "Pano":
menuItemId = UISettings.showPanoramaMenuItemId;
break;
default:
break;
}
if( menuItemId != null )
{
paneMenu.EnableItem( menuItemId, valid );
}
}
UIObjects.prototype._PlayButtonClicked = function()
{
this._eventManager.FireEvent( "Play" );
var pauseButton = this._mainFrame.playbackFrame.controlPane.playButtons.GetButton( UISettings.pauseButtonId );
pauseButton.SetFocus();
}
UIObjects.prototype._PauseButtonClicked = function()
{
this._eventManager.FireEvent( "Pause" );
var playButton = this._mainFrame.playbackFrame.controlPane.playButtons.GetButton( UISettings.playButtonId );
playButton.SetFocus();
}
UIObjects.prototype._MuteButtonClicked = function()
{
this._eventManager.FireEvent( "Mute" );
var unmuteButton = this._mainFrame.playbackFrame.controlPane.playButtons.GetButton( UISettings.unmuteButtonId );
unmuteButton.SetFocus();
}
UIObjects.prototype._UnmuteButtonClicked = function()
{
this._eventManager.FireEvent( "Unmute" );
var muteButton = this._mainFrame.playbackFrame.controlPane.playButtons.GetButton( UISettings.muteButtonId );
muteButton.SetFocus();
}
UIObjects.prototype.ShowBrowserSetting = function()
{
this._mainFrame.downloadFrame.ShowCompletedEvent.Add( this.SettingCheckingCompleteEvent );
this._mainFrame.downloadFrame.ShowBrowserSettings();
}
UIObjects.prototype._OnBeginCodecDownload = function( wmvWidgetName, wmvFileName )
{
if( wmvWidgetName == "QCIFVideo" || wmvWidgetName == "PanoVideo" )
{
this._renderers[ "PanoVideo" ].SetCodecMissingFlag( true,  wmvFileName );
this._renderers[ "QCIFVideo" ].SetCodecMissingFlag( true, wmvFileName );
this._renderers[ "MMC" ].GetWidget(UISettings.mmcWmvWidgetId).SetCodecMissingFlag( true, wmvFileName );
this._renderers[ "AppSharing" ].GetWidget(UISettings.asWmvWidgetId).SetCodecMissingFlag( true, wmvFileName );
}
else
if( wmvWidgetName == "MMC" || wmvWidgetName == "AppSharing" )
{
this._renderers[ "MMC" ].GetWidget(UISettings.mmcWmvWidgetId).SetCodecMissingFlag( true, wmvFileName );
this._renderers[ "AppSharing" ].GetWidget(UISettings.asWmvWidgetId).SetCodecMissingFlag( true,wmvFileName );
}
if ( window.opener && !window.opener.closed )
{
window.opener.g_codecMissing = true;
}
var str = LocaleInfo.GetText( UISettings.WmvError_CodecRequired );
this._globalInfo.SetInformation(
GradedInfo.grades.error,
str );
}
UIObjects.prototype._OnEndCodecDownload = function( wmvWidgetName )
{
this._globalInfo.ClearInformation(
GradedInfo.grades.error );
}
UIObjects.prototype.DeleteAllWMVObjects = function()
{
var wmvObject = this._renderers[ "Audio" ];
if( wmvObject != null )
{
wmvObject.DeleteWMVObject();
}
wmvObject = this._renderers[ "PanoVideo" ];
if( wmvObject != null )
{
wmvObject.DeleteWMVObject();
}
wmvObject = this._renderers[ "QCIFVideo" ];
if( wmvObject != null )
{
wmvObject.DeleteWMVObject();
}
if( this._renderers["MMC"] && this._renderers[ "MMC" ].GetWidget )
{
wmvObject =  this._renderers[ "MMC" ].GetWidget(UISettings.mmcWmvWidgetId);
}
else
{
wmvObject = null;
}
if( wmvObject != null )
{
wmvObject.DeleteWMVObject();
}
if( this._renderers[ "AppSharing" ] && this._renderers[ "AppSharing" ].GetWidget )
{
wmvObject = this._renderers[ "AppSharing" ].GetWidget(UISettings.asWmvWidgetId);
}
else
{
wmvObject = null;
}
if( wmvObject != null )
{
wmvObject.DeleteWMVObject();
}
}
Trace.Wrap( "UIObjects" );
function SequencePlayManager()
{
this._sequencePlayers = null;
this._meetingState = null;
this._pulseCount = 0;
this._mainSeqs = ["Audio", "QCIF", "Pano", "Content"];
this._mainSeqsSeekCompleted = {};
for ( var i = 0; i < this._mainSeqs.length; i++ )
{
this._mainSeqsSeekCompleted[ this._mainSeqs[i] ] = true;
}
this._mainSeqsReadyStates = {};
for ( var i = 0; i < this._mainSeqs.length; i++ )
{
this._mainSeqsReadyStates[ this._mainSeqs[i] ] = true;
}
this._seekCompleted = true;
this._allSeekReady = true;
this._readyHandlerDelegates = {};
for ( var i = 0; i < this._mainSeqs.length; i++ )
{
this._readyHandlerDelegates[ this._mainSeqs[i] ] =
DelegateWithArgs( this, SequencePlayManager.prototype._ReadyForSeekHandler, this._mainSeqs[i] );
}
this.WaitingChanged = new Event();
this.SeekCompleteChangedEvent = new Event();
this._seekOperationBufferred = false;
this._seekPosNotApplied = -1;
}
SequencePlayManager.PulseInterval = 1;
SequencePlayManager.SyncInterval = 10;
SequencePlayManager.StatusSyncInterval = 10;
SequencePlayManager.SeekCompleteStates = {};
SequencePlayManager.SeekCompleteStates.Completed = 0;
SequencePlayManager.SeekCompleteStates.Seeking = 1;
SequencePlayManager.prototype.SetSequences = function( seqs )
{
this._sequencePlayers = seqs;
for ( var i = 0; i < this._mainSeqs.length; i ++ )
{
var seqId = this._mainSeqs[i];
this._sequencePlayers[seqId].BufferingEvent.Add(
DelegateWithArgs(
this,
SequencePlayManager.prototype._GeneralSequenceBufferringHandler,
seqId
)
);
this._sequencePlayers[seqId].ReadyEvent.Add(
DelegateWithArgs(
this,
SequencePlayManager.prototype._GeneralSequenceReadyHandler,
seqId
)
);
this._sequencePlayers[seqId].SeekCompletedEvent.Add(
DelegateWithArgs(
this,
SequencePlayManager.prototype._SeekCompletedHanlder,
seqId
)
);
this._sequencePlayers[seqId].BeforeEnterNewPage.Add(
DelegateWithArgs(
this,
SequencePlayManager.prototype._BeforeEnterNewPage,
seqId
)
);
}
}
SequencePlayManager.prototype.SetMeetingStateRef = function( meetingState )
{
this._meetingState = meetingState;
}
SequencePlayManager.prototype.MeetingPlaybackStarted = function()
{
for ( var mainseq in {Audio:"Audio"} )
{
this._sequencePlayers[mainseq].BufferingEvent.Add(
DelegateWithArgs( this, SequencePlayManager.prototype._SequenceBufferingCareHandler, mainseq )
);
this._sequencePlayers[mainseq].ReadyEvent.Add(
DelegateWithArgs( this, SequencePlayManager.prototype._SequenceReadyCareHandler, mainseq )
);
}
for ( var nonmainseq in {QCIF:"QCIF", Pano:"Pano", Content:"Content"} )
{
this._sequencePlayers[nonmainseq].ReadyEvent.Add(
DelegateWithArgs( this, SequencePlayManager.prototype._SequenceReadyNoCareHandler, nonmainseq )
);
}
}
SequencePlayManager.prototype.Pulse = function()
{
var baseSeq = this._sequencePlayers.GlobalTimer;
if ( this._pulseCount % SequencePlayManager.PulseInterval == 0 )
{
this._PulseAllSequences( baseSeq );
}
if ( this._pulseCount % SequencePlayManager.SyncInterval == 0 )
{
this._SyncAllSequences( baseSeq, this._meetingState );
}
if ( this._pulseCount % SequencePlayManager.StatusSyncInterval == 0 )
{
this._SyncStateAllSequences( this._meetingState );
}
this._pulseCount++;
}
SequencePlayManager.prototype._PulseAllSequences = function( baseSeq )
{
for( var seqPlayer in this._sequencePlayers )
{
if ( this._sequencePlayers[seqPlayer] == baseSeq )
{
continue;
}
if ( this._sequencePlayers[seqPlayer].Pulse )
{
if ( this._sequencePlayers[seqPlayer].HasData
&& this._sequencePlayers[seqPlayer].HasData())
{
this._DispatchPulseEvent(
Delegate(
this._sequencePlayers[seqPlayer],
this._sequencePlayers[seqPlayer].Pulse
)
);
}
}
}
}
SequencePlayManager.prototype._SyncAllSequences = function( baseSeq, meetingState )
{
for( var seqPlayer in this._sequencePlayers )
{
if ( this._sequencePlayers[seqPlayer] == baseSeq )
{
continue;
}
if ( this._sequencePlayers[seqPlayer].Sync )
{
this._sequencePlayers[seqPlayer].Sync(meetingState);
}
}
}
SequencePlayManager.prototype._SyncStateAllSequences = function ( meetingState )
{
for( var seqPlayer in this._sequencePlayers )
{
if ( this._sequencePlayers[seqPlayer].IsBuffering )
{
continue;
}
this._SyncStateOneSequence( this._sequencePlayers[seqPlayer], meetingState );
}
}
SequencePlayManager.prototype._SyncStateOneSequence = function( seqPlayer, meetingState )
{
if ( this._CaredSequenceBuffering() )
{
if ( seqPlayer.IsEnabled() )
{
seqPlayer.Enable( false );
}
}
else
{
if ( !seqPlayer.IsEnabled() )
{
seqPlayer.Sync( meetingState );
if ( seqPlayer == this._sequencePlayers.Audio && meetingState.IsMute )
{
seqPlayer.Enable( false );
}
else
{
seqPlayer.Enable( true );
}
}
seqPlayer.SyncState( meetingState );
}
}
SequencePlayManager.prototype._SequenceReadyNoCareHandler = function( seqId )
{
this._SyncStateOneSequence( this._sequencePlayers[seqId], this._meetingState );
}
SequencePlayManager.prototype._GeneralSequenceBufferringHandler = function( seqId )
{
this._sequencePlayers[seqId].IsBuffering = true;
}
SequencePlayManager.prototype._GeneralSequenceReadyHandler = function( seqId )
{
this._sequencePlayers[seqId].IsBuffering = false;
}
SequencePlayManager.prototype._SequenceBufferingCareHandler = function( seqId )
{
this._SyncStateAllSequences( this._meetingState );
}
SequencePlayManager.prototype._SequenceReadyCareHandler = function( seqId )
{
this._SyncStateAllSequences( this._meetingState );
}
SequencePlayManager.prototype._CaredSequenceBuffering = function()
{
if ( this._sequencePlayers.Audio.IsBuffering )
{
return true;
}
else
{
return false;
}
}
SequencePlayManager.prototype._DispatchPulseEvent = function( vdelegate )
{
var baseSeq = this._sequencePlayers.GlobalTimer;
var pos = baseSeq.GetAbsolutePosition( );
vdelegate( pos );
}
SequencePlayManager.prototype.DoSeek = function( tmNew )
{
if ( !this._seekCompleted )
{
this._seekOperationBufferred = true;
this._seekPosNotApplied = tmNew;
return;
}
this._meetingState.IsSeeking = true;
this.SeekCompleteChangedEvent( SequencePlayManager.SeekCompleteStates.Seeking );
this.WaitingChanged( true );
for ( var seqPlayer in this._mainSeqsSeekCompleted )
{
this._mainSeqsSeekCompleted[ seqPlayer ] = false;
}
for ( var seqPlayer in this._mainSeqsReadyStates )
{
this._mainSeqsReadyStates[ seqPlayer ] = false;
this._sequencePlayers[seqPlayer].ReadyEvent.Remove( this._readyHandlerDelegates[ seqPlayer ] );
this._sequencePlayers[seqPlayer].ReadyEvent.Add( this._readyHandlerDelegates[ seqPlayer ] );
}
for( var seqPlayer in this._sequencePlayers )
{
if ( this._sequencePlayers[seqPlayer].Seek )
{
this._sequencePlayers[seqPlayer].Seek( tmNew );
}
}
this._sequencePlayers.GlobalTimer.WaitResume();
this._meetingState.MeetingPos = this._sequencePlayers.GlobalTimer.GetAbsolutePosition();
}
SequencePlayManager.prototype._CheckSeekCompleted = function()
{
for ( var seqId in this._mainSeqsSeekCompleted )
{
if ( !this._mainSeqsSeekCompleted[ seqId ] )
{
return false;
}
}
return true;
}
SequencePlayManager.prototype._SeekCompletedHanlder = function( seqId )
{
this._mainSeqsSeekCompleted[ seqId ] = true;
this._seekCompleted = this._CheckSeekCompleted();
if ( this._seekCompleted )
{
this.SeekCompleteChangedEvent( SequencePlayManager.SeekCompleteStates.Completed );
if ( this._seekOperationBufferred )
{
this._seekOperationBufferred = false;
this.DoSeek( this._seekPosNotApplied );
}
}
}
SequencePlayManager.prototype._CheckAllMainSequencesReady = function()
{
for ( var i = 0; i < this._mainSeqs.length; i++ )
{
if ( !this._mainSeqsReadyStates[this._mainSeqs[ i ]] )
{
return false;
}
}
return true;
}
SequencePlayManager.prototype._ReadyForSeekHandler = function( seqId )
{
this._mainSeqsReadyStates[ seqId ] = true;
this._sequencePlayers[seqId].ReadyEvent.Remove( this._readyHandlerDelegates[ seqId ] );
this._allSeekReady = this._CheckAllMainSequencesReady();
if ( !this._allSeekReady )
{
setTimeout( DelegateWithArgs( this, SequencePlayManager.prototype._WaitAfterSeekReady, seqId ), 0 );
}
else
{
setTimeout( DelegateWithArgs( this, SequencePlayManager.prototype._ResumeSequencesAfterAllSeekReady, seqId ), 0 );
}
}
SequencePlayManager.prototype._WaitAfterSeekReady = function( seqId )
{
if ( this._allSeekReady )
{
return;
}
this._sequencePlayers[ seqId ].WaitResume();
}
SequencePlayManager.prototype._ResumeSequencesAfterAllSeekReady = function( lastseqId )
{
for ( var i = 0; i < this._mainSeqs.length; i++ )
{
this._sequencePlayers[this._mainSeqs[ i ]].ApplyResume();
}
this._sequencePlayers.GlobalTimer.ApplyResume();
this.WaitingChanged( false );
this._meetingState.IsSeeking = false;
}
SequencePlayManager.prototype._BeforeEnterNewPage = function( seqId, pos, isSeek )
{
if ( !this._sequencePlayers[ seqId ].GetAutoSwitch()  && !isSeek )
{
this._SyncPage( seqId,pos );
}
}
SequencePlayManager.prototype._SyncPage = function( seqId, pos )
{
if ( !this._seekCompleted )
{
return;
}
this.SeekCompleteChangedEvent( SequencePlayManager.SeekCompleteStates.Seeking );
this.WaitingChanged( true );
this._sequencePlayers[ "Audio" ].WaitResume();
this._sequencePlayers.GlobalTimer.Seek(pos);
for ( var seqPlayer in this._mainSeqsSeekCompleted )
{
this._mainSeqsSeekCompleted[ seqPlayer ] = true;
this._mainSeqsReadyStates[ seqPlayer ] = true;
this._sequencePlayers[seqPlayer].ReadyEvent.Remove( this._readyHandlerDelegates[ seqPlayer ] );
}
this._mainSeqsSeekCompleted[ seqId ] = false;
this._mainSeqsReadyStates[ seqId ] = false;
this._sequencePlayers[seqId].ReadyEvent.Add( this._readyHandlerDelegates[ seqId ] );
if ( this._sequencePlayers[seqId].Seek )
{
this._sequencePlayers[seqId].Seek( pos );
}
this._sequencePlayers.GlobalTimer.WaitResume();
}
SequencePlayManager.prototype.SetLowBandwidth = function( isLow )
{
for ( var i = 0; i < this._mainSeqs.length; i++ )
{
this._sequencePlayers[this._mainSeqs[i]].SetAutoSwitch( !isLow );
}
}
Trace.Wrap( "SequencePlayManager" );
function BWDManager()
{
OOP.CallParentConstructor( this, arguments.callee );
this._interactionNeeded = false;
this._seqs = null;
this._tarSeqId = null;
this._promoptWarningHandler = null;
this._totalCnt = 0;
this._bufferCnt = 0;
this._promptState = BWDManager.Prompt;
this.CloseSeqenceEvent = new Event();
}
BWDManager.Prompt = 0;
BWDManager.YesToAll = 1;
BWDManager.NoToAll = 2;
BWDManager.BandDetectionInterval = 300;
BWDManager.DetectInterval = 1000;
BWDManager.prototype.Initialize = function( seqs, promoptWarningHandler )
{
this._seqs = seqs;
this._promoptWarningHandler = promoptWarningHandler;
}
BWDManager.prototype.Check = function( )
{
if ( this._interactionNeeded )
{
return;
}
this._totalCnt++;
var isBuffering = this._CheckBuffering();
if ( isBuffering )
{
this._bufferCnt++;
}
if ( this._totalCnt % BWDManager.BandDetectionInterval == 0 )
{
this._BWDSummary();
}
}
BWDManager.prototype.Clear = function()
{
this._totalCnt = 0;
this._bufferCnt = 0;
}
BWDManager.prototype.Reset = function()
{
if (this.timerHandler)
{
clearTimeout( this.timerHandler );
}
this.timerHandler = setInterval(
Delegate( this, BWDManager.prototype.Check ),
BWDManager.DetectInterval
);
this.Clear();
}
BWDManager.prototype._CheckSeqToBeClosed = function()
{
if ( !this._seqs.Pano.Closed )
{
return this._seqs.Pano._name;
}
if ( !this._seqs.QCIF.Closed )
{
return this._seqs.QCIF._name;
}
return null;
}
BWDManager.prototype._BWDSummary = function()
{
if ( this._bufferCnt > this._totalCnt / 2 )
{
this._ProcessCloseStream();
}
this.Clear();
}
BWDManager.prototype._ProcessCloseStream = function()
{
var tarSeqId = this._CheckSeqToBeClosed();
if ( tarSeqId )
{
this._tarSeqId = tarSeqId;
if ( this._promptState == BWDManager.Prompt )
{
this._ShowWarning( this._tarSeqId );
}
else if ( this._promptState == BWDManager.YesToAll )
{
this.CloseSeqenceEvent( tarSeqId );
}
else if ( this._promptState == BWDManager.NoToAll )
{
}
}
}
BWDManager.prototype.PromotToCloseStream = function()
{
this._ProcessCloseStream();
this.Clear();
}
BWDManager.prototype._CheckBuffering = function()
{
var ret = false;
if ( this._seqs.Audio.IsBuffering )
{
ret = true;
}
if ( this._seqs.QCIF.IsBuffering )
{
ret = true;
}
if ( this._seqs.Pano.IsBuffering )
{
ret = true;
}
return ret;
}
BWDManager.prototype._ShowWarning = function( seqId )
{
if ( this._interactionNeeded )
{
return;
}
this._interactionNeeded = true;
if ( this._promoptWarningHandler )
{
this._promoptWarningHandler( "BW" + seqId, Delegate(this, this.BWDPromptHandler) );
}
}
BWDManager.prototype.BWDPromptHandler = function( btnID )
{
if ( !this._tarSeqId )
{
return;
}
this._interactionNeeded = false;
switch( btnID )
{
case MeetingSettings.DID.YesToAll:
this._promptState = BWDManager.YesToAll;
case MeetingSettings.DID.Yes:
this.CloseSeqenceEvent( this._tarSeqId );
break;
case MeetingSettings.DID.NoToAll:
this._promptState = BWDManager.NoToAll;
case MeetingSettings.DID.No:
break;
default:
Trace.WriteWarning( "No such btnID " + btnID );
}
}
Trace.Wrap( "BWDManager" );
function BasePlayer()
{
this._renderer = null;
this._initialized = false;
this._rendererAssignedEvent = new Event();
this._initializedEvent = new Event();
this._uninitializedEvent = new Event();
this._enabled = true;
}
BasePlayer.prototype.Initialize = function()
{
this._initializedEvent();
this._initialized = true;
}
BasePlayer.prototype.Uninitialize = function()
{
this._uninitializedEvent();
this._initialized = false;
}
BasePlayer.prototype.AssignRenderer = function( renderer )
{
this._renderer = renderer;
this._rendererAssignedEvent( renderer );
}
BasePlayer.prototype.GetRenderer = function()
{
return this._renderer;
}
BasePlayer.prototype.Enable = function( isEnable )
{
this._enabled = isEnable;
}
BasePlayer.prototype.IsEnabled = function()
{
return this._enabled;
}
Trace.Wrap( "BasePlayer" );
function CtrlablePlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._waiting           = false;
this.SeekCompletedEvent      = new Event();
this._playerState = new MeetingSettings.MeetingStateClass(
MeetingSettings.MeetingState.Undefined,
1.0,
1.0,
false,
0,
false
);
this._customizeSeekCompleted = false;
this._pulsedEvent       = new Event();
this._seekedEvent       = new Event();
this._syncEvent         = new Event();
this._syncStateEvent    = new Event();
this._playEvent         = new Event();
this._stopEvent         = new Event();
this._pauseEvent        = new Event();
this._pauseAtEvent      = new Event();
this._playAtEvent       = new Event();
this._stopAtEvent       = new Event();
this._setRateEvent      = new Event();
this._setVolumeEvent    = new Event();
this._muteEvent         = new Event();
this._waitResumeEvent   = new Event();
this._applyResumeEvent  = new Event();
}
OOP.Inherit( CtrlablePlayer, BasePlayer );
CtrlablePlayer.prototype.Pulse = function( pos )
{
this._playerState.MeetingPos = pos;
this._pulsedEvent( pos );
}
CtrlablePlayer.prototype.Seek = function( pos )
{
this._seekedEvent( pos );
if ( !this._customizeSeekCompleted )
{
setTimeout( Delegate( this, this.SeekCompletedEvent ), 0 );
}
this._waiting = false;
}
CtrlablePlayer.prototype.Sync = function( meetingState )
{
this._syncEvent( meetingState );
}
CtrlablePlayer.prototype.SyncState = function( meetingState )
{
this._syncStateEvent( meetingState );
}
CtrlablePlayer.prototype.Play = function()
{
this._playerState.State = MeetingSettings.MeetingState.Playing;
this._playEvent();
}
CtrlablePlayer.prototype.PlayAt = function( pos )
{
this._playerState.State = MeetingSettings.MeetingState.Playing;
this._playAtEvent( pos );
}
CtrlablePlayer.prototype.Stop = function()
{
this._playerState.State = MeetingSettings.MeetingState.Stopped;
this._stopEvent( );
}
CtrlablePlayer.prototype.StopAt = function( pos )
{
this._playerState.State = MeetingSettings.MeetingState.Stopped;
this._stopAtEvent( pos );
}
CtrlablePlayer.prototype.Pause = function()
{
this._playerState.State = MeetingSettings.MeetingState.Paused;
this._pauseEvent();
}
CtrlablePlayer.prototype.PauseAt = function( pos )
{
this._playerState.State = MeetingSettings.MeetingState.Paused;
this._pauseAtEvent( pos );
}
CtrlablePlayer.prototype.SetRate = function( rate )
{
this._playerState.Speed = rate;
this._setRateEvent( rate );
}
CtrlablePlayer.prototype.SetVolume = function( vol )
{
this._playerState.Volume = vol;
this._setVolumeEvent( vol );
}
CtrlablePlayer.prototype.Mute = function( isMute )
{
this._playerState.IsMute = isMute;
this._muteEvent( isMute );
}
CtrlablePlayer.prototype.WaitResume = function()
{
this._waiting = true;
this._waitResumeEvent();
}
CtrlablePlayer.prototype.ApplyResume = function()
{
this._applyResumeEvent();
this._waiting = false;
}
Trace.Wrap("CtrlablePlayer");
function PagedPlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._resPagePlayerFlag = false;
this._page = null;
this._prebufferredPage = null;
this._pageTime = 0;
this._startTime = 0;
this._isBuffering = false;
this._pageEnterEvent = new Event();
this._pageExitEvent = new Event();
this._prebufferPageEvent = new Event();
this.BufferingEvent = new Event();
this.ReadyEvent = new Event();
this._rendererAssignedEvent.Add(
DelegateWithArgs( this, PagedPlayer.prototype._RendererAssignedHandler )
);
this._innerMessages = null;
this._pulsedEvent.Add( Delegate( this, PagedPlayer.prototype._PulseHandler ) );
this._seekedEvent.Add( Delegate( this, PagedPlayer.prototype._SeekHandler ) );
this._lastProcessTime = -1;
this._BeforeProcMsgEvent = new Event();
this._AfterProcMsgEvent = new Event();
}
OOP.Inherit( PagedPlayer, CtrlablePlayer );
PagedPlayer.prototype.IsResPlayer = function()
{
return this._resPagePlayerFlag;
}
PagedPlayer.prototype.EnterPage = function( page, time, startTime, playState, isEnabled )
{
if ( this._renderer.StartSession )
{
this._renderer.StartSession();
}
this._page = page;
this._pageTime = time;
this._startTime = startTime;
Trace.WriteLine( "Event page setted fired ");
this._pageEnterEvent( page, time, startTime, playState, isEnabled );
this._lastProcessTime = -1;
this._playerState.State = playState;
if ( !this._resPagePlayerFlag )
{
this.ReadyEvent();
}
}
PagedPlayer.prototype.ExitPage = function( fDifResOnFollowing )
{
this._pageExitEvent( fDifResOnFollowing );
this._page = null;
this._playerState.State = MeetingSettings.MeetingState.Stopped;
if ( this._renderer.StopSession )
{
this._renderer.StopSession();
}
}
PagedPlayer.prototype.PrebufferPage = function ( page, offset )
{
if (( this._prebufferredPage == page ) && ( !this._isBuffering ))
{
}
else
{
}
this._prebufferPageEvent( page, offset );
}
PagedPlayer.prototype._RendererAssignedHandler = function ( renderer )
{
if ( !renderer )
{
return;
}
if ( renderer.BufferingEvent )
{
renderer.BufferingEvent.Add(
Delegate( this, PagedPlayer.prototype._RendererBufferingHandler )
);
}
if ( renderer.ReadyEvent )
{
renderer.ReadyEvent.Add(
Delegate( this, PagedPlayer.prototype._RendererReadyHandler )
);
}
}
PagedPlayer.prototype._RendererBufferingHandler = function()
{
this._isBuffering = true;
this.BufferingEvent();
}
PagedPlayer.prototype._RendererReadyHandler = function()
{
this._isBuffering = false;
this.ReadyEvent();
}
PagedPlayer.prototype._SeekHandler = function( pos )
{
Trace.WriteLine("--Seek !!!" );
this._ProcessTime( pos, true );
if ( !this._resPagePlayerFlag )
{
this.ReadyEvent();
}
}
PagedPlayer.prototype._PulseHandler = function( pos )
{
this._ProcessTime( pos, false );
}
PagedPlayer.prototype._ProcessTime = function( pos, isSeek )
{
if ( this._page && this._innerMessages )
{
this._ProcessInnerPageMessage( pos, isSeek );
}
this._lastProcessTime = pos;
}
PagedPlayer.prototype._ProcessInnerPageMessage = function( pos, isSeek )
{
var meetingTime = pos;
var posInPage = this._GetPosInPage( meetingTime );
var srcIndex = SearchItemWithTimeEx(
this._lastProcessTime,
this._innerMessages,
"time"
);
var tarIndex = SearchItemWithTimeEx(
meetingTime,
this._innerMessages,
"time" );
if ( meetingTime < this._lastProcessTime )
{
this._BackwardMessages( this._lastProcessTime, pos, srcIndex, tarIndex, isSeek );
}
else
{
this._ForwardMessages( this._lastProcessTime, pos, srcIndex, tarIndex, isSeek );
}
}
PagedPlayer.prototype._BackwardMessages = function(
lastPos, curPos, srcIndex, tarIndex, isSeek )
{
Trace.WriteLine("--BackwardMessage("+lastPos+", "+curPos+", "+srcIndex+", "+tarIndex+", "+isSeek+")" );
if (srcIndex == tarIndex && !isSeek)
{
return;
}
if ( this._renderer.ResetSession )
{
this._renderer.ResetSession();
}
this.Reset();
this._BeforeProcMsgEvent( curPos, tarIndex, isSeek );
if ( tarIndex == null )
{
return;
}
this._ProcessRangeMessages( 0, tarIndex );
this._AfterProcMsgEvent( curPos, tarIndex, isSeek );
}
PagedPlayer.prototype._ProcessRangeMessages = function( from, to )
{
if ( this._RecalcRange )
{
var tmpObj = this._RecalcRange( from, to );
from = tmpObj.from;
to = tmpObj.to;
}
var i;
var iStart = from;
var snapTime = -1;
if ( this._page && this._page.snapShots )
{
var toTime = this._innerMessages[to].time;
var snapIdx = SearchItemWithTimeEx(
toTime,
this._page.snapShots,
"time"
);
if ( snapIdx != null )
{
this.Update( this._page.snapShots[ snapIdx ] );
snapTime = this._page.snapShots[ snapIdx ].time;
var tmpStartIdx = SearchItemWithTimeEx(
snapTime,
this._innerMessages,
"time"
);
if ( tmpStartIdx != null )
{
iStart = tmpStartIdx;
}
}
}
for ( i = iStart; i <= to; i++ )
{
if ( this._innerMessages[i].time > snapTime )
{
this.Update( this._innerMessages[i] );
}
}
}
PagedPlayer.prototype._ForwardMessages = function(
lastPos, curPos, srcIndex, tarIndex, isSeek )
{
if (srcIndex == tarIndex && !isSeek)
{
return;
}
this._BeforeProcMsgEvent( curPos, tarIndex, isSeek );
if ( srcIndex != tarIndex )
{
if ( srcIndex == null )
{
srcIndex = -1;
}
this._ProcessRangeMessages( srcIndex + 1, tarIndex );
}
this._AfterProcMsgEvent( curPos, tarIndex, isSeek );
}
PagedPlayer.prototype._GetPosInPage = function( pos )
{
return pos - this._pageTime;
}
Trace.Wrap("PagedPlayer");
function WithAnnoPlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._annoPlayer = null;
this._pageEnterEvent.Add( Delegate( this, WithAnnoPlayer.prototype._PageEnterHandler ) );
this._pageExitEvent.Add( Delegate( this, WithAnnoPlayer.prototype._PageExitHandler ) );
this._pulsedEvent.Add( Delegate( this, WithAnnoPlayer.prototype._PulseHandler ) );
}
OOP.Inherit( WithAnnoPlayer, PagedPlayer );
WithAnnoPlayer.prototype.SetAnnoPlayer = function( annoPlayer )
{
this._annoPlayer = annoPlayer;
}
WithAnnoPlayer.prototype._PageEnterHandler = function( page, time, startTime, playstate, isEnable )
{
this._annoPlayer.EnterPage( page, time, startTime, playstate, isEnable );
}
WithAnnoPlayer.prototype._PageExitHandler = function( fdif )
{
this._annoPlayer.ExitPage( fdif );
}
WithAnnoPlayer.prototype._PulseHandler = function( pos )
{
this._annoPlayer.Pulse( pos );
}
function IndexBasePlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._indexData = null;
this._originalIndex = IndexBasePlayer.UNUSEDINDEX;
this.IndexChanged = new Event();
}
IndexBasePlayer.UNUSEDINDEX = -100;
IndexBasePlayer.PREVTHRESHOLD = 5.0;
IndexBasePlayer.prototype.Initialize = function()
{
}
IndexBasePlayer.prototype.Uninitialize = function()
{
}
IndexBasePlayer.prototype.SetIndexData = function( indexData )
{
this._indexData = indexData;
this._originalIndex = IndexBasePlayer.UNUSEDINDEX;
}
IndexBasePlayer.prototype.Pulse = function ( pos )
{
var idx = SearchItemWithTime( pos, this._indexData );
if ( this._originalIndex != idx )
{
this.IndexChanged( idx );
this._originalIndex = idx;
}
}
IndexBasePlayer.prototype.GetIndexPos = function ( idx )
{
return this._indexData[ idx ].time;
}
Trace.Wrap( "IndexBasePlayer" );
function IndexPlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( IndexPlayer, IndexBasePlayer );
IndexPlayer.UNUSEDINDEX = -100;
IndexPlayer.PREVTHRESHOLD = 5.0;
IndexPlayer.prototype.GetPosOfNext = function ( pos )
{
var retval = 0;
var idx = SearchItemWithTimeEx( pos, this._indexData );
if ( idx == null )
{
if (this._indexData.length >= 1 )
{
retval = this._indexData[0].time;
}
}
else
{
if ( idx == this._indexData.length - 1 )
{
retval = pos;
}
else
{
retval = this._indexData[ idx + 1 ].time;
}
}
return retval;
}
IndexPlayer.prototype.GetPosOfPrev = function ( pos )
{
var retval = 0;
var idx = SearchItemWithTimeEx( pos, this._indexData );
if ( idx == null )
{
retval = 0;
}
else
{
if ( idx == 0 )
{
retval = this._indexData[ idx ].time;
}
else
{
retval = this._indexData[ idx - 1 ].time;
}
}
return retval;
}
Trace.Wrap( "IndexPlayer" );
function AnnoPlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._textAnnos = {};
this._pageEnterEvent.Add( Delegate( this, AnnoPlayer.prototype._PageEnterHandler ) );
this._pageExitEvent.Add( Delegate( this, AnnoPlayer.prototype._PageExitHandler ) );
this._rendererAssignedEvent.Add( Delegate( this, AnnoPlayer.prototype._RendererAssignedHandler ) );
}
OOP.Inherit( AnnoPlayer, PagedPlayer );
AnnoPlayer.DefaultPageWidth = 800;
AnnoPlayer.DefaultPageHeight = 600;
AnnoPlayer.PointerR = 5;
AnnoPlayer.BorderWeight = 2;
AnnoPlayer.DefaultWeight = 2;
AnnoPlayer.DefaultHighLighterWeight = 30;
AnnoPlayer.DefaultOvalOpacity = 0.0;
AnnoPlayer.BorderColor = "#FFFFFF";
AnnoPlayer.DefaultShapeColor = "#4D0B0F";
AnnoPlayer.DefaultHighLighterColor = "#FFFF00";
AnnoPlayer.DefaultXStampColor = "#4FF74C";
AnnoPlayer.DefaultArrowStampColor = "#76FFFC";
AnnoPlayer.DefaultCheckStampColor = "#FFFFA6";
AnnoPlayer.PointerBorderColor = "#000000";
AnnoPlayer.PointerColor = "#FF0000";
AnnoPlayer.PointerInnerOpacity = 1.0;
AnnoPlayer.PointerBorderWidth = 1;
AnnoPlayer.DefaultOvalFill = "#FFFFFF";
AnnoPlayer.XStamp_T1 = 3;
AnnoPlayer.XStamp_T2 = 9;
AnnoPlayer.ArrowStamp_T1 = 4;
AnnoPlayer.ArrowStamp_T2 = 7;
AnnoPlayer.CheckStamp_T = 1;
AnnoPlayer.prototype._PageEnterHandler = function( page, time, startTime )
{
if ( !this._renderer.IsAvailable() )
{
return;
}
this._innerMessages = page.AnnotationChanged;
this.Reset();
var w = null;
var h = null;
if ( page.width )
{
w = page.width;
}
if ( page.height )
{
h = page.height;
}
this._renderer.SetGroupSize( w, h );
}
AnnoPlayer.prototype._PageExitHandler = function(  )
{
this._textAnnos = {};
if ( !this._renderer.IsAvailable() )
{
return;
}
this._renderer.SetStyle( "visibility",  "hidden" );
this._renderer.Uninitialize();
}
AnnoPlayer.prototype._RecalcRange = function( from, to )
{
var tmp = {};
tmp.from = from;
tmp.to = to;
for ( var i = from; i <= to; i++ )
{
if ( this._innerMessages[i].action == "Clear" )
{
tmp.from = i;
}
}
return tmp;
}
AnnoPlayer.prototype.Update = function( msg )
{
if ( !msg.action )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var elemId = msg.elementId;
if (( typeof elemId == "string" ) && ( elemId.length > 0 ) && ( elemId[0] == '_' ))
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var action = msg.action.toLowerCase();
Trace.WriteLine( " anno action is %1", action );
switch (action)
{
case "draw":
this._Draw( elemId, msg );
break;
case "update":
this._UpdateText( elemId, msg );
break;
case "delete":
this._Delete( elemId );
break;
case "clear":
this._Clear();
break;
case "move":
this._Move( elemId, msg );
break;
case "changecolor":
this._ChangeColor( elemId, msg );
break;
default:
g_ErrorHandling.ShowCustomWarning( "Unknown annotation action " + action );
break;
}
}
AnnoPlayer.prototype._ChangeColor = function( elemId, msg )
{
var aColor = msg.color;
this._renderer.ChangeColor( elemId, aColor );
}
AnnoPlayer.prototype._Move = function( elemId, msg )
{
var dx = parseFloat( msg.dx );
var dy = parseFloat( msg.dy );
if ( isNaN( dx ) )
{
dx = 0;
}
if ( isNaN( dy ) )
{
dy = 0;
}
this._renderer.Move( elemId, dx, dy );
var borderId = AnnoPlayer.GenBorderId( elemId );
if ( this._renderer._GetAnnoElementById( borderId ) != null )
{
this._renderer.Move( borderId, dx, dy );
}
}
AnnoPlayer.prototype._Clear = function()
{
this._renderer.Clear();
}
AnnoPlayer.prototype._UpdateText = function( elemId, msg )
{
var aType = msg.type.toLowerCase();
var aKeyPoints = msg.keyPoints;
var points = aKeyPoints.split(",");
if ( points.length < 2 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
if ( msg.color == null )
{
msg.color = AnnoPlayer.DefaultShapeColor;
}
if ( msg.fontStyle )
{
this._textAnnos[elemId].fontStyle = msg.fontStyle;
}
if ( msg.fontWeight )
{
this._textAnnos[elemId].fontWeight = msg.fontWeight;
}
if ( msg.fontSize )
{
this._textAnnos[elemId].fontSize = msg.fontSize;
}
if ( msg.fontFamily )
{
this._textAnnos[elemId].fontFamily = msg.fontFamily;
}
if ( msg.underline )
{
this._textAnnos[elemId].underline = (msg.underline == "true");
}
var font =
this._textAnnos[elemId].fontStyle +
" normal " +
this._textAnnos[elemId].fontWeight + " " +
this._textAnnos[elemId].fontSize + " \"" +
this._textAnnos[elemId].fontFamily + "\"";
this._renderer.UpdateText(
aType,
elemId,
parseFloat( points[0] ),
parseFloat( points[1] ),
msg.color,
font,
this._textAnnos[elemId].underline,
msg.text
);
}
AnnoPlayer.prototype._Delete = function( elemId )
{
this._renderer.Delete( elemId );
var borderId = AnnoPlayer.GenBorderId( elemId );
if ( this._renderer._GetAnnoElementById( borderId ) != null )
{
this._renderer.Delete( borderId );
}
}
AnnoPlayer.prototype._DrawRect = function( msg, elemId, aType, points )
{
if ( points.length < 4 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
if ( msg.color == null )
{
msg.color = AnnoPlayer.DefaultShapeColor;
}
var left = parseFloat( points[0] );
var top = parseFloat( points[1] );
var right = parseFloat( points[2] );
var bottom = parseFloat( points[3] );
var width = right - left;
if ( width < 0 )
{
width = 0;
}
var height = bottom - top;
if ( height < 0 )
{
height = 0;
}
this._renderer.DrawRect(
aType,
AnnoPlayer.GenBorderId( elemId ),
left,
top,
width,
height,
AnnoPlayer.BorderColor,
AnnoPlayer.BorderWeight );
this._renderer.DrawRect(
aType,
elemId,
left,
top,
width,
height,
msg.color,
AnnoPlayer.DefaultWeight );
}
AnnoPlayer.prototype._DrawRoundRect = function( msg, elemId, aType, points )
{
if ( points.length < 4 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
if ( msg.color == null )
{
msg.color = AnnoPlayer.DefaultShapeColor;
}
var left = parseFloat( points[0] );
var top = parseFloat( points[1] );
var right = parseFloat( points[2] );
var bottom = parseFloat( points[3] );
var width = right - left;
if ( width < 0 )
{
width = 0;
}
var height = bottom - top;
if ( height < 0 )
{
height = 0;
}
this._renderer.DrawRoundRect(
aType,
AnnoPlayer.GenBorderId( elemId ),
left,
top,
width,
height,
AnnoPlayer.BorderColor,
AnnoPlayer.BorderWeight );
this._renderer.DrawRoundRect(
aType,
elemId,
left,
top,
width,
height,
msg.color,
AnnoPlayer.DefaultWeight );
}
AnnoPlayer.prototype._DrawLine = function( msg, elemId, aType, points )
{
if ( points.length < 4 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
if ( msg.color == null )
{
msg.color = AnnoPlayer.DefaultShapeColor;
}
this._renderer.DrawLine(
aType,
AnnoPlayer.GenBorderId( elemId ),
parseFloat( points[0] ),
parseFloat( points[1] ),
parseFloat( points[2] ),
parseFloat( points[3] ),
AnnoPlayer.BorderColor,
AnnoPlayer.BorderWeight );
this._renderer.DrawLine(
aType,
elemId,
parseFloat( points[0] ),
parseFloat( points[1] ),
parseFloat( points[2] ),
parseFloat( points[3] ),
msg.color,
AnnoPlayer.DefaultWeight );
}
AnnoPlayer.prototype._DrawArrow = function( msg, elemId, aType, points )
{
if ( points.length < 4 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
if ( msg.color == null )
{
msg.color = AnnoPlayer.DefaultShapeColor;
}
this._renderer.DrawArrow(
aType,
AnnoPlayer.GenBorderId( elemId ),
parseFloat( points[0] ),
parseFloat( points[1] ),
parseFloat( points[2] ),
parseFloat( points[3] ),
AnnoPlayer.BorderColor,
AnnoPlayer.BorderWeight );
this._renderer.DrawArrow(
aType,
elemId,
parseFloat( points[0] ),
parseFloat( points[1] ),
parseFloat( points[2] ),
parseFloat( points[3] ),
msg.color,
AnnoPlayer.DefaultWeight );
}
AnnoPlayer.prototype._DrawOval = function( msg, elemId, aType, points )
{
if ( points.length < 4 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
if ( msg.color == null )
{
msg.color = AnnoPlayer.DefaultShapeColor;
}
var left = parseFloat( points[0] );
var top = parseFloat( points[1] );
var right = parseFloat( points[2] );
var bottom = parseFloat( points[3] );
var width = right - left;
if ( width < 0 )
{
width = 0;
}
var height = bottom - top;
if ( height < 0 )
{
height = 0;
}
this._renderer.DrawOval(
aType,
AnnoPlayer.GenBorderId( elemId ),
left,
top,
width,
height,
AnnoPlayer.BorderColor,
AnnoPlayer.BorderWeight,
AnnoPlayer.DefaultOvalOpacity,
AnnoPlayer.DefaultOvalFill );
this._renderer.DrawOval(
aType,
elemId,
left,
top,
width,
height,
msg.color,
AnnoPlayer.DefaultWeight,
AnnoPlayer.DefaultOvalOpacity,
AnnoPlayer.DefaultOvalFill );
}
AnnoPlayer.prototype._DrawFreeLine = function( msg, elemId, aType, points )
{
if ( points.length < 4 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
if ( msg.color == null )
{
msg.color = AnnoPlayer.DefaultShapeColor;
}
this._renderer.DrawFreeLine(
aType,
AnnoPlayer.GenBorderId( elemId ),
msg.keyPoints,
AnnoPlayer.BorderColor,
AnnoPlayer.BorderWeight );
this._renderer.DrawFreeLine(
aType,
elemId,
msg.keyPoints,
msg.color,
AnnoPlayer.DefaultWeight );
}
AnnoPlayer.prototype._DrawHighLighter = function( msg, elemId, aType, points )
{
if ( points.length < 4 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
if ( msg.color == null )
{
msg.color = AnnoPlayer.DefaultHighLighterColor;
}
this._renderer.DrawHighLighter(
aType,
elemId,
msg.keyPoints,
msg.color,
AnnoPlayer.DefaultHighLighterWeight );
}
AnnoPlayer.prototype._DrawXStamp = function( msg, elemId, aType, points )
{
if ( points.length < 2 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
if ( msg.color == null )
{
msg.color = AnnoPlayer.DefaultArrowStampColor;
}
this._renderer.DrawXStamp(
aType,
elemId,
parseFloat( points[0] ),
parseFloat( points[1] ),
msg.color,
AnnoPlayer.XStamp_T1,
AnnoPlayer.XStamp_T2 );
}
AnnoPlayer.prototype._DrawArrowStamp = function( msg, elemId, aType, points )
{
if ( points.length < 2 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
if ( msg.color == null )
{
msg.color = AnnoPlayer.DefaultArrowStampColor;
}
this._renderer.DrawArrowStamp(
aType,
elemId,
parseFloat( points[0] ),
parseFloat( points[1] ),
msg.color,
AnnoPlayer.ArrowStamp_T1,
AnnoPlayer.ArrowStamp_T2
);
}
AnnoPlayer.prototype._DrawCheckStamp = function( msg, elemId, aType, points )
{
if ( points.length < 2 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
if ( msg.color == null )
{
msg.color = AnnoPlayer.DefaultCheckStampColor;
}
this._renderer.DrawCheckStamp(
aType,
elemId,
parseFloat( points[0] ),
parseFloat( points[1] ),
msg.color,
AnnoPlayer.CheckStamp_T
);
}
AnnoPlayer.prototype._DrawText = function( msg, elemId, aType, points )
{
if ( points.length < 2 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var tmpMsg = {};
if ( msg.color == null )
{
tmpMsg.color = AnnoPlayer.DefaultShapeColor;
}
else
{
tmpMsg.color = msg.color;
}
if ( !msg.fontStyle )
{
tmpMsg.fontStyle = "normal";
}
else
{
tmpMsg.fontStyle = msg.fontStyle;
}
if ( !msg.fontWeight )
{
tmpMsg.fontWeight = "normal";
}
else
{
tmpMsg.fontWeight = msg.fontWeight;
}
if ( !msg.fontSize )
{
tmpMsg.fontSize = "16";
}
else
{
tmpMsg.fontSize = msg.fontSize;
}
if ( !msg.fontFamily )
{
tmpMsg.fontFamily = "Arial";
}
else
{
tmpMsg.fontFamily = msg.fontFamily;
}
tmpMsg.underline  = (msg.underline == "true");
this._textAnnos[elemId] = new Object();
this._textAnnos[elemId].fontStyle = tmpMsg.fontStyle;
this._textAnnos[elemId].fontWeight = tmpMsg.fontWeight;
this._textAnnos[elemId].fontSize = tmpMsg.fontSize;
this._textAnnos[elemId].fontFamily = tmpMsg.fontFamily;
this._textAnnos[elemId].underline = tmpMsg.underline;
var font = tmpMsg.fontStyle
+ " normal "
+ tmpMsg.fontWeight + " "
+ tmpMsg.fontSize + " \'"
+ tmpMsg.fontFamily + "\'";
this._renderer.DrawText(
aType,
elemId,
parseFloat( points[0] ),
parseFloat( points[1] ),
tmpMsg.color,
font,
tmpMsg.underline,
msg.text
);
}
AnnoPlayer.prototype._DrawPointer = function( msg, elemId, aType, points )
{
if ( points.length < 2 )
{
g_ErrorHandling.ShowWarning( E_BADANNODATA );
return;
}
var x = parseFloat( points[0] );
var y = parseFloat( points[1] );
if ( isNaN( x ) )
{
x = 0;
}
if ( isNaN( y ) )
{
y = 0;
}
this._renderer.DrawOval(
aType,
elemId,
x - AnnoPlayer.PointerR,
y - AnnoPlayer.PointerR,
AnnoPlayer.PointerR * 2,
AnnoPlayer.PointerR * 2,
AnnoPlayer.PointerBorderColor,
AnnoPlayer.PointerBorderWidth,
AnnoPlayer.PointerInnerOpacity,
AnnoPlayer.PointerColor
);
}
AnnoPlayer.prototype._Draw = function( elemId, msg )
{
var aType = msg.type.toLowerCase();
var aKeyPoints = msg.keyPoints;
var points = aKeyPoints.split(",");
switch (aType)
{
case "rect":
this._DrawRect( msg, elemId, aType, points );
break;
case "roundrect":
this._DrawRoundRect( msg, elemId, aType, points );
break;
case "line":
this._DrawLine( msg, elemId, aType, points );
break;
case "arrow":
this._DrawArrow( msg, elemId, aType, points );
break;
case "oval":
this._DrawOval( msg, elemId, aType, points );
break;
case "freeline":
this._DrawFreeLine( msg, elemId, aType, points );
break;
case "highlighter":
this._DrawHighLighter( msg, elemId, aType, points );
break;
case "xstamp":
this._DrawXStamp( msg, elemId, aType, points );
break;
case "arrowstamp":
this._DrawArrowStamp( msg, elemId, aType, points );
break;
case "checkstamp":
this._DrawCheckStamp( msg, elemId, aType, points );
break;
case "text":
this._DrawText( msg, elemId, aType, points );
break;
case "pointer":
this._DrawPointer( msg, elemId, aType, points );
break;
default:
g_ErrorHandling.ShowWarning( E_BADANNODATA );
}
}
AnnoPlayer.prototype.Reset = function( )
{
if ( this._renderer && this._renderer.Initialize )
{
this._renderer.Initialize();
}
this._textAnnos = {};
}
AnnoPlayer.GenBorderId = function( elemId )
{
return "_" + elemId + "_border";
}
AnnoPlayer.prototype._RendererAssignedHandler = function( renderer )
{
this._renderer.SetDefaultPageSize(
AnnoPlayer.DefaultPageWidth,
AnnoPlayer.DefaultPageHeight
);
}
Trace.Wrap( "AnnoPlayer" );
function AVPlayer( isAudio )
{
OOP.CallParentConstructor( this, arguments.callee );
this._resPagePlayerFlag = true;
this._customizeSeekCompleted = true;
this._isAudio = isAudio;
this._down = false;
this._error = false;
this._resetErrorTimer = null;
this._lowBandwidth = false;
this._initializedEvent.Add( Delegate( this, AVPlayer.prototype._InitializedHandler ) );
this._uninitializedEvent.Add( Delegate( this, AVPlayer.prototype._UninitializedHandler ) );
this._rendererAssignedEvent.Add( Delegate( this, AVPlayer.prototype._RendererAssignedHandler ) );
this._pageEnterEvent.Add( Delegate( this, AVPlayer.prototype.PageEnterHandler ) );
this._pageExitEvent.Add( Delegate( this, AVPlayer.prototype.PageExitHandler ) );
this._seekedEvent.Add( Delegate( this, AVPlayer.prototype._SeekHandler ) );
this._playEvent.Add( Delegate( this, AVPlayer.prototype._PlayHandler ) );
this._pauseEvent.Add( Delegate( this, AVPlayer.prototype._PauseHandler ) );
this._stopEvent.Add( Delegate( this, AVPlayer.prototype._StopHandler ) );
this._setRateEvent.Add( Delegate( this, AVPlayer.prototype._SetRateHandler ) );
this._setVolumeEvent.Add( Delegate( this, AVPlayer.prototype._SetVolumeHandler ) );
this._muteEvent.Add( Delegate( this, AVPlayer.prototype._MuteHandler ) );
this._syncEvent.Add( Delegate( this, AVPlayer.prototype._SyncHandler ) );
this._syncStateEvent.Add( Delegate( this, AVPlayer.prototype._SyncStateHandler ) );
this._pulsedEvent.Add( Delegate( this, AVPlayer.prototype._PulseHandler ) );
this._waitResumeEvent.Add( Delegate( this, AVPlayer.prototype._WaitResumeHandler ) );
this._applyResumeEvent.Add( Delegate( this, AVPlayer.prototype._ApplyResumeHandler ) );
this._isMediaEnded = false;
this._syncState = new Object();
this._syncState.executeSyncOperationFlag = true;
this._syncState.lastSyncPosition = -0.001;
this._syncState.bufferingPosition = -0.001;
this._syncState.advancedValue = 0;
this._syncState.waiting = false;
this._syncState.syncing = false;
this._syncState.targetPosition = -0.001;
this._syncState.syncDifference = AVPlayer.SyncThreshold ;
this._syncState.bufferingCounter = 0;
this._isServiceMode = UriUtils.IsWebUrl( GetPageRoot() );
}
OOP.Inherit( AVPlayer, PagedPlayer );
AVPlayer.SyncThreshold = 1.0;
AVPlayer.SyncModeThreshold = 10.0;
AVPlayer.SyncThresholdForSSR = 3.0;
AVPlayer.SyncShowThreshold = 4.0;
AVPlayer.SyncWaitingThreshold = -10.0;
AVPlayer.SyncFinishJudgement = 1.0;
AVPlayer.SyncTimeoutThreshold = 120;
AVPlayer.RateFastUp = 1.2;
AVPlayer.RateSlowDown = 0.8;
AVPlayer.prototype.GetRelativePosition = function ()
{
var pos = this._renderer.GetRelativePosition();
return pos;
}
AVPlayer.prototype.GetRate = function ()
{
var rate = this._renderer.GetRate();
return rate;
}
AVPlayer.prototype.GetVolume = function ()
{
var vol = this._renderer.GetVolume();
return vol;
}
AVPlayer.prototype.Enable = function( isEnable )
{
BasePlayer.prototype.Enable.call( this, isEnable );
if ( !this._renderer )
{
return;
}
if ( this._isAudio )
{
this._renderer.EnableAudio( isEnable );
}
else
{
this._renderer.SetStyle(
"visibility",
(isEnable ? "" : "hidden")
);
}
}
AVPlayer.prototype._InitializedHandler = function()
{
}
AVPlayer.prototype._UninitializedHandler = function()
{
}
AVPlayer.prototype.PageEnterHandler = function ( page, time, startTime, playstate, isEnable )
{
this._isMediaEnded = false;
this._ResetSyncState();
var url = page.url;
var entry = parseInt( page.entry, 10 );
if( page.isCodecChecker )
{
this._renderer.SetCodecCheckerFlag( true );
}
else
{
this._renderer.SetCodecCheckerFlag( false );
}
this._renderer.SetURI( playstate, url, entry, startTime );
this.Enable( isEnable );
if( page.width > 0 && page.height > 0 )
{
this._renderer.SetOriginalSize( page.width, page.height );
}
else
{
this._renderer.ApplyDefaultOriginalSize();
}
}
AVPlayer.prototype.PageExitHandler = function()
{
this._renderer.ApplyDefaultOriginalSize( );
this._renderer.Stop();
this._error = false;
if( this._resetErrorTimer != null )
{
clearTimeout( this._resetErrorTimer );
this._resetErrorTimer = null;
}
this._ResetSyncState();
}
AVPlayer.prototype._PlayHandler = function ()
{
if ( this._down || this._error )
{
return;
}
this._ResetSyncState();
if( !this._isMediaEnded )
{
this._renderer.Play();
}
}
AVPlayer.prototype._PauseHandler = function ()
{
if ( this._down || this._error )
{
return;
}
this._ResetSyncState();
if( !this._isMediaEnded )
{
this._renderer.Pause();
}
}
AVPlayer.prototype._StopHandler = function()
{
if ( this._down || this._error )
{
return;
}
this._ResetSyncState();
this._renderer.Stop();
}
AVPlayer.prototype._SeekHandler = function ( pos )
{
if ( this._down || this._error )
{
setTimeout( Delegate( this, this.SeekCompletedEvent ), 0 );
setTimeout( Delegate( this, this.ReadyEvent ), 0 );
return;
}
this._ResetSyncState();
var posInPage = this._GetPosInPage( pos );
if ( this._renderer.GetRate() != 1.0 )
{
this._renderer.SetRate( 1.0 );
}
this._renderer.Seek( posInPage, this._playerState.State );
}
AVPlayer.prototype._SetRateHandler = function ( rate )
{
if ( this._down || this._error )
{
return;
}
this._renderer.SetRate( rate );
}
AVPlayer.prototype._SetVolumeHandler = function ( vol )
{
if ( this._down || this._error )
{
return;
}
if ( this._renderer.IsAudioEnabled() )
{
this._renderer.SetVolume( vol );
}
}
AVPlayer.prototype._MuteHandler = function ( ismuted )
{
if ( this._down || this._error )
{
return;
}
if ( this._renderer.IsAudioEnabled() )
{
this._renderer.Mute( ismuted );
}
}
AVPlayer.prototype._SyncHandler = function( meetingState )
{
if( this._isServiceMode )
{
this._SyncHandlerForSSR( meetingState );
}
else
{
this._SyncHandlerForCSR( meetingState );
}
}
AVPlayer.prototype._SyncHandlerForCSR = function( meetingState )
{
if ( this._down || this._error )
{
return;
}
if( NavigatorInfo.IsFirefox() )
{
return;
}
else
if( NavigatorInfo.IsIE() )
{
this._SyncHandlerForIE( meetingState );
}
else
if( NavigatorInfo.IsSafari() )
{
this._SyncHandlerForSafari( meetingState);
}
}
AVPlayer.prototype._SyncHandlerForSSR = function ( meetingState )
{
if ( this._down || this._error )
{
return;
}
if ( this._playerState.State != MeetingSettings.MeetingState.Playing
|| meetingState.IsSeeking
|| !this._page
|| this._isMediaEnded)
{
return;
}
if( NavigatorInfo.IsFirefox() )
{
return;
}
var posRenderer = this._renderer.GetRelativePosition();
var posInPage = this._GetPosInPage( meetingState.MeetingPos );
if( posInPage < 0 )
{
return;
}
if( posRenderer == this._syncState.lastSyncPosition )
{
if( !this._syncState.waiting )
{
var simpleState = this._renderer.GetSimpleState();
if( this._syncState.executeSyncOperationFlag )
{
if( simpleState == WmvWidget.playState.Playing )
{
this._syncState.executeSyncOperationFlag = false;
this._syncState.bufferingPosition = posRenderer;
this._syncState.bufferingCounter = 0;
}
}
else
{
this._syncState.bufferingCounter++;
if( (this._syncState.bufferingCounter > AVPlayer.SyncTimeoutThreshold)
||(simpleState != WmvWidget.playState.Playing) )
{
this._ResetSyncState();
return;
}
}
}
}
else
{
if( this._syncState.syncing )
{
if( posRenderer -this._syncState.targetPosition > AVPlayer.SyncFinishJudgement )
{
var difference = posInPage - posRenderer;
this._syncState.advancedValue = this._syncState.advancedValue + difference;
this._syncState.syncDifference = (this._syncState.syncDifference + Math.abs(difference))/2;
if( this._syncState.syncDifference > AVPlayer.SyncThresholdForSSR )
{
this._syncState.syncDifference = AVPlayer.SyncThresholdForSSR;
}
else
if( this._syncState.syncDifference < AVPlayer.SyncThreshold )
{
this._syncState.syncDifference = AVPlayer.SyncThreshold;
}
this._syncState.syncing = false;
}
}
}
if( !this._syncState.executeSyncOperationFlag )
{
if( posRenderer - this._syncState.bufferingPosition >= AVPlayer.SyncShowThreshold )
{
this._syncState.executeSyncOperationFlag = true;
this._syncState.bufferingCounter = 0;
}
}
this._syncState.lastSyncPosition = posRenderer;
if( !this._syncState.executeSyncOperationFlag || this._syncState.syncing )
{
return;
}
this._SyncOperationForSSR( meetingState );
}
AVPlayer.prototype._SyncHandlerForIE = function( meetingState )
{
var posInPage = meetingState.MeetingPos - this._pageTime;
var posRenderer = this.GetRelativePosition();
if ( this._playerState.State == MeetingSettings.MeetingState.Playing &&
!this._renderer.IsBuffering() )
{
if ( (Math.abs( posInPage - posRenderer ) > AVPlayer.SyncModeThreshold)
&& (this._isAudio || ( !this._isAudio && !this._lowBandwidth )))
{
this._renderer.SeekWithoutCompletedEvent(
posInPage,
MeetingSettings.MeetingState.Playing );
}
else
{
if ( this._isAudio )
{
}
else
{
if ( Math.abs( posInPage - posRenderer ) > AVPlayer.SyncThreshold )
{
var rate = 1.0;
var curRate = this._renderer.GetRate();
if ( ( posInPage > posRenderer ) && ( curRate <= 1 ) )
{
this._renderer.SetRate( AVPlayer.RateFastUp );
}
else if ( ( posInPage < posRenderer ) && ( curRate >= 1 ) )
{
this._renderer.SetRate( AVPlayer.RateSlowDown );
}
}
else
{
if ( this._renderer.GetRate() != 1.0 )
{
this._renderer.SetRate( 1.0 );
}
}
}
}
}
}
AVPlayer.prototype._SyncHandlerForSafari = function( meetingState )
{
var posInPage = meetingState.MeetingPos - this._pageTime;
var posRenderer = this.GetRelativePosition();
if ( this._playerState.State == MeetingSettings.MeetingState.Playing &&
!this._renderer.IsBuffering() )
{
if ( (Math.abs( posInPage - posRenderer ) > AVPlayer.SyncThreshold))
{
this._renderer.SeekWithoutCompletedEvent(
posInPage,
MeetingSettings.MeetingState.Playing );
}
}
}
AVPlayer.prototype._SyncOperationForSSR = function( meetingState )
{
if ( this._playerState.State != MeetingSettings.MeetingState.Playing ||
this._renderer.IsBuffering() )
{
return;
}
var posInPage = this._GetPosInPage( meetingState.MeetingPos );
var posRenderer = this.GetRelativePosition();
var gap = posInPage - posRenderer;
if( gap > AVPlayer.SyncWaitingThreshold && gap <= (-1)*this._syncState.syncDifference )
{
if( !this._syncState.waiting && !this._syncState.syncing )
{
this._syncState.waiting = true;
this._renderer.Pause();
}
}
else
if( gap <= AVPlayer.SyncWaitingThreshold || gap >= this._syncState.syncDifference )
{
if( !this._syncState.syncing )
{
this._syncState.waiting = false;
this._syncState.syncing = true;
this._syncState.targetPosition = posInPage + this._syncState.advancedValue;
this._renderer.SeekWithoutCompletedEvent(
this._syncState.targetPosition,
MeetingSettings.MeetingState.Playing );
}
}
else
{
if( this._syncState.waiting )
{
this._syncState.waiting = false;
this._renderer.Play();
}
}
}
AVPlayer.prototype._ResetSyncState = function()
{
this._syncState.executeSyncOperationFlag = true;
this._syncState.lastSyncPosition = -0.001;
this._syncState.bufferingPosition = -0.001;
this._syncState.waiting = false;
this._syncState.syncing = false;
this._syncState.targetPosition = -0.001;
this._syncState.bufferingCounter = 0;
}
AVPlayer.prototype._SyncStateHandler = function( meetingState )
{
if ( this._down || this._error )
{
return;
}
if ( this._renderer.IsMuted() != meetingState.IsMute
&& this._enabled == true
&& this._renderer.IsAudioEnabled() )
{
this._renderer.Mute( meetingState.IsMute );
}
}
AVPlayer.prototype._PositionChangedHandler = function( oldPos, newPos )
{
this.ReadyEvent();
}
AVPlayer.prototype._PlayStateChangedHandler = function ( playstate )
{
try
{
if( this._renderer._htmlObject == null )
{
return;
}
var simpleState = this._renderer.GetSimpleState();
if( playstate == MeetingSettings.MeetingState.MediaEnded )
{
this._isMediaEnded = true;
}
if( playstate == MeetingSettings.MeetingState.Playing )
{
this._isMediaEnded = false;
}
if( this._playerState.State == MeetingSettings.MeetingState.Playing && this._renderer.IsBuffering() )
{
this.BufferingEvent();
}
else
{
this.ReadyEvent();
}
}
catch( e )
{
}
}
AVPlayer.prototype._RendererAssignedHandler = function ()
{
this._renderer.playStateChangedEvent.Add(
Delegate( this, AVPlayer.prototype._PlayStateChangedHandler )
);
this._renderer.positionChangedEvent.Add(
Delegate( this, AVPlayer.prototype._PositionChangedHandler )
);
this._renderer.seekCompletedEvent.Add(
Delegate( this, AVPlayer.prototype._SeekCompletedHandler )
);
this._renderer.errorEvent.Add(
Delegate( this, AVPlayer.prototype._WMVErrorHandler )
);
}
AVPlayer.prototype.ShutDown = function()
{
this._ResetSyncState();
this._renderer.Stop();
this._down = true;
}
AVPlayer.prototype.Reconnect = function()
{
this._down = false;
this._ResetSyncState();
if ( this._playerState.State == MeetingSettings.MeetingState.Playing )
{
if( NavigatorInfo.IsIE() )
{
this.Play();
this.SyncState( this._playerState );
this.Sync( this._playerState );
}
else
{
var posInPage = this._GetPosInPage( this._playerState.MeetingPos );
this._renderer.SeekWithoutCompletedEvent(
posInPage,
MeetingSettings.MeetingState.Playing );
this.SyncState( this._playerState );
}
}
}
AVPlayer.prototype._PulseHandler = function( pos )
{
if ( this._down )
{
return;
}
var posInPage = this._GetPosInPage( pos );
this._renderer.UpdateCurrentPosition( posInPage );
}
AVPlayer.prototype._SeekCompletedHandler = function()
{
this.SeekCompletedEvent();
}
AVPlayer.prototype._WaitResumeHandler = function()
{
if( (NavigatorInfo.IsIE() && this._isAudio && this._lowBandwidth)
|| (!NavigatorInfo.IsFirefox() && this._isServiceMode ) )
{
this._renderer.Pause();
}
else
{
this._renderer.SetRate( MeetingSettings.WaitResumeAVRate );
}
}
AVPlayer.prototype._ApplyResumeHandler = function()
{
if( (NavigatorInfo.IsIE() && this._isAudio && this._lowBandwidth)
||(!NavigatorInfo.IsFirefox() && this._isServiceMode ) )
{
if ( this._playerState.State == MeetingSettings.MeetingState.Playing )
{
this._renderer.Play();
}
}
else
{
this._renderer.SetRate( 1.0000 );
}
}
AVPlayer.prototype._WMVErrorHandler = function()
{
this._error = true;
this._ResetSyncState();
this.ReadyEvent();
if( this._resetErrorTimer != null )
{
clearTimeout( this._resetErrorTimer );
this._resetErrorTimer = null;
}
this._resetErrorTimer = setTimeout(
Delegate(
this,
AVPlayer.prototype._ResetError
),
5000 );
}
AVPlayer.prototype._ResetError = function()
{
this._ResetSyncState();
this._resetErrorTimer = null;
this._error = false;
this._renderer.Reset();
}
AVPlayer.prototype.SetLowBandwidth = function( isLow )
{
this._lowBandwidth = isLow;
}
Trace.Wrap( "AVPlayer" );
function FlashPlayer( isAudio )
{
OOP.CallParentConstructor( this, arguments.callee );
this._isAudio = isAudio;
this._down = false;
this._initializedEvent.Add( Delegate( this, FlashPlayer.prototype._InitializedHandler ) );
this._uninitializedEvent.Add( Delegate( this, FlashPlayer.prototype._UninitializedHandler ) );
this._rendererAssignedEvent.Add( Delegate( this, FlashPlayer.prototype._RendererAssignedHandler ) );
this._pageEnterEvent.Add( Delegate( this, FlashPlayer.prototype.PageEnterHandler ) );
this._pageExitEvent.Add( Delegate( this, FlashPlayer.prototype.PageExitHandler ) );
this._seekedEvent.Add( Delegate( this, FlashPlayer.prototype._SeekHandler ) );
this._playEvent.Add( Delegate( this, FlashPlayer.prototype._PlayHandler ) );
this._pauseEvent.Add( Delegate( this, FlashPlayer.prototype._PauseHandler ) );
this._stopEvent.Add( Delegate( this, FlashPlayer.prototype._StopHandler ) );
this._setRateEvent.Add( Delegate( this, FlashPlayer.prototype._SetRateHandler ) );
this._setVolumeEvent.Add( Delegate( this, FlashPlayer.prototype._SetVolumeHandler ) );
this._muteEvent.Add( Delegate( this, FlashPlayer.prototype._MuteHandler ) );
this._syncEvent.Add( Delegate( this, FlashPlayer.prototype._SyncHandler ) );
this._syncStateEvent.Add( Delegate( this, FlashPlayer.prototype._SyncStateHandler ) );
this._isMediaEnded = false;
}
OOP.Inherit( FlashPlayer, PagedPlayer );
FlashPlayer.SyncThreshold = 1.0;
FlashPlayer.SyncModeThreshold = 10.0;
FlashPlayer.prototype.GetRelativePosition = function ()
{
var pos = this._renderer.GetRelativePosition();
return pos;
}
FlashPlayer.prototype.GetRate = function ()
{
var rate = this._renderer.GetRate();
return rate;
}
FlashPlayer.prototype.GetVolume = function ()
{
var vol = this._renderer.GetVolume();
return vol;
}
FlashPlayer.prototype.Enable = function( isEnable )
{
BasePlayer.prototype.Enable.call( this, isEnable );
if ( !this._renderer )
{
return;
}
if ( this._isAudio )
{
this._renderer.Mute( !isEnable );
}
else
{
this._renderer.SetStyle(
"visibility",
(isEnable ? "" : "hidden")
);
}
}
FlashPlayer.prototype._InitializedHandler = function()
{
}
FlashPlayer.prototype._UninitializedHandler = function()
{
}
FlashPlayer.prototype.PageEnterHandler = function ( page, time, startTime, playstate, isEnable )
{
this._isMediaEnded = false;
var url = page.url;
var entry = parseInt( page.entry, 10 );
this._renderer.SetURI( playstate, url, entry, startTime );
if( page.width > 0 && page.height > 0 )
{
this._renderer.SetOriginalSize( page.width, page.height );
}
else
{
this._renderer.ApplyDefaultOriginalSize();
}
this.Enable( isEnable );
}
FlashPlayer.prototype.PageExitHandler = function()
{
this._renderer._UnloadFile();
}
FlashPlayer.prototype._PlayHandler = function ()
{
if ( this._down )
{
return;
}
if( !this._isMediaEnded )
{
this._renderer.Play();
}
}
FlashPlayer.prototype._PauseHandler = function ()
{
if ( this._down )
{
return;
}
if( !this._isMediaEnded )
{
this._renderer.Pause();
}
}
FlashPlayer.prototype._StopHandler = function()
{
if ( this._down )
{
return;
}
this._renderer.Stop();
}
FlashPlayer.prototype._SeekHandler = function ( pos )
{
if ( this._down )
{
return;
}
var posInPage = this._GetPosInPage( pos );
this._renderer.SetPosition( posInPage, this._playerState.State );
}
FlashPlayer.prototype._SetRateHandler = function ( rate )
{
if ( this._down )
{
return;
}
this._renderer.SetRate( rate );
}
FlashPlayer.prototype._SetVolumeHandler = function ( vol )
{
if ( this._down )
{
return;
}
this._renderer.SetVolume( vol );
}
FlashPlayer.prototype._MuteHandler = function ( ismuted )
{
if ( this._down )
{
return;
}
this._renderer.Mute( ismuted );
}
FlashPlayer.prototype._SyncHandler = function ( meetingState )
{
}
FlashPlayer.prototype._SyncStateHandler = function( meetingState )
{
if ( this._down )
{
return;
}
if ( this._renderer.IsMuted() != meetingState.IsMute && this._enabled == true )
{
this._renderer.Mute( meetingState.IsMute );
}
}
FlashPlayer.prototype._PlayStateChangedHandler = function ( playstate )
{
try
{
if( this._renderer._htmlObject == null )
{
return;
}
var simpleState = this._renderer.GetSimpleState();
if( playstate == MeetingSettings.MeetingState.MediaEnded )
{
this._isMediaEnded = true;
}
if( playstate == MeetingSettings.MeetingState.Playing )
{
this._isMediaEnded = false;
}
if( this._playerState.State == MeetingSettings.MeetingState.Playing )
{
if( simpleState == MeetingSettings.MeetingState.Buffering )
{
this.BufferingEvent();
}
else
{
this.ReadyEvent();
}
}
}
catch( e )
{
}
}
FlashPlayer.prototype._OperationFailedHandler = function( operationName )
{
readyOperations = { "SetURI":1, "Play":1 };
if( operationName in readyOperations )
{
this.ReadyEvent();
}
}
FlashPlayer.prototype._RendererAssignedHandler = function ()
{
this._renderer.playStateChangedEvent.Add(
Delegate( this, FlashPlayer.prototype._PlayStateChangedHandler )
);
this._renderer.operationFailedEvent.Add(
Delegate( this, FlashPlayer.prototype._OperationFailedHandler ) );
}
FlashPlayer.prototype.ShutDown = function()
{
this.Stop();
this._down = true;
}
FlashPlayer.prototype.Reconnect = function()
{
this._down = false;
if ( this._playerState.State == MeetingSettings.MeetingState.Playing )
{
this.Play();
this.SyncState( this._playerState );
this.Sync( this._playerState );
}
}
Trace.Wrap( "FlashPlayer" );
function MMCPlayer( )
{
OOP.CallParentConstructor( this, arguments.callee );
this._mediaPlayer = new AVPlayer( false );
this._flashPlayer = new FlashPlayer( false );
this._player = null;
this._forceInteractionUpdate = false;
this._interactionEnabled = false;
this._MMCState = MMCPlayer.State.Stopped;
this._oldMMCState = MMCPlayer.State.Stopped;
this._mediaTimeOfLastCmd = 0;
this._cmdTime = 0;
this._posChanged = false;
this._resPagePlayerFlag = true;
this._customizeSeekCompleted = true;
this._rendererAssignedEvent.Add( Delegate( this, MMCPlayer.prototype._RendererAssignedHandler ) );
this._pageEnterEvent.Add( Delegate( this, MMCPlayer.prototype._PageEnterHandler ) );
this._pageExitEvent.Add( Delegate( this, MMCPlayer.prototype._PageExitHandler ) );
this._BeforeProcMsgEvent.Add( Delegate( this, MMCPlayer.prototype._BeforeProcMsgHandler ) );
this._AfterProcMsgEvent.Add( Delegate( this, MMCPlayer.prototype._AfterProcMsgHandler ) );
this._playEvent.Add( Delegate( this, MMCPlayer.prototype._PlayHandler ) );
this._seekedEvent.Add( Delegate( this, MMCPlayer.prototype._SeekHandler ) );
this._pauseEvent.Add( Delegate( this, MMCPlayer.prototype._PauseHandler ) );
this._setVolumeEvent.Add( Delegate( this, MMCPlayer.prototype._SetVolumeHandler ) );
this._muteEvent.Add( Delegate( this, MMCPlayer.prototype._MuteHandler ) );
this._syncEvent.Add( Delegate( this, MMCPlayer.prototype._SyncHandler ) );
this._syncStateEvent.Add( Delegate( this, MMCPlayer.prototype._SyncStateHandler ) );
this._pulsedEvent.Add( Delegate( this, MMCPlayer.prototype._PulseHandler ) );
this._mediaPlayer.ReadyEvent.Add( Delegate( this, MMCPlayer.prototype._InnerPlayerReady ) );
this._mediaPlayer.BufferingEvent.Add( Delegate( this, MMCPlayer.prototype._InnerPlayerBuffering ) );
this._flashPlayer.ReadyEvent.Add( Delegate( this, MMCPlayer.prototype._InnerPlayerReady ) );
this._flashPlayer.BufferingEvent.Add( Delegate( this, MMCPlayer.prototype._InnerPlayerBuffering ) );
this._waitResumeEvent.Add( Delegate( this, MMCPlayer.prototype._WaitResumeHandler ) );
this._applyResumeEvent.Add( Delegate( this, MMCPlayer.prototype._ApplyResumeHandler ) );
}
OOP.Inherit( MMCPlayer, PagedPlayer );
MMCPlayer.State = { "Playing":3,"Paused":2,"Stopped":1 }
MMCPlayer.prototype.Reset = function()
{
if ( !this._player )
{
return;
}
this._ResetMembers();
this._player.Stop();
this._rendererHolder.EnableInteraction( this._interactionEnabled, true );
this._rendererHolder.Reset();
}
MMCPlayer.prototype._ResetMembers = function()
{
this._MMCState = MMCPlayer.State.Stopped;
this._mediaTimeOfLastCmd = 0;
this._cmdTime = 0;
this._interactionEnabled = false;
}
MMCPlayer.prototype._RendererAssignedHandler = function( renderer )
{
this._rendererHolder = renderer;
this._mediaPlayer.AssignRenderer( renderer.GetWidget( UISettings.mmcWmvWidgetId ) );
this._flashPlayer.AssignRenderer( renderer.GetWidget( UISettings.mmcFlashWidgetId ) );
this._mediaPlayer.SeekCompletedEvent.Add( Delegate( this, this.SeekCompletedEvent ) );
this._flashPlayer.SeekCompletedEvent.Add( Delegate( this, this.SeekCompletedEvent ) );
}
MMCPlayer.prototype._PageEnterHandler = function( page, time, startTime, playstate, isEnable )
{
if ( !page.format )
{
g_ErrorHandling.ShowWarning( E_MMCNOFORMAT );
return;
}
this._ResetMembers();
if ( startTime > 0 )
{
this._mediaTimeOfLastCmd = startTime;
}
else
{
this._mediaTimeOfLastCmd = 0;
}
this._cmdTime = time;
MMCPlayer.ProcessPageData( page );
var fmt = page.format.toLowerCase();
var widgetId = UISettings.mmcWmvWidgetId;
if ( fmt == "av" )
{
this._player = this._mediaPlayer;
widgetId = UISettings.mmcWmvWidgetId;
this._rendererHolder.EnableInteraction( false, true );
this._player.EnterPage(
page,
time,
startTime,
MeetingSettings.MeetingState.Stopped,
isEnable );
this._rendererHolder.SetActiveWidget( widgetId );
this._rendererHolder.SetClipRect( 0, 0, page.width, page.height );
}
else if ( fmt == "flash" )
{
this._player = this._flashPlayer;
widgetId = UISettings.mmcFlashWidgetId;
this._rendererHolder.EnableInteraction( false, true );
this._player.EnterPage(
page,
time,
startTime,
MeetingSettings.MeetingState.Stopped,
isEnable );
this._rendererHolder.SetActiveWidget( widgetId );
}
else
{
g_ErrorHandling.ShowWarning( E_MMCNOFORMAT );
this._player = null;
return;
}
this._innerMessages = this._page.MMCChanged;
this.ReadyEvent();
}
MMCPlayer.prototype._PageExitHandler = function( bDif )
{
if ( this._player )
{
this._player.ExitPage( bDif );
}
}
MMCPlayer.prototype._PlayHandler = function()
{
if ( this._player && this._MMCState == MeetingSettings.MeetingState.Playing )
{
this._player.Play( );
this.Seek( this._playerState.MeetingPos );
}
}
MMCPlayer.prototype._PauseHandler = function()
{
if ( this._player )
{
this._player.Pause();
}
}
MMCPlayer.prototype._SeekHandler = function( pos )
{
if( this._player && this._MMCState == MeetingSettings.MeetingState.Playing )
{
this._player.Seek( this._pageTime + this._GetMediaPosFromMeetingPos( pos ) );
}
else
{
this.SeekCompletedEvent();
this.ReadyEvent();
}
}
MMCPlayer.prototype._SetVolumeHandler = function( vol )
{
if ( this._player )
{
this._player.SetVolume( vol );
}
}
MMCPlayer.prototype._MuteHandler = function( isMute )
{
if ( this._player )
{
this._player.Mute( isMute );
}
}
MMCPlayer.prototype._UpdateMMCChanged = function( msg )
{
if ( !msg.action )
{
g_ErrorHandling.ShowWarning( E_MMCBADMESSAGE );
return;
}
var action = msg.action.toLowerCase();
var posMedia = parseFloat( msg.position );
switch (action)
{
case "play":
this._interactionEnabled = false;
this._forceInteractionUpdate = false;
this._MMCState = MMCPlayer.State.Playing;
if ( !isNaN( posMedia ) && posMedia >= 0 )
{
this._mediaTimeOfLastCmd = posMedia;
}
this._cmdTime = msg.time;
break;
case "stop":
this._interactionEnabled = false;
this._forceInteractionUpdate = false;
this._MMCState = MMCPlayer.State.Stopped;
if ( !isNaN( posMedia ) && posMedia >= 0 )
{
this._mediaTimeOfLastCmd = posMedia;
}
else
{
this._mediaTimeOfLastCmd = 0;
}
this._cmdTime = msg.time;
break;
case "pause":
this._interactionEnabled = false;
this._forceInteractionUpdate = false;
this._MMCState = MMCPlayer.State.Paused;
if ( !isNaN( posMedia ) && posMedia >= 0 )
{
this._mediaTimeOfLastCmd = posMedia;
}
this._cmdTime = msg.time;
break;
case "seekto":
if ( !isNaN( posMedia ) && posMedia >= 0 )
{
this._mediaTimeOfLastCmd = posMedia;
}
this._cmdTime = msg.time;
break;
case "enableinteraction":
this._interactionEnabled = true;
this._forceInteractionUpdate = true;
break;
case "disableinteraction":
this._interactionEnabled = false;
this._forceInteractionUpdate = true;
break;
default:
g_ErrorHandling.ShowWarning( E_MMCBADMESSAGE );
return;
}
}
MMCPlayer.prototype._UpdateERChanged = function( msg )
{
var left = msg.left;
var top = msg.top;
var width = msg.width;
var height = msg.height;
this._rendererHolder.SetClipRect( left, top, width, height );
}
MMCPlayer.prototype.Update = function( msg )
{
if ( !this._player )
{
return;
}
if ( msg.eventName == "RectChanged" )
{
this._UpdateERChanged( msg );
}
else if ( msg.eventName == "MMCChanged" )
{
this._UpdateMMCChanged( msg );
}
else
{
}
var posChangedEvents = { "play":1, "stop":1, "pause":1, "seekto":1 };
var fmt = this._page.format.toLowerCase();
if( msg.action in posChangedEvents )
{
this._posChanged = true;
}
}
MMCPlayer.prototype._BeforeProcMsgHandler = function( curPos, tarIndex, isSeek )
{
this._oldMMCState = this._MMCState;
this._flashPosChanged = false;
this._forceInteractionUpdate = false;
}
MMCPlayer.prototype._AfterProcMsgHandler = function( curPos, tarIndex, isSeek )
{
this._rendererHolder.EnableInteraction( this._interactionEnabled, this._forceInteractionUpdate );
if ( this._oldMMCState == this._MMCState )
{
if( this._posChanged )
{
this._player.Seek( this._pageTime + this._mediaTimeOfLastCmd );
}
return;
}
var tarState = this._CalcState( this._MMCState, this._playerState.State );
switch( tarState )
{
case MMCPlayer.State.Playing:
this._player.Play();
if( this._posChanged )
{
var fmt = this._page.format.toLowerCase();
var tarTime = this._pageTime + this._mediaTimeOfLastCmd;
if( this._player != null && fmt == "av" )
{
tarTime += curPos - this._cmdTime;
}
this._player.Seek( tarTime );
}
break;
case MMCPlayer.State.Paused:
this._player.Pause();
break;
case MMCPlayer.State.Stopped:
this._player.Stop();
break;
default:
}
}
MMCPlayer.prototype._CalcState = function( mmcState, globalState )
{
if ( globalState == MeetingSettings.MeetingState.Playing )
{
return mmcState;
}
return globalState;
}
MMCPlayer.ProcessPageData = function ( page )
{
if ( page.MMCChanged == null )
{
return;
}
if ( page.MMCChanged.length == 0 )
{
return;
}
var lastCmdMediaTime = 0;
var lastCmdTime = 0;
var lastStateCmdAction = "stopped";
for ( var i = 0; i < page.MMCChanged.length; i++ )
{
var curMsg = page.MMCChanged[i];
if ( curMsg.eventName == "RectChanged" )
{
continue;
}
curMsg.action = curMsg.action.toLowerCase();
if ( curMsg.position == null )
{
if ( curMsg.action == "stop" )
{
curMsg.position = 0;
}
else
{
if ( lastStateCmdAction == "play" )
{
curMsg.position =
lastCmdMediaTime + ( curMsg.time - lastCmdTime );
}
else
{
curMsg.position = lastCmdMediaTime;
}
}
}
else
{
curMsg.position = parseFloat( curMsg.position );
if (isNaN( curMsg.position ) )
{
curMsg.position = 0;
g_ErrorHandling.ShowWarning( E_MMCBADMESSAGE );
}
}
if ( curMsg.action == "play"
|| curMsg.action == "pause"
|| curMsg.action == "stop" )
{
lastCmdMediaTime = curMsg.position;
lastCmdTime = curMsg.time;
lastStateCmdAction = curMsg.action;
}
else if ( curMsg.action.toLowerCase() == "seekto" )
{
lastCmdMediaTime = curMsg.position;
lastCmdTime = curMsg.time;
}
}
}
MMCPlayer.prototype._SyncHandler = function( meetingState )
{
if ( !this._player || this._interactionEnabled == true )
{
return;
}
if ( meetingState.State == MeetingSettings.MeetingState.Playing )
{
var ms = this._GetMeetingState( meetingState );
this._player.Sync( ms );
}
}
MMCPlayer.prototype._SyncStateHandler = function( meetingState )
{
if ( !this._player )
{
return;
}
var ms = this._GetMeetingState( meetingState );
this._player.SyncState( ms );
}
MMCPlayer.prototype._PulseHandler = function( pos )
{
if( !this._player )
{
return;
}
this._player.Pulse( this._pageTime + this._GetMediaPosFromMeetingPos( pos ) );
}
MMCPlayer.prototype._GetMeetingState = function( meetingState )
{
var ms = new MeetingSettings.MeetingStateClass(
meetingState.State,
meetingState.Speed,
meetingState.Volume,
meetingState.IsMute,
meetingState.MeetingPos,
meetingState.IsSeeking
);
ms.MeetingPos = this._pageTime + this._GetMediaPosFromMeetingPos( meetingState.MeetingPos );
return ms;
}
MMCPlayer.prototype._GetMediaPosFromMeetingPos = function( meetingPos )
{
return this._mediaTimeOfLastCmd + meetingPos - this._cmdTime;
}
MMCPlayer.prototype._WaitResumeHandler = function()
{
if ( this._playerState.State == MeetingSettings.MeetingState.Playing )
{
if ( this._player && this._player.SetRate )
{
this._player.SetRate( MeetingSettings.WaitResumeAVRate );
}
}
}
MMCPlayer.prototype._ApplyResumeHandler = function()
{
if ( this._playerState.State == MeetingSettings.MeetingState.Playing )
{
if ( this._player && this._player.SetRate )
{
this._player.SetRate( 1.0 );
}
}
}
MMCPlayer.prototype._InnerPlayerReady = function()
{
this.ReadyEvent();
}
MMCPlayer.prototype._InnerPlayerBuffering = function()
{
this.BufferingEvent();
}
MMCPlayer.prototype.SetLowBandwidth = function( isLow )
{
if( this._mediaPlayer )
{
this._mediaPlayer.SetLowBandwidth( isLow );
}
}
Trace.Wrap( "MMCPlayer" );
function AppSharingPlayer( )
{
OOP.CallParentConstructor( this, arguments.callee );
this._player = new AVPlayer( false );
this._startTime = 0;
this._resPagePlayerFlag = true;
this._customizeSeekCompleted = true;
this._rendererAssignedEvent.Add( Delegate( this, AppSharingPlayer.prototype._RendererAssignedHandler ) );
this._pageEnterEvent.Add( Delegate( this, AppSharingPlayer.prototype._PageEnterHandler ) );
this._pageExitEvent.Add( Delegate( this, AppSharingPlayer.prototype._PageExitHandler ) );
this._playEvent.Add( Delegate( this, AppSharingPlayer.prototype._PlayHandler ) );
this._seekedEvent.Add( Delegate( this, AppSharingPlayer.prototype._SeekHandler ) );
this._pauseEvent.Add( Delegate( this, AppSharingPlayer.prototype._PauseHandler ) );
this._setVolumeEvent.Add( Delegate( this, AppSharingPlayer.prototype._SetVolumeHandler ) );
this._muteEvent.Add( Delegate( this, AppSharingPlayer.prototype._MuteHandler ) );
this._syncEvent.Add( Delegate( this, AppSharingPlayer.prototype._SyncHandler ) );
this._syncStateEvent.Add( Delegate( this, AppSharingPlayer.prototype._SyncStateHandler ) );
this._pulsedEvent.Add( Delegate( this, AppSharingPlayer.prototype._PulseHandler ) );
this._player.ReadyEvent.Add( Delegate( this, AppSharingPlayer.prototype._InnerPlayerReady ) );
this._player.BufferingEvent.Add( Delegate( this, AppSharingPlayer.prototype._InnerPlayerBuffering ) );
this._waitResumeEvent.Add( Delegate( this, AppSharingPlayer.prototype._WaitResumeHandler ) );
this._applyResumeEvent.Add( Delegate( this, AppSharingPlayer.prototype._ApplyResumeHandler ) );
}
OOP.Inherit( AppSharingPlayer, PagedPlayer );
AppSharingPlayer.State = { "Playing":3,"Paused":2,"Stopped":1 }
AppSharingPlayer.prototype.Reset = function()
{
if ( !this._player )
{
return;
}
this._ResetMembers();
this._rendererHolder.Reset();
this._rendererHolder.SetClipRect( 0, 0, this._page.width, this._page.height )
this._player.Seek( this._pageTime );
}
AppSharingPlayer.prototype._ResetMembers = function()
{
}
AppSharingPlayer.prototype._RendererAssignedHandler = function( renderer )
{
this._rendererHolder = renderer;
if( !renderer.CanPlayASWmv || !renderer.CanPlayASWmv() )
{
this._player = null;
}
else
{
this._player.AssignRenderer( renderer.GetWidget( UISettings.asWmvWidgetId ) );
this._player.SeekCompletedEvent.Add( Delegate( this, this.SeekCompletedEvent ) );
}
}
AppSharingPlayer.prototype._PageEnterHandler = function( page, time, startTime, playstate, isEnable )
{
if ( !page.format )
{
g_ErrorHandling.ShowWarning( E_MMCNOFORMAT );
return;
}
this._ResetMembers();
if ( startTime > 0 )
{
this._startTime = startTime;
}
else
{
this._startTime = 0;
}
if( this._player )
{
this._player.EnterPage(
page,
time,
startTime,
playstate,
isEnable );
if( page.url != null )
{
this._rendererHolder.SetActiveWidget( UISettings.asWmvWidgetId );
}
else
{
this._rendererHolder.SetActiveWidget( UISettings.asImageWidgetId );
}
this._rendererHolder.SetClipRect( 0, 0, page.width, page.height );
this._innerMessages = this._page.MMCChanged;
}
this.ReadyEvent();
}
AppSharingPlayer.prototype._PageExitHandler = function( bDif )
{
if ( this._player )
{
this._player.ExitPage( bDif );
}
}
AppSharingPlayer.prototype._PlayHandler = function()
{
if ( this._player )
{
this._player.Play( );
}
}
AppSharingPlayer.prototype._PauseHandler = function()
{
if ( this._player )
{
this._player.Pause();
}
}
AppSharingPlayer.prototype._SeekHandler = function( pos )
{
if( this._player )
{
this._player.Seek( pos );
}
else
{
this.SeekCompletedEvent();
this.ReadyEvent();
}
}
AppSharingPlayer.prototype._SetVolumeHandler = function( vol )
{
if ( this._player )
{
this._player.SetVolume( vol );
}
}
AppSharingPlayer.prototype._MuteHandler = function( isMute )
{
if ( this._player )
{
this._player.Mute( isMute );
}
}
AppSharingPlayer.prototype._UpdateERChanged = function( msg )
{
if( !this._player )
{
return;
}
var left = msg.left;
var top = msg.top;
var width = msg.width;
var height = msg.height;
this._rendererHolder.SetClipRect( left, top, width, height );
}
AppSharingPlayer.prototype.Update = function( msg )
{
if ( !this._player )
{
return;
}
if ( msg.eventName == "RectChanged" )
{
this._UpdateERChanged( msg );
}
}
AppSharingPlayer.prototype._SyncHandler = function( meetingState )
{
if ( !this._player )
{
return;
}
if ( meetingState.State == MeetingSettings.MeetingState.Playing )
{
this._player.Sync( meetingState );
}
}
AppSharingPlayer.prototype._SyncStateHandler = function( meetingState )
{
if ( !this._player )
{
return;
}
this._player.SyncState( meetingState );
}
AppSharingPlayer.prototype._WaitResumeHandler = function()
{
if ( this._playerState.State == MeetingSettings.MeetingState.Playing )
{
if ( this._player && this._player.SetRate )
{
this._player.SetRate( MeetingSettings.WaitResumeAVRate );
}
}
}
AppSharingPlayer.prototype._ApplyResumeHandler = function()
{
if ( this._playerState.State == MeetingSettings.MeetingState.Playing )
{
if ( this._player && this._player.SetRate )
{
this._player.SetRate( 1.0 );
}
}
}
AppSharingPlayer.prototype._InnerPlayerReady = function()
{
this.ReadyEvent();
}
AppSharingPlayer.prototype._InnerPlayerBuffering = function()
{
this.BufferingEvent();
}
AppSharingPlayer.prototype.SetLowBandwidth = function( isLow )
{
if( this._player )
{
this._player.SetLowBandwidth( isLow );
}
}
AppSharingPlayer.prototype._PulseHandler = function( pos )
{
if( !this._player )
{
return;
}
this._player.Pulse( pos );
}
Trace.Wrap( "AppSharingPlayer" );
function StartPagePlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._meetingInfo = null;
this._rendererAssignedEvent.Add(
Delegate(this, StartPagePlayer.prototype.RendererAssignedHandler)
);
}
OOP.Inherit( StartPagePlayer, PagedPlayer );
StartPagePlayer.prototype.SetMeetingInfo = function( meetingInfo )
{
this._meetingInfo = meetingInfo;
}
StartPagePlayer.prototype.RendererAssignedHandler = function( renderer )
{
if ( renderer && renderer.SetMeetingInfo )
{
renderer.SetMeetingInfo( this._meetingInfo );
}
}
Trace.Wrap("StartPagePlayer");
function ImagePlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
if ( GetPageRoot().substring( 0, 4 ) == "http" )
{
this._resPagePlayerFlag = true;
this._seekedEvent.Add( Delegate( this, ImagePlayer.prototype._SeekHandler ) );
}
this._loadedflag = false;
this._pageEnterEvent.Add( Delegate( this, ImagePlayer.prototype._PageEnterHandler ) );
this._rendererAssignedEvent.Add( Delegate( this, ImagePlayer.prototype._RendererAssignedHandler ) );
}
OOP.Inherit( ImagePlayer, WithAnnoPlayer );
ImagePlayer.prototype._RendererAssignedHandler = function( renderer )
{
if ( GetPageRoot().substring( 0, 4 ) == "http" )
{
this._renderer._AfterLoadedEvent.Add( Delegate( this, ImagePlayer.prototype._LoadedHandler ) );
}
}
ImagePlayer.prototype._LoadedHandler = function()
{
this._loadedflag = true;
this.ReadyEvent();
}
ImagePlayer.prototype._SeekHandler = function()
{
if ( !this._resPagePlayerFlag || this._loadedflag )
{
this.ReadyEvent();
}
}
ImagePlayer.prototype.GetRelativePosition = function ()
{
return 0;
}
ImagePlayer.prototype.GetRate = function ()
{
return 1.0;
}
ImagePlayer.prototype._PageEnterHandler = function ( page, time, startTime )
{
var url = page.url;
if ( this._renderer )
{
this._loadedflag = false;
this._renderer.SetURI( url );
if( page.width > 0 && page.height > 0 )
{
this._renderer.SetOriginalSize( page.width, page.height );
}
else
{
this._renderer.ApplyDefaultOriginalSize();
}
}
}
function QAPlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( QAPlayer, IndexBasePlayer );
QAPlayer.HighLightThreshold = 60.0;
QAPlayer.prototype.SetIndexData = function( indexData )
{
this._indexData = indexData;
var i;
for( i = 0; i < this._indexData.length; i++ )
{
this._indexData[i]._actived = false;
}
}
QAPlayer.prototype.Pulse = function ( pos )
{
var idx = SearchItemWithTime( pos, this._indexData );
if ( this._originalIndex != idx )
{
if ( this._originalIndex != null && this._originalIndex >= 0 )
{
this.IndexChanged( this._originalIndex, false );
}
if ( idx != null && idx >= 0 )
{
this.IndexChanged( idx, true );
}
this._originalIndex = idx;
}
}
function NotesPlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._uri = null;
}
OOP.Inherit( NotesPlayer, BasePlayer );
NotesPlayer.prototype.AssignRenderer = function( renderer )
{
BasePlayer.prototype.AssignRenderer.apply(
this,
arguments );
this._renderer.SetURI( this._uri );
}
NotesPlayer.prototype.SetURI = function( uri )
{
if ( CheckFileExist( uri ) )
{
this._uri = uri;
}
else
{
this._uri = null;
}
}
function WebPlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._pageEnterEvent.Add( Delegate( this, WebPlayer.prototype._PageEnterHandler ) );
}
OOP.Inherit( WebPlayer, PagedPlayer );
WebPlayer.prototype.GetRelativePosition = function ()
{
return 0;
}
WebPlayer.prototype.GetRate = function ()
{
return 1.0;
}
WebPlayer.prototype._PageEnterHandler = function ( page, time, startTime )
{
var url = null;
if ( ! page.webhref )
{
url = null;
}
else
{
url = page.webhref;
}
if ( this._renderer )
{
this._renderer.SetURI( url, page.url );
}
}
function GlobalTimerPlayer()
{
this._duration      = -1;
this._currentPos    = 0;
this._state         = MeetingSettings.MeetingState.Ready ;
this._rate          = 1.0;
this._refTime       = 0;
this._meetingOffsetByRefTime = 0;
this._timer         = CreateLMTimer( this,
Delegate( this, GlobalTimerPlayer.prototype._onUpdateTimer ),
100 );
this.onTimerEvent = new Event();
}
GlobalTimerPlayer.prototype._UpdateTime = function ( )
{
var dt = new Date();
if ( dt < this._refTime )
{
this._refTime = dt;
}
this._meetingOffsetByRefTime = ( dt - this._refTime ) * this._rate * 0.001 + this._meetingOffsetByRefTime;
if ( this._duration >= 0 )
{
if ( this._meetingOffsetByRefTime > this._duration )
{
this._meetingOffsetByRefTime = this._duration;
this._state = MeetingSettings.MeetingState.MediaEnded;
}
}
this._refTime = dt;
this._currentPos = this._meetingOffsetByRefTime;
}
GlobalTimerPlayer.prototype._onUpdateTimer = function( )
{
if (( this._state == MeetingSettings.MeetingState.Playing )
||( this._state == MeetingSettings.MeetingState.ScanForward ))
{
this._UpdateTime();
}
this.onTimerEvent( this._currentPos );
}
GlobalTimerPlayer.prototype.Initialize = function ()
{
this._refTime    = new Date();
this._meetingOffsetByRefTime = 0;
this._currentPos = 0;
this._state      = MeetingSettings.MeetingState.Ready ;
EnableLMTimer( this._timer, true );
}
GlobalTimerPlayer.prototype.SetDuration = function( dur )
{
this._duration = dur;
}
GlobalTimerPlayer.prototype.SetPosition = function( pos )
{
if ( this._duration >= 0 )
{
}
if ( this._state == MeetingSettings.MeetingState.MediaEnded )
{
this.Pause();
}
this._meetingOffsetByRefTime = pos;
this._refTime = new Date();
this._currentPos = pos;
}
GlobalTimerPlayer.prototype.GetRelativePosition = function( )
{
return this._currentPos;
}
GlobalTimerPlayer.prototype._InnerPause = function( )
{
if (( this._state == MeetingSettings.MeetingState.Playing ) || (this._state == MeetingSettings.MeetingState.ScanForward))
{
EnableLMTimer( this._timer, false );
this._UpdateTime();
}
}
GlobalTimerPlayer.prototype.Pause = function( )
{
this._InnerPause();
this._state = MeetingSettings.MeetingState.Paused;
}
GlobalTimerPlayer.prototype._InnerPlay = function( )
{
this._meetingOffsetByRefTime = this._currentPos;
this._refTime = new Date();
this._UpdateTime();
EnableLMTimer( this._timer, true );
}
GlobalTimerPlayer.prototype.Play = function( )
{
this._InnerPlay();
this._state = MeetingSettings.MeetingState.Playing;
}
GlobalTimerPlayer.prototype.Stop = function( )
{
this._state = MeetingSettings.MeetingState.Stopped;
this.SetPosition( 0 );
EnableLMTimer( this._timer, false );
}
GlobalTimerPlayer.prototype.GetState = function( )
{
return this._state;
}
GlobalTimerPlayer.prototype.SetRate = function( rate )
{
this._rate = rate;
}
GlobalTimerPlayer.prototype.GetRate = function( )
{
return this._rate;
}
GlobalTimerPlayer.prototype.Enable = function( isEnable )
{
if ( isEnable && this._state == MeetingSettings.MeetingState.Playing )
{
this._InnerPlay();
}
else
{
this._InnerPause();
}
}
Trace.Wrap("GlobalTimerPlayer");
function SequencePlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this.SeekCompletedEvent = new Event();
this._isEnabled = true;
this._sequenceState = new MeetingSettings.MeetingStateClass(
MeetingSettings.MeetingState.Undefined,
1.0,
1.0,
false,
0,
false
);
this._initialized = false;
this._activePlayer = null;
this._currentPgCEvent = null;
this._pane = null;
this._PulsedEvent = new Event();
this._SeekedEvent = new Event();
this._SyncEvent = new Event();
this._SyncStateEvent = new Event();
this._initializedEvent = new Event();
this._uninitializedEvent = new Event();
this.IsBuffering = false;
}
SequencePlayer.prototype.Initialize = function()
{
this._initializedEvent();
this._initialized = true;
}
SequencePlayer.prototype.Uninitialize = function()
{
this._uninitializedEvent();
this._initialized = false;
}
SequencePlayer.prototype._InternalGetAbsolutePosition = null;
SequencePlayer.prototype._InternalSetPosition = null;
SequencePlayer.prototype.SetPosition = function ( pos )
{
this._InternalSetPosition( pos );
}
SequencePlayer.prototype.GetAbsolutePosition = function()
{
var pos = this._InternalGetAbsolutePosition();
return pos;
}
SequencePlayer.prototype.GetPlayer = function()
{
return this._activePlayer;
}
SequencePlayer.prototype.SetActivePlayer = function( player )
{
this._activePlayer = player;
}
SequencePlayer.prototype.AssignPane = function( pane )
{
this._pane = pane;
}
SequencePlayer.prototype.Pulse = function( pos )
{
this._sequenceState.MeetingPos = pos;
this._PulsedEvent( pos );
}
SequencePlayer.prototype.Seek = function( pos )
{
this._SeekedEvent( pos );
}
SequencePlayer.prototype.Sync = function( meetingState )
{
this._SyncEvent( meetingState );
}
SequencePlayer.prototype.SyncState = function( meetingState )
{
this._SyncStateEvent( meetingState );
}
SequencePlayer.prototype.Enable = function( isEnable )
{
this._isEnabled = isEnable;
if ( this._activePlayer && this._activePlayer.Enable )
{
this._activePlayer.Enable( isEnable );
}
}
SequencePlayer.prototype.IsEnabled = function()
{
return this._isEnabled;
}
SequencePlayer.prototype.WaitingNeeded = function()
{
return false;
}
SequencePlayer.prototype.HasData = function()
{
return true;
}
Trace.Wrap( "SequencePlayer" );
function NotesSequencePlayer( )
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( NotesSequencePlayer, SequencePlayer );
NotesSequencePlayer.prototype.SetNotesPlayer = function( player )
{
this._activePlayer = player;
}
Trace.Wrap( "NotesSequencePlayer" );
function CtrlableSequencePlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._BeforeStateChangedEvent = new Event();
this._BeforeStateChangedEvent.Add( Delegate( this, CtrlableSequencePlayer.prototype._BeforeStateChangedHandler ) );
this.Closed = false;
this._waiting = false;
}
OOP.Inherit( CtrlableSequencePlayer, SequencePlayer );
CtrlableSequencePlayer.prototype.Close = function()
{
this.Closed = true;
}
CtrlableSequencePlayer.prototype.Open = function()
{
this.Closed = false;
}
CtrlableSequencePlayer.prototype.Play = function()
{
this._BeforeStateChangedEvent( this._sequenceState.State, MeetingSettings.MeetingState.Playing );
if ( this._activePlayer )
{
this._activePlayer.Play();
}
}
CtrlableSequencePlayer.prototype.PrePlay = function()
{
}
CtrlableSequencePlayer.prototype.WaitResume = function()
{
this._waiting = true;
if ( this._activePlayer )
{
this._activePlayer.WaitResume();
}
}
CtrlableSequencePlayer.prototype.ApplyResume = function()
{
if ( this._activePlayer )
{
this._activePlayer.ApplyResume();
}
this._waiting = false;
}
CtrlableSequencePlayer.prototype.Stop = function()
{
this._BeforeStateChangedEvent( this._sequenceState.State, MeetingSettings.MeetingState.Stopped );
}
CtrlableSequencePlayer.prototype.Pause = function()
{
this._BeforeStateChangedEvent( this._sequenceState.State, MeetingSettings.MeetingState.Paused );
if ( this._activePlayer )
{
this._activePlayer.Pause();
}
}
CtrlableSequencePlayer.prototype.SetRate = function( rate )
{
this._sequenceState.Speed = rate;
if ( this._activePlayer )
{
this._activePlayer.SetRate( rate );
}
}
CtrlableSequencePlayer.prototype.GetRate = function()
{
var rate = 1;
if ( this._activePlayer )
{
rate = this._activePlayer.GetRate();
}
return rate;
}
CtrlableSequencePlayer.prototype._BeforeStateChangedHandler = function( oldState, newState )
{
this._sequenceState.State = newState;
}
function PagedSequencePlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._players = new Object();
this._autoSwitchNew = true;
this._pageChangeEvents = [];
this._iCurPgCEvt = null;
this.BufferingEvent = new Event();
this.ReadyEvent = new Event();
this.BeforeEnterNewPage = new Event();
this._PulsedEvent.Add(
Delegate( this, PagedSequencePlayer.prototype._PulsedHandler )
);
this._SyncEvent.Add(
Delegate( this, PagedSequencePlayer.prototype._SyncHandler )
);
this._SyncStateEvent.Add(
Delegate( this, PagedSequencePlayer.prototype._SyncStateHandler )
);
this._SeekedEvent.Add(
Delegate( this, PagedSequencePlayer.prototype._SeekedHandler )
);
this._uninitializedEvent.Add(
Delegate( this, PagedSequencePlayer.prototype._UninitializedHandler )
);
}
OOP.Inherit( PagedSequencePlayer, CtrlableSequencePlayer );
PagedSequencePlayer.BufferThreshold = 60000;
PagedSequencePlayer.prototype._UninitializedHandler = function( )
{
if ( this._setActiveRendererTimerId )
{
clearTimeout( this._setActiveRendererTimerId );
this._setActiveRendererTimerId = 0;
}
if ( this._bufferTimeoutHandler )
{
clearTimeout( this._bufferTimeoutHandler );
this._bufferTimeoutHandler = 0;
}
}
PagedSequencePlayer.prototype._PulsedHandler = function( pos )
{
if ( !this._initialized )
{
return;
}
this._ProcessNewTime( pos, false );
if ( this._activePlayer )
{
this._activePlayer.Pulse( pos  );
}
}
PagedSequencePlayer.prototype._SeekedHandler = function( pos )
{
if ( !this._initialized )
{
return;
}
this._ProcessNewTime( pos, true );
if ( this._activePlayer )
{
this._activePlayer.Seek( pos );
}
else
{
this.ReadyEvent();
this.SeekCompletedEvent();
}
}
PagedSequencePlayer.prototype.SetPageChangeEvents = function( pageChangeEvents )
{
this._pageChangeEvents = pageChangeEvents;
}
PagedSequencePlayer.prototype.AddPlayer = function( pageType, player )
{
this._players[ pageType ] = player;
player.BufferingEvent.Add(
DelegateWithArgs( this, PagedSequencePlayer.prototype._BufferingHandler )
);
player.ReadyEvent.Add(
DelegateWithArgs( this, PagedSequencePlayer.prototype._ResourceReadyHandler )
);
player.SeekCompletedEvent.Add(
DelegateWithArgs( this, PagedSequencePlayer.prototype._SeekCompletedHandler )
);
}
PagedSequencePlayer.prototype._InternalGetAbsolutePosition = function()
{
if ( !this._initialized )
{
return 0;
}
var pos = 0;
if ( this._activePlayer )
{
pos = this._activePlayer.GetRelativePosition( )
+ parseFloat( this._pageChangeEvents[ this._iCurPgCEvt ].time );
}
else
{
pos = 0;
}
return pos;
}
PagedSequencePlayer.prototype._InternalSetPosition = function ( pos )
{
if ( !this._initialized )
{
return;
}
this.Pulse( pos );
}
PagedSequencePlayer.prototype._SwitchToNull = function()
{
if ( this._iCurPgCEvt != null )
{
if ( this._activePlayer )
{
this._activePlayer.ExitPage( true );
}
}
this._iCurPgCEvt = null;
this._activePlayer = null;
}
PagedSequencePlayer.prototype._SwitchPages = function( index, pos, isSeek )
{
var oldType = null;
if ( this._iCurPgCEvt != null )
{
oldType = this._pageChangeEvents[ this._iCurPgCEvt ].pageType;
}
var curPgCEvt = this._pageChangeEvents[ index ];
var pageTypeChanged = (oldType != curPgCEvt.Page.pageType);
this._ExitOldPage( pageTypeChanged );
this.BeforeEnterNewPage( pos, isSeek );
this._iCurPgCEvt = index;
if ( this._autoSwitchNew || isSeek )
{
this._EnterNewPage( curPgCEvt, pos, isSeek );
}
}
PagedSequencePlayer.prototype._ExitOldPage = function( pageTypeChanged )
{
if ( this._activePlayer )
{
this._activePlayer.ExitPage( pageTypeChanged );
}
}
PagedSequencePlayer.prototype._EnterNewPage = function( newPgCEvt, pos, isSeek )
{
if (( newPgCEvt.Page.pageType != null )
&&( !newPgCEvt.Page._notExist )
&&( newPgCEvt.Page.pageType in this._players ))
{
this._activePlayer = this._players[ newPgCEvt.Page.pageType ];
this._activePlayer.EnterPage(
newPgCEvt.Page,
newPgCEvt.time,
((isSeek == true)?(pos - newPgCEvt.time):0),
this._sequenceState.State,
this._isEnabled
);
}
else
{
this._activePlayer = null;
this.ReadyEvent();
}
}
PagedSequencePlayer.prototype._BufferingHandler = function( )
{
this.BufferingEvent();
this._bufferTimeoutHandler =
setTimeout(
Delegate( this, PagedSequencePlayer.prototype._ProcBufferTimedOut ),
PagedSequencePlayer.BufferThreshold
);
}
PagedSequencePlayer.prototype._ProcBufferTimedOut = function()
{
this.ReadyEvent( true );
}
PagedSequencePlayer.prototype._ResourceReadyHandler = function( )
{
if ( this._bufferTimeoutHandler )
{
clearTimeout( this._bufferTimeoutHandler );
this._bufferTimeoutHandler = null;
}
this._PrebufferNextPage( );
this.ReadyEvent();
}
PagedSequencePlayer.prototype._PrebufferNextPage = function( )
{
if (( this._iCurPgCEvt == null ) && ( this._pageChangeEvents.length > 0))
{
this._PrebufferPage( this._pageChangeEvents[0].Page, 0 );
}
if ( this._iCurPgCEvt < this._pageChangeEvents.length - 1 )
{
this._PrebufferPage( this._pageChangeEvents[this._iCurPgCEvt + 1].Page, 0 );
}
}
PagedSequencePlayer.prototype._PrebufferPage = function ( page, offset )
{
var isInPlayers = false;
for( var pt in this._players )
{
if ( page.pageType == pt )
{
isInPlayers = true;
}
}
if ( !isInPlayers )
{
return;
}
var nextPlayer = this._players[ page.pageType ];
nextPlayer.PrebufferPage( page, offset );
}
PagedSequencePlayer.prototype._ProcessActiveRenderer = function()
{
if ( this._pane )
{
var activeRenderer;
if ( this._activePlayer )
{
activeRenderer = this._activePlayer.GetRenderer();
}
else
{
activeRenderer = null;
}
if ( this._setActiveRendererTimerId )
{
clearTimeout( this._setActiveRendererTimerId );
this._setActiveRendererTimerId = 0;
}
this._setActiveRendererTimerId = setTimeout(
DelegateWithArgs(
this._pane,
this._pane.SetActiveRenderer,
activeRenderer,
this._IsShownAnnotation()
),
10
);
}
}
PagedSequencePlayer.prototype._PageChanged = function( index, pos, isSeek )
{
if ( !this._initialized )
{
return;
}
if ( index == null )
{
this._SwitchToNull();
}
else
{
this._SwitchPages( index, pos, isSeek );
}
this._ProcessActiveRenderer();
}
PagedSequencePlayer.prototype._ProcessNewPgCIndex = function ( index, pos, isSeek )
{
if ( this._iCurPgCEvt == null )
{
if ( index != null )
{
this._PageChanged( index, pos, isSeek );
}
}
else if ( index == null )
{
this._PageChanged( index, pos, isSeek );
}
else
{
if ( this._iCurPgCEvt != index )
{
this._PageChanged( index, pos, isSeek );
}
}
}
PagedSequencePlayer.prototype._ProcessNewTime = function ( pos, isSeek )
{
if ( this._pageChangeEvents )
{
var iNewIndex = SearchItemWithTimeEx( pos, this._pageChangeEvents, "time" );
this._ProcessNewPgCIndex( iNewIndex, pos, isSeek );
}
}
PagedSequencePlayer.prototype._SyncHandler = function( meetingState )
{
if ( this._activePlayer )
{
if ( this._activePlayer.Sync )
{
this._activePlayer.Sync( meetingState );
}
}
}
PagedSequencePlayer.prototype._SyncStateHandler = function( meetingState )
{
if ( this._activePlayer )
{
if ( this._activePlayer.SyncState )
{
this._activePlayer.SyncState( meetingState );
}
}
}
PagedSequencePlayer.prototype.Stop = function()
{
CtrlableSequencePlayer.prototype.Stop.call( this );
this._ExitOldPage( false );
}
PagedSequencePlayer.prototype.WaitingNeeded = function()
{
if ( !this._pageChangeEvents || this._pageChangeEvents.length == 0 )
{
return false;
}
if ( this._pageChangeEvents[0].time != 0 )
{
return false;
}
var pageType = this._pageChangeEvents[0].Page.pageType;
if ( pageType == MeetingSettings.PageType.Audio
|| pageType == MeetingSettings.PageType.PanoVideo
|| pageType == MeetingSettings.PageType.QCIFVideo
|| pageType == MeetingSettings.PageType.MMC
)
{
return true;
}
return false;
}
PagedSequencePlayer.prototype.HasData = function()
{
if (!this._pageChangeEvents || this._pageChangeEvents.length == 0 )
{
return false;
}
else
{
return true;
}
}
PagedSequencePlayer.prototype._IsShownAnnotation = function()
{
if ( !this._activePlayer )
{
return false;
}
if ( !this._activePlayer._annoPlayer )
{
return false;
}
if ( !this._activePlayer._annoPlayer._renderer.IsAvailable() )
{
return false;
}
return true;
}
PagedSequencePlayer.prototype._SeekCompletedHandler = function()
{
this.SeekCompletedEvent();
}
PagedSequencePlayer.prototype.Play = function()
{
CtrlableSequencePlayer.prototype.Play.call( this );
if ( !this._activePlayer )
{
this.ReadyEvent();
}
}
PagedSequencePlayer.prototype.SetAutoSwitch = function( autoswitch )
{
this._autoSwitchNew = autoswitch;
}
PagedSequencePlayer.prototype.GetAutoSwitch = function(  )
{
return this._autoSwitchNew;
}
Trace.Wrap("PagedSequencePlayer");
function MediaSequencePlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( MediaSequencePlayer, PagedSequencePlayer );
MediaSequencePlayer.prototype.GetVolume = function()
{
var ret = 1;
if ( this._activePlayer && this._activePlayer.GetVolume )
{
ret = this._activePlayer.GetVolume();
}
return ret;
}
MediaSequencePlayer.prototype.SetVolume = function( vol )
{
if( this._activePlayer && this._activePlayer.SetVolume )
{
this._activePlayer.SetVolume( vol );
}
}
MediaSequencePlayer.prototype.Mute = function( ismuted )
{
if( this._activePlayer && this._activePlayer.Mute )
{
this._activePlayer.Mute( ismuted );
}
}
MediaSequencePlayer.prototype.PrePlay = function()
{
this.Enable( false );
this.Mute( true );
this.Play();
this.Pulse( 0 );
}
function MeetingClock()
{
OOP.CallParentConstructor( this, arguments.callee );
this._fNeedHitTime = false;
this._timeNeedHit = 0;
this._activePlayer = new GlobalTimerPlayer();
this._activePlayer.onTimerEvent.Add( Delegate( this, MeetingClock.prototype.onTimerHandler ) );
this._duration = 0;
this._BeforeStateChangedEvent.Add( Delegate( this, MeetingClock.prototype._BeforeStateChangedHandler ) );
this.MeetingFinishedEvent = new Event();
this.TimerClockEvent = new Event();
this._stateChanged = false;
this._lastPos = 0;
}
OOP.Inherit( MeetingClock, CtrlableSequencePlayer );
MeetingClock.prototype.SetMeetingDuration = function( dur )
{
this._duration = dur;
}
MeetingClock.prototype.onTimerHandler = function( pos )
{
if ( this._fNeedHitTime )
{
pos = this._timeNeedHit;
this._fNeedHitTime = false;
this._InternalSetPosition( pos );
}
else
{
pos = this._RefinePosition( pos );
}
this.TimerClockEvent( pos );
if ( pos >= this._duration)
{
this._fNeedHitTime = false;
pos = 0;
this.MeetingFinishedEvent();
}
this._lastPos = pos;
this._stateChanged = false;
}
MeetingClock.prototype.SetDuration = function( dur )
{
this._duration = dur;
}
MeetingClock.prototype._InternalGetAbsolutePosition = function()
{
return this._lastPos;
}
MeetingClock.prototype._InternalSetPosition = function( pos )
{
return this._activePlayer.SetPosition( pos );
}
MeetingClock.prototype.Pulse = function( pos )
{
this._InternalSetPosition( pos );
}
MeetingClock.prototype.Seek = function( pos )
{
this.SetPosition( pos );
this._MakeSureClockHit( pos );
this._lastPos = pos;
}
MeetingClock.prototype.Play = function()
{
CtrlableSequencePlayer.prototype.Play.call( this );
}
MeetingClock.prototype.Stop = function()
{
CtrlableSequencePlayer.prototype.Stop.call( this );
this._activePlayer.Stop();
this._lastPos = 0;
}
MeetingClock.prototype._BeforeStateChangedHandler = function( oldState, newState )
{
if ( newState == MeetingSettings.MeetingState.Playing )
{
this._MakeSureClockHit( this.GetAbsolutePosition() );
}
this._stateChanged = true;
}
MeetingClock.prototype._MakeSureClockHit = function( time )
{
this._fNeedHitTime = true;
this._timeNeedHit = time;
}
MeetingClock.prototype._RefinePosition = function( pos )
{
var newPos = pos;
if ( NavigatorInfo.IsFirefox() )
{
if ( (this._sequenceState.State == MeetingSettings.MeetingState.Playing) &&
(this._stateChanged == false) &&
(pos - this._lastPos > 0.5) )
{
newPos = this._lastPos + 0.5;
this._InternalSetPosition( newPos );
}
}
return newPos;
}
MeetingClock.prototype.WaitResume = function()
{
if ( this._sequenceState.State == MeetingSettings.MeetingState.Playing )
{
this._activePlayer.Pause();
}
}
MeetingClock.prototype.ApplyResume = function()
{
if ( this._sequenceState.State == MeetingSettings.MeetingState.Playing )
{
this._activePlayer.Play();
}
}
function DataSequencePlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
}
OOP.Inherit( DataSequencePlayer, MediaSequencePlayer );
function IndexBaseSequencePlayer( )
{
OOP.CallParentConstructor( this, arguments.callee );
this._PulsedEvent.Add(
Delegate( this, IndexBaseSequencePlayer.prototype._PulseHandler )
);
this._SeekedEvent.Add(
Delegate( this, IndexBaseSequencePlayer.prototype._SeekHandler )
);
}
OOP.Inherit( IndexBaseSequencePlayer, SequencePlayer );
IndexBaseSequencePlayer.prototype.SetIndexData = function( indexData )
{
if ( this._activePlayer )
{
this._activePlayer.SetIndexData( indexData );
}
}
IndexBaseSequencePlayer.prototype.AddIndexChangedEventHandler = function ( handler )
{
if ( this._activePlayer )
{
this._activePlayer.IndexChanged.Add( handler );
}
}
IndexBaseSequencePlayer.prototype.GetIndexPos = function( idx )
{
if ( !this._activePlayer )
{
return 0;
}
return this._activePlayer.GetIndexPos( idx );
}
IndexBaseSequencePlayer.prototype._PulseHandler = function( pos )
{
this._activePlayer.Pulse( pos );
}
IndexBaseSequencePlayer.prototype._SeekHandler = function( pos )
{
this._activePlayer.Pulse( pos );
}
Trace.Wrap( "IndexBaseSequencePlayer" );
function IndexSequencePlayer( )
{
OOP.CallParentConstructor( this, arguments.callee );
this._activePlayer = new IndexPlayer();
}
OOP.Inherit( IndexSequencePlayer, IndexBaseSequencePlayer );
IndexSequencePlayer.prototype.GetPosOfPrev = function( pos )
{
return this._activePlayer.GetPosOfPrev( pos );
}
IndexSequencePlayer.prototype.GetPosOfNext = function( pos )
{
return this._activePlayer.GetPosOfNext( pos );
}
Trace.Wrap( "IndexSequencePlayer" );
function QASequencePlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._activePlayer = new QAPlayer();
}
OOP.Inherit( QASequencePlayer, IndexBaseSequencePlayer );
Trace.Wrap( "QASequencePlayer" );
function HTMLPlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._loadedflag = false;
this._resPagePlayerFlag = true;
this._pageEnterEvent.Add(
Delegate( this, HTMLPlayer.prototype.PageEnterHandler )
);
this._rendererAssignedEvent.Add(
DelegateWithArgs( this, HTMLPlayer.prototype._RendererAssignedHandler )
);
this._seekedEvent.Add( Delegate( this, HTMLPlayer.prototype._SeekHandler ) );
}
OOP.Inherit( HTMLPlayer, WithAnnoPlayer );
HTMLPlayer.prototype.PageEnterHandler = function ( page, time, startTime )
{
this._page = page;
this._loadedflag = false;
if ( this._renderer )
{
if ( page.width > 0 && page.height > 0 )
{
this._renderer.SetOriginalSize( page.width, page.height );
}
else
{
this._renderer.ApplyDefaultOriginalSize();
}
if ( page._notExist )
{
this._renderer.SetURI( null, time ) ;
g_ErrorHandling.ShowWarning( E_PAGENOTEXIST );
}
else
{
this._renderer.SetURI( page.url, time );
}
}
}
HTMLPlayer.prototype._RendererAssignedHandler = function( renderer )
{
this._renderer._AfterLoadedEvent.Add( Delegate( this, HTMLPlayer.prototype._LoadedHandler ) );
}
HTMLPlayer.prototype._LoadedHandler = function()
{
this._loadedflag = true;
this.ReadyEvent();
}
HTMLPlayer.prototype._SeekHandler = function()
{
if ( this._loadedflag )
{
this.ReadyEvent();
}
}
Trace.Wrap( "HTMLPlayer" );
function SlidePlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._animDisablePatch = new SlidePlayerAnimDisablePatch( this );
this._lastStep = 0;
this._pageEnterEvent.Add( Delegate( this, SlidePlayer.prototype._PageEnterHandler ) );
this._pageExitEvent.Add( Delegate( this, SlidePlayer.prototype._PageExitHandler ) );
this._uninitializedEvent.Add( Delegate( this, SlidePlayer.prototype._UninitializedHandler ) );
this._playEvent.Add( Delegate( this, SlidePlayer.prototype._PlayHandler ) );
this._pauseEvent.Add( Delegate( this, SlidePlayer.prototype._PauseHandler ) );
this._setRateEvent.Add( Delegate( this, SlidePlayer.prototype._SetRateHandler ) );
this._BeforeProcMsgEvent.Add( Delegate( this, SlidePlayer.prototype._BeforeProcMsgHandler ) );
this._AfterProcMsgEvent.Add( Delegate( this, SlidePlayer.prototype._AfterProcMsgHandler ) );
this._seekedEvent.Add( Delegate( this, SlidePlayer.prototype._SeekHandler ) );
}
OOP.Inherit( SlidePlayer, HTMLPlayer );
SlidePlayer.Threshold = 2.0;
SlidePlayer.FinalStep = -100;
SlidePlayer.prototype.GetRelativePosition = function()
{
var curPos = 0;
if ( this._renderer )
{
curPos = this._renderer.GetRelativePosition();
}
return curPos;
}
SlidePlayer.prototype.GetRate = function()
{
var res = 1.0;
if ( this._renderer )
{
res = this._renderer.GetRate();
}
return res;
}
SlidePlayer.prototype._PageEnterHandler = function( page, time, startTime )
{
this._innerMessages = page.AnimationChanged;
this._lastStep = 0;
if ( this._renderer )
{
this._renderer.Initialize();
this._Start();
this._renderer.SetPosition( startTime, this._playerState.State, false );
}
this._animDisablePatch.EnterPage( page );
}
SlidePlayer.prototype._PageExitHandler = function( fToBlank )
{
this._innerMessages = null;
if ( this._renderer )
{
this._renderer.Uninitialize();
}
}
SlidePlayer.prototype._PlayHandler = function()
{
if ( this._renderer )
{
this._renderer.Play();
}
}
SlidePlayer.prototype._PauseHandler = function()
{
if ( this._renderer )
{
this._renderer.Pause();
}
}
SlidePlayer.prototype._SetRateHandler = function( rate )
{
if ( this._renderer )
{
this._renderer.SetRate( rate );
}
}
SlidePlayer.prototype._UninitializedHandler = function()
{
if ( this._renderer )
{
this._renderer.Uninitialize();
}
}
SlidePlayer.prototype._Start = function()
{
if ( this._renderer )
{
this._renderer.Start();
if ( this._playerState.State != MeetingSettings.MeetingState.Playing )
{
this._renderer.Pause();
}
}
}
SlidePlayer.prototype._GetPosInPage = function( pos )
{
var ret = PagedPlayer.prototype._GetPosInPage.call( this, pos );
if ( ret < 0 )
{
ret = 0;
}
return ret;
}
SlidePlayer.prototype.Update = function( msg )
{
if (!NavigatorInfo.AnimationEnabled())
{
return;
}
if ( this._renderer )
{
this.FinalStep = msg.currentStep;
}
}
SlidePlayer.prototype._BeforeProcMsgHandler = function( curPos, tarIndex, isSeek )
{
var msgOffset = 0;
if ( tarIndex != null )
{
msgOffset = this._GetPosInPage( this._innerMessages[ tarIndex ].time );
}
if ( msgOffset == 0  && !this._lastStep > 0)
{
this._Start();
}
else
{
this._renderer.SetPosition(
msgOffset,
this._playerState.State,
true
);
}
}
SlidePlayer.prototype._AfterProcMsgHandler = function( curPos, tarIndex, isSeek )
{
var newStep = this.FinalStep;
if ( newStep >= this._lastStep )
{
for( var i = this._lastStep + 1; i <= newStep; i++ )
{
this._renderer.StepAnimation( this._playerState.State );
}
}
else
{
this.Reset();
for( var i = 1; i <= newStep; i++ )
{
this._renderer.StepAnimation( this._playerState.State );
}
}
this._lastStep = newStep;
var msgOffset = 0;
msgOffset = this._GetPosInPage( curPos );
if ( msgOffset == 0 && !this._lastStep > 0)
{
this._Start();
}
else
{
this._renderer.SetPosition(
msgOffset,
this._playerState.State,
true
);
}
}
SlidePlayer.prototype.Reset = function()
{
if ( this._renderer )
{
this._renderer.Initialize();
}
this._Start();
this._lastStep = 0;
}
SlidePlayer.prototype._SeekHandler = function( )
{
this._animDisablePatch.Seek( );
}
Trace.Wrap("SlidePlayer");
function SlidePlayerAnimDisablePatch( player )
{
this._slidePlayer = player;
}
SlidePlayerAnimDisablePatch.prototype._Exec = function()
{
if ( !NavigatorInfo.IsIE() )
{
return;
}
if ( !NavigatorInfo.AnimationEnabled() )
{
setTimeout(
Delegate( this._slidePlayer,
this._slidePlayer._LoadedHandler ),
0 );
}
}
SlidePlayerAnimDisablePatch.prototype.EnterPage = function( page )
{
this._Exec();
}
SlidePlayerAnimDisablePatch.prototype.Seek = function( )
{
this._Exec();
}
function PollPlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._pageEnterEvent.Add( Delegate( this, PollPlayer.prototype._PageEnterHandler ) );
this._pageExitEvent.Add( Delegate( this, PollPlayer.prototype._PageExitHandler ) );
this._BeforeProcMsgEvent.Add( Delegate( this, PollPlayer.prototype._BeforeProcMsgHandler ) );
this._AfterProcMsgEvent.Add( Delegate( this, PollPlayer.prototype._AfterProcMsgHandler ) );
}
OOP.Inherit( PollPlayer, PagedPlayer );
PollPlayer.prototype.GetRelativePosition = function ()
{
return 0;
}
PollPlayer.prototype.Reset = function( )
{
if ( this._renderer )
{
this._renderer.Initialize();
}
}
PollPlayer.prototype._PageEnterHandler = function( page, time, startTime )
{
this._innerMessages = page.PollingChanged;
this._renderer.Initialize();
}
PollPlayer.prototype._PageExitHandler = function()
{
this._innerMessages = null;
this._renderer.Uninitialize();
}
PollPlayer.prototype.GetRate = function ()
{
return 1.0;
}
PollPlayer.prototype._CheckValid = function( message )
{
return true;
}
PollPlayer.prototype.Update = function( message )
{
if ( !this._CheckValid( message ) )
{
return;
}
var action = message.action.toLowerCase();
switch (action)
{
case "create":
case "edit":
this._nameUpdated = true;
this._choicesUpdated = true;
this._name = message.Question;
this._choices = [];
if ( message.Choice )
{
for (var i = 0; i < message.Choice.length; i++)
{
this._choices[i] = new Object();
this._choices[i].name = message.Choice[i].value;
this._choices[i].color = message.Choice[i].color;
}
}
break;
case "update":
this._itemsUpdated = true;
this._items = [];
var total = 0;
if ( message.Choice )
{
for (var i = 0; i < message.Choice.length; i++)
{
this._items[i] = new Object();
this._items[i].number = parseInt( message.Choice[i].chooseCnt, 10 );
total += this._items[i].number;
}
}
if (total < 1)
{
for (var i = 0; i < this._items.length; i++)
{
this._items[i].percent = 0;
}
}
else
{
for (var i = 0; i < this._items.length; i++)
{
this._items[i].percent = 100.0 * this._items[i].number / total;
}
}
break;
case "enable":
this._enabledisableChanged = true;
this._enabled = true;
break;
case "disable":
this._enabledisableChanged = true;
this._enabled = false;
break;
case "showresult":
this._showhideChanged = true;
this._shown = true;
break;
case "hideresult":
this._showhideChanged = true;
this._shown = false;
break;
default:
break;
}
}
PollPlayer.prototype._BeforeProcMsgHandler = function()
{
this._nameUpdated = false;
this._choicesUpdated = false;
this._itemsUpdated = false;
this._enabledisableChanged = false;
this._enabled = true;
this._showhideChanged = false;
this._shown = true;
this._name = "";
this._choices = [];
this._items = [];
}
PollPlayer.prototype._AfterProcMsgHandler = function()
{
if ( this._nameUpdated )
{
this._renderer.SetName( this._name );
}
if ( this._choicesUpdated )
{
this._renderer.SetChoices( this._choices );
}
if ( this._itemsUpdated )
{
this._renderer.UpdateCount( this._items );
}
if ( this._enabledisableChanged )
{
if ( this._enabled )
{
this._renderer.Enable();
}
else
{
this._renderer.Disable();
}
}
if ( this._showhideChanged )
{
if ( this._shown )
{
this._renderer.ShowResult();
}
else
{
this._renderer.HideResult();
}
}
}
Trace.Wrap( "PollPlayer" );
function TextPlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._text = "";
this._modified = false;
this._pageEnterEvent.Add( Delegate( this, TextPlayer.prototype._PageEnterHandler ) );
this._pageExitEvent.Add( Delegate( this, TextPlayer.prototype._PageExitHandler ) );
this._BeforeProcMsgEvent.Add( Delegate( this, TextPlayer.prototype._BeforeProcMsgHandler ) );
this._AfterProcMsgEvent.Add( Delegate( this, TextPlayer.prototype._AfterProcMsgHandler ) );
}
OOP.Inherit( TextPlayer, PagedPlayer );
TextPlayer.MaxLength = 30000;
TextPlayer.prototype.Reset = function ()
{
this._text = "";
if ( this._renderer )
{
this._renderer.Initialize();
}
}
TextPlayer.prototype.GetRelativePosition = function ()
{
return 0;
}
TextPlayer.prototype.SetPosition = function ( pos )
{
}
TextPlayer.prototype._PageEnterHandler = function( page, time, startTime )
{
this._innerMessages = this._page.TextChanged;
this.Reset();
}
TextPlayer.prototype._PageExitHandler = function( fDif )
{
this._innerMessages = null;
this._text = "";
this._renderer.Uninitialize();
}
TextPlayer.prototype.GetRate = function ()
{
return 1.0;
}
TextPlayer.prototype._CheckValid = function( message )
{
var retval = true;
var beginIndex = message.beginIndex;
var endIndex = message.endIndex;
switch( message.action )
{
case "insert":
if ( isNaN(beginIndex) || (beginIndex < 0) )
{
retval = false;
}
if ( message.text == "" )
{
retval = false;
}
break;
case "remove":
if ( isNaN(beginIndex) || (beginIndex < 0) )
{
retval = false;
}
else
if ( isNaN( endIndex ) || ( endIndex < 0 ) || ( beginIndex >= endIndex ) )
{
retval = false;
}
break;
case "snapshot":
retval = (typeof message.text == "string");
break;
default:
retval = false;
}
return retval;
}
TextPlayer.prototype._CheckInsert = function( msg )
{
if ( msg.action != "insert" )
{
return true;
}
if ( msg.beginIndex >= TextPlayer.MaxLength )
{
return false;
}
var totalsize = 0;
if ( this._text.length > msg.beginIndex )
{
totalsize = this._text.length + msg.text.length;
}
else
{
totalsize = msg.beginIndex + msg.text.length;
}
if ( totalsize > TextPlayer.MaxLength )
{
msg.text = msg.text.substr(0, msg.text.length - totalsize + TextPlayer.MaxLength );
}
return true;
}
TextPlayer.prototype.Update = function( message )
{
var _startUpdate = new Date();
if ( !this._CheckValid( message ) )
{
g_ErrorHandling.ShowWarning( E_BADTEXTMESSAGE );
return;
}
if (!this._CheckInsert( message ))
{
g_ErrorHandling.ShowWarning( E_TEXTFULL );
return;
}
var _afterCheck = new Date();
var action = message.action;
var begin = message.beginIndex;
switch (action)
{
case "insert":
var msg = message.text;
if (this._text.length < begin)
{
for( var i = this._text.length; i < begin; i++ )
{
this._text += ' ';
}
}
this._text = this._text.substring(0, begin) +  msg + this._text.substring(begin);
break;
case "remove":
var end = message.endIndex;
if (this._text.length < end)
{
this._text = this._text.substring(0, begin);
}
else
{
this._text = this._text.substring(0, begin) +  this._text.substring(end);
}
break;
case "snapshot":
this._text = message.text;
break;
default:
return;
}
this._modified = true;
var _endAll = new Date();
this._checkTime += _afterCheck - _startUpdate;
this._calcTime += _endAll - _afterCheck;
}
TextPlayer.prototype._BeforeProcMsgHandler = function()
{
this._modified = false;
this._startTime = new Date();
this._checkTime = 0;
this._calcTime = 0;
}
TextPlayer.prototype._AfterProcMsgHandler = function()
{
if ( this._modified )
{
this._renderer.SetText( this._text, true );
}
this._totalTime = new Date() - this._startTime;
}
Trace.Wrap( "TextPlayer" );
function WhiteBoardPlayer()
{
OOP.CallParentConstructor( this, arguments.callee );
this._lastStep = 0;
this._pageEnterEvent.Add( Delegate( this, WhiteBoardPlayer.prototype._PageEnterHandler ) );
}
OOP.Inherit( WhiteBoardPlayer, WithAnnoPlayer );
WhiteBoardPlayer.prototype._PageEnterHandler = function( page, time, startTime )
{
if( page.width > 0 && page.height > 0 )
{
this._renderer.SetOriginalSize( page.width, page.height );
}
else
{
this._renderer.ApplyDefaultOriginalSize();
}
}
function SearchItemBase( value, list, attrName, checkDisable )
{
if ( !list )
{
return null;
}
if ( list.length == 0 )
{
return null;
}
var last = list[list.length - 1];
if ( checkDisable )
{
if (( value >= last[attrName] ) && (!last._disabled))
{
return list.length - 1;
}
}
else
{
if ( value >= last[attrName] )
{
return list.length - 1;
}
}
var first = list[0];
if ( value < first[attrName] )
{
return null;
}
var left = 0;
var right = list.length - 2;
var mid = null;
while (left <= right)
{
mid = Math.floor((left + right) / 2);
var midValue = list[mid][attrName];
var midPlusValue = list[mid + 1][attrName];
if (( value >=  midValue) && ( value < midPlusValue ) )
{
break;
}
else if ( value >= midPlusValue )
{
left = mid + 1;
}
else
{
right = mid - 1;
}
}
var i;
var retval = null;
if ( checkDisable )
{
for( i = mid; i >= 0; i--)
{
if ( ! list[i]._disabled )
{
retval = i;
break;
}
}
}
else
{
retval = mid;
}
return retval;
}
function SearchItemWithTimeEx( value, list, attrName )
{
if ( attrName == undefined )
{
attrName = "time";
}
return SearchItemBase( value, list, attrName, true );
}
function SearchItemWithTime( value, list, attrName )
{
if ( attrName == undefined )
{
attrName = "time";
}
return SearchItemBase( value, list, attrName, false );
}
function BufferingManager()
{
OOP.CallParentConstructor( this, arguments.callee );
this._pageDownloader = new PageDownloader();
this.BandwidthIsLowEvent = new Event();
this._pageDownloader.BandwidthIsLowEvent.Add( this.BandwidthIsLowEvent );
this.PredownloadFinishedEvent = new Event();
this.BufferReadyEvent = new Event();
this._pageDownloader.BufferReadyEvent.Add( this.BufferReadyEvent );
}
BufferingManager.QUICKBUFFERINTERVAL = 0;
BufferingManager.prototype.SetPageChangeEvents = function( pagechangelist )
{
for( var i = 0; i < pagechangelist.Content.length; i++ )
{
this._pageDownloader.PushPage( pagechangelist.Content[i] );
}
}
BufferingManager.prototype.Seek = function( time )
{
this._pageDownloader.Seek( time );
}
BufferingManager.prototype.IsPageBufferingReady = function( time, pageId )
{
return this._pageDownloader.IsPageBufferingReady( time, pageId );
}
BufferingManager.prototype.GetPageSize = function( pageId )
{
return this._pageDownloader.GetPageSize( pageId );
}
BufferingManager.prototype.LoadPages = function()
{
setTimeout(
this.PredownloadFinishedEvent,
MeetingSettings.DownloadTimeMin
);
this._pageDownloader.Start();
}
BufferingManager.prototype.SwithToPlayingState = function()
{
this._pageDownloader.ItemDownloader.SetQuickJobInterval(
BufferingManager.QUICKBUFFERINTERVAL
);
}
Trace.Wrap( "BufferingManager" );
function FilterEngine()
{
OOP.CallParentConstructor( this, arguments.callee );
this._filterItems = [];
this.AllGroupEnabled = new Event();
}
FilterEngine.prototype.SetFilterItems = function( items )
{
MoveTheFirstLittle( items );
for( var i = 0; i < items.length; i++ )
{
var obj = new Object();
obj.time = items[i].time;
obj.group = items[i].group;
this._filterItems.push( obj );
}
}
FilterEngine.prototype.EnableGroup = function( group, isEnable )
{
var bAllGroupEnabled = true;
var bAllGroupDisabled = true;
for( var i = 0; i < this._filterItems.length; i++ )
{
if ( this._filterItems[i].group == group )
{
this._filterItems[i]._disabled = !isEnable;
}
if( this._filterItems[i].group == null )
{
continue;
}
if ( this._filterItems[i]._disabled )
{
bAllGroupEnabled = false;
}
else
{
bAllGroupDisabled = false;
}
}
var applyAll = ( bAllGroupEnabled || bAllGroupDisabled );
this.AllGroupEnabled( bAllGroupEnabled, applyAll );
}
FilterEngine.prototype.EnableAllGroup = function( enable )
{
for( var i = 0; i < this._filterItems.length; i++ )
{
this._filterItems[i]._disabled = !enable;
}
this.AllGroupEnabled( enable, true );
}
FilterEngine.prototype.CheckPosition = function( pos )
{
var idx = SearchItemWithTime( pos, this._filterItems );
if ( idx == null )
{
return true;
}
if ( this._filterItems[idx]._disabled )
{
return false;
}
else
{
return true;
}
}
FilterEngine.prototype.FilterPosition = function( pos, forward )
{
var idx = SearchItemWithTime( pos, this._filterItems );
if ( forward )
{
idx = this._ForwardSearch( idx );
}
else
{
idx = this._BackwardSearch( idx );
}
var pos = 0;
if ( idx < 0 )
{
pos = -1;
}
else if ( idx == null )
{
pos = 0;
}
else
{
pos = this._filterItems[idx].time;
}
return pos;
}
FilterEngine.prototype._ForwardSearch = function( idx )
{
var ret = -1;
while( idx < this._filterItems.length )
{
if ( !this._filterItems[idx]._disabled )
{
ret = idx;
break;
}
idx++;
}
return ret;
}
FilterEngine.prototype._BackwardSearch = function( idx )
{
var ret = null;
while ( idx >= 0 )
{
if ( !this._filterItems[idx]._disabled )
{
ret = idx;
break;
}
idx--;
}
return ret;
}
Trace.Wrap( "FilterEngine" );
function BizcardCtrlManager()
{
this._delegate = null;
this._playing = false;
this._action = "show";
}
BizcardCtrlManager.prototype.SetActionEvent = function( delegate )
{
this._delegate = delegate;
}
BizcardCtrlManager.prototype.Play = function()
{
this._playing = true;
this._delegate( this._action );
}
BizcardCtrlManager.prototype.Pause = function()
{
this._playing = false;
this._delegate( "show" );
}
BizcardCtrlManager.prototype.Stop = function()
{
this._playing = false;
this._delegate( "show" );
}
BizcardCtrlManager.prototype.SwitchAction = function( action )
{
this._action = action;
if ( this._playing )
{
this._delegate( action );
}
else
{
this._delegate( "show" );
}
}
function ControllerInitializer( )
{
}
ControllerInitializer.prototype.Execute = function( ctrl )
{
this._InitSequencePlayers( ctrl );
this._InitPlayers( ctrl );
this._InitEventHandlers( ctrl );
this._InitEvents( ctrl );
this._InitIndex( ctrl );
}
ControllerInitializer.prototype._InitSequencePlayers = function( ctrl )
{
ctrl._sequencePlayers.GlobalTimer   = new MeetingClock();
ctrl._sequencePlayers.Audio         = new MediaSequencePlayer();
ctrl._sequencePlayers.QCIF          = new MediaSequencePlayer();
ctrl._sequencePlayers.Pano          = new MediaSequencePlayer();
ctrl._sequencePlayers.Content       = new DataSequencePlayer();
ctrl._sequencePlayers.Notes         = new NotesSequencePlayer();
ctrl._sequencePlayers.QA            = new QASequencePlayer();
ctrl._sequencePlayers.ContentIndex  = new IndexSequencePlayer();
ctrl._sequencePlayers.SpeakerIndex  = new IndexSequencePlayer();
ctrl._sequencePlayers.PVSC          = new IndexSequencePlayer();
ctrl._sequencePlayers.BizChanged    = new IndexSequencePlayer();
for( var st in ctrl._sequencePlayers )
{
ctrl._sequencePlayers[st]._name = st;
ctrl._sequencePlayers[st].Initialize();
}
ctrl._indexers[ MeetingSettings.Index.ContentName ] = ctrl._sequencePlayers.ContentIndex;
ctrl._indexers[ MeetingSettings.Index.SpeakerName ] = ctrl._sequencePlayers.SpeakerIndex;
ctrl._activeIndexSequencePlayer = ctrl._indexers[ MeetingSettings.Index.ContentName ];
ctrl._sequencePlayers.GlobalTimer.TimerClockEvent.Add(
Delegate( ctrl, ctrl.Pulse )
);
ctrl._sequencePlayers.GlobalTimer.MeetingFinishedEvent.Add(
Delegate( ctrl, ctrl.onMeetingFinished )
);
ctrl._sequencePlayers.ContentIndex.AddIndexChangedEventHandler(
Delegate( ctrl, ctrl.ContentIndexChangedHandler )
);
ctrl._sequencePlayers.SpeakerIndex.AddIndexChangedEventHandler(
Delegate( ctrl, ctrl.SpeakerIndexChangedHandler    )
);
ctrl._sequencePlayers.PVSC.AddIndexChangedEventHandler(
Delegate( ctrl, ctrl.PVSCChangedHandler )
);
ctrl._sequencePlayers.QA.AddIndexChangedEventHandler(
Delegate( ctrl, ctrl.QAChangedHandler )
);
ctrl._sequencePlayers.BizChanged.AddIndexChangedEventHandler(
Delegate( ctrl, ctrl.BizChangedHandler )
);
ctrl._seqPlayManager.SetSequences( ctrl._sequencePlayers );
}
ControllerInitializer.prototype._InitPlayers = function( ctrl )
{
ctrl._players[ MeetingSettings.PageType.Audio ]     = new AVPlayer( true );
ctrl._players[ MeetingSettings.PageType.PanoVideo ] = new AVPlayer( false );
ctrl._players[ MeetingSettings.PageType.QCIFVideo ] = new AVPlayer( false );
ctrl._players[ MeetingSettings.PageType.Ppt ]       = new SlidePlayer();
ctrl._players[ MeetingSettings.PageType.Text ]      = new TextPlayer();
ctrl._players[ MeetingSettings.PageType.Image ]     = new ImagePlayer();
ctrl._players[ MeetingSettings.PageType.Web ]       = new WebPlayer();
ctrl._players[ MeetingSettings.PageType.Poll ]      = new PollPlayer();
ctrl._players[ MeetingSettings.PageType.MMC ]       = new MMCPlayer();
ctrl._players[ MeetingSettings.PageType.AppSharing ] = new AppSharingPlayer();
ctrl._players[ MeetingSettings.PageType.Modi ]      = new ImagePlayer();
ctrl._players[ MeetingSettings.PageType.Whiteboard ] = new WhiteBoardPlayer();
ctrl._players[ MeetingSettings.VirtualPageType.Anno ]   = new AnnoPlayer();
ctrl._players[ MeetingSettings.VirtualPageType.Start ]  = new StartPagePlayer();
ctrl._players[ MeetingSettings.VirtualPageType.Notes ]  = new NotesPlayer();
ctrl._players.Ppt.SetAnnoPlayer( ctrl._players.Anno );
ctrl._players.Image.SetAnnoPlayer( ctrl._players.Anno );
ctrl._players.Modi.SetAnnoPlayer( ctrl._players.Anno );
ctrl._players.Whiteboard.SetAnnoPlayer( ctrl._players.Anno );
for ( var pt in ctrl._players )
{
ctrl._players[pt]._name = pt;
ctrl._players[pt].Initialize();
}
ctrl._sequencePlayers.Audio.AddPlayer(
MeetingSettings.PageType.Audio,
ctrl._players[ MeetingSettings.PageType.Audio ]
);
ctrl._sequencePlayers.QCIF.AddPlayer(
MeetingSettings.PageType.QCIFVideo,
ctrl._players[ MeetingSettings.PageType.QCIFVideo ]
);
ctrl._sequencePlayers.Pano.AddPlayer(
MeetingSettings.PageType.PanoVideo,
ctrl._players[ MeetingSettings.PageType.PanoVideo ]
);
ctrl._sequencePlayers.Content.AddPlayer(
MeetingSettings.PageType.Ppt,
ctrl._players[ MeetingSettings.PageType.Ppt ]
);
ctrl._sequencePlayers.Content.AddPlayer(
MeetingSettings.PageType.Image,
ctrl._players[ MeetingSettings.PageType.Image ]
);
ctrl._sequencePlayers.Content.AddPlayer(
MeetingSettings.PageType.Modi,
ctrl._players[ MeetingSettings.PageType.Modi ]
);
ctrl._sequencePlayers.Content.AddPlayer(
MeetingSettings.PageType.Web,
ctrl._players[ MeetingSettings.PageType.Web ]
);
ctrl._sequencePlayers.Content.AddPlayer(
MeetingSettings.PageType.Poll,
ctrl._players[ MeetingSettings.PageType.Poll ]
);
ctrl._sequencePlayers.Content.AddPlayer(
MeetingSettings.PageType.Text,
ctrl._players[ MeetingSettings.PageType.Text ]
);
ctrl._sequencePlayers.Content.AddPlayer(
MeetingSettings.PageType.MMC,
ctrl._players[ MeetingSettings.PageType.MMC ]
);
ctrl._sequencePlayers.Content.AddPlayer(
MeetingSettings.PageType.Whiteboard,
ctrl._players[ MeetingSettings.PageType.Whiteboard ]
);
ctrl._sequencePlayers.Content.AddPlayer(
MeetingSettings.PageType.AppSharing,
ctrl._players[ MeetingSettings.PageType.AppSharing ]
);
ctrl._sequencePlayers.Content.AddPlayer(
MeetingSettings.VirtualPageType.Start,
ctrl._players[ MeetingSettings.VirtualPageType.Start ]
);
ctrl._sequencePlayers.Notes.SetNotesPlayer(
ctrl._players[ MeetingSettings.VirtualPageType.Notes ]
);
}
ControllerInitializer.prototype._InitEventHandlers = function( ctrl )
{
ctrl._eventHandlers[ "Play" ]               = Delegate(ctrl, ctrl.Play);
ctrl._eventHandlers[ "Stop" ]               = Delegate(ctrl, ctrl.Stop);
ctrl._eventHandlers[ "Pause" ]              = Delegate(ctrl, ctrl.Pause);
ctrl._eventHandlers[ "Mute" ]               = DelegateWithArgs(ctrl, ctrl.Mute, true);
ctrl._eventHandlers[ "Unmute" ]             = DelegateWithArgs(ctrl, ctrl.Mute, false);
ctrl._eventHandlers[ "Next" ]               = Delegate(ctrl, ctrl.JumpToNext);
ctrl._eventHandlers[ "Prev" ]               = Delegate(ctrl, ctrl.JumpToPrevious);
ctrl._eventHandlers[ "SetVolume" ]          = Delegate(ctrl, ctrl.SetVolume);
ctrl._eventHandlers[ "GetVolume" ]          = Delegate(ctrl, ctrl.GetVolume);
ctrl._eventHandlers[ "SetSpeed" ]           = Delegate(ctrl, ctrl.SetSpeed);
ctrl._eventHandlers[ "SeekToTime" ]         = Delegate(ctrl, ctrl.SeekToTime);
ctrl._eventHandlers[ "GetCurrentTime" ]     = Delegate(ctrl, ctrl.GetCurrentTime);
ctrl._eventHandlers[ "SetIndexCategory" ]   = Delegate(ctrl, ctrl.SetIndexCategory);
ctrl._eventHandlers[ "JumpToIndex" ]        = Delegate(ctrl, ctrl.JumpToIndex);
ctrl._eventHandlers[ "EnableQCIFVideo" ]    = Delegate(ctrl, ctrl.ChangeQCIFState );
ctrl._eventHandlers[ "EnablePanoVideo" ]    = Delegate(ctrl, ctrl.ChangePanoState );
ctrl._eventHandlers[ "EnableIndex" ]        = Delegate(ctrl, ctrl.EnableIndex );
ctrl._eventHandlers[ "EnableQA" ]           = Delegate(ctrl, ctrl.EnableQA );
ctrl._eventHandlers[ "EnableNotes" ]        = Delegate(ctrl, ctrl.EnableNotes );
ctrl._eventHandlers[ "EnableSpeaker" ]      = Delegate(ctrl, ctrl.EnableSpeaker );
ctrl._eventHandlers[ "EnableAllSpeakers" ]  = Delegate(ctrl, ctrl.EnableAllSpeaker );
}
ControllerInitializer.prototype._InitEvents = function( ctrl )
{
ctrl._events.AddEvent( "MeetingStarted" );
ctrl._events.AddEvent( "MeetingStopped" );
ctrl._events.AddEvent( "MeetingPaused" );
ctrl._events.AddEvent( "VolumeChanged" );
ctrl._events.AddEvent( "SpeedChanged" );
ctrl._events.AddEvent( "TimeChanged" );
ctrl._events.AddEvent( "MeetingMuted" );
ctrl._events.AddEvent( "ContentIndexChanged" );
ctrl._events.AddEvent( "SpeakerIndexChanged" );
ctrl._events.AddEvent( "IndexCategoryChanged" );
ctrl._events.AddEvent( "SpeakerChanged" );
ctrl._events.AddEvent( "BizcardChanged" );
ctrl._events.AddEvent( "QAChanged" );
ctrl._events.AddEvent( "QCIFVideoEnabled" );
ctrl._events.AddEvent( "PanoVideoEnabled" );
ctrl._events.AddEvent( "IndexEnabled" );
ctrl._events.AddEvent( "QAEnabled" );
ctrl._events.AddEvent( "NotesEnabled" );
ctrl._events.AddEvent( "DataAvailable" );
ctrl._events.AddEvent( "SpeakerEnabled" );
ctrl._events.AddEvent( "SpeakerAllEnabled" );
ctrl._events.AddEvent( "MeetingBuffering" );
ctrl._bizcardCtrlManager.SetActionEvent( ctrl._events.GetEvent("BizcardChanged") );
}
ControllerInitializer.prototype._InitIndex = function( ctrl )
{
ctrl._events.FireEvent( "IndexCategoryChanged", MeetingSettings.Index.ContentName );
}
Trace.Wrap( "ControllerInitializer" );
function ControllerUninitializer()
{
}
ControllerUninitializer.prototype.Execute = function( ctrl )
{
if ( ctrl._meetingStarted )
{
ctrl._CoreStop();
}
for( var st in this._sequencePlayers )
{
ctrl._sequencePlayers[st].Uninitialize();
}
for (var pt in this._players )
{
ctrl._players[pt].Uninitialize();
}
}
Trace.Wrap( "ControllerUninitializer" );
function BufferingEventProcessor()
{
this._keyStreamBuffering = false;
this._meetingWaiting = false;
this._lastState = BufferingEventProcessor.Unspecified;
this.BufferingChanged = new Event();
}
BufferingEventProcessor.Unspecified = 0;
BufferingEventProcessor.Buffering = 1;
BufferingEventProcessor.Ready = 2;
BufferingEventProcessor.prototype.KeyStreamBuffering = function()
{
this._keyStreamBuffering = true;
if ( this._lastState != BufferingEventProcessor.Buffering )
{
this.BufferingChanged( true );
this._lastState = BufferingEventProcessor.Buffering;
}
}
BufferingEventProcessor.prototype.KeyStreamReady = function()
{
this._keyStreamBuffering = false;
if ( !this._meetingWaiting && this._lastState != BufferingEventProcessor.Ready )
{
this.BufferingChanged( false );
this._lastState = BufferingEventProcessor.Ready;
}
}
BufferingEventProcessor.prototype.WaitResume = function()
{
this._meetingWaiting = true;
if ( this._lastState != BufferingEventProcessor.Buffering )
{
this.BufferingChanged( true );
this._lastState = BufferingEventProcessor.Buffering;
}
}
BufferingEventProcessor.prototype.ApplyResume = function()
{
this._meetingWaiting = false;
if ( !this._keyStreamBuffering && this._lastState != BufferingEventProcessor.Ready )
{
this.BufferingChanged( false );
this._lastState = BufferingEventProcessor.Ready;
}
}
Trace.Wrap( "BufferingEventProcessor" );
function ControllerFFVistaPatch( controller )
{
this._controller = controller;
}
ControllerFFVistaPatch.prototype.Exec = function()
{
var osName = NavigatorInfo.GetOSName();
var osType = NavigatorInfo.GetOSType();
var osVer  = NavigatorInfo.GetOSVersion();
var isFF   = NavigatorInfo.IsFirefox();
if ( osName == "Windows"
&& osType == "NT"
&& CompareVersion( osVer, "6.0" ) >= 0
&& isFF )
{
this._controller._pageChangeEvents.PanoVideo = [];
}
}
function Controller()
{
this._meetingInfo       = null;
this._pageChangeEvents  = null;
this._contentIndexData  = null;
this._speakerIndexData  = null;
this._pvscData          = null;
this._bizChangedData    = null;
this._attendeeList      = null;
this._locale            = null;
this._controllerInitializer = new ControllerInitializer();
this._controllerUninitializer = new ControllerUninitializer();
this._bufferingEventProcessor = new BufferingEventProcessor();
this._filterEngine      = new FilterEngine();
this._bufferManager     = new BufferingManager();
this._bwdManager        = new BWDManager();
this._seqPlayManager       = new SequencePlayManager();
this._bizcardCtrlManager = new BizcardCtrlManager();
this._sequencePlayers   = new Object();
this._players           = new Object();
this._indexers = new Object();
this._pulseCount = 0;
this._isWebLocation = false;
this._forceSeek = false;
this._meetingState = new MeetingSettings.MeetingStateClass(
MeetingSettings.MeetingState.Undefined,
1.0,
1.0,
false,
0,
false
);
this._seqPlayManager.SetMeetingStateRef( this._meetingState );
this._meetingSpeed      = 1.0;
this._finitialized      = false;
this._meetingStarted    = false;
this._someStreamTimedOut = false;
this._events            = new EventsManager();
this._eventHandlers     = new Object();
this.LoadFinished       = new Event();
this.AllWaitNeededReady = new Event();
this._bufferManager.PredownloadFinishedEvent.Add( this.LoadFinished );
this._bufferManager.BandwidthIsLowEvent.Add(
Delegate( this, Controller.prototype._LowBandwidthHandler )
);
this._filterEngine.AllGroupEnabled.Add(
DelegateWithArgs(
this._events,
this._events.FireEvent,
"SpeakerAllEnabled"
)
);
this._bufferingEventProcessor.BufferingChanged.Add(
Delegate(
this,
this._MeetingBuffering
)
);
this._seqPlayManager.WaitingChanged.Add(
Delegate(
this,
this._WaitingChanged
)
);
this._ffVistaPatch  = new ControllerFFVistaPatch( this );
}
Controller.PredownloadInterval = 10;
Controller.prototype.Initialize = function()
{
this._controllerInitializer.Execute( this );
this._finitialized = true;
}
Controller.prototype.Uninitialize = function()
{
this._controllerUninitializer.Execute( this );
this._finitialized = false;
}
Controller.prototype.SetMeetingInfo = function( meetingInfo )
{
this._meetingInfo = meetingInfo;
this._sequencePlayers.GlobalTimer.SetMeetingDuration( meetingInfo.duration );
this._players[ MeetingSettings.VirtualPageType.Notes ].SetURI( meetingInfo.Notes );
this._players[ MeetingSettings.VirtualPageType.Start ].SetMeetingInfo( meetingInfo );
}
Controller.prototype.UpdateDuration = function ( durNew )
{
this._sequencePlayers.GlobalTimer.SetMeetingDuration( durNew );
}
Controller.prototype.SetPageChangeEvent = function( pageChangeEvents )
{
if ( !pageChangeEvents )
{
pageChangeEvents = {"Audio":[],"QCIFVideo":[],"PanoVideo":[],"Content":[]};
}
this._pageChangeEvents = pageChangeEvents;
this._ffVistaPatch.Exec();
if ( NavigatorInfo.WmvEnabled() )
{
this._sequencePlayers.Audio.SetPageChangeEvents( pageChangeEvents.Audio );
this._sequencePlayers.QCIF.SetPageChangeEvents( pageChangeEvents.QCIFVideo );
this._sequencePlayers.Pano.SetPageChangeEvents( pageChangeEvents.PanoVideo );
}
this._sequencePlayers.Content.SetPageChangeEvents( pageChangeEvents.Content );
this._bufferManager.SetPageChangeEvents( pageChangeEvents );
}
Controller.prototype.SetContentIndexData = function( contentIndex )
{
this._contentIndexData = contentIndex;
this._sequencePlayers.ContentIndex.SetIndexData( contentIndex );
}
Controller.prototype.SetSpeakerIndexData = function( speakerIndex )
{
this._speakerIndexData = speakerIndex;
this._PrepareFilterData();
this._sequencePlayers.SpeakerIndex.SetIndexData( speakerIndex );
}
Controller.prototype.SetAttendeeList = function( attendeeList )
{
this._attendeeList = attendeeList;
}
Controller.prototype.SetQAData = function( qaData )
{
this._sequencePlayers.QA.SetIndexData( qaData );
}
Controller.prototype.SetPrimVideoSrcChangedData = function( pvscData )
{
this._pvscData = pvscData;
this._sequencePlayers.PVSC.SetIndexData( pvscData );
}
Controller.prototype.SetBizcardChagnedData = function( bizChangedData )
{
this._bizChangedData = bizChangedData;
this._sequencePlayers.BizChanged.SetIndexData( bizChangedData );
}
Controller.prototype.SetPromptBandWidthMessageHandler = function( handler )
{
this._bwdManager.Initialize( this._sequencePlayers, handler );
this._bwdManager.CloseSeqenceEvent.Add( Delegate( this, Controller.prototype._CloseStream ) );
}
Controller.prototype.PrePlay = function()
{
this._InitializeUI();
this._bufferManager.SwithToPlayingState();
this._preplaying = true;
this.AllWaitNeededReady.PostFire();
}
Controller.prototype.StartMeetingPlayback = function()
{
for ( var mainseq in {Audio:"Audio"} )
{
this._sequencePlayers[mainseq].BufferingEvent.Add(
Delegate( this._bufferingEventProcessor, this._bufferingEventProcessor.KeyStreamBuffering )
);
this._sequencePlayers[mainseq].ReadyEvent.Add(
Delegate( this._bufferingEventProcessor, this._bufferingEventProcessor.KeyStreamReady )
);
}
this._seqPlayManager.MeetingPlaybackStarted();
this.Play();
this.SeekToTime( 0 );
this._meetingStarted = true;
this.Mute( false );
}
Controller.prototype._MeetingBuffering = function( isBuffering )
{
this._events.FireEvent( "MeetingBuffering", isBuffering, this._meetingState.State );
}
Controller.prototype._GetWaitNeededSequences = function()
{
var retval = [];
for( var seq in this._sequencePlayers )
{
if ( this._sequencePlayers[seq].WaitingNeeded() )
{
retval.push( this._sequencePlayers[seq] );
}
}
return retval;
}
Controller.prototype._SetWaitReadyHandlerToSequences = function( seqs )
{
for( var i = 0; i < seqs.length; i++ )
{
seqs[i].ReadyEvent.Add(
DelegateWithArgs(
this,
Controller.prototype._SequenceWaitReadyHandler,
seqs[i]._name)
);
}
}
Controller.prototype._CheckAllSequenceReadyForWait = function()
{
var allSeqReady = true;
for( var seq in this._sequencePlayers )
{
if ( this._sequencePlayers[seq].WaitingNeeded() )
{
if ( !this._sequencePlayers[seq]._waitReady )
{
allSeqReady = false;
break;
}
}
}
return allSeqReady;
}
Controller.prototype._SequenceWaitReadyHandler = function( seqId, bTimedOut )
{
if ( !this._preplaying )
{
return;
}
if ( bTimedOut )
{
this._someStreamTimedOut = true;
}
this._sequencePlayers[seqId]._waitReady = true;
if ( this._CheckAllSequenceReadyForWait() )
{
this._ProcAllSequencesReadyForWait();
}
}
Controller.prototype._ProcAllSequencesReadyForWait = function()
{
this._preplaying = false;
if ( this._someStreamTimedOut )
{
this._bwdManager.PromotToCloseStream();
}
this.AllWaitNeededReady();
}
Controller.prototype._InitializeUI = function()
{
this._events.FireEvent( "SpeakerAllEnabled", true, true );
this._events.FireEvent( "QCIFVideoEnabled", true );
this._events.FireEvent( "PanoVideoEnabled", this._sequencePlayers.Pano.HasData() );
this._events.FireEvent( "IndexEnabled", true );
this._events.FireEvent( "QAEnabled", false );
this._events.FireEvent( "NotesEnabled", false );
for ( var seq in this._sequencePlayers )
{
this._events.FireEvent( "DataAvailable", seq, this._sequencePlayers[ seq ].HasData() );
}
this._events.FireEvent( "IndexCategoryChanged", MeetingSettings.Index.ContentName );
this._events.FireEvent( "VolumeChanged", 1.0 );
this._events.FireEvent( "SpeedChanged", 1.0 );
this._events.FireEvent( "MeetingMuted", false );
}
Controller.prototype.LoadPages = function()
{
this._isWebLocation = true;
this._bufferManager.LoadPages();
}
Controller.prototype.Play = function( )
{
this._meetingState.State = MeetingSettings.MeetingState.Playing;
this._bwdManager.Reset();
for( var seqPlayer in this._sequencePlayers )
{
this._sequencePlayers[ seqPlayer ].IsBuffering = false;
if ( this._sequencePlayers[ seqPlayer ].Play )
{
this._sequencePlayers[ seqPlayer ].Play();
}
}
this._events.FireEvent( "MeetingStarted" );
this._bizcardCtrlManager.Play();
}
Controller.prototype._CoreStop = function()
{
this._meetingState.State = MeetingSettings.MeetingState.Stopped;
this._bwdManager.Reset();
for( var seqPlayer in this._sequencePlayers )
{
this._sequencePlayers[ seqPlayer ].IsBuffering = false;
if ( this._sequencePlayers[ seqPlayer ].Stop )
{
this._sequencePlayers[ seqPlayer ].Stop();
}
}
this._CorePulse();
this._events.FireEvent( "MeetingStopped" );
}
Controller.prototype.Stop = function()
{
this._CoreStop();
this._bizcardCtrlManager.Stop();
}
Controller.prototype.Pause = function()
{
this._meetingState.State = MeetingSettings.MeetingState.Paused;
this._bwdManager.Reset();
for( var seqPlayer in this._sequencePlayers )
{
this._sequencePlayers[ seqPlayer ].IsBuffering = false;
if ( this._sequencePlayers[ seqPlayer ].Pause )
{
this._sequencePlayers[ seqPlayer ].Pause();
}
}
this._events.FireEvent( "MeetingPaused" );
this._bizcardCtrlManager.Pause();
}
Controller.prototype.Mute = function( ismuted )
{
this._meetingState.IsMute = ismuted;
for( var seqPlayer in this._sequencePlayers )
{
if ( this._sequencePlayers[ seqPlayer ].Mute )
{
this._sequencePlayers[ seqPlayer ].Mute( ismuted );
}
}
this._events.FireEvent( "MeetingMuted", ismuted );
}
Controller.prototype.SetVolume = function( vol )
{
this._meetingState.Volume = vol;
for( var seqPlayer in this._sequencePlayers )
{
if ( this._sequencePlayers[ seqPlayer ].SetVolume )
{
this._sequencePlayers[ seqPlayer ].SetVolume( vol );
}
}
this._events.FireEvent( "VolumeChanged", vol );
}
Controller.prototype.SetSpeed = function( speed )
{
this._meetingState.Speed = speed;
for( var seqPlayer in this._sequencePlayers )
{
if (this._sequencePlayers[ seqPlayer ].SetRate)
{
this._sequencePlayers[ seqPlayer ].SetRate( speed );
}
}
this._events.FireEvent( "SpeedChanged", speed );
}
Controller.prototype.SeekToTime = function( tmNew, forward )
{
if ( typeof forward != "boolean" )
{
forward = true;
}
if ( ! this._filterEngine.CheckPosition( tmNew ) )
{
tmNew = this._filterEngine.FilterPosition( tmNew, forward );
}
this._ProcessTimeFiltered( tmNew );
}
Controller.prototype.SetIndexCategory = function( indexName )
{
this._activeIndexSequencePlayer = this._indexers[indexName];
this._events.FireEvent( "IndexCategoryChanged", indexName );
}
Controller.prototype.JumpToIndex = function( idx )
{
var pos = this._activeIndexSequencePlayer.GetIndexPos( idx );
this.SeekToTime( pos );
}
Controller.prototype.JumpToNext = function( )
{
var currentTime = this.GetCurrentTime();
var pos = this._activeIndexSequencePlayer.GetPosOfNext( currentTime );
if( pos != currentTime )
{
this.SeekToTime( pos, true );
}
}
Controller.prototype.JumpToPrevious = function( )
{
var currentTime = this.GetCurrentTime();
var pos = this._activeIndexSequencePlayer.GetPosOfPrev( currentTime );
if( pos != currentTime )
{
this.SeekToTime( pos, false );
}
}
Controller.prototype.GetEventHandlers = function()
{
return this._eventHandlers;
}
Controller.prototype.GetEventManager = function()
{
return this._events;
}
Controller.prototype.OnFireEvent = function( eventname )
{
this._events.FireEvent( arguments );
}
Controller.prototype.onMeetingFinished = function()
{
this._events.FireEvent( "TimeChanged",  this._meetingInfo.duration );
setTimeout( Delegate(this, Controller.prototype.Stop), 0 );
}
Controller.prototype.GetVolume = function( vol )
{
this._sequencePlayers.Audio.GetVolume( vol );
}
Controller.prototype.GetCurrentTime = function()
{
var baseSeq = this._sequencePlayers.GlobalTimer;
return baseSeq.GetAbsolutePosition( );
}
Controller.prototype.GetDataSequence = function( )
{
return this._sequencePlayers.Content;
}
Controller.prototype.GetPlayer = function( playerName )
{
var player = this._players[ playerName ];
return player;
}
Controller.prototype._CorePulse = function()
{
this._seqPlayManager.Pulse();
var baseSeq = this._sequencePlayers.GlobalTimer;
var pos = baseSeq.GetAbsolutePosition( );
if ( this._isWebLocation )
{
if ( ( this._forceSeek ) || ( this._pulseCount % Controller.PredownloadInterval ) == 0 )
{
this._bufferManager.Seek( pos );
this._forceSeek = false;
}
this._pulseCount++;
}
this._events.FireEvent( "TimeChanged", pos );
}
Controller.prototype.Pulse = function( )
{
if (!this._finitialized)
{
}
var baseSeq = this._sequencePlayers.GlobalTimer;
this._meetingState.MeetingPos = baseSeq.GetAbsolutePosition( );
if ( !this._filterEngine.CheckPosition( this._meetingState.MeetingPos ) )
{
var tmNew = this._filterEngine.FilterPosition( this._meetingState.MeetingPos, true );
this._ProcessTimeFiltered( tmNew );
return;
}
this._CorePulse();
}
Controller.prototype.QAChangedHandler = function ( idx, actived )
{
if ( idx == null )
{
idx = -1;
}
this._events.FireEvent( "QAChanged", idx, actived );
}
Controller.prototype.BizChangedHandler = function( idx )
{
var action = "show";
if ( idx != null )
{
action = this._bizChangedData[idx].action;
}
this._bizcardCtrlManager.SwitchAction( action );
}
Controller.prototype.ContentIndexChangedHandler = function( idx )
{
if ( idx == null )
{
idx = -1;
}
this._events.FireEvent( "ContentIndexChanged", idx );
}
Controller.prototype.SpeakerIndexChangedHandler = function( idx )
{
if ( idx == null )
{
idx = -1;
}
this._events.FireEvent( "SpeakerIndexChanged", idx );
}
Controller.prototype._GetAttendeeInfo = function( idx )
{
var speakerInfo = null;
var attendeeId = null;
var pvscData = this._pvscData;
if( pvscData != null && idx >= 0 && idx < pvscData.length )
{
attendeeId = pvscData[ idx ].attendee;
}
if( attendeeId != null && this._attendeeList != null )
{
speakerInfo = this._attendeeList[ attendeeId ];
}
return speakerInfo;
}
Controller.prototype.EnableQCIFVideo = function( enabled )
{
this._events.FireEvent( "QCIFVideoEnabled", enabled );
if ( !enabled )
{
this._players.QCIFVideo.ShutDown( );
this._sequencePlayers.QCIF.Closed = true;
}
else
{
this._players.QCIFVideo.Reconnect( );
this._sequencePlayers.QCIF.Closed = false;
}
}
Controller.prototype.ChangeQCIFState = function( currentEnabled )
{
this.EnableQCIFVideo( !currentEnabled );
}
Controller.prototype.EnablePanoVideo = function( enabled )
{
this._events.FireEvent( "PanoVideoEnabled", enabled );
if ( !enabled )
{
this._players.PanoVideo.ShutDown( );
this._sequencePlayers.Pano.Closed = true;
}
else
{
this._players.PanoVideo.Reconnect( );
this._sequencePlayers.Pano.Closed = false;
}
}
Controller.prototype.ChangePanoState = function( currentEnabled )
{
this.EnablePanoVideo( !currentEnabled );
}
Controller.prototype.EnableIndex = function( enable )
{
this._events.FireEvent( "IndexEnabled", !enable );
}
Controller.prototype.EnableQA = function( enable )
{
this._events.FireEvent( "QAEnabled", !enable );
}
Controller.prototype.EnableNotes = function( enable )
{
this._events.FireEvent( "NotesEnabled", !enable );
}
Controller.prototype.EnableSpeaker = function( speakerId, isEnable )
{
this._filterEngine.EnableGroup( speakerId, isEnable );
this.Pulse();
this._events.FireEvent( "SpeakerEnabled", speakerId, isEnable );
}
Controller.prototype.EnableAllSpeaker = function( enable )
{
this._filterEngine.EnableAllGroup( enable );
this.Pulse();
}
Controller.prototype._PrepareFilterData = function( )
{
var filterData = [];
for( var i = 0; i < this._speakerIndexData.length; i++ )
{
var item = this._speakerIndexData[i];
var obj = new Object();
obj.time = item.time;
obj.group = item.attendee;
filterData.push( obj );
}
this._filterEngine.SetFilterItems( filterData );
}
Controller.prototype._DoSeekToTime = function( tmNew )
{
this._bwdManager.Reset();
this._seqPlayManager.DoSeek( tmNew );
this._forceSeek = true;
this._CorePulse();
}
Controller.prototype._ProcessTimeFiltered = function( tmNew )
{
if ( tmNew < 0 )
{
this.Stop();
}
else
{
this._DoSeekToTime( tmNew );
}
}
Controller.prototype._CloseStream = function( seqId )
{
if ( seqId == this._sequencePlayers.QCIF._name )
{
this.EnableQCIFVideo( false );
}
else if ( seqId == this._sequencePlayers.Pano._name )
{
this.EnablePanoVideo( false );
}
else
{
}
}
Controller.prototype.PVSCChangedHandler = function( idx )
{
if ( idx == null )
{
this._events.FireEvent( "SpeakerChanged", null );
}
else
{
var speakerInfo = this._GetAttendeeInfo( idx );
this._events.FireEvent( "SpeakerChanged", speakerInfo );
}
}
Controller.prototype.RestoreForError = function()
{
if ( this._meetingState.State != MeetingSettings.MeetingState.Undefined )
{
this.Stop();
}
}
Controller.prototype._WaitingChanged = function( isWaiting )
{
if ( isWaiting )
{
this._bufferingEventProcessor.WaitResume();
}
else
{
this._bufferingEventProcessor.ApplyResume();
}
}
Controller.prototype._LowBandwidthHandler = function( isLow )
{
var avPlayers = {
Audio:MeetingSettings.PageType.Audio,
PanoVideo:MeetingSettings.PageType.PanoVideo,
QCIFVideo:MeetingSettings.PageType.QCIFVideo,
MMC:MeetingSettings.PageType.MMC,
AppSharing:MeetingSettings.PageType.AppSharing
};
for( var playerName in avPlayers)
{
this._players[ playerName ].SetLowBandwidth( isLow );
}
this._seqPlayManager.SetLowBandwidth( isLow );
}
Trace.Wrap( "Controller" );
function DataSettingImpl( root )
{
this._XML_Par = function( dataName, sURI )
{
this.DataName = dataName;
this.URI = sURI;
}
if( root == null )
{
root = "";
}
if( !root.match( /\/$/ ) )
{
root += "/";
}
this.DataRoot = root;
this.InputFolder     = root + "input/";
this.XMLParList = new Object();
this.XMLParList.MeetingInfo =
new this._XML_Par( "MeetingInfo", this.InputFolder + "MeetingInfo.xml" );
this.XMLParList.Index =
new this._XML_Par( "Index", this.InputFolder + "Index.xml" );
this.XMLParList.Current =
new this._XML_Par( "Current", this.InputFolder + "Current.xml" );
this.XMLParList.OptData =
new this._XML_Par( "OptData", this.InputFolder + "OptData.xml" );
}
var DataSetting = null;
function BaseDataProcessor()
{
}
BaseDataProcessor.InvalidTime = -100;
BaseDataProcessor.DefaultSize = 1000;
BaseDataProcessor.prototype.ProcessNode = function( node )
{
this._ProcessNodeByName( node, node._name.toLowerCase() );
}
BaseDataProcessor.prototype.ProcessResult = function( res )
{
}
BaseDataProcessor.prototype._ProcessNodeByName = function( node, name )
{
}
BaseDataProcessor.prototype._AddToStart = function( content, item )
{
MoveTheFirstLittle( content );
content.unshift( item );
}
BaseDataProcessor.ParseFloat = function( data, defaultVal )
{
if ( defaultVal == null || isNaN( defaultVal ) )
{
defaultVal = 0;
Trace.WriteWarning( "Invalide Default Value!" );
}
var ret = parseFloat( data );
if ( isNaN( ret ) )
{
ret = defaultVal;
BaseDataProcessor.ParseFloat.DefaultValueUsed = true;
}
else
{
BaseDataProcessor.ParseFloat.DefaultValueUsed = false;
}
return ret;
}
BaseDataProcessor.ParseTimeAttribute = function( strTime, defaultVal )
{
var ret = 0;
ret = BaseDataProcessor.ParseFloat( strTime, defaultVal );
if ( ret < 0 )
{
ret = 0;
}
BaseDataProcessor.ParseTimeAttribute.DefaultValueUsed
= BaseDataProcessor.ParseFloat.DefaultValueUsed;
return ret;
}
BaseDataProcessor.ParseDate = function( str, defaultVal )
{
var date;
var matchResult = str.match(
/^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2})([+-])(\d{2}):(\d{2})$/
);
if( matchResult != null )
{
var year = matchResult[1];
var month = matchResult[2];
var day = matchResult[3];
var hour = matchResult[4];
var min = matchResult[5];
var second = matchResult[6];
var sign = matchResult[7];
var regionHour = matchResult[8];
var regionMin = matchResult[9];
var time = Date.UTC(
parseInt( year, 10 ),
parseInt( month, 10 ) - 1,
parseInt( day, 10 ),
parseInt( hour, 10 ),
parseInt( min, 10 ),
parseInt( second, 10 ) );
var regionSecond = parseInt( regionHour, 10 ) * 3600 + parseInt( regionMin, 10 ) * 60;
var regionMilliSecond = regionSecond * 1000;
if( sign == "+" )
{
time -= regionMilliSecond;
}
else
{
time += regionMilliSecond;
}
date = new Date( time );
}
else
{
date = defaultVal;
}
return date;
}
BaseDataProcessor.GetFullPath = function( url )
{
if (! url.match( /^\w+:\/\/.+$/ ) )
{
url = DataSetting.DataRoot + url;
}
else
{
g_ErrorHandling.ShowWarning( E_UNSECUREURL );
url = null;
}
return url;
}
Trace.Wrap( "BaseDataProcessor" );
function IndexDataProcessor()
{
OOP.CallParentConstructor( this, arguments.callee );
this._dummyIndex = {title:"dummy",time:0};
this._dummyIndex.thumb = uiSettings.GetImage( "dummy" );
this._biggestTime = 0;
this.version = null;
}
OOP.Inherit( IndexDataProcessor, BaseDataProcessor );
IndexDataProcessor.prototype.ProcessResult = function( data )
{
if ( data && data.attributes && data.attributes.version )
{
this.version = data.attributes.version;
}
this._ParseIndex( data );
}
IndexDataProcessor.prototype._ProcessNodeByName = function( node, name )
{
switch ( name )
{
case "indexitem":
this._ProcessIndexIndexItemNode( node );
break;
default:
}
}
IndexDataProcessor.prototype._ProcessIndexIndexItemNode = function( node )
{
if ( !node.attributes )
{
node.attributes = new Object();
node.attributes.time = BaseDataProcessor.InvalidTime;
node.value = null;
g_ErrorHandling.ShowWarning( E_INVALIDINDEXITEM );
return;
}
if( node.attributes.thumb )
{
node.attributes.thumb = BaseDataProcessor.GetFullPath( node.attributes.thumb );
}
if ( node.attributes.time )
{
node.attributes.time = BaseDataProcessor.ParseTimeAttribute( node.attributes.time, BaseDataProcessor.InvalidTime );
}
else
{
node.attributes.time = BaseDataProcessor.InvalidTime;
g_ErrorHandling.ShowWarning( E_INVALIDINDEXITEMTIME );
}
}
IndexDataProcessor.prototype._ParseIndex = function( data )
{
if ( this._contentIndex != null )
{
return;
}
if ( this._speakerIndex != null )
{
return;
}
this._contentIndexs = [];
this._speakerIndexs = [];
this._ProcessIndexSequence( data, "contentchanged", "_contentIndexs" );
this._AddToStart( this._contentIndexs, this._dummyIndex );
this._ProcessIndexSequence( data, "speakerchanged", "_speakerIndexs" );
}
IndexDataProcessor.prototype._ProcessIndexSequence = function( data, seq, member )
{
var i;
var previousIndexTime = -1;
if (data && data[seq] && data[seq][0] && data[seq][0].indexitem )
{
for( i = 0; i < data[seq][0].indexitem.length; i++ )
{
var item = data[seq][0].indexitem[i];
if ( !item.attributes )
{
continue;
}
if ( item.attributes.time == null )
{
continue;
}
var tarItem = new Object();
tarItem.title = item.value;
tarItem.time = item.attributes.time;
if ( item.attributes.thumb )
{
tarItem.thumb = item.attributes.thumb;
}
if ( item.attributes.attendee )
{
tarItem.attendee = item.attributes.attendee;
}
if ( previousIndexTime < tarItem.time )
{
this[ member ].push( tarItem );
previousIndexTime = tarItem.time;
if ( this._biggestTime < tarItem.time )
{
this._biggestTime = tarItem.time;
}
}
}
}
}
IndexDataProcessor.prototype.GetBiggestTime = function()
{
return this._biggestTime;
}
IndexDataProcessor.prototype.SetDummyTitle = function( title )
{
this._dummyIndex.title = title;
}
Trace.Wrap( "BaseDataProcessor" );
function OptDataProcessor()
{
OOP.CallParentConstructor( this, arguments.callee );
this.textOpts = [];
}
OOP.Inherit( OptDataProcessor, BaseDataProcessor );
OptDataProcessor.prototype.ProcessResult = function( data )
{
this._ParseTextOptData( data );
}
OptDataProcessor.prototype._ProcessNodeByName = function( node, name )
{
switch ( name )
{
case "snapshot":
this._ProcessSnapshot( node );
break;
default:
}
}
OptDataProcessor.prototype._ProcessSnapshot = function( node )
{
if ( !node.attributes )
{
node.attributes = new Object();
node.attributes.time = BaseDataProcessor.InvalidTime;
node.value = null;
g_ErrorHandling.ShowWarning( E_INVALIDOPTDATANODE );
return;
}
if ( node.attributes.time )
{
node.attributes.time = BaseDataProcessor.ParseTimeAttribute( node.attributes.time, BaseDataProcessor.InvalidTime );
}
else
{
node.attributes.time = BaseDataProcessor.InvalidTime;
g_ErrorHandling.ShowWarning( E_INVALIDOPTDATANODETIME );
}
}
OptDataProcessor.prototype._ParseTextOptData = function( data )
{
if ( !data.textopt )
{
return;
}
if ( !data.textopt[0].snapshot )
{
return;
}
var latestMsgTime = -1;
for ( var i = 0; i < data.textopt[0].snapshot.length; i ++ )
{
var snapshot = data.textopt[0].snapshot[i];
if ( snapshot.text == null || snapshot.text[0].value == null )
{
continue;
}
var tarsnapshot = new Object();
tarsnapshot.time = snapshot.attributes.time;
if ( snapshot.text )
{
tarsnapshot.text = snapshot.text[0].value;
}
tarsnapshot.action = "snapshot";
tarsnapshot.page = snapshot.attributes.page;
if ( ( typeof tarsnapshot.text == "string" )
&&( typeof tarsnapshot.page == "string") )
{
if ( tarsnapshot.time != BaseDataProcessor.InvalidTime )
{
if ( latestMsgTime < tarsnapshot.time )
{
this.textOpts.push( tarsnapshot );
latestMsgTime = tarsnapshot.time;
}
}
}
else
{
g_ErrorHandling.ShowWarning( E_INVALIDOPTSNAPSHOT );
}
}
}
Trace.Wrap( "BaseDataProcessor" );
function MeetingInfoDataProcessor()
{
OOP.CallParentConstructor( this, arguments.callee );
this._badDuration = false;
this.version = null;
}
OOP.Inherit( MeetingInfoDataProcessor, BaseDataProcessor );
MeetingInfoDataProcessor.NotesRegExp = /^[^:]+\.htm$/i;
MeetingInfoDataProcessor.prototype.ProcessResult = function( data )
{
if ( !data )
{
g_ErrorHandling.ShowError( E_MEETINGINFONOTPROVIDED );
return;
}
if ( data && data.attributes && data.attributes.version )
{
this.version = data.attributes.version;
}
this.meetingInfo = this._ProcessMiscInfo( data );
this.attendeeList = this._ProcessAttendeeList( data );
this.meetingInfo.Notes = this._ProcessNotes( data );
}
MeetingInfoDataProcessor.prototype._ProcessNotes = function( data )
{
var notes = null;
if ( data.meetingnotes && data.meetingnotes[0] )
{
var src = data.meetingnotes[0].value;
if (( src != null ) && (src.match( MeetingInfoDataProcessor.NotesRegExp )))
{
notes = BaseDataProcessor.GetFullPath( src );
}
}
return notes;
}
MeetingInfoDataProcessor.prototype._ProcessMiscInfo = function( data )
{
var miscInfo = new Object();
miscInfo.organizer = null;
miscInfo.startTime = null;
miscInfo.stopTime = null;
miscInfo.duration = 0;
miscInfo.subject = null;
miscInfo.location = null;
miscInfo.branding = null;
if ( data.miscinfo && data.miscinfo[0] )
{
if ( data.miscinfo[0].organizer && data.miscinfo[0].organizer[0] )
{
miscInfo.organizer = data.miscinfo[0].organizer[0].value;
}
if ( data.miscinfo[0].starttime && data.miscinfo[0].starttime[0] )
{
miscInfo.startTime = BaseDataProcessor.ParseDate(
data.miscinfo[0].starttime[0].value,
miscInfo.startTime );
}
if ( data.miscinfo[0].stoptime && data.miscinfo[0].stoptime[0] )
{
miscInfo.stopTime = BaseDataProcessor.ParseDate(
data.miscinfo[0].stoptime[0].value,
miscInfo.stopTime );
}
if ( data.miscinfo[0].duration && data.miscinfo[0].duration[0] )
{
miscInfo.duration =
BaseDataProcessor.ParseTimeAttribute( data.miscinfo[0].duration[0].value );
this._badDuration = BaseDataProcessor.ParseTimeAttribute.DefaultValueUsed;
}
else
{
this._badDuration = true;
}
if ( data.miscinfo[0].subject && data.miscinfo[0].subject[0] )
{
miscInfo.subject = data.miscinfo[0].subject[0].value;
}
if ( data.miscinfo[0].location && data.miscinfo[0].location[0] )
{
miscInfo.location = data.miscinfo[0].location[0].value;
}
if ( data.miscinfo[0].branding && data.miscinfo[0].branding[0] )
{
miscInfo.branding = BaseDataProcessor.GetFullPath( data.miscinfo[0].branding[0].value );
}
}
return miscInfo;
}
MeetingInfoDataProcessor.prototype._ProcessAttendeeList = function( data )
{
var attendees = new Object();
if ( data.attendeelist && data.attendeelist[0] && data.attendeelist[0].attendee )
{
for( var i = 0; i < data.attendeelist[0].attendee.length; i++ )
{
var item = data.attendeelist[0].attendee[i];
if ( item.attributes && item.attributes.id )
{
if ( attendees[ item.attributes.id ] )
{
g_ErrorHandling.ShowWarning( E_ATTENDEEDUPLICATED );
}
attendees[ item.attributes.id ] = this._GetValideAttendee( item );
}
}
}
return attendees;
}
MeetingInfoDataProcessor.prototype._GetValideAttendee = function( attendee )
{
var att = new Object();
att.fullName = null;
att.nameInMeeting = null;
att.corporation = null;
att.organization = null;
att.title = null;
att.email = null;
att.phone = null;
att.photo = null;
if ( attendee.fullname )
{
att.fullName = attendee.fullname[0].value;
}
if ( attendee.nameinmeeting )
{
att.nameInMeeting = attendee.nameinmeeting[0].value;
}
if ( attendee.corporation )
{
att.corporation = attendee.corporation[0].value;
}
if ( attendee.organization )
{
att.organization = attendee.organization[0].value;
}
if ( attendee.title )
{
att.title = attendee.title[0].value;
}
if ( attendee.email )
{
if ( attendee.email[0].value == null )
{
att.email = "";
}
else if ( !attendee.email[0].value.match( /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/ ) )
{
att.email = "";
}
else
{
att.email = attendee.email[0].value;
}
}
if ( attendee.figure )
{
if ( attendee.figure[0].value != null )
{
att.photo = BaseDataProcessor.GetFullPath( attendee.figure[0].value );
}
}
if ( attendee.phone )
{
att.phone = attendee.phone[0].value;
}
return att;
}
Trace.Wrap( "BaseDataProcessor" );
function CurrentDataProcessorEx()
{
OOP.CallParentConstructor( this, arguments.callee );
this._emptyPage = {pageType:null};
this._startPage = {pageType:MeetingSettings.VirtualPageType.Start};
this._startEvent = new Object();
this._startEvent.time = 0;
this._startEvent.Page = this._startPage;
this.pageList = [];
this.qaList = [];
this.pvscList = [];
this.bzcList = [];
this._biggestTime = 0;
this.version = null;
this.ParsingDone = new Event();
this._previousInnerMsgTime = 0;
this._previousPVSCTime = 0;
this._previousBizChangedTime = 0;
}
OOP.Inherit( CurrentDataProcessorEx, BaseDataProcessor );
CurrentDataProcessorEx.DefaultPageWidth = 0;
CurrentDataProcessorEx.DefaultPageHeight = 0;
CurrentDataProcessorEx.PageRegExp =
{
"Audio"         :/^[^:]+\.xml$/i,
"PanoVideo"     :/^[^:]+\.xml$/i,
"QCIFVideo"     :/^[^:]+\.xml$/i,
"Modi"          :/^[^:]+\.(png|jpg|gif|bmp)$/i,
"Web"           :/^[^:]+\.(png|jpg|gif|bmp)$/i,
"Image"         :/^[^:]+\.(png|jpg|gif|bmp)$/i,
"Ppt"           :/^[^:]+\.(htm|html)$/i,
"MMC"           :/^[^:]+\.(xml|swf)$/i,
"AppSharing"    :/^[^:]+\.xml$/i
};
CurrentDataProcessorEx.AsyncProcListRoot = function( listRoot, nodeProc, finishedDelegate )
{
if ( !listRoot )
{
finishedDelegate();
return;
}
AsyncJS.VisitArray( listRoot.childNodes, 0, listRoot.childNodes.length, nodeProc, finishedDelegate );
}
CurrentDataProcessorEx.prototype.ProcessResult= function( doc )
{
var roots = doc.getElementsByTagName('Presentation');
if ( !roots )
{
return;
}
var root = null;
var i = 0;
while ( i < roots.length )
{
if ( roots[i].nodeType == 1 )
{
root = roots[i];
break;
}
i++;
}
if ( !root )
{
return;
}
this.version = root.getAttribute( "version" );
var rcls = doc.getElementsByTagName( "ResChangeList" );
if ( rcls && rcls.length > 0 )
{
this._ProcessResChangeList( rcls[0] );
}
var pcls = doc.getElementsByTagName( "PageChangeList" );
if ( pcls && pcls.length > 0 )
{
this._ProcessPageCListNode( pcls[0] );
}
setTimeout(
DelegateWithArgs(
this,
CurrentDataProcessorEx.prototype._CallBackProcessInnerPageMessageList,
doc ),
0
);
}
CurrentDataProcessorEx.prototype._ProcessFuncs = function( array, func1, func2 )
{
if ( array && array.length > 0 )
{
CurrentDataProcessorEx.AsyncProcListRoot( array[0],
func1,
func2 );
}
else
{
func2();
}
}
CurrentDataProcessorEx.prototype._CallBackProcessInnerPageMessageList = function( doc )
{
this._ProcessFuncs( doc.getElementsByTagName( "InnerPageMessageList" ),
Delegate( this, this._ProcInnerPageMessageNode ),
DelegateWithArgs( this, this._CallBackPVSCMessageList, doc )
);
}
CurrentDataProcessorEx.prototype._CallBackPVSCMessageList = function( doc )
{
this._ProcessFuncs( doc.getElementsByTagName( "PrimaryVideoSrcMessageList" ),
Delegate( this, this._ProcPVSCNode ),
DelegateWithArgs( this, this._CallBackBizcardChangeMessageList, doc )
);
}
CurrentDataProcessorEx.prototype._CallBackBizcardChangeMessageList = function( doc )
{
this._ProcessFuncs( doc.getElementsByTagName( "BizCardChangedMessageList" ),
Delegate( this, this._ProcBizcardChangedNode ),
DelegateWithArgs( this, this._CallBackProcessQAList, doc )
);
}
CurrentDataProcessorEx.prototype._CallBackProcessQAList = function( doc )
{
this._ProcessFuncs( doc.getElementsByTagName( "QAMessageList" ),
Delegate( this, this._ProcQANode ),
DelegateWithArgs( this, this._ParsingDone, doc )
);
}
CurrentDataProcessorEx.prototype._ParsingDone = function()
{
this.ParsingDone();
}
CurrentDataProcessorEx.prototype._ProcInnerPageMessageNode = function( item )
{
if ( item.nodeType != 1 )
{
return;
}
var time = item.getAttribute( "time" );
if ( !time )
{
return;
}
time = BaseDataProcessor.ParseTimeAttribute( time );
if ( BaseDataProcessor.ParseTimeAttribute.DefaultValueUsed )
{
return;
}
if ( this._previousInnerMsgTim > time )
{
return;
}
this._previousInnerMsgTim = time;
switch( item.nodeName )
{
case "AnimationChanged":
this._ProcessAnimationChangedNode( item, time );
break;
case "PollingChanged":
this._ProcessPollingChangedNode( item, time );
break;
case "AnnotationChanged":
this._ProcessAnnotationChangedNode( item, time );
break;
case "MMCChanged":
this._ProcessMMCChangedNode( item, time );
break;
case "EffectiveRectChanged":
this._ProcessEffectiveRectChangedNode( item, time );
break;
case "TextChanged":
this._ProcessTextChangedNode( item, time );
break;
default:
Trace.WriteLine( "unknown inner page message " + item.nodeName );
break;
}
}
CurrentDataProcessorEx.prototype._ProcPVSCNode = function( item )
{
if ( item.nodeType != 1 )
{
return;
}
var time = item.getAttribute( "time" );
if ( !time )
{
return;
}
time = BaseDataProcessor.ParseTimeAttribute( time );
if ( BaseDataProcessor.ParseTimeAttribute.DefaultValueUsed )
{
return;
}
var tPvscMsg = new Object();
tPvscMsg.time = time;
tPvscMsg.attendee = item.getAttribute( "attendee" );
if ( this._previousPVSCTime <= tPvscMsg.time )
{
this.pvscList.push( tPvscMsg );
this._previousPVSCTime = tPvscMsg.time;
}
}
CurrentDataProcessorEx.prototype._ProcBizcardChangedNode = function( item )
{
if ( item.nodeType != 1 )
{
return;
}
var time = item.getAttribute( "time" );
var action = item.getAttribute( "action" );
if ( !time )
{
return;
}
if ( (action != "show") && (action != "hide") )
{
return;
}
time = BaseDataProcessor.ParseTimeAttribute( time );
if ( BaseDataProcessor.ParseTimeAttribute.DefaultValueUsed )
{
return;
}
var tbzcMsg = new Object();
tbzcMsg.time = time;
tbzcMsg.action = action;
if ( this._previousBizChangedTime <= tbzcMsg.time )
{
this.bzcList.push( tbzcMsg );
this._previousBizChangedTime = tbzcMsg.time;
}
}
CurrentDataProcessorEx.prototype._ProcQANode = function( item )
{
if ( item.nodeType != 1 )
{
return;
}
var time = item.getAttribute( "time" );
if ( !time )
{
return;
}
time = BaseDataProcessor.ParseTimeAttribute( time );
if ( BaseDataProcessor.ParseTimeAttribute.DefaultValueUsed )
{
return;
}
var tqa = new Object();
tqa.Question = null;
tqa.Answer = null;
if ( this.previousQATime > time )
{
return;
}
this.previousQATime = time;
var j = 0;
while ( j < item.childNodes.length )
{
switch( item.childNodes[j].nodeName )
{
case "Question":
tqa.Question = XMLDomDataBuilder.GetTextValueFromSingleNode( item.childNodes[j] )
break;
case "Answer":
tqa.Answer = XMLDomDataBuilder.GetTextValueFromSingleNode( item.childNodes[j] )
break;
default:
}
j++;
}
tqa.time = time;
this.qaList.push( tqa );
}
CurrentDataProcessorEx.prototype._ProcessResChangeList = function( rcls )
{
if ( !rcls )
{
return;
}
var addreslist = rcls.childNodes;
for ( var i = 0; i < addreslist.length; i++ )
{
if ( addreslist[i].nodeType != 1 )
{
continue;
}
var iIndex = 0;
var bFound = false;
while( iIndex < addreslist[i].childNodes.length )
{
if ( addreslist[i].childNodes[iIndex].nodeType == 1 )
{
bFound = true;
break;
}
iIndex++;
}
if ( !bFound )
{
continue;
}
if ( addreslist[i].childNodes[iIndex].childNodes.length == 0 )
{
continue;
}
var resNode = XMLUtils.GetFirstElementChild( addreslist[i] );
if ( !resNode )
{
continue;
}
for ( var j = 0; j < resNode.childNodes.length; j++ )
{
var item = resNode.childNodes[j];
if ( (item.nodeType == 1) && (item.nodeName == "Page") )
{
this._ProcessCurrentPageNode( item );
}
}
}
}
CurrentDataProcessorEx.prototype._ProcessAnimationChangedNode = function( item, time )
{
var tAnim = new Object();
tAnim.time = time;
tAnim.currentStep = parseInt( item.getAttribute( "currentStep" ), 10 );
if ( isNaN( tAnim.currentStep ) || tAnim.currentStep < 0 )
{
return;
}
this._HookNodeWithPage( tAnim, item.getAttribute("page"), "AnimationChanged" );
}
CurrentDataProcessorEx.prototype._GetPollChoice = function( choiceNode )
{
var tcho        = new Object();
tcho.value      = choiceNode.nodeValue;
if ( tcho.value == null )
{
tcho.value = "";
}
tcho.color      = choiceNode.getAttribute( "color" );
tcho.chooseCnt  = parseInt( choiceNode.getAttribute( "chooseCnt" ), 10 );
if ( isNaN(tcho.chooseCnt) )
{
tcho.chooseCnt = 0;
}
return tcho;
}
CurrentDataProcessorEx.prototype._ProcessPollingChangedNode = function( item, time )
{
function GetChoiceNode( node )
{
var tchoice = new Object();
tchoice.chooseCnt = parseInt( node.getAttribute( "chooseCnt" ) );
if ( isNaN( tchoice.chooseCnt ) )
{
tchoice.chooseCnt = 0;
}
tchoice.color = node.getAttribute( "color" );
tchoice.value = XMLDomDataBuilder.GetTextValueFromSingleNode( node )
return tchoice;
}
var tPoll = new Object();
tPoll.time = time;
tPoll.action = item.getAttribute( "action" );
tPoll.action = tPoll.action.toLowerCase();
tPoll.Choice = [];
var i = 0;
var bTooManyChoices = false;
while( i < item.childNodes.length )
{
if ( item.childNodes[i].nodeType != 1 )
{
i++;
continue;
}
if ( item.childNodes[i].nodeName == "Question" )
{
tPoll.Question = XMLDomDataBuilder.GetTextValueFromSingleNode( item.childNodes[i] )
}
if ( ( item.childNodes[i].nodeName == "Choice" ) && ( !bTooManyChoices ) )
{
tPoll.Choice.push( GetChoiceNode( item.childNodes[i] ) );
}
if ( ( tPoll.Choice.length > MeetingSettings.MaxPollChoiceCount ) && (!bTooManyChoices) )
{
tPoll.time = BaseDataProcessor.InvalidTime;
g_ErrorHandling.ShowWarning( E_BADPOLLMESSAGE );
bTooManyChoices = true;
}
i++;
}
this._HookNodeWithPage( tPoll, item.getAttribute( "page" ), "PollingChanged" );
}
CurrentDataProcessorEx.prototype._ProcessAnnotationChangedNode = function( item, time )
{
function _GetFontAttribute( tAnno, item )
{
tAnno.fontStyle  = item.getAttribute( "fontStyle" );
tAnno.fontWeight  = item.getAttribute( "fontWeight" );
tAnno.fontSize  = item.getAttribute( "fontSize" );
if( tAnno.fontSize )
{
tAnno.fontSize = tAnno.fontSize * 4 / 3;
}
tAnno.fontFamily  = item.getAttribute( "fontFamily" );
tAnno.underline  = item.getAttribute( "underline" );
}
var tAnno       = new Object();
tAnno.time      = time;
tAnno.color     = item.getAttribute( "color" );
if ( tAnno.color == null || !tAnno.color.match( /^[0-9a-fA-F]{6}$/ ) )
{
tAnno.color = "#000000";
}
else
{
tAnno.color = "#" + tAnno.color;
}
tAnno.elementId = "a" + item.getAttribute( "elementId" );
tAnno.keyPoints = item.getAttribute( "keyPoints" );
if ( !tAnno.keyPoints )
{
tAnno.keyPoints = "";
}
tAnno.action    = item.getAttribute( "action" );
tAnno.type      = item.getAttribute( "type" );
tAnno.dx        = item.getAttribute( "dx" );
tAnno.dy        = item.getAttribute( "dy" );
tAnno.text      = "";
var i = 0;
while( i < item.childNodes.length )
{
if ( item.childNodes[i].nodeName == "Text" )
{
tAnno.text = XMLDomDataBuilder.GetTextValueFromSingleNode( item.childNodes[i] )
_GetFontAttribute( tAnno, item.childNodes[i] );
break;
}
i++;
}
this._HookNodeWithPage( tAnno, item.getAttribute( "page" ), "AnnotationChanged" );
}
CurrentDataProcessorEx.prototype._ProcessMMCChangedNode = function( item, time )
{
var tMMC = new Object();
tMMC.eventName = "MMCChanged";
tMMC.time = time;
tMMC.action = item.getAttribute( "action" );
if ( tMMC.action )
{
tMMC.action = tMMC.action.toLowerCase();
}
tMMC.position = item.getAttribute( "position" );
this._HookNodeWithPage( tMMC, item.getAttribute( "page" ), "MMCChanged" );
}
CurrentDataProcessorEx.prototype._ProcessEffectiveRectChangedNode = function( item, time )
{
function _FormatFloat( flt, acceptNeg )
{
if ( isNaN( flt ) )
{
flt = 0;
}
else if ( (flt < 0) && (!acceptNeg) )
{
flt = 0;
}
return flt;
}
for ( var j = 0; j < item.childNodes.length; j++ )
{
var rectItem = item.childNodes[j];
if ( (rectItem.nodeType == 1) && (rectItem.nodeName == "Rect") )
{
var tMMC = new Object();
tMMC.time = time;
tMMC.eventName = "RectChanged";
tMMC.left = _FormatFloat( parseFloat( rectItem.getAttribute( "left" ) ), true );
tMMC.top = _FormatFloat( parseFloat( rectItem.getAttribute( "top" ) ), true );
tMMC.width = _FormatFloat( parseFloat( rectItem.getAttribute( "width" ) ), false );
tMMC.height = _FormatFloat( parseFloat( rectItem.getAttribute( "height" ) ), false );
this._HookNodeWithPage( tMMC, item.getAttribute( "page" ), "MMCChanged" );
break;
}
}
}
CurrentDataProcessorEx.prototype._ProcessTextChangedNode = function( item, time )
{
var tTextMsg = new Object();
tTextMsg.time = time;
tTextMsg.action = item.getAttribute( "action" );
if ( tTextMsg.action )
{
tTextMsg.action = tTextMsg.action.toLowerCase();
}
tTextMsg.beginIndex = parseInt( item.getAttribute( "beginIndex" ) );
tTextMsg.endIndex = parseInt( item.getAttribute( "endIndex" ) );
tTextMsg.text = "";
var i = 0;
while( i < item.childNodes.length )
{
if ( item.childNodes[i].nodeName == "Text" )
{
tTextMsg.text = XMLDomDataBuilder.GetTextValueFromSingleNode( item.childNodes[i] )
break;
}
i++;
}
this._HookNodeWithPage( tTextMsg, item.getAttribute( "page" ), "TextChanged" );
}
CurrentDataProcessorEx.prototype._ProcessPageCListNode = function( pclist )
{
var pageChange = new Object();
pageChange.Audio = [];
pageChange.PanoVideo = [];
pageChange.QCIFVideo = [];
pageChange.Content = [];
for ( var i = 0; i < pclist.childNodes.length; i ++ )
{
if ( pclist.childNodes[i].nodeType != 1 )
{
continue;
}
var seqName = pclist.childNodes[i].nodeName;
if ( !(seqName in pageChange) )
{
continue;
}
var previousTime = -1;
for ( var j = 0; j < pclist.childNodes[i].childNodes.length; j++ )
{
var item = pclist.childNodes[i].childNodes[j];
if ( item.nodeType != 1 )
{
continue;
}
var time = item.getAttribute( "time" );
if ( !time )
{
continue;
}
time = BaseDataProcessor.ParseTimeAttribute( time );
if ( BaseDataProcessor.ParseTimeAttribute.DefaultValueUsed )
{
continue;
}
if ( previousTime > time )
{
continue;
}
else
{
previousTime = time;
}
var tpc = new Object();
tpc.time = time;
tpc.Page = this.pageList[ item.getAttribute( "page" ) ];
if ( tpc.Page == null )
{
tpc.Page = this._emptyPage;
}
pageChange[seqName].push( tpc );
}
}
this._AddToStart( pageChange.Content, this._startEvent );
if( NavigatorInfo.IsIE() && (pageChange.QCIFVideo.length > 0 || pageChange.PanoVideo.length > 0) )
{
var wvc1CodecCheckEvent = this._CreateWvc1CodecCheckEvent();
this._AddToStart( pageChange.QCIFVideo, wvc1CodecCheckEvent );
MoveTheFirstLittle( pageChange.PanoVideo );
}
this.pageChangeList = pageChange;
}
CurrentDataProcessorEx.prototype._CreateWvc1CodecCheckEvent = function()
{
var tpage = new Object();
tpage.id        = "QCIF_CODEC";
tpage.pageType  = "QCIFVideo";
tpage.size      = "10000000";
tpage.res       = "";
tpage.format    = "";
tpage.url       = GetPageRoot()+"wvc1.wmv";
tpage.webhref   = GetPageRoot()+"wvc1.wmv";
tpage.entry     = "";
tpage.width     = 160;
tpage.height    = 120;
tpage._notExist = false;
tpage.isCodecChecker = true;
var checkEvent = new Object();
checkEvent.time = 0;
checkEvent.Page = tpage;
return checkEvent;
}
CurrentDataProcessorEx.prototype._CheckValidPageNode = function( pageNode )
{
if ( !pageNode.getAttribute( "id" ) || !pageNode.getAttribute( "pageType" ) )
{
g_ErrorHandling.ShowCustomWarning( "Bad page node" );
return false;
}
var pageType = pageNode.getAttribute( "pageType" );
if (! ( pageType in MeetingSettings.PageType) )
{
g_ErrorHandling.ShowCustomWarning( "Pagetype(" + pageType + ") is not valid" );
return false;
}
return true;
}
CurrentDataProcessorEx.NoURINeeded = 0;
CurrentDataProcessorEx.InvalidURI = 1;
CurrentDataProcessorEx.ValidURI = 2;
CurrentDataProcessorEx.prototype._CheckPageURI = function( pageNode )
{
var pageType = pageNode.getAttribute( "pageType" );
var fmt = pageNode.getAttribute( "format" );
if ( pageType == MeetingSettings.PageType.Audio
|| pageType == MeetingSettings.PageType.PanoVideo
|| pageType == MeetingSettings.PageType.QCIFVideo
|| pageType == MeetingSettings.PageType.Modi
|| pageType == MeetingSettings.PageType.Image
|| pageType == MeetingSettings.PageType.Ppt
|| pageType == MeetingSettings.PageType.MMC )
{
var url = pageNode.getAttribute( "url" );
if ( !url )
{
return CurrentDataProcessorEx.InvalidURI;
}
if ( !url.match( CurrentDataProcessorEx.PageRegExp[ pageType ] ) )
{
return CurrentDataProcessorEx.InvalidURI;
}
return CurrentDataProcessorEx.ValidURI;
}
else if( pageType == MeetingSettings.PageType.AppSharing
|| pageType == MeetingSettings.PageType.Web )
{
var url = pageNode.getAttribute( "url" );
if ( !url )
{
return CurrentDataProcessorEx.NoURINeeded;
}
if ( !url.match( CurrentDataProcessorEx.PageRegExp[ pageType ] ) )
{
return CurrentDataProcessorEx.InvalidURI;
}
return CurrentDataProcessorEx.ValidURI;
}
else
{
return CurrentDataProcessorEx.NoURINeeded;
}
}
CurrentDataProcessorEx.prototype._CheckAVMMCContentURL = function( tpage )
{
var pageType = tpage.pageType;
if ( pageType == MeetingSettings.PageType.Audio
|| pageType == MeetingSettings.PageType.PanoVideo
|| pageType == MeetingSettings.PageType.QCIFVideo )
{
if ( !tpage.url || !tpage.url.match( /.xml$/i ) )
{
return false;
}
}
if ( pageType == MeetingSettings.PageType.MMC )
{
if ( !tpage.format )
{
return false;
}
else if ( tpage.format.toLowerCase() == "av" )
{
if ( !tpage.url || !tpage.url.match( /.xml$/i ) )
{
return false;
}
}
else if ( tpage.format.toLowerCase() == "flash" )
{
if ( !tpage.url || !tpage.url.match( /.swf$/i ) )
{
return false;
}
}
else
{
return false;
}
}
return true;
}
CurrentDataProcessorEx.prototype._ProcessCurrentPageNode = function( pageNode )
{
if ( !this._CheckValidPageNode( pageNode ) )
{
return;
}
var checkResult = this._CheckPageURI( pageNode );
var uri = null;
var bNotExist = false;
switch( checkResult )
{
case CurrentDataProcessorEx.NoURINeeded:
break;
case CurrentDataProcessorEx.InvalidURI:
g_ErrorHandling.ShowWarning( E_PAGENOTEXIST );
bNotExist = true;
break;
case CurrentDataProcessorEx.ValidURI:
uri = BaseDataProcessor.GetFullPath( pageNode.getAttribute( "url" ) );
break;
default:
}
var pageType = pageNode.getAttribute( "pageType" );
var tpage = new Object();
tpage.id        = pageNode.getAttribute( "id" );
tpage.pageType  = pageType;
tpage.size      = pageNode.getAttribute( "size" );
tpage.res       = pageNode.getAttribute( "res" );
tpage.format    = pageNode.getAttribute( "format" );
tpage.url       = uri;
tpage.webhref   = pageNode.getAttribute( "webhref" );
tpage.entry     = pageNode.getAttribute( "entry" );
tpage.width     = parseFloat( pageNode.getAttribute( "width" ) );
tpage.height    = parseFloat( pageNode.getAttribute( "height" ) );
tpage._notExist = bNotExist;
tpage.biggestInnerMsgTime = -1;
tpage.Related   = [];
var i = 0;
while ( i < pageNode.childNodes.length )
{
var item = pageNode.childNodes[i];
if ( item.nodeName == "Related" )
{
var relatedURI = BaseDataProcessor.GetFullPath( item.getAttribute( "url" ) );
var relatedSize = item.getAttribute( "size" );
if ( !relatedURI )
{
i++;
continue;
}
var tRelated = new Object();
tRelated.url = relatedURI;
tRelated.size = parseFloat( relatedSize );
if ( isNaN( tRelated.size ) || ( tRelated.size <= 0 ) )
{
tRelated.size = BaseDataProcessor.DefaultSize;
}
tpage.Related.push( tRelated );
}
i++;
}
if( isNaN( tpage.width ) )
{
tpage.width = CurrentDataProcessorEx.DefaultPageWidth;
}
if( isNaN( tpage.height ) )
{
tpage.height = CurrentDataProcessorEx.DefaultPageHeight;
}
if ( this._CheckAVMMCContentURL( tpage ) )
{
this.pageList[ pageNode.getAttribute( "id" ) ] = tpage;
}
}
CurrentDataProcessorEx.prototype.GetBiggestTime = function()
{
return this._biggestTime;
}
CurrentDataProcessorEx.prototype._HookNodeWithPage = function( data, pageId, name )
{
if ( pageId == null )
{
return;
}
if ( data == null )
{
return;
}
var thePage = this.pageList[ pageId ];
if ( !thePage )
{
return;
}
if ( !thePage[ name ] )
{
thePage[ name ] = new Array();
}
if ( name == "AnimationChanged"
|| name == "AnnotationChanged"
|| name == "TextChanged"
|| name == "PollingChanged"
|| name == "MMCChanged"
)
{
var newTime = BaseDataProcessor.ParseTimeAttribute( data.time, BaseDataProcessor.InvalidTime );
if ( !BaseDataProcessor.ParseTimeAttribute.DefaultValueUsed && newTime != BaseDataProcessor.InvalidTime && thePage.biggestInnerMsgTime <= newTime )
{
thePage[ name ].push( data );
thePage.biggestInnerMsgTime = newTime;
}
}
else
{
thePage[ name ].push( data );
}
}
Trace.Wrap( "BaseDataProcessor" );
function DataManager()
{
this._currentProcessor = new CurrentDataProcessorEx();
this._indexProcessor = new IndexDataProcessor();
this._meetingInfoProcessor = new MeetingInfoDataProcessor();
this._optDataProcessor = new OptDataProcessor();
this._biggestTime = 0;
this._localeInfoLoaded = false;
this._meetingInfoLoaded = false;
this._currentLoaded = false;
this._indexLoaded = false;
this._optDataLoaded = false;
this._attendeeList = new Array();
this.PageList = new Object();
this.LocaleInfoLoadedEvent = new Event();
this.MeetingInfoLoadedEvent = new Event();
this.DataParsedEvent = new Event();
this.PageListLoadedEvent = new Event();
this.DurationUpdatedEvent = new Event();
}
DataManager.BadDurationOffset = 600;
DataManager.prototype.Initialize = function()
{
}
DataManager.prototype.Uninitialize = function()
{
}
DataManager.prototype.LoadLocaleInfo = function()
{
if ( this._localeInfoLoaded )
{
}
var builder = new XMLDataBuilder(
DataSetting.XMLParList.LocaleInfo.URI,
false );
builder.ResultGotEvent.Add(
Delegate( this, DataManager.prototype._ProcessLocaleInfoResult )
);
builder.ErrorEvent.Add(
DelegateWithArgs( this, DataManager.prototype._OnXMLBuilderError )
);
builder.Execute();
this._localeInfoLoaded = true;
}
DataManager.prototype.LoadMeetingInfo = function()
{
if ( this._meetingInfoLoaded )
{
}
var builder = new XMLDataBuilder(
DataSetting.XMLParList.MeetingInfo.URI,
false
);
builder.ResultGotEvent.Add(
DelegateWithArgs( this, DataManager.prototype._ProcessMeetingInfoResult )
);
builder.ErrorEvent.Add(
DelegateWithArgs( this, DataManager.prototype._OnXMLBuilderError )
);
builder.Execute();
}
DataManager.prototype.LoadCurrentAndIndex = function()
{
this.LoadCurrent();
this.LoadIndex();
}
DataManager.prototype.LoadCurrent = function()
{
var builder = new DirectXMLDataBuilder(
DataSetting.XMLParList.Current.URI,
false
);
builder.ItemVisitedEvent.Add(
Delegate( this, DataManager.prototype._ProcessCurrentNode )
);
builder.ResultGotEvent.Add(
DelegateWithArgs( this, DataManager.prototype._ProcessCurrentResult )
);
builder.ErrorEvent.Add(
DelegateWithArgs( this, DataManager.prototype._OnXMLBuilderError )
);
builder.Execute();
}
DataManager.prototype.LoadIndex = function()
{
if ( this._indexLoaded )
{
return;
}
var builder = new XMLDataBuilder(
DataSetting.XMLParList.Index.URI,
false
);
builder.ItemVisitedEvent.Add(
Delegate( this, DataManager.prototype._ProcessIndexNode )
);
builder.ResultGotEvent.Add(
DelegateWithArgs( this, DataManager.prototype._IndexDataLoadedHandler )
);
builder.ErrorEvent.Add(
DelegateWithArgs( this, DataManager.prototype._IndexErrorHandler )
);
builder.Execute();
}
DataManager.prototype._IndexErrorHandler = function( e )
{
this._IndexDataLoadedHandler( null );
}
DataManager.prototype._IndexDataLoadedHandler = function( data )
{
if ( this._IndexDataLoadedHandlerCalled )
{
return;
}
this._IndexDataLoadedHandlerCalled = true;
this._IndexLoadedHandler( data );
this._GeneralDataLoadedHandler();
}
DataManager.prototype._LoadOptData = function()
{
if ( this._optDataLoaded )
{
return;
}
var builder = new XMLDataBuilder(
DataSetting.XMLParList.OptData.URI,
false
);
builder.ItemVisitedEvent.Add(
Delegate( this, DataManager.prototype._ProcessOptNode )
);
builder.ResultGotEvent.Add(
DelegateWithArgs( this, DataManager.prototype._ProcessOptData )
);
builder.ErrorEvent.Add(
DelegateWithArgs( this, DataManager.prototype._OptFileErrorHandler )
);
builder.Execute();
}
DataManager.prototype._IndexLoadedHandler = function ( data )
{
this._indexLoaded = true;
this._indexProcessor.ProcessResult( data );
if ( data == null )
{
g_ErrorHandling.ShowWarning( E_INDEXNOTPROVIDED );
}
}
DataManager.prototype._CurrentLoadedHandler = function ( doc )
{
if ( doc == null )
{
g_ErrorHandling.ShowError( E_CURRENTNOTPROVIDED );
}
this._currentProcessor.ParsingDone.Add( Delegate( this, this._LoadOptData ) );
this._currentProcessor.ProcessResult( doc );
}
DataManager.prototype._OnXMLBuilderError = function( e )
{
switch( typeof e )
{
case "string":
g_ErrorHandling.ShowCustomError( e );
break;
case "object":
g_ErrorHandling.ShowCustomError( e.message );
break;
case "number":
g_ErrorHandling.ShowError( e );
break;
default:
break;
}
}
DataManager.prototype._ProcessLocaleInfoResult = function( data )
{
this.LocaleInfo = data;
this.LocaleInfoLoadedEvent( data );
}
DataManager.prototype._ProcessMeetingInfoResult = function( data )
{
this._meetingInfoLoaded = true;
this._ProcessMeetingData( data );
this.MeetingInfoLoadedEvent( data );
this._GeneralDataLoadedHandler();
}
DataManager.prototype._ProcessCurrentResult = function( doc )
{
this._currentLoaded = true;
this.PageList = this._currentProcessor.pageList;
this._CurrentLoadedHandler( doc );
this._GeneralDataLoadedHandler();
if ( !this._CheckVersion( this._currentProcessor.version, g_version ) )
{
g_ErrorHandling.ShowCustomWarning(
"The publish engine's version is not the same as the playback engine in current.xml.",
true
);
}
}
DataManager.prototype._CheckVersion = function( dataVersion, engineVersion )
{
if ( !dataVersion || !engineVersion )
{
return false;
}
dataVersion = dataVersion.replace( /\.([^\.]*)$/, "" );
engineVersion = engineVersion.replace( /\.([^\.]*)$/, "" );
return dataVersion == engineVersion;
}
DataManager.prototype._ProcessCurrentNode = function( node )
{
this._currentProcessor.ProcessNode( node );
}
DataManager.prototype._ProcessIndexNode = function( node )
{
this._indexProcessor.ProcessNode( node );
}
DataManager.prototype._GeneralDataLoadedHandler = function()
{
if ( this._currentLoaded && this._indexLoaded && this._optDataLoaded && this._meetingInfoLoaded )
{
if ( DataManager.prototype._GeneralDataLoadedHandler.called )
{
return;
}
DataManager.prototype._GeneralDataLoadedHandler.called = true;
this.DataParsedEvent.PostFire();
var maxbiggest = this._currentProcessor._biggestTime;
if ( maxbiggest < this._indexProcessor._biggestTime )
{
maxbiggest = this._indexProcessor._biggestTime;
}
var durBiggest = maxbiggest + DataManager.BadDurationOffset;
var duration = this._meetingInfo.duration;
if (( this._meetingInfoProcessor._badDuration ) || ( duration < maxbiggest ))
{
this._meetingInfo.duration = durBiggest;
}
this.DurationUpdatedEvent( this._meetingInfo.duration );
}
}
DataManager.prototype.GetLocaleInfo = function()
{
return this[ DataSetting.XMLParList.LocaleInfo.DataName ];
}
DataManager.prototype.GetMeetingInfo = function()
{
return this._meetingInfo;
}
DataManager.prototype.GetPageChangeEvents = function()
{
return this._currentProcessor.pageChangeList;
}
DataManager.prototype.GetContentIndexData = function()
{
return this._indexProcessor._contentIndexs;
}
DataManager.prototype.GetSpeakerIndexData = function()
{
return this._indexProcessor._speakerIndexs;
}
DataManager.prototype.GetAttendeeList = function()
{
return this._attendeeList;
}
DataManager.prototype._ProcessMeetingData = function( data )
{
this._meetingInfoProcessor.ProcessResult( data );
this._meetingInfo = this._meetingInfoProcessor.meetingInfo;
this._attendeeList = this._meetingInfoProcessor.attendeeList;
this._SetMeetingInfoToIndexProcessor( this._meetingInfo );
}
DataManager.prototype._SetMeetingInfoToIndexProcessor = function( meetingInfo )
{
this._indexProcessor.SetDummyTitle( meetingInfo.subject );
}
DataManager.prototype._ProcessOptNode = function( node )
{
this._optDataProcessor.ProcessNode( node );
}
DataManager.prototype._ProcessOptData = function( data )
{
this._optDataLoaded = true;
if ( data )
{
this._optDataProcessor.ProcessResult( data );
this._MergeOptData();
}
this._GeneralDataLoadedHandler();
}
DataManager.prototype._OptFileErrorHandler = function( )
{
if ( this._optXMLError )
{
return;
}
this._optXMLError = true;
this._optDataLoaded = true;
this._ProcessOptData( null );
}
DataManager.prototype._MergeOptData = function()
{
for ( var i = 0; i < this._optDataProcessor.textOpts.length; i++ )
{
var item = this._optDataProcessor.textOpts[i];
var page = this.PageList[ item.page ];
if ( !page )
{
continue;
}
if ( !page.snapShots )
{
page.snapShots = [];
}
page.snapShots.push( item );
}
}
DataManager.prototype.GetQAData = function()
{
return this._currentProcessor.qaList;
}
DataManager.prototype.GetPrimVideoSrcChangedData = function()
{
return this._currentProcessor.pvscList;
}
DataManager.prototype.GetBizcardChangedData = function()
{
return this._currentProcessor.bzcList;
}
Trace.Wrap("DataManager");
function ItemDownloader()
{
this._contentList = new Array();
this._pageList = new Object();
this._pageCount = 0;
this._loadedPageCount = 0;
this._totalFileSize = 0;
this._bandwidth = ItemDownloader.InitialBandWidth;
this._quickJobInterval = 0;
this._slowBufferBitrate = 0;
this._bufferType = ItemDownloader.QuickBuffering;
this._currentContent = 0;
this._quickBufferEndTime = 0;
this._quickBufferStartTime = 0;
this._interrupt = false;
this._requiredContent = 0;
this._needNotifyBufferReady = false;
this._timerHandler = null;
this._timerCounter = 0;
this._isLoading = false;
this.BufferReadyEvent = new Event();
this.BandwidthUpdatedEvent = new Event();
this._JobLoadedEvent = new Event();
this._JobLoadedEvent.Add( Delegate( this, this._JobLoadedHandler ) );
}
ItemDownloader.Threshold = 20000;
ItemDownloader.Coef = 2.0;
ItemDownloader.InitialBandWidth = 7;
ItemDownloader.Pending = -1;
ItemDownloader.Loaded = 0;
ItemDownloader.Timeout = 1;
ItemDownloader.NotExist = 2;
ItemDownloader.DefaultEstTimeForInvalid = 10000;
ItemDownloader.QuickBufferTime = 60;
ItemDownloader.QuickBuffering = 0;
ItemDownloader.SlowBuffering = 1;
ItemDownloader.Job = function( item )
{
this.item = item;
this.startTime = 0;
this.endTime = 0;
this.loaded = ItemDownloader.Pending;
this.timerHandle = null;
}
ItemDownloader.Content = function( pageChange, page )
{
this.time = pageChange.time;
this.page = page;
}
ItemDownloader.Page = function( page )
{
this.pageId = page.id;
this.jobList = new Array();
this.currentJob = 0;
this.loaded = ItemDownloader.Pending;
this.totalPageSize = 0;
this.PushJob( page );
if ( page.Related )
{
for( var i = 0; i < page.Related.length; i++ )
{
this.PushJob( page.Related[i] );
}
}
if (this.jobList.length == 0)
{
this.loaded = ItemDownloader.Loaded;
}
}
ItemDownloader.Page.prototype.PushJob = function( page )
{
if ( !page || !page.url )
{
return;
}
this.jobList.push( new ItemDownloader.Job( page ) );
this.totalPageSize += parseFloat(page.size);
}
ItemDownloader.prototype.PushContent = function( pageChange )
{
if ( !pageChange.Page || !pageChange.Page.url )
{
return;
}
if (!this._pageList[pageChange.Page.id])
{
this._pageList[pageChange.Page.id] = new ItemDownloader.Page(pageChange.Page);
this._pageCount++;
this._totalFileSize += this._pageList[pageChange.Page.id].totalPageSize;
}
this._contentList.push( new ItemDownloader.Content( pageChange, this._pageList[pageChange.Page.id] ) );
this._slowBufferBitrate = this._totalFileSize / ( ( this._contentList[this._contentList.length-1].time -this._contentList[0].time )  / 2 );
}
ItemDownloader.prototype._StartLoadPage = function(timerNo)
{
if (timerNo != this._timerCounter)
return;
this._timerHandler = null;
if (this._loadedPageCount == this._pageCount)
{
return;
}
this._isLoading = true;
if(this._interrupt == true)
{
this._currentContent = this._requiredContent;
if (this._bufferType == ItemDownloader.QuickBuffering)
{
this._quickBufferStartTime = this._contentList[this._currentContent].time;
this._quickBufferEndTime = this._quickBufferStartTime + ItemDownloader.QuickBufferTime;
}
this._interrupt = false;
}
var length = this._contentList.length;
while(this._contentList[this._currentContent].page.loaded != ItemDownloader.Pending)
{
this._currentContent = (this._currentContent + 1) % length;
}
if ((this._bufferType == ItemDownloader.QuickBuffering)
&& ((this._contentList[this._currentContent].time > this._quickBufferEndTime) || (this._contentList[this._currentContent].time < this._quickBufferStartTime)))
{
this._bufferType = ItemDownloader.SlowBuffering;
this._quickBufferStartTime = 0;
this._quickBufferEndTime = 0;
if (this._needNotifyBufferReady)
{
this.BufferReadyEvent();
this._needNotifyBufferReady = false;
}
}
var page = this._contentList[this._currentContent].page;
var job = page.jobList[page.currentJob];
job.startTime = new Date();
var estimateTime = ItemDownloader.DefaultEstTimeForInvalid;
var size = job.item.size;
if ( size != null )
{
var bw = 1000;
if ( this._bandWidth > bw )
{
bw = this._bandWidth;
}
estimateTime = ItemDownloader.Coef * size / bw * 1000;
if ( estimateTime > ItemDownloader.Threshold )
{
estimateTime = ItemDownloader.Threshold;
}
}
var xmlhttp = this.DownloadItem( job );
if ( job.loaded == ItemDownloader.Pending )
{
job.timerHandle = setTimeout(
DelegateWithArgs( this, ItemDownloader.prototype._JobTimeout, xmlhttp, job ),
estimateTime
);
}
}
ItemDownloader.prototype.DownloadItem = function( job )
{
var xmlhttp = CreateIEXMLHttp();
if ( !xmlhttp )
{
xmlhttp = CreateNonIEXMLHttp();
}
if ( xmlhttp )
{
xmlhttp.onreadystatechange = DelegateWithArgs(
this,
ItemDownloader.prototype._ReadyStateChange,
xmlhttp);
try
{
xmlhttp.open("get", job.item.url, true );
xmlhttp.send( null );
}
catch( e )
{
job.item._notExist = true;
this._DownItemException( xmlhttp );
}
}
else
{
}
return xmlhttp;
}
ItemDownloader.prototype._UpdateBandWidth = function( job )
{
var timeused = job.endTime - job.startTime;
if ( timeused < 10 )
{
timeused = 10;
}
var bwForJob = job.item.size / timeused;
this._bandwidth = ( this._bandwidth * this._jobLoaded + bwForJob )
/ (this._jobLoaded + 1);
this.BandwidthUpdatedEvent( this._bandwidth );
}
ItemDownloader.prototype._JobLoadedHandler = function()
{
var page = this._contentList[this._currentContent].page;
var job = page.jobList[page.currentJob];
page.currentJob++;
if (page.currentJob >= page.jobList.length)
{
page.loaded = ItemDownloader.Loaded;
this._loadedPageCount++;
}
this._isLoading = false;
var jobInterval = this._quickJobInterval;
if (this._bufferType == ItemDownloader.SlowBuffering)
{
jobInterval = 1000 * parseFloat(job.item.size) / this._slowBufferBitrate - (job.endTime - job.startTime);
if (jobInterval < 0)
jobInterval = 0;
}
if (!this._timerHandler)
{
this._timerCounter++;
this._timerHandler = setTimeout(
DelegateWithArgs( this, ItemDownloader.prototype._StartLoadPage, this._timerCounter ),
jobInterval );
}
}
ItemDownloader.prototype._ItemLoaded = function( xmlhttp, result )
{
var page = this._contentList[this._currentContent].page;
var job = page.jobList[page.currentJob];
job.loaded = result;
job.endTime = new Date();
clearTimeout( job.timerHandle );
job.timerHandle = null;
this._JobLoadedEvent( result );
if ( xmlhttp )
{
xmlhttp.onreadystatechange = Constant.NULL;
}
}
ItemDownloader.prototype._JobTimeout = function( xmlhttp, job )
{
if ( job.loaded == ItemDownloader.Pending )
{
this._ItemLoaded( xmlhttp, ItemDownloader.Timeout );
}
}
ItemDownloader.prototype._ReadyStateChange = function( xmlhttp )
{
if ( xmlhttp.readyState == 4 )
{
this._ItemLoaded( xmlhttp, ItemDownloader.Loaded );
}
}
ItemDownloader.prototype._DownItemException = function( xmlhttp )
{
this._ItemLoaded( xmlhttp, ItemDownloader.NotExist );
}
ItemDownloader.prototype._SetRequiredContent = function(content, buffertype, needNotifyBufferEvent)
{
this._interrupt = true;
this._requiredContent = content;
this._bufferType = buffertype;
this._needNotifyBufferReady = needNotifyBufferEvent;
}
ItemDownloader.prototype._Interrupt = function()
{
if (!this._isLoading)
{
if (this._timerHandler)
{
clearTimeout( this._timerHandler );
this._timerHandler = null;
}
this._timerCounter++;
this._timerHandler = setTimeout( DelegateWithArgs( this, ItemDownloader.prototype._StartLoadPage, this._timerCounter ), 0 );
}
}
ItemDownloader.prototype.Start = function()
{
if ( this._contentList.length > 0 )
{
this._currentContent = 0;
this._quickBufferStartTime = this._contentList[this._currentContent].time;
this._quickBufferEndTime = this._contentList[this._currentContent].time + ItemDownloader.QuickBufferTime;
this._bufferType = ItemDownloader.QuickBuffering;
this._needNotifyBufferReady = false;
this._timerCounter++;
this._timerHandler = setTimeout( DelegateWithArgs( this, ItemDownloader.prototype._StartLoadPage, this._timerCounter ), 0 );
}
}
ItemDownloader.prototype.Seek = function( time )
{
if (this._loadedPageCount == this._pageCount)
return;
var i = 0;
for (i = 0; i < this._contentList.length; i++)
{
if (((this._contentList[i].time <= time) && ((i+1 >= this._contentList.length) || ((i+1 < this._contentList.length) && (this._contentList[i+1].time > time))))
|| (this._contentList[i].time > time))
{
break;
}
}
if (i == this._contentList.length)
{
return;
}
if (this._contentList[i].page.loaded == ItemDownloader.Pending)
{
this._SetRequiredContent(i, ItemDownloader.QuickBuffering, false);
this._Interrupt();
}
else
{
this._SetRequiredContent(i, this._bufferType, false);
}
}
ItemDownloader.prototype.IsPageBufferingReady = function( time, pageId )
{
if (this._loadedPageCount == this._pageCount)
return true;
var i = 0;
var loaded = false;
for (i = 0; i < this._contentList.length; i++)
{
if (this._contentList[i].time == time && this._contentList[i].page.pageId == pageId)
{
if (this._contentList[i].page.loaded == ItemDownloader.Loaded)
{
loaded = true;
}
else
{
loaded = false;
}
break;
}
else if (this._contentList[i].time > time)
{
loaded = true;
break;
}
}
if (i != this._contentList.length)
{
if (!loaded)
{
this._SetRequiredContent(i, ItemDownloader.QuickBuffering, true);
this._Interrupt();
}
else
{
this._SetRequiredContent(i, this._bufferType, false);
}
}
else
{
loaded = true;
}
return loaded;
}
ItemDownloader.prototype.GetPageSize = function( pageId )
{
if (!this._pageList[pageId])
return 0;
else
return this._pageList[pageId].jobList[0].item.size;
}
ItemDownloader.prototype.SetQuickJobInterval = function( interval )
{
this._quickJobInterval = interval;
}
Trace.Wrap("ItemDownloader");
function PageDownloader()
{
this.ItemDownloader = new ItemDownloader();
this.BandwidthIsLowEvent = new Event();
this.BufferReadyEvent = new Event();
this.ItemDownloader.BandwidthUpdatedEvent.Add(
Delegate( this, PageDownloader.prototype._BandwidthUpdatedHandler )
);
this.ItemDownloader.BufferReadyEvent.Add( this.BufferReadyEvent );
}
PageDownloader.standardBandwidth = 16;
PageDownloader.prototype.PushPage = function( page )
{
this.ItemDownloader.PushContent( page );
}
PageDownloader.prototype.Start = function()
{
this.ItemDownloader.Start();
}
PageDownloader.prototype.Seek = function( time )
{
this.ItemDownloader.Seek( time );
}
PageDownloader.prototype.IsPageBufferingReady = function( time, pageId )
{
return this.ItemDownloader.IsPageBufferingReady( time, pageId );
}
PageDownloader.prototype.GetPageSize = function( pageId )
{
return this.ItemDownloader.GetPageSize( pageId );
}
PageDownloader.prototype._BandwidthUpdatedHandler = function( bandwidth )
{
if( bandwidth < PageDownloader.standardBandwidth )
{
this.BandwidthIsLowEvent( true );
}
else
{
this.BandwidthIsLowEvent( false );
}
}
Trace.Wrap("PageDownloader");
function PageListParser()
{
this.hasWMV = false;
this.hasPPT = false;
this.hasFlash = false;
}
PageListParser.prototype.Execute = function( pclist )
{
this.hasWMV = false;
this.hasPPT = false;
this.hasFlash = false;
if ( !pclist )
{
return;
}
if ( pclist.Audio && pclist.Audio.length > 0 )
{
this.hasWMV = true;
}
else if ( pclist.QCIFVideo && pclist.QCIFVideo.length > 0 )
{
this.hasWMV = true;
}
else if ( pclist.PanoVideo && pclist.PanoVideo.length > 0 )
{
this.hasWMV = true;
}
if ( pclist.Content && pclist.Content.length > 0 )
{
for ( var i = 0; i < pclist.Content.length; i++ )
{
var page = pclist.Content[i].Page;
if ( !page ) continue;
if ( !page.pageType ) continue;
if ( page.pageType.toLowerCase() == "mmc" || page.pageType.toLowerCase() == "appsharing" )
{
var fmt = page.format.toLowerCase();
if ( fmt == "av" )
{
this.hasWMV = true;
}
else if ( fmt == "flash" )
{
this.hasFlash = true;
}
}
else if ( page.pageType == "Ppt" )
{
this.hasPPT = true;
}
}
}
}
function LMPlayback()
{
this._playbackStates = new Object();
this._playbackStates.localeInfoLoaded           = false;
this._playbackStates.meetingInfoLoaded          = false;
this._playbackStates.currentLoaded              = false;
this._playbackStates.indexLoaded                = false;
this._playbackStates.ctrlDataApplied            = false;
this._playbackStates.pagesLoadReady             = false;
this._playbackStates.showDownloadComplete  = false;
this._playbackStates.settingCheckingComplete  = false;
this._playbackStates.preparePlaybackFrameComplete = false;
this._playbackStates.playbackframeReady         = false;
this._playbackStates.continueClicked            = false;
g_ErrorHandling.ErrorOccuredEvent.Add( Delegate( this, this._ErrorOccuredHandler ) );
g_ErrorHandling.WarningOccuredEvent.Add( Delegate( this, this._WarningOccuredHandler ) );
}
LMPlayback.prototype.Run = function()
{
setTimeout( Delegate( this, this._Initialize ), 0 );
}
LMPlayback.prototype._Initialize = function()
{
if ( !this._InitializeCore() )
{
return;
}
if ( NavigatorInfo.IsIE() && !NavigatorInfo.ActiveXSupported() )
{
return;
}
this._LoadLocaleInfo();
}
LMPlayback.prototype._LocaleInfoLoadedHandler = function( succeeded )
{
if( !succeeded )
{
g_ErrorHandling.ShowCustomError( "The locale information can't be loaded. " );
return;
}
this.uiObjects.PrepareAssistantFrames( succeeded );
if ( !this._ParseDataRoot() )
{
return;
}
this._playbackStates.localeInfoLoaded = true;
this._LoadMeetingInfo();
this._LoadData();
this._MeetingInfoOrLocalLoaded();
}
LMPlayback.prototype._MeetingInfoLoadedHandler = function()
{
this._playbackStates.meetingInfoLoaded = true;
this._SetMeetingInfo();
this._MeetingInfoOrLocalLoaded();
this._PreparePlaybackFrame();
}
LMPlayback.prototype._MeetingInfoOrLocalLoaded = function()
{
if( !this._playbackStates.meetingInfoLoaded ||
!this._playbackStates.localeInfoLoaded )
{
return;
}
this._PrepareDownloadFrame();
}
LMPlayback.prototype._PrepareDownloadFrameCompleteHandler = function()
{
this.uiObjects.ShowDownloadCompleteEvent.Add(
Delegate( this, LMPlayback.prototype._ShowDownloadCompleteHandler )
);
this._ShowDownloadFrame();
}
LMPlayback.prototype._ShowDownloadCompleteHandler = function()
{
this._playbackStates.showDownloadComplete  = true;
this._SetUIDataAndStartPlayback();
}
LMPlayback.prototype._PreparePlaybackFrameCompleteHandler = function()
{
this._playbackStates.preparePlaybackFrameComplete = true;
this._SetUIDataAndStartPlayback();
}
LMPlayback.prototype._SettingCheckingCompleteHandler = function( isContinueClicked )
{
this._playbackStates.settingCheckingComplete = true;
this._playbackStates.continueClicked = isContinueClicked;
this._SetUIDataAndStartPlayback();
this._PreparePlaybackFrame();
}
LMPlayback.prototype.DataManagerDataParsedHandler = function()
{
this._playbackStates.currentLoaded  = true;
this._playbackStates.indexLoaded    = true;
this._DetectBrowser();
this._ApplyDataForController();
this._playbackStates.ctrlDataApplied  = true;
this._SetUIDataAndStartPlayback();
}
LMPlayback.prototype._ControllerPagesLoadedHandler = function()
{
this._playbackStates.pagesLoadReady = true;
this._StartPlayback();
}
LMPlayback.prototype._SetUIDataAndStartPlayback = function( )
{
if ( !this._playbackStates.settingCheckingComplete
|| !this._playbackStates.ctrlDataApplied
|| !this._playbackStates.preparePlaybackFrameComplete
|| !this._playbackStates.showDownloadComplete )
{
return;
}
this._playbackStates.playbackframeReady  = true;
this._ApplyDataForUI();
this._StartPlayback();
}
LMPlayback.prototype._StartPlayback = function()
{
if ( !this._playbackStates.pagesLoadReady
|| !this._playbackStates.playbackframeReady  )
{
return;
}
g_ErrorHandling.EndLoadingProcess();
this._HookUIAndController();
this.uiObjects.ShowPlaybackFrame();
this._StartControllerAndWaitForReady();
}
LMPlayback.prototype.ControllerReadyHandler = function()
{
this.controller.StartMeetingPlayback();
}
LMPlayback.prototype._Uninitialize = function()
{
this.uiObjects.Uninitialize();
if( NavigatorInfo.IsFirefox() )
{
this.uiObjects.DeleteAllWMVObjects();
}
window.onbeforeunload = null;
Delegate.DisableAll = true;
Object.UnregisterAllEvents( window );
Object.UnregisterAllEvents( document );
lmPlayback = null;
LocaleInfo = null;
NavigatorInfo = null;
}
LMPlayback.prototype._OnStop = function()
{
return false;
}
LMPlayback.prototype._OnContextMenu = function()
{
return false;
}
LMPlayback.prototype._OnWindowError = function( msg, url, line )
{
var str = msg + "\r\n" + line + "@" + url;
g_ErrorHandling.ShowCustomError( str );
return false;
}
LMPlayback.prototype._ErrorOccuredHandler = function( msg )
{
this.controller.RestoreForError();
this.uiObjects.ShowErrorMsg( msg );
}
LMPlayback.prototype._WarningOccuredHandler = function( msg )
{
}
LMPlayback.prototype._DataManagerDurationUpdatedHandler = function( durNew )
{
if ( this.controller && this.controller.UpdateDuration )
{
this.controller.UpdateDuration( durNew );
}
if ( this.uiObjects && this.uiObjects.UpdateDuration )
{
this.uiObjects.UpdateDuration( durNew );
}
}
LMPlayback.prototype._InitializeCore = function()
{
Object.RegisterDomEvent( window, "onerror", Delegate( lmPlayback, lmPlayback._OnWindowError ) );
Object.RegisterDomEvent( window, "onunload", Delegate( lmPlayback, lmPlayback._Uninitialize ) );
Object.RegisterDomEvent( document, "onstop", Delegate( lmPlayback, lmPlayback._OnStop ) );
Object.RegisterDomEvent( document, "oncontextmenu", Delegate( lmPlayback, lmPlayback._OnContextMenu ) );
LocaleInfo.Initialize("lang/");
this.uiObjects = new UIObjects();
this.controller = new Controller();
this.dataManager = new DataManager();
this.uiObjects.Initialize();
this.controller.Initialize();
this.dataManager.Initialize();
var ctrlEventManager = this.controller.GetEventManager();
var ctrlEventHandlers = this.controller.GetEventHandlers();
var uiEventManager = this.uiObjects.GetEventManager();
var uiEventHandlers = this.uiObjects.GetEventHandlers();
ctrlEventManager.AddEventHandlers( uiEventHandlers );
uiEventManager.AddEventHandlers( ctrlEventHandlers );
this.controller.SetPromptBandWidthMessageHandler(
Delegate( this.uiObjects, this.uiObjects.PromptExclusiveMessage )
);
this.uiObjects.SettingCheckingCompleteEvent.Add(
DelegateWithArgs( this, LMPlayback.prototype._SettingCheckingCompleteHandler )
);
return true;
}
LMPlayback.prototype._LoadMeetingInfo = function()
{
this.dataManager.DurationUpdatedEvent.Add(
Delegate( this, LMPlayback.prototype._DataManagerDurationUpdatedHandler )
);
this.dataManager.MeetingInfoLoadedEvent.Add(
Delegate( this, LMPlayback.prototype._MeetingInfoLoadedHandler )
);
this.dataManager.LoadMeetingInfo();
}
LMPlayback.prototype._LoadLocaleInfo = function()
{
LocaleInfo.LoadedEvent.Add(
Delegate(
this,
LMPlayback.prototype._LocaleInfoLoadedHandler ) );
LocaleInfo.Load();
}
LMPlayback.prototype._LoadData = function()
{
this.dataManager.DataParsedEvent.Add(
Delegate( this, LMPlayback.prototype.DataManagerDataParsedHandler )
);
this.dataManager.LoadCurrentAndIndex();
}
LMPlayback.prototype._ParseDataRoot = function()
{
var dataRoot = window.location.search.substr( 1 );
dataRoot = decodeURIComponent( dataRoot );
if ( !dataRoot )
{
g_ErrorHandling.ShowError( E_DATAPATHNOTPROVIDED );
return false;
}
DataSetting = new DataSettingImpl( dataRoot );
return true;
}
LMPlayback.prototype._SetMeetingInfo = function()
{
var meetingInfo = this.dataManager.GetMeetingInfo();
if ( !meetingInfo )
{
g_ErrorHandling.ShowError( E_MEETINGINFONOTPROVIDED );
return;
}
this.uiObjects.SetMeetingInfo( meetingInfo );
this.controller.SetMeetingInfo( meetingInfo );
}
LMPlayback.prototype._PrepareDownloadFrame = function()
{
this.uiObjects.PrepareDownloadFrameCompletedEvent.Add(
Delegate( this,LMPlayback.prototype._PrepareDownloadFrameCompleteHandler )
);
this.uiObjects.PrepareDownloadFrame();
}
LMPlayback.prototype._PreparePlaybackFrame = function()
{
if ( !this._playbackStates.meetingInfoLoaded
||!this._playbackStates.settingCheckingComplete )
{
return;
}
this.uiObjects.PreparePlaybackFrameCompletedEvent.Add(
Delegate(
this,
LMPlayback.prototype._PreparePlaybackFrameCompleteHandler
)
);
this.uiObjects.PreparePlaybackFrame();
}
LMPlayback.prototype._ShowDownloadFrame = function()
{
this.uiObjects.ShowDownloadFrame();
}
LMPlayback.prototype._DetectBrowser = function()
{
var pageChangeEvents = this.dataManager.GetPageChangeEvents();
var plParser = new PageListParser();
plParser.Execute( pageChangeEvents );
NavigatorInfo.checkWMV = plParser.hasWMV;
NavigatorInfo.checkAnimation = plParser.hasPPT;
NavigatorInfo.checkFlash = plParser.hasFlash;
NavigatorInfo.FinishedEvent.Add( Delegate( this, this._SettingDetectionFinished ) );
NavigatorInfo.DetectBrowserSettings();
}
LMPlayback.prototype._ApplyDataForController = function()
{
var pageChangeEvents = this.dataManager.GetPageChangeEvents();
this.controller.SetPageChangeEvent( pageChangeEvents );
this._LoadPages();
var contentIndex = this.dataManager.GetContentIndexData();
var speakerIndex = this.dataManager.GetSpeakerIndexData();
var attendeeList = this.dataManager.GetAttendeeList();
this.controller.SetContentIndexData( contentIndex );
this.controller.SetSpeakerIndexData( speakerIndex );
this.controller.SetAttendeeList( attendeeList );
var qaData = this.dataManager.GetQAData();
this.controller.SetQAData( qaData );
var pvscData = this.dataManager.GetPrimVideoSrcChangedData();
this.controller.SetPrimVideoSrcChangedData( pvscData );
var bizChangedData = this.dataManager.GetBizcardChangedData();
this.controller.SetBizcardChagnedData( bizChangedData );
}
LMPlayback.prototype._LoadPages = function()
{
var bFromLocal = false;
var engineRoot = window.location;
if ( engineRoot.href.substring( 0, 4 ) == "http" )
{
this.controller.LoadFinished.Add(
Delegate( this, LMPlayback.prototype._ControllerPagesLoadedHandler )
);
this.controller.LoadPages();
}
else
{
setTimeout( Delegate( this, LMPlayback.prototype._ControllerPagesLoadedHandler ), 0 );
}
}
LMPlayback.prototype._SettingDetectionFinished = function()
{
this.uiObjects.ShowBrowserSetting();
}
LMPlayback.prototype._ApplyDataForUI = function()
{
var contentIndexData = this.dataManager.GetContentIndexData();
this.uiObjects.SetContentIndexData( contentIndexData );
var speakerIndexData = this.dataManager.GetSpeakerIndexData();
var attendeeList = this.dataManager.GetAttendeeList();
this.uiObjects.SetSpeakerIndexData( speakerIndexData, attendeeList );
var qaData = this.dataManager.GetQAData();
this.uiObjects.SetQAData( qaData );
}
LMPlayback.prototype._HookUIAndController = function()
{
for( var playerType in MeetingSettings.PageType )
{
var renderer = this.uiObjects.GetRenderer( playerType );
var player = this.controller.GetPlayer( playerType );
try
{
player.AssignRenderer( renderer );
}
catch( e )
{
Trace.WriteError( e, "Assign " + playerType + " renderer to player failed. " );
eval("debugger;");
}
}
var notesPlayer = this.controller.GetPlayer( MeetingSettings.VirtualPageType.Notes );
var notesRenderer = this.uiObjects.GetRenderer( MeetingSettings.VirtualPageType.Notes );
notesPlayer.AssignRenderer( notesRenderer );
var annoPlayer = this.controller.GetPlayer( MeetingSettings.VirtualPageType.Anno );
var annoRenderer = this.uiObjects.GetRenderer( MeetingSettings.VirtualPageType.Anno );
annoPlayer.AssignRenderer( annoRenderer );
var startPlayer = this.controller.GetPlayer( MeetingSettings.VirtualPageType.Start );
var startRenderer = this.uiObjects.GetRenderer( MeetingSettings.VirtualPageType.Start );
startPlayer.AssignRenderer( startRenderer );
var dataSeqPlayer = this.controller.GetDataSequence();
dataSeqPlayer.AssignPane(
this.uiObjects.GetPane( "Data" )
);
}
LMPlayback.prototype._StartControllerAndWaitForReady = function()
{
this.controller.AllWaitNeededReady.Add(
Delegate( this, LMPlayback.prototype.ControllerReadyHandler )
);
this.controller.PrePlay();
}
LMPlayback.DummyThumbnailEnabled = true;
Trace.Wrap( "LMPlayback" );
var LocaleInfo = new LocaleInfoImpl();
var lmPlayback = new LMPlayback();
lmPlayback.Run();
