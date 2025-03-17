var carritoVisible = false;

document.addEventListener('DOMContentLoaded', function () {
    cargarCarritoDesdeServidor();
    document.querySelectorAll('.boton-item').forEach(button => {
        button.addEventListener('click', agregarAlCarritoClicked);
    });
    document.querySelector('.btn-pagar').addEventListener('click', pagarClicked);
});

function agregarAlCarritoClicked(event) {
    var button = event.target;
    var item = button.closest('.item');
    var idProducto = item.dataset.id;
    var titulo = item.querySelector('.titulo-item').innerText;
    var precio = parseFloat(item.querySelector('.precio-item').innerText.replace('₡', ''));
    var imagenSrc = item.querySelector('.img-item').src;

    $.post('/Carrito/AgregarAlCarrito', { idProducto, cantidad: 1, precioUnitario: precio }, function () {
        cargarCarritoDesdeServidor();
        hacerVisibleCarrito();
    });
}

function cargarCarritoDesdeServidor() {
    $.get('/Carrito/ObtenerCarrito', function (data) {
        var carritoItems = document.querySelector('.carrito-items');
        carritoItems.innerHTML = '';
        data.forEach(item => {
            var itemHTML = `<div class="carrito-item" data-id="${item.IdProducto}">
                <img src="" width="80px" alt="">
                <div class="carrito-item-detalles">
                    <span class="carrito-item-titulo">${item.Nombre}</span>
                    <div class="selector-cantidad">
                        <i class="fa-solid fa-minus restar-cantidad"></i>
                        <input type="text" value="${item.Cantidad}" class="carrito-item-cantidad" disabled>
                        <i class="fa-solid fa-plus sumar-cantidad"></i>
                    </div>
                    <span class="carrito-item-precio">₡${item.PrecioUnitario}</span>
                </div>
                <button class="btn-eliminar"><i class="fa-solid fa-trash"></i></button>
            </div>`;
            carritoItems.insertAdjacentHTML('beforeend', itemHTML);
        });
        asignarEventosCarrito();
        actualizarTotalCarrito();
    });
}

function asignarEventosCarrito() {
    document.querySelectorAll('.btn-eliminar').forEach(button => {
        button.addEventListener('click', eliminarItemCarrito);
    });
    document.querySelectorAll('.sumar-cantidad').forEach(button => {
        button.addEventListener('click', sumarCantidad);
    });
    document.querySelectorAll('.restar-cantidad').forEach(button => {
        button.addEventListener('click', restarCantidad);
    });
}

function eliminarItemCarrito(event) {
    var item = event.target.closest('.carrito-item');
    var idProducto = item.dataset.id;
    $.post('/Carrito/EliminarDelCarrito', { idProducto }, function () {
        item.remove();
        actualizarTotalCarrito();
        ocultarCarrito();
    });
}

function actualizarCantidad(idProducto, cantidad) {
    $.post('/Carrito/ActualizarCantidad', { idProducto, cantidad }, function () {
        actualizarTotalCarrito();
    });
}

function sumarCantidad(event) {
    var selector = event.target.closest('.selector-cantidad');
    var input = selector.querySelector('.carrito-item-cantidad');
    var idProducto = event.target.closest('.carrito-item').dataset.id;
    input.value = parseInt(input.value) + 1;
    actualizarCantidad(idProducto, input.value);
}

function restarCantidad(event) {
    var selector = event.target.closest('.selector-cantidad');
    var input = selector.querySelector('.carrito-item-cantidad');
    var idProducto = event.target.closest('.carrito-item').dataset.id;
    if (parseInt(input.value) > 1) {
        input.value = parseInt(input.value) - 1;
        actualizarCantidad(idProducto, input.value);
    }
}

function actualizarTotalCarrito() {
    var total = 0;
    document.querySelectorAll('.carrito-item').forEach(item => {
        var precio = parseFloat(item.querySelector('.carrito-item-precio').innerText.replace('₡', ''));
        var cantidad = parseInt(item.querySelector('.carrito-item-cantidad').value);
        total += precio * cantidad;
    });
    document.querySelector('.carrito-precio-total').innerText = `₡${total.toLocaleString("es")},00`;
}

function pagarClicked() {
    alert("Gracias por tu compra");
    $.post('/Carrito/EliminarTodo', function () {
        cargarCarritoDesdeServidor();
        ocultarCarrito();
    });
}

function hacerVisibleCarrito() {
    document.querySelector('.carrito').classList.add('visible');
}

function ocultarCarrito() {
    if (document.querySelector('.carrito-items').childElementCount === 0) {
        document.querySelector('.carrito').classList.remove('visible');
    }
}
