﻿function SetCheck(elementId) {
    let element = document.getElementsByName(elementId);
    element[0].checked = true;
}
function AddClass(elementId, className) {

    let element = document.getElementById(elementId);
    element.classList.add(className);
}
function RemoveClass(elementId, className) {

    let element = document.getElementById(elementId);
    element.classList.remove(className);
}

function RefreshMenuItemsDragStatus() {

    let menuItems = document.querySelectorAll(".menu-item");

    menuItems.forEach(u => {
        u.classList.remove("can-drop");
        u.classList.remove("no-drop");
    });

} 