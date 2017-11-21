$(function() {
    // FlexSlider Homepage
    $('#homepage .home_slider .flexslider').flexslider({
        slideshow: true,
        animation: "fade",
        slideshowSpeed: 7000,
        animationSpeed: 650,
        move: 1,
        controlNav: true,
        directionNav: true,
        // smoothHeight: true,
        //smoothHeight disabled because slides have 0 height and get size from padding %
        //flexslider looks at height and causes the slides to "disappear" and reappear after animation
        animationLoop: true,
        start: function(slider) {
            $('body').removeClass('loading');
            $('.home_slider .flexslider .slides > li').show();
        }
    });

    $(window).load(function() {
        if ( window.innerWidth < 768) {
            setTimeout(function(){
                $('#homepage .home_slider .flexslider > .content').css('height', $('#homepage .home_slider .flex-active-slide').css('padding-top'));
                $('#homepage .info_slider .flexslider > .content').css('height', '');
            },150);
        } else {
            $('#homepage .home_slider .flexslider > .content').css('height', $('#homepage .home_slider .flex-active-slide').css('height'));
            $('#homepage .info_slider .flexslider > .content').css('height', $('#homepage .info_slider .flex-active-slide').css('height'));
        }
    });

    $(window).bind("resize", function() {
        if ( window.innerWidth < 768) {
            setTimeout(function(){
                $('#homepage .home_slider .flexslider > .content').css('height', $('#homepage .home_slider .flex-active-slide').css('padding-top'));
                $('#homepage .info_slider .flexslider > .content').css('height', '');
            },150);
        } else {
            $('#homepage .home_slider .flexslider > .content').css('height', $('#homepage .home_slider .flex-active-slide').css('height'));
            $('#homepage .info_slider .flexslider > .content').css('height', $('#homepage .info_slider .flex-active-slide').css('height'));
        }
    });

    $('#homepage .info_slider .flexslider').flexslider({
        slideshow: true,
        animation: "fade",
        animationSpeed: 650,
        move: 1,
        directionNav: true,
        // smoothHeight: true,
        //slideshowSpeed: 10000,
        animationLoop: true,
        start: function(slider) {
            $('body').removeClass('loading');
            $('.info_slider .flexslider .slides > li').show();
        }
    });

    //Homepage Main Slider
    $('#homepage .home_slider .flex-direction-nav li:first-of-type').hover(function() {
        TweenMax.to($(this), 0.5, {
            repeat: -1,
            yoyo: true,
            'transform': 'translate(-5px, 0px)'
        });
    }, function() {
        TweenMax.to($(this), 0.5, {
            'transform': 'translate(0, 0px)'
        });
    });

    $('#homepage .home_slider .flex-direction-nav li:last-of-type').hover(function() {
        TweenMax.to($(this), 0.5, {
            repeat: -1,
            yoyo: true,
            'transform': 'translate(5px, 0px)'
        });
    }, function() {
        TweenMax.to($(this), 0.5, {
            'transform': 'translate(0px, 0px)'
        });
    });

    //Zipcode Validation
    /*function IsValidZipCode(zip) {
        var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(zip);
        if (isValid)
            return true;
        else {
            return false;
        }
    }

    $('#zipcode input[type="submit"]').on('click', function(e){
        if( !IsValidZipCode( $('#zipcode input[type="text"]').val() ) ){
            $('#zip-validation').fadeIn();
            $('html, body').animate({
                scrollTop: $('#zipcode input[type="text"]').offset().top
            }, 500);
            $('#zipcode input[type="text"]').focus();
            e.preventDefault();
        }
        else{
            $('#zip-validation').fadeOut();
        }
    });*/

    //Video Controller
    var videoURL;

    $(".flexslider .slides .home-slider-0").hover(function () {
        $(this).css("cursor", "pointer");
    });

    $(".video_container, .home-slider-0").on('click', function () {
        var wistia_video = Wistia.api("wistia_video");

        var videoURL = $('iframe.wistia_embed').prop('src');
        videoURL += "?videoFoam=true&autoPlay=true";

        $('iframe.wistia_embed').prop('src', videoURL);
        $('#video_overlay').fadeIn();

        $('#video_popup').show();
        wistia_video.play();
    });

    $('#video_overlay').on('click', function () {
        var wistia_video = Wistia.api("wistia_video");

        var videoURL = $('iframe.wistia_embed').prop('src');
        videoURL = videoURL.replace("?videoFoam=true&autoPlay=true", "");

        $('iframe.wistia_embed').prop('src', videoURL);
        $('#video_overlay').fadeOut();

        $('#video_popup').hide();
        wistia_video.pause();
    });
});
