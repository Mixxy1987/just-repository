using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Common;
using QuipuTestWork.Models;

namespace QuipuTestWork.Common
{
    public interface IWebLoader
    {
        void Load(
            IList<string> fileContent,
            IUiContext context,
            ObservableCollection<LinkResult> linkResults,
            CancellationToken token, IProgress<SetupStateProgress> progress);
    }
}
