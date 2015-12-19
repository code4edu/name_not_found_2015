//using SQLite;
//using System.Collections.Generic;
//using System.IO;
//using Windows.Storage;

//namespace QuickTester.Questions
//{
//    public class QuestionWithChooseVariantsOfAnswers : IQuestion
//    {
//        [PrimaryKey, AutoIncrement]
//        public int KeyQuestion { get; private set; }
//        public string thisQuestion { get; private set; }
//        private Dictionary<byte, StructAnswer> variantsOfAnswers;

//        public QuestionWithChooseVariantsOfAnswers(string question, Dictionary<byte, StructAnswer> answers) // n - количество вариантов ответа
//        {
//            this.thisQuestion = question;
//            variantsOfAnswers = answers;
//        }

//        public bool TheRightAnswer(byte i)
//        {
//            if (variantsOfAnswers[i].right)
//                return true;
//            return false;
//        }


//    }

//}
