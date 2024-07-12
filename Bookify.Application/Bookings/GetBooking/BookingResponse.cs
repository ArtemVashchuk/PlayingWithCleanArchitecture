namespace Bookify.Application.Bookings.GetBooking;

public sealed class BookingResponse
{
    private Guid Id { get; init; }
    
    public Guid UserId { get; init; }
    
    public Guid ApartmentId { get; init; }
    
    public int Status { get; set; }
    
    public decimal PriceAmount { get; set; }
    
    public string PriceCurrency { get; set; }
    
    public decimal CleaningFeeAmount { get; init; }
    
    public string CleaningFeeCurrency { get; set; }
    
    public decimal AmenitiesUpChargeAmount { get; init; }
    
    public string AmenitiesUpChargeACurrency { get; set; }
    
    public decimal TotalPriceAmount { get; init; }
    
    public decimal TotalPriceCurrency { get; init; }
    
    public DateOnly DurationStart { get; init; }
    
    public DateOnly DurationEnd { get; init; }
    
    public DateTime CreatedOnUtc { get; init; }
}