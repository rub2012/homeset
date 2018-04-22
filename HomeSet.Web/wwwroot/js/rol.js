"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/// <reference path="usuarioCrearModificar.d.ts"/>
var ko = require("knockout");
var $ = require("jquery");
var util = require("Musuario");
//import { Utils, setearDropDownRolSelected } from "Musuario";
//declare function setearDropDownRolSelected(): any;
//import * as usuariojs from "usuarioCrear.js";
var Rol = /** @class */ (function () {
    function Rol(id, nombre) {
        this.id = ko.observable(id);
        this.nombre = ko.observable(nombre);
    }
    return Rol;
}());
var RolViewModel = /** @class */ (function () {
    function RolViewModel() {
        this.roles = ko.observableArray();
    }
    RolViewModel.prototype.addRol = function () {
        if ($('#rol option:selected').text() > "") {
            this.roles.push(new Rol(Number($('#rol option:selected').val()), $('#rol option:selected').text()));
            //inhabilito la opcion
            $("#rol option:selected").attr('disabled', 'disabled');
            util.setearDropDownRolSelected();
        }
        $('#rolesFinales').val(ko.toJSON(this.roles));
    };
    return RolViewModel;
}());
ko.applyBindings(new RolViewModel());
//# sourceMappingURL=rol.js.map