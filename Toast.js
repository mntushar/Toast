﻿const toastDetails = {
    timer: 5000,
    success: {
        icon: "fa-circle-check",
    },
    error: {
        icon: "fa-circle-xmark",
    },
    warning: {
        icon: "fa-triangle-exclamation",
    },
    info: {
        icon: "fa-circle-info",
    },
    random: {
        icon: "fa-solid fa-star",
    },
}

const removeToast = (toast) => {
    toast.classList.add("hide")
    if (toast.timeoutId) clearTimeout(toast.timeoutId)
    setTimeout(() => toast.remove(), 500)
}

const createToast = (toastType, text) => {
    const toastSection = document.querySelector(".toastSection");

    if (toastSection) {
        const { icon } = toastDetails[toastType]
        const toast = document.createElement("li")
        toast.className = `myToast ${toastType}`
        toast.innerHTML = `<div class="column">
                         <i class="fa-solid ${icon}"></i>
                         <span>${text}</span>
                      </div>
                      <i class="fa-solid fa-xmark" onclick="removeToast(this.parentElement)"></i>`
        toastSection.appendChild(toast)
        toast.timeoutId = setTimeout(() => removeToast(toast), toastDetails.timer)
    }
}

function ShowToast(toastType, text) {
    createToast(toastType, text);
}