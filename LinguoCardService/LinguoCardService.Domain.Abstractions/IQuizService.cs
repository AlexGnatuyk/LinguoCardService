namespace LinguoCardService.Domain.Abstractions
{
    public interface IQuizService
    {
        bool CheckQuiz(int dictionaryId, string chosenValue);
    }
}