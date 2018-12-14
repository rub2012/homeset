const CSS = [
    'bootstrap/dist/css/bootstrap.min.css',
    'jquery-datetimepicker/build/jquery.datetimepicker.min.css'
];
const JS = [
    'jquery/dist/jquery.min.js',
    'jquery/dist/jquery.js',
    'bootstrap/dist/js/bootstrap.min.js',
    'bootstrap/dist/js/bootstrap.js',
    'bootstrap/dist/js/bootstrap.bundle.min.js',    
    'jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.min.js', 
    'jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.js', 
    'jquery-validation/dist/jquery.validate.min.js',
    'jquery-validation/dist/jquery.validate.js',
    'jquery-validation-unobtrusive/jquery.validate.unobtrusive.js',
    'jquery-validation/dist/localization/messages_es_AR.min.js',
    'jquery-datetimepicker/build/jquery.datetimepicker.full.js',
    'knockout/build/output/knockout-latest.js',
    'knockout/build/output/knockout-latest.debug.js',
    'requirejs/require.js',
    'popper.js/dist/umd/popper.min.js',
    'popper.js/dist/umd/popper.js'
];

module.exports = [...JS, ...CSS];