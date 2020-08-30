/// <reference path="../bower_components/angular/angular.js" />
(function () {
    angular.module('nhatdaishop.products_category', ['nhatdaishop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products_categories', {
            url: "/products_categories",
            templateUrl: "/app/components/product_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        }).state('add_products_category', {
            url: "/add_products_category",
            templateUrl: "/app/components/product_categories/productCategoryAddView.html",
            controller: "productCategoryAddController"
        }).state('edit_products_category', {
            url: "/edit_products_category",
            templateUrl: "/app/components/product_categories/productCategoryEditView.html",
            controller: "productCategoryEditController"
        });
    }
})();