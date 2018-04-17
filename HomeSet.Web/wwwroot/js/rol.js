"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
///// <reference path="../lib/knockout/dist/knockout.js" />
var ko = require("knockout");
var RolViewModel = /** @class */ (function () {
    function RolViewModel(language, framework) {
        this.language = ko.observable(language);
        this.framework = ko.observable(framework);
    }
    return RolViewModel;
}());
ko.applyBindings(new RolViewModel("TypeScript", "Knockout"));
//# sourceMappingURL=rol.js.map