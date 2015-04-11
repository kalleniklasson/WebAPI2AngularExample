angular.module('app')
    .controller('userController', userController);

userController.$inject = ['user'];

function userController(user) {
    var vm = this;

    vm.user = user;

    activate();

    function activate() {

    }
};