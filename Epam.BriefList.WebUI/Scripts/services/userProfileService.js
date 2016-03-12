﻿angular.module('myApp').factory('userProfileService', function ($http, $q) {
    return {
        getUserProfile: function(userId) {

            var deferred = $q.defer();
            $http.get('/api/users/' + userId)
                    .then(function(resp) {
                        deferred.resolve(resp);
                    }),
                function(error) {
                    deferred.reject({ success: false, data: error });
                };

            return deferred.promise;
        },

        update: function(path, model) {

            var deferred = $q.defer();
            $http.put(path, model)
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