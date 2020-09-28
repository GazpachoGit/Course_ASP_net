(function () {
    'use strict';
    angular.module('AppEvents')
        .controller('MyOrdersController', Controller);

    function Controller($http, TransferService, $stateParams) {

            var vm = this;
            vm.Name = "Egor";

    };
}());