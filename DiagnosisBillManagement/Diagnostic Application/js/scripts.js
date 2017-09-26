$(document).ready(function(){
	var window_ = $(window),
		body_ = $('body');
	$('<a href="#" class="open-menu">Open Menu</a>').appendTo('.nav-area');
	$('<span class="fader"/>').appendTo('.nav-area');
	$('.open-menu').click(function(){
		body_.toggleClass('menu-opened');
		return false;
	});
	$('.fader').click(function(){
		body_.removeClass('menu-opened');
	});
	$('.main-nav li').has('ul').addClass('has-drop');
	$('.has-drop > a').click(function() {
		if (window_.width() <= 991 && $(this).parent().hasClass('active')) {
			$(this).parent().removeClass('active');
		} else if (window_.width() <= 991) {
			$(this).parent().addClass('active').siblings('.active').removeClass('active');
		};
		return false;
	});
	$('.main-gallery .item, .visual-in, .contact-lightbox .left').each(function() {
		var $el = $(this).find('> img');
		if ($el.length > 0) {
			$(this).css('background-image', 'url(' + $el.attr('src') + ')');
			$el.hide();
		}
	});
	$('.main-gallery').slick({
		fade: true,
		autoplay: true,
		autoplaySpeed: 3000,
		arrows: true,
		pauseOnHover: true,
		slide: '.item',
		draggable: false,
		useCSS: false,
		responsive: [
			{
				breakpoint: 767,
				settings:{
					arrows: false,
					fade: false
				}
			}
		]
	});
	var featuredCarouselNav = $('.featured-carousel').siblings('.main-title').find('.carousel-nav');
	$('.featured-carousel').slick({
		infinite: true,
		autoplay: true,
		autoplaySpeed: 3000,
		slidesToShow: 3,
		slidesToScroll: 3,
		appendArrows: featuredCarouselNav,
		pauseOnHover: true,
		responsive: [
			{
				breakpoint: 991,
				settings:{
					slidesToShow: 2,
					slidesToScroll: 2
				}
			},
			{
				breakpoint: 630,
				settings:{
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});
	$('#about-text').dotdotdot({
		after: 'a.readmore',
		watch: 'window'
	});
	$('.fancybox').fancybox({
		padding: 0,
		margin: [40, 30, 40, 30],
		maxWidth: 928
	});
	jQuery.validator.addMethod("defaultInvalid", function(value, element) {
		return !(element.value == element.defaultValue);
	});
	$('#contact-form').validate({
		rules: {
			fname: {
				required: true,
				defaultInvalid: true
			},
			lname: {
				required: true,
				defaultInvalid: true
			},
			phone: {
				required: true,
				digits: true,
				defaultInvalid: true
			},
			email: {
				required: true,
				email: true,
				defaultInvalid: true
			},
			message: {
				required: true,
				defaultInvalid: true
			}
		},
		messages: {
			fname: "Please specify First Name",
			lname: "Please specify Last Name",
			phone: "Please specify Phone Number",
			email: {
				required: "We need your email address to contact you",
				email: "Your email address must be in the format of name@domain.com"
			},
			message: "Please specify Message"
		},
		highlight: function(element, errorClass, validClass) {
			if ($(element).parent('.input-group').length) {
				$(element).parent().addClass(errorClass).removeClass(validClass);
			} else{
				$(element).addClass(errorClass).removeClass(validClass);
			};
		},
		unhighlight: function(element, errorClass, validClass) {
			if ($(element).parent('.input-group').length) {
				$(element).parent().removeClass(errorClass).addClass(validClass);
			} else{
				$(element).removeClass(errorClass).addClass(validClass);
			};
		}
	});
	$('.quick-search form').each(function() {
		$(this).validate({
			rules: {
				location: {
					required: true,
					defaultInvalid: true
				}
			},
			messages: {
				location: "Please specify Location"
			},
			highlight: function(element, errorClass, validClass) {
				if ($(element).parent('.input-group').length) {
					$(element).parent().addClass(errorClass).removeClass(validClass);
				} else{
					$(element).addClass(errorClass).removeClass(validClass);
				};
			},
			unhighlight: function(element, errorClass, validClass) {
				if ($(element).parent('.input-group').length) {
					$(element).parent().removeClass(errorClass).addClass(validClass);
				} else{
					$(element).removeClass(errorClass).addClass(validClass);
				};
			}
		});
		$('.col-price .price-box').each(function() {
			var inp_ = $(this).find('input');
			$(this).find('.reduce').click(function() {
				var currentVal = parseInt(inp_.val().replace('$','').replace(/,/g,''));
				if (!isNaN(currentVal) && currentVal > 0) {
					inp_.val('$' + commaSeparateNumber((currentVal - 5000)));
				} else {
					inp_.val('$' + 0);
				}
				return false;
			});
			$(this).find('.increase').click(function() {
				var currentVal = parseInt(inp_.val().replace('$','').replace(/,/g,''));
				if (!isNaN(currentVal)) {
					var currentVal = parseInt(inp_.val().replace('$','').replace(/,/g,''));
					inp_.val('$' + commaSeparateNumber((currentVal + 5000)));
				} else {
					inp_.val('$' + 0);
				}
				return false;
			});
		});
	});
	$('.col-quantity .price-box').each(function() {
		var inp_ = $(this).find('input');
		$(this).find('.reduce').click(function() {
			var currentVal = parseInt(inp_.val());
			if (!isNaN(currentVal) && currentVal > 0) {
				currentVal--;
				inp_.val(currentVal);
			} else {
				inp_.val(0);
			}
			return false;
		});
		$(this).find('.increase').click(function() {
			var currentVal = parseInt(inp_.val());
			if (!isNaN(currentVal)) {
				currentVal++;
				inp_.val(currentVal);
			} else {
				inp_.val(0);
			}
			return false;
		});
	});
	function commaSeparateNumber(val){
		while (/(\d+)(\d{3})/.test(val.toString())){
			val = val.toString().replace(/(\d+)(\d{3})/, '$1'+','+'$2');
		}
		return val;
	}
	$.widget( 'custom.catcomplete', $.ui.autocomplete, {
		_create: function() {
			this._super();
			this.widget().menu( 'option', 'items', '> :not(.ui-autocomplete-category)' );
		},
		_renderMenu: function( ul, items ) {
			var that = this,
				currentCategory = '';
			$.each( items, function( index, item ) {
				var li;
				if ( item.category != currentCategory ) {
					ul.append( '<li class="ui-autocomplete-category">' + item.category + '</li>' );
					currentCategory = item.category;
				}
				li = that._renderItemData( ul, item );
				if ( item.category ) {
					li.attr( 'aria-label', item.category + ' : ' + item.label );
				}
			});
		}
	});
	var data = [
		{ label: "anders", category: "" },
		{ label: "andreas", category: "" },
		{ label: "antal", category: "" },
		{ label: "annhhx10", category: "Products" },
		{ label: "annk K12", category: "Products" },
		{ label: "annttop C13", category: "Products" },
		{ label: "anders andersson", category: "People" },
		{ label: "andreas andersson", category: "People" },
		{ label: "andreas johnson", category: "People" }
	];
	$( ".autocomplete > input" ).each(function() {
		$(this).autocomplete({
			source: data
		});
	});

	$('.selectpicker').selectpicker({
		style: 'btn'
	});

	// new 12.10.15
	// agent-carousel
	$('.agent-carousel').slick({
		infinite: true,
		autoplay: true,
		autoplaySpeed: 3000,
		slidesToShow: 3,
		slidesToScroll: 3,
		pauseOnHover: true,
		arrows: true,
		appendArrows: $('.agent-carousel').siblings('.agent-carousel-nav'),
		responsive: [
			{
				breakpoint: 991,
				settings:{
					arrows: false,
					slidesToShow: 2,
					slidesToScroll: 2
				}
			},
			{
				breakpoint: 630,
				settings:{
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});
	// autocomplete
	var data2 = [
		{ label: "anders", category: "" },
		{ label: "andreas", category: "" },
		{ label: "antal", category: "" },
		{ label: "annhhx10", category: "Products" },
		{ label: "annk K12", category: "Products" },
		{ label: "annttop C13", category: "Products" },
		{ label: "anders andersson", category: "People" },
		{ label: "andreas andersson", category: "People" },
		{ label: "andreas johnson", category: "People" }
	];
	$( '.search-agent-form .input-group > input' ).autocomplete({
		source: data2
	});
});