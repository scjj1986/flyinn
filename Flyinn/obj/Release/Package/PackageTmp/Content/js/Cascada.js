
function cascada(valor) {
    // alert($("#last").html());
        var promotor = $('select#Promotores').val();
        $.ajax({
            type: 'POST',
            //Llamado al metodo GetidEstados en el controlador
            url: 'Promotor',
            dataType: 'json',
            //Parametros que se envian al metodo del controlador 
            data: { CodigoCertificado: $("#codCertificado").find('option:selected').text() },
            //En caso de resultado exitoso
            success: function (Certificado) {
                if (Certificado == 0) {
                    $('select#Promotores').val(-1);

                }
                else {
                    //Se agrega el elemento vacio para poder desplegar que seleccione una opcion
                    //$("#idPromotores").append('<option value=""><...></option>');      
                    //$.each(Certificad, function (i, Certificados) {
                    //    if (i=1) {
                    //        $('select#Promotores').val(Certificado);
                    //    }
                    //    else if (i=2) 
                    //    {
                    //        $('select#Gerentes').val(Certificado);
                    //    } 

                    //});
                    $('select#Promotores').val(Certificado);
                    if (promotor != valor) { $('select#EstatusP').val(1); } else { $('select#EstatusP').val(0); };
                }
                //Recargar el plugin para que tenga la funcionalidad del componente
                $("#Promotores").select({ placeholder: "<...>", width: "20%" });
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Ocurrio un error inesperado llame al departamento de Sistemas.' + ex);
            }
        });
        return false;

}


function getfReserva() {
    // alert($("#last").html());
        $.ajax({
            type: 'POST',
            //Llamado al metodo GetidEstados en el controlador
            url: 'fReservaCert',
            dataType: 'json',
            //Parametros que se envian al metodo del controlador
            data: { CodigoCertificado: $("#codCertificado").find('option:selected').text() },
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
        return false;

}

function getfViajeCli() {

        // alert($("#last").html());
        $.ajax({
            type: 'POST',
            //Llamado al metodo GetidEstados en el controlador
            url: 'fViajeCliCert',
            dataType: 'json',
            //Parametros que se envian al metodo del controlador
            data: { CodigoCertificado: $("#codCertificado").find('option:selected').text() },
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
        return false;
    
}


function cascada1(valor) {
    // alert($("#last").html());
    
        var supervisor = $('#Supervisores').val();
        $.ajax({
            type: 'POST',
            //Llamado al metodo GetidEstados en el controlador
            url: 'Supervisor',
            dataType: 'json',
            //Parametros que se envian al metodo del controlador
            data: { CodigoCertificado: $("#codCertificado").find('option:selected').text() },
            //En caso de resultado exitoso
            success: function (Certificado) {
                if (Certificado == 0) {
                    $('select#Supervisores').val(-1);

                }
                else {

                    $('select#Supervisores').val(Certificado);
                    if (supervisor != valor) { $('select#EstatusS').val(1); } else { $('select#EstatusS').val(0); };
                }
                //Recargar el plugin para que tenga la funcionalidad del componente
                $("#Supervisores").select({ placeholder: "<...>", width: "20%" });

            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
        return false;

}
function cascada2(valor) {
    // alert($("#last").html());
   
        var coordinador = $('#Coordinadores').val();
        $.ajax({
            type: 'POST',
            //Llamado al metodo GetidEstados en el controlador
            url: 'Coordinador',
            dataType: 'json',
            //Parametros que se envian al metodo del controlador
            data: { CodigoCertificado: $("#codCertificado").find('option:selected').text() },
            //En caso de resultado exitoso
            success: function (Certificado) {
                if (Certificado == 0) {
                    $('select#Coordinadores').val(-1);

                }
                else {
                    $('select#Coordinadores').val(Certificado);
                    if (coordinador != valor) { $('select#EstatusC').val(1); } else { $('select#EstatusC').val(0); };
                }
                //Recargar el plugin para que tenga la funcionalidad del componente
                $("#Coordinadores").select({ placeholder: "<...>", width: "20%" });
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
        return false;

}

function cascada3(valor) {
    // alert($("#last").html());
    
        var Gerentes = $('#Gerentes').val();
        $.ajax({
            type: 'POST',
            //Llamado al metodo GetidEstados en el controlador
            url: 'Gerente',
            dataType: 'json',
            //Parametros que se envian al metodo del controlador
            data: { CodigoCertificado: $("#codCertificado").find('option:selected').text() },
            //En caso de resultado exitoso
            success: function (Certificado) {
                if (Certificado == 0) {
                    $('select#Gerentes').val(-1);

                }
                else {
                    //Se agrega el elemento vacio para poder desplegar que seleccione una opcion
                    $('select#Gerentes').val(Certificado);
                    if (Gerentes != valor) { $('select#EstatusG').val(1); } else { $('select#EstatusG').val(0); };

                }
                //Recargar el plugin para que tenga la funcionalidad del componente
                $("#Gerentes").select({ placeholder: "<...>", width: "20%" });
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
        return false;


}
/*$(document).ready(function cascada(valor) {

    $("#codCertificado").change(function() {
        //Se limpia el contenido del dropdownlist
        //  $("#idPromotores").empty
        
        var promotor= $('select#Promotores').val();
        $.ajax({
            type: 'POST',
            //Llamado al metodo GetidEstados en el controlador
            url: 'Promotor',
            dataType: 'json',
            //Parametros que se envian al metodo del controlador
            data: { CodigoCertificado: $("#codCertificado").find('option:selected').text() },
            //En caso de resultado exitoso
            success: function (Certificado) {
                if (Certificado == 0) {
                    $('select#Promotores').val(-1);

                }
                else {
                    //Se agrega el elemento vacio para poder desplegar que seleccione una opcion
                    //$("#idPromotores").append('<option value=""><...></option>');      
                    //$.each(Certificad, function (i, Certificados) {
                    //    if (i=1) {
                    //        $('select#Promotores').val(Certificado);
                    //    }
                    //    else if (i=2) 
                    //    {
                    //        $('select#Gerentes').val(Certificado);
                    //    } 

                    //});
                    $('select#Promotores').val(Certificado);
                    if (promotor != valor) { $('select#EstatusP').val(1); } else { $('select#EstatusP').val(0); };
                }
                //Recargar el plugin para que tenga la funcionalidad del componente
                $("#Promotores").select({ placeholder: "<...>", width: "20%" });
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
        return false;
    })
});*/
