using System;
using LinguoCardService.Domain.Abstractions;
using NLog;

namespace LinguoCardService.Services.Services
{
    public class QuizService : IQuizService
    {
        private readonly IWordDictionaryRepository _repository;
        private readonly ILogger _logger;

        public QuizService(IWordDictionaryRepository repository, ILogger logger)
        {
            _logger = logger;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Checking answers
        /// </summary>
        /// <param name="dictionaryId"></param>
        /// <param name="chosenValue"></param>
        /// <returns></returns>
        public bool CheckQuiz(int dictionaryId, string chosenValue)
        {
            _logger.Info($"[QuizService] Checking of  dictionary with id {dictionaryId} and word {chosenValue} was requested ");
            var correctValue = _repository.GetById(dictionaryId);
            return correctValue.EnglishValue.Equals(chosenValue) ||
                   correctValue.RussianValue.Equals(chosenValue);
        }
    }
}