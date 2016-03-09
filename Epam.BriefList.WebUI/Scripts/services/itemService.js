angular.module('myApp').factory('itemService', function ($http, $q) {
    return {
        getTodoItems: function (id) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/api/lists/' + id + '/todoitems/'+false
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
        }



    }
});

