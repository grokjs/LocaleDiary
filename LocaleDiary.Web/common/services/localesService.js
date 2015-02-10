(function() {
    'use strict';
    angular.module('LocaleDiaryApp')
        .factory('localesService', [
            '$http', function($http) {
                var serviceBase = 'http://localhost:45955/';
                var localesServiceFactory = {};

                var _getLocales = function() {
                    return $http.get(serviceBase + 'api/locales')
                        .then(function(results) {
                            return results;
                        });
                };

                localesServiceFactory.getLocales = _getLocales;

                return localesServiceFactory;
            }
        ]);

})();