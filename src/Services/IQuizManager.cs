using QuizApp.Models;

namespace QuizApp.Services
{
    public interface IQuizManager
    {
        Quiz CreateQuiz(IGetQuiz quizSource);
        void GetQuiz(Quiz quiz);
        void DisplaySummary(Quiz quiz);
    }
}
