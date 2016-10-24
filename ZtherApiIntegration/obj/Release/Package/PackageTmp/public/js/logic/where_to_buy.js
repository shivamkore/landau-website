$(function () {
    searchValues = {
        pageNum: 1,
        filter:null
    };

    $('.search_bar .right li a').on('click', function () {
        $(this).parent().addClass("selected");
    });

    $(".search_bar .left button").on('click', function (e) {
        onSearchClick(e);
    });

    $(".search_bar .left .text").keypress(function (event) {
        if (window.event)
            key = window.event.keyCode;     //IE
        else
            key = e.which;     //firefox

        if (key == 13) {
            onSearchClick(event);
            event.keyCode = 0
        }
    });

    function onSearchClick(e) {
        e.preventDefault();
        whereToBuy.searchRetailers();
    }

    //first load, location container is hidden
    $(".locations_container").css('display', 'none')

    whereToBuy.map = whereToBuy.initMap();

    var query = whereToBuy.getQueryStringValue(document.location);
    if (isNaN(query) && query.filter.length> 0)
    {
        $(".search_bar .dropdown_wrapper input").val(decodeURI(query.filter));
        whereToBuy.searchRetailers();
    }

});

var whereToBuy = {
    map: null,
    infoBubble: null,
    arr_rl_marker: [],
    arr_dd_marker: [],
    iniSlider: function() {
        $('.locations .flexslider').flexslider({
            animation: "fade",
            animationSpeed: 650,
            slideshow: false,
            move: 1,
            controlNav: true,
            directionNav: true,
            animationLoop: true,
            start: function (slider) {
                $('body').removeClass('loading');
                $('.flexslider .slides > li').show();
            }
        });
    },
    initInfoToggle: function () {
        //Mobile More Details/Less Details
        $('#where_to_buy .locations_container .info_toggle').on('click', function () {
            $(this).siblings('.block').toggleClass('normal_padding');
            $(this).siblings('.block').children('.text:not(.email):not(.phone)').slideToggle(250);
            $(this).children('.more').toggle();
            $(this).children('.less').toggle();
        });

        // Remove styles from slide toggling location details on desktop
        enquire.register("screen and (max-width:767px)", {
            deferSetup: true,
            unmatch: function () {
                $('#where_to_buy .locations_container .location').removeAttr("style");
                $('#where_to_buy .locations_container .location .text').removeAttr("style");
                $('#where_to_buy .locations_container .location .info_toggle span').removeAttr("style");
                $('#where_to_buy .locations_container .location .normal_padding').removeClass("normal_padding");
            }
        });

    },
    getQueryStringValue: function(url) {
        var queries = {};
        $.each(url.search.substr(1).split('&'), function (c, q) {
            var i = q.split('=');
            if (i[0].length > 0) {
                queries[i[0].toString()] = i[1].toString();
            }
            else { queries = null; }
        });
        return queries;
    },
    showLoading: function () {
        $('#map-canvas').css('visibility', 'hidden');
        $('.map_container .loading').css('opacity', 1).show();
    },
    hideLoading: function () {
        $('.map_container .loading').css('opacity', 0).hide();
        $('#map-canvas').css('visibility', 'visible');
    },
    searchRetailers: function () {
        this.clearAllMarkers();
        searchValues.filter = $(".search_bar .dropdown_wrapper input").val();
        if (searchValues.filter.length > 0) {

            whereToBuy.showLoading();

            $.ajax({
                url: "/WhereToBuy/SearchRetailers",
                type: "GET",
                data: {
                    filter: searchValues.filter
                }
            })
            .fail(function (jqXHR, textStatus) {
            })
            .done(function (response) {
                $(".locations_container").css('display', 'block');

                $("#retailDealer").html(response.retailersView);
                $("#retailsDiamond").html(response.diamondsView);

                var location = ['', '37.4419', '-100.1419'];
                if (retail_locations.length > 0)
                    location = retail_locations[0];
                else if (diamondDealers.length > 0)
                    location = diamondDealers[0];

                //initialize();
               whereToBuy.addMarkers();
               whereToBuy.map.panTo(new google.maps.LatLng(location[1], location[2]));

                 whereToBuy.hideLoading();
                whereToBuy.iniSlider();
                whereToBuy.initInfoToggle();
                searchValues.pageNum = 1;
            });
        }
    },
    refreshRetailers: function() {
        $.ajax({
            url: "/WhereToBuy/RefreshRetailers",
            type: "GET",
            data: {
                filter: searchValues.filter,
                pageNumber: searchValues.pageNum
            }
        })
        .fail(function (jqXHR, textStatus) {
        })
        .done(function (response) {
            $(".locations_container").css('display', 'block');

            $("#retailDealer").html(response);

            var location = ['', '37.4419', '-100.1419'];
            if (retail_locations.length > 0) { location = retail_locations[0]; }
            //initialize();
            whereToBuy.addMarkers();
            whereToBuy.map.panTo(new google.maps.LatLng(location[1], location[2]));

            whereToBuy.hideLoading();
            whereToBuy.iniSlider();
            whereToBuy.initInfoToggle();

        });

    },
    initMap: function () {
        console.log('init of Google Maps');

        var mapCanvas = document.getElementById('map-canvas');
        var mapOptions = {
            zoom: 4,
            center: new google.maps.LatLng('37.4419', '-100.1419'),
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            scrollwheel: false,
            navigationControl: false,
            mapTypeControl: false
        };

        whereToBuy.infoBubble = new InfoBubble({
            map: whereToBuy.map,
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

        for (var i = 0; i < diamondDealers.length; i++) {
            diamondDealers[i].setMap(null);
        }

        for (var i = 0; i < retail_locations.length; i++) {
            retail_locations[i].setMap(null);
        }

        // REMOVE LOADING STATUS
        google.maps.event.addListenerOnce(map, 'tilesloaded', function () {
            TweenMax.to($('.map_container .loading'), 0.35, {
                opacity: 0,
                onComplete: function () {
                    this.target.hide();
                }
            });
        });

        google.maps.event.addDomListener(window, "resize", function () {
            var center = map.getCenter();
            google.maps.event.trigger(map, "resize");
            map.setCenter(center);
        });

        // Try HTML5 geolocation.
        // if (navigator.geolocation) {
        //     navigator.geolocation.getCurrentPosition(function (position) {
        //         var pos = {
        //             lat: position.coords.latitude,
        //             lng: position.coords.longitude
        //         };
        //         map.setCenter(pos);
        //     }, function () {
        //         handleLocationError(true, map.getCenter());
        //     });
        // } else {
        //     // Browser doesn't support Geolocation
        //     handleLocationError(false, map.getCenter());
        // }

        return map;
    },
    addMarkers: function () {
        whereToBuy.map.setZoom(10);
        var iconBig = new google.maps.MarkerImage('public/images/where_to_buy/location_icon_big.png');
        var iconSmall = new google.maps.MarkerImage('public/images/where_to_buy/location_icon_small.png');


        var dd_marker, i;
        for (i = 0; i < diamondDealers.length; i++) {
            dd_marker = new google.maps.Marker({
                position: new google.maps.LatLng(diamondDealers[i][1], diamondDealers[i][2]),
                map: whereToBuy.map,
                title: diamondDealers[i][0],
                icon: iconBig
            });

            whereToBuy.arr_rl_marker.push(dd_marker);

            google.maps.event.addListener(dd_marker, 'mouseover', (function (dd_marker, i) {
                return function () {
                    whereToBuy.infoBubble.setContent('<div class="title">' + diamondDealers[i][0] + '</div>');
                    whereToBuy.infoBubble.open(whereToBuy.map, dd_marker);
                };
            })(dd_marker, i));
        }
        // END DIAMOND DEALERS

        var rl_marker;
        for (i = 0; i < retail_locations.length; i++) {
            rl_marker = new google.maps.Marker({
                position: new google.maps.LatLng(retail_locations[i][1], retail_locations[i][2]),
                map: whereToBuy.map,
                title: retail_locations[i][0],
                icon: iconSmall
            });

            whereToBuy.arr_rl_marker.push(rl_marker);

            google.maps.event.addListener(rl_marker, 'mouseover', (function (rl_marker, i) {
                return function () {
                    whereToBuy.infoBubble.setContent('<div class="title">' + retail_locations[i][0] + '</div>');
                    whereToBuy.infoBubble.open(whereToBuy.map, rl_marker);
                };
            })(rl_marker, i));
        }
        // END RETAIL LOCATIONS
    },
    clearAllMarkers: function () {
        this.removeMarkers(whereToBuy.arr_rl_marker);
        this.removeMarkers(whereToBuy.arr_dd_marker);
    },
    removeMarkers: function (array) {
        for (var i = 0; i < array.length; i++) {
            array[i].setMap(null);
        }
    }
}

function nextPage() {
    //avoid multiple requests before loading data
    $('.next.page_button').first().removeAttr('href');
    $('.prev.page_button').first().removeAttr('href');

    searchValues.pageNum++;
    whereToBuy.removeMarkers(whereToBuy.arr_rl_marker);
    whereToBuy.refreshRetailers();
}

function previousPage() {
    //avoid multiple requests before loading data
    $('.next.page_button').first().removeAttr('href');
    $('.prev.page_button').first().removeAttr('href');

    searchValues.pageNum--;
    whereToBuy.removeMarkers(whereToBuy.arr_rl_marker);
    whereToBuy.refreshRetailers();
}
