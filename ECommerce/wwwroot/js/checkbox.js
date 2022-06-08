function check(checkboxId) {
    let checkbox = document.getElementById(checkboxId);
    let isChecked = checkbox.checked;

    if (isChecked) {
        checkbox.checked = false;
    } else {
        checkbox.checked = true;
    }
}