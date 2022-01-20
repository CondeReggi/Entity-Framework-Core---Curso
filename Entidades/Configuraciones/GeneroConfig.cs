using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {

            //modelBuilder.Entity<Genero>() == builder

            builder.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
