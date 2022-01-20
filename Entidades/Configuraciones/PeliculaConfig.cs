using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(e => e.Titulo)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.PosterUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}
