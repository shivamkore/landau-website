$(function() {
    $(window).load(function() {
        if ( window.innerWidth < 768) {
            setTimeout(function(){
                $('.prints_solids_page .info_slider .flexslider > .content').css('height', '');
            },150);
        } else {
            $('.prints_solids_page .info_slider .flexslider > .content').css('height', $('.prints_solids_page .info_slider .flex-active-slide').css('height'));
        }
    });

    $(window).bind("resize", function() {
        if ( window.innerWidth < 768) {
            setTimeout(function(){
                $('.prints_solids_page .info_slider .flexslider > .content').css('height', '');
            },150);
        } else {
            $('.prints_solids_page .info_slider .flexslider > .content').css('height', $('.prints_solids_page .info_slider .flex-active-slide').css('height'));
        }
    });

    $('.prints_solids_page .info_slider .flexslider').flexslider({
        slideshow: false,
        animation: "fade",
        animationSpeed: 650,
        move: 1,
        directionNav: true,
        // smoothHeight: true,
        slideshowSpeed: 10000,
        animationLoop: true,
        start: function(slider) {
            $('body').removeClass('loading');
            $('.info_slider .flexslider .slides > li').show();
        }
    });

    //Product Dropdown Slider
    $('.prints_solids_page .products_slider .flexslider').flexslider({
        slideshow: false,
        animation: "fade",
        animationSpeed: 650,
        move: 1,
        directionNav: true,
        // smoothHeight: true,
        slideshowSpeed: 10000,
        animationLoop: true,
    });

    $('.prints_solids_page .products_slider .flex-direction-nav li:first-of-type').hover(function() {
        if( window.width >= 1271 ){
            TweenMax.to($(this), 0.5, {
                repeat: -1,
                yoyo: true,
                'transform': 'translate(-5px, 0px)'
            });
        }
    }, function() {
        if( window.width >= 1271 ){
            TweenMax.to($(this), 0.5, {
                'transform': 'translate(0, 0px)'
            });
        }
    });

    $('.prints_solids_page .products_slider .flex-direction-nav li:last-of-type').hover(function() {
        if( window.innerWidth >= 1271 ){
            TweenMax.to($(this), 0.5, {
                repeat: -1,
                yoyo: true,
                'transform': 'translate(5px, 0px)'
            });
        }
    }, function() {
        if( window.innerWidth >= 1271 ){
            TweenMax.to($(this), 0.5, {
                'transform': 'translate(0px, 0px)'
            });
        }
    });


    // Prints
    var timeout = false;
    $('#prints_page .products .product').each(function() {
        $(this).find('.image_icon, .text').click(function() {
            if (!timeout) {
                timeout = true;
                if ($(this).parent().hasClass('active')) {
                    $('.hover_selection .close_btn').click();
                    $(this).parent().removeClass('active');
                } else {
                    var timeDelay = 0;
                    if ($('#prints_page .products .product.active').length) {
                        timeDelay = 600;
                        $('#prints_page .products .hover_selection').slideUp({
                            duration: 600,
                            easing: 'linear',
                            complete: function() {
                                $(this).parent().find('.arrow').css('opacity', 0);
                            }
                        });
                        TweenMax.to($('#prints_page .products .product.active'), 0.6, {
                            'margin-bottom': '0',
                            ease: Power0.easeNone,
                        });
                        $('.product.active').removeClass('active');
                    }

                    var that = this;
                    setTimeout(function() {
                        $(that).parent().addClass('active');
                        var hover_selection = $(that).parent().find('.hover_selection');
                        var hs_height = hover_selection.height() + 60;
                        $(that).parent().find('.arrow').css('opacity', 1);

                        hover_selection.slideDown({
                            duration: 600,
                            easing: 'linear',
                        });

                        TweenMax.to($(that).parent(), 0.6, {
                            'margin-bottom': hs_height,
                            ease: Power0.easeNone,
                            onComplete: function() {
                                timeout = false;
                            }
                        });
                    }, timeDelay);
                }
            }
        });
    });

    $(document).on('click', '.hover_selection .close_btn', function() {
        $('.hover_selection:visible').slideUp({
            duration: 600,
            easing: 'linear',
            complete: function() {
                $(this).parent().find('.arrow').css('opacity', 0);
            }
        });
        TweenMax.to($('#prints_page .products .product.active'), 0.6, {
            'margin-bottom': '0',
            ease: Power0.easeNone,
            onComplete: function() {
                timeout = false;
            }
        });
    });

    $(window).on('resize orientationchange', function() {
        var height = $('.hover_selection:visible').outerHeight(true);
        $('.product.active').css('margin-bottom', height);
    });
});
