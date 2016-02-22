var myApp = angular.module('myApp', ["ngRoute"])
    .config(function($routeProvider){
        $routeProvider.when('/_ShowLists',
        {
            templateUrl:'~/Views/Lists/_ShowLists.cshtml',
            controller:'listController'
        });

})