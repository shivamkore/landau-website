$(function() {

    // Responsive Checker
    var window_width = $(window).width(),
        medium = 1270,
        small = 639,
        very_small = 475;

    //Top Dropdowns
    var animating = false;
    $('.search_bar .right').on('click', function() {
        if (!animating) {
            var timeout = 0;
            if ($('.search_bar .left').hasClass('open')) {
                timeout = 350;
                $('.search_bar .left').click();
            }
            animating = true;
            setTimeout(function() {
                $('.search_bar .right').toggleClass('open');
                $('#where_to_buy .search_bar .international_container').slideToggle(350);
                setTimeout(function() {
                    animating = false;
                }, 350);
            }, timeout);
        }
    });
    $('.search_bar .left').on('click', function() {
        if ($(window).width() <= 1270 && !animating) {
            var timeout = 0;
            if ($('.search_bar .right').hasClass('open')) {
                timeout = 350;
                $('.search_bar .right').click();
            }
            animating = true;
            setTimeout(function() {
                $('.search_bar .left').toggleClass('open');
                $('.search_bar .dropdown_wrapper').slideToggle(350);
                setTimeout(function() {
                    animating = false;
                }, 350);
            }, timeout);
        }
    });

    // U.S. Retailers Zip Position Swap
    enquire.register("screen and (max-width:1270px)", {
        deferSetup: true,
        match: function() {
            var swapTarget = $(".search_bar .left");
            swapTarget.after($('.search_bar .left .input .dropdown_wrapper'));
        },
        unmatch: function() {
            var swapTarget = $(".search_bar .left .input .title");
            swapTarget.after($('.search_bar .dropdown_wrapper'));
            $('.search_bar .dropdown_wrapper').css('display', '');
            $('.search_bar .left').removeClass('open');
        }
    });

    // Locations Slider
    $('.flexslider .slides > li').hide();
    $('.locations .flexslider').flexslider({
        slideshow: false,
        animation: "fade",
        animationSpeed: 650,
        move: 1,
        controlNav: true,
        directionNav: true,
        animationLoop: true,
        start: function(slider) {
            $('body').removeClass('loading');
            $('.flexslider .slides > li').show();
        }
    });


    //Mobile More Details/Less Details
    $('#where_to_buy .locations_container .info_toggle').on('click', function() {
        $(this).siblings('.block').toggleClass('normal_padding');
        $(this).siblings('.block').children('.text:not(.email):not(.phone)').slideToggle(250);
        $(this).children('.more').toggle();
        $(this).children('.less').toggle();
    });

    // Remove styles from slide toggling location details on desktop
    enquire.register("screen and (max-width:767px)", {
        deferSetup: true,
        unmatch: function() {
            $('#where_to_buy .locations_container .location').removeAttr("style");
            $('#where_to_buy .locations_container .location .text').removeAttr("style");
            $('#where_to_buy .locations_container .location .info_toggle span').removeAttr("style");
            $('#where_to_buy .locations_container .location .normal_padding').removeClass("normal_padding");
        }
    });
});

