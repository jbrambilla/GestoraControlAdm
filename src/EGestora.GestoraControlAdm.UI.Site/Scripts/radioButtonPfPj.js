var formPessoaJuridica = "<div id='formPessoaJuridica'>" + $('#formPessoaJuridica').html() + "</div>";
var formPessoaFisica = "<div id='formPessoaFisica'>" + $('#formPessoaFisica').html() + "</div>";

$(document).ready(function () {
    $('#formPessoaJuridica').remove();
    $('#formPessoaFisica').remove();
    $('#panelRadioGroup').after(formPessoaFisica);
    ColocarMascaras();
});

$('#fisica').change(function () {
    $('#panelRadioGroup').after(formPessoaFisica);
    $('#formPessoaJuridica').remove();
    ColocarMascaras();
});

$('#juridica').change(function () {
    $('#panelRadioGroup').after(formPessoaJuridica);
    $('#formPessoaFisica').remove();
    ColocarMascaras();
});

function ColocarMascaras()
{
    $('[name="Cpf"]').mask('000.000.000-00', { reverse: true });
    $('[name="Cnpj"]').mask('00.000.000/0000-00', { reverse: true });
    $('[name="Rg"]').mask('00.000.000-0', { reverse: true });
    $('[name="CEP"]').mask('00000-000');
}