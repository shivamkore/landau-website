$(function () {
    $('#prints_page .products .product .image_icon').each(function () {
        var _that = $(this).parent();
        var oColor = _that.find('.text .id').text();
        
        $(this).on('click', function () {
            var isDisplayed = _that.find('.isDisplayed');
            if (isDisplayed.length > 0) {
                _that.find('.hover_selection').removeClass("isDisplayed");
            }
            else {
                _that.find('.hover_selection').addClass("isDisplayed");
                renderProducts(oColor, _that);
            }
        });
        
    });


});

function initProductSlider() {

    //Product Dropdown Slider
    $('.prints_solids_page .products_slider .flexslider').flexslider({
        animation: "fade",
        animationSpeed: 650,
        move: 1,
        directionNav: true,
        // smoothHeight: true,
        slideshow: false,
        slideshowSpeed: 10000,
        animationLoop: true,
    });

    $('.prints_solids_page .products_slider .flex-direction-nav li:first-of-type').hover(function () {
        if (window.width >= 1270) {
            TweenMax.to($(this), 0.5, {
                repeat: -1,
                yoyo: true,
                'transform': 'translate(-5px, 0px)'
            });
        }
    }, function () {
        if (window.width >= 1270) {
            TweenMax.to($(this), 0.5, {
                'transform': 'translate(0, 0px)'
            });
        }
    });

    $('.prints_solids_page .products_slider .flex-direction-nav li:last-of-type').hover(function () {
        if (window.innerWidth >= 1270) {
            TweenMax.to($(this), 0.5, {
                repeat: -1,
                yoyo: true,
                'transform': 'translate(5px, 0px)'
            });
        }
    }, function () {
        if (window.innerWidth >= 1270) {
            TweenMax.to($(this), 0.5, {
                'transform': 'translate(0px, 0px)'
            });
        }
    });

}

function renderProducts(oColor, elem) {
    if (oColor) {
        $.ajax({
            url: "/Prints/GetProductsByColor",
            type: "GET",
            data: {
                color: oColor
            }
        })
        .fail(function (jqXHR, textStatus) {
        })
        .done(function (response) {
            if (response.length == 0) { elem.find('.hover_selection .bottom .products').css('height', '0px'); }

            elem.find('.hover_selection .bottom .products').html(response);
            initProductSlider();

        });
    }

}