﻿function addCategory(inputId) {
	let name = document.getElementById(inputId).value;
	if (name) {
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
}

function addSubCategory(inputNameId, inputCategoryId) {
	let name = document.getElementById(inputNameId).value;
	let categoryId = document.getElementById(inputCategoryId).getAttribute('data-categoryId');
	if (name && categoryId) {
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
}

function addAttribute(inputNameId) {
	let name = document.getElementById(inputNameId).value;
	if (name) {
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
}

function addPreset(presetNameId, attributesCount, subCategoriesCount) {
	let name = document.getElementById(presetNameId).value;

	let subCategoryId, radio;
	for (let i = 0; i < subCategoriesCount; i++) {
		radio = document.getElementById(`radio${i}`);
		if (radio.checked) {
			subCategoryId = radio.value;
			break;
		}
	}

	let checkedList = Array();
	let checkboxListItem;
	for (let i = 0; i < attributesCount; i++) {
		checkboxListItem = document.getElementById(`checkbox${i}`);
		if (checkboxListItem.checked) checkedList.push(checkboxListItem.value);
	}

	let checkedListJson = JSON.stringify(checkedList);

	if (subCategoryId && name && checkedListJson) {
		$.ajax({
			type: "POST",
			url: "Preset/Add",
			async: false,
			data: {
				'SubCategory.Id': subCategoryId,
				Name: name,
				CheckedListJson: checkedListJson
			},
			success: () => {
				document.location.reload();
			}
		})
    }	

	console.log(checkedList);
}

function addProductForm(presetsCount) {
	let presetId, radio;
	for (let i = 0; i < presetsCount; i++) {
		radio = document.getElementById(`radioPreset${i}`);
		if (radio.checked) {
			presetId = radio.value;
			break;
        }
    }

	if (presetId) {
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
}

class Attribute {
	constructor(attributeId, value) {
		this.AttributeId = attributeId;
		this.Value = value;
	}
}

function addProduct(inputNameId, attributesCount, discountsCount, presetId) {
	let price = document.getElementById("formInputPrice").value;

	let attributes = Array();
	let field;
	for (let i = 0; i < attributesCount; i++) {
		field = document.getElementById(`formInput${i}`);
		attributes.push(new Attribute(field.getAttribute('data-attributeId'), field.value));
	}

	let discount;
	let discountId;
	for (let i = 0; i < discountsCount; i++) {
		discount = document.getElementById(`radioDiscount${i}`);
		if (discount.checked) {
			discountId = discount.value;
        }
	}

	let name = document.getElementById(inputNameId).value;

	let attributesJson = JSON.stringify(attributes);

	if (attributesJson && price && presetId && discountId && name) {
		$.ajax({
			type: "POST",
			url: "Product/Add",
			async: false,
			data: {
				'Product.Name': name,
				Attributes: attributesJson,
				Price: price,
				'Preset.Id': presetId,
				'Discount.Id': discountId
			},
			success: () => {
				document.location.reload();
			}
		})
    }	
}

function addUser(inputName, inputPassword) {
	let name = document.getElementById(inputName).value;
	let password = document.getElementById(inputPassword).value;

	if (name && password) {
		$.ajax({
			type: "POST",
			url: "User/Add",
			async: false,
			data: {
				'User.Name': name,
				'User.Password': password
			},
			success: () => {
				document.location.reload();
			}
		})
    }	
}

function addDiscount(inputName, inputValue) {
	let name = document.getElementById(inputName).value;
	let value = document.getElementById(inputValue).value;

	if (name && value) {
		$.ajax({
			type: "POST",
			url: "Discount/Add",
			async: false,
			data: {
				'Discount.Name': name,
				'value': value
			},
			success: () => {
				document.location.reload();
			}
		})
    }
}