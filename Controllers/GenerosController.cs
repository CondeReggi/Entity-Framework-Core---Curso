using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GenerosController(ApplicationDbContext context)
        {
            this.context = context;
        }
    
        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            // .AsNoTracking() utilizamos para el uso de Querys de solo lectura (hace mas eficiente la busqueda) 

            return await context.Generos
                //.AsNoTracking() Para no utilizar Traking => AsTracking para el uso de Tracking
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {

            // FirstOrDefaultAsync si no encuentra nada => return null
            // FirstAsync si no encuentra nada => return internal Error


            var genero =  await context.Generos.FirstOrDefaultAsync(x => x.Id == id); 
            
            // => g.Nombre.StartsWith(" letra ").
            // => g.length > 54
            // or any condition 

            if (genero == null)
            {
                return NotFound(); //Error 404
            }

            return Ok(genero); //Status 200
            
        }

        [HttpGet("filtrar")]
        public async Task<IEnumerable<Genero>> GetFiltro([FromQuery] string nombre)
        {
            return await context.Generos.Where( g => (g.Nombre.StartsWith("C") || g.Nombre.StartsWith("A")) && g.Nombre.Contains(nombre) )
                .OrderBy(g => g.Nombre) //Ordenamos de manera ascendente por nombre
                .ToListAsync();

            //.Where es la condicion de sql de where tal cual
        }

        [HttpGet("paginacion")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetPaginacion([FromQuery] int pagina = 1)
        {
            //Take es en SQL TOP 3 ...... any number
            //Skip, es toma los primeros 3 pero el segundo saltealo

            var cantidadRegistrosPorPagina = 2;

            var generos = await context.Generos
                                .Skip(  (pagina - 1) * cantidadRegistrosPorPagina  )
                                .Take(cantidadRegistrosPorPagina)
                                .ToListAsync();

            return generos;
        }
    }
}
