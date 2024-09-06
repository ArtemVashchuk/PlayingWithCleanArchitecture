using Bookify.Domain.Apartments;

namespace Bookify.Domain.Bookings;

public interface IBookingRepository
{
    public Task<Booking?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> IsOverlapping(Apartment apartment, DateRange duration, CancellationToken cancellationToken);
    void Add(Booking booking);
}