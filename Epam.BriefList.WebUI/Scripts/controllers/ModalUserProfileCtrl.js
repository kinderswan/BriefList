angular.module('myApp').controller('ModalUserProfileController', function ($scope, $uibModal) {

    $scope.open = function (userId) {
        $uibModal.open({
            animation: true,
            templateUrl: '/Template/ModalUserProfile.html',
            controller: 'ModalProfileInstanceCtrl',
            backdrop: 'static',
            //size: 'lg',
            resolve: {
                userId: function () {
                    return userId;
                }
            }
        });
    };
});

angular.module('myApp').controller('ModalProfileInstanceCtrl', function ($scope, $uibModalInstance, userId, userProfileService) {

    var promiseObj = userProfileService.getUserProfile(userId);
    promiseObj.then(function (value) {
        //$uibModalInstance.dismiss('cancel');
        $scope.userProfile = value.data;
    });

    $scope.savePersonal = function (model, personalForm) {
        if (personalForm.$valid) {
            var promiseObj = userProfileService.update('/api/updatePersonalUsers/',model);

            promiseObj.then(function (value) {
                //не работает возврат сюда!!!!!!
          //      $rootScope.$broadcast('UpdateLists', $scope.ownerId);
                $uibModalInstance.dismiss('cancel');
                return value.data;
            });

        }
    };

    $scope.changePassword = function (passmodel, passwordForm) {
        if (passwordForm.$valid) {
            var promiseObj = userProfileService.update('/api/updatePassword/', passmodel);

            promiseObj.then(function (value) {
            //работает но посылает успех даже если и не успех!!
           //     $rootScope.$broadcast('UpdateLists', $scope.ownerId);
                $uibModalInstance.dismiss('change');
                return value.data;
            });

        }
    };






    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
