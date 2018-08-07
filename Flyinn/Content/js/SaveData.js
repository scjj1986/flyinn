function InsertarCertificado() {
    // alert($("#last").html());
 
    swal({
        title: "¿Esta Seguro Que Desea Insertar Estos Registros?",
        text: "¿Toda la Información esta Correcta?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#1393C1",
        confirmButtonText: "Si, Insertar!",
        cancelButtonText: "No, Cerrar!",
        closeOnConfirm: false,
        closeOnCancel: false
    }, function (isConfirm) {
        if (isConfirm) {
            $.ajax({
                type: 'POST',
                //Llamado al metodo GetidEstados en el controlador
                url: 'InsertarCertificado',
                dataType: 'json',
                //Parametros que se envian al metodo del controlador
                data: { tablacertificados: $("#last").html() },
                //En caso de resultado exitoso
                success: function (verifi) {
                    if (verifi == false) {
                        alert("No se Ingreso Certificado");
                    }
                    else {
                        swal({
                            title: "¡Completado!",
                            text: "Certificado ingresado correctamente",
                            type: "success",
                            showCancelButton: false,
                            confirmButtonColor: "#66CDAA",
                            confirmButtonText: "Aceptar",
                            closeOnConfirm: true
                        }, function () {
                            toggle('blanket');
                            toggle('popUpDiv');
                            location.reload();
                        });

                    }
                    //Recargar el plugin para que tenga la funcionalidad del componente$("#idMunicipio").select({ placeholder: "Selecciona un Municipio", width: "20%" });
                },
                //Mensaje de error en caso de fallo
                error: function (ex) {
                    alert('Failed to retrieve states.' + ex);
                }
            });

            /*
            toggle('blanket');
            toggle('popUpDiv');
            location.reload();*/
        }
        else {
            swal("Cancelado", "Continue en el Menu", "error");
        }
    });
    return true;
}


function modificarCertificado() {

    var codCertificado = $("#codCertificado").val();
    var codCertificado2 = $("#codCertificado2").val();
    var fechaCertificado = $("#fechaCertificado").val();
    var nbCliente = $("#nbCliente").val();
    var cedulaCliente = $("#cedulaCliente").val();
    var nbAcompanante = $("#nbAcompañante").val();
    var cedulaAc = $("#cedulaAc").val();
    var Sucursal = $("#Sucursal").val();
    var Promotores = $("#Promotores").val();
    var Supervisores = $("#Supervisores").val();
    var Gerentes = $("#Gerentes").val();
    var Noches = $("#Noches").val();
    var Adultos = $("#Adultos").val();
    var Ninos = $("#Niños").val();
    var Liner = $("#Liner").val();
    var Closer = $("#Closer").val();
    var montoCertificado = $("#MontoCertificado").val();
    var Observaciones = $("#Observaciones").val();

    var fechaReserva = $("#fechaReserva").val();

    var fechaViajeCliente = $("#fechaViajeCliente").val();

    var mjs = "";
    var ok = true;


    if (codCertificado == "") {
        mjs += "Codigo Certificado, "
        ok = false;
    }
    if (nbCliente == "") {
        mjs += "Nombre(s), "
        ok = false;
    }
    if (cedulaCliente == "") {
        mjs += "Cedula Cliente, "
        ok = false;
    }
    if (nbAcompañante == "") {
        //mjs += "Nombre del Acompañante, "
        //ok = false;
        nbAcompañante = "N/A"
    }
    if (cedulaAc == "") {
        //mjs += "Cedula del Acompañante, "
        //ok = false;
        cedulaAc = 0
    }
    if (fechaCertificado == "") {
        mjs += "Fecha del Certificado, "
        ok = false;
    }
    if (Sucursal == "<...>" || Sucursal == "") {
        mjs += "Hotel, "
        ok = false;
    }
    if (Promotores == "<...>" || Promotores == "") {
        mjs += "Promotor, "
        ok = false;
    }
    if (Supervisores == "<...>" || Supervisores == "") {
        mjs += "Supervisor, "
        ok = false;
    }
    if (Gerentes == "<...>" || Gerentes == "") {
        mjs += "Gerente, "
        ok = false;
    }
    //if (Liner == "<...>" || Liner == "") {
    //    mjs += "Liner, "
    //    ok = false;
    //}
    //if (Closer == "<...>" || Closer == "") {
    //    mjs += "Closer, "
    //    ok = false;
    //}
    if (Noches == "") {
        mjs += "Noches, "
        ok = false;
    }
    if (Ninos == "") {
        mjs += "Niños, "
        ok = false;
    }
    if (Adultos == "") {
        mjs += "Adultos, "
        ok = false;
    }
    if (montoCertificado == "") {
        mjs += "Monto del Certificado"
        ok = false;
    }


    if (ok == false) {
        document.getElementById('oculto').style.display = 'block';
        document.getElementById('error').innerHTML = mjs;
    }
    else if (ok == true) {

        swal({
            title: "¿Esta Seguro Que Desea Modificar Este Certificado?",
            text: "¿Toda la Información esta correcta?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#1393C1",
            confirmButtonText: "Si, Modificar!",
            cancelButtonText: "No, Cerrar!",
            closeOnConfirm: false,
            closeOnCancel: false
        }, function (isConfirm) {
            if (isConfirm == true) {
                $.ajax({
                    type: 'POST',
                    //Llamado al metodo GetidEstados en el controlador
                    url: 'ModificarCertificado',
                    dataType: 'JSON',
                    //Parametros que se envian al metodo del controlador
                    data: {

                        codCertificado: codCertificado, codCertificado2: codCertificado2, nbCliente: nbCliente, cedulaCliente: cedulaCliente, nbAcompanante: nbAcompanante, cedulaAc: cedulaAc, Sucursal: Sucursal, Promotores: Promotores, Supervisores: Supervisores, Gerentes: Gerentes, Liner: Liner, Closer: Closer, fechaCertificado: fechaCertificado, Noches: Noches, Ninos: Ninos, Adultos: Adultos, montoCertificado: montoCertificado, Observaciones: Observaciones, fechaReserva: fechaReserva, fechaViajeCliente: fechaViajeCliente
                    },

                    //En caso de resultado exitoso
                    success: function (verifi) {
                        if (verifi == false) {
                            alert("No se Modifico Certificado");
                        }
                        else {

                            swal({
                                title: "¡Completado!",
                                text: "Certificado modificado correctamente",
                                type: "success",
                                showCancelButton: false,
                                confirmButtonColor: "#66CDAA",
                                confirmButtonText: "Aceptar",
                                closeOnConfirm: true
                            }, function () {
                                toggle('blanket');
                                toggle('popUpDiv');
                                location.reload();
                            });

                        }
                        //Recargar el plugin para que tenga la funcionalidad del componente$("#idMunicipio").select({ placeholder: "Selecciona un Municipio", width: "20%" });
                    },
                    //Mensaje de error en caso de fallo
                    error: function (ex) {
                        alert('Se ha Presentado un error por favor llamar al Departamento de Sistemas. Error:' + ex);
                    }
                }).toString();
              
            }
            else {
                swal("Cancelado", "Continue en el Menu", "error");
            }
        });
        return true;
    }
}