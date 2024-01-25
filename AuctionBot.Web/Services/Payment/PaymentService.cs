namespace AuctionBot.Web.Services.Payment;

public class PaymentService : IPaymentService
{
    public Task<bool> DoTransaction(PaymentDto paymentDto)
    {
        return Task.FromResult(true);
    }
}