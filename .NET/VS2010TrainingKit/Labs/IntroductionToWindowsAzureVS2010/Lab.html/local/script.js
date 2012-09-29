window.onload = LoadPage;
window.onunload = Window_Unload;
//window.onresize=ResizeWindow;
window.onbeforeprint = set_to_print;
window.onafterprint = reset_form;

var vbDeclaration;
var vbUsage;
var csLang;
var cLang;
var jsharpLang;
var jsLang;

var scrollPos = 0;
var languageCount = 0;

var inheritedMembers;
var protectedMembers;
var netcfMembersOnly;


// Initialize array of section states

var sectionStates = new Array();
var sectionStatesInitialized = false;
var allCollapsed = false;
var allExpanded = false;

function InitSectionStates() {
    // SectionStates has the format:
    //
    //     firstSectionId:state;secondSectionId:state;thirdSectionId:state; ... ;lastSectionId:state
    //
    // where state is either "e" (expanded) or "c" (collapsed)

    allExpanded = Load("AllExpanded");
    allCollapsed = Load("AllCollapsed");

    if (allExpanded == null || allCollapsed == null) {
        allExpanded = true;
        allCollapsed = false;
    }

    var states = Load("SectionStates");
    if (states == null || states == "") return;

    var start = 0;
    var end;
    var section;
    var state;

    while (start < states.length) {
        end = states.indexOf(":", start);

        section = states.substring(start, end);

        start = end + 1;
        end = states.indexOf(";", start);
        if (end == -1) end = states.length;

        state = states.substring(start, end);

        sectionStates[section] = (allExpanded) ? "e" : state;

        start = end + 1;
    }
}

var noReentry = false;

function OnLoadImage() {
    if (noReentry) return;

    if (!sectionStatesInitialized) {
        globals = GetGlobals();
        InitSectionStates();
        sectionStatesInitialized = true;
    }

    elem = event.srcElement;

    if (sectionStates[elem.id] == null) sectionStates[elem.id] = GetDefaultState();

    if (ShouldExpand(elem)) {
        noReentry = true;

        try {
            elem.src = collapseImage.src;
            elem.alt = collapseImage.alt;

            ExpandSection(elem);
        }
        catch (e) {
        }

        noReentry = false;
    }
}

function GetDefaultState() {
    if (allExpanded) return "e";
    if (allCollapsed) return "c";

    return "e";
}

function ShouldExpand(elem) {
    return (allExpanded || sectionStates[elem.id] == "e");
}


/*	
**********
**********   Begin
**********
*/

function LoadPage() {

    // If not initialized, grab the DTE.Globals object
    if (globals == null) globals = GetGlobals();

    // show correct language
    LoadLanguages();

    LoadMembersOptions();

    Set_up_checkboxes();

    DisplayLanguages();

    RenumberDemo();

    if (inheritedMembers == "off") DisplayInheritedMembers();
    if (protectedMembers == "off") DisplayProtectedMembers();
    if (netcfMembersOnly == "on") DisplayNETCFMembers();

    ChangeMembersOptionsFilterLabel();

    //SetCollapseAll();

    //	ResizeWindow();
    // split screen
    var screen = new SplitScreen('header', 'mainSection');

    // filtering dropdowns
    if (document.getElementById('languageSpan') != null) {
        var languageMenu = new Dropdown('languageFilterToolTip', 'languageSpan');
    }
    if (document.getElementById('membersOptionsFilterToolTip') != null) {
        var languageMenu = new Dropdown('membersOptionsFilterToolTip', 'membersOptionsSpan');
    }
        
    if (languageCount == 0) {
        var el = document.getElementById("languageFilterToolTip");

        if (el != null) {
            el.style.display = "none";
        }
    }

    // vs70.js did this to allow up/down arrow scrolling, I think
    try { mainSection.setActive(); } catch (e) { }

    //set the scroll position
    try { mainSection.scrollTop = scrollPos; }
    catch (e) { }
}

function Window_Unload() {
    SaveLanguages();
    SaveMembersOptions();
    SaveSections();
}

