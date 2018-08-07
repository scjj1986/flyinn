var correo;
//VALIDACION PARA QUE SOLO ACEPTE NUMEROS EN LOS TEXT
function AcceptNumbers(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = "1234567890";
    especiales = [8];

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}//VALIDACION PARA QUE SOLO ACEPTE LETAS EN LOS TEXT
function AcceptLetters(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
    especiales = [8];

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}
function decimal(e, thix) {
    var keynum = window.event ? window.event.keyCode : e.which;
    if (document.getElementById(thix.id).value.indexOf('.') != -1 && keynum == 46)
        return false;
    if ((keynum == 8 || keynum == 48 || keynum == 46))
        return true;
    if (keynum <= 47 || keynum >= 58) return false;
    return /\d/.test(String.fromCharCode(keynum));
}


/*
function Filtrar(a) {
    var ruta;
    var boton = $("#btnFiltrar").val();
    var fechaInicio = $("#fechaInicio").val();
    var fechaFin = $("#fechaFin").val();
    var codOfiIsla = $('#codOfiIsla').prop("checked") ? $("#codOfiIsla").val() : -1;
    var codOfiCosta = $('#codOfiCosta').prop("checked") ? $("#codOfiCosta").val() : -1;
    var codOfiPlaya = $('#codOfiPlaya').prop("checked") ? $("#codOfiPlaya").val() : -1;
    var codOfiCoche = $('#codOfiCoche').prop("checked") ? $("#codOfiCoche").val() : -1;
    var codOfiSala = $('#codOfiSala').prop("checked") ? $("#codOfiSala").val() : -1;
    var codOfiSala5 = $('#codOfiSala5').prop("checked") ? $("#codOfiSala5").val() : -1;
    var PPF = $('#PPF').prop("checked") ? "@**@" : "PPF";
    var PVB = $('#PVB').prop("checked") ? "@**@" : "PVB";
    var CodigoPrograma = $("#CodigoPrograma").val();
    var mjs = "";
    var ok = true;
    if (a == "contratos") {
        ruta = "Filtrar";
    }
    else {
        ruta = "FiltrarContratos"
    }
    if (fechaInicio == "") {
        mjs += " Fecha Inicio "
        ok = false;
    }
    if (fechaFin == "") {
        mjs += " Fecha Fin "
        ok = false;
    }

    if (ok == false) {
        swal("Verificar Campos!", "Campos: " + mjs + " - Se encuentran vacios!!!", "error")
        //alert();
    }
    else if (ok == true) {
        //alert(fechaInicio); alert(fechaFin); alert(codOfiIsla); alert(codOfiCosta); alert(codOfiPlaya); alert(codOfiCoche); alert(codOfiSala);
        $.ajax({
            type: 'POST',
            //Llamado al metodo GetDepartByGeren en el controlador
            url: ruta,
            dataType: 'html',
            //Parametros que se envian al metodo del controlador
            data: { fechaInicio: fechaInicio, fechaFin: fechaFin, codOfiIsla: codOfiIsla, codOfiCosta: codOfiCosta, codOfiPlaya: codOfiPlaya, codOfiCoche: codOfiCoche, codOfiSala: codOfiSala, codOfiSala5: codOfiSala5, PPF: PPF, PVB: PVB, CodigoPrograma: CodigoPrograma },
            //En caso de resultado exitoso
            success: function (verifi) {

                $("#example1").empty();
                $("#example1").html(verifi);
                if (a == "contratos1") {
                    $("#btnPDF3").attr("href", "/Flyinn/Report/PDFReporteContratosProcesables?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "&codOfiIsla=" + codOfiIsla + "&codOfiCosta=" + codOfiCosta + "&codOfiPLaya=" + codOfiPlaya +
                 "&codOfiCoche=" + codOfiCoche + "&codOfiSala=" + codOfiSala + "&codOfiSala5=" + codOfiSala5 + "&PPF=" + PPF + "&PVB=" + PVB + "&CodigoPrograma=" + CodigoPrograma + "");
                }

                //$('#example').dataTable({
                //    "bPaginate": true,
                //    "bLengthChange": true,                    
                //    "bFilter": true,
                //    "pageLength": 100,
                //    "bSort": true,
                //    "bInfo": true,
                //    "bAutoWidth": true,
                //    "asStripClasses": null
                //});             

                //$("#btnPDF").attr("href", "/Report/PDF?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");           
                //$("#btnExcel").attr("href", "/Report/Excel?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
    }
}

*/

