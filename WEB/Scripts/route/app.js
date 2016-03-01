var myApp = angular.module('myApp', ["ngRoute"])
    .config(function($routeProvider){
        $routeProvider.when('showLists',
        {
            templateUrl:'api/users/2/lists',
            controller:'ListController'
        });

})