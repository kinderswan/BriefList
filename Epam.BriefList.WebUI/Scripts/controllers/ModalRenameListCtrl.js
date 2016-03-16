
angular.module('myApp').controller('ModalRenameListController', function ($scope, $uibModal) {


    $scope.open = function (list) {
         $uibModal.open({
            animation: true,
            templateUrl: '/Template/ModalCreateRenameList.html',
            controller: 'ModalRenameInstanceCtrl',
            size: 'lg',
            resolve: {
                list: function () {
                    return list;
                }
            }
        });

    };

});


angular.module('myApp').controller('ModalRenameInstanceCtrl', function ($scope, $rootScope, $uibModalInstance, list, listService) {

    $scope.model = list;
    $scope.oldmodel = angular.copy(list);
    $scope.ownerId = list.OwnerId;

    $scope.save = function (model, listForm) {
        if (listForm.$valid) {
            var promiseObj = listService.updateList(model);
            promiseObj.then(function(value) {

                $uibModalInstance.dismiss('cancel');
                return value.data;
            });

        } else {
            console.log('ModalRenameInstanceCtrl error Title List');
        }
    };
    
    $scope.cancel = function () {
        $rootScope.$broadcast('RenameList', $scope.oldmodel);
        $uibModalInstance.dismiss('cancel');
    };



});


