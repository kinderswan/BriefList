myApp.factory('listService', function($http, $q) {
    return {
        getUserByName: function(name) {
            var deferred = $q.defer();
            $http({ method: 'GET', url: '/Users/GetUser', params: { 'name': name } })
                    .then(function(resp) {
                        deferred.resolve(resp);
                    }),
                function(error) {
                    deferred.reject({ success: false, data: error });
                };

            return deferred.promise;
        },

        getUserById: function(id) {
            var deferred = $q.defer();
            $http({ method: 'GET', url: '/api/users', params: { 'id': id } })
                    .then(function(resp) {
                        deferred.resolve(resp);
                    }),
                function(error) {
                    deferred.reject({ success: false, data: error });
                };

            return deferred.promise;
        },

        getlists: function() {
            var deferred = $q.defer();
            $http.get("/List/Showlists")
                    .then(function(resp) {
                        deferred.resolve(resp);
                    }),
                function(error) {
                    deferred.reject({ success: false, data: error });
                };

            return deferred.promise;
        }

    }
});