/*
function ResizeWindow()
{
if (document.body.clientWidth==0) return;
var header = document.all.item("header");
var mainSection = document.all.item("mainSection");
if (mainSection == null) return;
	
	
document.body.scroll = "no"
mainSection.style.overflow= "auto";
header.style.width= document.body.offsetWidth - 2;
//mainSection.style.paddingRight = "20px"; // Width issue code
mainSection.style.width= document.body.offsetWidth - 2;
mainSection.style.top=0;  
if (document.body.offsetHeight > header.offsetHeight + 10)
mainSection.style.height= document.body.offsetHeight - (header.offsetHeight + 2);
else
mainSection.style.height=0;
	
try
{
mainSection.setActive();
}
catch(e)
{
}
}
*/

function set_to_print() {
    //breaks out of divs to print
    var i;

    if (window.text) document.all.text.style.height = "auto";

    for (i = 0; i < document.all.length; i++) {
        if (document.all[i].tagName == "body") {
            document.all[i].scroll = "yes";
        }
        if (document.all[i].id == "header") {
            document.all[i].style.margin = "0px 0px 0px 0px";
            document.all[i].style.width = "100%";
        }
        if (document.all[i].id == "mainSection") {
            document.all[i].style.overflow = "visible";
            document.all[i].style.top = "5px";
            document.all[i].style.width = "100%";
            document.all[i].style.padding = "0px 10px 0px 30px";
        }
    }
}

function reset_form() {
    //returns to the div nonscrolling region after print
    document.location.reload();
}

function Set_up_checkboxes() {
    var checkbox;

    checkbox = document.getElementById("vbDeclarationCheckbox");
    if (checkbox != null) {
        if (vbDeclaration == "on")
            checkbox.checked = true;
        else
            checkbox.checked = false;
    }

    checkbox = document.getElementById("vbUsageCheckbox");
    if (checkbox != null) {
        if (vbUsage == "on")
            checkbox.checked = true;
        else
            checkbox.checked = false;
    }

    checkbox = document.getElementById("csCheckbox");
    if (checkbox != null) {
        if (csLang == "on")
            checkbox.checked = true;
        else
            checkbox.checked = false;
    }

    checkbox = document.getElementById("cCheckbox");
    if (checkbox != null) {
        if (cLang == "on")
            checkbox.checked = true;
        else
            checkbox.checked = false;
    }

    checkbox = document.getElementById("jsharpCheckbox");
    if (checkbox != null) {
        if (jsharpLang == "on")
            checkbox.checked = true;
        else
            checkbox.checked = false;
    }

    checkbox = document.getElementById("jsCheckbox");
    if (checkbox != null) {
        if (jsLang == "on")
            checkbox.checked = true;
        else
            checkbox.checked = false;
    }

    checkbox = document.getElementById("inheritedCheckbox");
    if (checkbox != null) {
        if (inheritedMembers == "on")
            checkbox.checked = true;
        else
            checkbox.checked = false;
    }

    checkbox = document.getElementById("protectedCheckbox");
    if (checkbox != null) {
        if (protectedMembers == "on")
            checkbox.checked = true;
        else
            checkbox.checked = false;
    }

    checkbox = document.getElementById("netcfCheckbox");
    if (checkbox != null) {
        if (netcfMembersOnly == "on")
            checkbox.checked = true;
        else
            checkbox.checked = false;
    }
}

/*	
**********
**********   End
**********
*/


/*	
**********
**********   Begin Language Filtering
**********
*/

function SetLanguage(key) {
    var i = 0;
    if (vbDeclaration == "on")
        i++;
    if (vbUsage == "on")
        i++;
    if (csLang == "on")
        i++;
    if (cLang == "on")
        i++;
    if (jsharpLang == "on")
        i++;
    if (jsLang == "on")
        i++;

    if (key.id == "vbDeclarationCheckbox") {
        if (vbDeclaration == "on") {
            if (i == 1) {
                key.checked = true;
                return;
            }

            vbDeclaration = "off";
        }
        else
            vbDeclaration = "on";
    }
    if (key.id == "vbUsageCheckbox") {
        if (vbUsage == "on") {
            if (i == 1) {
                key.checked = true;
                return;
            }

            vbUsage = "off";
        }
        else
            vbUsage = "on";
    }
    if (key.id == "csCheckbox") {
        if (csLang == "on") {
            if (i == 1) {
                key.checked = true;
                return;
            }

            csLang = "off";
        }
        else
            csLang = "on";
    }
    if (key.id == "cCheckbox") {
        if (cLang == "on") {
            if (i == 1) {
                key.checked = true;
                return;
            }

            cLang = "off";
        }
        else
            cLang = "on";
    }
    if (key.id == "jsharpCheckbox") {
        if (jsharpLang == "on") {
            if (i == 1) {
                key.checked = true;
                return;
            }

            jsharpLang = "off";
        }
        else
            jsharpLang = "on";
    }
    if (key.id == "jsCheckbox") {
        if (jsLang == "on") {
            if (i == 1) {
                key.checked = true;
                return;
            }

            jsLang = "off";
        }
        else
            jsLang = "on";
    }

    DisplayLanguages();
}

