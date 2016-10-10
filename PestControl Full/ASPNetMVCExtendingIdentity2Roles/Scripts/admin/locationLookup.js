/// <reference path="services.js" />
/// <reference path="scripts.js" />



SilentAction.Location = (function (j) {
	var $_location, $_latitude, $_longitude;

	function _getLocation(_successCallback, _errorCallback) {
		if (Modernizr.geolocation) {
			navigator.geolocation.getCurrentPosition(
				_onSuccess.bind(this, _successCallback),
				_onError.bind(this, _errorCallback)
			);
		} else if (navigator.geolocation) {
			navigator.geolocation.getCurrentPosition(
				_onSuccess.bind(this, _successCallback),
				_onError.bind(this, _errorCallback)
			);
		} else {
			// no native support; maybe try a fallback?
		}
	};

	function _onSuccess(callback, position) {
		$_latitude = position.coords.latitude;
		$_longitude = position.coords.longitude;

		$_location = {
			lat: $_latitude,
			lng: $_longitude
		}
		callback($_location);
	}

	function _onError(callback, err) {
		callback();
	}

	return {
		nearByLookup: function (_successCallback, _errorCallback) {
			_getLocation(_successCallback, _errorCallback);
		}
    }

})(jQuery);

