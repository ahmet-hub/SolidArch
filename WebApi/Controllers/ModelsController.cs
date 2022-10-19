using Application.Features.Models.Commands.CreateModel;
using Application.Features.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateModelCommand createModelCommand)
        {
            var result = _mediator.Send(createModelCommand);
            return Created("deneme", result);
        }

    }
}