function DisplayLanguages() {
    
    var spanElements = document.getElementsByTagName("span");
    var x = 0;
    if (vbDeclaration == "on")
        x++;
    if (vbUsage == "on")
        x++;
    if (csLang == "on")
        x++;
    if (cLang == "on")
        x++;
    if (jsharpLang == "on")
        x++;
    if (jsLang == "on")
        x++;

    var i;
    var visualBasicCount = 0;
        
    for (i = 0; i < spanElements.length; ++i) {

        var codeLanguage = null;
        if (spanElements[i].attributes["codeLanguage"])
            codeLanguage = spanElements[i].attributes["codeLanguage"].value;
    
        if (codeLanguage != null) {
            if (codeLanguage == "VisualBasic") {
                if (vbDeclaration == "on" || vbUsage == "on") {
                    spanElements[i].style.display = "";
                    languageCount++;                    
                }
                else
                    spanElements[i].style.display = "none";
            }
            if (codeLanguage == "VisualBasicDeclaration") {
                if (vbDeclaration == "on") {
                    spanElements[i].style.display = "";
                    languageCount++;
                }
                else
                    spanElements[i].style.display = "none";
            }
            if (codeLanguage == "VisualBasicUsage") {
                if (vbUsage == "on") {
                    spanElements[i].style.display = "";
                    languageCount++;
                }
                else
                    spanElements[i].style.display = "none";
            }
            if (codeLanguage == "CSharp") {
                if (csLang == "on") {
                    spanElements[i].style.display = "";
                    languageCount++;
                }
                else
                    spanElements[i].style.display = "none";
            }
            if (codeLanguage == "ManagedCPlusPlus") {
                if (cLang == "on") {
                    spanElements[i].style.display = "";
                    languageCount++;
                }
                else
                    spanElements[i].style.display = "none";
            }
            if (codeLanguage == "JSharp") {
                if (jsharpLang == "on") {
                    spanElements[i].style.display = "";
                    languageCount++;
                }
                else
                    spanElements[i].style.display = "none";
            }
            if (codeLanguage == "JScript") {
                if (jsLang == "on") {
                    spanElements[i].style.display = "";
                    languageCount++;
                }
                else
                    spanElements[i].style.display = "none";
            }

            if (codeLanguage == "NotVisualBasicUsage") {
                if ((x == 1) && (vbUsage == "on")) {
                    spanElements[i].style.display = "none";                    
                }
                else {
                    spanElements[i].style.display = "";
                    languageCount++;
                }
            }
            
        }
        
    }
    ChangeLanguageFilterLabel();
}

