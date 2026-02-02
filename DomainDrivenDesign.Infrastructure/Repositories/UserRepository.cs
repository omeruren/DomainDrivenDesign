using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories;
internal sealed class UserRepository(ApplicationDbContext _context) : IUserRepository
{
    public async Task<User> CreateAsync(string name, string email, string password, string country, string city, string street, string postalCode, string fullAddress, CancellationToken cancellationToken = default)
    {
        User user = User.CreateUser(name, email, password, country, city, street, postalCode, fullAddress);
        await _context.AddAsync(user, cancellationToken);
        return user;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Users.ToListAsync(cancellationToken);
    }
}
