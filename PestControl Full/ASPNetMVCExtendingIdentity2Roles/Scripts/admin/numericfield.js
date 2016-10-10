$.prototype.numericfield = function (a) { $(this).keydown(function (e) { if ((e.keyCode >= 35 && e.keyCode <= 40) || e.keyCode == 8 || e.keyCode == 9 || e.keyCode == 13 || e.keyCode == 46 || (e.keyCode >= 112 && e.keyCode <= 123)) { return true } else if ((e.keyCode >= 96 && e.keyCode <= 105) || (e.keyCode >= 48 && e.keyCode <= 57)) { return !e.shiftKey } else if (e.keyCode == 190) { if (a != null && a != undefined && a["allow_decimal"] == true) { if ($(this).val().indexOf(".") < 0) { return !e.shiftKey } else { return false } } else { return false } } else if (e.keyCode == 110) { if (a != null && a != undefined && a["allow_decimal"] == true) { if ($(this).val().indexOf(".") < 0) { return true } else { return false } } else { return false } } else if (e.keyCode == 65 || e.keyCode == 67 || e.keyCode == 86 || (e.keyCode > 87 && e.keyCode < 91)) { return e.ctrlKey } else { return false } }); $(this).keyup(function (e) { if (e.keyCode == 86) { if (isNaN($(this).val())) { $(this).val("") } } }) };



;(function (j) {
	j(function () {
		j('[data-type=number]').each(function (index, el) {
			j(el).numericfield({
				allow_decimal: j(el).data('decimal')
			});
		});
	});
})(jQuery);
