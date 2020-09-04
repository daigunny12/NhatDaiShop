(function (app) {
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService' ];

    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true

        }
        $scope.AddProduct = AddProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.CkeditorOptions = {
            languague : 'vi',
            height : '200px'
        }

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function AddProduct() {
            apiService.post('/api/products/create', $scope.product,
                function (result) {
                    notificationService.success(result.data.Name + ' đã được thêm mới.')
                    $state.go('products');
                }, function (error) {
                    notificationService.error('Thêm mới không thành công.')
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
    }
})(angular.module('nhatdaishop.products'));