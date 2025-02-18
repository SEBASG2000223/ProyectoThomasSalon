$(document).ready(function () {

    $.ajax({
        url: '/Servicios/ObtenerServiciosParcial', 
        type: 'GET',
        success: function (response) {
         
            $("#contenido").html(response);

          
            setTimeout(function () {
              
                if (!$(".service-carousel").data('owlCarousel')) {
                    $(".service-carousel").owlCarousel({
                        autoplay: true,
                        smartSpeed: 1500,
                        loop: true,
                        dots: false,
                        nav: false,
                        responsive: {
                            0: {
                                items: 1
                            },
                            576: {
                                items: 2
                            },
                            768: {
                                items: 3
                            },
                            992: {
                                items: 4
                            },
                            1200: {
                                items: 5
                            }
                        }
                    });
                }
            }, 500);
        },
        error: function (xhr, status, error) {
            alert("Hubo un error al cargar el contenido.");
            console.error("Error AJAX:", error);
        }
    });
});
