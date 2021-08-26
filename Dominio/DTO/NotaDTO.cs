using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class NotaDTO
    {
        public Guid IdNota { get; set; }
        public string NombreProfesor { get; set; }
        public string NombreEstudiante { get; set; }
        public int Valor { get; set; }
    }
}
