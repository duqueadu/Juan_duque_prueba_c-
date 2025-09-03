using Clientes.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace Clientes.Repositories.Data;


public class ClientesDbContext : DbContext
{
    public ClientesDbContext(DbContextOptions<ClientesDbContext> options) : base(options) { }
    public DbSet<Cliente> Clientes => Set<Cliente>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Mappings.ClienteEntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}