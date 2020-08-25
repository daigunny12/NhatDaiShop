/// <reference path="../bower_components/angular/angular.js" />
(function () {
    angular.module('nhatdaishop', ['nhatdaishop.products','nhatdaishop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller:"homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();