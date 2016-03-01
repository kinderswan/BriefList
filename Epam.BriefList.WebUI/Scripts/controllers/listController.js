var myApp=angular.module('myApp');
myApp.controller("ListController", function ($scope,listService) {

    var promiseObj = listService.getlistsTitle();
    promiseObj.then(function (value) {
        $scope.phones = value.data;
    });

    }
);