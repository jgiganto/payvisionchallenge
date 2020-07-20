using FluentValidation;
using Refactoring.FraudDetection.Application.Orders.Contracts;
using Refactoring.FraudDetection.Application.Orders.Responses;
using System;
using System.Collections.Generic;
using System.IO;

namespace Refactoring.FraudDetection.Application.Orders.Services
{
    public class GetOrdersFromFile : IGetOrdersFromFile
    {
        List<Order> orders;
        OrderValidator validator;
        public GetOrdersFromFile()
        {
            orders = new List<Order>();
            validator = new OrderValidator();
        }
        public List<Order> GetOrders(string filePath) 
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var items = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                var order = new Order
                {
                    OrderId = int.Parse(items[0]),
                    DealId = int.Parse(items[1]),
                    Email = items[2].ToLower(),
                    Street = items[3].ToLower(),
                    City = items[4].ToLower(),
                    State = items[5].ToLower(),
                    ZipCode = items[6],
                    CreditCard = items[7]
                };

                validator.ValidateAndThrow(order);         

                orders.Add(order);
            }
              
            return orders; 
        }
    }
}
