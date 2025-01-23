using QuizApp.Services;

namespace QuizApp.Models
{
    public class ManualQuizCreation : IGetQuiz
    {
        public List<Question> RetrieveQuestions()
        {
            var questions = new List<Question>();

            var question1 = Question.Create(
                "What is the capital of England?",
                new List<string> { "Paris", "London", "Berlin" },
                2
            );
            var question2 = Question.Create(
                "Which Continent is England in?",
                new List<string> { "Europe", "Asia", "Africa", "America" },
                1
            );
            var question3 = Question.Create(
                "What is the currency of England?",
                new List<string> { "Dollar", "Rial", "Euro", "Pound" },
                4
            );

            questions.Add(question1);
            questions.Add(question2);
            questions.Add(question3);

            return questions;
        }
    }
}
