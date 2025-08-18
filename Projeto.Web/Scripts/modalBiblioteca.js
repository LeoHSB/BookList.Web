$(document).ready(function () {
    $('#formCadastroBiblioteca').on('submit', function (e) {
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
            success: function (response) {
                if (response.success) {
                    mensagemDiv.removeClass('alert-danger').addClass('alert-success').text(response.message).show();

                    setTimeout(function () {
                        $('#modalCadastroBiblioteca').modal('hide');
                        form[0].reset(); 
                        mensagemDiv.hide();
                        if (typeof atualizarListaBibliotecas === 'function') {
                            atualizarListaBibliotecas();
                        }
                    }, 1500);
                } else {
                    mensagemDiv.removeClass('alert-success').addClass('alert-danger').text(response.message).show();
                }
            },
            error: function (xhr, status, error) {
                console.error('Erro AJAX:', error);
                mensagemDiv.removeClass('alert-success').addClass('alert-danger').text('Erro ao cadastrar biblioteca. Tente novamente.').show();
            },
            complete: function () {
                submitBtn.prop('disabled', false);
                spinner.removeClass('d-block').addClass('d-none'); 
            }
        });
    });
    $('#modalCadastroBiblioteca').on('hidden.bs.modal', function () {
        $('#formCadastroBiblioteca')[0].reset();
        $('#mensagemModal').hide();
        $('.text-danger').text('');
    });
});