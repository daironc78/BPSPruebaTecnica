using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Models
{
    public class EstudianteModel
    {
        [Key]
        public Guid IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public ICollection<NotaModel> EstudianteLink { get; set; }
    }
}
