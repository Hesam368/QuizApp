using QuizApp.Models;

namespace QuizApp.Services{
    public interface IQuizManager{
        Question CreateQuestion(string text, List<string> options, int correctOption);
        Quiz CreateQuiz(List<Question> questions);
        void GetQuiz(Quiz quiz);
        List<Question> ImportQuiz(string filePath);
        void DisplaySummary(Quiz quiz);
    }
}