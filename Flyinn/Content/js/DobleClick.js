function UploadCertificado(a) {

    popup('popUpDiv');
    var sucursal;
    var promotores;
    //  alert($("#sup" + a + "").val());
    $("#codCertificado").val($("#cod" + a + "").val());
    $("#codCertificado2").val($("#cod" + a + "").val());
    $("#fechaCertificado").val($("#fecha" + a + "").val());
    $("#nbCliente").val($("#nbC" + a + "").val());
    $("#cedulaCliente").val($("#cedulaC" + a + "").val());
    $("#nbAcompañante").val($("#nbA" + a + "").val());
    $("#cedulaAc").val($("#cAc" + a + "").val());
    $("select#Sucursal").val($("#suc" + a + "").val());
    $("select#Promotores").val($("#pN" + a + "").val());
    $("select#Supervisores").val($("#sup" + a + "").val());
    $("select#Gerentes").val($("#gN" + a + "").val());
    $("#Liner").val($("#Liner" + a + "").val());
    $("#Closer").val($("#Closer" + a + "").val());
    $("#Noches").val($("#noches" + a + "").val());
    $("#Adultos").val($("#adultos" + a + "").val());
    $("#Niños").val($("#niños" + a + "").val());
    $("#MontoCertificado").val($("#montoC" + a + "").val());
    $("#Observaciones").val($("#obser" + a + "").val());

    

    if ($("#fres" + a + "").val() != "") {

        var dt = $("#fres" + a + "").val().split("/").reverse().join("-");
        dt = dt.replace(" ", "");
        console.log(dt);
        $("#fechaReserva").val(dt);
    }

    if ($("#fvcli" + a + "").val() != "") {

        var dt2 = $("#fvcli" + a + "").val().split("/").reverse().join("-");
        dt2 = dt2.replace(" ", "");
        $("#fechaViajeCliente").val(dt2);
    }

    


    //console.log("epa");
    //alert($("#fechaReserva").val());
    $("#MontoPagar").val($("#montoP" + a + "").val());
    var dia = $("#dia" + a + "").val();
    var mes = $("#mes" + a + "").val();
    var año = $("#año" + a + "").val();
    setInputDate1("#fechaCertificado");
    //setInputDate1("#fechaReserva");
    //setInputDate1("#fechaViajeCliente");


    function setInputDate1(_id) {
        console.log($(_id).val());
        var _dat = document.querySelector(_id);
        var d = dia, m = mes, y = año, data;
        if (d < 10) {
            d = "0" + d;
        };
        if (m < 10) {
            m = "0" + m;
        };
        data = y + "-" + m + "-" + d;
        console.log(data);
        _dat.value = data;

    };

    document.getElementById('tabla').style.display = 'none'
    document.getElementById('boton1').style.display = 'none'
    document.getElementById('botones').style.display = 'none'
    document.getElementById('boton').style.display = 'block'

}
function mostrarControles() {
    document.getElementById('tabla').style.display = 'block'
    document.getElementById('boton1').style.display = 'block'
    document.getElementById('botones').style.display = 'block'
    document.getElementById('boton').style.display = 'none'
}
function calculoMontoPagar() {

    var idSucursal = $("#Sucursal").val()
    var Noches = $("#Noches").val()
    var Adultos = $("#Adultos").val()
    var Niños = $("#Niños").val()
    var MontoPagar = 0;

    if (idSucursal == 1 || idSucursal == 3) {
        MontoPagar = ((Noches * Adultos * 5) + (Noches * Niños * 2.5))
    } else {
        MontoPagar = (Noches * 10)
    }
    $("#MontoPagar").val(MontoPagar);
}

