var formPessoaJuridica = "<div id='formPessoaJuridica'>" + $('#formPessoaJuridica').html() + "</div>";
var formPessoaFisica = "<div id='formPessoaFisica'>" + $('#formPessoaFisica').html() + "</div>";

$(document).ready(function () {
    $('#formPessoaJuridica').remove();
    $('#formPessoaFisica').remove();
    $('#panelRadioGroup').after(formPessoaFisica);
});

$('#fisica').change(function () {
    $('#panelRadioGroup').after(formPessoaFisica);
    $('#formPessoaJuridica').remove();
});

$('#juridica').change(function () {
    $('#panelRadioGroup').after(formPessoaJuridica);
    $('#formPessoaFisica').remove();
});