
(function () {
    'use strict';
    angular.module('AppEvents')
        .controller("TicketsController", TicketsController);

    function TicketsController($http,  $stateParams, TransferService) {

        var vm = this;
        vm.Name = 'Egor';
        vm.eventId = $stateParams.eventId;
        vm.Tickets = [];
        vm.SelectedEvent = TransferService.eventName; 

        $http.get(`/api/Events/${vm.eventId}/Tickets`)
            .then(function (response) {

                //Ok
                angular.copy(response.data, vm.Tickets);
            }, function (error) {
                //NotOk
                vm.ErrorMessage = "Feiled to load data: " + error;
            });

        vm.sortParameter = 'sellerName';
        vm.reversed = false;
        vm.DoSort = function (param) {
            vm.sortParameter = param;
            vm.reversed = !vm.reversed;
            vm.ArrowDirection = vm.reversed ? 'down' : 'up';
        };
        vm.ShowArrow = function (param) {
            if (vm.sortParameter == param)
                return true;
            else
                return false;
        }
        
    }
}());
