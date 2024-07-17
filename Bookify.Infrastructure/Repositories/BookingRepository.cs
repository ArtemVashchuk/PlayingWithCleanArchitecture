using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories;

internal sealed class BookingRepository(ApplicationDbContext dbContext)
    : Repository<Booking>(dbContext), IBookingRepository
{
    private static readonly BookingStatus[] ActiveBookingStatuses =
    [
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    ];

    public Task<bool> IsOverlapping(Apartment apartment, DateRange duration,
        CancellationToken cancellationToken = default)
    {
        return dbContext.Set<Booking>()
            .AnyAsync(booking =>
                booking.ApartmentId == apartment.Id &&
                booking.Duration.Start <= duration.End &&
                booking.Duration.End >= duration.Start &&
                ActiveBookingStatuses.Contains(booking.Status),
                cancellationToken: cancellationToken);
    }
}