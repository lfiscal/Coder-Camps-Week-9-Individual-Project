app.controller("LoginController", function ($scope, $window, LoginService, $location, $routeParams, $http) {
    $scope.login = function () {
        LoginService.processLogin($scope.user.UserName, $scope.user.Password).then(
            function () {
                $scope.token = $window.sessionStorage.getItem("token");
                $http({ method: "GET", url: "/api/ApiUser" }).success(function (data) {
                    $scope.Users = data

                    for (var i = 0; i < data.length; i++) {
                        if (data[i].Name == $scope.user.UserName) {
                            $location.path("/User/" + data[i].Id)
                        }
                    }
                })
            }, function (status) {
                $scope.token = status;
            })
    }
})