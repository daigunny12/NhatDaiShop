/// <reference path="../../../bower_components/angular/angular.js" />
(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService', 'authenticationService'];
    function apiService($http, notificationService, authenticationService) {
        return {
            get: get,
            post: post,
            put: put, 
            del: del
        }

        function post(url, data, sucess, failure) {
            authenticationService.setHeader();
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
            authenticationService.setHeader();
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
            authenticationService.setHeader();
            $http.get(url, params).then(function (result) {
                sucess(result);
            }, function (error) {
                failure(error);
            });
        }
        function del(url, data, sucess, failure) {
            authenticationService.setHeader();
            $http.delete(url, data).then(function (result) {
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
  
    }
})(angular.module('nhatdaishop.common'));