using EmpresaDto;
using EmpresaEntities;
using EmpresaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaService
{
    public class ClienteService
    {
        public bool CrearCliente(ClienteDto clienteDto)
        {
            if (!Validate(clienteDto)) { return false; };
            var clienteExistente = ClienteFiles.LeerClientesDesdeJson();
            if (clienteExistente.Any(x => x.Dni == clienteDto.Dni)) { return false; }
            var cliente = ConvertirACliente(clienteDto);
            cliente.FechaCreacion = DateTime.Now;
            ClienteFiles.EscribirClientesAJson(cliente);
            return true;
        }

        public ClienteDto ObtenerClientePorDni(int dni)
        {
            var cliente = ClienteFiles.LeerClientesDesdeJson().FirstOrDefault(x => x.Dni == dni);
            if (cliente != null)
            {
                return ConvertirAClienteDto(cliente);
            }
            return null;
        }

        public List<ClienteDto> ObtenerListaClientes()
        {
            return ClienteFiles.LeerClientesDesdeJson().Select(ConvertirAClienteDto).ToList();
        }

        public Resultado EditarCliente(int dni, ClienteDto clienteDto)
        {
            if (!Validate(clienteDto)) { return new Resultado() { Codigo = 400, Mensaje = "Datos incompletos", Success = false }; }
            var buscar = ClienteFiles.LeerClientesDesdeJson().FirstOrDefault(x => x.Dni == dni);
            if (buscar == null) { return new Resultado() { Codigo = 404, Mensaje = "No se encontro al cliente", Success = false }; }
            var cliente = ConvertirACliente(clienteDto);
            cliente.FechaActualizacion = DateTime.Now;
            ClienteFiles.EscribirClientesAJson(cliente);
            return new Resultado() { Codigo = 200, Mensaje = "Cliente editado correctamente", Success = true };

        }

        public bool EliminarCliente(int dni)
        {
            var cliente = ClienteFiles.LeerClientesDesdeJson().FirstOrDefault(x => x.Dni == dni);
            if (cliente == null) { return false; }
            cliente.FechaEliminacion = DateTime.Now;
            ClienteFiles.EscribirClientesAJson(cliente);
            return true;
        }


        private bool Validate(ClienteDto clienteDto)
        {
            if (clienteDto == null ||
         clienteDto.Dni <= 0 ||
         string.IsNullOrWhiteSpace(clienteDto.Nombre) ||
         string.IsNullOrWhiteSpace(clienteDto.Apellido) ||
         string.IsNullOrWhiteSpace(clienteDto.Email) ||
         clienteDto.Telefono <= 0 ||
         clienteDto.Latitud == 0 ||
         clienteDto.Longitud == 0 ||
         clienteDto.FechaNacimiento == DateTime.MinValue ||
         clienteDto.FechaNacimiento > DateTime.Now ||
         clienteDto.FechaNacimiento.Year < 1900)
            {
                return false;
            }
            return true;
        }
        private Cliente ConvertirACliente(ClienteDto clienteDto)
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = clienteDto.Nombre;
            cliente.Apellido = clienteDto.Apellido;
            cliente.Email = clienteDto.Email;
            cliente.Dni = clienteDto.Dni;
            cliente.Telefono = clienteDto.Telefono;
            cliente.Longitud = clienteDto.Longitud;
            cliente.Latitud = clienteDto.Latitud;
            cliente.FechaNacimiento = clienteDto.FechaNacimiento;

            return cliente;
        }
        private ClienteDto ConvertirAClienteDto(Cliente cliente)
        {
            ClienteDto clienteDto = new ClienteDto();
            clienteDto.Nombre = cliente.Nombre;
            clienteDto.Apellido = cliente.Apellido;
            clienteDto.Email = cliente.Email;
            clienteDto.Dni = cliente.Dni;
            clienteDto.Telefono = cliente.Telefono;
            clienteDto.Longitud = cliente.Longitud;
            clienteDto.Latitud = cliente.Latitud;
            clienteDto.FechaNacimiento = cliente.FechaNacimiento;

            return clienteDto;
        }
    }
}
