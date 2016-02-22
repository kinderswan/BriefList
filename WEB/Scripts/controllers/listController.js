myApp.controller('listController',
    function listController($scope, dataService) {

        var promiseObj = dataService.getData();
        promiseObj.then(function (value) { $scope.lists = value; });

        $scope.voteUp = function (answer) {
            answer.rate++;
        };
        $scope.voteDown = function (answer) {
            answer.rate--;
        };
    }
)