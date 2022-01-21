using AutoMapper;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;

namespace EFCorePeliculas.Servicios
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Actor , ActorDTO>().ReverseMap();
            CreateMap<Cine, CinesDTO>()
                .ForMember(dto => dto.Latitud, ent => ent.MapFrom(prop => prop.Ubicacion.Y))
                .ForMember(dto => dto.Longitud, ent => ent.MapFrom(prop => prop.Ubicacion.X));

            CreateMap<Genero, GeneroDTO>();
            CreateMap<Pelicula, PeliculaDTO>()
                .ForMember(dto => dto.Cines, ent => ent.MapFrom(prop => prop.SalasDeCine.Select(c => c.Cine)))
                .ForMember(dto => dto.Actores, ent => ent.MapFrom(prop => prop.PeliculaActores.Select(p => p.Actor)));

            //Con ProjectTo

            //CreateMap<Pelicula, PeliculaDTO>()
            //    .ForMember(dto => dto.Generos, ent => ent.MapFrom(prop => prop.Generos.OrderByDescending(g => g.Nombre)))
            //    .ForMember(dto => dto.Cines, ent => ent.MapFrom(prop => prop.SalasDeCine.Select(c => c.Cine)))
            //    .ForMember(dto => dto.Actores, ent => ent.MapFrom(prop => prop.PeliculaActores.Select(p => p.Actor)));
        }
    }
}
