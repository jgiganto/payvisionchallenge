namespace Refactoring.FraudDetection.Tests
{
    public class TestConstants
    {
        public const string Files = "Files";
        public const string BaseRoute = "./Files/";
        public const string OneLineFile = "OneLineFile.txt";
        public const string TwoLines_FraudulentSecond = "TwoLines_FraudulentSecond.txt";
        public const string ThreeLines_FraudulentSecond = "ThreeLines_FraudulentSecond.txt";
        public const string FourLines_MoreThanOneFraudulent = "FourLines_MoreThanOneFraudulent.txt";

        public const string NullError = "The result should not be null.";
        public const string NumberOfLinesError = "The result should contains the number of lines of the file";
    }
}
