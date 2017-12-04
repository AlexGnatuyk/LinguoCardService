using System;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Services.Services
{
    public class QuizService : IQuizService
    {
        private readonly IWordDictionaryRepository _repository;
        public QuizService(IWordDictionaryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public bool CheckQuiz(int dictionaryId, string chosenValue)
        {
            var correctValue = _repository.GetById(dictionaryId);
            return correctValue.EnglishValue.Equals(chosenValue) ||
                   correctValue.RussianValue.Equals(chosenValue);
        }
    }
}