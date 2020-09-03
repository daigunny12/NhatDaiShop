﻿(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);
    productCategoryAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function productCategoryAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
            
        }
        $scope.AddProductCategory = AddProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function AddProductCategory() {
            apiService.post('/api/productcategory/create', $scope.productCategory,
                function (result) {
                    notificationService.success(result.data.Name + ' đã được thêm mới.')
                    $state.go('products_categories');
                }, function (error) {
                    notificationService.error('Thêm mới không thành công.')
                });
        }

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }
        function LoadParentCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('can not get list parent');
            });
        }
        LoadParentCategory();
    }
})(angular.module('nhatdaishop.products_category'));