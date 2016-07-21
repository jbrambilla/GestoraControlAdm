$(document).ready(function () {
    if ($('#pj').val() == "") {
        $("#pj").prop("disabled", true);
        $("#pf").prop("disabled", false);
    }
    else {
        $("#pj").prop("disabled", false);
        $("#pf").prop("disabled", true);
    }

    $('#fisica').change(function () {

        $("#pj").prop("disabled", true);
        $("#pf").prop("disabled", false);

    });
    $('#juridica').change(function () {
        $("#pf").prop("disabled", true);
        $("#pj").prop("disabled", false);
    });
});