document.addEventListener("DOMContentLoaded", function () {

    obtenerProductosBajoStock();
});

function obtenerProductosBajoStock() {

    fetch('http://localhost:5125/api/Producto')
        .then(response => response.json())
        .then(data => {
            var tablaProductos = document.getElementById("tablaProductosBajoStock");
            data.forEach(producto => {
                var fila = document.createElement("tr");
                fila.innerHTML = `
                    <td>${producto.codigoUnico}</td>
                    <td>${producto.nombre}</td>
                    <td>${producto.marca}</td>
                    <td>${producto.stockMinimo}</td>
                    <td>${producto.cantidadStock}</td>
                `;
                tablaProductos.appendChild(fila);
            });
        })
        .catch(error => {
            console.error('Error al obtener datos:', error);
            alert('No se pudo cargar la lista de productos con stock bajo');
        });
}
