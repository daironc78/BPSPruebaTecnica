using Aplicacion.Customer;
using MediatR;
using Persistencia.Entidad;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Nota
{
    public class DeleteNotaId
    {

        public class EliminarNotaId : IRequest
        {
            public Guid NotaId { get; set; }
        }

        public class Manejador : IRequestHandler<EliminarNotaId>
        {
            private readonly BPSContext _context;
            public Manejador(BPSContext Context)
            {
                this._context = Context;
            }

            public async Task<Unit> Handle(EliminarNotaId request, CancellationToken cancellationToken)
            {
                try
                {
                    var Nota = _context.Nota.Where(x => x.IdNota == request.NotaId).FirstOrDefault();
                    if (Nota != null)
                    {
                        _context.Nota.Remove(Nota);

                        var result = await _context.SaveChangesAsync();
                        if (result > 0)
                            return Unit.Value;
                        else
                            throw new ValidacionError(HttpStatusCode.NotFound, new { message = "Ha ocurrido un error intente mas tarde" });
                    }
                    else
                    {
                        throw new ValidacionError(HttpStatusCode.NotFound, new { message = "Por favor, validar los datos ingresados" });
                    }

                }
                catch
                {
                    throw new ValidacionError(HttpStatusCode.NotFound, new { message = "Por favor, validar los datos ingresados" });
                }
            }
        }
    }
}
