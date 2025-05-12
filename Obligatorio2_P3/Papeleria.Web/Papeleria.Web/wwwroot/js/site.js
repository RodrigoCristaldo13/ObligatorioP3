
function toggleForm() {
    var formPedido = document.getElementById('formPedido');
    var formArticulo = document.getElementById('formArticulo');
    var iconoBoton = document.createElement('img');

    var btn = document.getElementById('btnContinuar');
    if (formPedido.classList.contains('d-none')) {
        formPedido.classList.remove('d-none');
        formArticulo.classList.add('d-none');

        btn.textContent = "Agregar articulos";
        // Seteamos ruta de imagen
        iconoBoton.src = '../img/volver.svg';
        iconoBoton.classList = 'btn-close-white px-2';

        // Agregamos la imagen al botón
        btn.appendChild(iconoBoton);
    } else {
        formPedido.classList.add('d-none');
        formArticulo.classList.remove('d-none');

        btn.textContent = "Continuar";
        // Seteamos ruta de imagen
        iconoBoton.src = '../img/siguiente.svg'; 
        iconoBoton.classList = 'btn-close-white px-2';
        // Agregamos la imagen al botón
        btn.appendChild(iconoBoton);
    }
}
