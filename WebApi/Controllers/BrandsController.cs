using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Core.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<ApiResponse<CreatedBrandDto>> Add([FromBody] CreateBrandCommand createBrandCommand) =>
            _mediator.Send(createBrandCommand);

    }
}
