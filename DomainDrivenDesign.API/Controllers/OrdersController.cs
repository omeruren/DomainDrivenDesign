
using DomainDrivenDesign.Application.Features.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrdersController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(OrderCreateCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(OrderGetAllQuery query, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }
}
