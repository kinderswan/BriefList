var myApp=angular.module('myApp');
myApp.controller("ListController", function ($scope,listService) {

    var promiseObj = listService.getData();
    promiseObj.then(function (value) {
        $scope.phones = value.data;
    });

    }
);