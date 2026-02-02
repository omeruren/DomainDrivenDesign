using DomainDrivenDesign.Application.Features.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CategoryGetAllQuery query, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }
}
