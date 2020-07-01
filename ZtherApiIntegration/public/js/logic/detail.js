
$(function () {
    customerReviews = function () {
        var prodCode = "";
        var pageNr = 1;
        var sizeCategory = "";

        return {
            prodCode: prodCode, 
            pageNr: pageNr,
            sizeCategory: sizeCategory
        }
    }();

    $(".favorites_container").on('click', function () {
        if (window.localStorage && customerReviews.prodCode.length > 0) {
            setLocalStorageItem(customerReviews.prodCode);
        }
    });

    $('.swatch_container').on('click', function () {
        var favs = getFavsFromStorage();
        var color = $(this).data('color-code');        
        var colorName = $(this).data('color-name');
        var swatchType = $(this).data('swatch-type');

        $('.category_options_container .text').html('Color - ' + colorName + ' (' + color + ')');

        var sizeCode = $(".category_options_wrapper .active .sizes_container .selected").first();

        var index = searchInArray(favs, customerReviews.prodCode, color, sizeCode.text());

        changeFavIcon(index < 0);

        refreshWidgetUrl(color, swatchType);
        
        refreshImages($(this).data('color-code'));
    });

    $('.category_container a').on('click', function () {
        var option = $(this).text();
        customerReviews.sizeCategory = option;
    });
    
    addHandlerForSizes();
    
});

function refreshWidgetUrl(color, swatchType) {

    var product = $('.sku').text().trim();
    var urlWidget = $('#where-to-buy-dialog').attr('src');

    var param = product;

    if (swatchType.trim().toUpperCase() === 'PRINT') {
        param += color;
    }
    
    var url = urlWidget.substr(0, urlWidget.indexOf('?'));
    var newSrc = (url + "?modelname=" + param).trim().toLowerCase();
    
    $('#where-to-buy-dialog').attr('src', newSrc);
}

function addHandlerForSizes() {
    $('.size_option').off('click');

    $('.size_option').on('click', function () {
        var favs = getFavsFromStorage();

        var color = $(".category_options_wrapper .color_options_container .selected").first().data('color-code');

        var sizeCode = $(this);

        var index = searchInArray(favs, customerReviews.prodCode, color, sizeCode.text());

        changeFavIcon(index < 0);
    });
}


function setUnfavorite(colorCode, sizeCode) {
    var favList = getFavsFromStorage();

    if (favList.length > 0 ) {        
        var index = searchInArray(favList, customerReviews.prodCode, colorCode, sizeCode);
        if (index != -1) {
            changeFavIcon(false);
        }
    };
}


function searchInArray(arr, value, color, size) {
    for (var i = 0; i < arr.length; i++) {
        if (arr[i].ProductCode == value && arr[i].ColorCode == color && arr[i].SizeCode == size) {
            return i;
        }
    }

    return -1;
}

function setLocalStorageItem(search) {
    if (search === '') {
        return;
    }
    //console.log(localStorage);

    var favoriteProducts = getFavsFromStorage();

    var colorCode = $(".category_options_wrapper .color_options_container .selected").first();
    var sizeCode = $(".category_options_wrapper .sizes_container .selected").first();

    var index = searchInArray(favoriteProducts, search, colorCode.data('color-code'), sizeCode.text());

    //if click to add to Favorites, then change text to "Remove..." and add 'unfavorite' class
    if ($(".favorites_container .unfavorite").length == 0) { //FAVORITE
        //if unfavorite, remove item , search in localStorage and remove it.
        if (index == -1) { //exist in array            
            var sizeCode = $(".category_options_wrapper .size_options_container .selected").first();

            var pushObj = {
                ProductCode: search,
                ColorCode: colorCode.data('color-code'),
                ColorName: colorCode.data('color-name'),
                ColorUrl: colorCode.data('color-url'),
                ColorHex: colorCode.data('color-hex'),
                SizeCode: sizeCode.text(),
                SizeCategory: sizeCode.data('size-category')
            };

            favoriteProducts.push(pushObj);
            localStorage.setItem("favoriteProducts", JSON.stringify(favoriteProducts));            

            changeFavIcon(false);
        }
    }
    else {//UNFAVORITE

        if (index != -1) { //exists in array
            favoriteProducts.splice(index, 1);
            localStorage.setItem("favoriteProducts", JSON.stringify(favoriteProducts));
            
            changeFavIcon(true);
        }
    }

    var count = JSON.parse(localStorage.getItem("favoriteProducts")).length;
    
    var favoriteSpan = $(".num .num-circle span");
    for (var i = 0 ; i < favoriteSpan.length; i++) {
        favoriteSpan[i].innerHTML = count;
    }

    window.localStorage.setItem('favoriteCount', count);
}

