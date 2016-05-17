
$(function () {
    $.ajaxSetup({ cache: false });

    $(document).on('click', 'a[data-modal]', function (e) {
        
        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                /*backdrop: 'static',*/
                keyboard: true
            }, 'show');
            MascaraContato();
            bindForm(this);
        });
        return false;

    });
});

function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: new FormData(this),
            processData: false,
            contentType: false,
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    if (result.replaceTarget == "cnae") {
                        $('#replacetargetCnae').load(result.url);
                    } else if (result.replaceTarget == "servico") {
                        $('#replacetargetServico').load(result.url);
                    } else if (result.replaceTarget == "funcionario") {
                        $('#replacetargetFuncionarios').load(result.url);
                    } else if (result.replaceTarget == "revenda") {
                        $('#replacetargetRevenda').load(result.url);
                    } else if (result.replaceTarget == "anexo") {
                        $('#replacetargetAnexo').load(result.url);
                    } else if (result.replaceTarget == "contato") {
                        $('#replacetargetContato').load(result.url);
                    } else if (result.replaceTarget == "debito") {
                        $('#replacetargetDebito').load(result.url);
                    } else if (result.replaceTarget == "imagem") {
                        $('#imagemCliente').attr('src', result.url);
                    } else if (result.replaceTarget == "proprietario") {
                        $('#replacetargetProprietarios').load(result.url);
                    } else {
                        $('#replacetarget').load(result.url); // Carrega o resultado HTML para a div demarcada
                    }
                } else {
                    $('#myModalContent').html(result);
                    bindForm(dialog);
                }
            }
        });
        return false;
    });
}

function MascaraContato()
{
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
}


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