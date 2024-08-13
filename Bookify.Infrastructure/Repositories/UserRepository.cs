using Bookify.Domain.Users;

namespace Bookify.Infrastructure.Repositories;

internal sealed class UserRepository(ApplicationDbContext dbContext)
    : Repository<User>(dbContext), IUserRepository
{
    public override void Add(User user)
    {
        foreach (var userRole in user.Roles)
        {
            DbContext.Attach(userRole);
        }

        DbContext.Add(user);
    }
}