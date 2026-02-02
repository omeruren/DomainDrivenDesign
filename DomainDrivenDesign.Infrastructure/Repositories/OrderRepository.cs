using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories;
internal sealed class OrderRepository(ApplicationDbContext _context) : IOrderRepository
{
    public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
    {
        Order order = new(
            Guid.CreateVersion7(),
            "1",
            DateTime.Now,
            OrderStatusEnum.AwaitingFroApproval);

        order.CreateOrderLine(createOrderDtos);
        await _context.Orders.AddAsync(order, cancellationToken);
        return order;
    }

    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {

        return await _context.Orders.ToListAsync(cancellationToken);
    }
}
