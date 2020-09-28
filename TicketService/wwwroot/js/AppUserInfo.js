(function () {
    'use strict';
    angular.module('AppUserInfo', ['ngRoute'])
        .config(function ($routeProvider) {
            $routeProvider
                .when('/', {
                    controller: 'UserInfoController',
                    controllerAs: "vm",
                    templateUrl: '/views/MyOrders/WaitingView.html',
                })
        })
        .controller('UserInfoController', function () {

            var vm = this;
            vm.Name = "Egor";

        });
}());