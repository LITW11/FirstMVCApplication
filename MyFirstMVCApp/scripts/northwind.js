$(() => {
    $(".btn-danger").on('click', function () {
        const button = $(this);
        button.closest('tr').toggleClass('table-danger');
    });
});