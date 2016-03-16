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

angular.module('myApp').controller('ModalProfileInstanceCtrl', function ($scope, $uibModalInstance, userId, userProfileService, loginService) {

    var getUserProfile = function() {
        var promiseObj = userProfileService.getUserProfile(userId);
        promiseObj.then(function(value) {
            $scope.userProfile = value.data;
            $scope.image = value.data.Photo;
        },
        function (error) {
            console.log(error.data.Message+" StatusCode:"+error.status);
        });
    };



    $scope.savePersonal = function (model, personalForm) {
        if (personalForm.$valid) {
            var promiseObj = userProfileService.update('/api/users/updatePersonalData/', model);


            promiseObj.then(function (resp) {
                console.log(resp.data.StatusCode);
            },
            function (error) {
                $scope.Errors = error.data;
            });

        }
    };

    $scope.changePassword = function (passmodel, passwordForm) {
        if (passwordForm.$valid) {
            var promiseObj = userProfileService.update('/api/users/updatePassword/', passmodel);

            promiseObj.then(function (resp) {
                console.log(resp.status);
                $uibModalInstance.dismiss('change');
                },
            function (error) {
                console.log(error.data);
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
