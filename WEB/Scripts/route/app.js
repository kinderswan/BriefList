var myApp = angular.module('myApp', ["ngRoute"])
    .config(function($routeProvider){
        $routeProvider.when('showLists',
        {
            templateUrl:'List/_ShowLists',
            controller:'ListController'
        });

})