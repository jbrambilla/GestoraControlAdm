$(function () {
    $.ajaxSetup({ cache: false });

    $(document).on('click', 'a[data-modal]', function (e) {
        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                /*backdrop: 'static',*/
                keyboard: true
            }, 'show');
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
                        $('#replacetargetFuncionario').load(result.url);
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