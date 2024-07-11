using Bookify.Application.Abstraction.Messaging;

namespace Bookify.Application.Bookings.GetBooking;

public record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;