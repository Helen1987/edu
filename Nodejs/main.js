var express = require('express');
var app = express();
var bodyparser = require('body-parser');
var mongoose = require('mongoose');

app.use(bodyparser.urlencoded({
    extended: true
}));

app.use(bodyparser.json());

mongoose.connect('mongodb://localhost:27017/restaurant');

require('./app/routes.food.js')(app);
require('./app/routes.user.js')(app);

app.use(express.static(__dirname + '/public'));

app.set('port', process.env.PORT || 3000);
app.listen(app.get('port'));
console.log("the server is running on http://localhost:" + app.get('port'));