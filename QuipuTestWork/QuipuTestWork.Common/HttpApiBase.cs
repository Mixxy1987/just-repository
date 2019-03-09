using System;
using System.Net.Http;
using System.Threading;

namespace QuipuTestWork.Common
{
    public class HttpApiBase : IHttpApiBase
    {
        private CancellationToken _token;

        public HttpApiBase(CancellationToken token)
        {
            _token = token;
        }

        /// <summary>
        /// Обработка GET запросов к API
        /// </summary>
        public HttpResponseMessage Get(string path)
        {
            using (var handler = PrepareWebRequestHandler())
            {
                using (var client = PrepareHttpClient(handler))
                {
                    try
                    {
                        return client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).Result;
                    }
                    catch (AggregateException ex)
                    {
                        throw ex.InnerException ?? ex;
                    }
                }
            }
        }

        /// <summary>
        /// Подготовка обработчика запросов
        /// </summary>
        private WebRequestHandler PrepareWebRequestHandler()
        {
            var handler = new WebRequestHandler
            {
                AllowAutoRedirect = false,
            };

            return handler;
        }

        /// <summary>
        /// Подготовка http-клиента
        /// </summary>
        private HttpClient PrepareHttpClient(WebRequestHandler handler)
        {
            var client = new HttpClient(new ApiRequestHandler(handler));
            return client;
        }
    }
}
