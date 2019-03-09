using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using Common;
using QuipuTestWork.Models;

namespace QuipuTestWork.Common
{
    public class WebLoader : IWebLoader
    {
        private const string _pattern = "<(a|link).*?href=(\"|')(.+?)(\"|').*?>";
        private readonly HttpApi _httpApi;

        public WebLoader(HttpApi httpApi)
        {
            _httpApi = httpApi;
        }

        public void Load(
            IList<string> fileContent,
            IUiContext context,
            CustomObsCollection<LinkResult> linkResults,
            CancellationToken token, IProgress<SetupStateProgress> progress)
        {
            Regex r = new Regex(_pattern);
            int max = 0;
            for (int i = 0; i < fileContent.Count; ++i)
            {
                int tmp = i;
                try
                {
                    var result = _httpApi.GetLinkAndDownload(token, UrlCorrector.FixUrl(fileContent[tmp]));
                    var collection = r.Matches(result);
                    token.ThrowIfCancellationRequested();
                    max = Math.Max(max, collection.Count);
                    context?.BeginInvoke(() => linkResults.Add(new LinkResult(fileContent[tmp], collection.Count)));
                    context?.BeginInvoke(() => UpdateCollection(context, linkResults, max));
                }
                catch (Exception e)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    string message = e.InnerException?.Message ?? e.Message;
                    context?.BeginInvoke(() => linkResults.Add(new LinkResult(fileContent[tmp], message)));
                }
                progress?.Report(new SetupStateProgress(fileContent[tmp], ((tmp + 1) * 100 / fileContent.Count)));
            }
        }

        private void UpdateCollection(IUiContext context, CustomObsCollection<LinkResult> linkResults, int max)
        {
            for (int j = 0; j < linkResults.Count; ++j)
            {
                linkResults[j].Max = linkResults[j].Count == max;
            }
            linkResults.UpdateCollection();
        }
    }
}
