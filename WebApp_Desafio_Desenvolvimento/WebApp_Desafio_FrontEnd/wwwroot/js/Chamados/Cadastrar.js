$(document).ready(function () {

    $('#btnCancelar').click(function () {
        Swal.fire({
            html: "Deseja cancelar essa operação? O registro não será salvo.",
            type: "warning",
            showCancelButton: true,
        }).then(function (result) {
            if (result.value) {
                history.back();
            } else {
                console.log("Cancelou a inclusão.");
            }
        });
    });

    $("#datepicker").datepicker({
        dateFormat: 'dd/mm/yy',
        closeText: "Fechar",
        prevText: "&#x3C;Anterior",
        nextText: "Próximo&#x3E;",
        currentText: "Hoje",
        monthNames: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
        monthNamesShort: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
        dayNames: ["Domingo", "Segunda-feira", "Terça-feira", "Quarta-feira", "Quinta-feira", "Sexta-feira", "Sábado"],
        dayNamesShort: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb"],
        dayNamesMin: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb"],
        weekHeader: "Sm",
        firstDay: 1
    });

    $(document).ready(function () {
        $.ajax({
            url: config.contextPath + "Chamados/ListarSolicitante",
            type: 'GET',
            contentType: 'application/json',

        }).done(function (data) {
            $("#autocomplete").autocomplete({
                source: eval(data)
            });

        });
    });

    $('#btnSalvar').click(function () {

        if ($('#form').valid() != true) {
            FormularioInvalidoAlert();
            return;
        }

        let chamado = SerielizeForm($('#form'));
        let url = $('#form').attr('action');
        debugger;

        $.ajax({
            type: "POST",
            url: url,
            data: chamado,
            success: function (result) {

                Swal.fire({
                    type: result.Type,
                    title: result.Title,
                    text: result.Message,
                }).then(function () {
                    window.location.href = config.contextPath + result.Controller + '/' + result.Action;
                });
            },
            error: function (result) {

                Swal.fire({
                    text: result,
                    confirmButtonText: 'OK',
                    icon: 'error'
                });
            },
        });
    });
});
