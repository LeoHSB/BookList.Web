(function($){
    // Função para atualizar a lista de bibliotecas
    function atualizarListaBibliotecas() {
        $.get('/Biblioteca/ConsultarBibliotecas', function(html) {
            $('#lista-bibliotecas').html(html); // atualiza apenas o container da lista
        });
    }

    $(document).ready(function(){
        // Intercepta o submit do formulário do modal
        $('#formCadastroBiblioteca').off('submit').on('submit', function(e){
            e.preventDefault();

            var form = $(this);
            var submitBtn = $('#btnSalvarBiblioteca');
            var spinner = submitBtn.find('.spinner-border');
            var mensagemDiv = $('#mensagemModal');

            submitBtn.prop('disabled', true);
            spinner.removeClass('d-none').addClass('d-block');
            mensagemDiv.hide();
            $('.text-danger').text('');

            $.ajax({
                url: form.attr('action'),
                type: 'POST',
                data: form.serialize(),
                dataType: 'json',
                success: function(response) {
                    if(response.success){
                        mensagemDiv.removeClass('alert-danger').addClass('alert-success').text(response.message).show();

                        setTimeout(function(){
                            $('#modalCadastroBiblioteca').modal('hide'); // fecha modal
                            form[0].reset(); // limpa formulário
                            mensagemDiv.hide();

                            // Atualiza a lista de bibliotecas via Ajax
                            atualizarListaBibliotecas();
                        }, 1200);
                    } else {
                        mensagemDiv.removeClass('alert-success').addClass('alert-danger').text(response.message).show();
                    }
                },
                error: function(xhr, status, error){
                    console.error('Erro AJAX:', error);
                    mensagemDiv.removeClass('alert-success').addClass('alert-danger').text('Erro ao cadastrar biblioteca.').show();
                },
                complete: function(){
                    submitBtn.prop('disabled', false);
                    spinner.removeClass('d-block').addClass('d-none');
                }
            });
        });

        // Limpa modal ao fechar
        $('#modalCadastroBiblioteca').on('hidden.bs.modal', function(){
            $('#formCadastroBiblioteca')[0].reset();
            $('#mensagemModal').hide();
            $('.text-danger').text('');
        });
    });

    // Expõe a função globalmente caso queira chamar de outros lugares
    window.atualizarListaBibliotecas = atualizarListaBibliotecas;

})(jQuery);