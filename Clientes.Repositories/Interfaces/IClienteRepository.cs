using Clientes.Domain;


namespace Clientes.Repositories.Interfaces;


public interface IClienteRepository
{
    Task<Cliente?> ObtenerPorIdentificacionAsync(string identificacion, CancellationToken ct = default);
    Task<IEnumerable<Cliente>> ObtenerTodosAsync(CancellationToken ct = default);
    Task<Cliente> CrearAsync(Cliente cliente, CancellationToken ct = default);
    Task<bool> ActualizarAsync(Cliente cliente, CancellationToken ct = default);
    Task<bool> EliminarAsync(string identificacion, CancellationToken ct = default);

}