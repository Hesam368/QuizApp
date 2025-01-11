namespace QuizApp.Models{
    public class Question{
        //Properties
        public Guid Id {get; private set;}
        public string Text {get; set;}
        public List<string> Options {get; set;}
        public int CorrectOption{get;set;}

        //Constructor
        private Question(string text, List<string> options, int correctOption){
            if(string.IsNullOrWhiteSpace(text)){
                throw new ArgumentException("Question text cannot be empty!");
            }
            if(options == null || options.Count < 2){
                throw new ArgumentException("Question must have at least 2 options!");
            }
            if(correctOption < 1 || correctOption > options.Count){
                throw new ArgumentException("Correct Option must be within the range of options!");
            }
            Id = Guid.NewGuid();
            Text = text;
            Options = options;
            CorrectOption = correctOption;
        }
        internal static Question Create(string text, List<string> options, int correctOption){
            return new Question(text, options, correctOption);
        }
    }
}