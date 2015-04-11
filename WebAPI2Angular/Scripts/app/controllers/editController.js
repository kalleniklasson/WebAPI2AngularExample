angular.module('app')
    .controller('editController', editController);

editController.$inject = ['user'];

function editController(user) {
    var vm = this;

    vm.user = user;

    activate();

    function activate() {

    }
};