namespace Refactoring.FraudDetection.Application.Orders.Contracts
{
    public interface INormalizeState
    {
        string GetOrderWithNormalizedState(string state);
    }
}
