using Bookify.Domain.Apartments;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories;

internal sealed class ApartmentRepository(DbContext dbContext) : Repository<Apartment>(dbContext), IApartmentRepository
{
}