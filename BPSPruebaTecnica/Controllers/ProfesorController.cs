using Aplicacion.Profesor;
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
    public class ProfesorController : GlobalControllerBase
    {
        [HttpGet]
        [Route("GetProfesores")]
        public async Task<ActionResult<List<ProfesorModel>>> GetProfesores()
        {
            return await _mediator.Send(new GetProfesores.ListaProfesores());
        }
    }
}
