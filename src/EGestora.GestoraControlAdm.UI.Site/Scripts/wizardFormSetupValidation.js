var $validator = $("#wizard-1").validate({

    rules: {
        "PessoaFisica.Nome": {
            required: true
        },
        "PessoaFisica.Apelido": {
            required: true
        },
        "PessoaFisica.Rg": {
            required: true
        },
        "PessoaFisica.OrgaoEmissor": {
            required: true
        },
        "PessoaFisica.Cpf": {
            required: true,
            minlength: 4
        },
        "PessoaFisica.Nascimento": {
            required: true,
            date: "invalid format"
        },
        "PessoaFisica.ProfissaoId": {
            required: true
        },
        "PessoaFisica.EstadoCivil": {
            required: true
        },
        "PessoaFisica.Genero": {
            required: true
        },
        "PessoaJuridica.RazaoSocial": {
            required: true
        },
        "PessoaJuridica.NomeFantasia": {
            required: true
        },
        "PessoaJuridica.Cnpj": {
            required: true
        },
        "PessoaJuridica.InscricaoMunicipal": {
            required: true
        },
        "PessoaJuridica.InscricaoEstadual": {
            required: true
        },
        "PessoaJuridica.DataFundacao": {
            required: true,
            date: "formato de data inválido"
        },
        "PessoaJuridica.DataAniversario": {
            required: true,
            date: "formato de data inválido"
        },
        "PessoaJuridica.CnaeId": {
            required: true
        }
    },

    messages: {
        //PF
        "PessoaFisica.Nome": "Campo obrigatório.",
        "PessoaFisica.Apelido": "Campo obrigatório.",
        "PessoaFisica.Rg": "Campo obrigatório.",
        "PessoaFisica.OrgaoEmissor": "Campo obrigatório.",
        "PessoaFisica.Cpf": "Campo obrigatório.",
        "PessoaFisica.Nascimento": "Campo obrigatório.",
        "PessoaFisica.ProfissaoId": "Campo obrigatório.",
        "PessoaFisica.Genero": "Campo obrigatório.",
        "PessoaFisica.EstadoCivil": "Campo obrigatório.",

        //PJ
        "PessoaJuridica.RazaoSocial": "Campo obrigatório.",
        "PessoaJuridica.NomeFantasia": "Campo obrigatório.",
        "PessoaJuridica.Cnpj": "Campo obrigatório.",
        "PessoaJuridica.InscricaoMunicipal": "Campo obrigatório.",
        "PessoaJuridica.InscricaoEstadual": "Campo obrigatório.",
        "PessoaJuridica.DataFundacao": "Campo obrigatório.",
        "PessoaJuridica.DataAniversario": "Campo obrigatório.",
        "PessoaJuridica.CnaeId": "Campo obrigatório."
    },

    highlight: function (element) {
        $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
    },
    errorElement: 'span',
    errorClass: 'help-block',
    errorPlacement: function (error, element) {
        if (element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    }
});

$('#bootstrap-wizard-1').bootstrapWizard({
    'tabClass': 'form-wizard',
    'onNext': function (tab, navigation, index) {
        var $valid = $("#wizard-1").valid();
        if (!$valid) {
            $validator.focusInvalid();
            return false;
        } else {
            $('#bootstrap-wizard-1').find('.form-wizard').children('li').eq(index - 1).addClass(
              'complete');
            $('#bootstrap-wizard-1').find('.form-wizard').children('li').eq(index - 1).find('.step')
            .html('<i class="fa fa-check"></i>');
        }
    }
});