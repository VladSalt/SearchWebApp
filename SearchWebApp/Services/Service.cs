using SearchWebApp.Interface;
using SearchWebApp.Methods;
using SearchWebApp.Models;
using System;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace SearchWebApp.Services
{
    public class Service : IService<AnswerModel>
    {
        /// <summary>
        /// Шаблонная строка запроса. 
        /// TODO: Переделать, вынести в Config.
        /// </summary>
        private string ApiUrl = @"https://api.stackexchange.com/2.3/search?order=desc&sort=activity&intitle={0}&site=stackoverflow";

        #region public
        /// <summary>
        /// Задать вопрос
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public AnswerModel RequestAnswer(string question)
        {
            var fullUrl = CreateUrl(question);
            return Get(fullUrl);
        }
        #endregion

        #region private
        /// <summary>
        /// Получим полный адрес
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private string CreateUrl(string param)
        {
            var url = string.Empty;
            if (param == String.Empty || param == null)
            {
                //TODO: Обработка пустого параметра запроса
                // Пока по дефолту будем искать вопросы по Java
                url = String.Format(ApiUrl, HttpUtility.UrlEncode("java"));
            }
            else
            {
                url = String.Format(ApiUrl, HttpUtility.UrlEncode(param));
            }

            return url;
        }

        /// <summary>
        /// Получить ответы на вопрос
        /// </summary>
        /// <param name="uri">Готовая строка запроса к API</param>
        /// <returns></returns>
        private AnswerModel Get(string uri)
        {
            try
            {
                var jsonResult = new NetworkMethod(uri).Get();
                AnswerModel answerModel = ParseResult(jsonResult);

                // Сортировка по последней активности
                answerModel.items.OrderBy(item => item.last_activity_date);

                return answerModel;
            }
            catch (Exception ex)
            {
                //TODO: Обработать ошибки
                var errorMessage = ex.Message;
                return new AnswerModel();
            }
        }

        /// <summary>
        /// Распарсим результат json в модель
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private AnswerModel ParseResult(string jsonResult)
        {
            return JsonSerializer.Deserialize<AnswerModel>(jsonResult);
        }
        #endregion
    }
}
