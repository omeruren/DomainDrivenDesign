using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Products;
public sealed record ProductCreateCommand(
    string Name,
    int Quantity,
    decimal Amount,
    string Currency,
    Guid CategoryId) : IRequest;


internal sealed class ProductCreateCommandHandler(IProductRepository _productRepository, IUnitOfWork _unitOfWork) : IRequestHandler<ProductCreateCommand>
{
    public async Task Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.CreateAsync(
            request.Name,
            request.Quantity,
            request.Amount,
            request.Currency,
            request.CategoryId, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
