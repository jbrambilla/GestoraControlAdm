var newContatoInput;
var checkboxesEmail;
var countContato = 1;
$(document).ready(function () {

    newContatoInput = "<fieldset name='contato'>" + $('fieldset[name="contato"]').clone().html() + "</fieldset>";
    emailCheckbox = "<div name='emailCheckbox[0]'>" + $('div[name="emailCheckbox[0]"]').clone().html() + "</div>"
    $('div[name="emailCheckbox[0]"]').remove();

    $("select[name='ContatoList[0].TipoContatoId']")
        .change(function () {
            
            $("input[name='ContatoList[0].InformacaoContato'").removeAttr("type");
            $("input[name='ContatoList[0].InformacaoContato'").unmask();
            $("input[name='ContatoList[0].InformacaoContato'").val("");

            if ($("option:selected", this).html().toLowerCase().indexOf("mail") >= 0) {
                /** mostrar checkbox **/
                $('div[name="infoContato[0]"]').after(emailCheckbox);
                $("input[name='ContatoList[0].InformacaoContato'").attr("type", "email")
                /** fim mostrar checkbox **/
            }

            else {
                /** colocar máscara **/
                $('div[name="emailCheckbox[0]"]').remove();
                var mask = $("option:selected", this).attr("mask");
                $("input[name='ContatoList[0].InformacaoContato'").mask(mask);
                /** fim colocar máscara **/
            }
        });
});

function adicionarContato() {
    $('fieldset[name="contato"]').last().after(newContatoInput);
    $('fieldset[name="contato"]').last().find("h4").text("Contato " + (countContato + 1));
    $('fieldset[name="contato"]')
        .last()
        .find('input:text, input:password, input:file, input:checkbox, select, textarea, div')
        .each(function () {
            if ($(this).attr('name') != null) {
                var attrName = $(this).attr('name');
                var attrNameReplaced = attrName.replace("[0]", "[" + countContato + "]");
                $(this).attr('name', attrNameReplaced);
            }
        });
    
   
    var selectName = "select[name='ContatoList[" + countContato + "].TipoContatoId'";
    var divEmailCheckBoxName = "div[name='emailCheckbox[" + countContato + "]'";
    $(divEmailCheckBoxName).remove();

    $(selectName)
        .change(function () {

            var mask = $("option:selected", this).attr("mask");
            var index = $(this).attr("name").substr(12, 1);
            var inputInformacaoContato = "input[name='ContatoList[" + index + "].InformacaoContato";
            var divEmailCheckBoxName = "div[name='emailCheckbox[" + index + "]'";
            var divInfoContatoName = "div[name='infoContato[" + index + "]'";
            var emailCheckboxAditional = emailCheckbox.replace(/[0]/g, index);//replace("[0]", "[" + index + "]").replace("[0]", "[" + index + "]").replace("[0]", "[" + index + "]");
            $(divEmailCheckBoxName).remove();
            $(inputInformacaoContato).unmask();
            $(inputInformacaoContato).val("");
            $(inputInformacaoContato).removeAttr("type", "email");

            if ($("option:selected", this).html().toLowerCase().indexOf("mail") >= 0)
            {
                $(divInfoContatoName).last().after(emailCheckboxAditional);
                $(inputInformacaoContato).attr("type", "email");
            }
            else
            {
                $(inputInformacaoContato).mask(mask);
            }
        });
    countContato++;
}

function removerContato() {
    if ($('fieldset[name="contato"]').length > 1) {
        countContato--;
        $('fieldset[name="contato"]').last().remove();
    }
}