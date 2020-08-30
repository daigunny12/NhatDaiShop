/// <reference path="../../../bower_components/angular/angular.js" />
(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService'];
    function apiService($http, notificationService) {
        return {
            get: get,
            post: post,
            put: put
        }

        function post(url, data, sucess, failure) {
            $http.post(url, data).then(function (result) {
                sucess(result);
            }, function (error) {
                console.log(error.status)
                if (error.Status === 401) {
                    notificationService.error('Authenticate is required');
                } else if (failure != null) {
                    failure(error);
                }
            });
        }

        function put(url, data, sucess, failure) {
            $http.put(url, data).then(function (result) {
                sucess(result);
            }, function (error) {
                console.log(error.status)
                if (error.Status === 401) {
                    notificationService.error('Authenticate is required');
                } else if (failure != null) {
                    failure(error);
                }
            });
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