(function () {
    'use strict';
    angular.module('AppEvents')
        .controller("EventSelectController", EventsController);

    function EventsController($http, TransferService, $stateParams) {

        var vm = this;
        vm.event = $stateParams.event;
        vm.selectEvent = function (eventName) {
            TransferService.eventName = eventName;
        }

        vm.GoBack = function () {
            $state.go('^');
        }
        vm.Name = "egor";

        
    }

}());