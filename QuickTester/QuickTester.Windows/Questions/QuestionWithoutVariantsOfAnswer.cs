//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace QuickTester.Questions
//{
//    public class QuestionWithoutVariantsOfAnswer : IQuestion
//    {
//        public string Question { get; set; }
//        private int rightAnswer;

//        public QuestionWithoutVariantsOfAnswer(string question, int RightAnswer)
//        {
//            this.Question = question;
//            rightAnswer = RightAnswer;
//        }
//        //TODO: Ответ на вопрос вводится с клавиатуры. ОН обязательно числовой!!!
//        public bool TheRightAnswer(int i)
//        {
//            if (i == rightAnswer)
//                return true;
//            return false;
//        }
//    }
//}
