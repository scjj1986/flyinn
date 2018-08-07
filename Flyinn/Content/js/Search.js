var resp;
function Filtrar(a) {
    var ruta;
    
    var PPF = $('#PPF-CTR').prop("checked") ? "PPF" : "@**@";
    var PVB = $('#PVB-CTR').prop("checked") ? "PVB" : "@**@";

    if (a == "contratos1") {

        var PPF = $('#PPF').prop("checked") ? "@**@" : "PPF";
        var PVB = $('#PVB').prop("checked") ? "@**@" : "PVB";

    }

    /*
    var PPF = $('#PPF-CTR').prop("checked") ? "@**@" : "PPF";
    var PVB = $('#PVB-CTR').prop("checked") ? "@**@" : "PVB";

    var PPF = $('#PPF-CTR').is(':checked') ? "@**@" : "PPF";
    var PVB = $('#PVB-CTR').is(':checked') ? "@**@" : "PVB";*/

    //alert(PPF);

    //alert(PVB);


    var boton = $("#btnFiltrar").val();
    var fechaInicio = $("#fechaInicio").val();
    var fechaFin = $("#fechaFin").val();
    var codOfiIsla = $('#codOfiIsla').prop("checked") ? $("#codOfiIsla").val() : -1;
    var codOfiCosta = $('#codOfiCosta').prop("checked") ? $("#codOfiCosta").val() : -1;
    var codOfiPlaya = $('#codOfiPlaya').prop("checked") ? $("#codOfiPlaya").val() : -1;
    var codOfiCoche = $('#codOfiCoche').prop("checked") ? $("#codOfiCoche").val() : -1;
    var codOfiSala = $('#codOfiSala').prop("checked") ? $("#codOfiSala").val() : -1;
    var codOfiSala5 = $('#codOfiSala5').prop("checked") ? $("#codOfiSala5").val() : -1;

    console.log(fechaInicio);
    //alert($('#PPF-CTR').is(':checked'));
    
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
                    //$("#btnPDF3").attr("href", "/Report/PDFReporteContratosProcesables?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "&codOfiIsla=" + codOfiIsla + "&codOfiCosta=" + codOfiCosta + "&codOfiPLaya=" + codOfiPlaya +
                     //"&codOfiCoche=" + codOfiCoche + "&codOfiSala=" + codOfiSala + "&codOfiSala5=" + codOfiSala5 + "&PPF=" + PPF + "&PVB=" + PVB + "&CodigoPrograma=" + CodigoPrograma + "");

                

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

function FiltrarC(a) {
    var ruta;

    var PPF = $('#PPF-CTR').prop("checked") ? "PPF" : "@**@";
    var PVB = $('#PVB-CTR').prop("checked") ? "PVB" : "@**@";

    if (a == "contratos1") {

        var PPF = $('#PPF').prop("checked") ? "@**@" : "PPF";
        var PVB = $('#PVB').prop("checked") ? "@**@" : "PVB";

    }

    /*
    var PPF = $('#PPF-CTR').prop("checked") ? "@**@" : "PPF";
    var PVB = $('#PVB-CTR').prop("checked") ? "@**@" : "PVB";

    var PPF = $('#PPF-CTR').is(':checked') ? "@**@" : "PPF";
    var PVB = $('#PVB-CTR').is(':checked') ? "@**@" : "PVB";*/

    //alert(PPF);

    //alert(PVB);


    var boton = $("#btnFiltrar").val();
    var fechaInicio = $("#fechaInicio").val();
    var fechaFin = $("#fechaFin").val();
    var codOfiIsla = $('#codOfiIsla').prop("checked") ? $("#codOfiIsla").val() : -1;
    var codOfiCosta = $('#codOfiCosta').prop("checked") ? $("#codOfiCosta").val() : -1;
    var codOfiPlaya = $('#codOfiPlaya').prop("checked") ? $("#codOfiPlaya").val() : -1;
    var codOfiCoche = $('#codOfiCoche').prop("checked") ? $("#codOfiCoche").val() : -1;
    var codOfiSala = $('#codOfiSala').prop("checked") ? $("#codOfiSala").val() : -1;
    var codOfiSala5 = $('#codOfiSala5').prop("checked") ? $("#codOfiSala5").val() : -1;

    console.log(fechaInicio);
    //alert($('#PPF-CTR').is(':checked'));

    var CodigoPrograma = $("#CodigoPrograma").val();
    var mjs = "";
    var ok = true;
    if (a == "contratos") {
        ruta = "Filtrar";
    }
    else {
        ruta = "generarC"
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

                
                if (verifi == false) {
                    alert("No se Ingreso Certificado");
                }
                else {
                    /*
                    swal("Ingresado!", "Todo se ingreso Correctamente.", "success");
                    toggle('blanket');
                    toggle('popUpDiv');
                    location.reload();*/

                    swal({
                        title: "¡Completado!",
                        text: "Comisiones generadas correctamente",
                        type: "success",
                        showCancelButton: false,
                        confirmButtonColor: "#66CDAA",
                        confirmButtonText: "Aceptar",
                        closeOnConfirm: true
                    }, function () {
                        $("#example1").empty();
                    });



                }
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
    }
}


function FiltrarVPF() {
    var ruta;
    var boton = $("#btnFiltrar").val();
    var fechaInicio = $("#fInicio").val();
    var fechaFin = $("#fFin").val();
    var codOfiIsla = $('#codOfiIslaVPF').is(':checked') ? $("#codOfiIslaVPF").val() : -1;
    var codOfiCosta = $('#codOfiCostaVPF').is(':checked') ? $("#codOfiCostaVPF").val() : -1;
    var codOfiPlaya = $('#codOfiPlayaVPF').is(':checked') ? $("#codOfiPlayaVPF").val() : -1;
    var codOfiCoche = $('#codOfiCocheVPF').is(':checked') ? $("#codOfiCocheVPF").val() : -1;
    var codOfiSala = $('#codOfiSala').prop("checked") ? $("#codOfiSala").val() : -1;
    var codOfiSala5 = $('#codOfiSala5VPF').is(':checked') ? $("#codOfiSala5VPF").val() : -1;
    var codOfiSala7 = $('#codOfiSala7VPF').is(':checked') ? $("#codOfiSala7VPF").val() : -1;
    var Proc = $('#Procesable').prop("checked") ? "Procesable" : null;
    var Pend = $('#Pending').prop("checked") ? "Pending" : null;
    var Anul = $('#Anulado').prop("checked") ? "Anulado" : null;
    var mjs = "";
    var ok = true;


    console.log(codOfiCoche);
    console.log(codOfiPlaya);  


    if (fechaInicio == "") {
        mjs += " Fecha Inicio "
        ok = false;
    }
    if (fechaFin == "") {
        mjs += " Fecha Fin "
        ok = false;
    }
    if (Proc == null && Pend == null && Anul == null) {

        mjs += " Estatus (Procesable, Pending o Anulado) "
        ok = false;
    }

    if (ok == false) {
        swal("Verificar Campos!", "Campos: " + mjs + " - Se encuentran vacios!!!", "error")
        //alert();
    }
    else if (ok == true) {
        //alert(fechaInicio); alert(fechaFin); alert(codOfiIsla); alert(codOfiCosta); alert(codOfiPlaya); alert(codOfiCoche); alert(codOfiSala);

        fechaInicio = fechaInicio + " 00:00:00";
        fechaFin = fechaFin + " 23:59:59";
        $.ajax({
            type: 'POST',
            //Llamado al metodo GetDepartByGeren en el controlador
            url: 'FiltrarVPF',
            dataType: 'html',
            //Parametros que se envian al metodo del controlador
            data: { fechaInicio: fechaInicio, fechaFin: fechaFin, codOfiIsla: codOfiIsla, codOfiCosta: codOfiCosta, codOfiPlaya: codOfiPlaya, codOfiCoche: codOfiCoche, codOfiSala: codOfiSala, codOfiSala5: codOfiSala5, codOfiSala7: codOfiSala7, Proc: Proc, Pend: Pend, Anul: Anul},
            //En caso de resultado exitoso
            success: function (verifi) {

                //console.log(verifi);

                //$("#btnPDF-VPF").attr("href", "/Report/PDFReporteVPF?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "&codOfiIsla=" + codOfiIsla + "&codOfiCosta=" + codOfiCosta + "&codOfiPLaya=" + codOfiPlaya +
              //"&codOfiCoche=" + codOfiCoche + "&codOfiSala=" + codOfiSala + "&codOfiSala5=" + codOfiSala5 + "&codOfiSala7=" + codOfiSala7 + "&Proc=" + Proc + "&Pend=" + Pend + "&Anul=" + Anul + "");

                $("#btnPDF-VPF").attr("href", "/Flyinn/Report/PDFReporteVPF?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "&codOfiIsla=" + codOfiIsla + "&codOfiCosta=" + codOfiCosta + "&codOfiPLaya=" + codOfiPlaya +
                "&codOfiCoche=" + codOfiCoche + "&codOfiSala=" + codOfiSala + "&codOfiSala5=" + codOfiSala5 + "&codOfiSala7=" + codOfiSala7 + "&Proc=" + Proc + "&Pend=" + Pend + "&Anul=" + Anul + "");

                $("#exampleVPF").empty();
                $("#exampleVPF").html(verifi);
                $('#example-VPF').dataTable({
                    "bPaginate": true,
                    "bLengthChange": true,
                    "bFilter": true,
                    "pageLength": 50,
                    "bSort": true,
                    "bInfo": true,
                    "bAutoWidth": true,
                    "asStripClasses": null
                });

                
                
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
    }
}



function TransferirComisiones() {

    var fechaInicio = $("#fchini").val();
    var fechaFin = $("#fchfin").val();

    swal({
        title: "Transferir Comisiones",
        text: "Está seguro en transferir",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-success",
        confirmButtonText: "Aceptar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false,
        closeOnCancel: true
    },
    function (isConfirm) {
        if (isConfirm) {
            //swal("Deleted!", "Your imaginary file has been deleted.", "success");
            
            $.ajax({
                type: 'POST',
                //Llamado al metodo GetDepartByGeren en el controlador
                url: 'InsertarComiTrans',
                dataType: 'html',
                //Parametros que se envian al metodo del controlador
                data: { fechaInicio: fechaInicio, fechaFin: fechaFin},
                //En caso de resultado exitoso
                success: function (verifi) {

                    
                    alert('Fallo en la transferencia de nomima.' + ex);
                    


                },
                //Mensaje de error en caso de fallo
                error: function (ex) {
                    $.ajax({
                        type: 'POST',
                        //Llamado al metodo GetDepartByGeren en el controlador
                        url: 'ActualizarComiTrans',
                        dataType: 'html',
                        //Parametros que se envian al metodo del controlador
                        data: { fechaInicio: fechaInicio, fechaFin: fechaFin },
                        //En caso de resultado exitoso
                        success: function (verifi) {

                            alert('Fallo en la actualizacion de nomima.' + ex);

                            

                        },
                        //Mensaje de error en caso de fallo
                        error: function (ex) {

                            $("#example2").empty();
                            swal("Finalizado", "La transferencia de comisiones fue realizada satisfactoriamente", "success");
                            
                        }
                    });
                }
            });

            


        } else {
            //swal("Cancelled", "Your imaginary file is safe :)", "error");
        }
    });
}


function BuscarComisionesTransferencia() {

    
    var fechaInicio = $("#fchini").val();
    var fechaFin = $("#fchfin").val();

    $("#dvListado").html("Listado de comisiones desde " + fechaInicio + " hasta el " + fechaFin);

    if (fechaInicio == "") {

        swal("Verificar Campos!", "El campo Fecha de Inicio se encuentra vacío!", "error");

    }
    else if (fechaFin == "") {

        swal("Verificar Campos!", "El campo Fecha Final se encuentra vacío!", "error");

    }
    else if (fechaInicio.toString() > fechaFin.toString()) {

        swal("Fechas!", "La fecha de inicio no puede ser mayo que la fecha final!", "error");
    }
    else {
        
        $.ajax({
            type: 'POST',
            //Llamado al metodo GetDepartByGeren en el controlador
            url: 'BuscarComiTrans',
            dataType: 'html',
            //Parametros que se envian al metodo del controlador
            data: { fechaInicio: fechaInicio, fechaFin: fechaFin},
            //En caso de resultado exitoso
            success: function (verifi) {
                $("#example2").empty();
                $("#example2").html(verifi);
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
    }


}




function Buscar(a) {
    var fechaInicio = $("#fechaInicio").val();
    var fechaFin = $("#fechaFin").val();
    var mjs = "";
    var ok = true;

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
            url: 'BuscarCertificado',
            dataType: 'html',
            //Parametros que se envian al metodo del controlador
            data: { fechaInicio: fechaInicio, fechaFin: fechaFin },
            //En caso de resultado exitoso
            success: function (verifi) {
                $("#example1").empty();
                $("#example1").html(verifi);
                $("#example2").dataTable({
                    "bPaginate": true,
                    "bLengthChange": true,
                    "bFilter": true,
                    "pageLength": 100,
                    "bSort": true,
                    "bInfo": true,
                    "bAutoWidth": true,
                    "asStripClasses": null
                });

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

function FiltrarReportesComisionesDetalladas() {
    var fechaInicio = $("#fechaInicio2").val();
    var fechaFin = $("#fechaFin2").val();
    var mjs = "";
    var ok = true;
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
            url: 'FiltrarReportesComisionesDetalladas',
            dataType: 'html',
            //Parametros que se envian al metodo del controlador
            data: { fechaInicio: fechaInicio, fechaFin: fechaFin },
            //En caso de resultado exitoso
            success: function (verifi) {
                $("#example3").empty();
                $("#example3").html(verifi);
                $("#btnPDF").attr("href", "/Flyinn/Report/PDFReportesComisionesDetalladas?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "");
                //$("#btnPDF").attr("href", "/Report/PDFReportesComisionesDetalladas?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "");


                //$("#btnExcel").attr("href", "/Report/Excel?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
    }
}

function FiltrarReportesComisiones(mens) {
    
    var fechaInicio = $("#fechaInicio1").val();
    var fechaFin = $("#fechaFin1").val();
    var mjs = "";
    var ok = true;
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
    verificaCierre(fechaInicio,fechaFin)
    if (mens == 1) {
        
        if (ok == true) {
            //alert(fechaInicio); alert(fechaFin); alert(codOfiIsla); alert(codOfiCosta); alert(codOfiPlaya); alert(codOfiCoche); alert(codOfiSala);
            $.ajax({
                type: 'POST',
                //Llamado al metodo GetDepartByGeren en el controlador
                url: 'FiltrarReportesComisiones',
                dataType: 'html',
                //Parametros que se envian al metodo del controlador
                data: { fechaInicio: fechaInicio, fechaFin: fechaFin },
                //En caso de resultado exitoso
                success: function (verifi) {
                    $("#example2").empty();
                    $("#example2").html(verifi);
                    $("#btnPDF1").attr("href", "/Flyinn/Report/PDFReportesComisiones?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "");
                    //$("#btnPDF1").attr("href", "/Report/PDFReportesComisiones?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "");
                    //$("#btnExcel").attr("href", "/Report/Excel?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");
                },
                //Mensaje de error en caso de fallo
                error: function (ex) {
                    alert('Failed to retrieve states.' + ex);
                }
            });
        }
    } else {
        
         if (ok == true) {          
           
            if (resp == 1) {
                swal("Cierre ya realizado!", "Se guardo anteriormente un cierre con este rango de fecha", "error")

            } else {
              
               $.ajax({
                    type: 'POST',
                    //Llamado al metodo GetDepartByGeren en el controlador
                    url: 'GuardaHistorico',
                    dataType: 'html',
                    //Parametros que se envian al metodo del controlador
                    data: { fechaInicio: fechaInicio, fechaFin: fechaFin },
                    //En caso de resultado exitoso
                    success: function (verifi) {
                       // $("#example2").empty();
                        // $("#example2").html(verifi);
                        // $("#btnPDF1").attr("href", "/Flyinn/Report/PDFReportesComisiones?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "");
                        //$("#btnExcel").attr("href", "/Report/Excel?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");
                        //swal("Información", "Se guardo correctamente", "success")
                    },
                    //Mensaje de error en caso de fallo
                    error: function (ex) {
                       swal("Información", "Se guardo correctamente", "success")
                    }
                });
            }
        }
       // swal("Hola", "porf in historico", "success")
    }
}




function ConsultarComplementos() {
    var FechaInicio = $("#FechaInicio").val();
    var FechaFin = $("#FechaFin").val();
    var mjs = "";
    var ok = true;

    if (FechaInicio == "") {
        mjs += " Fecha Inicio "
        ok = false;
    }
    if (FechaFin == "") {
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
            url: 'ConsultarComplementos',
            dataType: 'html',
            //Parametros que se envian al metodo del controlador
            data: { FechaInicio: FechaInicio, FechaFin: FechaFin },
            //En caso de resultado exitoso
            success: function (verifi) {
                $("#table_C").empty();
                $("#table_C").html(verifi);


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
function Usuarios() {

    //alert(fechaInicio); alert(fechaFin); alert(codOfiIsla); alert(codOfiCosta); alert(codOfiPlaya); alert(codOfiCoche); alert(codOfiSala);
    $.ajax({
        type: 'POST',
        //Llamado al metodo GetDepartByGeren en el controlador
        url: 'PartialViewUsuarios',
        dataType: 'html',
        //Parametros que se envian al metodo del controlador
        data: {},
        //En caso de resultado exitoso
        success: function (verifi) {
            $("#Users").empty();
            $("#Users").html(verifi);


            //$("#btnPDF").attr("href", "/Report/PDF?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");           
            //$("#btnExcel").attr("href", "/Report/Excel?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");
        },
        //Mensaje de error en caso de fallo
        error: function (ex) {
            alert('Failed to retrieve states.' + ex);
        }
    });

}
function Empleados() {

    //alert(fechaInicio); alert(fechaFin); alert(codOfiIsla); alert(codOfiCosta); alert(codOfiPlaya); alert(codOfiCoche); alert(codOfiSala);
    $.ajax({
        type: 'POST',
        //Llamado al metodo GetDepartByGeren en el controlador
        url: 'PartialViewEmpleado',
        dataType: 'html',
        //Parametros que se envian al metodo del controlador
        data: {},
        //En caso de resultado exitoso
        success: function (verifi) {
            $("#vistaEmpleados").empty();
            $("#vistaEmpleados").html(verifi);


            //$("#btnPDF").attr("href", "/Report/PDF?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");           
            //$("#btnExcel").attr("href", "/Report/Excel?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");
        },
        //Mensaje de error en caso de fallo
        error: function (ex) {
            alert('Failed to retrieve states.' + ex);
        }
    });

}
function ModalView(idModal, Partial) { //metodo generico para mostrar la partialview

    //alert(fechaInicio); alert(fechaFin); alert(codOfiIsla); alert(codOfiCosta); alert(codOfiPlaya); alert(codOfiCoche); alert(codOfiSala);
    $.ajax({
        type: 'POST',
        //Llamado al metodo GetDepartByGeren en el controlador
        url: Partial,
        dataType: 'html',
        //Parametros que se envian al metodo del controlador
        data: {},
        //En caso de resultado exitoso
        success: function (verifi) {
            $('#' + idModal + '').empty();
            $('#' + idModal + '').html(verifi);
            //$("#btnPDF").attr("href", "/Report/PDF?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");           
            //$("#btnExcel").attr("href", "/Report/Excel?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");
        },
        //Mensaje de error en caso de fallo
        error: function (ex) {
            alert('Failed to retrieve states.' + ex);
        }
    });

}
function verificarTabla() {
    //alert( $("#table>tbody >tr >td").text());
    if ($("#table >tbody >tr >td").text() == 'No matching records found') {
        swal("Error", "Debe generar una consulta para poder continuar", "error");

    }
    


}

function verificaCierre(inicio, fin) {
  
    $.ajax({
        type: 'POST',
        //Llamado al metodo GetDepartByGeren en el controlador
        url: 'verificaCierre',
        dataType: 'html',
        //Parametros que se envian al metodo del controlador
        data: { fechaInicio: inicio, fechaFin: fin },
        //En caso de resultado exitoso
        success: function (verifi) {
            
            if (verifi == 1) {
               
                resp=1;
            }
            else
                resp=0;           
        }     
       
    });
    
}
function FiltrarReportesComisionesHistorico() {
    
    var fechaInicio = $("#fechaInicio3").val();
    var fechaFin = $("#fechaFin3").val();
    var mjs = "";
    var ok = true;
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
            url: 'FiltrarReportesComisionesHistorico',
            dataType: 'html',
            //Parametros que se envian al metodo del controlador
            data: { fechaInicio: fechaInicio, fechaFin: fechaFin },
            //En caso de resultado exitoso
            success: function (verifi) {
                $("#example4").empty();
                $("#example4").html(verifi);

                $("#btnPDF4").attr("href", "/Flyinn/Report/PDFReporteHistorico?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "");
                //$("#btnPDF4").attr("href", "/Report/PDFReporteHistorico?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "");



                //$("#btnExcel").attr("href", "/Report/Excel?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
    }
}
function FiltrarReportesComplementos() {

    var fechaInicio = $("#fechaInicio4").val();
    var fechaFin = $("#fechaFin4").val();
    var mjs = "";
    var ok = true;
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
            url: 'FiltrarReporteComplementos',
            dataType: 'html',
            //Parametros que se envian al metodo del controlador
            data: { fechaInicio: fechaInicio, fechaFin: fechaFin },
            //En caso de resultado exitoso
            success: function (verifi) {
                $("#example5").empty();
                $("#example5").html(verifi);
                $("#btnPDFC").attr("href", "/Flyinn/Report/PDFReporteComplementos?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "");
                //$("#btnPDFC").attr("href", "/Report/PDFReporteComplementos?fechaInicio=" + fechaInicio + "&fechaFin=" + fechaFin + "");
                //$("#btnExcel").attr("href", "/Report/Excel?idTipoDocumento=" + idTipoDocumento + "&documento=" + documento + "");
            },
            //Mensaje de error en caso de fallo
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
    }
}