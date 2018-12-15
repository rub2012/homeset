{
    var ko;
    //import * as ko from "knockout";
    //import ko = require("knockout");
    //import { * } from 'knockout';
    //import * as $ from "jquery";
    //import * as util from "Musuario";
    class Rol {
        constructor(id, nombre) {
            this.id = ko.observable(id);
            this.nombre = ko.observable(nombre);
        }
    }
    class RolViewModel {
        constructor() {
            this.removeRol = (rol) => {
                this.roles.remove(rol);
                $('#rolesFinales').val(ko.toJSON(this.roles));
            };
            this.roles = ko.observableArray();
        }
        addRol() {
            if ($('#rol option:selected').text() > "") {
                this.roles.push(new Rol(Number($('#rol option:selected').val()), $('#rol option:selected').text()));
                //inhabilito la opcion
                $("#rol option:selected").attr('disabled', 'disabled');
                //util.setearDropDownRolSelected();
            }
            $('#rolesFinales').val(ko.toJSON(this.roles));
        }
    }
    ko.applyBindings(new RolViewModel());
}
//# sourceURL=rol.js
//# sourceMappingURL=rol.js.map