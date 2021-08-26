using Aplicacion.Customer;
using Dominio.Models;
using FluentValidation;
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
    public class PutNota
    {

        public class ActualizarNota : IRequest
        {
            public Guid NotaId { get; set; }
            public int Valor { get; set; }
        }

        public class NotaValidacion : AbstractValidator<ActualizarNota>
        {
            public NotaValidacion()
            {
                RuleFor(x => x.Valor).NotEmpty().WithMessage("Por favor ingrese una nota");
            }
        }

        public class Manejador : IRequestHandler<ActualizarNota>
        {
            private readonly BPSContext _context;
            public Manejador(BPSContext Context)
            {
                this._context = Context;
            }

            public async Task<Unit> Handle(ActualizarNota request, CancellationToken cancellationToken)
            {
                try
                {
                    var Nota = await _context.Nota.Include(x => x.Profesor).Include(x => x.Estudiante).Where(x => x.IdNota == request.NotaId).FirstOrDefaultAsync();
                    if (Nota != null)
                    {
                        Nota.Valor = request.Valor;
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
                catch (Exception e)
                {
                    throw new ValidacionError(HttpStatusCode.NotFound, new { message = "Por favor, validar los datos ingresados" + e.Message });
                }
            }
        }
    }
}
