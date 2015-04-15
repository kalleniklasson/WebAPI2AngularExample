(function() {
    'use strict';

    angular.module('app')
        .config(appConfig)
        .run(appRun);

    appConfig.$inject = ['$stateProvider', '$urlRouterProvider'];

    function appConfig($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/home');

        $stateProvider
            .state('home', {
                url: '/home',
                data: {},
                templateUrl: '/Scripts/app/views/home.html',
                controller: 'homeController',
                controllerAs: 'vm'
            })
            .state('home.users', {
                url: '/users',
                templateUrl: '/Scripts/app/views/home.users.html',
                resolve: {
                    users: usersResService
                },
                controller: 'usersController',
                controllerAs: 'vm'
            })
            .state('user', {
                parent: 'home.users',
                url: '/{id:[0-9]{1,4}}',
                'abstract': true,
                templateUrl: '/Scripts/app/views/user.html',
                resolve: { user: userResService },
                controller: 'userController',
                controllerAs: 'vm'
            })
            .state('user.info', {
                url: '',
                templateUrl: '/Scripts/app/views/user.info.html',
                controller: 'userController',
                controllerAs: 'vm'
            })
            .state('user.edit', {
                url: '',
                templateUrl: '/Scripts/app/views/user.edit.html',
                controller: 'editController',
                controllerAs: 'vm'
            });
    };

    usersResService.$inject = ['$http'];

    function usersResService($http) {
        return $http.get('/Api/Persons').
            success(function(data, status, headers, config) {
                return data;
            }).
            error(function(data, status, headers, config) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
    }

    userResService.$inject = ['$stateParams', 'users'];

    function userResService($stateParams, users) {
        //Since we resolved users in our parent state we can inject in anywher in the child states
        for (var i = 0, ii = users.data.length; i < ii; i++) {
            if (users.data[i].id == $stateParams.id)
                return users.data[i];
        }
    }

    appRun.$inject = ['$rootScope', '$state', '$stateParams'];

    function appRun($rootScope, $state, $stateParams) {
        $rootScope.$on('$stateChangeStart', function(event, toState, toStateParams) {
            $rootScope.toState = toState;
            $rootScope.toStateParams = toStateParams;
        });
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;
    };
})();