﻿const CSS = [
    'bootstrap/dist/css/bootstrap.min.css',
    'jquery-datetimepicker/build/jquery.datetimepicker.min.css'
];
const JS = [
    'jquery/dist/jquery.min.js',
    'bootstrap/dist/js/bootstrap.min.js',
    'jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.min.js',
    'datetimepicker/dist/DateTimePicker.min.js',    
    'jquery-validation/dist/jquery.validate.js',
    'jquery-validation-unobtrusive/jquery.validate.unobtrusive.js',
    'jquery-validation/dist/localization/messages_es_AR.min.js',
    'jquery-datetimepicker/build/jquery.datetimepicker.full.js'
];

module.exports = [...JS, ...CSS];