/// <reference path="usuarioCrearModificar.d.ts"/>
import * as ko from "knockout";
import * as $ from "jquery";
import * as util from "Musuario";
//import { Utils, setearDropDownRolSelected } from "Musuario";

//declare function setearDropDownRolSelected(): any;
//import * as usuariojs from "usuarioCrear.js";

class Rol
{
    id: KnockoutObservable<number>
    nombre: KnockoutObservable<string>

    constructor(id: number, nombre: string) {
        this.id = ko.observable(id);
        this.nombre = ko.observable(nombre);
    }
}

class RolViewModel
{
    roles: KnockoutObservable<Rol[]>

    constructor()
    {
        this.roles = ko.observableArray()
    }

    addRol()
    {
        if ($('#rol option:selected').text() > "") {
            this.roles.push(new Rol(Number($('#rol option:selected').val()), $('#rol option:selected').text()));
            //inhabilito la opcion
            $("#rol option:selected").attr('disabled', 'disabled');
            util.setearDropDownRolSelected();
        }
        $('#rolesFinales').val(ko.toJSON(this.roles));

    }

}

ko.applyBindings(new RolViewModel());