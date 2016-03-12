angular.module('myApp', ['ui.bootstrap', 'ngRoute', 'ngAnimate'])
.config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/user/:id/lists", {
                templateUrl: "/Template/List.html",
                controller: 'GetListController'
            })
            .when("/", {
                controller: 'GetListController'
            })
            .when("/:id", {
                redirectTo: "/user/:id/lists",
                controller: 'GetListController'
            })
            .when("/list/:id/todoitems", {
                templateUrl: "/Template/TodoItem.html",
                controller: 'GetItemController'
            })
            .when("/home", {
                templateUrl: "/Template/Home.html",
                controller: 'HomeController'
            })
            .when("/route/:id", {
                templateUrl: "/Template/Route.html",
                controller: 'RouteController'
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
