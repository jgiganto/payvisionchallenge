// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
    using Refactoring.FraudDetection.Application.FraudResults.Contracts;
    using Refactoring.FraudDetection.Application.FraudResults.Responses;
    using Refactoring.FraudDetection.Application.FraudResults.Services;
    using Refactoring.FraudDetection.Application.Orders.Contracts;
    using Refactoring.FraudDetection.Application.Orders.Responses;
    using Refactoring.FraudDetection.Application.Orders.Services;
    using System.Collections.Generic;
    using System.Linq;

    public class FraudRadar   
    {
        INormalizeOrderService orders;
        ICheckFraudService results;
        public FraudRadar()
        {
           orders = new NormalizeOrderService();
           results = new CheckFraudService();
        }
        public IEnumerable<FraudResult> Check(List<Order> ordersList) =>        
             results.CheckOrders(orders.Normalize(ordersList).ToList());
                 
    }
} 