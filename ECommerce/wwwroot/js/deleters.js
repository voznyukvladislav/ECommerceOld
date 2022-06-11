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

function deleteUser(inputId) {
	let id = document.getElementById(inputId).value;

	$.ajax({
		type: "DELETE",
		url: "User/Delete",
		async: false,
		data: {
			Id: id
		},
		success: () => {
			document.location.reload();
		}
	})
}

function deleteDiscount(inputId) {
	let id = document.getElementById(inputId).value;

	$.ajax({
		type: "DELETE",
		url: "Discount/Delete",
		async: false,
		data: {
			Id: id
		},
		success: () => {
			document.location.reload();
		}
	})
}

function deleteOrder(orderId) {
	$.ajax({
		type: "DELETE",
		url: "Order/Delete",
		async: false,
		data: {
			'Order.Id': orderId
		},
		success: () => {
			document.location.reload();
		}
	})
}