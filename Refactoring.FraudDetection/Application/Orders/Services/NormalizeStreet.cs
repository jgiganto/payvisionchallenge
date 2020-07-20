using Refactoring.FraudDetection.Application.Orders.Contracts;

namespace Refactoring.FraudDetection.Application.Orders.Services
{
    public class NormalizeStreet : INormalizeStreet
    {
        public string GetOrderWithNormalizedStreet(string street)
        {
            return street.Replace("st.", "street").Replace("rd.", "road");
        }
    }
}
