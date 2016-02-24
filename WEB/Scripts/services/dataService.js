myApp.factory('StudentService', ['$http', function ($http) {

    var StudentService = {};

    StudentService.getStudents = function () {

        return $http.get("/showLists");
        
    };

    return StudentService;



}]);