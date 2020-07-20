using Refactoring.FraudDetection.Application.FraudResults.Contracts;
using Refactoring.FraudDetection.Application.FraudResults.Responses;
using Refactoring.FraudDetection.Application.Orders.Responses;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Application.FraudResults.Services
{
    public class CheckFraudService : ICheckFraudService
    {
        public IEnumerable<FraudResult> CheckOrders(List<Order> orders)
        {
            var fraudResults = new List<FraudResult>();

            for (int i = 0; i < orders.Count; i++)
            {
                var current = orders[i];
                bool isFraudulent = false;

                for (int j = i + 1; j < orders.Count; j++)
                {
                    isFraudulent = false;

                    if (current.DealId == orders[j].DealId
                        && current.Email == orders[j].Email
                        && current.CreditCard != orders[j].CreditCard)
                    {
                        isFraudulent = true;
                    }

                    if (current.DealId == orders[j].DealId
                        && current.State == orders[j].State
                        && current.ZipCode == orders[j].ZipCode
                        && current.Street == orders[j].Street
                        && current.City == orders[j].City
                        && current.CreditCard != orders[j].CreditCard)
                    {
                        isFraudulent = true;
                    }

                    if (isFraudulent)
                    {
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = orders[j].OrderId });
                    }
                }
            }

            return fraudResults;
        }
    }
}
