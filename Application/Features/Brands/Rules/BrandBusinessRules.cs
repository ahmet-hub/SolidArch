using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly DataContext _context;
        public BrandBusinessRules(DataContext context) =>
            _context = context;

        public async Task BrandNameCanNotBeDublicatedWhenInserted(string name)
        {
            var brand = await _context.Brands.AnyAsync(x => x.Name == name);

            if (brand) throw new BusinessException("ExistBrandName");

        }
    }
}
