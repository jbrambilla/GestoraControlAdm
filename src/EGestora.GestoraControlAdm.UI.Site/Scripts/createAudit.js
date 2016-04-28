
setMultiSelect();

$("#ControllerName").change(function () {
    if ($(this).val() != "") {
        listaActions($(this).val());
    }
});

$("form").submit(function (event) {
    if ($('#ControllerName').val() != "") {
        if (confirm('ATENÇÃO! Ao salvar um controller sem actions, você assumirá que todas as actions deste controller serão auditadas. Deseja continuar?')) {
            return;
        }
    }
    event.preventDefault();
});

function listaActions(controller) {
    $.getJSON('/Audit/LoadActions?controllerName=' + controller, listaActionsCallBack);
}

function listaActionsCallBack(json) {
    $('#ActionNameList').multiselect('destroy');
    $("#ActionNameList").empty();

    $(json).each(function () {
        $("#ActionNameList").append("<option value='" + this.Text + "'>" + this.Text + "</option>");
    });

    setMultiSelect();
}

function setMultiSelect() {
    $('#ActionNameList').multiselect({
        enableFiltering: true,
        enableClickableOptGroups: true,
        includeSelectAllOption: true,
        buttonWidth: '100%',
        nonSelectedText: 'Nenhuma ação selecionada',
        allSelectedText: 'Todas estão selecionadas',
        numberDisplayed: 5,
        selectAllText: 'Selecionar Todos',
        nSelectedText: "Ações Selecionadas"
    });
}