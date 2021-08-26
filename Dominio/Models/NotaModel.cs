using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class NotaModel
    {
        [Key]
        public Guid IdNota { get; set; }

        [ForeignKey("Estudiante")]
        public Guid IdEstudiante { get; set; }
        public EstudianteModel Estudiante { get; set; }

        [ForeignKey("Profesor")]
        public Guid IdProfesor { get; set; }
        public ProfesorModel Profesor { get; set; }

        public int Valor { get; set; }
    }

}