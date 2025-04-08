$(document).ready(function () {
    // Inicializar DataTable, si es necesario
    let table = new DataTable('#myTable');

    $(document).on("click", ".cancelar-cita", function (e) {
        e.preventDefault(); // Evita el comportamiento predeterminado del enlace

        let idCita = $(this).data("id"); // Obtener el ID de la cita
        console.log("ID Cita: " + idCita);  // Asegúrate de que el ID se está obteniendo correctamente

        // Mostrar SweetAlert dentro del modal
        Swal.fire({
            title: "¿Estás seguro?",
            text: "Esta acción cancelará la cita.",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
            confirmButtonText: "Sí, cancelar",
            cancelButtonText: "No",
            backdrop: false,  // Evita que se cierre el modal de Bootstrap
            target: '#modalDetallesCitaBody' // Establece el modal como contexto
        }).then((result) => {
            if (result.isConfirmed) {
                console.log("Confirmado cancelación de cita");
                // Enviar la petición AJAX para cancelar la cita
                $.ajax({
                    url: "/Citas/Cancelar/" + idCita,
                    type: "POST",
                    success: function (response) {
                        console.log("Cita cancelada con éxito");
                        Swal.fire({
                            title: "¡Cancelado!",
                            text: "La cita ha sido cancelada correctamente.",
                            icon: "success",
                            target: '#modalDetallesCitaBody' // Asegura que se muestre en el modal
                        }).then(() => {
                            // Cerrar el modal y refrescar la página o actualizar la tabla
                            $('#modalDetallesCita').modal('hide');
                            location.reload();
                        });
                    },
                    error: function () {
                        Swal.fire({
                            title: "Error",
                            text: "No se pudo cancelar la cita. Intenta nuevamente.",
                            icon: "error",
                            target: '#modalDetallesCitaBody' // Se muestra dentro del modal
                        });
                    }
                });
            }
        });
    });
});
