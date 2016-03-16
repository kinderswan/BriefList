angular.module('myApp', ['ui.bootstrap', 'ngRoute', 'ngAnimate', 'dndLists'])
.config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/user/:id/lists", {
                templateUrl: "/Template/List.html",
                controller: 'ListController'
            })
            .when("/", {
                controller: 'ListController'
            })
            .when("/:id", {
                redirectTo: "/user/:id/lists",
                controller: 'ListController'
            })
            .when("/list/:id/todoitems", {
                templateUrl: "/Template/TodoItem.html",
                controller: 'ItemController'
            })
            .otherwise({
                templateUrl: "/Template/Error.html",
                controller: 'ErrorController'
            });

        $locationProvider.html5Mode(false).hashPrefix('!');
    })

    .controller('ErrorController', function($scope) {

        $scope.message = "error";

    });
