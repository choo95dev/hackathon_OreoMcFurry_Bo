using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Stock_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediatRController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
