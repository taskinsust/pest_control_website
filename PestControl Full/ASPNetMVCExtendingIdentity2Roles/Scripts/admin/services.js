﻿var Service = {};

Service.Elements = (function (j) {
	return {
		htmlBody: j('body'),
		DropdownBG: j('.dropdown-bg')
	}
})(jQuery);

Service.IntroSlider = (function (j) {
	var slider, jSlider, jSliderText, jSliderNav, tempSliderTextHeight, sliderTextHeight = 0,
		sliderCount, lastSliderIndex = 0, sliderIndex = 1,
		transition = 1000, delay = 10000;

	function sliderFn() {
		jSliderNav.children('a.active').removeClass('active');
		jSliderNav.children('a:eq(' + sliderIndex + ')').addClass('active');

		jSliderText.eq(lastSliderIndex).fadeOut(transition, function () {
			jSlider.eq(lastSliderIndex).fadeOut(transition);

			jSlider.eq(sliderIndex).fadeIn(transition, function () {
				jSliderText.eq(sliderIndex).fadeIn(transition);

				lastSliderIndex = sliderIndex;
				sliderIndex++;
				sliderIndex = (sliderIndex == sliderCount) ? 0 : sliderIndex;
			});
		});
	}

	function startSlider() {
		slider = setInterval(function () {
			sliderFn();
		}, delay);
	}

	function stopSlider() {
		clearInterval(slider);
	}

	function goToSlide(slideIndex) {
		stopSlider();

		sliderIndex = slideIndex;

		sliderFn();
		startSlider();
	}

	function introSlider() {
		if (!jSlider) {
			jSlider = j('.intro-slider > .slide');
		}

		if (!jSliderText) {
			jSliderText = j('.intro-text-content');
		}

		if (!jSliderNav) {
			jSliderNav = j('.intro .slider-nav');
		}

		jSliderText.filter(':gt(0)').hide();
		jSliderText.css('visibility', 'visible');

		sliderCount = jSlider.length;

		if (sliderCount > 1) {
			for (var i = 0; i < sliderCount; i++) {
				jSliderNav.append('<a class="introSlider' + i + '" href="javascript:SilentAction.IntroSlider.goToSlide(' + i + ');"></a>');

				tempSliderTextHeight = jSliderText.eq(i).height();
				if (sliderTextHeight < tempSliderTextHeight) {
					sliderTextHeight = tempSliderTextHeight;
				}
			}

			jSliderText.parent().height(sliderTextHeight);

			jSliderNav.children('a:eq(0)').addClass('active');

			startSlider();
		}
	}

	function adjustContentArea() {
		for (var i = 0; i < sliderCount; i++) {
			tempSliderTextHeight = jSliderText.eq(i).height();
			if (sliderTextHeight < tempSliderTextHeight) {
				sliderTextHeight = tempSliderTextHeight;
			}
		}
	}

	return {
		// Start the slider
		start: function () {
			introSlider();
		},

		// Stop the slider
		stop: function () {
			stopSlider();
		},

		// Go to a specific slide
		goToSlide: function (slideIndex) {
			goToSlide(slideIndex);
		},

		// Reset the height of the content area
		resetContentArea: function () {
			adjustContentArea();
		}
	}
})(jQuery);

Service.Campaign = (function (j) {
	function campaignGrid() {
		if (!j().masonry)
			return;

		var container = j('.campaigns section');
		container.masonry();

		container.imagesLoaded(function () {
			container.masonry({
				itemSelector: '.hentry'
			});
		});
	}

	function campaignWidget() {
		j('.campaigns a').attr('target', '_blank');
	}

	function destroyMasonry() {
	    j('.campaigns section').masonry('destroy');
	}

	return {
		//Initialize the grid
		init: function () {
			campaignGrid();
			campaignWidget();
		},

	    //Removes grid layout functionality
		destroy: function() {
		    destroyMasonry();
		},

		//Resets the grid
		resizeGrid: function () {
			campaignGrid();
		},

		//Rearranges the grid
		update: function (container, newItems) {
			container.masonry('appended', newItems);
		}
	}
})(jQuery);

