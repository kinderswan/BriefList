briefApp.factory('userListService', function ($http, $q) {
    return {
        getUserLists: function (userId) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/api/users/' + userId + '/lists'
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