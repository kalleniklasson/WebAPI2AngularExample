angular.module('app')
    .controller('usersController', usersController);

usersController.$inject = ['users'];

function usersController(users) {
    var vm = this;

    vm.users = users.data;

    activate();

    function activate() {
       
    }
};