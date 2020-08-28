/// <reference path="../../../bower_components/angular/angular.js" />
(function (app) {
    app.factory('notificationService', notificationService);

    function notificationService() {
        toastr.options = {
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "fadeIn": 300,
            "fadeOut": 1000,
            "timeOut": 3000,
            "extendedTimeOut": 1000
        };
        
        function success(messasge) {
            toastr.success(messasge);
        }

        function error(error) {
            if (Array.isArray(error)) {
                error.each(function (err) {
                    toastr.error(err)
                });
            } else {
                toastr.error(error)
            }
        }

        function warning(messasge) {
            toastr.warning(messasge);
        }

        function infor(messasge) {
            toastr.infor(messasge);
        }

        return {
            success: success,
            error: error,
            warning: warning,
            infor: infor
        }
    }
})(angular.module('nhatdaishop.common'));