angular.module('myApp').controller('RouteController', function ($scope, $routeParams, listService) {

    $scope.message = "routecontroller";

    var promiseObj = listService.getUserById($routeParams.id);
    promiseObj.then(function (value) {
        $scope.user = value.data;
    });

})
    .controller('HomeController', function ($scope, $routeParams, listService) {

        $scope.message = "homecontroller";

        var promiseObj = listService.getlists();
        promiseObj.then(function (value) {
            $scope.phones = value.data;
        });

    })
    .controller('LoginController', [
        '$scope', 'loginService', function ($scope, loginService) {

            $scope.save = function (model, loginForm) {
                if (loginForm.$valid) {
                    var promiseObj = loginService.postLogin(model);
                    promiseObj.then(function (value) {
                        return value.data;
                    });

                }
            };
        }
    ])
    .controller('RegisterController', [
        '$scope', 'registerService', function ($scope, registerService) {

            $scope.save = function (model, registerForm) {
                if (registerForm.$valid) {
                    var promiseObj = registerService.postRegister(model);
                    promiseObj.then(function (value) {
                        return value.data;
                    });

                }
            };
        }
    ])
    .controller('GetListController', ['$timeout',
        '$scope', '$location', 'userListService', function ($timeout, $scope, $location, userListService) {

            $scope.message = 'GetListController';

            $scope.$on('UpdateLists', function (event, userId) {
                $scope.getAllLists(userId);
            });

            $scope.getAllLists = function (userId) {
                var promiseObj = userListService.getUserLists(userId);
                promiseObj.then(function (value) {
                    $scope.lists = value.data;
                });
            };

            $scope.deleteList = function (listId) {
                if (listId !== undefined) {
                    userListService.deleteList(listId);

                    var arr = $scope.lists;
                    for (var i = arr.length - 1; i >= 0; i--) {
                        if (arr[i].Id === listId) {
                            arr.splice(i, 1);
                        }
                    }
                    $scope.lists = arr;
                    $timeout(function () {
                        $location.path('/');
                    });

                } else {
                    console.log("error listId undefined getlistcontroller");
                }
            };


        }
    ])
    .controller('GetItemController', [
        '$scope', '$routeParams', 'itemService', function ($scope, $routeParams, itemService) {

            $scope.message = 'GetItemController';

            if ($routeParams.id !== undefined) {
                var promiseObj = itemService.getTodoItems($routeParams.id);
                promiseObj.then(function (value) {
                    $scope.items = value.data;
                    $scope.listId = $routeParams.id;
                });
            }

            $scope.completeTask = function (listId) {
                if ($scope.completeitems === undefined) {
                    var promiseObj = itemService.getCompleteItems(listId);
                    promiseObj.then(function (value) {
                        $scope.completeitems = value.data;
                    });
                } else {
                    $scope.completeitems = undefined;
                }

            };

            $scope.addItem = function (listId) {
                if (listId !== undefined && $scope.inputItem !== undefined) {
                    var promiseObj = itemService.addItem(listId, $scope.inputItem);
                    promiseObj.then(function (value) {
                        $scope.items.push(value.config.data);
                    });
                } else {
                    console.log(listId + "listId or inputItem error GetItemController");
                }

            };

            $scope.deleteItem = function (id) {
                if (id === undefined) {
                    if ($routeParams.id !== undefined) {
                        var promise = itemService.getTodoItems($routeParams.id);
                        promise.then(function (value) {
                            $scope.items = value.data;
                            $scope.listId = $routeParams.id;
                        });
                    } else {
                        alert("error $routeParams.id undefined GetItemController");
                    }
                }
                itemService.deleteItem(id);

                console.log($scope.items);

                var arr = $scope.items;
                for (var i = arr.length - 1; i >= 0; i--) {
                    if (arr[i].Id === id) {
                        arr.splice(i, 1);
                    }
                }
                $scope.items = arr;

            };


            $scope.markAsCompleted = function (item) {

                item.Completed = !item.Completed;
                var promiseObj = itemService.updateItem(item);
                promiseObj.then(function (value) {

                    var iarr = $scope.items;
                    for (var i = iarr.length - 1; i >= 0; i--) {
                        if (iarr[i].Id === item.Id) {
                            iarr.splice(i, 1);
                        }
                    }
                    $scope.items = iarr;

                    $scope.completeitems.push(value.config.data);
                });

                console.log(item);
                alert(item.Title + 'need to be completed');
            };

        }
    ]);