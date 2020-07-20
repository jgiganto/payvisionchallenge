using FluentValidation;

namespace Refactoring.FraudDetection.Application.Orders.Responses
{
    public class Order
    {
        public int OrderId { get; set; }
        public int DealId { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CreditCard { get; set; }
    }

    public class OrderValidator : AbstractValidator<Order>
    {       
        public OrderValidator()
        {
            RuleFor(o => o.OrderId)
                .NotEmpty()
                .NotNull()                 
                .WithMessage("OrderId is required");

            RuleFor(o => o.DealId)
                .NotEmpty()
                .NotNull()
                .WithMessage("DealId is required");

            RuleFor(o => o.Email)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage(o => $"{o.Email} Error: A valid email is required in order {o.OrderId}");

            RuleFor(o => o.Street)
              .NotEmpty()
              .NotNull()
              .WithMessage("Street is required");

            RuleFor(o => o.City)
              .NotEmpty()
              .NotNull()
              .WithMessage("City is required");

            RuleFor(o => o.State)
              .NotEmpty()
              .NotNull()
              .WithMessage("State is required");

            RuleFor(o => o.ZipCode)
              .NotEmpty()
              .NotNull()
              .WithMessage("ZipCode is required");

            RuleFor(o => o.CreditCard)
             .NotEmpty()
             .NotNull()
             .Matches(@"^[0-9']{11}$")
             .WithMessage(o => $"CreditCard Error:{o.CreditCard} is not valid in Order {o.OrderId}, is required with length of 11 digits" );
        }
    }
}

 