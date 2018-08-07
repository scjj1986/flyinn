function AddCertificado() {

    var codCertificado = $("#codCertificado").val()
    var fechaCertificado = $("#fechaCertificado").val()
    var nbCliente = $("#nbCliente").val()
    var cedulaCliente = $("#cedulaCliente").val()
    var nbAcompañante = $("#nbAcompañante").val()
    var cedulaAc = $("#cedulaAc").val()
    var Sucursal = $("#Sucursal").find('option:selected').text()
    var idSucursal = $("#Sucursal").val()
    var Promotores = $("#Promotores").find('option:selected').text()
    var idPromotores = $("#Promotores").val()
    var Supervisores = $("#Supervisores").find('option:selected').text()
    var idSupervisores = $("#Supervisores").val()
    var Gerentes = $("#Gerentes").find('option:selected').text()
    var idGerentes = $("#Gerentes").val()
    
    var Liner = $("#Liner").val()
  
    var Closer = $("#Closer").val()
    var Noches = $("#Noches").val()
    var Adultos = $("#Adultos").val()
    var Niños = $("#Niños").val()
    var montoCertificado = $("#MontoCertificado").val()
    var Observaciones = $("#Observaciones").val()

    var fechaReserva = $("#fechaReserva").val()

    var fechaViajeCliente = $("#fechaViajeCliente").val()


    var MontoPagar = 0;
    if (idSucursal == 1 || idSucursal == 3) {
        MontoPagar = ((Noches * Adultos * 5)+(Noches * Niños * 2.5))
    }else{
        MontoPagar = (Noches * 10)
    }
    if (Observaciones=="") {
        Observaciones="SIN OBSERVACIÓN"
    }
    var mjs = "";
    var ok = true;

    if (codCertificado == "") {
        mjs += "Certificado, "
        ok = false;
    }
    if (fechaCertificado == "") {
        mjs += "Fecha Certificado, "
        ok = false;

    }
    if (nbCliente == "") {
        mjs += "nbCliente, "
        ok = false;
    }
    if (cedulaCliente == "") {
        mjs += "Cedula del Cliente, "
        ok = false;
    }
    if (nbAcompañante == "") {
        //mjs += "Nombre del Acompañante, "
        //ok = false;
        nbAcompañante="N/A"
    }
    if (cedulaAc == "") {
        //mjs += "Cedula del Acompañante, "
        //ok = false;
        cedulaAc=0
    }
    if (montoCertificado == "") {
        mjs += "Monto del Certificado, "
        ok = false;
    }
    //if (Observaciones == "") {
    //    mjs += "Monto del Certificado, "
    //    ok = false;
    //}
    if (Sucursal == "") {
        mjs += "Sucursal, "
        ok = false;
    }
    if (Promotores == "") {
        mjs += "Promotores, "
        ok = false;
    }
    if (Supervisores == "") {
        mjs += "Supervisores, "
        ok = false;
    }
    if (Gerentes == "") {
        mjs += "Gerentes, "
        ok = false;
    }
    if (Noches == "") {
        mjs += "Noches, "
        ok = false;
    }
    if (Adultos == "") {
        mjs += "Adultos, "
        ok = false;
    }
    if (Niños == "") {
        mjs += "Niños, "
        ok = false;
    }
    if (Closer=="") {
        Closer = "NO";
    }
    if (Liner=="") {
        Liner = "NO";
    }

    //if (MontoPagar == "") {
    //    mjs += "Monto Pagar "
    //    ok = false;
    //}

    if (ok == false) {
        document.getElementById('oculto').style.display = 'block';
        document.getElementById('error').innerHTML = mjs;
    }
    else if (ok == true) {

        $.ajax({
            type: 'POST',
            //Llamado al metodo GetDepartByGeren en el controlador
            url: 'VerificarCertificado',
            dataType: 'json',
            //Parametros que se envian al metodo del controlador
            data: { codCertificado: $("#codCertificado").val(), certificados: $("#certificados").val() },
            //En caso de resultado exitoso
            success: function (verifi) {
                if (verifi == 0) {
                    var texto2;
                    var i = ($("#tabla_cetificado >tbody >tr").length + 1);
                    var e = "cer" + i;                  

                    var texto1 = "<tr id=" + e + "><td>" + codCertificado + "</td><td>" + formatDate(fechaCertificado) + "</td><td>"
                    + nbCliente + "</td><td>" + cedulaCliente + "</td><td>" + nbAcompañante + "</td><td>" + cedulaAc + "</td><td>"
                    + Sucursal + "</td><td hidden>" + idPromotores + "</td><td>"
                    + Promotores + "</td><td hidden>" + idSupervisores + "</td><td>" + Supervisores + "</td><td hidden>"
                    + idGerentes + "</td><td>" + Gerentes + "</td><td>" + Liner + "</td><td>" + Closer + "</td><td>" + Noches + "</td><td>" + Adultos + "</td><td>" + Niños + "</td><td>" + montoCertificado + "</td><td>"
                    + MontoPagar + "</td><td>" + Observaciones + "</td><td>" + formatDate(fechaReserva) + "</td><td>" + formatDate(fechaViajeCliente) + "</td><td>" + "<button class='btn btn-danger btn-xs' type='button' id='btnmenos' value='-' onclick='menos(" + e + ")'><i class='glyphicon glyphicon-remove'></i></button>" + "</td></tr>";

                    $("#tabla_cetificado > tbody").append(texto1);
                    texto2 = $("#certificados").val() + " " + codCertificado
                    $("#certificados").attr("value", texto2);
                    i = i + 1;

                    $("#codCertificado").val("");
                    $("#fechaCertificado").val("");
                    $("#nbCliente").val("");
                    $("#cedulaCliente").val("");
                    $("#nbAcompañante").val("");
                    $("#cedulaAc").val("");
                    $("#Observaciones").val("");
                    $("#montoCertificado").val("");
                    $("#Sucursal").replaceWith($("#Sucursal").clone(true));
                    $("#Promotores").replaceWith($("#Promotores").clone(true));
                    $("#Supervisores").replaceWith($("#Supervisores").clone(true));
                    $("#Gerentes").replaceWith($("#Gerentes").clone(true));
                    $("#Liner").val("");
                    $("#Closer").val("");
                    $("#Adultos").val("");
                    $("#Niños").val("");
                    $("#MontoCertificado").val(0);
                    $("#fechaReserva").val("");
                    $("#fechaViajeCliente").val("");

                }
                else if (verifi == 1) {
                    document.getElementById('oculto').style.display = 'block';
                    document.getElementById('error').innerHTML = "El Certificado: " + $("#codCertificado").val(); + " - Ya se encuentra registrado";
                }
                else if (verifi == 2) {
                    document.getElementById('oculto').style.display = 'block';
                    document.getElementById('error').innerHTML = "El Certificado: " + $("#codCertificado").val(); + " - Ya se encuentra en la lista para ingresar";
                }
                //Recargar el plugin para que tenga la funcionalidad del componente$("#idMunicipio").select({ placeholder: "Selecciona un Municipio", width: "20%" });
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });

    }
};

function formatDate(input) {
    if (input !=""){
        var datePart = input.match(/\d+/g),
        year = datePart[0],
        month = datePart[1], day = datePart[2];

        return day + '/' + month + '/' + year;
    }
    return "";
}

function menos(id) {
    id.remove();
}

$(function(){
    var list = [];

   

})