// GOOGLE MAPS
function initialize() {
    var mapCanvas = document.getElementById('map-canvas');
    var mapOptions = {
        zoom: 4,
        center: new google.maps.LatLng('37.4419', '-100.1419'),
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        scrollwheel: false,
        navigationControl: false,
        mapTypeControl: false
    };
    var infoBubble = new InfoBubble({
      map: map,
      shadowStyle: 1,
      padding: 0,
      minHeight: 40,
      backgroundColor: '#FFF',
      borderRadius: 0,
      arrowSize: 15,
      borderWidth: 1,
      borderColor: '#FFF',
      disableAutoPan: true,
      hideCloseButton: true,
      arrowPosition: 50,
      backgroundClassName: 'transparent',
      arrowStyle: 0
    });
    var styles = [{
        "featureType": "administrative",
        "elementType": "labels.text.fill",
        "stylers": [{
            "color": "#444444"
        }]
    }, {
        "featureType": "landscape",
        "elementType": "all",
        "stylers": [{
            "color": "#f2f2f2"
        }]
    }, {
        "featureType": "poi",
        "elementType": "all",
        "stylers": [{
            "visibility": "off"
        }]
    }, {
        "featureType": "road",
        "elementType": "all",
        "stylers": [{
            "saturation": -100
        }, {
            "lightness": 45
        }]
    }, {
        "featureType": "road.highway",
        "elementType": "all",
        "stylers": [{
            "visibility": "simplified"
        }]
    }, {
        "featureType": "road.arterial",
        "elementType": "labels.icon",
        "stylers": [{
            "visibility": "off"
        }]
    }, {
        "featureType": "transit",
        "elementType": "all",
        "stylers": [{
            "visibility": "off"
        }]
    }, {
        "featureType": "water",
        "elementType": "all",
        "stylers": [{
            "color": "#2b90cf"
        }, {
            "visibility": "on"
        }]
    }];
    var map = new google.maps.Map(mapCanvas, mapOptions);
    map.setOptions({
        styles: styles
    });

    // Custom Icons
    var iconBig = new google.maps.MarkerImage('public/images/where_to_buy/location_icon_big.png');
    var iconSmall = new google.maps.MarkerImage('public/images/where_to_buy/location_icon_small.png');

    // DIAMOND DEALERS
    var diamondDealers = [
        ['SCRUBOLOGY #1608', '33.846981', '-117.954189'],
        ['CERRITOS COLLEGE', '33.902237', '-118.081733'],
        ['RED DOT FASHION', '34.074314', '-118.036644']
    ];

    var dd_marker, i;
    for (i = 0; i < diamondDealers.length; i++) {
        dd_marker = new google.maps.Marker({
            position: new google.maps.LatLng(diamondDealers[i][1], diamondDealers[i][2]),
            map: map,
            title: diamondDealers[i][0],
            icon: iconBig
        });

        google.maps.event.addListener(dd_marker, 'mouseover', (function(dd_marker, i) {
            return function() {
                infoBubble.setContent('<div class="title">'+diamondDealers[i][0]+'</div>');
                infoBubble.open(map, dd_marker);
            };
        })(dd_marker, i));
    }
    // END DIAMOND DEALERS

    // RETAIL LOCATIONS
    var retail_locations = [
        ['OC UNIFORMS', '33.782792', '-117.868324'],
        ['KWD UNIFORM', '33.938790', '-117.960036'],
        ['SCRUBS 4 U', '33.458313', '-117.649889'],
        ['SCRUBS 4 U', '33.627620', '-117.724770'],
        ['SCRUBOLOGY #1278', '33.826831', '-118.347692'],
        ['OC UNIFORMS', '33.895789', '-117.929493'],
        ['SCRUBOLOGY #1548', '33.608139', '-117.705726'],
        ['UNIVERSITY OF LAVERNE', '34.100843', '-117.767835']
    ];

    var rl_marker;
    for (i = 0; i < retail_locations.length; i++) {
        rl_marker = new google.maps.Marker({
            position: new google.maps.LatLng(retail_locations[i][1], retail_locations[i][2]),
            map: map,
            title: retail_locations[i][0],
            icon: iconSmall
        });

        google.maps.event.addListener(rl_marker, 'mouseover', (function(rl_marker, i) {
            return function() {
                infoBubble.setContent('<div class="title">'+retail_locations[i][0]+'</div>');
                infoBubble.open(map, rl_marker);
            };
        })(rl_marker, i));
    }
    // END RETAIL LOCATIONS

    // REMOVE LOADING STATUS
    google.maps.event.addListenerOnce(map, 'tilesloaded', function() {
        TweenMax.to($('.map_container .loading'), 0.35, {
            opacity: 0,
            onComplete: function() {
                this.target.hide();
            }
        });
    });

    google.maps.event.addDomListener(window, "resize", function() {
        var center = map.getCenter();
        google.maps.event.trigger(map, "resize");
        map.setCenter(center);
    });

    // Try HTML5 geolocation.
    // if (navigator.geolocation) {
    //     navigator.geolocation.getCurrentPosition(function(position) {
    //         var pos = {
    //             lat: position.coords.latitude,
    //             lng: position.coords.longitude
    //         };
    //         map.setCenter(pos);
    //         map.setZoom(10);
    //     }, function() {
    //         handleLocationError(true, map.getCenter());
    //     });
    // } else {
    //     // Browser doesn't support Geolocation
    //     handleLocationError(false, map.getCenter());
    // }
}

// if( window['google'] != undefined ){
//     google.maps.event.addDomListener(window, 'load', initialize);
// }

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
}
