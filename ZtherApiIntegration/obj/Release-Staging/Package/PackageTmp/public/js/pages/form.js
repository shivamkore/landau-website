$(function(){
    var lastFocusedElement = null;
    var isClick = false;
    $('input, textarea').mousedown(function(e) {
        isClick = true;
        setTimeout(function() {
            isClick = false;
        }, 0);
    }).focus(function(e){
        if (isClick) {
        } else {
            var center = $(window).height()/2;
            var top = $(this).offset().top ;
            if (top > center){
            	$(window).scrollTop(top-center);
            }
        }
        lastFocusedElement = e.target;
        isClick = false;
    });

    $(document.body).focus(function(){
      lastFocusedElement = document.body;
    });

    //Radio/Checkbox Button Hidden Input
    $('.radio_btn, .checkbox_btn').on('click', function() {
        isClick = true;
        if ($(this).prev("input").checked) {
            $(this).prev("input").checked = false;
        } else {
            $(this).prev("input").checked = true;
        }
    });

    $('label').on('click', function(e) {
        isClick= true;
    });

    //Remove/Add required field to (select one or both) field
    $('input[name="check1"]').on('click',function(){
        if( $('input[name="check1"]:checkbox:checked').length > 0){
            $('input[name="check1"]').removeAttr('required');
        }
        else{
            $('input[name="check1"]').attr('required', 'true');
        }
    });

    $('.placeholder').on('click', function(){
        if( !$(this).parent().hasClass('open') ){
            $('.desktop.open').find('.options_container').fadeToggle(350);
            $('.desktop.open').toggleClass('open');
        }
        $(this).parent().toggleClass('open');
        $(this).next('.options_container').fadeToggle(350);
    });

    $('.form_container form .select .mobile').change(function(){
        var value = $(this).val();
        $(this).siblings('.desktop').find('.placeholder').attr('value', value);
        $(this).siblings('.desktop').find('.placeholder').html(value);
    });

    $('.options_container a').on('click', function(e){
        var container = $(this).closest('.desktop');
        var value = $(this).attr('value');
        var title = $(this).html();
        var target = $(this).closest('.desktop').children('.placeholder');

        target.attr('value', value).html(title);
        $(this).closest('.select').find('select').val(value);
        $('.desktop.open').find('.options_container').fadeToggle(350);
        $('.desktop.open').toggleClass('open');
    });

    $(document).mouseup(function (e)
    {
        var container = $(".placeholder");

        if (!container.is(e.target) // if the target of the click isn't the container...
            && container.next('.options_container').has(e.target).length === 0) // ... nor a descendant of the container
        {
            $('.desktop.open').find('.options_container').fadeToggle(350);
            $('.desktop.open').toggleClass('open');
        }
    });

    var scrollables = document.getElementsByClassName('scrollable');

    for (var i = 0; i < scrollables.length; i++) {
        Ps.initialize(scrollables[i]);
    }

    $('.scrollable').on('mouseover', function(){
        Ps.update(this);
    });

    $( '.scrollable' ).bind( 'mousewheel DOMMouseScroll', function ( e ) {
        var e0 = e.originalEvent,
        delta = e0.wheelDelta || -e0.detail;

        this.scrollTop += ( delta < 0 ? 1 : -1 ) * 30;
        e.preventDefault();
    });

    //Select mouse outs
    var selectTimer;
    var selectTarget;
    function hideSelectDropdown() {
        clearInterval(selectTimer);
        $(selectTarget).find('.select_dropdown').fadeOut(350);
        $(selectTarget).find('.select_dropdown_parent').removeClass('open');
    }

    $('.select').on('mouseleave', function(){
        if( $(this).find('.select_dropdown_parent.open').length ){
            selectTarget = this;
            selectTimer = setInterval(hideSelectDropdown, 500);
        }
    });

    $('.select').on('mouseenter', function() {
        clearInterval(selectTimer);
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

    $('.form_container input[type="submit"]').on('click', function(e){
        if( $('.zipcode_container input[type="text"]').length ){
            if( !IsValidZipCode( $('.zipcode_container input[type="text"]').val() ) ){
                $('#zip-validation').fadeIn();
                var center = $(window).height()/2;
                var top = $('.zipcode_container input[type="text"]').offset().top ;
                if (top > center){
                	$(window).scrollTop(top-center);
                }
                $('.zipcode_container input[type="text"]').focus();
                e.preventDefault();
            }
            else{
                $('#zip-validation').fadeOut();
            }
        }
    });*/
});
