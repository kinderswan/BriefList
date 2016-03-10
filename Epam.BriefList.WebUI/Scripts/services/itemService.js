angular.module('myApp').factory('itemService', function ($http, $q/*, $filter*/) {
    return {
        getTodoItems: function (id) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/api/lists/' + id + '/todoitems/' + false
            }).then(function (resp) {
                deferred.resolve(resp);
            }),
            function (error) {
                deferred.reject({ success: false, data: error });
            };

            return deferred.promise;
        },

        getCompleteItems: function (id) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/api/lists/' + id + '/todoitems/' + true
            }).then(function (resp) {
                deferred.resolve(resp);
            }),
            function (error) {
                deferred.reject({ success: false, data: error });
            };

            return deferred.promise;
        },

        addItem: function (listId, inputItem) {

            var model = {
                ListId: listId,
                Title: inputItem,
                // TimeComplete: $filter('date')(new Date(), 'dd/MM/yyyy HH:mm:ss'),
                Completed: false,
                Starred: false
            };
            var deferred = $q.defer();
            $http.post('/api/todoitems', model)
            .then(function (resp) {
                deferred.resolve(resp);
            }),
            function (error) {
                deferred.reject({ success: false, data: error });
            };

            return deferred.promise;
        },

        deleteItem: function (id) {
            var deferred = $q.defer();
            $http.delete('/api/deletetodoitems/' + id)
            .then(function (resp) {
                deferred.resolve(resp);
            }),
            function (error) {
                deferred.reject({ success: false, data: error });
            };

            return deferred.promise;
        }
    }
});