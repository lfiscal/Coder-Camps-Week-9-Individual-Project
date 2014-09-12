app.controller("homeController", function ($scope, $window, LoginService, $http, $routeParams) {
    $scope.MovieTrailer = "";

    $scope.searchMovie = function () {
        $http({ method: "GET", url: "http://www.omdbapi.com/?t=" + $scope.movieTitle, data: $scope.imdbMovie })
            .success(function (data) {
                $scope.imdbMovie = data;
                clicked = true;
                return $scope.imdbMovie;
            })
        $http({ method: "GET", url: "http://trailersapi.com/trailers.json?movie=" + $scope.movieTitle + "&limit=5&width=320", data: $scope.MovieTrailer })
            .success(function (data) {
                $scope.MovieTrailer = data[0].code;
                return $scope.MovieTrailer;
            })
    }
    $scope.hideDiv = function () {

        if (clicked == true) {
            return true;
        }
        else {
            return false;
        }
    }

    //$scope.addMovie = function () {
    //    $scope.Movie = {}
    //    $scope.Movie.Title = document.getElementById("Title").value
    //    $scope.Movie.Year = document.getElementById("Year").value
    //    $scope.Movie.Poster = document.getElementById("Poster").value
    //    $scope.Movie.Rated = document.getElementById("Rated").value
    //    $scope.Movie.Runtime = document.getElementById("Runtime").value
    //    $scope.Movie.Genre = document.getElementById("Genre").value
    //    $scope.Movie.Released = document.getElementById("Released").value
    //    $scope.Movie.Country = document.getElementById("Country").value
    //    $scope.Movie.Language = document.getElementById("Language").value
    //    $scope.Movie.imdbRating = document.getElementById("imdbRating").value
    //    $scope.Movie.Plot = document.getElementById("Plot").value
    //    $scope.Movie.Director = document.getElementById("Director").value
    //    $scope.Movie.Actors = document.getElementById("Actors").value
    //    $scope.Movie.Status = document.getElementById("Status").value

    //    $http({ method: "POST", url: "/api/ApiMovie", data: $scope.Movie })
    //    .success(function (data) {
    //        $scope.getMovies();
    //    })
    //}


    //$scope.getMovies = function () {
    //    $http({ method: "GET", url: "api/ApiMovie" })
    //    .success(function (data) {
    //        $scope.Movies = data;
    //    })
    //}


    //$scope.getUsers = function () {
    //    $http({ method: "GET", url: "api/ApiUser" })
    //    .success(function (data) {
    //        $scope.Users = data
    //    })
    //}
    //$scope.getMovies();
    //$scope.getUsers();
})