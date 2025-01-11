using QuizApp.Models;
using QuizApp.Services;
public class Program{
    public static void Main(){
        var quizManager = QuizManager.Instance;
        
        //Create Questions
        var question1 = quizManager.CreateQuestion("Where is the capital of England?",
            new List<string>{"Paris", "London", "Berlin"}, 2);
        var question2 = quizManager.CreateQuestion("Which Continent is England in?",
            new List<string>{"Europe", "Asia", "Africa", "America"}, 1);
        var question3 = quizManager.CreateQuestion("What is the currency of England?",
            new List<string>{"Dollar", "Rial", "Euro", "Pound"}, 4);
        
        //Create Quiz
        var quiz = quizManager.CreateQuiz(new List<Question>{question1, question2, question3});

        //Get Quiz
        quizManager.GetQuiz(quiz);
    }
}