function UploadUsuarios(a) {

    //  alert($("#sup" + a + "").val());
    $("#nbUsuario").val($("#usuario" + a + "").val());
    $("#contraseña").val($("#contraseña" + a + "").val());
    $("#repContraseña").val($("#contraseña" + a + "").val());
    $("#Cedula").val($("#cedula" + a + "").val());
    $("#nombreUser").val($("#nombre" + a + "").val());
    $("#apeUser").val($("#apellido" + a + "").val());
    $("select#Perfil").val($("#perfil" + a + "").val());
    $("#correo").val($("#correo" + a + "").val());
    $("#Codigo").val($("#Cod" + a + "").val());

    var check = $("#act" + a + "").val();
    if (check == 1) {
        // $("#activo").attr('checked', 'checked');
        document.getElementById('activo').checked = true;
        document.getElementById('activo').value = 1;
    }
    else {
        document.getElementById('activo').checked = false;
        document.getElementById('activo').value = 0;
    }




    document.getElementById('botonGuardar').style.display = 'none'
    document.getElementById('botonModificar').style.display = 'block'

}
function checkbox(check) {
    if (check.checked) {
        $("#activo").val(1);
    } else {
        $("#activo").val(0);
    }
}
function UploadEmpleados(a) {

    var CodigoEmpleado = $("#CodigoEmpleado").val();
    var Cedula = $("#Cedula").val();
    var Nombres = $("#Nombres").val();
    var correo = $("#Email").val();
    var CodigoCargo = $("#CodigoCargo").val();
    var CodigoPrograma = $("#CodigoPrograma").val();
    var activo = $("#activo").val();
    //  alert($("#sup" + a + "").val());
    $("#CodigoEmpleado").val($("#codigo" + a + "").val());
    $("#Cedula").val($("#cedula" + a + "").val());
    $("#Nombres").val($("#nombre" + a + "").val());
    $("select#CodigoCargo").val($("#codCargo" + a + "").val());
    $("select#CodigoPrograma").val($("#codPrograma" + a + "").val());
    $("#Email").val($("#correo" + a + "").val());
    $("#ID").val($("#ID" + a + "").val());

    var check = $("#act" + a + "").val();
    if (check == 1) {
        // $("#activo").attr('checked', 'checked');
        document.getElementById('activo').checked = true;
        document.getElementById('activo').value = 1;
    }
    else {
        document.getElementById('activo').checked = false;
        document.getElementById('activo').value = 0;
    }




    document.getElementById('botonGuardar').style.display = 'none'
    document.getElementById('botonModificar').style.display = 'block'

}
function mdfEmpleado(i) {
    // popup("popUpDiv");
    // $("#btnAsociar").click();
    //$("#btnAsociar").click(function () {
    //    $("#asociarCertificados").dialog('open');
    //    return false;
    //});

    //$('table tdoby tr td').on('click', function () {
    //    $("#asociarCertificados").modal('show');
    //});
    $('#fReservaCert').text("");
    $('#fViajeClienteCert').text("");
    $("#codcert").html($("#CDC" + i + "").val());
    $("#idcert").val($("#CC" + i + "").val());

    //console.log($("#codcert").html());
    document.getElementById('NroContrato').innerHTML = $('#NC' + i + "").val();
    document.getElementById('Cliente').innerHTML = $('#NB' + i + "").val();
    document.getElementById('fechaVenta').innerHTML = $('#FV' + i + "").val();
    document.getElementById('fechaProcesable').innerHTML = $('#FP' + i + "").val();
    document.getElementById('MontoContrato').innerHTML = $('#MC' + i + "").val();

    //console.log($("#idcert").html());
    console.log($("#CC" + i + "").val());

    //console.log($("#CDC" + i + "").val());

    if ($('#CC' + i + "").val() != "") {
        if ($("#IP" + i + "").val() != 0) {
            console.log("Promotor");
            console.log($("#IP" + i + "").val());
            $('select#Promotores').val($("#IP" + i + "").val());
        } else {
            $('select#Promotores').val(-1);
        }
        //alert($("#IP" + i + "").val());
        $('select#EstatusP').val($("#EP" + i + "").val());
        //alert($("#EP" + i + "").val());
        if ($("#IG" + i + "").val() != 0) {
            $('select#Gerentes').val($("#IG" + i + "").val());
        } else {
            $('select#Gerentes').val(-1);
        }
        //alert($("#IG" + i + "").val());
        $('select#EstatusG').val($("#EG" + i + "").val());
        //alert($("#EG" + i + "").val());
        if ($("#IS" + i + "").val() != 0) {
            $('select#Supervisores').val($("#IS" + i + "").val());
        } else {
            $('select#Supervisores').val(-1);
        }
        //alert($("#IS" + i + "").val());
        $('select#EstatusS').val($("#ES" + i + "").val());
        //alert($("#ES" + i + "").val());
        if ($("#IC" + i + "").val() != 0) {
            $('select#Coordinadores').val($("#IC" + i + "").val());
        } else {
            $('select#Coordinadores').val(-1);
        }
        $('select#EstatusC').val($("#EC" + i + "").val());
        //alert($("#CC" + i + "").val());
        console.log($("#CC" + i + "").val());
        if ($("#CC" + i + "").val() != 0) {
            $('select#codCertificado').val($("#CC" + i + "").val());
            //getfReserva($("#CDC" + i + "").val());

            $.ajax({
                type: 'POST',
                //Llamado al metodo GetidEstados en el controlador
                url: 'fReservaCert',
                dataType: 'json',
                //Parametros que se envian al metodo del controlador
                data: { CodigoCertificado: $("#CDC" + i + "").val() },
                //En caso de resultado exitoso
                success: function (Certificado) {
                    if (Certificado == "") {
                        $('#fReservaCert').text("");
                    }
                    else {
                        $('#fReservaCert').text(Certificado);
                    }
                },
                //Mensaje de error en caso de fallo
                error: function (ex) {
                    alert('Ocurrio un error inesperado llame al departamento de Sistemas.' + ex);
                }
            });
            
            $.ajax({
                type: 'POST',
                //Llamado al metodo GetidEstados en el controlador
                url: 'fViajeCliCert',
                dataType: 'json',
                //Parametros que se envian al metodo del controlador
                data: { CodigoCertificado: $("#CDC" + i + "").val() },
                //En caso de resultado exitoso
                success: function (Certificado) {
                    if (Certificado == "") {
                        $('#fViajeClienteCert').text("");
                    }
                    else {
                        $('#fViajeClienteCert').text(Certificado);
                    }
                },
                //Mensaje de error en caso de fallo
                error: function (ex) {
                    alert('Ocurrio un error inesperado llame al departamento de Sistemas.' + ex);
                }
            });






            //getfViajeCli();

        } else {
            $('select#codCertificado').val(-1);
        }
        document.getElementById("modificar_contrato").style.display = "inline";
        document.getElementById("guardar_contrato").style.display = "none";
    } else {
        document.getElementById("modificar_contrato").style.display = "none";
        document.getElementById("guardar_contrato").style.display = "inline";
    }
    $.ajax({
        type: 'POST',
        //Llamado al metodo GetidEstados en el controlador
        url: 'reloadcmbCert',
        dataType: 'json',
        //Parametros que se envian al metodo del controlador
        data: {},
        //En caso de resultado exitoso
        success: function (Certi) {
            $('#blkslc').val("SI");
            $('select#codCertificado').children().remove();
            $.each(Certi, function (i, item) {
                $('select#codCertificado').append($('<option>', {
                    value: item.Value,
                    text: item.Text
                }));
            });
            $('#blkslc').val("NO");
            //$('select#codCertificado').val($("#CDC" + i + "").val());


            //console.log(Certi[0].Text);


        },
        //Mensaje de error en caso de fallo
        error: function (ex) {
            console.log(ex);
        }
    });
}




