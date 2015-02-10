(function() {
    'use strict';
    angular.module('LocaleDiaryApp')
        .controller('localesController', [
            '$scope', 'localesService', function($scope, localesService) {

                $scope.locales = [];

                localesService.getLocales().then(function(results) {
                    $scope.locales = results.data;
                }, function(error) {
                    // error
                });
            }
        ]);

})();