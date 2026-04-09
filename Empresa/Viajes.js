document.getElementById('asignarViajeForm').addEventListener('submit', function (event) {
    event.preventDefault();

    const fechaDesde = document.getElementById('fechaDesde').value;
    const fechaHasta = document.getElementById('fechaHasta').value;

    const datosViaje = {
        FechaDesde: new Date(fechaDesde).toISOString(),
        FechaHasta: new Date(fechaHasta).toISOString()
    };

    fetch('http://localhost:5125/api/Viaje', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(datosViaje)
    })
        .then(response => response.json())
        .then(data => {
            console.log('Respuesta de la API:', data);
            alert('Registro exitoso');
        })
        .catch(error => {
            console.error('Error al enviar los datos:', error);
            alert('Hubo un error al procesar el registro');
        });
});