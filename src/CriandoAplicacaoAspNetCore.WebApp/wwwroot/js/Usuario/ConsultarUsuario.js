(function () {
    'use strict';
    
    $(document).ready(function () {
        $('a.btn-delete').click(function () {
            var title = $(this).data('title');
            var message = $(this).data('message');
            var href = $(this).attr('href');

            bootbox.dialog({
                title: title,
                message: message,
                size: 'large',
                buttons: {
                    cancel: {
                        label: "Não",
                        className: 'btn-light',
                        callback: function () {
                            // cancelado
                        }
                    },
                    ok: {
                        label: "Sim",
                        className: 'btn-primary',
                        callback: function () {
                            $.get(href, function (result) {
                                if (result.sucesso)
                                    bootbox.alert('Registro excluido com sucesso!', function () {
                                        window.location.href = result.url;
                                    });
                                else
                                    bootbox.alert('Não foi possível excluir o registro.');
                            });
                        }
                    }
                }
            });
            return false;
        });

    });
})();