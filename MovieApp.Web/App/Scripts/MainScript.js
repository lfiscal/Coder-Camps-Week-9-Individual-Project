var app = angular.module("MovieApp", ['ngRoute', 'ngSanitize']);
var clicked = false;

app.config(function ($httpProvider, $routeProvider, $sceProvider) {
    $httpProvider.interceptors.push("AuthInterceptor")
    $sceProvider.enabled(false);
    $routeProvider.when("/", {
        templateUrl: "/App/Views/Index.html",
        controller: "homeController"
    }).when("/User/:id", {
        templateUrl: "/App/Views/User.html",
        controller: "UserController"
    }).when("/EditUserDeets/:id", {
        templateUrl: "/App/Views/EditUserDeets.html",
        controller: "editController"
    }).when("/MovieDeets/:id", {
        templateUrl: "/App/Views/MovieDeets.html",
        controller:"MovieDeetsController"
    })
})
