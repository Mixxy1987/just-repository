namespace QuipuTestWork.Models
{
    public class LinkResult
    {
        public string Url { get; set; }
        public string Message { get; set; }
        public int Count { get; set; }
        public bool Max { get; set; }

        public LinkResult(string url, string message)
        {
            Url = url;
            Message = message;
            Count = 0;
        }

        public LinkResult(string url, int percent)
        {
            Url = url;
            Message = string.Empty;
            Count = percent;
        }
    }
}
