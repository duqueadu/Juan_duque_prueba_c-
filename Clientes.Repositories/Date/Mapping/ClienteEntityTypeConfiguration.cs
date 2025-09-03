using Clientes.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Clientes.Repositories.Data.Mappings;


public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Identificacion).IsUnique();
        builder.Property(x => x.Identificacion).HasMaxLength(20).IsRequired();
        builder.Property(x => x.Nombres).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Apellidos).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(150);
        builder.Property(x => x.Telefono).HasMaxLength(30);
        builder.Property(x => x.Direccion).HasMaxLength(200);
    }
}