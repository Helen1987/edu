var mongoose = require('mongoose'),
    Schema = mongoose.Schema;

var FoodSchema = new Schema({
    name: String,
    description: String,
    price: String
});

mongoose.model('Food', FoodSchema);
module.exports = mongoose.model('Food');