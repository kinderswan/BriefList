briefApp.controller('userListController', function ($scope, $routeParams, userListService, todoItemService) {
    $scope.message = 'userListController';

    $scope.loadUserLists = function (userId) {

        var promiseObj = userListService.getUserLists(window[userId]);
        promiseObj.then(function (value) {
            $scope.userLists = value.data;
        });
    }
    $scope.getListItems = function() {
        var promiseObj = todoItemService.getTodoItems($routeParams.id);
        promiseObj.then(function (value) {
            $scope.listTodoItems = value.data;
        });
    }

    $scope.loadUserLists();

});
