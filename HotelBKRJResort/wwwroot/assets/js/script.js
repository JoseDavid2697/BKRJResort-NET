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



