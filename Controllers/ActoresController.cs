using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController( ApplicationDbContext context , IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> Get()
        {
            //var actores = await context.Actores
            //                .Select( x => new ActorDTO { Id = x.Id , Nombre = x.Nombre })
            //                .ToListAsync();

            var actores = await context.Actores.ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();

            return Ok(actores); 
        }
    }
}
