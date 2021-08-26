using AutoMapper;
using Dominio.DTO;
using Dominio.Models;
using System.Linq;

namespace Aplicacion.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<NotaModel, NotaDTO>()
                    .ForMember(x => x.NombreProfesor, y => y.MapFrom(z => z.Profesor.Nombre))
                    .ForMember(x => x.NombreEstudiante, y => y.MapFrom(z => z.Estudiante.Nombre));

        }
    }
}
