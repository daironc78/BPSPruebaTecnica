using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Entidad
{
    public class DbInicializador
    {
        public static void Inicializador(BPSContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Profesor.Any() && !context.Estudiante.Any() && !context.Nota.Any())
            {
                // Profesores
                var Profesores = new ProfesorModel[]
                {
                    new ProfesorModel { IdProfesor = Guid.NewGuid(),Nombre="Alexander"},
                    new ProfesorModel { IdProfesor = Guid.NewGuid(),Nombre="Alonso"},
                    new ProfesorModel { IdProfesor = Guid.NewGuid(),Nombre="Anand",},
                    new ProfesorModel { IdProfesor = Guid.NewGuid(),Nombre="Barzdukas"},
                    new ProfesorModel { IdProfesor = Guid.NewGuid(),Nombre="Li"}
                };

                foreach (ProfesorModel p in Profesores)
                {
                    context.Profesor.Add(p);
                }

                context.SaveChanges();

                // Estudiantes
                var Estudiantes = new EstudianteModel[]
                {
                    new EstudianteModel { IdEstudiante = Guid.NewGuid(),Nombre="Alexander"},
                    new EstudianteModel { IdEstudiante = Guid.NewGuid(),Nombre="Alonso"},
                    new EstudianteModel { IdEstudiante = Guid.NewGuid(),Nombre="Anand",},
                    new EstudianteModel { IdEstudiante = Guid.NewGuid(),Nombre="Barzdukas"},
                    new EstudianteModel { IdEstudiante = Guid.NewGuid(),Nombre="Li"}
                };

                foreach (EstudianteModel e in Estudiantes)
                {
                    context.Estudiante.Add(e);
                }

                context.SaveChanges();

                // Notas
                var Notas = new NotaModel[]
                {
                    new NotaModel 
                    { 
                        IdNota = Guid.NewGuid(),
                        IdEstudiante = context.Estudiante.Where(x => x.Nombre == "Alexander").Select(x => x.IdEstudiante).FirstOrDefault(),
                        IdProfesor= context.Profesor.Where(x => x.Nombre == "Alexander").Select(x => x.IdProfesor).FirstOrDefault(),
                        Valor = 1
                    },
                    new NotaModel
                    {
                        IdNota = Guid.NewGuid(),
                        IdEstudiante = context.Estudiante.Where(x => x.Nombre == "Alonso").Select(x => x.IdEstudiante).FirstOrDefault(),
                        IdProfesor= context.Profesor.Where(x => x.Nombre == "Alonso").Select(x => x.IdProfesor).FirstOrDefault(),
                        Valor = 1
                    },
                    new NotaModel
                    {
                        IdNota = Guid.NewGuid(),
                        IdEstudiante = context.Estudiante.Where(x => x.Nombre == "Anand").Select(x => x.IdEstudiante).FirstOrDefault(),
                        IdProfesor= context.Profesor.Where(x => x.Nombre == "Anand").Select(x => x.IdProfesor).FirstOrDefault(),
                        Valor = 1
                    },
                    new NotaModel
                    {
                        IdNota = Guid.NewGuid(),
                        IdEstudiante = context.Estudiante.Where(x => x.Nombre == "Barzdukas").Select(x => x.IdEstudiante).FirstOrDefault(),
                        IdProfesor= context.Profesor.Where(x => x.Nombre == "Barzdukas").Select(x => x.IdProfesor).FirstOrDefault(),
                        Valor = 1
                    },
                    new NotaModel
                    {
                        IdNota = Guid.NewGuid(),
                        IdEstudiante = context.Estudiante.Where(x => x.Nombre == "Li").Select(x => x.IdEstudiante).FirstOrDefault(),
                        IdProfesor= context.Profesor.Where(x => x.Nombre == "Li").Select(x => x.IdProfesor).FirstOrDefault(),
                        Valor = 1
                    },
                };

                foreach (NotaModel n in Notas)
                {
                    context.Nota.Add(n);
                }

                context.SaveChanges();
            }
            else
            {
                return;
            }
        }
    }
}
