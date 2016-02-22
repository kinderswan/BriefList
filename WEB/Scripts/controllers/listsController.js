var myApp = module('myApp');
module.controller('ListController', function ($scope) {

    $scope.lists = function () {
        return $http.get('/Home/MainPage');
    }

})