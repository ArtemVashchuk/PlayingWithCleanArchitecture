namespace Bookify.Domain.Apartments;

public interface IApartmentRepository
{
    public Task<Apartment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}