function ChangeLanguageFilterLabel() {
    var i = 0;
    if (vbDeclaration == "on")
        i++;
    if (vbUsage == "on")
        i++;
    if (csLang == "on")
        i++;
    if (cLang == "on")
        i++;
    if (jsharpLang == "on")
        i++;
    if (jsLang == "on")
        i++;

    var languageNumber = 0;
    
    var labelElement;

    labelElement = document.getElementById("showAllLabel");

    if (labelElement == null)
        return;

    labelElement.style.display = "none";

    labelElement = document.getElementById("multipleLabel");
    if (labelElement != null) {        
        labelElement.style.display = "none";        
    }

    labelElement = document.getElementById("vbLabel");
    if (labelElement != null) {
        languageNumber++;        
        labelElement.style.display = "none";
    }

    labelElement = document.getElementById("csLabel");
    if (labelElement != null) {
        languageNumber++;
        labelElement.style.display = "none";
    }

    labelElement = document.getElementById("cLabel");
    if (labelElement != null) {
        languageNumber++;
        labelElement.style.display = "none";
    }

    labelElement = document.getElementById("jsharpLabel");
    if (labelElement != null) {
        languageNumber++;      
        labelElement.style.display = "none";
    }

    labelElement = document.getElementById("jsLabel");
    if (labelElement != null) {
        languageNumber++;        
        labelElement.style.display = "none";
    }
    
    if (i == 6) {
        labelElement = document.getElementById("showAllLabel");
        labelElement.style.display = "inline";
    }
    else if ((i > 1) && (i < 6)) {    
        if ((i == 2) && ((vbDeclaration == "on") && (vbUsage == "on"))) {
            labelElement = document.getElementById("vbLabel");
            labelElement.style.display = "inline";
        }
        else {
            labelElement = document.getElementById("multipleLabel");
            labelElement.style.display = "inline";
        }
    }
    else if (i == 1) {    
        if (vbDeclaration == "on" || vbUsage == "on") {
            labelElement = document.getElementById("vbLabel");
            labelElement.style.display = "inline";
        }
        if (csLang == "on") {
            labelElement = document.getElementById("csLabel");
            labelElement.style.display = "inline";
        }
        if (cLang == "on") {
            labelElement = document.getElementById("cLabel");
            labelElement.style.display = "inline";
        }
        if (jsharpLang == "on") {
            labelElement = document.getElementById("jsharpLabel");
            labelElement.style.display = "inline";
        }
        if (jsLang == "on") {
            labelElement = document.getElementById("jsLabel");
            labelElement.style.display = "inline";
        }
    }
    if (languageNumber < 2) {
        document.getElementById("languageFilterToolTip").style.display = "None";
    }
}

function LoadLanguages() {
    var value;
    value = Load("vbDeclaration");
    if (value == null)         
        vbDeclaration = "on";    
    else 
        vbDeclaration = value;
               
    value = Load("vbUsage");
    if (value == null) 
        vbUsage = "on";           
    else 
        vbUsage = value;
           
    value = Load("csLang");
    if (value == null)
        csLang = "on";
    else
        csLang = value;

    value = Load("cLang");
    if (value == null)
        cLang = "on";
    else
        cLang = value;

    value = Load("jsharpLang");
    if (value == null)
        jsharpLang = "on";
    else
        jsharpLang = value;

    value = Load("jsLang");
    if (value == null)
        jsLang = "on";
    else
        jsLang = value;
    
}

function SaveLanguages() {
    Save("vbDeclaration", vbDeclaration);
    Save("vbUsage", vbUsage);
    Save("csLang", csLang);
    Save("cLang", cLang);
    Save("jsharpLang", jsharpLang);
    Save("jsLang", jsLang);
}

/*	
**********
**********   End Language Filtering
**********
*/


/*	
**********
**********   Begin Members Options Filtering
**********
*/

function SetMembersOptions(key) {
    if (key.id == "inheritedCheckbox") {
        if (key.checked == true)
            inheritedMembers = "on";
        else
            inheritedMembers = "off";

        DisplayInheritedMembers();
    }
    if (key.id == "protectedCheckbox") {
        if (key.checked == true)
            protectedMembers = "on";
        else
            protectedMembers = "off";

        DisplayProtectedMembers();
    }
    if (key.id == "netcfCheckbox") {
        if (key.checked == true)
            netcfMembersOnly = "on";
        else
            netcfMembersOnly = "off";

        DisplayNETCFMembers();
    }

    ChangeMembersOptionsFilterLabel();
}

function DisplayInheritedMembers() {
    var iMembers = document.all.tags("tr");
    var i;

    if (inheritedMembers == "off") {
        for (i = 0; i < iMembers.length; ++i) {
            if (iMembers[i].name == "inheritedMember")
                iMembers[i].style.display = "none";
        }
    }
    else {
        for (i = 0; i < iMembers.length; ++i) {
            if (iMembers[i].name == "inheritedMember") {
                if (netcfMembersOnly == "on") {
                    if (iMembers[i].notSupportedOn == "netcf") {
                        iMembers[i].style.display = "none";
                    }
                    else {
                        iMembers[i].style.display = "";
                    }
                }
                else
                    iMembers[i].style.display = "";
            }
        }
    }
}

