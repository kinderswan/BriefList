myApp.factory('registerService',['$http','$q', function ($http, $q) {
    return {
        postRegister: function (model) {
            var deferred = $q.defer();
            $http.post('/Account/_Register', model)
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