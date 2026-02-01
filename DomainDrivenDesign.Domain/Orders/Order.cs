using DomainDrivenDesign.Domain.Abstractions;

namespace DomainDrivenDesign.Domain.Orders;
public sealed class Order : BaseEntity
{
    public Order(Guid id, string orderNumber, DateTime createDate, OrderStatusEnum status, ICollection<OrderLine> orderLines) : base(id)
    {
        OrderNumber = orderNumber;
        CreateDate = createDate;
        Status = status;
        OrderLines = orderLines;
    }

    public string OrderNumber { get; private set; }
    public DateTime CreateDate { get; private set; }
    public OrderStatusEnum Status { get; private set; }
    public ICollection<OrderLine> OrderLines { get; private set; }
}
