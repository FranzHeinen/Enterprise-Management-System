document.addEventListener("DOMContentLoaded", function (event) {
    console.info("Formulario de Registro de Clientes Listo");
});

document.getElementById('registroForm').addEventListener('submit', function (event) {
    event.preventDefault();

    const dni = document.getElementById('dni').value;
    const nombre = document.getElementById('nombre').value;
    const apellido = document.getElementById('apellido').value;
    const email = document.getElementById('email').value;
    const telefono = document.getElementById('telefono').value;
    const latitud = parseFloat(document.getElementById('latitud').value);
    const longitud = parseFloat(document.getElementById('longitud').value);
    const fechaNacimiento = document.getElementById('fechaNacimiento').value;

    const datosCliente = {
        Dni: dni,
        Nombre: nombre,
        Apellido: apellido,
        Email: email,
        Telefono: telefono,
        Latitud: latitud,
        Longitud: longitud,
        FechaNacimiento: fechaNacimiento
    };

    fetch('http://localhost:5125/api/Cliente', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(datosCliente)
    })
        .then(response => {
            if (response.ok) {
                return response.text();
            } else {
                throw new Error('Error al cargar el cliente');
            }
        })
        .then(data => {
            console.log('Respuesta de la API:', data);
            alert('Registro de cliente exitoso');
        })
        .catch(error => {
            console.error('Error al enviar los datos:', error);
            alert('Hubo un error al procesar el registro del cliente');
        });
});