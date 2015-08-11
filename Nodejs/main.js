var express = require('express');
var app = express();
var bodyParser = require('body-parser');
var mongoose = require('mongoose');
//mongoose uses Schema as a layer on a MongoDb document (which represents a model):
var Schema = mongoose.Schema;

app.use(bodyParser.urlencoded({
    extended: true
}));
app.use(bodyParser.json());

//connect to mongodb:
mongoose.connect('mongodb://localhost:27017/restaurant');

require('./app/routes.food.js')(app);
app.use(express.static(__dirname + '/public'));

app.set('port', process.env.PORT || 3000);
app.listen(app.get('port'));
console.log("the server is running on http://localhost:" + app.get('port'));