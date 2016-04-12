$('#IssRetido').change(function () {

    $('#OutrasInformacoes').val("");
    $('#ValorLiquido').val($('#ValorTotal').val() - $('#ValorISS').val());

    if (this.checked) {
        $('#OutrasInformacoes').val("ISS retido na fonte com base na LEI COMPLEMENTAR 199/2015.");
        $('#ValorLiquido').val($('#ValorTotal').val());
    }

});

$('#ClienteId').change(function () {
    var id = $('option:selected', this).attr('value');
    PreencherValoresNotaPeloCliente(id);
});

function PreencherValoresNotaPeloCliente(id) {
    $.getJSON('/NotaServicos/ObterValoresPorCliente/' + id, PreencherValoresNotaPeloClienteCallBack);
}

function PreencherValoresNotaPeloClienteCallBack(json) {
    var valorTotal = json.valorTotal;
    var aliquota = $('#Aliquota').val();
    var baseCalculo = valorTotal;
    var valorISS = baseCalculo * (aliquota / 100);
    var valorLiquido = $('#IssRetido').is(':checked') ? valorTotal : valorTotal - valorISS;

    $('#ValorTotal').val(valorTotal);
    $('#ValorDeducoes').val(0);
    $('#BaseCalculo').val(baseCalculo);
    $('#ValorISS').val(valorISS);
    $('#ValorLiquido').val(valorLiquido);

    $('#discriminacao').val(json.discriminacaoServicos);
}