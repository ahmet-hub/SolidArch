using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Core.Application.Response;
using Domain.Entities;
using MediatR;
using Persistence.Contexts;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public partial class CreateBrandCommand : IRequest<ApiResponse<CreatedBrandDto>>
    {
        public string Name { get; set; }
    }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ApiResponse<CreatedBrandDto>>
    {
        private readonly DataContext _context;
        private readonly BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(DataContext dataContext, BrandBusinessRules brandBusinessRules)
        {
            _context = dataContext;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<ApiResponse<CreatedBrandDto>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            #region Rules
            await _brandBusinessRules.BrandNameCanNotBeDublicatedWhenInserted(request.Name);
            #endregion


            var entityEntry = await _context.AddAsync(new Brand
            {
                Name = request.Name,
            });

            await _context.SaveChangesAsync();

            var createdBrandDto = new CreatedBrandDto
            {
                Id = entityEntry.Entity.Id,
                Name = entityEntry.Entity.Name,
            };

            return new ApiResponse<CreatedBrandDto>(true, ResponseCode.Created, createdBrandDto);

        }
    }
}
