
    (function ()
    {
        'use strict';
        angular.module('AppEvents')
            .controller("EventsController", EventsController);

        function EventsController($http, TransferService, LanguageService) {

            var vm = this;
            vm.Events = [];
           
            $http.get('/api/Events')
                .then(function (response) {

                    //Ok
                    angular.copy(response.data, vm.Events);
                    
                }, function (error) {
                        //NotOk
                        vm.ErrorMessage = "Feiled to load data: " + error;
                });
            
            vm.sortParameter = 'Name';
            vm.reversed = false;
            vm.DoSort = function (param) {
                vm.sortParameter = param;
                vm.reversed = !vm.reversed;
            };
            vm.selectEvent = function (eventName) {
                TransferService.eventName = eventName;
            }
            vm.Selected = TransferService.eventName;
            

        }
    }());