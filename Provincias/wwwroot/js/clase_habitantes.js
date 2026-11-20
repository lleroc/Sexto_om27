class Clase_Habitantes {

    eliminar(id) {
        $.post('/Habitante/Delete', { id: id }, async (respuesta) => {
            console.log(respuesta)
            if (respuesta == 200 ||  respuesta == "200") {
                await Swal.fire("Habitanntes", "Se elimno con exito", "success")
                this.todos();
            } else {
                Swal.fire("Habitanntes", "Ocurrio un error al eliminar", "error")
            }
        })
    }

    todos() {
        $.get('Habitante/todos', (listaHabitantes) => {
            var html = ""
            $.each(listaHabitantes, (index, habitante) => {

                console.log(habitante)
                console.log(habitante[0])
                console.log(habitante['Nombre'])


                html += ` <tr>
            <td>
                ${habitante.nombre}
            </td>
            <td>
                ${habitante.apellido}
            </td>
            <td>
                ${habitante.fecha_Nacimiento}
            </td>
            <td>
                ${habitante.email}
            </td>
            <td>
                ${habitante.fecha_Registro}
            </td>
            <td>
                ${habitante.edad}
            </td>
            <td>
                ${habitante.canton.nombre}
            </td>
            
            <td>
                <a class="btn btn-outline-dark"  asp-action="Edit" asp-route-id="${habitante.id}">Editar</a> |
                <a class="btn btn-outline-secondary" asp-action="Details" asp-route-id="${habitante.id}">Detalles</a> |
                <a onclick="eliminar(${habitante.id})" class="btn btn-outline-warning">Eliminar</a>
            </td>
        </tr>`
        
            })

            $("#tablahabitante").html(html);

        })
    }
}
