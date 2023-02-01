$(document).ready(() => {
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));

});

//model
msgModalMessage = (message, origin, callback) => {
    $('#modal-origin').html(origin);
    $('#modal-body').html(message);
    

    $('#btnModalCallback').click(() => callback());

    $('#msgModal').modal('show');
};

closeMsgModalMessage = () => {
    $('#msgModal').modal('hide');
};

//toast
liveToastMessage = (message, origin) => {
    $('#toast-origin').html(origin);
    $('#toast-body').html(message);
    $('#toast-time').html(new Date().toLocaleTimeString('pt-br', {
        hour12: false,
        hour: "numeric",
        minute: "numeric"
    }));
    
    const toastLiveMessages = $('#liveToast');
    const toast = new bootstrap.Toast(toastLiveMessages)
    toast.show()
};


