(function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams' , 'commonService'];

    function productEditController(apiService, $scope, notificationService, $state, $stateParams,commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true

        }
        $scope.UpdateProduct = UpdateProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.CkeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function LoadProductDetail() {
            apiService.get('/api/products/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
            }, function (error) {
                notificationService.error(error.data);
            });
        }

        function UpdateProduct() {
            apiService.put('/api/products/update', $scope.product,
                function (result) {
                    notificationService.success(result.data.Name + ' đã được cập nhật.')
                    $state.go('products');
                }, function (error) {
                    notificationService.error('Cập nhật không thành công.')
                });
        }
        function LoadParentCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('can not get list parent');
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl;
            }
            finder.popup();
        }

        LoadParentCategory();
        LoadProductDetail();
    }
})(angular.module('nhatdaishop.products'));