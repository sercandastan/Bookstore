$('#authorModalForm').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: '/AdminPanel/Author/CreateAjax',
        type: 'POST',
        data: $(this).serialize(),
        success: function (response) {
            if (response.success) {
                const newOption = new Option(response.name, response.id, true, true);
                $('select[name="AuthorIds"]').append(newOption).trigger('change');
                $('#addAuthorModal').modal('hide');
                $('#authorModalForm')[0].reset();
            }
        },
        error: function (xhr) {
            let response = xhr.responseJSON;
            if (response && response.errors) {
                alert("Hatalar:\n" + response.errors.join("\n"));
            } else {
                alert("Yazar eklenirken hata oluştu.");
            }
        }
    });
});
