using System;
using QuickTester.Questions;

namespace QuickTester.Tests
{
    public class Test : ITest
    {
        private QuestionWithChooseVariantsOfAnswers[] questions;
        public int count_ball { get; private set; }

        public Test(int countOfQuestions)
        {
            questions = new QuestionWithChooseVariantsOfAnswers[countOfQuestions];
            count_ball = 0;
        }

        public void CountRightAnswers(QuestionWithChooseVariantsOfAnswers question, object i)
        {
            if (question.TheRightAnswer((byte)i))
                count_ball++;
        }
        public void CreateTest()
        {
            //Random rnd = new Random();
            //for (int i = 0; i < questions.Length; i++)
            //{
            //    questions[i].
            //}
        }
    }
}
