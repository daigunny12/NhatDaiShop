(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function LoadProductCategoryDetail() {
            apiService.get('/api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.error(error.data);
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.productCategory.Image = fileUrl;
                })              
            }
            finder.popup();
        }

        function UpdateProductCategory() {
            apiService.put('/api/productcategory/update', $scope.productCategory,
                function (result) {
                    notificationService.success(result.data.Name + ' đã được cập nhật.')
                    $state.go('products_categories');
                }, function (error) {
                    notificationService.error('cập nhật không thành công.')
                });
        }
        function LoadParentCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('can not get list parent');
            });
        }
        LoadParentCategory();
        LoadProductCategoryDetail();
    }
})(angular.module('nhatdaishop.products_category'));