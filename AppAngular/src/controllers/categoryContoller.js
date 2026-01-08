'use strict';

var categories = [
    { 'name': 'Dango', 'category_id': 1},
    { 'name': 'Forrest Gump', 'category_id': 1 }
]
var app = angular.module("AppAngular", []);

app
    .controller('categoryIndex', function ($scope) {

    })
    .controller('categoryListe', function ($scope) {

    })
    .controller('categoryCreat', function ($scope) {
        $scope.test = 'toto';
    })
    .controller('categoryRemove', function ($scope) {

    });
