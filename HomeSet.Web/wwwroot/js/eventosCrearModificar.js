$(document).ready(function () {
    attachDatePickers();
    $("#subcategoria-dropdown").attr('disabled','disabled');
    $("#categoria-dropdown").on("change", function () {
        $("#subcategoria-dropdown").removeAttr('disabled');        
        $("#subcategoria-dropdown").empty();
        $("#subcategoria-dropdown").append('<option disabled selected>Elegir...</option>');
        var categoriaId = $("option:selected", this).val()
        $.getJSON($("#getSubcategorias").val(), { categoriaId: categoriaId},function (data) {
            $.each(data, function (i, item) {
                $('<option/>', {
                    'value': item.id,
                    'text': item.descripcion
                }).appendTo($("#subcategoria-dropdown"));
            });
        });
    });
});

//# sourceURL=eventosCrearModificar.js