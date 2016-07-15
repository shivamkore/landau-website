$(function() {

    //Demo for preloader
    setTimeout(function(){
        $('#catalog_container .loading_mask').fadeOut();
    }, 2000);

    $(window).load(function() {
        if ( window.innerWidth < 768) {
            setTimeout(function(){
                $('#catalog_container .info_slider .flexslider > .content').css('height', '');
            },150);
        } else {
            $('#catalog_container .info_slider .flexslider > .content').css('height', $('#catalog_container .info_slider .flex-active-slide').css('height'));
        }
    });

    $(window).bind("resize", function() {
        if ( window.innerWidth < 768) {
            setTimeout(function(){
                $('#catalog_container .info_slider .flexslider > .content').css('height', '');
            },150);
        } else {
            $('#catalog_container .info_slider .flexslider > .content').css('height', $('#catalog_container .info_slider .flex-active-slide').css('height'));
        }
    });

    $('#catalog_container .info_slider .flexslider').flexslider({
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

    function filterPadding(){
        var filterMax = 0;
        $('.select:not(.sort_by)').each(function(){
            filterCount = $(this).children('.filter_list').children().length;
            if( filterCount > filterMax){
                filterMax = filterCount;
            }
        });
        //set padding based on highest column of filters
        padding = filterMax * 20;
        $('.filters:not(.mobile-filters').css('padding-bottom', padding+'px');
    }

    filterPadding();

    $('#catalog_container .filters .select').on('click', function(event) {
        target = event.target;
        //if clicked element is a filter
        if ( $(target).is('a') ) {
            //if clicked element is a filter exit button
            if ( $(target).parent().hasClass('filter_list')){
                value = $(target).attr("value");
                $(this).find(".select_group [value='"+value+"']").removeClass('active');
                $(target).remove();
            }
            //if element is a filter not in sort by (to allow multiple filters)
            else if ( !$(this).hasClass('sort_by') ) {
                //create filter close
                if( !$(target).hasClass('active') ){
                    value = $(target).attr("value");
                    text = $(target).html();
                    $(this).children('.filter_list').append('<a value="'+value+'">'+text+'</div>');
                }
                //remove filter close
                else{
                    value = $(target).attr("value");
                    $(this).children('.filter_list').find('[value="'+value+'"]').remove();
                }
                $(target).toggleClass('active');
            }
            //element is a filter in sort by (to only allow one filter active at time)
            else{
                if ( $(target).hasClass('active') ) {
                    $(target).removeClass('active');
                }
                else{
                    $(this).find('.select_group').children().removeClass('active');
                    $(target).addClass('active');
                }
            }
            filterPadding();
        }
        //clicked element is the dropdown
        else{
            if (!$(this).find('.select_group:visible').length) {
                //if there is a visible select_group, hide them all
                $('#catalog_container .filters .select_group:visible').fadeToggle('fast');
            }
            $(this).find('.select_group').fadeToggle('fast');
        }
    });

    var scrollTop;
    $('#catalog_container .filter_button_wrapper.right .filter_button').on('click', function() {
        scrollTop = $(window).scrollTop();
        TweenMax.to($('#catalog_container .mobile_right_filters'), 0.35, {
            '-ms-transform': 'translate(0,0)',
            '-webkit-transform': 'translate(0,0)',
            'transform': 'translate(0,0)',
            onComplete: function() {
                $('body').css('overflow', 'hidden').css('position', 'fixed');
            }
        });
    });

    $('#catalog_container .mobile_right_filters .exit_btn').on('click', function() {
        $('body').css('overflow', '').css('position', '');
        $(window).scrollTop(scrollTop);
        TweenMax.to($('#catalog_container .mobile_right_filters'), 0.35, {
            '-ms-transform': 'translate(' + $(window).width() + 'px,0)',
            '-webkit-transform': 'translate(' + $(window).width() + 'px,0)',
            'transform': 'translate(' + $(window).width() + 'px,0)',
            onComplete: function() {
                TweenLite.set(this.target, {
                    clearProps: "all"
                });
            }
        });
    });

    //Side Nav Dropdowns Mobile
    $('#catalog_container .mobile_right_filters .dropdown').on('click', function(event) {
        target = event.target;
        if( $(target).is('a') && !$(target).hasClass('dropdown-toggle') ) {
            if ( !$(target).closest('.ul-category').hasClass('sort_by') ) {
                $(target).parent().toggleClass('active');
            }
            //element is a filter in sort by (to only allow one filter active at time)
            else{
                if ( $(target).hasClass('active') ) {
                    $(target).parent().removeClass('active');
                }
                else{
                    $(target).parent().siblings().removeClass('active');
                    $(target).parent().addClass('active');
                }
            }
        }
        else{
            if ($(this).hasClass('opened')) {
                $('#catalog_container .mobile_right_filters .dropdown.opened').children('.dropdown-menu').slideToggle();
                $('#catalog_container .mobile_right_filters .dropdown.opened').removeClass('opened');
            } else {
                $('#catalog_container .mobile_right_filters .dropdown.opened').children('.dropdown-menu').slideToggle();
                $('#catalog_container .mobile_right_filters .dropdown.opened').removeClass('opened');
                $(this).addClass('opened');
                $(this).children('.dropdown-menu').slideToggle();
            }
        }
    });

    //Reset Body if filters are open and resized from mobile to tablet
    enquire.register("screen and (max-width:767px)", {
        deferSetup: true,
        unmatch: function() {
            $('body').css('overflow', '').css('position', '');
            TweenLite.set( $('#catalog_container .mobile_right_filters') , { clearProps: "all" });
        }
    });

    //Select mouse outs
    var selectTimer;
    var selectTarget;
    function hideSelectDropdown() {
        clearInterval(selectTimer);
        $(selectTarget).find('.select_group').fadeOut(350);
    }

    $('.select').on('mouseleave', function(){
        if( $(this).find('.select_group:visible').length ){
            selectTarget = this;
            selectTimer = setInterval(hideSelectDropdown, 500);
        }
    });

    $('.select').on('mouseenter', function() {
        clearInterval(selectTimer);
    });

    $('#catalog').on('click', '.back_to_top', function(){
        $('html, body').animate({scrollTop: '0px'}, 750, 'swing');
    });
});
