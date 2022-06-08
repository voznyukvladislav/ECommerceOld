class Attribute {
    constructor(name, value) {
        this.name = name;
        this.value = value;
    }
}

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