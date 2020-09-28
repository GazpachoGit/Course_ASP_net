(function () {
    'use strict';
    angular.module('AppEvents')       
        .service('LanguageService', function ($http, $resource) {
          
            var vm = this;
        
            vm.Language = '';                   
            vm.JsonFile = {};
         
            vm.getJsonFile = function (locale) {                
                $http.get(`Resources/${locale}.json`).then(function (response) {

                    angular.copy(response.data, vm.JsonFile);
                    JSON.parse(decodeURIComponent(JSON.stringify(vm.JsonFile)));
                    console.log(vm.JsonFile);
                });
            }
                
            this.DifineLanfuage = function (cookie) {

                    switch (cookie) {
                        case 'c=ru|uic=ru':
                            vm.Language = "Ru";
                            break;
                        case 'c=en-US|uic=en-US':
                           vm.Language = "En";
                            break;
                        default:
                           vm.Language = "Ru";
                    }
                    vm.getJsonFile(this.Language);
                    
                };
                this.Translate = function (tag) {
                    return vm.JsonFile[tag];
                }

          
        })
        .filter('translate', ['LanguageService', function (LanguageService) {
            return function (word) {
                return LanguageService.Translate(word);
            };
        }]);

}());


