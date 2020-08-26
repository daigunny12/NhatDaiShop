/// <reference path="../../../bower_components/angular/angular.js" />
(function (app) {
    app.service('apiService',apiService);

    apiService.$inject = ['$http'];
    function apiService($http) {
        return {
            get: get
        }
        function get(url, params, sucess, failure) {
            $http.get(url, params).then(function (result) {
                sucess(result);
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('nhatdaishop.common'));