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
            .AddSingleton<MenuHandler>() //Register MenuHandler
            .BuildServiceProvider();

        var quizManager = serviceProvider.GetRequiredService<IQuizManager>();
        var MenuHandler = serviceProvider.GetRequiredService<MenuHandler>();
        Quiz? quiz = null;

        while (true)
        {
            IGetQuiz? quizSource = MenuHandler.DisplayMenu();
            if (quizSource == null)
            {
                System.Console.WriteLine("Exiting...");
                return;
            }

            quiz = RetrieveQuiz(quizManager, quizSource);
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
