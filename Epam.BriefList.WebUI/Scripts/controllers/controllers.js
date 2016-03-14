angular.module('myApp')
    .controller('RouteController', function ($scope, $routeParams, listService) {

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
    .controller('GetListController', [
        '$timeout',
        '$scope', '$location', 'userListService', function ($timeout, $scope, $location, userListService) {

            $scope.message = 'GetListController';

            $scope.$on('UpdateLists', function (event, userId) {
                $scope.getAllLists(userId);
            });
            $scope.$on('RenameList', function (event, oldmodel) {
                var arr = $scope.lists;
                for (var i = arr.length - 1; i >= 0; i--) {
                    if (arr[i].Id === oldmodel.Id) {
                        arr[i] = oldmodel;
                    }
                }
                $scope.lists = arr;
            });

            $scope.getAllLists = function (userId) {
                var promiseObj = userListService.getUserLists(userId);
                promiseObj.then(function (value) {
                    $scope.lists = value.data;
                    $scope.$parent.userId = userId;
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
                    $scope.$parent.currentList = null;
                    $timeout(function () {
                        $location.path('/');
                    });

                } else {
                    console.log("error listId undefined getlistcontroller");
                }
            };


        }
    ])
    .controller('GetItemController', ['$scope', '$routeParams', 'itemService',
        function ($scope, $routeParams, itemService) {

            $scope.message = 'GetItemController';

            if ($routeParams.id !== undefined) {
                var promiseObj = itemService.getTodoItems($routeParams.id);
                promiseObj.then(function (value) {
                    $scope.items = value.data;
                    $scope.listId = $routeParams.id;
                    $scope.$parent.currList();
                });
            }

            $scope.$on('RenameItem', function (event, item) {
                var model = {
                    Id: item.Id,
                    ListId: item.ListId,
                    Title: item.Title,
                    TimeComplete: item.TimeComplete,
                    Completed: item.Completed,
                    Starred: item.Starred,
                    Comment: item.Comment
                };
                var promiseObj = itemService.updateItem(model);

                promiseObj.then(function (value) {
                    var promise = itemService.getTodoItems($routeParams.id);
                    promise.then(function (value) {
                        $scope.items = value.data;
                        $scope.listId = $routeParams.id;
                    });
                });
            });

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
                        console.log(value.config.data);
                        var promiseObj = itemService.getTodoItems($routeParams.id);
                        promiseObj.then(function (value) {
                            $scope.items = value.data;
                        });
                    });
                } else {
                    console.log(listId + "listId or inputItem error GetItemController");
                }

            };

            $scope.deleteItem = function (id, isCompleted) {

                itemService.deleteItem(id);
                $scope.$parent.detoggle();
                alert($scope.items);
                if (isCompleted) {
                    var arr = $scope.items;
                    for (var i = arr.length - 1; i >= 0; i--) {
                        if (arr[i].Id === id) {
                            arr.splice(i, 1);
                        }
                    }
                    $scope.items = arr;
                } else {
                    var arr1 = $scope.completeitems;
                    for (var j = arr1.length - 1; j >= 0; j--) {
                        if (arr1[j].Id === id) {
                            arr1.splice(j, 1);
                        }
                    }
                    $scope.completeitems = arr1;
                }


            };

            $scope.markAsCompleted = function (item) {
                var date = new Date();
                var model = {
                    Id: item.Id,
                    ListId: item.ListId,
                    Title: item.Title,
                    TimeComplete: date.toISOString(),
                    Completed: item.Completed,
                    Starred: item.Starred,
                    Comment: item.Comment
                };

                var promiseObj = itemService.updateItem(model);
                promiseObj.then(function (value) {

                    var arr = $scope.items;
                    for (var i = arr.length - 1; i >= 0; i--) {
                        if (arr[i].Id === item.Id) {
                            arr.splice(i, 1);
                        }
                    }
                    $scope.items = arr;

                    $scope.completeitems.push(value.config.data);
                });

            };

            $scope.markAsUnCompleted = function (item) {
                var model = {
                    Id: item.Id,
                    ListId: item.ListId,
                    Title: item.Title,
                    TimeComplete: null,
                    Completed: item.Completed,
                    Starred: item.Starred
                };

                var promiseObj = itemService.updateItem(model);
                promiseObj.then(function (value) {

                    var arr = $scope.completeitems;
                    for (var i = arr.length - 1; i >= 0; i--) {
                        if (arr[i].Id === item.Id) {
                            arr.splice(i, 1);
                        }
                    }
                    $scope.completeitems = arr;

                    $scope.items.push(value.config.data);
                });


            }

            $scope.showDetails = function (item) {
                $scope.$parent.toggle(item);
            }
        }
    ])
    .controller('IndexCtrl', [
        '$scope', '$routeParams', 'itemService', 'userListService',
        function ($scope, $routeParams, itemService, userListService) {

            $scope.message = 'IndexCtrl';

            $scope.currList = function () {
                var promiseObj = userListService.getUserListsById($scope.userId, $routeParams.id);
                promiseObj.then(function (value) {
                    $scope.currentList = value.data;
                    console.log($scope.currentList);
                });

            }

            $scope.toggle = function (item) {
                var toggleEl = angular.element(document.querySelector('#detail'));
                $scope.detailItem = item;
                toggleEl.css('width', '30%');
            }

            $scope.detoggle = function () {
                var toggleEl = angular.element(document.querySelector('#detail'));
                toggleEl.css('width', '0px');
                $scope.$broadcast("RenameItem", $scope.detailItem);

            }
        }
    ]);