using Application.Features.Models.Dtos;
using Domain.Entities;
using MediatR;
using Persistence.Contexts;

namespace Application.Features.Models.Commands.CreateModel
{
    public class CreateModelCommand : IRequest<CreatedModelDto>
    {
        public Guid BrandId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public List<string> ImageUrls { get; set; } = new();
    }

    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelDto>
    {
        private readonly DataContext _context;

        public CreateModelCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<CreatedModelDto> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            _context.Database.BeginTransaction();
            var entityEntry = _context.Models.Add(new Model
            {
                Name = request.Name,
                BrandId = request.BrandId,
                DailyPrice = request.DailyPrice,
            });

            var modelImages = new List<ModelImage>();

            _context.SaveChanges();

            if (request.ImageUrls.Any())
            {
                foreach (var imageUrl in request.ImageUrls)
                    modelImages.Add(new ModelImage { ModelId = entityEntry.Entity.Id, ImageUrl = imageUrl });

                _context.ModelImages.AddRange(modelImages);
                _context.SaveChanges();
            }

            await _context.Database.CommitTransactionAsync();

            return new CreatedModelDto
            {
                Id = entityEntry.Entity.Id,
                Name = entityEntry.Entity.Name,
                DailyPrice = entityEntry.Entity.DailyPrice,
            };
        }
    }
}
