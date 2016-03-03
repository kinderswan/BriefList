var briefApp = angular.module('briefApp', ["ngRoute"])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/user/:id/lists", {
                templateUrl: "/Template/List.html",
                controller: 'userListController'
            })
            .when("/", {
                controller: 'userListController'
            })
            .when("/:id", {
                redirectTo: "/user/:id/lists",
                controller: 'userListController'
            })
            .when("/list/:id/todoitems", {
                controller: 'userListController'
            })
            .otherwise({
                templateUrl: "/Template/Error.html",
                controller: 'ErrorController'
            });

        $locationProvider.html5Mode(false).hashPrefix('!');
    })

    .controller('ErrorController', function ($scope) {

        $scope.message = "error";

    });