Service.WhatWeDo = (function (j) {
	var _height = 0,
		els = j('.what-we-do > div'), el;

	function resetContentHeight() {
		_height = 0;
		els.css('height', '').each(function () {
			el = j(this);
			if (_height < el.height()) {
				_height = el.height();
			}
		});

		els.height(_height);
	}

	return {
		//Give all the containers (What We Do section) the same height
		contentHeight: function () {
			resetContentHeight();
		}
	}
})(jQuery);

Service.WindowLoad = (function (j) {
	var windowLoad_fn = [], fn, params = [];

	return {
		// Add a function with params (optional and provided as comma seperated values) to run once window loaded.
		add: function (fn, params) {
			windowLoad_fn.push(arguments);
		},

		// Remove a function from the list of functions to run when once window loaded.
		remove: function (fn) {
			var index = -1;

			for (var i = 0; i < windowLoad_fn.length; i++) {
				if (windowLoad_fn[i][0].name === fn.name) {
					index = i;
					break;
				}
			}

			if (index >= 0) {
				windowLoad_fn.splice(index, 1);
			}
		},

		// Call all the functions added to a list by SilentAction.WindowLoad.add().
		callFunctions: function () {
			if (windowLoad_fn.length > 0) {
				for (var i = 0; i < windowLoad_fn.length; i++) {
					fn = windowLoad_fn[i][0];
					params = Array.prototype.slice.apply(windowLoad_fn[i]);
					params = params.slice(1);
					fn.apply(this, params);
				}
			}
		}
	}
})(jQuery);

Service.WindowScroll = (function (j) {
	var windowScroll_fn = [], fn, params = [];

	return {
		// Add a function with params (optional and provided as comma seperated values) to run once window loaded.
		add: function (fn, params) {
			windowScroll_fn.push(arguments);
		},

		// Remove a function from the list of functions to run when once window loaded.
		remove: function (fn) {
			var index = -1;

			for (var i = 0; i < windowScroll_fn.length; i++) {
				if (windowScroll_fn[i][0].name === fn.name) {
					index = i;
					break;
				}
			}

			if (index >= 0) {
				windowScroll_fn.splice(index, 1);
			}
		},

		// Call all the functions added to a list by SilentAction.WindowLoad.add().
		callFunctions: function () {
			if (windowScroll_fn.length > 0) {
				for (var i = 0; i < windowScroll_fn.length; i++) {
					fn = windowScroll_fn[i][0];
					params = Array.prototype.slice.apply(windowScroll_fn[i]);
					params = params.slice(1);
					fn.apply(this, params);
				}
			}
		}
	}
})(jQuery);

Service.WindowResize = (function (j) {
	var windowResize_fn = [], fn, params = [];

	return {
		// Add a function with params (optional and provided as comma seperated values) to run when the window is resized.
		add: function (fn, params) {
			windowResize_fn.push(arguments);
		},

		// Remove a function from the list of functions to run when the window is resized.
		remove: function (fn) {
			var index = -1;

			for (var i = 0; i < windowResize_fn.length; i++) {
				if (windowResize_fn[i][0].name === fn.name) {
					index = i;
					break;
				}
			}

			if (index >= 0) {
				windowResize_fn.splice(index, 1);
			}
		},

		// Call all the functions added to a list by SilentAction.WindowResize.add().
		callFunctions: function () {
			if (windowResize_fn.length > 0) {
				for (var i = 0; i < windowResize_fn.length; i++) {
					fn = windowResize_fn[i][0];
					params = Array.prototype.slice.apply(windowResize_fn[i]);
					params = params.slice(1);
					fn.apply(this, params);
				}
			}
		}
	}
})(jQuery);

Service.DOM_Ready = (function (j) {
	var ready_fn = [], fn, params = [];

	return {
		// Add a function with params (optional and provided as comma seperated values) to run once DOM is ready.
		add: function (fn, params) {
			ready_fn.push(arguments);
		},

		// Remove a function from the list of functions to run when once DOM is ready.
		remove: function (fn) {
			var index = -1;

			for (var i = 0; i < ready_fn.length; i++) {
				if (ready_fn[i][0].name === fn.name) {
					index = i;
					break;
				}
			}

			if (index >= 0) {
				ready_fn.splice(index, 1);
			}
		},

		// Call all the functions added to a list by SilentAction.DOM_Ready.add().
		callFunctions: function () {
			if (ready_fn.length > 0) {
				for (var i = 0; i < ready_fn.length; i++) {
					fn = ready_fn[i][0];
					params = Array.prototype.slice.apply(ready_fn[i]);
					params = params.slice(1);
					fn.apply(this, params);
				}
			}
		}
	}
})(jQuery);