function UploadContratos(i) {
    popup("popUpDiv");
    document.getElementById('NroContrato').innerHTML = $('#NC' + i + "").val();
    // document.getElementById('').innerHTML = $('#NB' + i + "").val();
    document.getElementById('fechaVenta').innerHTML = $('#FV' + i + "").val();
    document.getElementById('fechaProcesable').innerHTML = $('#FP' + i + "").val();
    document.getElementById('MontoContrato').innerHTML = $('#MC' + i + "").val();


    //------------ Juan ------------------//
    var comisionP = $('#CP' + i + "").val();
    var comisionL = $('#CL' + i + "").val();
    var comisionC = $('#CC' + i + "").val();
    comisionP = comisionP.replace(',', '.');
    comisionL = comisionL.replace(',', '.');
    comisionC = comisionC.replace(',', '.');
    comisionP = parseFloat(comisionP).toFixed(2);
    comisionL = parseFloat(comisionL).toFixed(2);
    comisionC = parseFloat(comisionC).toFixed(2);
    //-------------------------------------//


    /*
    comisionP = parseFloat($('#CP' + i + "").val()).toFixed(2);
    comisionL = parseFloat($('#CL' + i + "").val()).toFixed(2);
    comisionC = parseFloat($('#CC' + i + "").val()).toFixed(2);*/

    


    $("#comisionPromotor").val(comisionP);
    $("#idPromotor").val($('#idPromotor' + i + "").val())
    $("#Promotor").val($('#Promotor' + i + "").val())
    $("#comisionLiner").val(comisionL)
    $("#idLiner").val($('#idLiner' + i + "").val())
    $("#Liner").val($('#Liner' + i + "").val())
    $("#comisionCloser").val(comisionC)
    $("#idCloser").val($('#idCloser' + i + "").val())
    $("#Closer").val($('#Closer' + i + "").val())
    //if ($('#CC' + i + "").val() != "") {
    //if ($("#Promotor" + i + "").val() != 0) {
    //    $('select#Promotores').val($("#Promotor" + i + "").val());
    //} else {
    //    $('select#Promotores').val(-1);
    //}
    ////alert($("#IP" + i + "").val());
    ////  $('select#EstatusP').val($("#EP" + i + "").val());
    ////alert($("#EP" + i + "").val());
    //if ($("#Liner" + i + "").val() != 0) {
    //    $('select#Liner').val($("#Liner" + i + "").val());
    //} else {
    //    $('select#Liner').val(-1);
    //}
    ////alert($("#IG" + i + "").val());
    ////   $('select#EstatusG').val($("#EG" + i + "").val());
    ////alert($("#EG" + i + "").val());
    //if ($("#Closer" + i + "").val() != 0) {
    //    $('select#Closer').val($("#Closer" + i + "").val());
    //} else {
    //    $('select#Closer').val(-1);
    //}
    //alert($("#IS" + i + "").val());
    //$('select#EstatusS').val($("#ES" + i + "").val());
    //alert($("#ES" + i + "").val());

    document.getElementById("modificar_contrato").style.display = "inline";
    document.getElementById("guardar_contrato").style.display = "none";
    //} else {
    //    document.getElementById("modificar_contrato").style.display = "none";
    //    document.getElementById("guardar_contrato").style.display = "inline";
    //}



}