function DisplayProtectedMembers() {
    var imgElements = document.getElementsByName("toggleSwitch");
    var i;

    if (protectedMembers == "off") {
        for (i = 0; i < imgElements.length; ++i) {
            if (imgElements[i].id.indexOf("Family", 0) == 0) {
                if (ItemCollapsed(imgElements[i].id) == false) {
                    ExpandCollapse(imgElements[i]);
                }
            }
        }
    }
    else {
        for (i = 0; i < imgElements.length; ++i) {
            if (imgElements[i].id.indexOf("Family", 0) == 0) {
                if (ItemCollapsed(imgElements[i].id) == true) {
                    ExpandCollapse(imgElements[i]);
                }
            }
        }
    }

}

function DisplayNETCFMembers() {
    var netcfMembers = document.all.tags("tr");
    var i;

    if (netcfMembersOnly == "off") {
        for (i = 0; i < netcfMembers.length; ++i) {
            if (netcfMembers[i].notSupportedOn == "netcf") {
                netcfMembers[i].style.display = "";
            }
        }
        DisplayInheritedMembers();
    }
    else {
        for (i = 0; i < netcfMembers.length; ++i) {
            if (netcfMembers[i].notSupportedOn == "netcf") {
                netcfMembers[i].style.display = "none";
            }
        }
    }
}

function ChangeMembersOptionsFilterLabel() {

    var filtered = false;

    if ((inheritedMembers == "off") || (protectedMembers == "off") || (netcfMembersOnly == "on"))
        filtered = true;

    var labelElement;

    labelElement = document.getElementById("showAllMembersLabel");

    if (labelElement == null)
        return;

    labelElement.style.display = "none";

    labelElement = document.getElementById("filteredMembersLabel");
    labelElement.style.display = "none";

    if (filtered) {
        labelElement = document.getElementById("filteredMembersLabel");
        labelElement.style.display = "inline";
    }
    else {
        labelElement = document.getElementById("showAllMembersLabel");
        labelElement.style.display = "inline";
    }
}

function LoadMembersOptions() {
    var value;
    value = Load("inheritedMembers");
    if (value == null)
        inheritedMembers = "on";
    else
        inheritedMembers = value;

    value = Load("protectedMembers");
    if (value == null)
        protectedMembers = "on";
    else
        protectedMembers = value;

    value = Load("netcfMembersOnly");
    if (value == null)
        netcfMembersOnly = "off";
    else
        netcfMembersOnly = value;
}

function SaveMembersOptions() {
    Save("inheritedMembers", inheritedMembers);
    Save("protectedMembers", protectedMembers);
    Save("netcfMembersOnly", netcfMembersOnly);
}

/*	
**********
**********   End Members Options Filtering
**********
*/


/*	
**********
**********   Begin Expand/Collapse
**********
*/

function ExpandCollapse(imageItem) {
    noReentry = true; // Prevent entry to OnLoadImage

    if (ItemCollapsed(imageItem.id) == true) {
        imageItem.src = collapseImage.src;
        imageItem.alt = collapseImage.alt;

        ExpandSection(imageItem);

        if (imageItem.id.indexOf("Family", 0) == 0) {
            protectedMembers = "on";
            Set_up_checkboxes();
            ChangeMembersOptionsFilterLabel();
        }
    }
    else {
        imageItem.src = expandImage.src;
        imageItem.alt = expandImage.alt;

        CollapseSection(imageItem);
    }

    allCollapsed = false;
    allExpanded = false;

    SetCollapseAll();

    noReentry = false;
}

function ExpandCollapseAll(imageItem) {
    noReentry = true; // Prevent entry to OnLoadImage

    var imgElements = document.getElementsByName("toggleSwitch");
    var i;

    if (imageItem.src == expandAllImage.src) {
        imageItem.src = collapseAllImage.src;
        imageItem.alt = collapseAllImage.alt;

        for (i = 0; i < imgElements.length; ++i) {
            imgElements[i].src = collapseImage.src;
            imgElements[i].alt = collapseImage.alt;

            ExpandSection(imgElements[i]);

            if (imgElements[i].id.indexOf("Family", 0) == 0) protectedMembers = "on";
        }

        SetToggleAllLabel(false);

        allExpanded = true;
        allCollapsed = false;
    }
    else {
        imageItem.src = expandAllImage.src;
        imageItem.alt = expandAllImage.alt;

        for (i = 0; i < imgElements.length; ++i) {
            imgElements[i].src = expandImage.src;
            imgElements[i].alt = expandImage.alt;

            CollapseSection(imgElements[i]);
        }

        SetToggleAllLabel(true);

        allExpanded = false;
        allCollapsed = true;
    }

    noReentry = false;
}

