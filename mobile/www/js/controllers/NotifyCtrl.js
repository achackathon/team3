﻿app.controller('NotifyCtrl', function ($scope, $stateParams, $ionicActionSheet, $timeout, $ionicLoading, $ionicModal, $ionicPopup, ionicMaterialInk, notifyService, helperService, $cordovaGeolocation) {
    //Using this variable to control scope.
    var vm = this;

    vm.myNotification = {Name:"",
                         Latitude:-43.935169,
                         Longitude:-19.93622,
                         Description:"",
                         User:{UserId:5,Name:"Maza",Email:"menriqueraraujo@gmail.com",Senha:null,ReceiveEmail:false},
                         NotificationType: null
                        }
    vm.notificationTypeList;
    vm.notificationTypeSelected;
    vm.notificationTypeOptions;
    vm.notificationValue = 0;
    vm.getOptions = function() {
       notifyService.getOptions(vm.notificationTypeSelected.id, function(err,data) {
        if(err) helperService.showAlert('erro', data);
          vm.notificationTypeOptions = data;
      });
    };

    vm.getNotificationTypes = function() {
      notifyService.getNotificationTypes(function(err,data) {
      if(err) helperService.showAlert('erro', data);
        vm.notificationTypeList = data;
      });
    };
    vm.showNotificationOptions = function() {
      return (vm.notificationTypeOptions != 'undefined' &&
         vm.notificationTypeOptions.length > 0)
    };
    vm.onChangeNotificationType = function(){
      helperService.loadingShow();
      if(vm.notificationTypeSelected != 'undefined')
      vm.notificationTypeOptions = notifyService.getOptions(vm.notificationTypeSelected.id, function(err,data) {
        if(err) helperService.showAlert('erro', data);
          vm.notificationTypeOptions = data;
      });
      helperService.loadingHide();
    };
    vm.saveNotification = function(notifiation) {
      helperService.loadingShow();
      notifyService.save();
      helperService.loadingHide();
      helperService.showAlert('Informacao', 'Notificação salva com Sucesso!', null);
    };

    vm.notificationTypeList = vm.getNotificationTypes();

    // Triggered on a button click, or some other target
    $scope.actionSheet = function() {

        // Show the action sheet
        var hideSheet = $ionicActionSheet.show({
            buttons: [{
                text: '<b>Share</b> This'
            }, {
                text: 'Move'
            }],
            destructiveText: 'Delete',
            titleText: 'Modify your album',
            cancelText: 'Cancel',
            cancel: function() {
                // add cancel code..
            },
            buttonClicked: function(index) {
                return true;
            }
        });

        // For example's sake, hide the sheet after two seconds
        $timeout(function() {
            hideSheet();
        }, 2000);

    };

    $scope.loading = function() {
        $ionicLoading.show({
            template: '<div class="loader"><svg class="circular"><circle class="path" cx="50" cy="50" r="20" fill="none" stroke-width="2" stroke-miterlimit="10"/></svg></div>'
        });

        // For example's sake, hide the sheet after two seconds
        $timeout(function() {
            $ionicLoading.hide();
        }, 2000);
    };

    $ionicModal.fromTemplateUrl('my-modal.html', {
        scope: $scope,
        animation: 'slide-in-up'
    }).then(function(modal) {
        $scope.modal = modal;
    });

    $scope.openModal = function() {
        $scope.modal.show();
        $timeout(function () {
            $scope.modal.hide();
        }, 2000);
    };
    // Cleanup the modal when we're done with it
    $scope.$on('$destroy', function() {
        $scope.modal.remove();
    });

    // Popover
    $scope.popover = function() {
        $scope.$parent.popover.show();
        $timeout(function () {
            $scope.$parent.popover.hide();
        }, 2000);
    };

    // Confirm
    $scope.showPopup = function() {
        var alertPopup = $ionicPopup.alert({
            title: 'You are now my subscribed to Cat Facts',
            template: 'You will meow receive fun daily facts about CATS!'
        });

        $timeout(function() {
            //ionic.material.ink.displayEffect();
            ionicMaterialInk.displayEffect();
        }, 0);
    };

    // Toggle Code Wrapper
    var code = document.getElementsByClassName('code-wrapper');
    for (var i = 0; i < code.length; i++) {
        code[i].addEventListener('click', function() {
            this.classList.toggle('active');
        });
    }
});