function checkDecimals(fieldName, fieldValue) {

    decallowed = 2; // how many decimals are allowed?

    if (isNaN(fieldValue) || fieldValue == "") {
       // alert("El número no es válido. Prueba de nuevo.");
        fieldName.select();
        fieldName.focus();
    }
    else {
        if (fieldValue.indexOf('.') == -1) fieldValue += ".";
        dectext = fieldValue.substring(fieldValue.indexOf('.')+1, fieldValue.length);

        if (dectext.length > decallowed)
        {
           // alert ("Por favor, entra un número con " + decallowed + " números decimales.");
            fieldName.select();
            fieldName.focus();
        }
        else {
           // alert ("Número validado satisfactoriamente.");
        }
    }
}

function NumCheck(e, field) {
    key = e.keyCode ? e.keyCode : e.which
    // backspace
    if (key == 8) return true
    // 0-9
    if (key > 47 && key < 58) {
        if (field.value == "") return true
        regexp = /.[0-9]{2}$/
        return !(regexp.test(field.value))
    }
    // .
    if (key == 46) {
        if (field.value == "") return false
        regexp = /^[0-9]+$/
        return regexp.test(field.value)
    }
    // other key
    return false
 
}

function guardar() {

    //alert($("#NroContrato").text()); alert($("#codCertificado").val()); alert($("#MontoContrato").text());
    //alert($("#Promotores").val()); alert($("#EstatusP").val()); alert($("#Supervisores").val()); alert($("#EstatusS").val());
    //alert($("#Coordinadores").val()); alert($("#EstatusC").val()); alert($("#Gerentes").val()); alert($("#EstatusG").val());
    var a = $('select[name=example_length]').val();   
    swal({
        title: "¿Esta Seguro Que Desea Modificar Este Registro?",
        text: "¿Toda la Información esta correcta?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#1393C1",
        confirmButtonText: "Si, Modificar!",
        cancelButtonText: "No, Cerrar!",
        closeOnConfirm: false,
        closeOnCancel: false
    }, function (isConfirm) {
        if (isConfirm) {
            $.ajax({
                type: 'POST',
                //Llamado al metodo GetidEstados en el controlador
                url: 'InsertarComisionContrato',
                dataType: 'json',
                //Parametros que se envian al metodo del controlador
                data: {
                    NroContrato: $("#NroContrato").text(), codCertificado: $("#codCertificado").find('option:selected').text(), MontoContrato: $("#MontoContrato").text(),
                    Promotores: $("#Promotores").val(), EstatusP: $("#EstatusP").val(), Supervisores: $("#Supervisores").val(), EstatusS: $("#EstatusS").val(),
                    Coordinadores: $("#Coordinadores").val(), EstatusC: $("#EstatusC").val(), Gerentes: $("#Gerentes").val(), EstatusG: $("#EstatusG").val()
                },
                //En caso de resultado exitoso
                success: function (verifi) {
                    if (verifi == false) {
                        alert("No se Modifico Empleado");
                    }
                    else {
                        swal("Finalizado!", "Contrato modificado satisfactoriamente.", "success");
                        $('#asociarCertificados').modal('hide');
                        toggle('asociarCertificados');
                        Filtrar('contratos');
                        //$("#asociarCertificados").attr("aria-hidden", "true");
                        

                    }                    
                    //Recargar el plugin para que tenga la funcionalidad del componente$("#idMunicipio").select({ placeholder: "Selecciona un Municipio", width: "20%" });
                },               
                //Mensaje de error en caso de fallo
                error: function (ex) {
                    alert('Hubo un error en la asociación del contrato.' + ex);
                }              
            });
            //toggle('blanket');
            
        }
        else {
            swal("Cancelado", "Continue en el Menu", "error");
        }
    });
    return true;   
}

