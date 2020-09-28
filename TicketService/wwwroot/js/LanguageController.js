(function () {
    'use strict';
    angular.module('AppEvents')
        .controller("LanguageController", Controller);

    function Controller($http, LanguageService, $cookies) {
        var vm = this;
        vm.Name = 'Eegor';
      
        vm.obj = $cookies.get('.AspNetCore.Culture');
      
        LanguageService.DifineLanfuage(vm.obj);
        vm.locale = LanguageService.Language;
        
    }
}());