app.controller("MovieDeetsController", function ($scope, $http, $location, $routeParams, LoginService, SessionHandler) {

    $scope.getMovie = function (id) {
        $http({ method: "GET", url: "api/ApiMovie/" + $routeParams.id })
        .success(function (data) {
            $scope.Movie = data;
        })
    }
$scope.getMovie($routeParams.id);
})