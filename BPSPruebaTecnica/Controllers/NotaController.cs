using Aplicacion.Nota;
using Dominio.DTO;
using Dominio.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPSPruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaController : GlobalControllerBase
    {
        [HttpGet]
        [Route("GetNotas")]
        public async Task<ActionResult<List<NotaDTO>>> GetNotas()
        {
            return await _mediator.Send(new GetNotas.ListaNotas());
        }

        [HttpGet]
        [Route("GetNotaId/{NotaId}")]
        public async Task<ActionResult<NotaModel>> GetNotaId(Guid NotaId)
        {
            return await _mediator.Send(new GetNotaId.Nota() { NotaId = NotaId });
        }

        [HttpPost]
        [Route("PostNota")]
        public async Task<ActionResult<Unit>> PostNota(PostNota.CrearNota Nota)
        {
            return await _mediator.Send(Nota);
        }

        [HttpPut]
        [Route("PutNotas/{NotaId}")]
        public async Task<ActionResult<Unit>> PutNotas(Guid NotaId, PutNota.ActualizarNota Nota)
        {
            Nota.NotaId = NotaId;
            return await _mediator.Send(Nota);
        }

        [HttpDelete]
        [Route("DeleteNota/{NotaId}")]
        public async Task<ActionResult<Unit>> DeleteNotas(Guid NotaId)
        {
            return await _mediator.Send(new DeleteNotaId.EliminarNotaId() { NotaId = NotaId });
        }
    }
}