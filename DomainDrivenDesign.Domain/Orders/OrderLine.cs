using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;

namespace DomainDrivenDesign.Domain.Orders;

public sealed class OrderLine : BaseEntity
{
    private OrderLine(Guid id) : base(id)
    {
    }

    public OrderLine(Guid id, Guid productId, Guid orderId, int quantity, Money price) : base(id)
    {
        ProductId = productId;
        OrderId = orderId;
        Quantity = quantity;
        Price = price;
    }

    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }
    public Guid OrderId { get; private set; }
    public int Quantity { get; private set; }
    public Money Price { get; private set; }

}