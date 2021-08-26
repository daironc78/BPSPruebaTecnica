using Aplicacion.Customer;
using Dominio.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia.Entidad;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Estudiante
{
    public class GetEstudiantes
    {
        public class ListaEstudiantes : IRequest<List<EstudianteModel>> { }
        public class Manejador : IRequestHandler<ListaEstudiantes, List<EstudianteModel>>
        {
            private readonly BPSContext _context;
            public Manejador(BPSContext Context)
            {
                this._context = Context;
            }

            public async Task<List<EstudianteModel>> Handle(ListaEstudiantes request, CancellationToken cancellationToken)
            {
                var Estudiantes = await _context.Estudiante.ToListAsync();
                if (Estudiantes != null)
                {
                    return Estudiantes;
                }

                throw new ValidacionError(HttpStatusCode.NotFound, new { message = "No se han encontrado registros" });
            }
        }
    }
}
