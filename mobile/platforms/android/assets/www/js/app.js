
var app = angular.module('avisai', ['ionic', 'ionic-material']);
app.run(function ($ionicPlatform) {
    $ionicPlatform.ready(function () {
        if (window.cordova && window.cordova.plugins.Keyboard) {
            cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
        }
        if (window.StatusBar) {
            StatusBar.styleDefault();
        }
    });
})
app.config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
    $stateProvider

    .state('app', {
        url: '/app',
        abstract: true,
        templateUrl: 'templates/menu.html',
        controller: 'AppCtrl'
    })

    .state('app.lists', {
        url: '/lists',
        views: {
            'menuContent': {
                templateUrl: 'templates/lists.html',
                controller: 'ListsCtrl',
                controllerAs: 'lstCtrl'
            }
        }
    })

    .state('app.about', {
        url: '/about',
        views: {
            'menuContent': {
                templateUrl: 'templates/about.html',
                controller: 'AboutCtrl'
            }
        }
    })

    .state('app.config', {
        url: '/config',
        views: {
            'menuContent': {
                templateUrl: 'templates/motion.html',
                controller: 'ConfigCtrl'
            }
        }
    })

    .state('app.presetation', {
        url: '/presetation',
        views: {
            'menuContent': {
                templateUrl: 'templates/presetation.html',
                controller: 'PresetationCtrl'
            }
        }
    })

    .state('app.notify', {
        url: '/notify',
        views: {
            'menuContent': {
                templateUrl: 'templates/notify.html',
                controller: 'NotifyCtrl',
                controllerAs: 'ntfCtrl'
            }
        }
    })
    ;

    // if none of the above states are matched, use this as the fallback
    $urlRouterProvider.otherwise('/app/presetation');
});
