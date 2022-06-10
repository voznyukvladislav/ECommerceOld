function addCategory(inputId) {
	let name = document.getElementById(inputId).value;
	$.ajax({
		type: "POST",
		url: "Category/Add",
		async: false,
		data: {
			Name: name
		},
		success: () => {
			document.location.reload();
		}
	})
}

function addSubCategory(inputNameId, inputCategoryId) {
	let name = document.getElementById(inputNameId).value;
	let categoryId = document.getElementById(inputCategoryId).getAttribute('data-categoryId');

	$.ajax({
		type: "POST",
		url: "SubCategory/Add",
		async: false,
		data: {
			Name: name,
			'Category.Id': categoryId
		},
		success: () => {
			document.location.reload();
		}
	})
}

function addAttribute(inputNameId) {
	let name = document.getElementById(inputNameId).value;

	$.ajax({
		type: "POST",
		url: "Attribute/Add",
		async: false,
		data: {
			Name: name
		},
		success: () => {
			document.location.reload();
		}
	})
}

function addPreset(presetNameId, attributesCount) {
	let name = document.getElementById(presetNameId).value;

	let checkedList = Array();
	let checkboxListItem;
	for (let i = 0; i < attributesCount; i++) {
		checkboxListItem = document.getElementById(`checkbox${i}`);
		if (checkboxListItem.checked) checkedList.push(checkboxListItem.value);
	}

	let checkedListJson = JSON.stringify(checkedList);

	$.ajax({
		type: "POST",
		url: "Preset/Add",
		async: false,
		data: {
			Name: name,
			CheckedListJson: checkedListJson
		},
		success: () => {
			document.location.reload();
		}
	})

	console.log(checkedList);
}

function addProductForm(presetsCount) {
	let presetId, radio;
	for (let i = 0; i < presetsCount; i++) {
		radio = document.getElementById(`radio${i}`);
		if (radio.checked) {
			presetId = radio.value;
			break;
        }
    }

	$.ajax({
		type: "POST",
		url: "Product/AddForm",
		async: false,
		data: {
			'Preset.Id': presetId
		},
		success: function (data, status, xhr) {
			document.body.innerHTML = data;
		}
	})
}

class Attribute {
	constructor(attributeId, value) {
		this.AttributeId = attributeId;
		this.Value = value;
	}
}

function addProduct(attributesCount, presetId) {
	let price = document.getElementById("formInputPrice").value;

	let attributes = Array();
	let field;
	for (let i = 0; i < attributesCount; i++) {
		field = document.getElementById(`formInput${i}`);
		attributes.push(new Attribute(field.getAttribute('data-attributeId'), field.value));
	}

	let attributesJson = JSON.stringify(attributes);
	$.ajax({
		type: "POST",
		url: "Product/Add",
		async: false,
		data: {
			Attributes: attributesJson,
			Price: price,
			'Preset.Id': presetId
		},
		success: () => {
			document.location.reload();
		}
	})
}