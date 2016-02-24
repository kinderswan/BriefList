var myApp=angular.module('myApp');
myApp.controller("ListController", function ($scope, $http) {

    $http.get("http://localhost:5157/List/Showlists")
        .then(function (response) {
        $scope.phones = response.data;
    });
    }
);