using QuizApp.Models;
using QuizApp.Services;
public class Program{
    public static void Main(){
        var quizManager = QuizManager.Instance;
        
        //Create Questions
        var question1 = quizManager.CreateQuestion("What is the capital of England?",
            new List<string>{"Paris", "London", "Berlin"}, 2);
        var question2 = quizManager.CreateQuestion("Which Continent is England in?",
            new List<string>{"Europe", "Asia", "Africa", "America"}, 1);
        var question3 = quizManager.CreateQuestion("What is the currency of England?",
            new List<string>{"Dollar", "Rial", "Euro", "Pound"}, 4);

        //Create Quiz
        var quiz = quizManager.CreateQuiz(new List<Question>{question1, question2, question3});
        
        while(true){
            Console.WriteLine("\n---Quiz Application---");
            Console.WriteLine("1. Start Quiz");
            Console.WriteLine("2. Import Quiz from JSON");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            string? input = Console.ReadLine();

            switch(input){
                case "1":
                    quizManager.GetQuiz(quiz);
                    quizManager.DisplaySummary(quiz);
                    break;
                case "2":
                    Console.Write("Enter the file path: ");
                    string? filePath = Console.ReadLine();
                    if(!string.IsNullOrWhiteSpace(filePath)){
                        var questions = quizManager.ImportQuiz(filePath);
                        quiz = quizManager.CreateQuiz(questions);
                    }
                    break;
                case "3":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }
        }
    }
}