Service.Spinner = (function (j) {

	; (function ($) {
		$.fn.spin = function (options) {
			if (Spinner) {
				return this.each(function () {
					var $this = $(this),

						data = $this.data(),

						defaultOptions = {
							lines: (data.lines ? data.lines : 10), // The number of lines to draw
							length: 0, // The length of each line
							width: (data.width ? data.width : 4), // The line thickness
							radius: (data.radius ? data.radius : 10), // The radius of the inner circle
							corners: 1, // Corner roundness (0..1)
							rotate: 0, // The rotation offset
							direction: 1, // 1: clockwise, -1: counterclockwise
							color: (data.color ? data.color : '#000'), // #rgb or #rrggbb
							speed: 1, // Rounds per second
							trail: 60, // Afterglow percentage
							shadow: false, // Whether to render a shadow
							hwaccel: false, // Whether to use hardware acceleration
							className: 'spinner', // The CSS class to assign to the spinner
							zIndex: 2e9, // The z-index (defaults to 2000000000)
							top: 'auto', // Top position relative to parent in px
							left: 'auto' // Left position relative to parent in px
						};
					if (data.spinner) {
						data.spinner.stop();
						delete data.spinner;
					}
					data.spinner = new Spinner($.extend(defaultOptions, options)).spin(this);
				});
			} else {
				throw "Spinner class not available.";
			}
		};
	})(jQuery);

	j(function () {
		j('[data-id=spinner]').each(function () {

			var el = j(this),
				size = ((parseInt(el.data('width') ? el.data('width') : 4) + parseInt(el.data('radius') ? el.data('radius') : 10)) * 2) + 2;

			el.css({
				display: 'inline-block',
				position: 'relative',
				width: size,
				height: size
			}).spin();

		}).children().css({
			top: '50%',
			left: '50%'
		}).end().hide();
	});

	return {

		//Shows a specific spinner.
		show: function (spinner) {
			j(spinner).fadeIn();
		},

		//Hides a specific spinner.
		hide: function (spinner) {
			j(spinner).fadeOut();
		}
	}
})(jQuery);

Service.Popup = (function (j) {
	var jMsgBox, jMsgTitleBar, jMsgTitle, jMsgBody, btnOK, jTimer,
		isHtmlReady = false, popupInterval, timer, timeLeft,
		defaultOptions = {
			titlebar: true,
			title: 'Message',
			message: 'This is the message content...',
			timeout: 0
		},
		popupHTML = '<div class="modal fade" id="msgBox" tabindex="-1" role="dialog" aria-labelledby="msgBoxTitle" aria-hidden="true">' +
					'	<div class="modal-dialog">' +
					'		<div class="modal-content">' +
					'			<div class="modal-header">' +
					'			    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
					'			    <h4 class="modal-title" id="msgBoxTitle"></h4>' +
					'			</div>' +
					'			<div class="modal-body">' +
					//'		    	Test content...' +
					'			</div>' +
					'			<div class="modal-footer" style="padding: 9px 20px 10px;">' +
                    //'		    	<em class="msgBoxTimer" style="text-align: left;float:left;display:none;font-size:85%;max-width:175px;">This message will automatically close in <span class="time-left"></span> seconds.</em>' +
					'   			<button type="button" class="btn btn-primary btnOK" data-dismiss="modal">OK</button>' +
                    '		    	<em class="msgBoxTimer" style="text-align: right;display:block;font-size:85%;margin-top:10px;">This message will automatically close in <span class="time-left"></span> seconds.</em>' +
					'			</div>' +
					'		</div>' +
					'	</div>' +
					'</div>';

	function init() {
		if (isHtmlReady == false) {
			isHtmlReady = true;
			j('body').append(popupHTML);

			jMsgBox = j('#msgBox');
			jMsgTitleBar = jMsgBox.find('.modal-header');
			jMsgTitle = jMsgBox.find('#msgBoxTitle');
			jMsgBody = jMsgBox.find('.modal-body');
			btnOK = jMsgBox.find('.btnOK');
			jTimer = jMsgBox.find('.msgBoxTimer');
			timeLeft = jMsgBox.find('.time-left');
		}
	}

	return {
		// Shows a popup box with options (optional) provided as a JSON object.
		// - options: {
		// - - - titlebar: true,
		// - - - title: 'Message',
		// - - - message: 'This is the message content...',
		// - - - timeout: 0
		// - }
		show: function (options) {
			init();
			j.extend(defaultOptions, options);

			if (defaultOptions.titlebar == false) {
				jMsgTitleBar.hide();
				jMsgBody.css('margin-top', 10);
			} else {
				jMsgTitleBar.show();
				jMsgBody.css('margin-top', 0);
				jMsgTitle.html(defaultOptions.title);
			}

			jMsgBody.html(defaultOptions.message);
			//btnOK.text("OK");
			jTimer.hide();

			if (defaultOptions.timeout > 1) {
				btnOK.text("Close");
				jTimer.show();

				timer = parseInt(defaultOptions.timeout);
				timeLeft.text(timer);

				popupInterval = setInterval(function () {
					timer -= 1;
					timeLeft.text(timer);
					if (timer == 0) {
						clearInterval(popupInterval);
						btnOK.click();
					}
				}, 1000);
			}

			jMsgBox.modal({
				//keyboard: false,
				backdrop: 'static'
			});
		}
	}
})(jQuery);

