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
    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
