namespace QuickTester.Tests
{
    public interface ITest
    {
        void CreateTest();
        int CountRightAnswers(IQuestion question);
    }
}
