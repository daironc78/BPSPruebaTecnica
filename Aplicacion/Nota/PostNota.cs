using Aplicacion.Customer;
using Dominio.Models;
using FluentValidation;
using MediatR;
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
    public class PostNota
    {
        public class CrearNota : IRequest
        {
            public Guid ProfesorId { get; set; }
            public Guid EstudianteId { get; set; }
            public int Valor { get; set; }
        }

        public class NotaValidacion : AbstractValidator<CrearNota>
        {
            public NotaValidacion()
            {
                RuleFor(x => x.ProfesorId).NotEmpty().WithMessage("Por favor ingrese el codigo de profesor");
                RuleFor(x => x.EstudianteId).NotEmpty().WithMessage("Por favor ingrese el codigo de estudiante");
                RuleFor(x => x.Valor).NotEmpty().WithMessage("Por favor ingrese una nota");
            }
        }

        public class Manejador : IRequestHandler<CrearNota>
        {
            private readonly BPSContext _context;
            public Manejador(BPSContext Context)
            {
                this._context = Context;
            }

            public async Task<Unit> Handle(CrearNota request, CancellationToken cancellationToken)
            {
                try
                {
                    var profesor = _context.Profesor.Where(x => x.IdProfesor == request.ProfesorId);
                    var estudiante = _context.Estudiante.Where(x => x.IdEstudiante == request.EstudianteId);
                    if (profesor != null && estudiante != null)
                    {
                        NotaModel nota = new NotaModel()
                        {
                            IdNota = Guid.NewGuid(),
                            IdProfesor = request.ProfesorId,
                            IdEstudiante = request.EstudianteId,
                            Valor = request.Valor
                        };
                        _context.Nota.Add(nota);

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
