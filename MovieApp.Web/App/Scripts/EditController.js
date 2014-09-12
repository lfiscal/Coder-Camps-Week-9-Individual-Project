app.controller("editController", function ($scope, $http, $routeParams, $location) {
    $scope.getUser = function () {
        $http({ method: "GET", url: "/api/ApiUser/" + $routeParams.id })
        .success(function (data) {
           $scope.UserMovieVM = data;
        })
    };
    $scope.saveChanges = function (eUser) {
        $http({ method: "PUT", url: "/api/ApiUser/" + $routeParams.id, data: eUser })
        .success(function () {
            $location.path("/User/" + $routeParams.id)
        })
    }


    $scope.getUser();

    $scope.deleteAccount = function (id) {
        $http({ method: "DELETE", url: "api/ApiUser/" + $routeParams.id, data: $scope.UserMovieVM })
        .success(function (data) {
            $location.path("/");
        })
    }
})