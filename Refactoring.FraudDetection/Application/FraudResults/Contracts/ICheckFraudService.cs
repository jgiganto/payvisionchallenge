using Refactoring.FraudDetection.Application.FraudResults.Responses;
using Refactoring.FraudDetection.Application.Orders.Responses;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Application.FraudResults.Contracts
{
    public interface ICheckFraudService
    {
        IEnumerable<FraudResult> CheckOrders(List<Order> orders);
    }
}
