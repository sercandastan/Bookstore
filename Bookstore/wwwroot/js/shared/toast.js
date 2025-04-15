window.addEventListener("load", function () {
    const toastEl = document.getElementById("toast-container");
    if (toastEl) {
        const toast = new bootstrap.Toast(toastEl, { delay: 4000 });
        toast.show();
    }
});
