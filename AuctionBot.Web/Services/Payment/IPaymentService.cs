namespace AuctionBot.Web.Services.Payment;

public interface IPaymentService
{
    Task<bool> DoTransaction(PaymentDto paymentDto);
}