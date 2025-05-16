$(function () {
    $('#registerForm').submit(function (e) {
        e.preventDefault();

        var form = $(this);
        $.ajax({
            url: form.attr('action'),
            method: 'POST',
            data: form.serialize(),
            success: function (data, status, xhr) {
                var contentType = xhr.getResponseHeader("content-type") || "";

                if (contentType.indexOf("application/json") !== -1) {
                    // JSON döndüyse → başarılı kayıt
                    if (data.success) {
                        window.location.href = data.redirectUrl;
                    }
                } else {
                    // HTML döndüyse → kayıt başarısız, hatalarla modalı güncelle
                    $('#registerModal .modal-content').html(data);
                }
            }
        });
    });
});
