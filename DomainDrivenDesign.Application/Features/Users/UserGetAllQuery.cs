using DomainDrivenDesign.Domain.Users;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Users;
public sealed record UserGetAllQuery() : IRequest<List<User>>;


internal sealed class UserGetAllQueryHandler(IUserRepository _userRepository) : IRequestHandler<UserGetAllQuery, List<User>>
{
    public async Task<List<User>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync(cancellationToken);
    }
}
