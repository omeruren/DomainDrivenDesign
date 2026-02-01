using DomainDrivenDesign.Domain.Abstractions;

namespace DomainDrivenDesign.Domain.Orders;
public sealed class Order : BaseEntity
{
    public Order(Guid id) : base(id)
    {
    }

    public string OrderNumber { get; set; }
    public DateTime CreateDate { get; set; }
    public OrderStatusEnum Status { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
}
