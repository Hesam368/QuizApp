namespace QuizApp.Models
{
    public class Quiz
    {
        //Properties
        private Guid Id;
        public List<Question> Questions { get; }

        //Constructor
        private Quiz(List<Question> questions)
        {
            if (questions == null || questions.Count == 0)
            {
                throw new ArgumentException("Quiz must have at least 1 question!");
            }
            Id = Guid.NewGuid();
            Questions = questions;
        }

        internal static Quiz Create(List<Question> questions)
        {
            return new Quiz(questions);
        }
    }
}
