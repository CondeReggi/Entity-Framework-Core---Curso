using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool enCartelera { get; set; }
        public DateTime fechaEstreno { get; set; }
        //[Unicode(false)]
        public string PosterUrl { get; set; }
        public HashSet<Genero> Generos { get; set; }
        public HashSet<SalaDeCine> SalasDeCine { get; set; }
        public HashSet<PeliculaActor> PeliculaActores { get; set;}
    }
}
