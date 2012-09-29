
Sys.Mvc.ValidatorRegistry.validators["priceOnRange"] = function (rule) {
    var minPrice = rule.ValidationParameters.minPrice;
    var maxPrice = rule.ValidationParameters.maxPrice;
    var message = rule.ErrorMessage;

    return function (value, context) {
        if (value > maxPrice || value < minPrice) {
            return false;
        }
        return true;
    };
};
