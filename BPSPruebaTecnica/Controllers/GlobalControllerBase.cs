using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BPSPruebaTecnica.Controllers
{
    [ApiController]
    public class GlobalControllerBase : ControllerBase
    {
        private IMediator Mediator;
        protected IMediator _mediator => Mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
