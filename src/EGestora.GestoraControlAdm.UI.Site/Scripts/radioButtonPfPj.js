var formPessoaJuridica = "<fieldset id='formPessoaJuridica'>" + $('#formPessoaJuridica').html() + "</fieldset>";
var formPessoaFisica = "<fieldset id='formPessoaFisica'>" + $('#formPessoaFisica').html() + "</fieldset>";

$(document).ready(function () {
    $('#formPessoaJuridica').remove();
    $('#formPessoaFisica').remove();
    $('#fieldsetRadio').after(formPessoaFisica);
    mascaras();
});

$('#fisica').change(function () {
    $('#fieldsetRadio').after(formPessoaFisica);
    $('#formPessoaJuridica').remove();
    mascaras();
});

$('#juridica').change(function () {
    $('#fieldsetRadio').after(formPessoaJuridica);
    $('#formPessoaFisica').remove();
    $('#cnaeid').select2();
    $('#cnaelist').select2({
        placeholder: "Lista de Cnaes secundários"
    });
    mascaras();
});

function mascaras()
{
    $(".date").mask("99/99/9999");
    $(".cpf").mask("999.999.999-99");
    $(".rg").mask("99.999.999-9");
    $(".cnpj").mask("99.999.999/9999-99");
    $('.maskdate').mask('99/99/9999');
}
