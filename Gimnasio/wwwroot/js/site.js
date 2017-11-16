
$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').focus()
});


    function enviar() {
        var url = '/Socios/Ingresos';
        var id = $('#dni').val();
        $.post(url, { dni: id });
        closeventana();
        $('#myModal2').modal('show');
};

function closeventana() {
    $("#myModal").slideUp("fast");
 };
