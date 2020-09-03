(function (app) {
    app.controller('productListController', productListController);
    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.products = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getproducts = getproducts;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteProducts = deleteProducts;
        $scope.selectAll = selectAll;
        $scope.deleteMutiple = deleteMutiple;

        function deleteMutiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedProducts: JSON.stringify(listId)
                }
            }
            apiService.del('/api/products/deletemulti', config, function (result) {
                notificationService.success('Xóa thành công ' + result.data + ' bản ghi.');
                search();
            }, function (error) {
                notificationService.error('Xóa không thành công.');
            });
        }

        function deleteProducts(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/products/delete', config, function () {
                    notificationService.success('Xóa thành công');
                    search();
                }, function () {
                    notificationService.error('Xóa không thành công!');
                })
            });
        }

        $scope.$watch("products", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function search() {
            getproducts();
        }
        function getproducts(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('/api/products/getall', config, function (result) {
                if (result.data.TotalPages == 0) {
                    notificationService.warning('không có bản ghi nào được tìm thấy');
                }
                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load products Failed.');
            });
        }
        $scope.getproducts();
    }
})(angular.module('nhatdaishop.products'));