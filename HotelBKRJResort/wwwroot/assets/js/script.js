function obtenerDatosUsuario() {
    var identificacion = document.getElementById("identificacion").value;

    var parametros = {
        "identificacion": identificacion
    };
    $.ajax(
        {
            data: parametros,
            url: 'obtenerUsuario',
            type: 'post',
            beforeSend: function () {
            },
            success: function (response) {
                var usuario = JSON.parse(response);
                document.getElementById("nombre").value = usuario.nombre;
                document.getElementById("apellidos").value = usuario.apellidos;
                document.getElementById("email").value = usuario.email;
                document.getElementById("tarjeta").value = usuario.tarjeta;

            }
        }
    );

}

function eliminarOferta(id) {
    var mensaje;
    var opcion = confirm("Estás seguro que deseas eliminar esta oferta?\nNo podrás deshacer la acción correspondiente");
    if (opcion == true) {
        mensaje = "Has clickado OK";
        $('#'+id).submit();
        alert("Eliminado correctamente");
    }
}
function eliminarReservacion(id) {
    var mensaje;
    var opcion = confirm("Estás seguro que deseas eliminar esta reservación?\nNo podrás deshacer la acción correspondiente");
    if (opcion == true) {
        $('#' + id).submit();
        alert("Eliminado correctamente");
    }
}
function eliminarTemporada(id) {
    var mensaje;
    var opcion = confirm("Estás seguro que deseas eliminar esta temporada?\nNo podrás deshacer la acción correspondiente");
    if (opcion == true) {
        $('#'+id).submit();
        alert("Eliminado correctamente");
    }
}
function cambiarEstado(checkboxElem) {

    var idHabitacion = checkboxElem.id;
    var estado;

    if (checkboxElem.checked) {//Hay que activar la habitacion
        estado = 1;
    } else {//Hay que desactivar la habitacion
        estado = 0;
    }

    var parametros = {
        "idHabitacion": idHabitacion,
        "estado": estado
    };

    $.ajax(
        {
            data: parametros,
            url: 'actualizarEstado',
            type: 'post',
        }
    );


}


function activar(id, estado) {

    if (estado == 1) {
        checkBox = document.getElementById(id);
        checkBox.checked = true;
    }
}



