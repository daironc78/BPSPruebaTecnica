using Aplicacion.Customer;
using Dominio.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Nota
{
    public class GetNotaId
    {
        public class Nota : IRequest<NotaModel> 
        {
            public Guid NotaId { get; set; }
        }
        public class Manejador : IRequestHandler<Nota, NotaModel>
        {
            private readonly BPSContext _context;
            public Manejador(BPSContext Context)
            {
                this._context = Context;
            }

            public async Task<NotaModel> Handle(Nota request, CancellationToken cancellationToken)
            {
                var Nota = await _context.Nota.Include(x => x.Profesor).Include(x => x.Estudiante).Where(x => x.IdNota == request.NotaId).FirstOrDefaultAsync();
                if (Nota != null)
                {
                    return Nota;
                }

                throw new ValidacionError(HttpStatusCode.NotFound, new { message = "No se han encontrado registros" });
            }
        }
    }
}
