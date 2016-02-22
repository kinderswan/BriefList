var questApp = angular.module('myApp', ["ngRoute"])
    .config(function($routeProvider){
        $routeProvider.when('/ShowLists',
        {
            templateUrl:'Views/Lists/ShowLists.cshtml',
            controller:'ListController'
        });

})