Service.Confirm = (function (j) {
	var jMsgBox, jMsgTitleBar, jMsgTitle, jMsgBody,
		btnYes, btnNo, btnClose,
		isConfirmBoxReady = false,
		defaultOptions = {
			titlebar: true,
			title: 'Confirm',
			message: 'This is the question...',
			yes: function () { },
			no: function () { }
		},
		popupHTML = '<div class="modal fade" id="confirmDialog" tabindex="-1" role="dialog" aria-labelledby="msgBoxTitle" aria-hidden="true">' +
					'	<div class="modal-dialog">' +
					'		<div class="modal-content">' +
					'			<div class="modal-header" style="padding: 8px 15px;">' +
					'   			<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
					'	    		<h4 class="modal-title" id="confirmDialogTitle"></h4>' +
					'			</div>' +
					'			<div class="modal-body" style="padding: 12px 20px;">' +
					//' 			Test content...' +
					'			</div>' +
					'			<div class="modal-footer" style="padding: 9px 20px 10px;">' +
					'   			<button type="button" style="padding: 3px 16px;" class="btn btn-primary btnConfirm-Yes">Yes</button>' +
					'	    		<button type="button" style="padding: 3px 16px;" class="btn btn-danger btnConfirm-No">No</button>' +
					'		    	<button type="button" style="display:none;width:0;height:0;position:absolute;z-index:-1;" class="btn btnConfirm-Close" data-dismiss="modal"></button>' +
					'			</div>' +
					'		</div>' +
					'	</div>' +
					'</div>';

	function init() {
		if (isConfirmBoxReady == false) {
			isConfirmBoxReady = true;
			j('body').append(popupHTML);

			jMsgBox = j('#confirmDialog');
			jMsgTitleBar = jMsgBox.find('.modal-header');
			jMsgTitle = jMsgBox.find('#confirmDialogTitle');
			jMsgBody = jMsgBox.find('.modal-body');
			btnYes = jMsgBox.find('.btnConfirm-Yes');
			btnNo = jMsgBox.find('.btnConfirm-No');
			btnClose = jMsgBox.find('.btnConfirm-Close');

			btnYes.click(function () {
				defaultOptions.yes.call();
				btnClose.click();
			});

			btnNo.click(function () {
				defaultOptions.no.call();
				btnClose.click();
			});
		}
	}

	return {

		// Shows a confirm dialog box with options (optional) provided as a JSON object.
		// - options: {
		// - - - titlebar: true,
		// - - - title: 'Confirm',
		// - - - message: 'This is the question...',
		// - - - yes: function() {
		// - - - 	// do something if clicked 'YES'
		// - - - },
		// - - - no: function() {
		// - - - 	// do something if clicked 'NO'
		// - - - }
		// - }
		show: function (options) {
			init();
			j.extend(defaultOptions, options);

			if (defaultOptions.titlebar == false) {
				jMsgTitleBar.hide();
				jMsgBody.css('margin-top', 10);
			} else {
				jMsgTitleBar.show();
				jMsgBody.css('margin-top', 0);
				jMsgTitle.html(defaultOptions.title);
			}

			jMsgBody.html(defaultOptions.message);

			jMsgBox.modal({
				backdrop: 'static'
			});
		}
	}
})(jQuery);

