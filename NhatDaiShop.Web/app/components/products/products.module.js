﻿/// <reference path="../bower_components/angular/angular.js" />
(function () {
    angular.module('nhatdaishop.products', ['nhatdaishop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: "/products",
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListController"
        }).state('product_add', {
            url: "/product_add",
          //  parent: 'base',
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddController"
        }).state('product_edit', {
            url: "/product_edit/:id",
            templateUrl: "/app/components/products/productEditView.html",
            controller: "productEditController"
        });
    }
})();