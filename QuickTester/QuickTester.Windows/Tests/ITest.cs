using QuickTester.Questions;

namespace QuickTester.Tests
{
    public interface ITest
    {
        void CreateTest();
        void CountRightAnswers(QuestionWithChooseVariantsOfAnswers question, object i);
    }
}