function changeFavIcon(enabled) {

    var attr = 'srcset';
    if (isIE())
        attr = 'src';

    if (enabled) {
        //change heart icon to unfavorite
        $(".favorites_container .heart").attr(attr, 'public/images/detail/icons/heart.svg')
        $(".favorites_container .text").removeClass('unfavorite');
    }
    else {
        //change heart icon to saved
        $(".favorites_container .heart").attr(attr, 'public/images/detail/icons/heart_saved.svg')
        $(".favorites_container .text").addClass('unfavorite');
    }
}

function refreshReviews() {
    $.ajax({
        url: "/Detail/ReviewsPagination",
        type: "GET",
        data: { productId: customerReviews.prodCode, pageNumber: customerReviews.pageNr }
    })
    .fail(function (jqXHR, textStatus) {
            //alert(textStatus);
    })
    .done(function (response) {
        $("#reviewsPagination").html(response);
    });
}

//encoding to avoid server detecting potential attack
function localEncode(value) {
    return value.replace(/&#39;/g, "_amp_");
}

function refreshImages(color) {
    $.ajax({
        url: "/Detail/ChangeProductImage",
        type: "GET",
        data: { productId: customerReviews.prodCode, color: color, sizeCategory: localEncode(customerReviews.sizeCategory) }
    })
    .fail(function (jqXHR, textStatus) {
        //alert(textStatus);
    })
    .done(function (response) {
        $(".zoom_wrapper").html(response.zoomedView);
        $(".img_container").html(response.imagesView);
        $(".social_container").html(response.shareView);
        $(".size_options_container").html(response.sizesView);

        $('.category_options_wrapper').off('click', '.more_colors');        
        
        //reload script to bind actions to reloaded elements
        $.getScript("/public/js/pages/detail.js")
        .done(function (script, textStatus) {
            addHandlerForSizes();
        })
        .fail(function (jqxhr, settings, exception) {
        });
    });
}

function reloadScript() {

}

function nextReviewsPage() {
        customerReviews.pageNr++;
        refreshReviews();
}

function previousReviewsPage() {
    if (customerReviews.pageNr > 1) {
        customerReviews.pageNr--;
        refreshReviews();
    }
}

function nextProduct() {
    changeProduct("NextProduct");
}

function previousProduct() {
    changeProduct("PreviousProduct");
}

function changeProduct(method) {
    $.ajax({
        url: "/Detail/" + method,
        type: "GET",
        data: { productId: $("#divCurrentProductCode").text() }
        })
        .fail(function (jqXHR, textStatus) {

        })
        .done(function (response) {
            if (response != '')
                $("#divMainBody").html(response);
        });
}

function setValues(prodCode, colorCode, sizeCategory) {
    $(document).ready(function () {
        customerReviews.prodCode = prodCode;
        customerReviews.sizeCategory = sizeCategory;
        var sizeCode = $(".category_options_wrapper .sizes_container .selected").first();

        //Set Favorite/UnFavorite text (add unfavorite class)
        setUnfavorite(colorCode, sizeCode.text());
    });
}

function getFavsFromStorage() {
    var favoriteProducts = [];

    if (window.localStorage.getItem("favoriteProducts")) {
        favoriteProducts = JSON.parse(localStorage.getItem("favoriteProducts"));
    }

    return favoriteProducts;
}

function measureChart() {
    $('.measurement').off('click');
    //window.location.href = "http://www.landau.com/fit-guide";
    window.open("http://www.landau.com/fit-guide");
}

function isIE() {

    var ua = window.navigator.userAgent;

    var msie = ua.indexOf('MSIE ');
    if (msie > 0) {
        // IE 10 or older => return version number
        return true;
    }

    var trident = ua.indexOf('Trident/');
    if (trident > 0) {
        // IE 11 => return version number
        return true;
    }

    var edge = ua.indexOf('Edge/');
    if (edge > 0) {
        // Edge (IE 12+) => return version number
        return true;
    }

    // other browser
    return false;
}