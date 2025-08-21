$(document).ready(function () {

    // Abrir modal via GET (botão principal ou dropdown)
    $(document).on("click", "#btnAbrirCadastroChave, #btnAbrirCadastroChaveDropdown", function (e) {
        e.preventDefault();
        $.ajax({
            url: urlGetCadastroChave,
            type: 'GET',
            success: function (data) {
                $("#containerModalChave").html(data);
                $("#modalCadastroChave").modal('show');
            },
            error: function () {
                alert("Erro ao carregar a tela de cadastro de chave.");
            }
        });
    });

    // Submeter formulário via AJAX POST
    $(document).on("submit", "#formCadastroChave", function (e) {
        e.preventDefault();

        var apiKey = $("#ApiKey").val();

        // Validação simples: campo vazio
        if (!apiKey || apiKey.trim() === "") {
            $("#erroApiKey").text("A chave API não pode ficar vazia.");
            return;
        } else {
            $("#erroApiKey").text("");
        }

        $.ajax({
            url: urlPostCadastroChave,
            type: 'POST',
            data: { ApiKey: apiKey },
            success: function (resultado) {
                if (resultado.sucesso) {
                    $("#mensagemCadastro").removeClass("alert-danger").addClass("alert-success")
                        .text(resultado.mensagem).show();

                    // Fecha modal após 1 segundo
                    setTimeout(function () {
                        $("#modalCadastroChave").modal('hide');
                    }, 1000);
                } else {
                    $("#mensagemCadastro").removeClass("alert-success").addClass("alert-danger")
                        .text(resultado.mensagem).show();
                }
            },
            error: function () {
                $("#mensagemCadastro").removeClass("alert-success").addClass("alert-danger")
                    .text("Erro inesperado.").show();
            }
        });
    });

    // Fechar modal ao clicar em Cancelar
    $(document).on("click", "#btnCancelarCadastro", function () {
        $("#modalCadastroChave").modal('hide');
    });
});