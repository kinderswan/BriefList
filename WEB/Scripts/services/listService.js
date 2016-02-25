myApp.factory('listService', function ($http, $q) {
    return {
        getData: function () {
            var deferred = $q.defer();
            $http.get("/List/Showlists")
                .then(function(resp) {
                    deferred.resolve( resp );
                }),
            function(error) {
                deferred.reject({ success: false, data: error});
            };

            return deferred.promise;
        }
    }
})