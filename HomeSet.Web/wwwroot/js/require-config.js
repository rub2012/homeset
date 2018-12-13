require.config({
    paths: {
        "knockout": "../lib/knockout-latest",
        "jquery": "../lib/jquery.min",
        "jquery.unobtrusive-ajax.min": "../lib/jquery.unobtrusive-ajax.min",
        "jquery.validate.min": "../lib/jquery.validate.min",
        "jquery.validate.unobtrusive": "../lib/jquery.validate.unobtrusive",
        "messages_es_AR.min": "../lib/messages_es_AR.min",
        "bootstrap.min": "../lib/bootstrap.min",
        "popper.min": "../lib/popper.min",
        "bootstrap": "https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/js/bootstrap.bundle.min"
    },
    shim: {
        'jquery': {
            exports: '$'
        },
        'jquery.validate.min': ['jquery'],
        'jquery.unobtrusive-ajax.min': ['jquery'],
        'jquery.validate.unobtrusive': ['jquery', 'jquery.validate.min'],
        'messages_es_AR.min': ['jquery', 'jquery.validate.min'],
        'bootstrap.min': ['jquery', 'popper.min'],
        'bootstrap': ['jquery'],
        'knockout': ['jquery']
    }
});
//# sourceMappingURL=require-config.js.map