function numberFormat(numero) {
    // Variable que contendra el resultado final
    var resultado = "";

    // Si el numero empieza por el valor "-" (numero negativo)
    if (numero[0] == "-") {
        // Cogemos el numero eliminando los posibles puntos que tenga, y sin
        // el signo negativo
        nuevoNumero = numero.replace(/\./g, '').substring(1);
    } else {
        // Cogemos el numero eliminando los posibles puntos que tenga
        nuevoNumero = numero.replace(/\./g, '');
    }

    // Si tiene decimales, se los quitamos al numero
    if (numero.indexOf(",") >= 0)
        nuevoNumero = nuevoNumero.substring(0, nuevoNumero.indexOf(","));

    // Ponemos un punto cada 3 caracteres
    for (var j, i = nuevoNumero.length - 1, j = 0; i >= 0; i--, j++)
        resultado = nuevoNumero.charAt(i) + ((j > 0) && (j % 3 == 0) ? "." : "") + resultado;

    // Si tiene decimales, se lo añadimos al numero una vez forateado con 
    // los separadores de miles
    if (numero.indexOf(",") >= 0)
        resultado += numero.substring(numero.indexOf(","));

    if (numero[0] == "-") {
        // Devolvemos el valor añadiendo al inicio el signo negativo
        return "-" + resultado;
    } else {
        return resultado;
    }
}



