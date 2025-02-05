$(document).ready(function () {
    let table = new DataTable('#myTable');

    $("#llamarAMiAlerta").on("click", function () {
        Swal.fire("SweetAlert2 is working!", "Hola mundo!", "success");
    });
});