function ExpandCollapse_CheckKey(imageItem) {
    if (window.event.keyCode == 13)
        ExpandCollapse(imageItem);
}

function ExpandCollapseAll_CheckKey(imageItem) {
    if (window.event.keyCode == 13)
        ExpandCollapseAll(imageItem);
}

function ExpandSection(imageItem) {
    try {
        imageItem.parentElement.parentElement.nextSibling.style.display = "";
        sectionStates[imageItem.id] = "e";
    }
    catch (e) {
    }
}

function CollapseSection(imageItem) {
    try {
        imageItem.parentElement.parentElement.nextSibling.style.display = "none";
        sectionStates[imageItem.id] = "c";
    }
    catch (e) {
    }
}

function SetCollapseAll() {
    var imageElement = document.getElementById("toggleAllImage");

    if (imageElement == null) return;

    if (allCollapsed) {
        imageElement.src = expandAllImage.src;
        imageElement.alt = expandAllImage.alt;
    }
    else {
        imageElement.src = collapseAllImage.src;
        imageElement.alt = collapseAllImage.alt;
    }

    SetToggleAllLabel(allCollapsed);
}

function SetToggleAllLabel(collapseAll) {
    var labelElement = document.getElementById("collapseAllLabel");

    if (labelElement == null) return;

    labelElement.style.display = "none";

    labelElement = document.getElementById("expandAllLabel");
    labelElement.style.display = "none";

    if (collapseAll) {
        labelElement = document.getElementById("expandAllLabel");
        labelElement.style.display = "inline";
    }
    else {
        labelElement = document.getElementById("collapseAllLabel");
        labelElement.style.display = "inline";
    }
}

function ItemCollapsed(imageId) {
    return sectionStates[imageId] == "c";
}

function SaveSections() {
    try {
        var states = "";

        for (var sectionId in sectionStates) states += sectionId + ":" + sectionStates[sectionId] + ";";

        Save("SectionStates", states.substring(0, states.length - 1));
    }
    catch (e) {
    }

    Save("AllExpanded", allExpanded);
    Save("AllCollapsed", allCollapsed);
}

function ShouldSave(imageId) {
    var toggleName;

    if (imageId == "toggleAllImage")
        return false;

    toggleName = "procedureToggle";
    if (imageId.indexOf(toggleName, 0) == 0)
        return false;

    toggleName = "sectionToggle";
    if (imageId.indexOf(toggleName, 0) == 0)
        return false;

    return true;
}

function OpenSection(imageItem) {
    if (sectionStates[imageItem.id] == "c") ExpandCollapse(imageItem);
}

/*	
**********
**********   End Expand/Collapse
**********
*/



/*	
**********
**********   Begin Copy Code
**********
*/

function CopyCode(key) {
    var trElements = document.getElementsByTagName("tr");
    for (var i = 0; i < trElements.length; ++i) {
        if (key.parentNode.parentNode.parentNode == trElements[i].parentNode) {
            i++;
            if (document.all) {
                var text = trElements[i].innerText;
                var lines = trElements[i].getElementsByTagName('b');
                if (lines.length > 0) {
                    text = lines[0].innerText;
                    for (var j = 1; j < lines.length; j++) {
                        text += '\r\n' + lines[j].innerText;
                    }
                }
                if (text != "") {
                    window.clipboardData.setData("Text", text);
                }
            } else {
                var text = trElements[i].textContent;
                var lines = trElements[i].getElementsByTagName('b');
                if (lines.length > 0) {
                    text = lines[0].textContent;
                    for (var j = 1; j < lines.length; j++) {
                        text += '\r\n' + lines[j].textContent;
                    }
                }
                if (text != "") {
                    CopyToClipboardFF(text);
                }
            }
            break;
        }
    }
}

