using System.Net.Http;

namespace QuipuTestWork.Common
{
    public interface IHttpApiBase
    {
        /// <summary>
        /// Обработка GET запросов к API
        /// </summary>
        HttpResponseMessage Get(string path);
    }
}
