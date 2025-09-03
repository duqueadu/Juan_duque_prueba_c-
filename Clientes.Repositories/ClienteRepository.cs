using Clientes.Domain;
using Clientes.Repositories.Data;
using Clientes.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesDbContext _context;

        public ClienteRepository(ClientesDbContext context)
        {
            _context = context;
        }

        //  Obtener todos
        public async Task<IEnumerable<Cliente>> ObtenerTodosAsync(CancellationToken ct = default)
        {
            return await _context.Clientes.ToListAsync(ct);
        }

        //  Obtener por identificación
        public async Task<Cliente?> ObtenerPorIdentificacionAsync(string identificacion, CancellationToken ct = default)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.Identificacion == identificacion, ct);
        }

        //  Crear
        public async Task<Cliente> CrearAsync(Cliente cliente, CancellationToken ct = default)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync(ct);
            return cliente;
        }

        //  Actualizar
        public async Task<bool> ActualizarAsync(Cliente cliente, CancellationToken ct = default)
        {
            var existente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Identificacion == cliente.Identificacion, ct);

            if (existente == null)
                return false;

            existente.Nombres = cliente.Nombres;
            existente.Apellidos = cliente.Apellidos;
            existente.Email = cliente.Email;
            existente.Telefono = cliente.Telefono;
            existente.Direccion = cliente.Direccion;

            _context.Clientes.Update(existente);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        //  Eliminar
        public async Task<bool> EliminarAsync(string identificacion, CancellationToken ct = default)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Identificacion == identificacion, ct);

            if (cliente == null)
                return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
