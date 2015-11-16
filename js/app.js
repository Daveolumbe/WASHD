angular.module('mapInput', [])
    .controller('mapController', ['$scope', function ($scope) {
        $scope.example = {
            text: 'guest',
            word: /^\s*\w*\s*$/
        };
    }]);