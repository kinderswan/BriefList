angular.module('myApp').controller('RouteController', function($scope, $routeParams, listService) {

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
            $scope.$on('UpdateLists', function(event, userId) {
                getAllLists(userId);
            });

            $scope.getAllLists = function(userId) {
                var promiseObj = userListService.getUserLists(userId);
                promiseObj.then(function(value) {
                    $scope.lists = value.data;
                });
            };

        }
    ])
    .controller('GetItemController', [
        '$scope', '$routeParams', 'itemService', function($scope, $routeParams, itemService) {

            $scope.message = 'GetItemController';

            if ($routeParams.id !== undefined) {
                var promiseObj = itemService.getTodoItems($routeParams.id);
                promiseObj.then(function(value) {
                    $scope.items = value.data;
                    $scope.listTaskId = $routeParams.id;
                });
            }

            $scope.completeTask = function(listId) {
                if ($scope.completeitems === undefined) {
                    var promiseObj = itemService.getCompleteItems(listId);
                    promiseObj.then(function(value) {
                        $scope.completeitems = value.data;
                    });
                } else {
                    $scope.completeitems = undefined;
                }

            };
            $scope.addItem = function (listId) {
                console.log(listId);
                if (listId != undefined) {
                    var promiseObj = itemService.addItem(listId, $scope.inputItem);
                    promiseObj.then(function (value) {
                        $scope.completeitems = value.data;
                    });
                } else {
                    console.log("Some error in add item ctrl");
                }
                
            }

        }
    ]);