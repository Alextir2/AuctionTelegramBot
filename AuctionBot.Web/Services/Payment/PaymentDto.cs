namespace AuctionBot.Web.Services.Payment;

public class PaymentDto
{
    public required string CardNumber { get; set; }
    
    public required decimal Amount { get; set; }
}