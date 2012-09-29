addLoadEvent(UpdateRelativeDepUrls);

function CheckDC(requiredDCVersion) {
    var iePlugin = document.getElementById("dcDetectorIE");
    var mozPlugin = document.getElementById("dcDetectorMoz");
    var dcVersion = "";

    if ((typeof (iePlugin) != "undefined") && (iePlugin != null) && (typeof (iePlugin.DCVersion) != "undefined")) {
        dcVersion = iePlugin.DCVersion;
    }
    else if ((typeof (mozPlugin) != "undefined") && (mozPlugin != null) && (typeof (mozPlugin.DCVersion) != "undefined")) {
        dcVersion = mozPlugin.DCVersion;
    }

    if (dcVersion == "") // not installed
    {
        alert("You need the Dependency Checker to run this configuration file!");
        OpenDCSetup();
        
        return false;
    }
    else if (!CompareVersion(requiredDCVersion, dcVersion)) // check version
    {
        alert("You need a newer version of the Dependency Checker to run this configuration file!");
        return false;
    }

    return true;
}

function OpenDCSetup() {
    var pageDirectory = window.location.href.substr(8);
    pageDirectory = pageDirectory.substr(0, pageDirectory.lastIndexOf('/'));
    
    // TODO: update this to open the DC installer form the TK or point to a download page
    window.location = pageDirectory + "/Assets/DependencyChecker/DependencyChecker.msi";
}

function UpdateRelativeDepUrls() {
    var links = document.getElementsByTagName('a');
    
    for (var i = 0; i < links.length; i++) {
        var link = links[i];
        
        if (link.href.toLowerCase().indexOf('dep://') == 0) {
            link.href = MakeAbsolute(link.href);
        }
    }
}

function MakeAbsolute(depPath) {
    var newDepPath = depPath;

    if (newDepPath.toLowerCase().indexOf('dep://') == 0) {
        newDepPath = newDepPath.substr(6);
    }

    var pageDirectory = window.location.href.substr(8);
    pageDirectory = pageDirectory.substr(0, pageDirectory.lastIndexOf('/'));

    //is absolute
    if (newDepPath.toLowerCase().indexOf(':') > 0) {
        return depPath;
    }

    //is online
    if (newDepPath.toLowerCase().indexOf('http') == 0) {
        return depPath;
    }

    newPath = 'dep://' + pageDirectory + '/' + newDepPath;

    return newPath;
}

function parseVersionString(str) {
    var x = str.split('.');

    var maj = parseInt(x[0]) || 0;
    var min = parseInt(x[1]) || 0;
    var rev = parseInt(x[2]) || 0;
    var bui = parseInt(x[3]) || 0;

    return {
        major: maj,
        minor: min,
        revision: rev,
        build: bui
    }
}

function CompareVersion(vmin, vcurrent) {
    minimum = parseVersionString(vmin);
    running = parseVersionString(vcurrent);
    if (running.major != minimum.major)
        return (running.major > minimum.major);
    else {
        if (running.minor != minimum.minor)
            return (running.minor > minimum.minor);
        else {
            if (running.revision != minimum.revision)
                return (running.revision > minimum.revision);
            else {
                if (running.build != minimum.build)
                    return (running.build > minimum.build);
                else
                    return true;
            }
        }
    }
}

function addLoadEvent(func) {
    var oldonload = window.onload;
    if (typeof window.onload != 'function') {
        window.onload = func;
    }
    else {
        window.onload = function() {
            oldonload();
            func();
        }
    }
}