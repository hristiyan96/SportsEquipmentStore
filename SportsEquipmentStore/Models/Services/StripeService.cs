using Stripe;

public class StripeService
{
    private readonly IConfiguration _configuration;

    public StripeService(IConfiguration configuration)
    {
        _configuration = configuration;

        // Replace with your Secret Key from the Stripe Dashboard
        StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
    }

    public PaymentIntent CreatePaymentIntent(long amount)
    {
        var options = new PaymentIntentCreateOptions
        {
            Amount = amount,
            Currency = "usd",
            PaymentMethodTypes = new List<string> { "card" }
        };

        var service = new PaymentIntentService();
        return service.Create(options);
    }
}
