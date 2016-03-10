angular.module('myApp').factory('userListService', ['$http', '$q', function ($http, $q) {
    return {
        getUserLists: function(userId) {
            var deferred = $q.defer();
            $http({
                    method: 'GET',
                    url: '/api/users/' + userId + '/lists'
                }).then(function(resp) {
                    deferred.resolve(resp);
                }),
                function(error) {
                    deferred.reject({ success: false, data: error });
                };

            return deferred.promise;
        },


    addList: function (model) {
        var deferred = $q.defer();
        $http.post('/api/Lists', model)
                .then(function (resp) {
                    deferred.resolve(resp);
                }),
            function (error) {
                deferred.reject({ success: false, data: error });
            };

        return deferred.promise;
    },

        deleteList: function (id) {
        var deferred = $q.defer();
        $http.delete('/api/deletelists/' + id)
        .then(function (resp) {
            deferred.resolve(resp);
        }),
        function (error) {
            deferred.reject({ success: false, data: error });
        };

        return deferred.promise;
    }

    }
}]);