var zther = zther || {};
zther.util = zther.util || {};
zther.util.Number = {

    map: function(value, min1, max1, min2, max2) {
        return min2 + (max2 - min2) * ((value - min1) / (max1 - min1));
    },

    constrain: function(value, firstValue, secondValue) {
        return Math.min(Math.max(value, Math.min(firstValue, secondValue)), Math.max(firstValue, secondValue));
    },

    isBetween: function(value, firstValue, secondValue) {
        return !(value < Math.min(firstValue, secondValue) || value > Math.max(firstValue, secondValue));
    },

    loopIndex: function(index, length) {
        if (index < 0) {
            index = length + index % length;
        }

        if (index >= length) {
            return index % length;
        }

        return index;
    }

    /*normalize : function(value, minimum, maximum):Percent {
    	return new Percent((value - minimum) / (maximum - minimum));
    }*/
};

$(function() {
    //Block Hovers with CTA's
    $('.block').hover(function() {
        if ($(window).width() >= 990) {
            $(this).find('.cta').addClass('cta-hover');
            TweenMax.to($(this).children('.overlay_img'), 0.35, {
                'transform': 'scale(1.05) rotate(0.1deg)'
            });
        }
    }, function() {
        if ($(window).width() >= 990) {
            $(this).find('.cta').removeClass('cta-hover');
            TweenMax.to($(this).children('.overlay_img'), 0.35, {
                'transform': 'scale(1) rotate(0.1deg)'
            });
        }
    });

    //Safari does not support the 'required' attribute on inputs so this will
    //send simple alert popup if required fields are empty
    $("form").submit(function(e) {
        var ref = $(this).find("[required]");

        $(ref).each(function(){
            if ( $(this).val() == '' )
            {
                alert("Required field should not be blank.");

                $(this).focus();

                e.preventDefault();
                return false;
            }
        });  return true;
    });
});

