using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/cines")]
    public class CinesController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CinesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinesDTO>>> Get()
        {

            //return await context.Cines.ToListAsync();
            //Para convertir de lartitud a longitud esta aca
            //https://isolution.pro/es/q/so72491685/entity-framework-core-3-1-con-nettopologysuite-geometries-point-sqlexception-el-valor-proporcionado-no-es-una-instanci
            //O tambien mirar Github de WebApi :D

            return await context.Cines.ProjectTo<CinesDTO>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
