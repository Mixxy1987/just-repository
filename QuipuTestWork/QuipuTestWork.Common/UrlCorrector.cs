using System;
using System.Text.RegularExpressions;

namespace QuipuTestWork.Common
{
    public static class UrlCorrector
    {
        private const string httpPrefix = "http://";
        private const string httpsPrefix = "https://";

        public static string FixUrl(string value)
        {
            string fixedUrl;
            if (string.IsNullOrEmpty(value) 
                || value.StartsWith(httpPrefix)
                || value.StartsWith(httpsPrefix))
            {
                return value;
            }
            value = value.TrimStart('/');
            if (value.Contains("//"))
            {
                fixedUrl = Regex.Replace(value, "^(.)*//", httpsPrefix);
            }
            else if (value.Contains(":/"))
            {
                fixedUrl = Regex.Replace(value, "^(.)*:/", httpsPrefix);
            }
            else
            {
                fixedUrl = httpsPrefix + value;
            }
            return fixedUrl;
        }
    }
}
