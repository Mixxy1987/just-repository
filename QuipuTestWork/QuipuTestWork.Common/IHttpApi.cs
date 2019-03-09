using System.Threading;

namespace QuipuTestWork.Common
{
    public interface IHttpApi
    {
        string GetLinkAndDownload(CancellationToken token, string url);
    }
}
