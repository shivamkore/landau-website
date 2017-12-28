$(function () {
    //Set Favorites count in display text
    var favCount = window.localStorage.getItem('favoriteCount');
    var count = favCount == null ? 0 : favCount;

    favoriteView.setDisplayCount(count);

    var data = JSON.parse(window.localStorage.getItem("favoriteProducts"));
    $.ajax({
        method: "POST",
        url: "/Favorites/GetProducts",
        data: {
            favoritesModel: data == null ? []: data
        }
    })
    .fail(function (jqXHR, textStatus) {
    })
    .done(function (response) {
        $(".favorites_container").html(response);
    });


});


var favoriteView = {
    remove: function (code, elem) {
        if (code === '') return;

        var index = this.searchFavorites(code);
        if (index != -1) { //exist in array
            this.removeFavoriteProducts(index);
            this.updateFavoriteCount();
            $(elem).parent().parent().parent().parent().parent().remove();
        }


        return false;
    },
    updateFavoriteCount: function () {
        var count = JSON.parse(window.localStorage.getItem("favoriteProducts")).length;

        var favoriteSpan = $(".num .num-circle span");
        for (var i = 0 ; i < favoriteSpan.length; i++) {
            favoriteSpan[i].innerHTML = count;
        }

        window.localStorage.setItem('favoriteCount', count);
        this.setDisplayCount(count);
    },
    setDisplayCount: function (fCount) {
        var favoriteSpan = $("#favorites_page .top .links .count span");
        var displayText = $("#favorites_page .top .links .count")[0];
        for (var i = 0 ; i < favoriteSpan.length; i++) {
            favoriteSpan[i].innerHTML = fCount;
            if (fCount == 1) { displayText.innerHTML = displayText.innerHTML.replace("Items", "Item "); }
            else if (fCount == 0) { displayText.innerHTML = displayText.innerHTML.replace("Item ", "Items "); }
        }
    },
    removeFavoriteProducts: function (index) {
        var favProduct = this.getFavoriteProducts();
        favProduct.splice(index, 1);
        window.localStorage.setItem("favoriteProducts", JSON.stringify(favProduct));
    },
    searchFavorites: function (value) {
        return this.getFavoriteProducts().map(function (x) { return x.ProductCode; }).indexOf(value);
    },
    getFavoriteProducts: function () {
        var favoriteProducts = [];
        if (window.localStorage.getItem("favoriteProducts")) {
            favoriteProducts = JSON.parse(localStorage.getItem("favoriteProducts"));
        }
        return favoriteProducts;
    }
}


function sendFavCodes() {
    var favs = favoriteView.getFavoriteProducts();
    var codes = '';
    for (var i = 0; i < favs.length; i++)
        codes += favs[i].ProductCode + ",";
    $('#hiddenFavs').val(codes);
}