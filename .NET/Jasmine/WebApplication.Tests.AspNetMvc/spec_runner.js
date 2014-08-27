console.log('Loading a web page');

var url = "spec_runner.html";
var page = new WebPage();
phantom.viewportSize = { width: 800, height: 600 };

//This is required because PhantomJS sandboxes the website and it does not show up the console messages form that page by default
page.onConsoleMessage = function (msg) { console.log(msg); };

// error tracking
page.onResourceError = function(error) {
    page.reason = error.errorString;
    page.reason_url = error.url;
};

//Open the website
page.open(url, function (status) {
    if (status !== 'success') {
        // Something went wrong, try to be helpful
        console.log('Unable to load the address!');
        console.log("Error: " + page.reason);
        console.log("Page: " + page.reason_url);
    } else {
        //Using a delay to make sure the JavaScript is executed in the browser
        window.setTimeout(function () {
            // render the page and save the output to the specified png file
            page.render("output.png");
            phantom.exit();
        }, 200);
    }
});