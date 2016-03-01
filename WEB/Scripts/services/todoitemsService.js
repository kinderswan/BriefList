myApp.factory('todoitemsService', function ($http) {

    this.getUserAllToDoItems= function(userId) {
        return $http.get('/api/users/' + userId + '/todoitems');
    }
})