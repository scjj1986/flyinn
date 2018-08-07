//Mostrar DIV si trabajar familiar en la empresa.
$("input:radio[id=si]").click(function () {
    $("#mostrar").show("slow")
});

$("input:radio[id=no]").click(function () {
    $("#mostrar").hide("slow")
});

//Mostrar DIV si posee dispacidad.
$("input:radio[id=si1]").click(function () {
    $("#mostrar1").show("slow")
});
$("input:radio[id=no1]").click(function () {
    $("#mostrar1").hide("slow")
});

//Mostrar DIV si posee carnet conapdis
$("input:radio[id=si2]").click(function () {
    $("#mostrar2").show("slow")
});
$("input:radio[id=no2]").click(function () {
    $("#mostrar2").hide("slow")
});

//Mostrar DIV si sufrio accidente
$("input:radio[id=si3]").click(function () {
    $("#mostrar3").show("slow")
});
$("input:radio[id=no3]").click(function () {
    $("#mostrar3").hide("slow")
});
//Mostrar DIV Sabe Manejaar
$("input:radio[id=si4]").click(function () {
    $("#mostrar4").show("slow")
});
$("input:radio[id=no4]").click(function () {
    $("#mostrar4").hide("slow")
});
//Mostrar DId Posee Automivil
$("input:radio[id=si5]").click(function () {
    $("#mostrar5").show("slow")
});
$("input:radio[id=no5]").click(function () {
    $("#mostrar5").hide("slow")
});

//mostrar div idiomas
$("input:radio[id=si6]").click(function () {
    $("#mostrar6").show("slow")
});
$("input:radio[id=no6]").click(function () {
    $("#mostrar6").hide("slow")
});
//mostrar div de estudios actuales
$("input:radio[id=si7]").click(function () {
    $("#mostrar7").show("slow")
});
$("input:radio[id=no7]").click(function () {
    $("#mostrar7").hide("slow")
});
//mostrar div de titulos actuales
$("input:radio[id=si9]").click(function () {
    $("#mostrar9").show("slow")
});
$("input:radio[id=no9]").click(function () {
    $("#mostrar9").hide("slow")
});


//$("#btnGuardar").submit(function () {
//    if ($("#nbEmpleado").val().length < 1) {
//        //$("#nombre").css({ color: "#FFFFFF", background: "#FF0000" });
//        $("#mostrarMjs").show("slow")

//        return false;
//    }
//    return false;
//});
// VALIDACIONES PARA MOSTRAR UN MJS SI EXISTE CAMPOS VACIOS 
function mostrar()
{
    // Setear Tablas en Texto

    $("#tabla_cursosempleados").attr("value", $("#lastcur").html());
    $("#tabla_idiomasempleados").attr("value", $("#lastidi").html());
    $("#tabla_cargosempleados").attr("value", $("#lastcar").html());
    $("#tabla_experienciaempleados").attr("value", $("#lastexp").html());
    $("#tablafamiliaresempleados").attr("value", $("#lastfam_emp").html());
    $("#tabla_Estudios").attr("value", $("#lastest").html());  
    $("#tabla_Titulos").attr("value", $("#lastTit").html());


    //
    var nbEmpleado = $("#nbEmpleado").val()
    var apeEmpleado = $("#apeEmpleado").val()
    var documento = $("#documento").val()
    var fechaNacimiento = $("#fechaNacimiento").val()
    var edad = $("#edad").val()
    var correoElectronico = $("#correoElectronico").val()   
    var mjs = "";
    var nbFamiliar = $("#nbFamiliar").val()
    var apeFamiliar = $("#apeFamiliar").val()
    var familiar = $("#si").val()
    var fechaDesde = $("#fechaDesde").val()
    var fechaHasta = $("#fechaHasta").val()
    var fechaIngreso = $("#fechaIngreso").val()
    //var photo1 = $("#photo1").val()
    //var photo2 = $("#photo2").val()
    var ok = true;

    if (nbEmpleado == "") {
        document.getElementById('oculto').style.display = 'block';
        mjs += "Nombre(s), "
        ok = false;
    }
    if (apeEmpleado == "") {
        document.getElementById('oculto').style.display = 'block';
        mjs+="Apellidos(s), "
        ok = false;

    }
    if (documento == "") {
        document.getElementById('oculto').style.display = 'block';
        mjs += "Cedula, "
        ok = false;

    }
    if (fechaNacimiento=="") {
        document.getElementById('oculto').style.display = 'block';
        mjs += "Fecha de Nacimiento, "
        ok = false;
    }
    if (edad == "") {
        document.getElementById('oculto').style.display = 'block';
        mjs += "Edad, "
        ok = false;
    }
    var expresion = /^[a-z][\w.-]+@\w[\w.-]+\.[\w.-]*[a-z][a-z]$/i;
    if (!expresion.test(correoElectronico)) {
        document.getElementById('oculto').style.display = 'block';
        document.getElementById('correoElectronico').style.borderColor = 'red';
        mjs += "Correo Electronico "
        ok = false;
    }
    if (fechaDesde == "") {
        document.getElementById('oculto').style.display = 'block';
        mjs += "Fecha Cargo Inicio "
        ok = false;

    }
    if (fechaHasta == "") {
        document.getElementById('oculto').style.display = 'block';
        mjs += "Fecha Cargo Fin "
        ok = false;

    }
    if (fechaIngreso == "") {
        document.getElementById('oculto').style.display = 'block';
        mjs += "Fecha Ingreso "
        ok = false;

    }
   
    //if (photo1 == "" && photo2=="") {

    //    document.getElementById('oculto').style.display = 'block';
    //    mjs += "Debe tomar una Foto o Cargarla "
    //    ok = false;

    //}
        //if (indEmpresa!=0) {

            
        //    if (nbFamiliar == "") {
        //        document.getElementById('oculto').style.display = 'block';
        //        //var atributo = document.getElementById('nbFamiliar')
        //        //atributo.setAttribute("required","required")
                
        //        mjs += "Nombre Familiar "
        //        ok = false;
        //    }
        //    else if (apeFamiliar=="")
        //        {
               
        //        document.getElementById('oculto').style.display = 'block';
        //        mjs += "Nombre Familiar "
        //        ok = false;
        //    }
            
        //}
   
    if (ok == false) {

        document.getElementById('error').innerHTML = mjs;

    } else
    {

        swal({
            title: "¿Esta Seguro Que Desea Guardar Este Registro?",
            text: "¿Toda la Información esta correcta?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#1393C1",
            confirmButtonText: "Si, Ingresar!",
            cancelButtonText: "No, Cerrar!",
            closeOnConfirm: false,
            closeOnCancel: false
        }, function (isConfirm) {
            if (isConfirm) {
                isConfirm = false;
                swal({
                    title: "Guardado!",
                    text: "Todo se Guardo Correctamente.",
                    type: "success",                    
                    confirmButtonColor: "#1393C1",
                    confirmButtonText: "Continuar!",                    
                    closeOnConfirm: true
                }, function (isConfirm) {
                    if (isConfirm) {                        
                        document.getElementById('guardar').submit();
                    }                   
                });                
            }
            else {
                swal("Cancelado", "Continue en el Perfil", "error");
            }
        });
        
    }
    
        
      
}

