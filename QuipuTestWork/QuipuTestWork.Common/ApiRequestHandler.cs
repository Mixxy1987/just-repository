using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using QuipuTestWork.Common.Exceptions;
using QuipuTestWork.Common.Properties;

namespace QuipuTestWork.Common
{
    public class ApiRequestHandler : DelegatingHandler
    {
        private const int RequestTimeout = 10000;

        public ApiRequestHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {}

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;
            try
            {
                var timeoutTask = Task.Delay(RequestTimeout).ContinueWith(t => { return new HttpResponseMessage(HttpStatusCode.RequestTimeout); });
                response = await Task.WhenAny(base.SendAsync(request, cancellationToken), timeoutTask).Result;
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException as WebException;
                if (inner == null)
                    throw;

                switch (inner.Status)
                {
                    case WebExceptionStatus.ProtocolError:
                        var resp = inner.Response as HttpWebResponse;
                        if (resp != null && resp.StatusCode == HttpStatusCode.GatewayTimeout)
                        {
                            throw new CustomException(ErrorMessages.ServerUnreachable);
                        }
                        throw;
                    case WebExceptionStatus.ConnectFailure:
                        throw new CustomException(ErrorMessages.ServerUnreachable);
                    case WebExceptionStatus.ConnectionClosed:
                        throw new CustomException(ErrorMessages.ServerDisconnected);
                    case WebExceptionStatus.Timeout:
                        throw new CustomException(ErrorMessages.TimeoutExpired);
                    case WebExceptionStatus.TrustFailure:
                        throw new CustomException(ErrorMessages.WrongServerCertificate);
                    case WebExceptionStatus.NameResolutionFailure:
                        throw new CustomException(ErrorMessages.NameResolutionFailure);
                    case WebExceptionStatus.ProxyNameResolutionFailure:
                        throw new CustomException(ErrorMessages.ProxyNameResolutionFailure);
                    default:
                        throw;
                }
            }

            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new CustomException(ErrorMessages.AuthFailed);
                case HttpStatusCode.ServiceUnavailable:
                    throw new CustomException(ErrorMessages.ServerUnreachable);
                case HttpStatusCode.Forbidden:
                    throw new CustomException(ErrorMessages.Forbidden);
                case HttpStatusCode.RequestTimeout:
                    throw new CustomException(ErrorMessages.TimeoutExpired);
                case HttpStatusCode.InternalServerError:
                    throw new CustomException(ErrorMessages.InternalServerError);
                case HttpStatusCode.BadRequest:
                    throw new CustomException(ErrorMessages.BadRequest);
                case HttpStatusCode.NotFound:
                    throw new CustomException(ErrorMessages.NotFound);
            }
            return response;
        }
    }
}
