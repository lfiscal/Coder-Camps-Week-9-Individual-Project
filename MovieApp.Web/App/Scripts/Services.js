app.factory("SessionHandler", function ($window) {
    var setLoggedInToken = function (token) {
        $window.sessionStorage.setItem("token", token); //"token" = tokenkey, token = tokenvalue
    }
    var removeLoggedInToken = function () {
        $window.sessionStorage.removeItem("token");
    }
    return {
        setLoggedInToken: setLoggedInToken,
        removeLoggedInToken: removeLoggedInToken
    }
});

app.factory("LoginService", function ($q, $http, SessionHandler) {
    var processLogin = function (username, password) {
        var deferred = $q.defer();
        $http({
            method: "POST",
            data: "username=" + username + "&password=" + password + "&grant_type=password",
            headers: { "Content-Type": "application/x-www-form-urlencoded" },
            url: "/Token",
            isArray: false
        }).success(function (data) {
            SessionHandler.setLoggedInToken(data.access_token);
            deferred.resolve();
        }).error(function (data, status) {
            SessionHandler.removeLoggedInToken();
            deferred.reject(status);
        })
        return deferred.promise;
    }
    var processLogout = function () {
        var deferred = $q.defer();
        $http({
            method: "POST",
            url: "/api/Account/Logout"
        }).success(function (data) {
            SessionHandler.removeLoggedInToken();
            deferred.resolve();
        }).error(function (data, status) {
            deferred.reject(status);
        })
        return deferred.promise;
    }
    return {
        processLogin: processLogin,
        processLogout: processLogout
    }
})
app.factory("AuthInterceptor", function ($window) {
    return {
        request: function (config) {
            config.headers = config.headers || {};
            if ($window.sessionStorage.getItem("token") && config.url.indexOf("localhost") > -1) {
                config.headers.Authorization = 'Bearer ' + $window.sessionStorage.getItem("token");
            }
            return config;
        }
    }
})