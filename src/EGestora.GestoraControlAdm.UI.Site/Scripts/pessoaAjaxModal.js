
$(function () {
    $.ajaxSetup({ cache: false });

    $(document).on('click', 'a[data-modal]', function (e) {
        var modalTarget = this.id;
        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                /*backdrop: 'static',*/
                keyboard: true
            }, 'show');
            
            if (modalTarget == "enderecoListAddLink"){
                Endereco();
            }
            if (modalTarget == "contatoListAddLink") {
                Contato();
            }

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
                        $('#spanEnderecoPrincipal').html(result.principal);
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

function Endereco()
{
    $('#CEP').mask('99999-999');
}

function Contato()
{
    maskContato();
    $('#TipoContatoId').change(function () {
        maskContato(this);
    });
}
function maskContato(select) {
    $('#checkboxEmailModal').hide();

    $('#InformacaoContato').removeAttr("type");
    $('#InformacaoContato').unmask();
    $('#InformacaoContato').val("");
    if ($("option:selected", select).html().toLowerCase().indexOf("mail") >= 0) {
        $('#checkboxEmailModal').show();
    }
    else {
        var mask = $("#TipoContatoId option:selected").attr('mascara');
        $('#InformacaoContato').mask(mask);
    }
}