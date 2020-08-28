/// <reference path="../../../bower_components/angular/angular.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService' ];
    function productCategoryListController($scope, apiService, notificationService) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getproductCategories = getproductCategories;
        $scope.keyword = '';

        $scope.search = search;

        function search() {
            getproductCategories();
        }
        function getproductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                     page : page, 
                     pageSize :2
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {

                if (result.data.TotalPages == 0) {
                    notificationService.warning('không có bản ghi nào được tìm thấy');
                }
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;

               
                
            }, function () {
                console.log('Load productCategory Failed.');
            });
        }

        $scope.getproductCategories();
    }
})(angular.module('nhatdaishop.products_category'));