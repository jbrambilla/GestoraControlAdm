var formPessoaJuridica = "<fieldset id='formPessoaJuridica'>" + $('#formPessoaJuridica').html() + "</fieldset>";
var formPessoaFisica = "<fieldset id='formPessoaFisica'>" + $('#formPessoaFisica').html() + "</fieldset>";

$(document).ready(function () {
    $('#formPessoaJuridica').remove();
    $('#formPessoaFisica').remove();
    $('#fieldsetRadio').after(formPessoaFisica);
});

$('#fisica').change(function () {
    $('#fieldsetRadio').after(formPessoaFisica);
    $('#formPessoaJuridica').remove();
});

$('#juridica').change(function () {
    $('#fieldsetRadio').after(formPessoaJuridica);
    $('#formPessoaFisica').remove();
    $('#cnaeid').select2();
    $('#cnaelist').select2({
        placeholder: "Lista de Cnaes secundários"
    });
});
