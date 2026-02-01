using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;

namespace DomainDrivenDesign.Domain.Orders;

public sealed class OrderLine : BaseEntity
{
    public OrderLine(Guid id) : base(id)
    {
    }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }

}