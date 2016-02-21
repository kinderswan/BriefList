var myApp = module('myApp');
module.controller('listsController', function ($scope) {

    $scope.lists = function () {

        return $http.get('/Home/MainPage');

    }
    $scope.lists =
    [
        {
    
        }
    ];

})