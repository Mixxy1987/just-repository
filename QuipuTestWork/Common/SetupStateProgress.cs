namespace Common
{
    public class SetupStateProgress
    {
        public string Message { get; }
        public int Percent { get; set; }

        public SetupStateProgress(string message) : this(message, 0)
        {}

        public SetupStateProgress(string message, int percent)
        {
            Message = message;
            Percent = percent;
        }
    }
}
