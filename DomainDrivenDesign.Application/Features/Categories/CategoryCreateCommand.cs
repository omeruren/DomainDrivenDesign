using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Categories;
public sealed record CategoryCreateCommand(string Name) : IRequest;


internal sealed class CategoryCreateCommandHandler(ICategoryRepository _categoryRepository, IUnitOfWork _unitOfWork) : IRequestHandler<CategoryCreateCommand>
{
    public async Task Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        await _categoryRepository.CreateAsync(request.Name, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
