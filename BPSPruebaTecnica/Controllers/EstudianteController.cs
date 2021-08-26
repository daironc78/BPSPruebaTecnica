using Aplicacion.Estudiante;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPSPruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : GlobalControllerBase
    {
        [HttpGet]
        [Route("GetEstudiantes")]
        public async Task<ActionResult<List<EstudianteModel>>> GetEstudiantes()
        {
            return await _mediator.Send(new GetEstudiantes.ListaEstudiantes());
        }
    }
}