function guardarComisiones() {

    //alert($("#NroContrato").text()); alert($("#codCertificado").val()); alert($("#MontoContrato").text());
    //alert($("#Promotores").val()); alert($("#EstatusP").val()); alert($("#Supervisores").val()); alert($("#EstatusS").val());
    //alert($("#Coordinadores").val()); alert($("#EstatusC").val()); alert($("#Gerentes").val()); alert($("#EstatusG").val());
    //var a = $('select[name=example_length]').val();
    var comisionP =parseFloat( $("#comisionPromotor").val());
    var comisionL = parseFloat($("#comisionLiner").val());
    var comisionC =parseFloat($("#comisionCloser").val());
    var contrato = document.getElementById('NroContrato').innerHTML;

    /*
    console.log(comisionP);
    console.log(comisionL);
    console.log(comisionC);*/

    //alert(comisionL);
    swal({
        title: "¿Esta Seguro Que Desea Modificar Este Registro?",
        text: "¿Toda la Información esta correcta?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#1393C1",
        confirmButtonText: "Si, Modificar!",
        cancelButtonText: "No, Cerrar!",
        closeOnConfirm: false,
        closeOnCancel: false
    }, function (isConfirm) {
        if (isConfirm) {
            $.ajax({
                type: 'POST',
                //Llamado al metodo GetidEstados en el controlador
                url: 'InsertarComisiones',
                dataType: 'json',
                //Parametros que se envian al metodo del controlador
                data:{
                   
                    nroContrato: document.getElementById('NroContrato').innerHTML, Promotores: $("#idPromotor").val(), comisionPromotor:comisionP,
                    Liner: $("#idLiner").val(), comisionLiner:comisionL, Closer: $("#idCloser").val(), comisionCloser: comisionC
                },
                //En caso de resultado exitoso
                success: function (verifi) {
                    if (verifi == false) {
                        swal("Error!", "Ocurrio un error al momento de actualizar el registro.", "error");
                    }
                    else {
                        //swal("Modificar!", "El registro se modifico Correctamente.", "success");

                        swal({
                            title: "¡Completado!",
                            text: "Comisiones modificadas correctamente",
                            type: "success",
                            showCancelButton: false,
                            confirmButtonColor: "#66CDAA",
                            confirmButtonText: "Aceptar",
                            closeOnConfirm: true
                        }, function () {
                            //$("#example1").empty();

                            
                        });

                        toggle('blanket');
                        toggle('popUpDiv');
                        Filtrar('contratos1');

                        /*
                        $("#CP" + contrato).val(comisionP);
                        $("#CL" + contrato).val(comisionL);
                        $("#CC" + contrato).val(comisionC);*/

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
            Filtrar('contratos1');*/
        }
        else {
            swal("Cancelado", "Continue en el Menu", "error");
        }
    });
    return true;
}

function InsertarUsuarios(id) {
    var titulo;
    var ruta;
    var sucess;
    var confirmacion;
    
    if (id=='insertar_usuarios') {
        titulo= "¿Esta Seguro Que Desea Guardar Este Usuario?";
        ruta='IngresarUsuarios';
        confirmacion = "Si, Guardar!";      
    }
    else {
        titulo = "¿Esta Seguro Que Desea Modificar Este Usuario?";
        ruta = 'ModificarUsuarios';
        confirmacion = "Si, Modificar!";      
    }


    var nbUsuario = $("#nbUsuario").val();
    var contraseña = $("#contraseña").val();
    var repContraseña = $("#repContraseña").val();
    var Cedula = $("#Cedula").val();
    var nombreUser = $("#nombreUser").val();
    var apeUser = $("#apeUser").val();
    var correo= $("#correo").val();
    var Perfil = $("#Perfil").val();
    var activo = $("#activo").val();   
    var Codigo = $("#Codigo").val();
  
    var mjs = "";
    var ok = true;
    //function validarEmail(correo) {
    //    expr = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    //    if (!expr.test(correo))
    //        mjs += "Error: La dirección de correo " + correo + " es incorrecta.";
    //    ok = false;
    //};
    if (nbUsuario== "") {
        mjs += "Nombre del Usuario, "
        ok = false;
    }
    if (contraseña == "") {
        mjs += "Contraseña, "
        ok = false;
    }
    if (repContraseña == "") {
        mjs += "Repetir Contraseña, "
        ok = false;
    }
    if (contraseña!=repContraseña) {
        mjs += "Las Contraseña no Coinciden, "
        ok = false;
    }
    if (Cedula == "") {
        mjs += "Cedula, "
        ok = false;
    }
    if (nombreUser == "") {
        mjs += "Nombre, "
        ok = false;
    }
    if (apeUser == "") {
        mjs += "Apellido, "
        ok = false;
    }
    if (correo == "") {
      //  mjs += "Correo, "
        // ok = false;
        correo="NO POSEE"
    }    
    if (ok == false) {
        $("#oculto").css("display", "block");
        $("#error").html(mjs);
    }
    else if (ok == true) {
        swal({
            title:titulo,
            text: "¿Toda la Información esta Correcta?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#1393C1",
            confirmButtonText:confirmacion,
            cancelButtonText: "No, Cerrar!",
            closeOnConfirm: false,
            closeOnCancel: false
        }, function (isConfirm) {
            if (isConfirm==true) {
                $.ajax({
                    type: 'POST',
                    //Llamado al metodo GetidEstados en el controlador
                    url: ruta,
                    dataType: 'html',
                    //Parametros que se envian al metodo del controlador
                    data: { nbUsuario:nbUsuario, contraseña: contraseña,Cedula:Cedula,nombreUser:nombreUser,apeUser:apeUser,correo:correo,Perfil:Perfil,activo:activo,Codigo:Codigo },
                    //En caso de resultado exitoso
                    success: function (verifi) {
                        if (verifi == false) {
                            alert("No se Ingreso el Usuario");
                        }
                        else {
                            if (id == 'insertar_usuarios') {
                                swal("Guardar!", "Usuario Guardado Correctamente.", "success");
                            }
                            else {
                                swal("Modificar!", "Usuario Modificado Correctamente.", "success");
                            }
                            /*limpiar los controles cuando se guarde o modifique un usuarios*/
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
                            /*limpiar los controles cuando se guarde o modifique un usuarios*/

                            /*se limpia el div de la tabla para cargar una partialview con la misma tabla cuando se modidicar o se agregar un nuevo usuario para mostrar la informacion en vivo*/
                            $("#popUpDiv1").empty();
                            $("#popUpDiv1").html(verifi);
                            $('#tabla_user').dataTable({
                                "bPaginate": true,
                                "bLengthChange": true,
                                "bFilter": true,
                                "pageLength": a,
                                "bSort": true,
                                "bInfo": true,
                                "bAutoWidth": true,
                                "asStripClasses": null
                            });
                           
                           
                        }
                        //Recargar el plugin para que tenga la funcionalidad del componente$("#idMunicipio").select({ placeholder: "Selecciona un Municipio", width: "20%" });
                    },
                    //Mensaje de error en caso de fallo
                    error: function (ex) {
                        alert('Failed to retrieve states.' + ex);
                    }
                });
                //toggle('blanket');
                //toggle('popUpDiv');
                
                //$("#users").submit();
                //location.reload();
              //  $("#tablaUser").load("Principal.html");
            }
            else {
                swal("Cancelado", "Continue en el Menu", "error");
            }
        });
        return true;
    }
}
function InsertarEmpleado(id) {

    $.ajax({
        type: 'POST',
        //Llamado al metodo GetidEstados en el controlador
        url: 'VerificarCodigo',
        dataType: 'json',
        //Parametros que se envian al metodo del controlador
        data: { codigo: $("#CodigoEmpleado").val() },
        //En caso de resultado exitoso
        success: function (verifi) {
          
            if (verifi==true) {
                swal("Error!", "El Codigo del Empleado Ya Existe.", "error");
            }
            else {

                var titulo;
                var ruta;
                var sucess;
                var confirmacion;
                var indicador;
                if (id == 'insertar_empleados') {
                    titulo = "¿Esta Seguro Que Desea Guardar Este Empleado";
                    //  ruta = 'IngresarEmpleado';
                    confirmacion = "Si, Guardar!";
                    indicador = true;
                }
                else {
                    titulo = "¿Esta Seguro Que Desea Modificar Este Empleado?";
                    // ruta = 'ModificarEmpleado';
                    confirmacion = "Si, Modificar!";
                    indicador = false;
                }


                var CodigoEmpleado = $("#CodigoEmpleado").val();
                var Cedula = $("#Cedula").val();
                var Nombres = $("#Nombres").val();
                var Email = $("#Email").val();
                var CodigoCargo = $("#CodigoCargo").val();
                var CodigoPrograma = $("#CodigoPrograma").val();
                var activo = $("#activo").val();
                var ID = $("#ID").val()

                var mjs = "";
                var ok = true;

                if (CodigoCargo == "") {
                    mjs += "Codigo, "
                    ok = false;
                }
                if (Cedula == "") {
                    mjs += "Cedula, "
                    ok = false;
                }
                if (Nombres == "") {
                    mjs += "Nombre, "
                    ok = false;
                }
                if (Email == "") {
                    // mjs += "Correo, "
                    // ok = false;
                    Email = "NO POSEE"
                }
                if (CodigoCargo == "<...>" || CodigoCargo == "") {
                    mjs += "Cargo, "
                    ok = false;
                }
                if (CodigoPrograma == "<...>" || CodigoPrograma == "") {
                    mjs += "Programa, "
                    ok = false;
                }
                if (ok == false) {
                    $("#oculto").css("display", "block");
                    $("#error").html(mjs);
                }
                else if (ok == true) {
                    swal({
                        title: titulo,
                        text: "¿Toda la Información esta Correcta?",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonColor: "#1393C1",
                        confirmButtonText: confirmacion,
                        cancelButtonText: "No, Cerrar!",
                        closeOnConfirm: false,
                        closeOnCancel: false
                    }, function (isConfirm) {
                        if (isConfirm == true) {
                            $.ajax({
                                type: 'POST',
                                //Llamado al metodo GetidEstados en el controlador
                                url: 'IngresarEmpleado',
                                dataType: 'html',
                                //Parametros que se envian al metodo del controlador
                                data: { CodigoEmpleado: CodigoEmpleado, Cedula: Cedula, Nombres: Nombres, Email: Email, CodigoCargo: CodigoCargo, CodigoPrograma: CodigoPrograma, activo: activo, indicador: indicador, idEmpleado: ID },
                                //En caso de resultado exitoso
                                success: function (verifi) {
                                    if (verifi == false) {
                                        alert("No se Ingreso el Usuario");
                                    }
                                    else {
                                        if (id == 'insertar_empleados') {
                                            swal("Guardar!", "Empleado Guardado Correctamente.", "success");
                                        }
                                        else {
                                            swal("Modificar!", "Empleado Modificado Correctamente.", "success");
                                        }
                                        /*limpiar los controles cuando se guarde o modifique un usuarios*/
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
                                        /*limpiar los controles cuando se guarde o modifique un usuarios*/

                                        /*se limpia el div de la tabla para cargar una partialview con la misma tabla cuando se modidicar o se agregar un nuevo usuario para mostrar la informacion en vivo*/
                                        $("#popUpDiv1").empty();
                                        $("#popUpDiv1").html(verifi);
                                        $('#tabla_user').dataTable({
                                            "bPaginate": true,
                                            "bLengthChange": true,
                                            "bFilter": true,
                                            "pageLength": a,
                                            "bSort": true,
                                            "bInfo": true,
                                            "bAutoWidth": true,
                                            "asStripClasses": null
                                        });


                                    }
                                    //Recargar el plugin para que tenga la funcionalidad del componente$("#idMunicipio").select({ placeholder: "Selecciona un Municipio", width: "20%" });
                                },
                                //Mensaje de error en caso de fallo
                                error: function (ex) {
                                    alert('Failed to retrieve states.' + ex);
                                }
                            });
                            //toggle('blanket');
                            //toggle('popUpDiv');

                            //$("#users").submit();
                            //location.reload();
                            //  $("#tablaUser").load("Principal.html");
                        }
                        else {
                            swal("Cancelado", "Continue en el Menu", "error");
                        }
                    });
                    return true;
                }
            }
           

        },
        //Mensaje de error en caso de fallo
        error: function (ex) {
            alert('Failed to retrieve states.' + ex);
        }
    });

    
}

function limpiar() {
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

function refrescar(div, desde) {
    $(div).load(desde);
}
function verificar(a) {

    $.ajax({
        type: 'POST',
        //Llamado al metodo GetidEstados en el controlador
        url: 'VerificarCodigo',
        dataType: 'json',
        //Parametros que se envian al metodo del controlador
        data: { codigo:a },
        //En caso de resultado exitoso
        success: function (verifi) {
            if (verifi == true) {
                swal("ERROR!","El Codigo del Empleado ya Existe","error");
            }
            //else {
            //    swal("Ingresado!", "Todo se ingreso Correctamente.", "success");

            //}
            //Recargar el plugin para que tenga la funcionalidad del componente$("#idMunicipio").select({ placeholder: "Selecciona un Municipio", width: "20%" });
        },
        //Mensaje de error en caso de fallo
        error: function (ex) {
            alert('Failed to retrieve states.' + ex);
        }
    });
}
//$(document).ready(function () {
//    $("#insertar_usuarios").click(function () {
//        $.post('@Url.Action("RefrescarCrearUsuarios", "Contratos")');
//    });
//    $("#modificar_usuarios").click(function () {
//        $.post('@Url.Action("RefrescarCrearUsuarios", "Contratos")').always(function () {
//            $("#tablaUser").load('/Contratos/RefrescarCrearUsuarios');
//        });
//       // $("#tablaUser").load('<%=Url.Action("RefrescarCrearUsuarios") %>');
//    });
//});


