$(function () {
    $('#registerModal form').submit(function (e) {
        e.preventDefault();
        var form = $(this);
        $.ajax({
            url: form.attr('action'),
            type: 'POST',
            data: form.serialize(),
            success: function (response) {
                if (response.success) {
                    $('#registerModal').modal('hide');
                    location.reload();
                } else {
                    $('#registerModalContent').html(response);
                }
            }
        });
    });
});