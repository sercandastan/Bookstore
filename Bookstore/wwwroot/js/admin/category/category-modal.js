$(document).ready(function () {
	$('#categoryModalForm').submit(function (e) {
		e.preventDefault();

		$.ajax({
			url: '/AdminPanel/Category/CreateAjax',
			type: 'POST',
			data: $(this).serialize(),
			success: function (response) {
				const newOption = new Option(response.name, response.id, true, true);
				$('select[name="CategoryId"]').append(newOption).trigger('change');
				$('#addCategoryModal').modal('hide');
				$('#categoryModalForm')[0].reset();
			},
			error: function () {
				alert("Kategori eklenirken hata oluştu.");
			}
		});
	});
});
