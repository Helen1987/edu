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

//create a Schema for our food:
var FoodSchema = new Schema({
    name: {
        type: String,
        index: {
            unique: true
        }
    },
    description: String,
    price: String
});


// Use the schema to register a model with MongoDb
mongoose.model('Food', FoodSchema);
var food = mongoose.model('Food');

//POST verb
app.post('/food', function (req, res) {
    food.create(req.body, function (err, food) {
        if (err) {
            res.send(401, err);
            return;
        }
        res.send(req.body);
    });
});

//GET verb
app.get('/food', function (req, res) {
    food.find(function (err, data) {
        if (err) {
            res.send(err);
        }
        res.json(data);
    });
});

//GET/id
app.get('/food/:id', function (req, res) {
    food.findOne({
        _id: req.params.id
    }, function (error, response) {
        if (error) {
            res.send(error);
        } else {
            res.send(response);
        }
    });
});

//GET by name
app.get('/foodname/:name', function (req, res) {
    food.findOne({
        name: req.params.name
    }, function (error, response) {
        if (error || !response) {
            res.send("not on the menu");
        } else {
            res.send(response);
        }
    });
});

app.set('port', process.env.PORT || 3000);
app.listen(app.get('port'));
console.log("the server is running on http://localhost:" + app.get('port'));