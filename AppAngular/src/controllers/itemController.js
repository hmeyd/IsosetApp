'use strict';

var items = [
    { 'id': 1, 'name': 'films' },
    { 'id': 2, 'name': 'series' }
]
var app = angular.module("AppAngular", []);

app
    .controller('itemsIndex', function ($scope) {

    })
    .controller('itemsListe', function ($scope) {

    })
    .controller('itemsCreat', function ($scope) {
        $scope.test = 'toto';
    })
    .controller('itemsRemove', function ($scope) {

    });