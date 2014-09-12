app.controller("UserController", function ($scope, $http, $location, $routeParams, LoginService, SessionHandler) {
    
    $scope.getUser = function () {
        $http({ method: "GET", url: "api/ApiUser/" + $routeParams.id })
        .success(function (data) {
            $scope.UserMovieVM = data
            $scope.UserDeets = data.User;
        })
    };

    $scope.getMovies = function () {
        $http({ method: "GET", url: "api/ApiUser/" + $routeParams.id })
            .success(function (data) {
                $scope.allMovies = data.Movies;
                
            })
    }
    $scope.addUserMovie = function () {
        $scope.UserMovieVM.Movie = {}
        $scope.UserMovieVM.Movie.Title = document.getElementById("Title").value
        $scope.UserMovieVM.Movie.Year = document.getElementById("Year").value
        $scope.UserMovieVM.Movie.Poster = document.getElementById("Poster").value
        $scope.UserMovieVM.Movie.Rated = document.getElementById("Rated").value
        $scope.UserMovieVM.Movie.Runtime = document.getElementById("Runtime").value
        $scope.UserMovieVM.Movie.Genre = document.getElementById("Genre").value
        $scope.UserMovieVM.Movie.Released = document.getElementById("Released").value
        $scope.UserMovieVM.Movie.Country = document.getElementById("Country").value
        $scope.UserMovieVM.Movie.Language = document.getElementById("Language").value
        $scope.UserMovieVM.Movie.imdbRating = document.getElementById("imdbRating").value
        $scope.UserMovieVM.Movie.Plot = document.getElementById("Plot").value
        $scope.UserMovieVM.Movie.Director = document.getElementById("Director").value
        $scope.UserMovieVM.Movie.Actors = document.getElementById("Actors").value
        $scope.UserMovieVM.Movie.Status = document.getElementById("Status").value

        $http({ method: "POST", url: "api/ApiMovie/", data: $scope.UserMovieVM })
        .success(function () {
            $scope.getMovies();
        })
    };

    $scope.deleteMovie = function (id) {
        $http({ method: "DELETE", url: "api/ApiMovie/" + id, data: $scope.Movie })
        .success(function (data) {
            $scope.getMovies();
        })
    }
    $scope.hovered = function () {
        console.log("hovered!");
        $scope.getMovies();
    }
    $scope.getUser();
    $scope.getMovies();
})