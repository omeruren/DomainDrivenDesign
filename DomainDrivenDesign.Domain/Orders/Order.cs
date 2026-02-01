using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Orders;
public sealed class Order : BaseEntity
{
    public Order(Guid id, string orderNumber, DateTime createDate, OrderStatusEnum status) : base(id)
    {
        OrderNumber = orderNumber;
        CreateDate = createDate;
        Status = status;
    }

    public string OrderNumber { get; private set; }
    public DateTime CreateDate { get; private set; }
    public OrderStatusEnum Status { get; private set; }
    public ICollection<OrderLine> OrderLines { get; private set; }

    public void CreateOrderLine(List<CreateOrderDto> createOrderDtos)
    {
        foreach (var item in createOrderDtos)
        {
            if (item.Quantity < 1)
                throw new ArgumentException("Quantity can not be 0 or less");

            // More business rules

            OrderLine orderLine = new(
                Guid.CreateVersion7(),
                Id, //orderId
                item.ProductId,
                item.Quantity,
                new(item.Amount, Currency.CheckCurrencyType(item.Currency)));

            OrderLines.Add(orderLine);
        }
    }

    public void RemoveOrderLine(Guid orderLineId)
    {
        OrderLine? orderLine = OrderLines.FirstOrDefault(o => o.Id == orderLineId);
        if (orderLine is null)
            throw new ArgumentException("Order line not found.");

        OrderLines.Remove(orderLine);
    }

}

public sealed record CreateOrderDto(
    Guid ProductId,
    int Quantity,
    decimal Amount,
    string Currency);