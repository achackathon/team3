app.factory('helperService', function ($ionicLoading, $ionicPopup, $timeout, $http) {
  var vm = this;

  function getHttpRequest(url,callback) {
    $http.get('http://avisaai.azurewebsites.net/api/' + url)
         .then(function(resp) {
           callback(false,resp);
            console.log('Succ ess', resp);
          }, function(err) {
            callback(true, err);
            console.error('ERR', err);
     });
  };

  function showLoading() {
    $ionicLoading.show({
      content: 'Loading',
      animation: 'fade-in',
      showBackdrop: true,
      maxWidth: 200,
      showDelay: 0
    });
    $timeout(function () {
      $ionicLoading.hide();
    }, 12000);
  };

  function hideLoading() {
    $ionicLoading.hide();
  };

  function showAlertFunction(title, description, callback) {
    var alertPopup = $ionicPopup.alert({
        title: title,
        template: description
    });
    alertPopup.then(callback);
  };


  vm.getMyGeoLocation = function () {
    console.log(window.cordova);
    if(window.cordova) {
      var currentPosMarker;
      var posOptions = {timeout: 10000, enableHighAccuracy: false};
      $cordovaGeolocation
      .getCurrentPosition(posOptions)
      .then(function(position) {
        var lat         = position.coords.latitude,
        long            = position.coords.longitude,
        initialLocation = new google.maps.LatLng(lat, long);
        console.log(initialLocation);
        return initialLocation;
/*
        map.setCenter(initialLocation);

        currentPosMarker = new google.maps.Marker({
          position: initialLocation,
          animation: google.maps.Animation.DROP,
          optimized: false,
          icon: 'img/icon-anchor.gif',
          map: map
        });          */

      });
    }
  };

  return {
    loadingShow: function() {
      return showLoading();
    },
    loadingHide: function () {
      return hideLoading();
    },
    showAlert: function(title, description, callback) {
      return showAlertFunction(title, description, callback);
    },
    getHttpRequest: function functionName(url,callback) {
      return getHttpRequest(url,callback);
    }
  }
});