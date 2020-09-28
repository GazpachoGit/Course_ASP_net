
(function () {
    'use strict';
    angular.module('AppEvents', ['ui.router', 'ngCookies', 'ngResource', 'ngSanitize'])
        .config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
            //$urlRouterProvider.otherwise("/Events")

            $stateProvider
                .state('Events', {
                    url: "/Events",
                    controller: 'EventsController',
                    controllerAs: "vm",
                    templateUrl: '/views/EventsView.html',
                })
                .state('Tickets', {
                    url: '/Events/:eventId/Tickets',
                    controller: 'TicketsController',
                    controllerAs: 'vm',
                    templateUrl: '/views/TicketsView.html'
                })
                .state('Events.Select', {
                    url: '/Select',
                    templateUrl: '/views/EventsDetails.html',
                    controller: 'EventSelectController',
                    controllerAs: 'vm',
                    params: {
                        event: null
                    },
                })
                .state('MyTickets', {
                    url: '/MyTickets',
                    controller: 'MyTicketsController',
                    controllerAs: 'vm',
                    templateUrl: '/views/MyTicketsView.html',
                })
                .state('MyTickets.Selling', {
                    url: '/Selling',
                    controller: 'MyTicketsController',
                    controllerAs: 'vm',
                    templateUrl: '/views/MyTickets/SellingView.html',
                })
                .state('MyTickets.Waiting', {
                    url: '/Waiting',
                    controller: 'MyTicketsController',
                    controllerAs: 'vm',
                    templateUrl: '/views/MyTickets/WaitingView.html',
                })
                .state('MyTickets.Sold', {
                    url: '/Sold',
                    controller: 'MyTicketsController',
                    controllerAs: 'vm',
                    templateUrl: '/views/MyTickets/SoldView.html',
                })
                .state('MyOrders', {
                    url: '/MyOrders',
                    controller: 'MyOrdersController',
                    controllerAs: 'vm',
                    templateUrl: '/views/MyOrdersView.html',
                })
                .state('MyOrders.Confirmed', {
                    url: '/Confirmed',
                    controller: 'MyOrdersController',
                    controllerAs: 'vm',
                    templateUrl: '/views/MyOrders/ConfirmedView.html',
                })
                .state('MyOrders.Rejected', {
                    url: '/Rejected',
                    controller: 'MyOrdersController',
                    controllerAs: 'vm',
                    templateUrl: '/views/MyOrders/RejectedView.html',
                })
                .state('MyOrders.Waiting', {
                    url: '/Waiting',
                    controller: 'MyOrdersController',
                    controllerAs: 'vm',
                    templateUrl: '/views/MyOrders/WaitingView.html',
                })
        })
        .factory('TransferService', function () {
            return {
                eventName: 'Not init'
            };
        });
   
    }());
