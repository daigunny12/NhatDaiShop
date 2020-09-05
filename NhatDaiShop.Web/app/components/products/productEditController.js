(function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function productEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
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
        $scope.moreImages = [];
        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function LoadProductDetail() {
            apiService.get('/api/products/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                if ($scope.product.MorelImages != null) {
                    $scope.moreImages = JSON.parse($scope.product.MorelImages);
                }
               
            }, function (error) {
                notificationService.error(error.data);
            });
        }

        function UpdateProduct() {
            $scope.product.MorelImages = JSON.stringify($scope.moreImages);
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
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }

        
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }

        LoadParentCategory();
        LoadProductDetail();
    }
})(angular.module('nhatdaishop.products'));