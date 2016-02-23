myApp.factory('dataService', function ($http, $q) {
    return {
        getData: function () {
            var deferred = $q.defer();
            $http({ method: 'GET', url: '/List/_ShowLists' }).
             success(function (data, status, headers, config) {
                 deferred.resolve(data.lists);
             }).
            error(function (data, status, headers, config) {
                deferred.reject(status);
            });

            return deferred.promise;
        }
    }
})