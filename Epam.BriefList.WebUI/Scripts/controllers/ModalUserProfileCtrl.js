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

angular.module('myApp').controller('ModalProfileInstanceCtrl', function ($scope, $uibModalInstance, userId, userProfileService, loginService, $http) {

    var getUserProfile = function() {
        var promiseObj = userProfileService.getUserProfile(userId);
        promiseObj.then(function(value) {
            $scope.userProfile = value.data;
            $scope.image = value.data.Photo;
        },
        function (error) {
            console.log(error);
        });
    };



    $scope.savePersonal = function (model, personalForm) {
        if (personalForm.$valid) {
            var promiseObj = userProfileService.update('/api/users/updatePersonalUsers/', model);

            promiseObj.then(function (value) {
                //не работает возврат сюда!!!!!!
                //      $rootScope.$broadcast('UpdateLists', $scope.ownerId);
                //      $uibModalInstance.dismiss('cancel');
                console.log(value);
                return value.data;
            },
            function (error) {
                console.log(error);
            },
            function () {
                $uibModalInstance.dismiss('cancel');
            }
            );

        }
    };

    $scope.changePassword = function (passmodel, passwordForm) {
        if (passwordForm.$valid) {
            var promiseObj = userProfileService.update('/api/users/updatePassword/', passmodel);

            promiseObj.then(function (value) {
                //работает но посылает успех даже если и не успех!!
                //     $rootScope.$broadcast('UpdateLists', $scope.ownerId);
                $uibModalInstance.dismiss('change');
                return value.data;
            },
            function (error) {
                console.log(error);
            },
            function () {
                $uibModalInstance.dismiss('cancel');
            });

        }
    };

    $scope.selectFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    }

    $scope.SaveFile = function () {
        var promiseObj = userProfileService.uploadFile($scope.SelectedFileForUpload, $scope.userId);
        promiseObj.then(function (resp) {
            console.log(resp);
            getUserProfile();

            },
        function (error) {
            console.log(error);
        });

    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.signOut = function () {

        $uibModalInstance.dismiss('cancel');
        loginService.signOut();
    };

    getUserProfile();

});
