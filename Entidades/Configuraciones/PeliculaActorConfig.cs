using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PeliculaActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {

            builder.HasKey(e => new { e.ActorId, e.PeliculaId });

            builder.Property(e => e.Personaje)
                .HasMaxLength(150);

        }
    }
}
