function CollapseCart(withAnimation) {
    if (withAnimation) {
        $("#ShopCartExpanded").hide();
        $("#ShopCartCollapsed").show("slow");
    }
    else {
        $("#ShopCartExpanded").css("display", "none");
        $("#ShopCartCollapsed").css("display", "block");
    }

    $("#ShoppingCartState").val("collapsed");
}

function ExpandCart(withAnimation) {
    if (withAnimation) {
        $("#ShopCartCollapsed").hide();
        $("#ShopCartExpanded").show("slow");
    }
    else {
        $("#ShopCartCollapsed").css("display", "none");
        $("#ShopCartExpanded").css("display", "block");
    }

    $("#ShoppingCartState").val("expanded");
}

$(document).ready(function() {

    // Preload expanded Shopping Cart background image
    $("<img>").attr("src", "Images/shopcart_bg.gif");

    $("#ShopCartCollapsed").click(function () { ExpandCart(true) });
    $("#ShopCartExpanded").click(function () { CollapseCart(true) });

    if ($("#ShoppingCartState").val() == "expanded") {
        ExpandCart(false);
    }
    else {
        CollapseCart(false);
    }
});