function CopyToClipboardFF(text) {
    //Firefox
    netscape.security.PrivilegeManager.enablePrivilege('UniversalXPConnect');

    var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
    if (!clip) return;

    var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
    if (!trans) return;

    trans.addDataFlavor('text/unicode');

    var str = new Object();
    var len = new Object();

    var str = Components.classes["@mozilla.org/supports-string;1"]
				.createInstance(Components.interfaces.nsISupportsString);

    str.data = text;

    trans.setTransferData("text/unicode", str, text.length * 2);

    var clipid = Components.interfaces.nsIClipboard;
    if (!clip) return;

    clip.setData(trans, null, clipid.kGlobalClipboard);
}

function ChangeCopyCodeIcon(key) {
    var i;
    var imageElements = document.getElementsByName("ccImage")
    var copyImg = document.getElementById("copyImage")
    var copyHoverImg = document.getElementById("copyHoverImage")

    for (i = 0; i < imageElements.length; ++i) {
        if (imageElements[i].parentNode == key) {
            if (imageElements[i].src == copyImg.src) {
                imageElements[i].src = copyHoverImg.src;
                imageElements[i].alt = copyHoverImg.alt;
            }
            else {
                imageElements[i].src = copyImg.src;
                imageElements[i].alt = copyImg.alt;
            }
        }
    }
}

function CopyCode_CheckKey(key) {
    if (window.event.keyCode == 13)
        CopyCode(key);
}

/*	
**********
**********   End Copy Code
**********
*/

/*	
**********
**********   Begin Maintain Scroll Position
**********
*/

function loadAll() {
    try {
        scrollPos = allHistory.getAttribute("Scroll");
    }
    catch (e) { }
}

function saveAll() {
    try {
        allHistory.setAttribute("Scroll", mainSection.scrollTop);
    }
    catch (e) { }
}

/*	
**********
**********   End Maintain Scroll Position
**********
*/


/*	
**********
**********   Begin Send Mail
**********
*/

function formatMailToLink(anchor) {
    var release = "Release: " + anchor.doc_Release;
    var topicId = "Topic ID: " + anchor.doc_TopicID;
    var topicTitle = "Topic Title: " + anchor.doc_TopicTitle;
    var url = "URL: " + document.URL;
    var browser = "Browser: " + window.navigator.userAgent;

    var crlf = "%0d%0a";
    var body = release + crlf + topicId + crlf + topicTitle + crlf + url + crlf + browser + crlf + crlf + "Comments:" + crlf + crlf;

    anchor.href = anchor.href + "&body=" + body;
}

/*	
**********
**********   End Send Mail
**********
*/


/*	
**********
**********   Begin Persistence
**********
*/

var globals;

function GetGlobals() {
    var tmp;

    // Try to get VS implementation
    try { tmp = window.external.Globals; }
    catch (e) { tmp = null; }

    // Try to get DExplore implementation
    try { if (tmp == null) tmp = window.external.GetObject("DTE", "").Globals; }
    catch (e) { tmp = null; }

    return tmp;
}

function Load(key) {
    try {
        return globals.VariableExists(key) ? globals.VariableValue(key) : null;
    }
    catch (e) {
        return null;
    }
}

function Save(key, value) {
    try {
        globals.VariableValue(key) = value;
        globals.VariablePersists(key) = true;
    }
    catch (e) {
    }
}

/*	
**********
**********   End Persistence
**********
*/

function RenumberDemo() {
    var mainBody = document.getElementById("mainBody");
    var tables = mainBody.getElementsByTagName("table");

    if (tables.length > 0) {
        for (t = 0; t < tables.length; t++) {
            var table = tables[t];
            var chkstr = "ActionScriptScreenshot";
            // the table is a demo script (should have the headers: Action | Script | Screenshot)
            if (table.innerText.substr(0, chkstr.length) == chkstr) {
                var cnt = 1; //item counter
                var tds = table.cells;

                //only renumber ordered lists on first column
                for (c = 0; c < tds.length; c = c + 3) {
                    var ols = tds[c].getElementsByTagName("ol");
                    for (i = 0; i < ols.length; i++) {
                        var lis = ols[i].getElementsByTagName("li");
                        for (j = 0; j < lis.length; j++) {
                            lis[j].setAttribute('value', cnt);
                            cnt++;
                        }
                    }
                }
            }
        }
    }
}