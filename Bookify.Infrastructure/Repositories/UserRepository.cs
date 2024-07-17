using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories;

internal sealed class UserRepository(DbContext dbContext) : Repository<User>(dbContext), IUserRepository
{
}