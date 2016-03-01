listApp.controller('listController', function ($scope, listService) {
    getLists();
    function getLists() {

        listService.getLists()

            .success(function (lst) {

                $scope.lists = lst;

                console.log($scope.lists);

            })

            .error(function (error) {

                $scope.status = 'Unable to load customer data: ' + error.message;

                console.log($scope.status);

            });

    }

});
var listApp = angular.module('listApp', []);
listApp.factory('listService', ['$http', function ($http) {

 

    var listService = {};

    listService.getStudents = function () {

        return $http.get('/List/_ShowLists');

    };

    return listService;

 

}]);