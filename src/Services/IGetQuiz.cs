using QuizApp.Models;

namespace QuizApp.Services
{
    public interface IGetQuiz
    {
        List<Question> RetrieveQuestions();
    }
}
