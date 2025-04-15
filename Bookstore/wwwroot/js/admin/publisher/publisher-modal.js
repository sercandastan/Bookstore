$(document).ready(function () {
    $('#publisherModalForm').submit(function (e) {
        e.preventDefault(); 

        $.ajax({
            url: '/AdminPanel/Publisher/CreateAjax',
            type: 'POST',
            data: $(this).serialize(),
            success: function (response) {
                if (response.success) {
                    const newOption = new Option(response.name, response.id, true, true);
                    $('select[name="PublisherId"]').append(newOption).trigger('change');

                    $('#addPublisherModal').modal('hide');
                    $('#publisherModalForm')[0].reset();
                }
            },
            error: function (xhr) {
                alert("Yayınevi eklenirken bir hata oluştu.");
            }
        });
    });
});
