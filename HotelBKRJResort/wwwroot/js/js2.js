//Send a request to the web service to get a new access code for the main shop
function requestAccessCode() {
    $.ajax(
        {
            data: null,
            url: '?controlador=Admin&accion=requestAccessCode',
            type: 'post',
            beforeSend: function () {
                $("#code").html("Requesting, \n\ wait a second...");
            },
            success: function (response) {
                $("#code").html(response);
            }
        }
    );
}//requestNewCode


