function deleteCategory(inputId) {
    let id = document.getElementById(inputId).value;

	$.ajax({
		type: "DELETE",
		url: "Category/Delete",
		async: false,
		data: {
			Id: id
		},
		success: () => {
			document.location.reload();
		}
	})
}

function deleteSubCategory(inputId) {
	let id = document.getElementById(inputId).value;

	$.ajax({
		type: "DELETE",
		url: "SubCategory/Delete",
		async: false,
		data: {
			Id: id
		},
		success: () => {
			document.location.reload();
		}
	})
}

function deleteAttribute(inputId) {
	let id = document.getElementById(inputId).value;

	$.ajax({
		type: "DELETE",
		url: "Attribute/Delete",
		async: false,
		data: {
			Id: id
		},
		success: () => {
			document.location.reload();
		}
	})
}

function deletePreset(inputId) {
	let id = document.getElementById(inputId).value;

	$.ajax({
		type: "DELETE",
		url: "Preset/Delete",
		async: false,
		data: {
			Id: id
		},
		success: () => {
			document.location.reload();
		}
	})
}

function deleteProduct(inputId) {
	let id = document.getElementById(inputId).value;

	$.ajax({
		type: "DELETE",
		url: "Product/Delete",
		async: false,
		data: {
			Id: id
		},
		success: () => {
			document.location.reload();
		}
	})
}