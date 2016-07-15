$(function() {

    $(window).load(function() {
        if ( window.innerWidth < 768) {
            setTimeout(function(){
                $('#collections .info_slider .flexslider > .content').css('height', '');
            },150);
        } else {
            $('#collections .info_slider .flexslider > .content').css('height', $('#collections .info_slider .flex-active-slide').css('height'));
        }
    });

    $(window).bind("resize", function() {
        if ( window.innerWidth < 768) {
            setTimeout(function(){
                $('#collections .info_slider .flexslider > .content').css('height', '');
            },150);
        } else {
            $('#collections .info_slider .flexslider > .content').css('height', $('#collections .info_slider .flex-active-slide').css('height'));
        }
    });

    $('#collections .info_slider .flexslider').flexslider({
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

    //Collections Category Hero Image Placement Swap
    enquire.register("screen and (max-width:990px)", {
        deferSetup: true,
        match: function() {
            var swap_target = $("#collections .seasonal_container .category_container.left");
            swap_target.before(swap_target.next());
        },
        unmatch: function() {
            var swap_target = $("#collections .seasonal_container .category_container.left");
            swap_target.after(swap_target.prev());
        }
    });

    if ($('#collections .fit_text').length) {
        $('#collections .fit_text').fitText(1.5);
    }

    function disableFitText() {
        if ( window.innerWidth >= 768) {
            $('#collections .fit_text').css('font-size', '');
        }
    }

    disableFitText();

    $(window).on('resize orientationchange', disableFitText);
});
