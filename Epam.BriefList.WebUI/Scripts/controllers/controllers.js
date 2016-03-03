myApp.controller('RouteController', function($scope, $routeParams, listService) {

        $scope.message = "routecontroller";

        var promiseObj = listService.getUserById($routeParams.id);
        promiseObj.then(function(value) {
            $scope.user = value.data;
        });

    })
    .controller('HomeController', function($scope, $routeParams, listService) {

        $scope.message = "homecontroller";

        var promiseObj = listService.getlists();
        promiseObj.then(function(value) {
            $scope.phones = value.data;
        });

    })

    .controller('LoginController', [
        '$scope', 'loginService', function($scope, loginService) {

            $scope.save = function(model, loginForm) {
                if (loginForm.$valid) {
                    var promiseObj = loginService.postLogin(model);
                    promiseObj.then(function (value) {
                        alert(model.Name + ", You enter");
                        return value.data;
                    });

                }
            };
        }
    ]);