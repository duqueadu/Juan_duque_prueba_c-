using Clientes.Domain;
using Clientes.DTOs;

namespace Clientes.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDto?> ObtenerPorIdentificacionAsync(string identificacion);
        Task<IEnumerable<ClienteDto>> ObtenerTodosAsync();
        Task<ClienteDto> CrearAsync(ClienteDto clienteDto);
        Task<bool> ActualizarAsync(string identificacion, ClienteDto clienteDto);
        Task<bool> EliminarAsync(string identificacion);

    }
}




