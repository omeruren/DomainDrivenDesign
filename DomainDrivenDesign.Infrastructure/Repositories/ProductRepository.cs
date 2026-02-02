using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories;
internal sealed class ProductRepository(ApplicationDbContext _context) : IProductRepository
{
    public async Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default)
    {
        Product product = new(
            Guid.CreateVersion7(),
            new(name),
            quantity,
            new(amount, Currency.CheckCurrencyType(currency)),
            categoryId
            );
        await _context.Products.AddAsync(product, cancellationToken);
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }
}
