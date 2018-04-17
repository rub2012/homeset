///// <reference path="../lib/knockout/dist/knockout.js" />
import * as ko from "knockout";

class RolViewModel {
    language: KnockoutObservable<string>
    framework: KnockoutObservable<string>

    constructor(language: string, framework: string) {
        this.language = ko.observable(language);
        this.framework = ko.observable(framework);
    }
}

ko.applyBindings(new RolViewModel("TypeScript", "Knockout"));