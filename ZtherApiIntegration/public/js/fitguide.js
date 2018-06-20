$(function(){
		$('.flexslider').flexslider({
			animation: "slide"
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
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1 flex-active-slide" style="width: 100%; float: left; margin-right: -100%; position: relative; opacity: 1; display: block; z-index: 2;"><img src="images/8555-large.jpeg" /></li></ul></div>';
					add_content(output);

					var rowinfo = '<div class="landau_logo"><img id="logo" src="images/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/8555.jpeg"><div class="description">Men\'s Cargo Pant</div><div class="number">8555</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/7602.jpeg"><div class="description">Unisex Reversible Drawstring Pant</div><div class="number">7602</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(rowinfo, 'landau');
				}
				else if(fit == 'modern style'){
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="images/2012-large.jpeg" /></li><li class="slide2"><img src="images/2012-large-1.jpeg" /></li><li class="slide3"><img src="images/2012-large-2.jpeg" /></li></ul></div>';
					add_content(output);

					var rowinfo = '<div class="landau_logo"><img id="logo" src="images/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/2025.jpeg"><div class="description">Men\'s Pre-Washed Cargo Pant</div><div class="number">2025</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/2012.jpeg"><div class="description">Men\'s Stretch Cargo Pant</div><div class="number">2012</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(rowinfo, 'landau');
				}
                else{
                    $('.classic.style').click();
                }
			}
			else if(types == 'tops clothing'){

				if(fit == 'classic style'){
				var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="images/7489-large.jpeg" /></li></ul></div>';
				add_content(output);
				var rowinfo = '<div class="landau_logo"><img id="logo" src="images/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/7502.jpeg"><div class="description">Unisex Scrub V-Neck Top</div><div class="number">7502</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/7489.jpeg"><div class="description">Men\'s 5-Pocket Scrub Top</div><div class="number">7489</div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(rowinfo, 'landau');
				}
				else if(fit == 'modern style'){
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="images/4098-large.jpeg" /></li></ul></div>';
				add_content(output);
					var rowinfo = '<div class="landau_logo"><img id="logo" src="images/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/7478.jpeg"><div class="description">Men\'s Pre-Washed Cargo Pant</div><div class="number">7478</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/4098.jpeg"><div class="description">Men\'s Stretch V-Neck Top</div><div class="number">4098</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
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
		if(gender == 'women'){
			$('button.landau').fadeIn();
			$('button.landau-temp').fadeOut();
			$('#women-chart').fadeIn();
			$('.urbane-row').fadeIn();
			if(types == 'pants clothing'){
				if(fit == 'classic style'){
				var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="images/8327-large.jpeg" /></li></ul></div>';


				add_content(output);

				var rowinfo = '<div class="landau_logo"><img id="logo" src="images/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/8335.jpeg"><div class="description">Womens Natural Flare Leg Pant</div><div class="number">8335</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/8327.jpeg"><div class="description">Womens Classic Relaxed Pant</div><div class="number">8327</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(rowinfo, 'landau');

					var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="images/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/9502.jpeg"><div class="description">Womens Relaxed Drawstring Pant</div><div class="number">9502</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(nextrowinfo, 'urbane');


				}
				else if(fit == 'modern style'){
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="images/2024-lg-2.jpeg" /></li><li class="slide2"><img src="images/2024-lg.jpeg" /></li><li class="slide3"><img src="images/2024-large.jpeg" /></li></ul></div>';
					add_content(output);

					var rowinfo = '<div class="landau_logo"><img id="logo" src="images/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/2035.jpeg"><div class="description">Womens All Day Full Elastic Cargo Pant</div><div class="number">2035</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/2024.jpeg"><div class="description">Womens Pre-Washed Cargo Pant</div><div class="number">2024</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(rowinfo, 'landau');

					var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="images/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/9324.jpeg"><div class="description">Womens Knit Waist Cargo Jogger Pant</div><div class="number">9324</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/9306.jpeg"><div class="description">Womens Alexis Comfort Elastic Waist Pant</div><div class="number">9306</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(nextrowinfo, 'urbane');
				}
				else{
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="images/9330-large.jpg" /></li></ul></div>';


				add_content(output);
				var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="images/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/9329.jpeg" width="200px" height="auto"><div class="description">"Taylor" Straight Leg Pant</div><div class="number">9329</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/9330-large.jpg" width="60%"><div class="description">"Michelle" Yoga Flare Leg Pant</div><div class="number">9330</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(nextrowinfo, 'urbane');
					var rowinfo = '<div class="smitten_logo"><img id="logo" src="images/smitten_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/s201003.jpeg" width="90%"><div class="description">AMP- Womens Smitten Cargo Elastic Pant</div><div class="number">S201003</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/s201002.jpeg" width="90%"><div class="description">Hottie - Womens Smitten Pant</div><div class="number">S201002</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(rowinfo, 'smitten');
				}
			}
			else if(types == 'tops clothing'){
				if(fit == 'classic style'){
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="images/8219-large.jpeg" /></li><li class="slide2"><img src="images/8219-large-1.jpeg" /></li><li class="slide3"><img src="images/8219-large-2.jpeg" /></li></ul></div>';
					add_content(output);

					var rowinfo = '<div class="landau_logo"><img id="logo" src="images/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/8232.jpeg"><div class="description">Womens Snap Front V-Neck Tunic</div><div class="number">8232</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/8219.jpeg"><div class="description">Women\'s V-Neck Tunic</div><div class="number">8219</div></div><div class=" col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(rowinfo, 'landau');

					var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="images/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/9534.jpeg"><div class="description">Womens Double Pocket Crossover Top</div><div class="number">9534</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(nextrowinfo, 'urbane');


				}
				else if(fit == 'modern style'){
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="images/4125-large.jpeg" /></li><li class="slide2"><img src="images/4125-large-1.jpeg" /></li><li class="slide3"><img src="images/4125-large-2.jpeg" /></li></ul></div>';
					add_content(output);

					var rowinfo = '<div class="landau_logo"><img id="logo" src="images/landau_logo2.png"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/4143.jpeg"><div class="description">Womens All Day Y Neck Scrub Tunic</div><div class="number">4143</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/4125.jpeg"><div class="description">Womens Pre-Washed V-Neck Top</div><div class="number">4125</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(rowinfo, 'landau');

					var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="images/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/9047.jpeg"><div class="description">Womens Quick Cool Sport Tunic</div><div class="number">9047</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/9577.jpeg"><div class="description">Womens Sophie Crossover Tunic</div><div class="number">9577</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					update_rowinfo(nextrowinfo, 'urbane');



				}
				else{
					var output = '<div class="flexslider"><ul class="slides"><li class="slide1"><img src="images/9063-large.jpg" /></li></ul></div>';


				add_content(output);

					var nextrowinfo = '<div class="urbane_logo"><img id="logo" src="images/urbane_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/9063-large.jpg" width="60%"><div class="description">"Chelsea" Soft V-Neck Tunic</div><div class="number">9063</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/9062.jpg" width="60%"><div class="description">"Leah" Empire Notch Neck Tunic</div><div class="number">9062</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
					// <div class="col-md-3"><img src="images/9062.jpg" width="100%"><div class="description">"Leah" Empire Notch Neck Tunic</div><div class="number">9062</div></div>
					update_rowinfo(nextrowinfo, 'urbane');
					var rowinfo = '<div class="smitten_logo"><img id="logo" src="images/smitten_logo.svg" width="10%" height="auto"></div><div class="col-xs-0 col-sm-3 col-md-3"></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/s101033.jpeg" width="90%"><div class="description">Glam-Womens Smitten Surplice Tunic Top</div><div class="number">S101033</div></div><div class="col-xs-6 col-sm-3 col-md-3"><img src="images/s101002.jpeg" width="90%"><div class="description">Rock Goddess - Womens Smitten Top</div><div class="number">S101002</div></div><div class="col-xs-6 col-sm-3 col-md-3"></div>';
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