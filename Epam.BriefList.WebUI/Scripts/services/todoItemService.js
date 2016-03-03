﻿briefApp.factory('todoItemService', function ($http, $q) {
    return {
        getTodoItems: function (id) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/api/lists/' + id + '/todoitems'
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