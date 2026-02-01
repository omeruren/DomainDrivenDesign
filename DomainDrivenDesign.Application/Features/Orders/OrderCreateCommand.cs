using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Orders.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders;
public sealed record OrderCreateCommand(List<CreateOrderDto> CreateOrderDtos) : IRequest;

internal sealed class OrderCreateCommandHandler(IOrderRepository _orderRepository, IUnitOfWork _unitOfWork, IMediator _mediator) : IRequestHandler<OrderCreateCommand>
{
    public async Task Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.CreateAsync(request.CreateOrderDtos, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new OrderDomainEvent(order));
    }
}
