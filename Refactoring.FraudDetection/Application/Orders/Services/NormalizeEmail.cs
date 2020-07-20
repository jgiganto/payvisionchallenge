using Refactoring.FraudDetection.Application.Orders.Contracts;
using Refactoring.FraudDetection.Application.Orders.Responses;
using System;

namespace Refactoring.FraudDetection.Application.Orders.Services
{
    public class NormalizeEmail : INormalizeEmail
    {
        public string GetOrderWithNormalizedEmail(string email)
        {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            email = string.Join("@", new string[] { aux[0], aux[1] });

            return email;
        }
    }
}
