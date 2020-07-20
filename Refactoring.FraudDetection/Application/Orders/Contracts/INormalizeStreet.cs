namespace Refactoring.FraudDetection.Application.Orders.Contracts
{
    public interface INormalizeStreet
    {
        string GetOrderWithNormalizedStreet(string street);
    }
}
