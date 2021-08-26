using Aplicacion.Customer;
using Dominio.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia.Entidad;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Profesor
{
    public class GetProfesores
    {
        public class ListaProfesores : IRequest<List<ProfesorModel>> { }
        public class Manejador : IRequestHandler<ListaProfesores, List<ProfesorModel>>
        {
            private readonly BPSContext _context;
            public Manejador(BPSContext Context)
            {
                this._context = Context;
            }

            public async Task<List<ProfesorModel>> Handle(ListaProfesores request, CancellationToken cancellationToken)
            {
                var Estudiantes = await _context.Profesor.ToListAsync();
                if (Estudiantes != null)
                {
                    return Estudiantes;
                }

                throw new ValidacionError(HttpStatusCode.NotFound, new { message = "No se han encontrado registros" });
            }
        }
    }
}
