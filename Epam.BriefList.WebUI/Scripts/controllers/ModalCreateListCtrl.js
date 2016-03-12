
angular.module('myApp').controller('ModalCreateListController', function ($scope, $uibModal) {

    $scope.animationsEnabled = true;

    $scope.open = function (ownerId) {
        $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: '/Template/ModalCreateRenameList.html',
            controller: 'ModalInstanceCtrl',
            size: 'lg',
            resolve: {
                ownerId: function () {
                    return ownerId;
                }
            }
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

                $rootScope.$broadcast('UpdateLists', $scope.ownerId);
                $uibModalInstance.dismiss('cancel');
                return value.data;
            });

        }
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});