Service.Prompt = (function (j) {
	var jMsgBox, jMsgTitleBar, jMsgTitle, jMsgBody, jTextBox,
		prompt, jReportStatus,
		btnSubmit, btnCancel, btnClose,
		isPromptBoxReady = false,
		defaultOptions = {
			title: 'Message',
			height: 80,
			placeholder: 'Write your message here...',
			onSubmit: function (message) { }
		},
		popupHTML = '<div class="modal fade" id="promptDialog" tabindex="-1" role="dialog" aria-labelledby="msgBoxTitle" aria-hidden="true">' +
					'	<div class="modal-dialog">' +
					'		<div class="modal-content">' +
					'			<div class="modal-header" style="padding: 8px 15px;">' +
					'   			<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
					'	    		<h4 class="modal-title" id="promptDialogTitle"></h4>' +
					'			</div>' +
					'			<div class="modal-body" style="padding: 12px 20px;">' +
					' 				<textarea class="textBox" rows="4" cols="15" style="width:100%; resize: none;"></textarea>' +
					'			</div>' +
					'			<div class="modal-footer" style="padding: 9px 20px 10px;">' +
                    //'		    	<em class="reportStatus" style="text-align: left;float:left;display:none;font-size:85%;max-width:60px;">Submitting report...</em>' +
					'   			<button type="button" style="padding: 3px 16px;" class="btn btn-primary btnPrompt-Submit">Submit</button>' +
					'	    		<button type="button" style="padding: 3px 16px;" class="btn btn-danger btnPrompt-Cancel" data-dismiss="modal">Cancel</button>' +
                    '		    	<em class="reportStatus" style="text-align: right;display:block;font-size:85%;margin-top:10px;">Submitting report...</em>' +
					'			</div>' +
					'		</div>' +
					'	</div>' +
					'</div>';

	function init() {
		if (isPromptBoxReady == false) {
			isPromptBoxReady = true;
			j('body').append(popupHTML);

			jMsgBox = j('#promptDialog');
			jMsgTitleBar = jMsgBox.find('.modal-header');
			jMsgTitle = jMsgBox.find('#promptDialogTitle');
			jMsgBody = jMsgBox.find('.modal-body');
			jTextBox = jMsgBody.find('.textBox');
			jReportStatus = jMsgBox.find('.reportStatus');
			btnSubmit = jMsgBox.find('.btnPrompt-Submit');
			btnCancel = jMsgBox.find('.btnPrompt-Cancel');

			prompt = {
				close: function () {
					//btnCancel.removeAttr().click();
					jMsgBox.modal('hide');
				}
			};

			btnSubmit.click(function () {
				j.extend(prompt, {
					message: jTextBox.val(),
				});

				if (prompt.message.length > 0) {
					btnSubmit.attr('disabled', 'disabled');
					btnCancel.attr('disabled', 'disabled');

					jReportStatus.fadeIn();

					defaultOptions.onSubmit.apply(this, [prompt]);
				}
			});
		}
	}

	return {

		// Shows a input dialog box with options (optional) provided as a JSON object.
		// - options: {
		// - - - title: 'Message',
		// - - - height: 80,
		// - - - placeholder: 'Write your message here...',
		// - - - onSubmit: function(message) {
		// - - - 	// do something if clicked 'Submit'
		// - - - }
		// - }
		show: function (options) {
			init();
			j.extend(defaultOptions, options);

			jMsgTitle.html(defaultOptions.title);
			jMsgBody.css('margin-top', 0);

			jTextBox.css('height', defaultOptions.height)
					.attr('placeholder', defaultOptions.placeholder);

			jReportStatus.hide();
			btnSubmit.removeAttr('disabled');
			btnCancel.removeAttr('disabled');

			jMsgBox.modal({
				backdrop: 'static'
			}).on('shown.bs.modal', function (e) {
				jTextBox.focus();
			}).on('hidden.bs.modal', function (e) {
				jTextBox.val("");
			});

		}
	}
})(jQuery);

; (function (j) {
	j(function () {
		j(document).ajaxComplete(function () {
		    //Service.DOM_Ready.callFunctions();
		    Service.Campaign.init();
		});
	});
})(jQuery);



Service.Loader = CLoader;



