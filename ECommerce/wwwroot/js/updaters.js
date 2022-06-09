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

function updateAttribute(inputId, inputName) {
	let id = document.getElementById(inputId).value;
	let name = document.getElementById(inputName).value;

	$.ajax({
		type: "POST",
		url: "Attribute/Update",
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

function updatePreset(presetInputId, presetNameId, attributesCount, i) {
	let id = document.getElementById(presetInputId).value;
	let name = document.getElementById(presetNameId).value;

	let checkedList = Array();
	let checkboxListItem;
	for (let j = 0; j < attributesCount; j++) {
		checkboxListItem = document.getElementById(`checkbox${i}${j}`);
		if (checkboxListItem.checked) checkedList.push(checkboxListItem.value);
	}

	let checkedListJson = JSON.stringify(checkedList);

	$.ajax({
		type: "POST",
		url: "Preset/Update",
		async: false,
		data: {
			Id: id,
			Name: name,
			CheckedListJson: checkedListJson
		},
		success: () => {
			document.location.reload();
		}
	})

	console.log(checkedList);
}