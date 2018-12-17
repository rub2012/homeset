{
    var ko: KnockoutStatic;
    //import * as ko from "knockout";
    //import ko = require("knockout");
    //import { * } from 'knockout';
    //import * as $ from "jquery";
    //import * as util from "Musuario";

    class Rol {
        id: KnockoutObservable<number>
        nombre: KnockoutObservable<string>

        constructor(id: number, nombre: string) {
            this.id = ko.observable(id);
            this.nombre = ko.observable(nombre);
        }
    }

    class RolViewModel {
        roles: KnockoutObservableArray<Rol>
        constructor() {
            this.roles = ko.observableArray();
            $.getJSON("Usuario/ObtenerRolesUsuario", { userid: $("#Id").val() }, rolesJson => {
                var mapped = $.map(rolesJson, function (rol) {
                    return new Rol(Number(rol.id), String(rol.nombre));
                });
                this.roles(mapped);
            });
        }

        addRol(): void {
            if (!isNaN(Number($('#rol option:selected').val())) && ko.utils.arrayFirst(this.roles(),
                function (rol) {
                    return Number($('#rol option:selected').val()) == rol.id();
                }) == null) {
                this.roles.push(new Rol(Number($('#rol option:selected').val()), $('#rol option:selected').text()));
                //inhabilito la opcion
                $("#rol option:selected").attr('disabled', 'disabled');
                //util.setearDropDownRolSelected();
            }
            $('#rolesFinales').val(ko.toJSON(this.roles));

        }

        removeRol = (rol: Rol): void => {
            this.roles.remove(rol);
            $('#rolesFinales').val(ko.toJSON(this.roles));
        }

        //Mapear Roles del usuario al modelo
        //this.roles();

    }

    ko.applyBindings(new RolViewModel());
}
//# sourceURL=rol.js