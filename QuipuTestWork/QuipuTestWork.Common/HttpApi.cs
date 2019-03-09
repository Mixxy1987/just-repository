using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using QuipuTestWork.Common.Exceptions;

namespace QuipuTestWork.Common
{
    public class HttpApi : IHttpApi
    {
        private readonly IHttpApiBase _httpApiBase;

        public HttpApi(IHttpApiBase httpApiBase)
        {
            _httpApiBase = httpApiBase;
        }

        public string GetLinkAndDownload(CancellationToken token, string url)
        {
            HttpResponseMessage result = _httpApiBase.Get(url);
            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return DownloadLinkContent(new Uri(url)).Result;
                case HttpStatusCode.Found:
                case HttpStatusCode.Moved:
                    return DownloadLinkContent(result.Headers.Location).Result;
                default:
                    throw new CustomException($"Unexpected status code - {result.StatusCode}");
            }
        }

        private async Task<string> DownloadLinkContent(Uri uri)
        {
            var response = _httpApiBase.Get(uri.ToString());
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
