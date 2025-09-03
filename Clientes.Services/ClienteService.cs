using Clientes.Services;
using Clientes.Repositories.Interfaces;
using Clientes.DTOs;
using Clientes.Domain;


namespace Clientes.Services
{
    public class ClienteService : Interfaces.IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        //  Obtener todos los clientes
        public async Task<IEnumerable<ClienteDto>> ObtenerTodosAsync()
        {
            var clientes = await _repository.ObtenerTodosAsync();
            return clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                Nombres = c.Nombres,
                Apellidos = c.Apellidos,
                Email = c.Email,
                Telefono = c.Telefono,
                Direccion = c.Direccion
            });
        }

        //  Obtener cliente por identificación
        public async Task<ClienteDto?> ObtenerPorIdentificacionAsync(string identificacion)
        {
            var cliente = await _repository.ObtenerPorIdentificacionAsync(identificacion);
            if (cliente == null) return null;

            return new ClienteDto
            {
                Id = cliente.Id,
                Nombres = cliente.Nombres,
                Apellidos = cliente.Apellidos,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion
            };
        }

        //  Crear cliente
        public async Task<ClienteDto> CrearAsync(ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                Nombres = clienteDto.Nombres,
                Apellidos = clienteDto.Apellidos,
                Email = clienteDto.Email,
                Telefono = clienteDto.Telefono,
                Direccion = clienteDto.Direccion
            };

            var creado = await _repository.CrearAsync(cliente);

            return new ClienteDto
            {
                Id = creado.Id,
                Nombres = creado.Nombres,
                Apellidos = creado.Apellidos,
                Email = creado.Email,
                Telefono = creado.Telefono,
                Direccion = creado.Direccion
            };
        }

        //  Actualizar cliente
        public async Task<bool> ActualizarAsync(string identificacion, ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                Id = clienteDto.Id,
                Nombres = clienteDto.Nombres,
                Apellidos = clienteDto.Apellidos,
                Email = clienteDto.Email,
                Telefono = clienteDto.Telefono,
                Direccion = clienteDto.Direccion
            };

            return await _repository.ActualizarAsync(cliente);
        }

        //  Eliminar cliente
        public async Task<bool> EliminarAsync(string identificacion)
        {
            return await _repository.EliminarAsync(identificacion);
        }


    }
}
