namespace Refactoring.FraudDetection.Application.Orders.Contracts
{
    public interface INormalizeEmail
    {
        string GetOrderWithNormalizedEmail(string email);
    }
}
