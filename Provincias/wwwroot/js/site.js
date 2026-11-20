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

        $.get('/Habitante/GetCantones', { provinciaId: provinciaId }, function(lista_cantones) {
            $.each(lista_cantones, function(i, canton) {
                $("#CantonId").append(
                    $('<option>', { value: canton.id, html: canton.nombre })
                );
            });
        });
    });


         $("#Fecha_Nacimiento").on("change input",function () {
             const fechaNacimiento = $(this).val();
             if (!fechaNacimiento) {
                 $("#Edad").val("");
                 return;
             }

             const [anio, mes, dia] = fechaNacimiento.split("-").map(Number);
             const hoy = new Date();
             let edad = hoy.getFullYear() - anio;
             if (hoy.getMonth() + 1 < mes || (hoy.getMonth() + 1 === mes && hoy.getDate() < dia)) {
                 edad--;
             }
             $("#Edad").val(edad);
         })

         $("#Fecha_Nacimiento").trigger("change");


         
     });

var eliminar = (id) => { 
    var habitante = new Clase_Habitantes();
    Swal.fire({
        title: "Esta seguro de eliminar el registro???",
        text: "Esta a punto de eliminar un habitante!!!!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#d33",
        cancelButtonColor: "#3085d6",
        confirmButtonText: "Eliminar!"
    }).then((result) => {
        if (result.isConfirmed) {
            habitante.eliminar(id);
        }
    });
}

var todos = () => {
    var habitante = new Clase_Habitantes();
    habitante.todos()
}