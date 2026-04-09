document.getElementById('actualizarStockForm').addEventListener('submit', function (event) {
    event.preventDefault();

    const id = document.getElementById('productoId').value;
    const cantidad = parseInt(document.getElementById('cantidad').value, 10);

    fetch(`http://localhost:5125/api/Producto/${id}/${cantidad}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ cantidad })
    })
        .then(response => {
            if (response.ok) {
                return response.text();
            } else {
                throw new Error('Error al actualizar el stock');
            }
        })
        .then(data => {
            console.log('Respuesta de la API:', data);
            alert('Stock actualizado exitosamente');
        })
        .catch(error => {
            console.error('Error:', error);
            alert('No se pudo actualizar el stock del producto');
        });
});