﻿angular.module('myApp').factory('loginService', ['$http', '$q', function ($http, $q) {
    return {
        postLogin: function (model) {
            var deferred = $q.defer();
            $http.post('/Account/Login', model)
                    .then(function(resp) {
                        deferred.resolve(resp);
                    },
                function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        signOut: function() {
            $http.post('/Account/Logoff')
                .then(function() {
                    window.location.href = '../Home/Start';
                });
        }

    }
}]);
