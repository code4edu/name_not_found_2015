using System.Collections.Generic;

namespace QuickTester.Questions
{
    public class QuestionWithChooseVariantsOfAnswers : IQuestion
    {
        public string thisQuestion { get; private set; }
        private Dictionary<byte, StructAnswer> variantsOfAnswers;

        public QuestionWithChooseVariantsOfAnswers(string question, Dictionary<byte, StructAnswer> answers) // n - количество вариантов ответа
        {
            this.thisQuestion = question;
            variantsOfAnswers = answers;
        }

        public bool TheRightAnswer(object i)
        {
            if (variantsOfAnswers[(byte)i].right)
                return true;
            return false;
        }


    }

}
