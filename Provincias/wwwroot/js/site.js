// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


     $(document).ready(function() {
    $("#provincia").change(function() {
        var provinciaId = $(this).val();
        
        $("#CantonId")
            .empty()
            .append('<option value="">-- Seleccione un canton --</option>')
            .prop('disabled', false);

        if (provinciaId == "") {
            alert("Seleccione una provincia");
            return;
        }

        $.get('~/Controllers/Habitante', { provinciaId: provinciaId }, function(lista_cantones) {
            $.each(lista_cantones, function(i, canton) {
                $("#CantonId").append(
                    $('<option>', { value: canton.id, html: canton.nombre })
                );
            });
        });
    });
});