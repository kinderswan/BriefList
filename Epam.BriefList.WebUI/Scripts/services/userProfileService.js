angular.module('myApp').factory('userProfileService', function ($http, $q) {
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
            $http.put(path, model).
             success(function(data, status) {
                deferred.resolve(status);
            }).
            error(function(data, status) {
                deferred.reject(status);
            });

            return deferred.promise;
        },

        uploadFile: function (file,id) {
            var formData = new FormData();

            formData.append("file",file);
        var deferred = $q.defer();
        $http.post('/api/users/updatePhoto/'+id, formData, {
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest:angular.identity
            }).
         success(function(data, status) {
             deferred.resolve(status);
         }).
        error(function(data, status) {
            deferred.reject(status);
        });

        return deferred.promise;
    },

        getImage: function(userId) {

            $http.get('/api/users/getImage/' + userId)
                .success(function(data) {
                    return data.data;
                });
        }
    }
});