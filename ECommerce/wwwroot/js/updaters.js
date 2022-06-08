function updateCategory(inputId, inputName) {
    let id = document.getElementById(inputId).value;
    let name = document.getElementById(inputName).value;

	$.ajax({
		type: "POST",
		url: "Category/Update",
		async: false,
		data: {
			Id: id,
			Name: name
		},
		success: () => {
			document.location.reload();
		}
	})
}

function updateSubCategory(inputSubCategoryId, inputSubCategoryName, inputCategoryId) {
	let id = document.getElementById(inputSubCategoryId).value;
	let name = document.getElementById(inputSubCategoryName).value;
	let categoryId = document.getElementById(inputCategoryId).getAttribute('data-categoryId');

	$.ajax({
		type: "POST",
		url: "SubCategory/Update",
		async: false,
		data: {
			Id: id,
			Name: name,
			'Category.Id': categoryId
		},
		success: () => {
			document.location.reload();
		}
	})
}