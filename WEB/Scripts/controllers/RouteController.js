myApp.controller('RouteController',function ($scope, $routeParams, listService) {

          $scope.message = "routecontroller";  
        
             var   promiseObj = listService.getUserById($routeParams.id);
                promiseObj.then(function(value) {
                    $scope.user = value.data;
                });

    });

myApp.controller('HomeController', function ($scope, $routeParams, listService) {

    $scope.message = "homecontroller";

    var promiseObj = listService.getlists();
    promiseObj.then(function (value) {
        $scope.phones = value.data;
    });

});
