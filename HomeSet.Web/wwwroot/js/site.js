﻿$(document).ready(function () {
    CentrarPosicionElemento();
    //Para todas las tablas paginadas le sumo el filtro al post
    $("#gridTabla").on('click', '.paginador', function () {
        var filtro = $("#filtro").val();
        var href = $(this).attr('href');
        $(this).attr('href', href + '&filtro=' + filtro);
    });

    //Evento al cliquear botones que disparan el modal
    $("#modal-editar").on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Button that triggered the modal
        var href = button.data('href'); // Extract info from data-* attributes
        var titulo = button.data('titulo');
        $.get(href, cargarModalEditar);
        $('#modal-editar-title').html(titulo);

        //modal.find('.modal-body input').val(recipient)
    })

    //Evento al ocultar el modal
    $("#modal-editar").on('hide.bs.modal', function (event) {
        event.stopPropagation();
    })
    

    //Evento al cliquear en el boton Guardar para disparar el formularo ajax Post
    $('#modal-editar-guardar').on('click', function (event) {        
        var form = $("#modal-editar form");
        form.validate();
        if (form.valid()) {
            form.submit();
        }
        else
        {
            event.preventDefault();
        }
        
    });

    $("#modal-eliminar").on('show.bs.modal', function (event) {
        $('#modal-eliminar-cancelar').focus();
        var button = $(event.relatedTarget); // Button that triggered the modal
        var href = button.data('href');
        var titulo = button.data('titulo');
        $('#modal-eliminar-body').html('<h3>¿Confirma la eliminación?</h3>');
        $('#modal-eliminar-title').html(titulo);
        $('#modal-eliminar-confirmar').attr('data-href', href);
    })

    $('#modal-eliminar-confirmar').on('click', function () {
        var token = $(this).parent().find('input[name="__RequestVerificationToken"]').val()
        $.post($(this).attr('data-href'), { __RequestVerificationToken: token}, function (data) { /*Post to action*/
            if (data == 'true') {
                MostrarAlertaExitosa();
            } else {
                MostrarAlertaError(data);
            }
        }).fail(
            function (message) {
                alert(message.responseText);
        }).done(
            function () {
                var container = $('#gridTabla');
                $.get(container.data('gridUrl') + '?filtro=' + $("#filtro").val(), function (data) {
                    container.html(data);
                });
            });
        $('#modal-eliminar').modal('hide');
    });

    //Ocultar alertError
    $('#alertCloseButton').on('click', function () {
        $("#alertaError").hide();
    });
    
    $('.dropdown-menu a.dropdown-toggle').on('click mouseover', function (e) {
        e.preventDefault();
        if (!$(this).next().hasClass('show')) {
            $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
        }
        var $subMenu = $(this).next(".dropdown-menu");
        $subMenu.toggleClass('show');


        $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
            $('.dropdown-submenu .show').removeClass("show");
        });        
    });
});

function cargarModalEditar(data) {
    $('#modal-editar-body').html(data);
    //$("#modal-editar-guardar").attr("disabled", false);
    //$('#modal-editar-title').html($('#modal-editar-body form').data().dialogoTitulo);
    $('#modal-editar-body form').attr('data-ajax-success', 'repuestaAjaxSuccess');

}

function attachDatePickers() {
    $('input.date').each(function () {
        var $this = $(this);
        $this.datetimepicker({
            timepicker: false,
            format: 'd/m/Y H:m',
        });
    });
    $.datetimepicker.setLocale('es');
    //$('#datetimepicker1').datetimepicker();
        //{ format: 'yyyy-MM-ddThh:mm' }
    
    //});
}

function MostrarAlertaError(data) {

    if (data != null) {
        $("#alertaError span").html(data);
    } else {
        $("#alertaError span").html($("#alertaError").data().mensaje);
    }
    $("#alertaError").show();
    $("#alertaError").delay(500).addClass("in");
}

function MostrarAlertaExitosa(data) {
    if (data != null) {
        $("#alertaExitosa span").html(data);
    }
    $("#alertaExitosa").show();
    $("#alertaExitosa").delay(500).addClass("in").fadeOut(2500);
}

function MostrarAlertaInfo(data) {
    if (data != null) {
        $("#alertaInfo span").html(data);
    }
    $("#alertaInfo").show();
    $("#alertaInfo").delay(500).addClass("in").fadeOut(2500);
}

function repuestaAjaxSuccess(respuesta) {
    if (respuesta == window.ajaxEditSuccess) {
        if ($('#search-form').length == 0) {
            window.location.href = window.location.href;
        } else {
            $('#modal-editar').modal('hide');
            var container = $('#gridTabla');
            if (container.length > 0 && container.is("[data-grid-url]")) {
                $.get(container.data('gridUrl') + '?filtro=' + $("#filtro").val(), function (data) {
                    container.html(data);
                });
            } else {
                $('#search-form').submit();
            }
            MostrarAlertaExitosa();
        }
    } else {
        cargarModalEditar(respuesta);
    }
}

function CentrarPosicionElemento() {
    $('.centro-pantalla').css({
        position: 'fixed',
        left: ($(window).width() - $('.centro-pantalla').outerWidth()) / 2.25,
        top: ($(window).height() - $('.centro-pantalla').outerHeight()) / 3
    });
}