using DomainDrivenDesign.Domain.Products;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Products;
public sealed record ProductGetAllQuery() : IRequest<List<Product>>;


internal sealed class ProductGetAllQueryHandler(IProductRepository _productRepository) : IRequestHandler<ProductGetAllQuery, List<Product>>
{
    public async Task<List<Product>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllAsync();
    }
}
