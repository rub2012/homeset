require.config({
    paths: {
        "knockout": "../lib/knockout-latest.debug",
        "jquery": "../lib/jquery",
        "jquery.unobtrusive-ajax": "../lib/jquery.unobtrusive-ajax",
        "jquery.validate": "../lib/jquery.validate",
        "jquery.validate.unobtrusive": "../lib/jquery.validate.unobtrusive",
        "messages_es_AR.min": "../lib/messages_es_AR.min",
        "bootstrap": "../lib/bootstrap",
        "popper": "../lib/popper",
        "bootstrap.bundle.min": "../lib/bootstrap.bundle.min"
    },
    shim: {
        'jquery.validate': ['jquery'],
        'jquery.unobtrusive-ajax': ['jquery'],
        'jquery.validate.unobtrusive': ['jquery', 'jquery.validate'],
        'messages_es_AR.min': ['jquery', 'jquery.validate'],
        'bootstrap': ['jquery', 'popper'],
        'bootstrap.bundle.min': ['jquery'],
        'knockout': ['jquery']
    }
});
//# sourceMappingURL=require-config.js.map