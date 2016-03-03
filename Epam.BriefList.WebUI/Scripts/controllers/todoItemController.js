briefApp.controller('todoItemController', function ($scope, $routeParams, todoItemService) {
    $scope.message = 'todoItemController';

    var promiseObj = todoItemService.getTodoItems(3);
    promiseObj.then(function (value) {
        $scope.listTodoItems = value.data;
    });
});
