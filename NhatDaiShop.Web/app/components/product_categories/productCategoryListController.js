/// <reference path="../../../bower_components/angular/angular.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];
    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];

        $scope.getproductCategories = getproductCategories;
        function getproductCategories() {
            apiService.get('/api/productcategory/getall', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Load productCategory Failed.');
            });
        }

        $scope.getproductCategories();
    }
})(angular.module('nhatdaishop.products_category'));