/// <reference path="services.js" />

var SilentAction = Service;

SilentAction.Events = (function (j) {
	return {
		// Window loaded
		window_loaded: function () {
			SilentAction.IntroSlider.start();
			SilentAction.WindowLoad.callFunctions();
		},

		// Window resized
		window_resized: function () {
			SilentAction.IntroSlider.resetContentArea();
			SilentAction.Campaign.resizeGrid();
			SilentAction.WhatWeDo.contentHeight();
			SilentAction.WindowResize.callFunctions();
		},

		// Category dropdown (Campaign & Auction section) clicked
		dropdown_click: function (el) {
			SilentAction.Elements.DropdownBG.show();
			j(el).siblings('.option-set').show().addClass('open');
		},

		// Background of the category dropdown (Campaign & Auction section) clicked
		dropdownBG_click: function () {
			j('.dropdown .option-set').hide().removeClass('open');
			SilentAction.Elements.DropdownBG.hide();
		}
	}
})(jQuery);


jQuery(function (j) {
	"use strict";

	j('.page-scroll a').bind('click', function (event) {
		var jAnchor = j(this);

		j('html, body').stop().animate({
			scrollTop: j(jAnchor.attr('href')).offset().top
		}, 1500, 'easeInOutExpo');

		event.preventDefault();
	});

	j(window).on('resize', function () {
		SilentAction.Events.window_resized();
	}).on('load', function () {
		SilentAction.Events.window_loaded();
	}).on('scroll', function () {
		if (j(".navbar").offset().top > 50) {
			j(".navbar-fixed-top").addClass("top-nav-collapse");
		} else {
			j(".navbar-fixed-top").removeClass("top-nav-collapse");
		}

		SilentAction.WindowScroll.callFunctions();
	});

	SilentAction.DOM_Ready.callFunctions();

});