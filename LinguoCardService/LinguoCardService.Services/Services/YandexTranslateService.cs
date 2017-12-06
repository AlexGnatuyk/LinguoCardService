using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;
using Newtonsoft.Json.Linq;
using NLog;

namespace LinguoCardService.Services.Services
{
    public class YandexTranslateService : IYandexTranslateService
    {
        private readonly IWordDictionaryRepository _repository;
        private readonly ILogger _logger;

        public YandexTranslateService(IWordDictionaryRepository repository, ILogger logger)
        {
            _logger = logger;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public string GetTranslate(string original, Language language)
        {
            _logger.Info($"[YandexTranslateService] Transslate of word: {original} was requested uses Yandex Translate");
            var url = $"https://translate.yandex.net/api/v1.5/tr.json/translate";
            var apiKey = $"trnsl.1.1.20171204T105508Z.73de18b158ee992c.0732ee1e959ed65fefe5f904d935b7401fb2b0dc";

            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection
                {
                    {"key", apiKey},
                    {"text", original},
                    {"lang", language.ToString().ToLower()}
                };

                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var response = webClient.UploadValues(url, pars);
                string responsebody = Encoding.UTF8.GetString(response);

                var responseText = JObject.Parse(responsebody)["text"];
                var translate = (string) responseText[0];
                if (language == Language.En)
                {
                    _repository.AddWord(translate, original);
                }
                else
                {
                    _repository.AddWord(original, translate);
                }
                return translate;
            }
        }
    }
}