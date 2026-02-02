using DomainDrivenDesign.Application.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(ProductGetAllQuery query, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }
}