function duracionCargo() {

    var Desde = new Date($("#fechaDesdeOtros1").val());
    var Hasta = new Date($("#fechaHastaOtros1").val());

    var DuracionMes, DuracionAño;
    if (Hasta.getFullYear() > Desde.getFullYear() && Hasta.getMonth() >= Desde.getMonth()) {
        DuracionMes = (new String(Hasta.getMonth() - Desde.getMonth()) + " Mes(es)");
        DuracionAño = (new String(Hasta.getFullYear() - Desde.getFullYear()) + " Año(s)");
    }
    else if (Hasta.getFullYear() >= Desde.getFullYear() && Hasta.getMonth() <= Desde.getMonth()) {
        DuracionMes = (new String((12 - Desde.getMonth()) + Hasta.getMonth()) + " Mes(es)");
        DuracionAño = (Hasta.getFullYear() - Desde.getFullYear() - 1) + " Año(s)";
    }
    else if (Hasta.getFullYear() == Desde.getFullYear() && Hasta.getMonth() >= Desde.getMonth()) {
        DuracionMes = (new String(Hasta.getMonth() - Desde.getMonth()) + " Mes(es)");
        DuracionAño = "";
    } else {
        DuracionMes = "";
        DuracionAño = "";
    }

    if (DuracionAño == "0 Año(s)") {
        DuracionAño = "";
    }
    else if (DuracionMes == "0 Mes(es)") {
        DuracionMes = "";
    }
    document.getElementById('duracionx').value = DuracionAño + " " + DuracionMes;

}
function duracionCargo1() {

    var Desde = new Date($("#fechaDesdeOtros").val());
    var Hasta = new Date($("#fechaHastaOtros").val());   

    var DuracionMes, DuracionAño;
    if (Hasta.getFullYear() > Desde.getFullYear() && Hasta.getMonth() >= Desde.getMonth()) {
        DuracionMes = (new String(Hasta.getMonth() - Desde.getMonth()) + " Mes(es)");
        DuracionAño = (new String(Hasta.getFullYear() - Desde.getFullYear()) + " Año(s)");
    }
    else if (Hasta.getFullYear() >= Desde.getFullYear() && Hasta.getMonth() <= Desde.getMonth()) {
        DuracionMes = (new String((12 - Desde.getMonth()) + Hasta.getMonth()) + " Mes(es)");
        DuracionAño = (Hasta.getFullYear() - Desde.getFullYear() - 1) + " Año(s)";
    }
    else if (Hasta.getFullYear() == Desde.getFullYear() && Hasta.getMonth() >= Desde.getMonth()) {
        DuracionMes = (new String(Hasta.getMonth() - Desde.getMonth()) + " Mes(es)");
        DuracionAño = "";
    } else {
        DuracionMes = "";
        DuracionAño = "";
    }

    if (DuracionAño == "0 Año(s)") {
        DuracionAño = "";
    }
    else if (DuracionMes == "0 Mes(es)") {
        DuracionMes = "";
    }
    document.getElementById('duracionx1').value = DuracionAño + " " + DuracionMes;

}