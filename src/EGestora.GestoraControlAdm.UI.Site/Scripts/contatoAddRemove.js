var newContatoInput;
var countContato = 1;
$(document).ready(function () {
    newContatoInput = "<fieldset name='contato'>" + $('fieldset[name="contato"]').clone().html() + "</fieldset>";

    $("select[name='ContatoList[0].TipoContatoId']")
        .change(function () {
            var mask = $("option:selected", this).attr("mask");
            $("input[name='ContatoList[0].InformacaoContato").mask(mask);
        });
});

function adicionarContato() {
    $('fieldset[name="contato"]').last().after(newContatoInput);
    $('fieldset[name="contato"]').last().find("h4").text("Contato " + (countContato + 1));
    $('fieldset[name="contato"]')
        .last()
        .find('input:text, input:password, input:file, select, textarea')
        .each(function () {
            var attrName = $(this).attr('name');
            var attrNameReplaced = attrName.replace("[0]", "[" + countContato + "]");
            $(this).attr('name', attrNameReplaced);
        });
    
    var selectName = "select[name='ContatoList[" + countContato + "].TipoContatoId'";
    $(selectName)
        .change(function () {
            var mask = $("option:selected", this).attr("mask");
            var index = $(this).attr("name").substr(12,1);
            var inputInformacaoContato = "input[name='ContatoList[" + index + "].InformacaoContato";
            $(inputInformacaoContato).mask(mask);
        });
    countContato++;
}

function removerContato() {
    if ($('fieldset[name="contato"]').length > 1) {
        countContato--;
        $('fieldset[name="contato"]').last().remove();
    }
}