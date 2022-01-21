using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PeliculasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> Get(int id)
        {
            var pelicula = await context.Peliculas
                            .Include(p => p.Generos.OrderByDescending(g => g.Nombre)) //Order By desc 
                            .Include(p => p.SalasDeCine)
                                .ThenInclude(c => c.Cine)
                            .Include(p => p.PeliculaActores.Where(pa => pa.Actor.FechaNacimiento.Value.Year >= 1980))
                                .ThenInclude(a => a.Actor)
                            .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null) { return NotFound();  }

            //Sin PROJECTTO
            var peliculaDto = mapper.Map<PeliculaDTO>(pelicula);

            peliculaDto.Cines = peliculaDto.Cines.DistinctBy(x => x.Id).ToList(); 

            return peliculaDto;
        }

        [HttpGet("conproyectTo/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetConProjectTo(int id)
        {
            var pelicula = await context.Peliculas
                            .ProjectTo<PeliculaDTO>(mapper.ConfigurationProvider) // Como en los modelos tienen ciertas cosas aca te manda todo.
                            .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null) { return NotFound(); }

            pelicula.Cines = pelicula.Cines.DistinctBy(x => x.Id).ToList();

            return pelicula;
        }
        
        [HttpGet("cargadoSelectivo/{id:int}")]
        public async Task<ActionResult> GetSelectivo(int id)
        {
            var pelicula = await context.Peliculas.Select( pelicula => new { 
                
                Id = pelicula.Id,
                Titulo = pelicula.Titulo,
                Generos = pelicula.Generos.OrderByDescending( g => g.Nombre ).Select(g => g.Nombre).ToList(), //Importante el ToList al final
                CantidadActores = pelicula.PeliculaActores.Count(),
                CantidadCines = pelicula.SalasDeCine.Distinct().Count()

            } ).FirstOrDefaultAsync(x => x.Id == id);

            if (pelicula is null) { return NotFound(); }

            return Ok(pelicula);
        }

        [HttpGet("cargadoExplicito/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetExplicito(int id)
        {
            var pelicula = await context.Peliculas.AsTracking().FirstOrDefaultAsync(x => x.Id == id);

            // Carga los generos a la peticion anterior
            await context.Entry(pelicula).Collection(p => p.Generos).LoadAsync();
            //await context.Entry(pelicula).Collection(p => p.SalasDeCine).LoadAsync();
            //await context.Entry(pelicula).Collection(p => p.PeliculaActores).LoadAsync();

            var cantidadGeneros = await context.Entry(pelicula).Collection(x => x.Generos).Query().CountAsync(); // Se pueden hacer este tipo de cosas en el mismo endpoint

            if ( pelicula is null) { return NotFound(); }

            var peliculaDto = mapper.Map<PeliculaDTO>(pelicula);

            return peliculaDto;
        }

        [HttpGet("lazyloading/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetLazyLoading(int id)
        {
            var peliculas = await context.Peliculas.AsTracking().FirstOrDefaultAsync(x => x.Id ==id);
            
          if (peliculas is null) { return NotFound(); }

            var peliculaDto = mapper.Map<PeliculaDTO>(peliculas);

            peliculaDto.Cines = peliculaDto.Cines.DistinctBy(x => x.Id).ToList();
            return peliculaDto;
        }
    }
}
