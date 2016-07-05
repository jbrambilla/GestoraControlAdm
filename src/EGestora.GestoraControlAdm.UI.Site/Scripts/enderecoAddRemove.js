var newEnderecoInput;
var countEndereco = 1;
$(document).ready(function () {
    $('input[name="EnderecoList[0].Cep"').mask('99999-999');
    newEnderecoInput = "<fieldset name='endereco'>" + $('fieldset[name="endereco"]').clone().html() + "</fieldset>";
});

function adicionarEndereco() {
    $('fieldset[name="endereco"]').last().after(newEnderecoInput);
    $('fieldset[name="endereco"]').last().find("h4").text("Endereço " + (countEndereco + 1));
    $('fieldset[name="endereco"]')
        .last()
        .find('input:checkbox, input:text, input:password, input:file, input:hidden, select, textarea')
        .each(function () {
            var newCepEvent = 'LoadAddress(this, ' + countEndereco + ')';
            var attrName = $(this).attr('name');
            var attrNameReplaced = attrName.replace("[0]", "[" + countEndereco + "]");
            $(this).attr('name', attrNameReplaced);
            if (attrNameReplaced.indexOf("Cep") >= 0){
                $(this).mask('99999-999');
                $(this).attr('onkeyup', newCepEvent);
            }
        });
    countEndereco++;
}

function removerEndereco() {
    if ($('fieldset[name="endereco"]').length > 1) {
        countEndereco--;
        $('fieldset[name="endereco"]').last().remove();
    }
}

function LoadAddress(cepInput, enderecoIndex)
{
    var cep = cepInput.value.replace(/_/g, '').replace('-', '');

    if (cep.length == 8) {
        $.ajax({
            dataType: 'json',
            url: '/Pessoas/ObterEnderecoPeloCep',
            type: "GET",
            data: { cep: cep },
            cache: false,
            success: function (result) {
                if (result.success) {
                    var endereco = result.address;
                    var cidadeInputName = 'input[name="EnderecoList[' + enderecoIndex + '].Cidade"';
                    var estadoInputName = 'input[name="EnderecoList[' + enderecoIndex + '].Estado"';
                    var bairroInputName = 'input[name="EnderecoList[' + enderecoIndex + '].Bairro"';
                    var logradoutoInputName = 'input[name="EnderecoList[' + enderecoIndex + '].Logradouro"';
                    var complementoInputName = 'input[name="EnderecoList[' + enderecoIndex + '].Complemento"';
                    var ibgeInputName = 'input[name="EnderecoList[' + enderecoIndex + '].Ibge"';
                    $(cidadeInputName).val(endereco.Cidade);
                    $(estadoInputName).val(endereco.Estado);
                    $(bairroInputName).val(endereco.Bairro);
                    $(logradoutoInputName).val(endereco.Logradouro);
                    $(complementoInputName).val(endereco.Complemento);
                    $(ibgeInputName).val(endereco.Ibge);
                } else {
                    alert(result.message);
                }
            }
        });
    }
}