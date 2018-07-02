$(function () {
   
		$('.flexslider').flexslider({
			animation: "slide"
		});

    $('#Seemorefromlandau').on('click', function () {
        redirecttofit(null);
    });
    
    $('#seemorefromurbane').on('click', function () {
        redirecttofit('urbane');
    });

    $('#morecomingsoon').on('click', function () {
        redirecttofit(null);
    });

    $('#seemorefromsmitten ').on('click', function () {
        redirecttofit('smitten');
    });

    function redirecttofit(externalLink) {
        var redirectUrl = {};
        var gender = $('#options').children('#active').children('div').attr('class');
        var types = $('.types').children('#active').attr('class');
        var fit = $('#active.style').attr('class');

        if (types == "pants clothing") {
            types = "pants";
        }
        else if (types == "tops clothing") {
            types = "tops";
        }

        if (fit == "classic style") {
            fit = "Classic";
        }
        else if (fit == "modern style") {
            fit = "Modern";
        }
        else if (fit == "contemporary style") {
            fit = "Contemporary";
        }

        if (gender == 'men' && fit == "Contemporary") {
            fit = 'Classic';
        }

        redirectUrl = { gender: gender, types: types, fit: fit };
        console.log(redirectUrl);
        if (externalLink=='urbane') {
            window.location.href = "http://www.urbanescrubs.com/" + redirectUrl.gender + '/category/' + redirectUrl.types + '?fit=' + redirectUrl.fit;
        }
        else if (externalLink == 'smitten') {
            window.location.href = "http://www.smittenscrubs.com/" + redirectUrl.gender + '/collection/' + redirectUrl.types + '?fit=' + redirectUrl.fit;
        }
        else {
            window.location = redirectUrl.gender + '/category/' + redirectUrl.types + '?fit=' + redirectUrl.fit;
        }    
    }

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


		$('.style').on('click', function(){
			$('#active.style').attr('id', '');
			$(this).attr('id', 'active');
			var gender = $('#options').children('#active').children('div').attr('class');

			if($(this).attr('class') == 'classic style'){
				$('.smitten-row').fadeOut();
				$('.landau-row').fadeIn();
			}
			else if($(this).attr('class') == 'modern style'){
				$('.landau-row').fadeIn();
				$('.smitten-row').fadeOut();
			}
			else{
				$('.landau-row').fadeOut();
				$('.smitten-row').fadeIn();
			}
			options_change();
		});
		$('#options').children(".col-md-4").on('click', function(){
			$('#active.col-md-4').attr('id','');
			$(this).attr('id','active');
			var classer = $(this).children().attr('class');

			$('.row').children('.container.active').removeClass('active');
            console.log(classer+'!!!!!!');
            $('#mobile').children('#'+classer +'-chart').addClass('active');
			$('#full-size').children('#'+classer +'-chart').addClass('active');
			if(classer == 'men'){
				$('.contemporary').attr('id', 'hide');
			}
			else{
				$('.contemporary').attr('id', '');
			}
			options_change();

		});

		$('.types').children('.clothing').on('click', function(){
			$('#active.clothing').attr('id', '');
			$(this).attr('id', 'active');
			options_change();
		});

options_change();

	});

	function options_change(){

		var gender = $('#options').children('#active').children('div').attr('class');

console.log(gender);



	var types = $('.types').children('#active').attr('class');
console.log(types);

		var fit = $('#active.style').attr('class');

		if(fit == 'contemporary style'){
			$('.contemporary-fit').fadeIn('slow');
			$('.modern-fit').fadeOut('fast');
			$('.classic-fit').fadeOut('fast');
		}
		if(fit == 'modern style'){
			$('.contemporary-fit').fadeOut('fast');
			$('.modern-fit').fadeIn('slow');
			$('.classic-fit').fadeOut('fast');
		}
		if(fit == 'classic style'){
			$('.contemporary-fit').fadeOut('fast');
			$('.modern-fit').fadeOut('fast');
			$('.classic-fit').fadeIn('slow');
		}

        console.log(fit);

        var output;

		if(gender == 'men'){
			$('button.landau').fadeOut();
			$('button.landau-temp').fadeIn();

			$('.urbane-row').fadeOut();
			if(types == 'pants clothing'){
				if(fit == 'classic style'){
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1 flex-active-slide" style="width: 100%; float: left; margin-right: -100%; position: relative; opacity: 1; display: block; z-index: 2;"><img src="public/images/fit-guide/8555-large.jpeg" /></li></ul></div>';
					add_content(output);

					//var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/8555.jpeg"><div class="description">Men\'s Cargo Pant</div><div class="number">8555</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/7602.jpeg"><div class="description">Unisex Reversible Drawstring Pant</div><div class="number">7602</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    var rowinfo ='<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/8555-mens-cargo-pant"><img src="public/images/fit-guide/8555.jpeg"></a><div class="description">Men\'s Cargo Pant</div><div class="number">8555</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/7602-unisex-reversible-drawstring-pant"><img src="public/images/fit-guide/7602.jpeg"></a><div class="description">Unisex Reversible Drawstring Pant</div><div class="number">7602</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    update_rowinfo(rowinfo, 'landau');
				}
				else if(fit == 'modern style'){
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="public/images/fit-guide/2012-large.jpeg" /></li><li class="slide2"><img src="public/images/fit-guide/2012-large-1.jpeg" /></li><li class="slide3"><img src="public/images/fit-guide/2012-large-2.jpeg" /></li></ul></div>';
					add_content(output);

					//var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/2025.jpeg"><div class="description">Men\'s Pre-Washed Cargo Pant</div><div class="number">2025</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/2012.jpeg"><div class="description">Men\'s Stretch Cargo Pant</div><div class="number">2012</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href=" /2025-mens-pre-washed-cargo-pant"><img src="public/images/fit-guide/2025.jpeg"></a><div class="description">Men\'s Pre-Washed Cargo Pant</div><div class="number">2025</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/2012-mens-stretch-cargo-pant"><img src="public/images/fit-guide/2012.jpeg"></a><div class="description">Men\'s Stretch Cargo Pant</div><div class="number">2012</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';

                    update_rowinfo(rowinfo, 'landau');
				}
                else{
                    $('.classic.style').click();
                }
			}
			else if(types == 'tops clothing'){

				if(fit == 'classic style'){
				var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="public/images/fit-guide/7489-large.jpeg" /></li></ul></div>';
                    add_content(output);

				//var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/7502.jpeg"><div class="description">Unisex Scrub V-Neck Top</div><div class="number">7502</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/7489.jpeg"><div class="description">Men\'s 5-Pocket Scrub Top</div><div class="number">7489</div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/7502-unisex-scrub-v-neck-top"><img src="public/images/fit-guide/7502.jpeg"></a><div class="description">Unisex Scrub V-Neck Top</div><div class="number">7502</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/7489-mens-5-pocket-scrub-top"><img src="public/images/fit-guide/7489.jpeg"></a><div class="description">Men\'s 5-Pocket Scrub Top</div><div class="number">7489</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';

                    update_rowinfo(rowinfo, 'landau');
				}
				else if(fit == 'modern style'){
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="public/images/fit-guide/4098-large.jpeg" /></li></ul></div>';
                    add_content(output);

					//var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/7478.jpeg"><div class="description">Men\'s Pre-Washed Cargo Pant</div><div class="number">7478</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/4098.jpeg"><div class="description">Men\'s Stretch V-Neck Top</div><div class="number">4098</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/7478-mens-pre-washed-v-neck-tunic"><img src="public/images/fit-guide/7478.jpeg"></a><div class="description">Men\'s Pre-Washed Cargo Pant</div><div class="number">7478</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href=" /4098-mens-stretch-v-neck-top"><img src="public/images/fit-guide/4098.jpeg"></a><div class="description">Men\'s Stretch V-Neck Top</div><div class="number">4098</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';

                    update_rowinfo(rowinfo, 'landau');
				}
                else{
                    $('.classic.style').click();
                }

			}
			else{
				$('.classic.style').attr('id', 'active');

			}
		}
		else if(gender == 'women'){
			$('button.landau').fadeIn();
			$('button.landau-temp').fadeOut();
			$('#women-chart').fadeIn();
			$('.urbane-row').fadeIn();
			if(types == 'pants clothing'){
				if(fit == 'classic style'){
				var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="public/images/fit-guide/8327-large.jpeg" /></li></ul></div>';


				add_content(output);

                    var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div> <div class="col-xs-6 col-sm-3 col-md-3"><a href="/8335-womens-natural-flare-leg-pant"><img src="public/images/fit-guide/8335.jpeg"></a><div class="description">Womens Natural Flare Leg Pant</div><div class="number">8335</div></div><div class="col-xs-6 col-sm-3 col-md-3" > <a href="/8327-womens-classic-relaxed-pant"><img src="public/images/fit-guide/8327.jpeg"></a><div class="description">Womens Classic Relaxed Pant</div><div class="number">8327</div></div> <div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(rowinfo, 'landau');

					
                    var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="public/images/fit-guide/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><a href="/9502-womens-relaxed-drawstring-pant"><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/9502.jpeg"></a><div class="description">Womens Relaxed Drawstring Pant</div><div class="number">9502</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    update_rowinfo(nextrowinfo, 'urbane');

				}
				else if(fit == 'modern style'){
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="public/images/fit-guide/2024-lg-2.jpeg" /></li><li class="slide2"><img src="public/images/fit-guide/2024-lg.jpeg" /></li><li class="slide3"><img src="public/images/fit-guide/2024-large.jpeg" /></li></ul></div>';
					add_content(output);

				
                    var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div> <div class="col-xs-6 col-sm-3 col-md-3"><a href="/2035-womens-all-day-full-elastic-cargo-pant"><img src="public/images/fit-guide/2035.jpeg"></a><div class="description">Womens All Day Full Elastic Cargo Pant</div><div class="number">2035</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/2024-womens-pre-washed-cargo-pant"><img src="public/images/fit-guide/2024.jpeg"></a><div class="description">Womens Pre-Washed Cargo Pant</div><div class="number">2024</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    update_rowinfo(rowinfo, 'landau')
                                                                   
                                        	
                    var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="public/images/fit-guide/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div> <div class="col-xs-6 col-sm-3 col-md-3"><a href="/9324-womens-knit-waist-cargo-jogger-pant"><img src="public/images/fit-guide/9324.jpeg"></a><div class="description">Womens Knit Waist Cargo Jogger Pant</div><div class="number">9324</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/9306-womens-alexis-comfort-elastic-waist-pant"><img src="public/images/fit-guide/9306.jpeg"></a><div class="description">Womens Alexis Comfort Elastic Waist Pant</div><div class="number">9306</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    update_rowinfo(nextrowinfo, 'urbane');
				}
				else{
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="public/images/fit-guide/9330-large.jpg" /></li></ul></div>';


				add_content(output);
				
                    var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="public/images/fit-guide/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/9329-taylor-straight-leg-pant"><img src="public/images/fit-guide/9329.jpeg" width="200px" height="auto"></a><div class="description">"Taylor" Straight Leg Pant</div><div class="number">9329</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="9330-michelle-yoga-flare-leg-pant"><img src="public/images/fit-guide/9330-large.jpg" width="60%"></a><div class="description">"Michelle" Yoga Flare Leg Pant</div><div class="number">9330</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    update_rowinfo(nextrowinfo, 'urbane');
					
                    var rowinfo = '<div class="smitten_logo"><img id="logo" src="public/images/fit-guide/smitten_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/s201003-amp---womens-smitten-cargo-elastic-pant"><img src="public/images/fit-guide/s201003.jpeg" width="90%"></a><div class="description">AMP- Womens Smitten Cargo Elastic Pant</div><div class="number">S201003</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/s201002-hottie---womens-smitten-pant"><img src="public/images/fit-guide/s201002.jpeg" width="90%"></a><div class="description">Hottie - Womens Smitten Pant</div><div class="number">S201002</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';

                    update_rowinfo(rowinfo, 'smitten');
				}
			}
			else if(types == 'tops clothing'){
				if(fit == 'classic style'){
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="public/images/fit-guide/8219-large.jpeg" /></li><li class="slide2"><img src="public/images/fit-guide/8219-large-1.jpeg" /></li><li class="slide3"><img src="public/images/fit-guide/8219-large-2.jpeg" /></li></ul></div>';
					add_content(output);

					//var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/8232.jpeg"><div class="description">Womens Snap Front V-Neck Tunic</div><div class="number">8232</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/8219.jpeg"><div class="description">Women\'s V-Neck Tunic</div><div class="number">8219</div></div><div class=" col-xs-6 col-sm-3 col-md-3"></div>';

                    var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href=" /8232-womens-snap-front-v-neck-tunic"><img src="public/images/fit-guide/8232.jpeg"></a><div class="description">Womens Snap Front V-Neck Tunic</div><div class="number">8232</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/8219-womens-v-neck-tunic"><img src="public/images/fit-guide/8219.jpeg"></a><div class="description">Women\'s V-Neck Tunic</div><div class="number">8219</div></div><div class=" col-xs-6 col-sm-3 col-md-3"></div>';
                    update_rowinfo(rowinfo, 'landau');

					//var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="public/images/fit-guide/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/9534.jpeg"><div class="description">Womens Double Pocket Crossover Top</div><div class="number">9534</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="public/images/fit-guide/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/9534-womens-double-pocket-crossover-top"><img src="public/images/fit-guide/9534.jpeg"></a><div class="description">Womens Double Pocket Crossover Top</div><div class="number">9534</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    update_rowinfo(nextrowinfo, 'urbane');


				}
				else if(fit == 'modern style'){
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="public/images/fit-guide/4125-large.jpeg" /></li><li class="slide2"><img src="public/images/fit-guide/4125-large-1.jpeg" /></li><li class="slide3"><img src="public/images/fit-guide/4125-large-2.jpeg" /></li></ul></div>';
					add_content(output);

					//var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/4143.jpeg"><div class="description">Womens All Day Y Neck Scrub Tunic</div><div class="number">4143</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/4125.jpeg"><div class="description">Womens Pre-Washed V-Neck Top</div><div class="number">4125</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    var rowinfo = '<div class="landau_logo"><img id="logo" src="public/images/fit-guide/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href=" /4143-womens-all-day-y-neck-scrub-tunic"><img src="public/images/fit-guide/4143.jpeg"></a><div class="description">Womens All Day Y Neck Scrub Tunic</div><div class="number">4143</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href=" /4125-womens-pre-washed-v-neck-top"><img src="public/images/fit-guide/4125.jpeg"></a><div class="description">Womens Pre-Washed V-Neck Top</div><div class="number">4125</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    update_rowinfo(rowinfo, 'landau');

					//var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="public/images/fit-guide/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/9047.jpeg"><div class="description">Womens Quick Cool Sport Tunic</div><div class="number">9047</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/9577.jpeg"><div class="description">Womens Sophie Crossover Tunic</div><div class="number">9577</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';

                    var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="public/images/fit-guide/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/9047-womens-quick-cool-sport-tunic"><img src="public/images/fit-guide/9047.jpeg"></a><div class="description">Womens Quick Cool Sport Tunic</div><div class="number">9047</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/9577-womens-sophie-crossover-tunic"><img src="public/images/fit-guide/9577.jpeg"></a><div class="description">Womens Sophie Crossover Tunic</div><div class="number">9577</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';

                    update_rowinfo(nextrowinfo, 'urbane');



				}
				else{
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="public/images/fit-guide/9063-large.jpg" /></li></ul></div>';


				add_content(output);

					//var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="public/images/fit-guide/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/9063-large.jpg" width="60%"><div class="description">"Chelsea" Soft V-Neck Tunic</div><div class="number">9063</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/9062.jpg" width="60%"><div class="description">"Leah" Empire Notch Neck Tunic</div><div class="number">9062</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="public/images/fit-guide/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/9063-chelsea-soft-v-neck-tunic"><img src="public/images/fit-guide/9063-large.jpg" width="60%"></a><div class="description">"Chelsea" Soft V-Neck Tunic</div><div class="number">9063</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="\9062-leah-empire-notch-neck-tunic"><img src="public/images/fit-guide/9062.jpg" width="60%"></a><div class="description">"Leah" Empire Notch Neck Tunic</div><div class="number">9062</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    update_rowinfo(nextrowinfo, 'urbane');

					//var rowinfo = '<div class="smitten_logo"><img id="logo" src="public/images/fit-guide/smitten_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/s101033.jpeg" width="90%"><div class="description">Glam-Womens Smitten Surplice Tunic Top</div><div class="number">S101033</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="public/images/fit-guide/s101002.jpeg" width="90%"><div class="description">Rock Goddess - Womens Smitten Top</div><div class="number">S101002</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
                    var rowinfo = '<div class="smitten_logo"><img id="logo" src="public/images/fit-guide/smitten_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/s101033-glam---womens-smitten-surplice-tunic-top"><img src="public/images/fit-guide/s101033.jpeg" width="90%"></a><div class="description">Glam-Womens Smitten Surplice Tunic Top</div><div class="number">S101033</div></div><div class="col-xs-6 col-sm-3 col-md-3"><a href="/s101002-rock-goddess---womens-smitten-top"><img src="public/images/fit-guide/s101002.jpeg" width="90%"></a><div class="description">Rock Goddess - Womens Smitten Top</div><div class="number">S101002</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';

                    update_rowinfo(rowinfo, 'smitten');
				}
			}
			else{
				if(fit == 'classic style'){

				}
				else if(fit == 'modern style'){

				}
				else{

				}
			}
		}
		//unisex
		else{
			if(types == 'pants clothing'){
				if(fit == 'classic style'){

				}
				else if(fit == 'modern style'){

				}
				else{

				}
			}
			else if(types == 'tops clothing'){
				if(fit == 'classic style'){

				}
				else if(fit == 'modern style'){

				}
				else{

				}
			}
			else{
				if(fit == 'classic style'){

				}
				else if(fit == 'modern style'){

				}
				else{

				}
			}
		}


	}


	function add_content(output){
		$('#slider_below').empty();
$('#slider_below').append(output);
$('.flexslider').flexslider();

// $('ul.slides').children().fadeIn();
$
	}

	function update_rowinfo(rowinfo, brand){
		$('.'+brand+'-row').children('.col-md-12').empty();
		$('.'+brand+'-row').children('.col-md-12').append(rowinfo);
	}