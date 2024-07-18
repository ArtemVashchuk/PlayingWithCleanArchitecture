﻿using Bookify.Application.Apartments.SearchApartments;
using Bookify.Application.Bookings.GetBooking;
using Bookify.Application.Bookings.ReserveBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.API.Controllers.Bookings;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBooking(
        Guid id,
        CancellationToken cancellationToken)
    {
        var query = new GetBookingQuery(id);

        var result = await sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ReserveBooking(ReserveBookingRequest request, CancellationToken cancellationToken)
    {
        var command = new ReserveBookingCommand(request.ApartmentId, request.UserId, request.StartDate, request.EndDate);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return CreatedAtAction(nameof(GetBooking), new { Id = result.Value }, result.Value);
    }
}