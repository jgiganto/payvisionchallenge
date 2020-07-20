namespace Refactoring.FraudDetection.Application.FraudResults.Responses
{
    public class FraudResult
    {
        public int OrderId { get; set; }
        public bool IsFraudulent { get; set; }
    }
}
