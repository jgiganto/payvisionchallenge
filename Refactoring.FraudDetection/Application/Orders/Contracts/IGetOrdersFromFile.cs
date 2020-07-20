using Refactoring.FraudDetection.Application.Orders.Responses;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Application.Orders.Contracts
{
    public interface IGetOrdersFromFile
    {
        List<Order> GetOrders(string filePath);
    }
}
