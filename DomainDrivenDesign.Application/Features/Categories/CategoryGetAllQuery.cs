using DomainDrivenDesign.Domain.Categories;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Categories;
public sealed record CategoryGetAllQuery() : IRequest<List<Category>>;


internal sealed class CategoryGetAllQueryHandler(ICategoryRepository _categoryRepository) : IRequestHandler<CategoryGetAllQuery, List<Category>>
{
    public async Task<List<Category>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAllAsync(cancellationToken);
    }
}
