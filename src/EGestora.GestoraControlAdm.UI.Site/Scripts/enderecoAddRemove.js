var newEnderecoInput;
var countEndereco = 1;
$(document).ready(function () {
    newEnderecoInput = "<fieldset name='endereco'>" + $('fieldset[name="endereco"]').clone().html() + "</fieldset>";
});

function adicionarEndereco() {
    $('fieldset[name="endereco"]').last().after(newEnderecoInput);
    $('fieldset[name="endereco"]').last().find("h4").text("Endereço " + (countEndereco + 1));
    $('fieldset[name="endereco"]')
        .last()
        .find('input:checkbox, input:text, input:password, input:file, select, textarea')
        .each(function () {
            var attrName = $(this).attr('name');
            var attrNameReplaced = attrName.replace("[0]", "[" + countEndereco + "]");
            $(this).attr('name', attrNameReplaced);
        });
    countEndereco++;
}

function removerEndereco() {
    if ($('fieldset[name="endereco"]').length > 1) {
        countEndereco--;
        $('fieldset[name="endereco"]').last().remove();
    }
}