$(document).ready(function () {
    $.getJSON("Usuario/ObtenerRoles", { id: $('#Id').val() },
        function (allData) {
            var mappedRoles = $.map(allData, function (item) {
                //inhabilito la opcion
                $("#rol option[value=" + item.Id + "]").attr('disabled', 'disabled');
                setearDropDownRolSelected();
                return new Rol(item);
            });
            //self.roles(mappedRoles);
            $('#rolesFinales').val(JSON.stringify(mappedRoles));
        }
    );

    if ($("#Modificando").val())
    {
        $("#userInput").attr('readonly', 'readonly');
        $("#passwordInput").rules('remove', 'required');
        $("#passwordConfirmInput").rules('remove', 'required');
        $("#passwordConfirmInput").removeAttr('data-rule-equalTo');
    }
    else
    {
        $("#passwordInput").rules('add', 'required');
    }
    
});

function setearDropDownRolSelected()
{
    var seleccionado = false;
    $.each($("#rol option"), function (index, value) {
        if (value.disabled) {
            value.selected = false;
        } else {
            if (!seleccionado) {
                value.selected = true;
                seleccionado = true;
            }
        }
    });
}


//# sourceURL=usuarioCrearModificar.js