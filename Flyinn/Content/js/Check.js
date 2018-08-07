
$(function () {
    //$.getScript('Search.js', function () {
        
    //})
    //ESTE METODO SIRVE PARA RECORRER LAS FILAS DE UNA TABLA SOLO SI TIENE UN CAMPO CON CHECKBOX LOS REGISTRSO SELECCIONADOS SE ENVIA POR AJAX AL SERVIDOR Y SE GUARDAN EN BASE DE DATOS. 
   
    var list = [];
    var check, NroContrato, Fecha, MontoContrato, Porcentaje;
    var index;
    var ind = false;
    var checkAll = new Boolean()
    $("#tbComplemento").on("check-all.bs.table", function (e, row) { //EVENTO PARA TILTAR UNA FILA E INSERTAR LOS DATOS DE LA FILA SELECCIONADA POR UN CHECKBOX Y SE GUARDA EN UNA ARREGLO 

        checkAll = true;
        list.push({ NroContrato: row.NroContrato, Fecha: $("#FechaProcesable1").val(), MontoContrato: row.MontoContrato, Porcentaje: row.Porcentaje });
       // alert('hola mundo' + list.length);
        ind = true;
        console.log(list);
    });
    $("#tbComplemento").on("uncheck-all.bs.table", function (e, row) { //EVENTO PARA TILTAR UNA FILA E INSERTAR LOS DATOS DE LA FILA SELECCIONADA POR UN CHECKBOX Y SE GUARDA EN UNA ARREGLO 
        $.each(list, function (index, value) {
            if (value.NroContrato === row.NroContrato) {
                list.splice(index, 1);
            }
        });
        checkAll = false;
        console.log(list);
    });
    
    $("#tbComplemento").on("check.bs.table", function (e, row) { //EVENTO PARA TILTAR UNA FILA E INSERTAR LOS DATOS DE LA FILA SELECCIONADA POR UN CHECKBOX Y SE GUARDA EN UNA ARREGLO 
        list.push({ NroContrato: row.NroContrato, Fecha: $("#FechaProcesable1").val(), MontoContrato: row.MontoContrato, Porcentaje: row.Porcentaje });
     //   alert('hola mundo' + row.NroContrato);
        ind = true;
        console.log(list);
    });

    $('#tbComplemento').on('uncheck.bs.table', function (e, row) { //EVENTO PARA QUITAR DEL ARREGLO EL REGISTRO QUE SE DESTILDO..
        $.each(list, function (index, value) {
            if (value.NroContrato === row.NroContrato) {
                list.splice(index, 1);
            }
        });
        console.log(list); 
    });
    
    $("#btnProcesar").click(function () {     
        if ($("#FechaProcesable1").val() == "") {
            swal("Error", "Debe colocar fecha procesable", "error");
            return;
        }
        console.log("epa");
swal({
    title: "¿Esta Seguro Que Desea Insertar Estos Complementos?",
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
       
        if (checkAll == true) {
            $("#tbComplemento tbody tr").each(function (index) {

                $(this).children("td").each(function (index2) {
                    
                    switch (index2) {
                        case 0:                            
                            check = $(this).text()
                            break;
                        case 1: NroContrato = $(this).text();
                            break;
                        case 2: Fecha = $("#FechaProcesable1").val();
                            break;
                        case 3: MontoContrato = ($(this).text());
                            break;
                        case 4: Porcentaje = ($(this).text());
                            break;
                    }                   
                    list = { 'Lista': [NroContrato, Fecha, MontoContrato, Porcentaje] }
                });
               
                $.ajax({
                    type: 'POST',
                    //Llamado al metodo GetDepartByGeren en el controlador
                    url: 'InsertarComplementos',
                    dataType: 'html',
                    //Parametros que se envian al metodo del controlador
                    // data: { NroContrato: NroContrato, Fecha: Fecha, Monto: Monto, Porcentaje: Porcentaje },
                    data: list,
                    //En caso de resultado exitoso
                    success: function (verifi) {

                    },
                    //Mensaje de error en caso de fallo
                    error: function (ex) {
                       // alert('Ocurrio un Error Inesperado por favor comunicarse con el departamento de Sistemas.' + ex);
                    }
                });
            });
            swal("Guardar", "Datos Ingresados Correctamente.", "success");
        }
        else {
                $.each(list, function (index, value) { // RECORRE EL ARREGLO LIST CON UN FOREACH Y PASA LOS DATOS POR AJAX AL CONTROLADOR Y SE INSERTAN EN BASE DE DATOS. 

                    list = { 'Lista': [value.NroContrato, value.Fecha, value.MontoContrato, value.Porcentaje] }

                    $.ajax({
                        type: 'POST',
                        //Llamado al metodo GetDepartByGeren en el controlador
                        url: 'InsertarComplementos',
                        dataType: 'html',
                        //Parametros que se envian al metodo del controlador
                        // data: { NroContrato: NroContrato, Fecha: Fecha, Monto: Monto, Porcentaje: Porcentaje },
                        data: list,
                        //En caso de resultado exitoso
                        success: function (verifi) {

                        },
                        //Mensaje de error en caso de fallo
                        error: function (ex) {
                            //alert('Ocurrio un Error Inesperado por favor comunicarse con el departamento de Sistemas.' + ex);
                        }
                    });    
                    swal("Guardar", "Datos Ingresados Correctamente.", "success");              
                });
            }
    }
    else {
        swal("Cancelado", "Continue en el Menu", "error");
    }
    $("#btnConsultar").click();
    
 });
        if (ind == false) {

            swal("Error", "Debe seleccionar al menos un contrato para continuar con la operación", "error");
        }
          //  swal("Selección!", "Debe selecciona al menos un contrato", "error")
        
       
     //   ESTE METODO SIRVE PARA RECORRER LAS FILAS DE UNA TABLA SE ENVIA POR AJAX AL SERVIDOR Y SE INSERTAR EN BASE DE DATOS. 
        //$("#tbComplemento tbody tr").each(function (index) { 
           
        //        $(this).children("td").each(function (index2) {

        //            ///NroContrato
        //            switch (index2) {
        //                case 0:
        //                    if ($(this).find('btSelectItem').is(':checked') == true) {
        //                        alert('hola mundo');
        //                    }
        //                    else {
        //                        alert('hola mundo');
        //                    }
        //                    check = $(this).text()
        //                    break;
        //                case 1: NroContrato = $(this).text();
        //                    break;
        //                case 2: Fecha = $(this).text();
        //                    break;
        //                case 3: MontoContrato = ($(this).text());
        //                    break;
        //                case 4: Porcentaje = ($(this).text());
        //                    break;
        //            }
        //            // $(this).css("background-color", "#ECF8E0");
        //            list = { 'Lista': [NroContrato, Fecha, MontoContrato, Porcentaje] }

        //        });
        //                       
        //$.ajax({
        //    type: 'POST',
        //    //Llamado al metodo GetDepartByGeren en el controlador
        //    url: 'InsertarComplementos',
        //    dataType: 'html',
        //    //Parametros que se envian al metodo del controlador

        //    // data: { NroContrato: NroContrato, Fecha: Fecha, Monto: Monto, Porcentaje: Porcentaje },
        //    data: list,
        //    //En caso de resultado exitoso
        //    success: function (verifi) {

        //    },
        //    //Mensaje de error en caso de fallo
        //    error: function (ex) {
        //        alert('Failed to retrieve states.' + ex);
        //    }
        //});
    //})
   
  })
})
