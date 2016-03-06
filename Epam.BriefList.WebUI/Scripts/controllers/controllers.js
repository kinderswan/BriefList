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
                    promiseObj.then(function(value) {
                        alert(model.Name + ", You enter");
                        return value.data;
                    });

                }
            };
        }
    ])
    .controller('RegisterController', [
        '$scope', 'registerService', function($scope, registerService) {

            $scope.save = function(model, registerForm) {
                if (registerForm.$valid) {
                    var promiseObj = registerService.postRegister(model);
                    promiseObj.then(function(value) {
                        alert(model.Name + ", You register");
                        return value.data;
                    });

                }
            };
        }
    ])
    .controller('GetListController', [
        '$scope', 'userListService', function($scope, userListService) {

            $scope.message = 'GetListController';

            $scope.getAllLists = function(userId) {
                var promiseObj = userListService.getUserLists(userId);
                promiseObj.then(function(value) {
                    $scope.lists = value.data;
                });
            };

            $scope.save = function(model, listForm) {
                if (listForm.$valid) {
                    var promiseObj = userListService.addList(model);
                    promiseObj.then(function(value) {
                        alert(model.Title + ", You add list");
                        return value.data;
                    });

                }
            };

        }
    ])
    .controller('GetItemController', [
        '$scope', '$routeParams', 'itemService', function($scope, $routeParams, itemService) {

            $scope.message = 'GetItemController';
           

            var promiseObj = itemService.getTodoItems($routeParams.id);
            promiseObj.then(function(value) {
                $scope.items = value.data;
                $scope.listId = $routeParams.id;
            });

            $scope.completeTask = function (listId) {
                if ($scope.completeitems !== 'undefined') {
                    promiseObj = itemService.getCompleteItems(listId);
                    promiseObj.then(function(value) {
                        $scope.completeitems = value.data;
                    });
                } else {
                    $scope.completeitems = 'undefined';
                }
 
            }

        }]);

