using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Domain.Users.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Users;
public sealed record UserCreateCommand(
    string Name,
    string Email,
    string Password,
    string Country,
    string City,
    string Street,
    string PostalCode,
    string FullAddress) : IRequest;

internal sealed class UserCreateCommandHandler(IUserRepository _userRepository, IUnitOfWork _unitOfWork, IMediator _mediator) : IRequestHandler<UserCreateCommand>
{
    public async Task Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.CreateAsync(
             request.Name,
             request.Email,
             request.Password,
             request.Country,
             request.City,
             request.Street,
             request.PostalCode,
             request.FullAddress);


        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new UserDomainEvent(user));
    }
}
