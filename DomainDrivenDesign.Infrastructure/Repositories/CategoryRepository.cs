using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories;
internal sealed class CategoryRepository(ApplicationDbContext _context) : ICategoryRepository
{
    public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        Category category = new(Guid.CreateVersion7(), new(name));
        await _context.Categories.AddAsync(category, cancellationToken);

    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Categories.ToListAsync(cancellationToken);
    }
}
