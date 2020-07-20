using Refactoring.FraudDetection.Application.Orders.Contracts;
using Refactoring.FraudDetection.Application.Orders.Responses;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Application.Orders.Services
{
    public class NormalizeOrderService : INormalizeOrderService
    {
        private readonly INormalizeEmail _normalizeEmail;
        private readonly INormalizeState _normalizeState;
        private readonly INormalizeStreet _normalizeStreet;
        private readonly IGetOrdersFromFile _getOrdersFromFile;

        public NormalizeOrderService()
        {
            _normalizeEmail = new NormalizeEmail();
            _normalizeState = new NormalizeState();
            _normalizeStreet = new NormalizeStreet();
            _getOrdersFromFile = new GetOrdersFromFile();
        }
     
        public IEnumerable<Order> Normalize(List<Order> orders)
        {

            foreach (var order in orders)
            {
                order.Email = _normalizeEmail.GetOrderWithNormalizedEmail(order.Email);

                order.Street = _normalizeStreet.GetOrderWithNormalizedStreet(order.Street);

                order.State = _normalizeState.GetOrderWithNormalizedState(order.State);
            }
           
            return orders;
        }

       
    }
}
