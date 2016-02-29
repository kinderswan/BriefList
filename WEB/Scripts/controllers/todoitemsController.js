var myApp = angular.module('myApp');
myApp.controller("ToDoItemsController", function ($scope, todoitemsService, id) {

    var promiseObj = todoitemsService.getUserAllToDoItems(id);
    promiseObj.then(function (value) {
        $scope.todoitems = value.data;
    });

}
);