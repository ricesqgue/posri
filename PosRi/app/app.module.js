
angular.module('PosRiApplication',
        ['ui.router',
        'blockUI',
        'angularjs-dropdown-multiselect'])
    .config(function(blockUIConfig) {
        blockUIConfig.message = 'Cargando...';
        blockUIConfig.autoBlock = true;
    });



toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": true,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": true,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "2500",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};