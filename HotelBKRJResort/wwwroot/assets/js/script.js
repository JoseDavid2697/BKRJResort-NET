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