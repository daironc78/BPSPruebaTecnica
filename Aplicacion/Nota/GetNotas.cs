using Aplicacion.Customer;
using AutoMapper;
using Dominio.DTO;
using Dominio.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia.Entidad;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Nota
{
    public class GetNotas
    {
        public class ListaNotas : IRequest<List<NotaDTO>> { }
        public class Manejador : IRequestHandler<ListaNotas, List<NotaDTO>>
        {
            private readonly BPSContext _context;
            public Manejador(BPSContext Context)
            {
                this._context = Context;
            }

            public async Task<List<NotaDTO>> Handle(ListaNotas request, CancellationToken cancellationToken)
            {
                var Notas = await _context.Nota.Include(x => x.Profesor).Include(x => x.Estudiante).ToListAsync();
                if (Notas != null)
                {
                    List<NotaDTO> NotasDTO = new List<NotaDTO>();
                    foreach (var Nota in Notas)
                    {
                        NotaDTO NotaDTO = new NotaDTO()
                        {
                            IdNota = Nota.IdNota,
                            NombreEstudiante = Nota.Estudiante.Nombre,
                            NombreProfesor = Nota.Profesor.Nombre,
                            Valor = Nota.Valor
                        };
                        NotasDTO.Add(NotaDTO);
                    }
                    return NotasDTO;
                }

                throw new ValidacionError(HttpStatusCode.NotFound, new { message = "No se han encontrado registros" });
            }
        }
    }
}
