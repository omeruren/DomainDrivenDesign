namespace DomainDrivenDesign.Domain.Orders;

public enum OrderStatusEnum
{
    AwaitingFroApproval = 1,
    Preparing = 2,
    InTransit = 3,
    Delivired = 4
}