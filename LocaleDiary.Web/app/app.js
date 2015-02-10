(function() {
    'use strict';
    var app = angular.module('LocaleDiaryApp', ['ngRoute']);

    app.config(function($routeProvider) {
        $routeProvider.when("/home", {
            controller: "homeController",
            templateUrl: "/app/home/home.html"
        });

        $routeProvider.when("/locales", {
            controller: "localesController",
            templateUrl: "/app/locales/locales.html"
        });

        $routeProvider.otherwise({ redirectTo: "/home" });
    });

})();