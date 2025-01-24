using Microsoft.Extensions.DependencyInjection;
using QuizApp.Models;
using QuizApp.Services;

public class Program
{
    public static void Main()
    {
        //var quizManager = QuizManager.Instance;

        //Setup DI Container
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IQuizManager, QuizManager>() //Register QuizManager as IQuizManager
            .AddSingleton<ManualQuizCreation>() //Register ManualQuizCreation
            .AddSingleton<JsonQuizCreation>() //Register JsonQuizCreation
            .BuildServiceProvider();

        var quizManager = serviceProvider.GetRequiredService<IQuizManager>();
        Quiz? quiz = null;

        while (true)
        {
            Console.WriteLine("\n---Quiz Application---");
            Console.WriteLine("1. Start Manual Quiz");
            Console.WriteLine("2. Start Quiz from JSON");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    quiz = RetrieveQuiz(
                        quizManager,
                        serviceProvider.GetRequiredService<ManualQuizCreation>()
                    );
                    break;
                case "2":
                    quiz = RetrieveQuiz(
                        quizManager,
                        serviceProvider.GetRequiredService<JsonQuizCreation>()
                    );
                    break;
                case "3":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }
            if (quiz != null)
            {
                quizManager.GetQuiz(quiz);
                quizManager.DisplaySummary(quiz);
            }
        }
    }

    private static Quiz? RetrieveQuiz(IQuizManager quizManager, IGetQuiz quizSource)
    {
        try
        {
            return quizManager.CreateQuiz(quizSource);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return null;
        }
    }
}
