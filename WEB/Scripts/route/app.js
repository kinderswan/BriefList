var myApp = angular.module('myApp', ["ngRoute"])
    .config(function($routeProvider, $locationProvider) {

        $routeProvider
            .when("/", {
                redirectTo: function() {
                    return 'home';
                }
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
            })

        $locationProvider.html5Mode(false).hashPrefix('!');
    })

    .controller('ErrorController', function($scope) {

        $scope.message = "error";

    });
