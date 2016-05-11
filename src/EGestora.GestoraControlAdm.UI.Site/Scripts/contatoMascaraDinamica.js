
var SPMaskBehavior = function (val) {
    return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
},
        spOptions = {
            onKeyPress: function (val, e, field, options) {
                field.mask(SPMaskBehavior.apply({}, arguments), options);
            }
        };

colocarMascara();
$('#TipoContatoId').change(function () {
    colocarMascara();
});

function colocarMascara() {
    var mascara = $("#TipoContatoId option:selected").attr('mascara');
    var text = $("#TipoContatoId option:selected").text();
    if (text.indexOf("Celular") >= 0) {
        $('#InformacaoContato').mask(SPMaskBehavior, spOptions);
    }
    else {
        $('#InformacaoContato').mask(mascara);
    }
}