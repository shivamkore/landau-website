$(function() {
    //PDP Social Container Placement Swap
    enquire.register("screen and (max-width:767px)", {
        deferSetup: true,
        match: function() {
            var swap_target = $(".detail_top > .right .sizes_container");
            swap_target.after(swap_target.siblings('.social_container'));
        },
        unmatch: function() {
            var swap_target = $(".detail_top > .right .buy_favorites_container");
            swap_target.after(swap_target.siblings('.social_container'));
            $('.center_container .related').css("display", "");
            $('.center_container .buy_now').css("display", "");
            $('.comments').css("display", "");
        }
    });

    //PDP Mobile Dropdowns
    $('.mobile_dropdown').on('click', function() {
        if ($('.mobile_dropdown.open').length && !$(this).hasClass('open')) {
            $('.mobile_dropdown.open').next().slideToggle();
            $('.mobile_dropdown.open').toggleClass('open');
        }
        $(this).toggleClass('open');
        $(this).next().slideToggle();
    });

    //Preview image swap
    var current_img = 1;
    $(".thumbnail_container").on('click', '.thumbnail_img', function () {
        if (!$(this).hasClass('active')) {
            $('.preview_wrapper .active').removeClass('active');
            $(".thumbnail_img.active").removeClass('active');
            $('.zoomed_img_container .active').removeClass('active');

            current_img = $(this).attr('thumbnail');

            $(this).addClass('active');
            $('.zoomed_img_container [zoom=' + current_img + ']').addClass('active');
            $('.preview_wrapper [preview=' + current_img + ']').addClass('active');

            //If video
            if ($('.preview_wrapper [preview=' + current_img + ']').hasClass('preview_video')) {
                TweenMax.to($('.zoom_hint_container'), 0.35, { opacity: 0 });
                if ($(window).width() >= 768) {
                    videos = document.getElementsByClassName("wistia-iframe");
                    for (var i = 0; i < videos.length; i++) {
                        videos[i].wistiaApi.pause();
                    }
                    $('.preview_wrapper [preview=' + current_img + '] .wistia-iframe')[0].wistiaApi.play()
                }
            }
            else {
                TweenMax.to($('.zoom_hint_container'), 0.35, { opacity: 1 });
                if ($(window).width() >= 768) {
                    videos = document.getElementsByClassName("wistia-iframe");
                    for (var i = 0; i < videos.length; i++) {
                        videos[i].wistiaApi.pause();
                    }
                }
            }
        }
    });

    //Preview Image click to zoom reveal
    $(".img_container").on('click', '.preview', function() {
        if ($(window).width() >= 768 && $(this).siblings('.disabled').length == 0 && !$(this).hasClass('disabled')) {
            $('.zoomed_img_container').addClass('active').css('visibility', 'visible');
            //hide video thumbnails for zoom
            $('.thumbnail_container .thumbnail_video').css('display', 'none');
        }
    });

    //Preview Image click to zoom hide
    $(".zoomed_img_container").on('click', function() {
        // debugger;
        $(this).removeClass('active');
        setTimeout(function(){
            $(".zoomed_img_container").css('visibility', 'hidden');
        }, 250);
        $('.thumbnail_container .thumbnail_video').css('display', '');
    });

    //Mouse controls for zoom image
    $(".zoomed_img_container").on('mousemove', function(e) {
        if ( !navigator.userAgent.match(/Android|BlackBerry|iPhone|iPad|iPod|Opera Mini|IEMobile/i)){
            var bg_sp = $(".zoomed_img_container .active");
            var mouseDataX = e.pageX - $(this).offset().left;
            var mouseDataY = e.pageY - $(this).offset().top;
            TweenMax.to(bg_sp, 0.5, {
                x: zther.util.Number.map(mouseDataX, 0, $(this).width(), 0, ($(this).width() - bg_sp.width())),
                overwrite: "auto"
            });
            TweenMax.to(bg_sp, 0.5, {
                y: zther.util.Number.map(mouseDataY, 0, $(this).height(), 0, ($(this).height() - bg_sp.height())),
                overwrite: "auto"
            });
        }
    });

    //Mobile detail image swipe gesture
    var xDown = null;
    var yDown = null;
    var totalSlides = $('.preview_wrapper .preview').length;
    $('.preview_wrapper').on('touchstart', '.preview', handleTouchStart);
    $('.zoomed_img_container').on('touchstart', '.zoom_img', handleTouchStart);
    $('.preview_wrapper').on('touchmove', '.preview', handleTouchMove);
    $('.zoomed_img_container').on('touchmove', '.zoom_img', handleTouchMove);

    function handleTouchStart(evt) {
        xDown = evt.originalEvent.pageX;
    }

    function handleTouchMove(evt) {
        if ( ! xDown ) {
            return;
        }

        var xUp = evt.originalEvent.pageX;

        var xDiff = xDown - xUp;

        TweenMax.to($('.preview_wrapper [preview=' + current_img + ']'), 0.35, {
            opacity: 0
        });
        TweenMax.to($('.zoomed_img_container [zoom=' + current_img + ']'), 0.35, {
            opacity: 0
        });

        if ( xDiff > 0 ) {
            if(current_img == 1){
                current_img = totalSlides;
            }
            else{
                current_img--;
            }
        } else {
            if(current_img == totalSlides){
                current_img = 1;
            }
            else{
                current_img++;
            }
        }

        $(".thumbnail_img.active").removeClass('active');
        $( $(".thumbnail_img")[current_img - 1] ).addClass('active');
        $('.zoomed_img_container .active').removeClass('active');
        $('.zoomed_img_container [zoom=' + current_img + ']').addClass('active');

        TweenMax.to($('.preview_wrapper [preview=' + current_img + ']'), 0.35, {
            opacity: 1
        });
        TweenMax.to($('.zoomed_img_container [zoom=' + current_img + ']'), 0.35, {
            opacity: 1
        });

        /* reset values */
        xDown = null;
    }

    //More Colors Slider
    $('.category_options_wrapper').on('click', '.more_colors', function(){
        $(this).children().toggle();
        $(this).siblings('.color_swatches').toggleClass('opened');
        $('.category_options_wrapper').height(currentTab.height());
    });

    //Sizes selection
    $(".sizes_container").on('click', '.size_option', function() {
        if (!$(this).hasClass('selected')) {
            $(".sizes_container .size_option.selected").removeClass('selected');
            $(this).addClass('selected');
        }
    });

    //Measurement Modal
    var last_position;
    $('.measurement').on('click', function(){
        $('.modal_overlay').addClass('active').css('visibility', 'visible');
        $('.detail_modal').addClass('active').css('visibility', 'visible');
        last_position = $('body').scrollTop();
        $('body').css('overflow', 'hidden');
        if( window.innerWidth < 768){
            $('body').css('position', 'fixed');
        }
    });

    $('.detail_modal .exit, .modal_overlay, .mobile_exit').on('click', function(){
        $('.modal_overlay').removeClass('active');
        $('.detail_modal').removeClass('active');
        setTimeout(function(){
            $('.modal_overlay').css('visibility', 'hidden');
            $('.detail_modal').css('visibility', 'hidden');
        }, 250);
        $('body').css('overflow', '').css('position', '');
        if( window.innerWidth < 768){
            $('body').scrollTop(last_position);
        }
    });

    //Type Container
    var currentTab = $('.category_options_wrapper .category_options_container.active');
    $('.category_container a').on('click', function(){
        $('.category_container a.selected').removeClass('selected');
        $(this).addClass('selected');
        var option = $(this).attr('option');
        currentTab = $('.category_options_wrapper .category_options_container.active');
        nextTab = $('.category_options_wrapper .category_options_container[option='+option+']');

        if (currentTab[0] !== $('.category_options_wrapper .category_options_container[option='+option+']')[0]){
            currentTab.removeClass('active');
            currentTab = $('.category_options_wrapper .category_options_container[option='+option+']');
            currentTab.addClass('active');
            $('.category_options_wrapper').height(currentTab.height());
            $('.category_options_container[option='+option+'] .color_options_container .color_swatches .swatch_container:first-of-type').click();
            $('.category_options_container[option='+option+'] .size_options_container .size_option:first-of-type').click();
        }
    });

    $(window).on('resize', function(){
        $('.category_options_wrapper').height(currentTab.height());
    });

    //Selected Colors
    $('.swatch_container').on('click', function(){
        if( !$(this).hasClass('selected') ){
            $('.swatch_container.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });
});
