$(document).ready(function () {

    $("#gridTabla").on('click', '.paginador', function () {
        var filtro = $("#filtro").val();
        var href = $(this).attr('href');
        $(this).attr('href', href + '&filtro=' + filtro);
        //return false;
    });

});