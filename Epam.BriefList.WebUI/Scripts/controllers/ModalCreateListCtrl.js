
angular.module('myApp').controller('ModalCreateListController', function ($scope, $uibModal, $log) {



    $scope.animationsEnabled = true;

    $scope.open = function (ownerId) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: '/Template/ModalCreateList.html',
            controller: 'ModalInstanceCtrl',
            size: 'lg',
            resolve: {
                ownerId: function () {
                    return ownerId;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };

});

// Please note that $uibModalInstance represents a modal window (instance) dependency.
// It is not the same as the $uibModal service used above.

angular.module('myApp').controller('ModalInstanceCtrl', function ($scope, $rootScope, $uibModalInstance, ownerId, userListService) {

    $scope.ownerId = ownerId;

    $scope.save = function (model, listForm) {
        if (listForm.$valid) {
            var promiseObj = userListService.addList(model);

            promiseObj.then(function (value) {

                $rootScope.$broadcast('UpdateLists', ownerId);

                alert(model.Title + ", You add list");
                $uibModalInstance.dismiss('cancel');
                return value.data;
            });

        }
    };
    
    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});


