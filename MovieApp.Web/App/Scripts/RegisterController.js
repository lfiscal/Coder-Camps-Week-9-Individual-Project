app.controller("RegisterController", function ($scope, $http, $location, $routeParams, LoginService, SessionHandler) {

    $scope.newUser = {}
    $scope.register = function () {
        $http({ method: "POST", url: "/api/ApiUser", data: $scope.newUser })
        .success(function () {
            $location.path("/");
        })
    }

})