$(window).load(function () {


    $(function () {
        $("input:radio[id=si2]").click(function () {
            carnet.hidden = false;
            addImage(e);
        });

        $('#conapdis').change(function (e) {
            carnet.hidden = false;
            addImage(e);

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
            $('#carnet').attr("src", result);
        }

    });

});


