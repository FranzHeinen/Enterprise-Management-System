document.getElementById('nuevaCompraForm').addEventListener('submit', function (event) {
    event.preventDefault();

    const productoCodigo = document.getElementById('productoCodigo').value;
    const clienteDni = document.getElementById('clienteDni').value;
    const cantidad = parseInt(document.getElementById('cantidad').value, 10);
    const fechaEntrega = document.getElementById('fechaEntrega').value;


    const datosCompra = {
        CodigoProducto: productoCodigo,
        DniCliente: clienteDni,
        CantidadComprada: cantidad,
        FechaEntrega: fechaEntrega,
    };

    fetch('http://localhost:5125/api/Compra', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(datosCompra)
    })
        .then(response => response.json())
        .then(data => {
            console.log('Respuesta de la API:', data);
            if (data.success) {
                alert('Registro exitoso');
            } else {
                alert('Hubo un error al procesar el registro: ' + data.mensaje);
            }
        })
        .catch(error => {
            console.error('Error al enviar los datos:', error);
            alert('Hubo un error al procesar el registro');
        });
});