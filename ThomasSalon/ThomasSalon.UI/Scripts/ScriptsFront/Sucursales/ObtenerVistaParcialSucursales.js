$(document).ready(function () {

    $.ajax({
        url: '/Sucursales/ObtenerSucursalesParcial',
        type: 'GET',
        success: function (response) {

            $("#contenidoSucursales").html(response);


            setTimeout(function () {
                if (!$('.branch-carousel').data('owlCarousel')) {
                    $('.branch-carousel').owlCarousel({
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
            alert("Hubo un error al cargar las sucursales.");
            console.error("Error AJAX:", error);
        }
    });

});
