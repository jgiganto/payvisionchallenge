using Refactoring.FraudDetection.Application.Orders.Contracts;

namespace Refactoring.FraudDetection.Application.Orders.Services
{
    public class NormalizeState : INormalizeState
    {
        public string GetOrderWithNormalizedState(string state)
        {
            return state.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
        }
    }
}