function limpiar() {
    $("select#Perfil").val(-1);
    $("select#CodigoCargo").val(-1);
    $("select#CodigoPrograma").val(-1);
    $("#Email").val('');
    $("#ID").val('');
    $("#CodigoEmpleado").val('');
    $("#Nombres").val('');
    $("#nbUsuario").val('');
    $("#contraseña").val('');
    $("#repContraseña").val('');
    $("#Cedula").val('');
    $("#nombreUser").val('');
    $("#apeUser").val('');
    $("#correo").val('');
    $("#Codigo").val('');
    document.getElementById('activo').checked = false;
    $("#activo").val(0);
}
function LimpiarCertificado() {
    $("#codCertificado").val('');
    $("#codCertificado2").val('');
    $("#fechaCertificado").val('');
    $("#nbCliente").val('');
    $("#cedulaCliente").val('');
    $("#nbAcompañante").val('');
    $("#cedulaAc").val('');
    $("select#Sucursal").val(1);
    $("select#Promotores").val(-1);
    $("select#Supervisores").val(-1);
    $("select#Gerentes").val(-1);
    $("select#Liner").val(-1);
    $("select#Closer").val(-1);
    $("#Noches").val(3);
    $("#Adultos").val(0);
    $("#Niños").val(0);
    $("#Liner").val("");
    $("#Closer").val("");
    $("#MontoCertificado").val(0);
    $("#Observaciones").val('');
    $("#fechaReserva").val("");
    $("#fechaViajeCliente").val("");
    $("#MontoPagar").val(0);
    $("#MontoCertificado").val(0.00);
}
function ShowControlesUsuarios() {
    document.getElementById('botonGuardar').style.display = 'block'
    document.getElementById('botonModificar').style.display = 'none'
}


