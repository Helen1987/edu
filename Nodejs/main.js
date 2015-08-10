var express = require('express');
var app = express();

app.use(express.static(__dirname + '/public'));

var menu = [{ "description": "papadums", "price": "2,00" }, { "description": "chicken tikka masala", "price": "14,00" },
{ "description": "fisher king beer", "price": "2,50" }, { "description": "sag paneer", "price": "6,00" }];

app.get('/food', function (req, res) {
    res.send(menu);
});

app.set('port', process.env.PORT || 3000);
app.listen(app.get('port'));
console.log("the server is running on http://localhost:" + app.get('port'));