$(function() {
    var animatingSlideoutOverlay = false;
    $('#slideout_overlay').on('touchstart mousedown', function() {
        setTimeout(function() {
            animatingSlideoutOverlay = false;
        }, 400);
        if (!animatingSlideoutOverlay) {
            animatingSlideoutOverlay = true;
            $('#side_nav_button').children('.icon-bar').fadeToggle(500);
            $('#side_nav_button').children('.x-icon').fadeToggle(500);
            $('#side_nav_button').removeClass('open');
            TweenMax.to($('#slideout_overlay'), 0.35, {
                opacity: 0,
                force3D: true,
                onComplete: function() {
                    this.target.hide();
                }
            });
            TweenMax.to($('body'), 0.35, {
                'transform': 'translate(0px, 0px)',
                force3D: true,
                onComplete: function() {
                    TweenLite.set(this.target, {
                        clearProps: "all"
                    });
                }
            });
        }
    });

    var navHeight = $(window).height();
    $('#main_nav_side').css('height', navHeight);
    $(window).resize(function() {
        navHeight = $(window).height();
        $('#main_nav_side').css('height', navHeight);
    });

    //Side Nav Button Mobile
    $('#side_nav_button').on('click', function() {
        $(this).children('.icon-bar').fadeToggle(500);
        $(this).children('.x-icon').fadeToggle(500);
        if ($(this).hasClass('open')) {
            $(this).removeClass('open');
            TweenMax.to($('#slideout_overlay'), 0.35, {
                opacity: 0,
                force3D: true,
                onComplete: function() {
                    this.target.hide();
                }
            });
            TweenMax.to($('body'), 0.35, {
                'transform': 'translate(0px, 0px)',
                force3D: true,
                onComplete: function() {
                    TweenLite.set(this.target, {
                        clearProps: "all"
                    });
                }
            });
        } else {
            $('body').css('height', navHeight).css('overflow', 'hidden').css('position', 'fixed');
            $(this).addClass('open');
            $("html, body").animate({
                scrollTop: 0
            }, 0);

            TweenMax.to($('#slideout_overlay'), 0.35, {
                opacity: 0.4,
                force3D: true,
                onStart: function() {
                    this.target.show();
                }
            });

            if ($(window).width() >= 768) {
                TweenMax.to($('body'), 0.35, {
                    force3D: true,
                    'transform': 'translate(346px, 0px)'
                });
            } else {
                TweenMax.to($('body'), 0.35, {
                    force3D: true,
                    'transform': 'translate(221px, 0px)'
                });
            }
        }
    });

    //Main Nav Dropdown Hover
    var hideTimer;

    function showDropdownMenu(source) {
        if ($('#main_nav .dropdown-active').length) {
            $('#main_nav .dropdown-active .dropdown-menu')
                .css('opacity', '0')
                .hide();
            $('#main_nav .dropdown-active').removeClass('dropdown-active');
            $(source).parent().addClass('dropdown-active');
            $('#main_nav .dropdown-active .dropdown-menu')
                .css('opacity', '1')
                .show();
        } else {
            $(source).parent().addClass('dropdown-active');
            TweenMax.to($('#main_nav .dropdown-active .dropdown-menu'), 0.35, {
                opacity: 1,
                onStart: function() {
                    this.target.show();
                }
            });
        }
    }

    function hideDropdownMenu() {
        clearInterval(hideTimer);
        TweenMax.to($('#main_nav .dropdown-active .dropdown-menu'), 0.35, {
            opacity: 0,
            onComplete: function() {
                this.target.hide();
                $('#main_nav .dropdown-active').removeClass('dropdown-active');
            }
        });
    }

    $('#main_nav .dropdown-toggle').on('mouseenter', function() {
        clearInterval(hideTimer);
        showDropdownMenu(this);
    });

    $('#main_nav .dropdown .dropdown-menu').on('mouseenter', function() {
        clearInterval(hideTimer);
    });

    $('#main_nav .dropdown-toggle, #main_nav .dropdown .dropdown-menu').on('mouseleave', function() {
        hideTimer = setInterval(hideDropdownMenu, 500);
    });

    //Mobile header dropdown tap
    $("body").on('touchstart', function(e) {
        if (!($(e.target).hasClass('dropdown-menu') || $(e.target).closest('.dropdown-menu').length > 0 || $(e.target).hasClass('dropdown-toggle'))) {
            hideDropdownMenu();
        } else if ($(e.target).parent().hasClass('dropdown-active')) {
            hideDropdownMenu();
        } else if ($(e.target).hasClass('dropdown-toggle')) {
            showDropdownMenu($(e.target));
        }
    });

    //Side Nav Dropdowns Mobile
    $('#main_nav_side .dropdown').on('click', function() {
        if ($(this).hasClass('opened')) {
            $('#main_nav_side .dropdown.opened').children('.dropdown-menu').slideToggle();
            $('#main_nav_side .dropdown.opened').removeClass('opened');
        } else {
            $('#main_nav_side .dropdown.opened').children('.dropdown-menu').slideToggle();
            $('#main_nav_side .dropdown.opened').removeClass('opened');
            $(this).addClass('opened');
            $(this).children('.dropdown-menu').slideToggle();
        }
    });

    //Search Bar Mobile
    $('#search-button').on('click', function() {
        $(this).children('.x-icon').fadeToggle(500);
        $(this).children('.mag-icon').fadeToggle(500);
        $('#navbar-search').slideToggle();
    });

    function clearSideNav() {
        if ($('#side_nav_button').hasClass('open')) {
            $('#side_nav_button').children('.icon-bar').fadeToggle(0);
            $('#side_nav_button').children('.x-icon').fadeToggle(0);
            $('#side_nav_button').removeClass('open');
            TweenLite.set($('body'), {
                clearProps: "all"
            });
            TweenLite.set($('#slideout_overlay'), {
                clearProps: "all"
            });
        }
    }

    //Reset Body if nav is open and resized to desktop
    enquire.register("screen and (min-width:768px) and (max-width:989px)", {
        deferSetup: true,
        unmatch: function() {
            clearSideNav();
        }
    });

    //Reset Body if nav is open and resized from mobile to tablet
    enquire.register("screen and (max-width:767px)", {
        deferSetup: true,
        unmatch: function() {
            clearSideNav();
        }
    });
});
