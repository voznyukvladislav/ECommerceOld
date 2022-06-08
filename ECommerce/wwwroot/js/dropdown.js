﻿function showList(dropdownId, buttonId) {
    let dropdown = document.getElementById(dropdownId).classList.toggle("show");
    let button = document.getElementById(buttonId).classList.toggle("dropdownButtonSelected");
}

function selectItem(
        dropdownId,
        buttonId,
        inputFieldId,
        attributeName,
        attributeValue,
        textValue) {
    let inputField = document.getElementById(inputFieldId);
    inputField.setAttribute(attributeName, attributeValue);
    inputField.value = textValue;
    showList(dropdownId, buttonId);
}