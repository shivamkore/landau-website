$(function() {
    //Fitguide Detail Page

    $('.play_btn .play').on('click', function(){
        $('.video_overlay').addClass('active').css('visibility', "visible");
        $('.video_container').show();
        $('.video_exit').fadeIn(250);
        videoURL = $('#iframe').prop('src');
        videoURL += "&autoplay=1";
        $('#iframe').prop('src',videoURL);
    });

    $('.video_overlay, .video_exit').on('click', function(){
        $('.video_overlay').toggleClass('active');
        $('.video_container').hide();
        $('.video_exit').fadeOut(250);
        videoURL = $('#iframe').prop('src');
        videoURL = videoURL.replace("&autoplay=1", "");
        $('#iframe').prop('src','');
        $('#iframe').prop('src',videoURL);
        setTimeout(function(){
            $('.video_overlay').css('visibility', "hidden");
        },250);
    });

    $('.fitguide_content .fit_guide .size').click(function() {
        $('.size_chart_flyout .close_col').addClass('open');
        $('.fitguide_content').animate({
            left: '-100%'
        }, 500);
        $('.size_chart_flyout').animate({
            left: '0%'
        }, 500, function() {
            $('.fitguide_content').hide();
            $('.size_chart_flyout').css('position', 'relative');
            $('html, body').animate({
                scrollTop: $(".main_content").offset().top - page_base
            }, 350);
        });
    });

    $('.size_chart_flyout .close_col').click(function() {
        $('.size_chart_flyout').css('position', 'absolute');
        $('.fitguide_content').show();
        $('.fitguide_content').animate({
            left: '0%'
        }, 500);
        $('.size_chart_flyout').animate({
            left: '100%'
        }, 500, function() {
            $('html, body').animate({
                scrollTop: $(".main_content").offset().top - page_base
            }, 350);
        });
        if ($('.size_chart_flyout .close_col').hasClass('open') && $('.size_chart_flyout .close_col').css('position') === "fixed") {
            $(this).animate({
                left: '100%'
            }, 500, function() {
                $('.size_chart_flyout .close_col')
                    .css('position', '')
                    .css('left', '');
            });
        }
        $('.size_chart_flyout .close_col').removeClass('open');
    });

    $('.fitguide_content .fit_guide .fit').click(function() {
        $('.diagrams_flyout .close_col').addClass('open');
        $('.fitguide_content').animate({
            left: '-100%'
        }, 500);
        $('.diagrams_flyout').animate({
            left: '0%'
        }, 500, function() {
            $('.fitguide_content').hide();
            $('.diagrams_flyout').css('position', 'relative');
            $('html, body').animate({
                scrollTop: $(".main_content").offset().top - page_base
            }, 350);
        });
    });

    $('.diagrams_flyout .close_col').click(function() {
        $('.diagrams_flyout').css('position', 'absolute');
        $('.fitguide_content').show();
        $('.fitguide_content').animate({
            left: '0%'
        }, 500);
        $('.diagrams_flyout').animate({
            left: '100%'
        }, 500, function() {
            $('html, body').animate({
                scrollTop: $(".main_content").offset().top
            }, 350);
        });
        if ($('.diagrams_flyout .close_col').hasClass('open') && $('.diagrams_flyout .close_col').css('position') === "fixed") {
            $(this).animate({
                left: '100%'
            }, 500, function() {
                $('.diagrams_flyout .close_col')
                    .css('position', '')
                    .css('left', '');
            });
        }
        $('.diagrams_flyout .close_col').removeClass('open');
    });

    var main_content;
    $(window).on('resize load orientationchange', function() {
        if( $('.main_content').length ){
            main_content = $('.main_content').position().top + $('#fitguide_detail_page').position().top;
        }
        if ($('.close_col').length > 0) {
            var base = $('.close_col').offset().top;
            var page_base = $('#fitguide_detail_page').position().top;
        }
    });

    if ($('.close_col').length > 0) {
        var base = $('.close_col').offset().top;
        var page_base = $('#fitguide_detail_page').position().top;
    }

    $(window).scroll(function() {
        if( $('.main_content').length ){
            if ($('.main_content').position().top + $('#fitguide_detail_page').position().top <= $(window).scrollTop()
                && $('.close_col.open').length && $(window).width() < 990 ){
                $('.close_col.open').css('position', 'fixed');
            } else {
                $('.close_col').css('position', '');
            }
        }
        if( $('.close_col.open').length && $(window).width() >= 990 ){
            if( $(window).scrollTop() + $('#fitguide_detail_page').position().top > base){
                $('.close_col.open').css('position', 'fixed').css('top', page_base);
            }
            else{
                $('.close_col.open').css('position', '').css('top', '');
            }
        }
    });
});
