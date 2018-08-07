window.URL = window.URL || window.webkitURL;
navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia || navigator.msGetUserMedia ||
function () {
    alert('Su navegador no soporta navigator.getUserMedia().');
};

//Este objeto guardará algunos datos sobre la cámara
window.datosVideo = {
    'StreamVideo': null,
    'url': null
}

jQuery('#tomarfoto').on('click', function (e) {

    //Pedimos al navegador que nos da acceso a 
    //algún dispositivo de video (la webcam)
    navigator.getUserMedia({
        'audio': false,
        'video': true
    }, function (streamVideo) {
        datosVideo.StreamVideo = streamVideo;
        datosVideo.url = window.URL.createObjectURL(streamVideo);
        jQuery('#video').attr('src', datosVideo.url);

    }, function () {
        alert('No fue posible obtener acceso a la cámara.');
    });

    cargarfoto.hidden = true;
    photo2.hidden = true;
    photo.hidden = true;
    tomarfoto.hidden = true;
    video.hidden = false;
    tomar1.hidden = false;
    cancelar1.hidden = false;


});

jQuery('#cancelar').on('click', function (e) {

    if (datosVideo.StreamVideo) {
        datosVideo.StreamVideo.getVideoTracks()[0].stop();
        window.URL.revokeObjectURL(datosVideo.url);
    }

    cargarfoto.hidden = false;
    photo2.hidden = false;
    photo.hidden = false;
    tomarfoto.hidden = false;
    video.hidden = true;
    tomar1.hidden = true;
    cancelar1.hidden = true;

});

jQuery('#tomar').on('click', function (e) {

    var oCamara, oFoto, oContexto, oPhoto, oPhoto1, w, h;

    oCamara = jQuery('#video');
    oFoto = jQuery('#canvas');
    oPhoto = jQuery('#photo1')

    w = oCamara.width();
    h = oCamara.height();
    oFoto.attr({
        'width': w,
        'height': h
    });
    oFoto[0].getContext('2d').drawImage(oCamara[0], 0, 0, w, h);
    var data = oFoto[0].toDataURL('image/jpg');
    photo.setAttribute('src', data);
    oPhoto.attr('value', data);

    if (datosVideo.StreamVideo) {
        datosVideo.StreamVideo.getVideoTracks()[0].stop();
        window.URL.revokeObjectURL(datosVideo.url);
    }

    var input = $("#photo2");
    input.replaceWith(input.clone(true));

    cargarfoto.hidden = false;
    photo2.hidden = false;
    photo.hidden = false;
    tomarfoto.hidden = false;
    video.hidden = true;
    tomar1.hidden = true;
    cancelar1.hidden = true;

});

$(window).load(function () {


    $(function () {
        $('#photo2').click(function (e) {

            if (datosVideo.StreamVideo) {
                datosVideo.StreamVideo.getVideoTracks()[0].stop();
                window.URL.revokeObjectURL(datosVideo.url);
            }

            photo.hidden = false;
            video.hidden = true;
            tomar.hidden = true;
            cancelar.hidden = true;
            photo2.hidden = false;
        });

        $('#photo2').change(function (e) {
            addImage(e);
            $('#photo1').attr('value', "");
        });

        function addImage(e) {
            var file = e.target.files[0],
            imageType = /image.*/;

            if (!file.type.match(imageType))
                return;

            var reader = new FileReader();
            reader.onload = fileOnload;
            reader.readAsDataURL(file);
        }

        function fileOnload(e) {
            var result = e.target.result;
            $('#photo').attr("src", result);
        }
    });    

});


