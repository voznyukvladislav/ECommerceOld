class Attribute {
    constructor(name, value) {
        this.name = name;
        this.value = value;
    }
}

function addProduct(tableName, attributes) {

}

function addCategory(inputId, url) {
	let name = 
	$.ajax({
		type: "POST",
		url: url,
		async: false,
		data: {
			Category.Name: name
		},
		success: () => {
			document.location.reload();
		}
	})
}