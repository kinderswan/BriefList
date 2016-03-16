angular.module('myApp').factory('listService', ['$http', '$q', function ($http, $q) {
    return {
        getUserLists: function(userId) {
            var deferred = $q.defer();
            $http({
                    method: 'GET',
                    url: '/api/users/' + userId + '/lists'
                }).then(function(resp) {
                    deferred.resolve(resp);
                },
                function(error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        getUserListsById: function (userId, listId) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/api/users/' + userId + '/lists/' + listId
            }).then(function (resp) {
                deferred.resolve(resp);
            }),
                function (error) {
                    deferred.reject({ success: false, data: error });
                };

            return deferred.promise;
        },
        addList: function(model) {
            var deferred = $q.defer();
            $http.post('/api/lists/add', model)
                    .then(function(resp) {
                        deferred.resolve(resp);
                    }),
                function(error) {
                    deferred.reject({ success: false, data: error });
                };

            return deferred.promise;
        },

        deleteList: function(id) {
            var deferred = $q.defer();
            $http.delete('/api/lists/delete/' + id)
                    .then(function(resp) {
                        deferred.resolve(resp);
                    }),
                function(error) {
                    deferred.reject({ success: false, data: error });
                };

            return deferred.promise;
        },
        updateList: function(model) {
            var deferred = $q.defer();
            $http.put('/api/lists/update', model)
                    .then(function(resp) {
                        deferred.resolve(resp);
                    }),
                function(error) {
                    deferred.reject({ success: false, data: error });
                };

            return deferred.promise;
        }

    };
}]);