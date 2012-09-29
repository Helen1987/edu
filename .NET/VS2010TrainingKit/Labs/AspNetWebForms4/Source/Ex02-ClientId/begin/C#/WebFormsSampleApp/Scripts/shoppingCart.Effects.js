function CollapseCart(withAnimation) {
//    TODO: Implement function
}

function ExpandCart(withAnimation) {
//    TODO: Implement function
}

$(document).ready(function() {

    // Preload expanded Shopping Cart background image
    $("<img>").attr("src", "Images/shopcart_bg.gif");

    // TODO: Add event handlers to page

    if ($("#ShoppingCartState").val() == "expanded") {
        ExpandCart(false);
    }
    else {
        CollapseCart(false);
    }
});