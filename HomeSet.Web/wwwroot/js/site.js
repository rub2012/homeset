$(document).ready(function () {

    //Para todas las tablas paginadas le sumo el filtro al post
    $("#gridTabla").on('click', '.paginador', function () {
        var filtro = $("#filtro").val();
        var href = $(this).attr('href');
        $(this).attr('href', href + '&filtro=' + filtro);
        //return false;
    });

    //Evento al cliquear botones que disparan el modal
    $("#modal-editar").on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget) // Button that triggered the modal
        var href = button.data('href') // Extract info from data-* attributes
        var titulo = button.data('titulo')
        $.get(href, cargarModalEditar);
        $('#modal-editar-title').html(titulo);
        // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
        // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
        //var modal = $(this)
        //modal.find('.modal-title').text('New message to ' + recipient)
        //modal.find('.modal-body input').val(recipient)
    })

    //Evento al cliquear en el boton Guardar para disparar el formularo ajax Post
    $('#modal-editar-guardar').on('click', function () {
        var form = $("#modal-editar form");
        form.submit();
        //$('#modal-editar form').submit();
        //if ($('#modal-editar form').valid())
        //    $("#modal-editar-guardar").attr("disabled", true);
    });

});

function cargarModalEditar(data) {
    $('#modal-editar-body').html(data);
    //$("#modal-editar-guardar").attr("disabled", false);
    //$('#modal-editar-title').html($('#modal-editar-body form').data().dialogoTitulo);
    //$('#modal-editar-body form').attr('data-ajax-success', 'editarRepuestaFormulario');

}

function attachDatePickers() {
    $('input.date').each(function () {
            var $this = $(this);
        $this.datetimepicker({
            timepicker: false,
            format: 'd/m/Y H:m',
            lang: 'es'
        });
    });
    //$('#datetimepicker1').datetimepicker();
        //{ format: 'yyyy-MM-ddThh:mm' }
    
    //});
}