/// <reference path="usuarioCrearModificar.d.ts"/>

//import * as ko from "knockout";
import ko = require("knockout");
//import * as $ from "jquery";
//import * as util from "Musuario";

export class Rol
{
    id: KnockoutObservable<number>
    nombre: KnockoutObservable<string>

    constructor(id: number, nombre: string) {
        this.id = ko.observable(id);
        this.nombre = ko.observable(nombre);
    }
}

export class RolViewModel
{
    roles: KnockoutObservableArray<Rol>
    constructor()
    {
        this.roles = ko.observableArray()
    }

    addRol() : void
    {
        if ($('#rol option:selected').text() > "") {
            this.roles.push(new Rol(Number($('#rol option:selected').val()), $('#rol option:selected').text()));
            //inhabilito la opcion
            $("#rol option:selected").attr('disabled', 'disabled');
            //util.setearDropDownRolSelected();
        }
        $('#rolesFinales').val(ko.toJSON(this.roles));

    }

    removeRol = (rol: Rol) : void =>
    {
        this.roles.remove(rol);
        $('#rolesFinales').val(ko.toJSON(this.roles));
    }

}

ko.applyBindings(new RolViewModel());

//# sourceURL=rol.js