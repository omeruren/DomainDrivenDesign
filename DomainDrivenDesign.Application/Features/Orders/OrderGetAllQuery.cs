using DomainDrivenDesign.Domain.Orders;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders;
public sealed record OrderGetAllQuery() : IRequest<List<Order>>;

internal sealed class OrderGetAllQueryHandler(IOrderRepository _orderRepository) : IRequestHandler<OrderGetAllQuery, List<Order>>
{
    public async Task<List<Order>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetAllAsync(cancellationToken);
    }
}
