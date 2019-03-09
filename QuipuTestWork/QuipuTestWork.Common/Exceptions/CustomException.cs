using System;

namespace QuipuTestWork.Common.Exceptions
{
    public class CustomException : Exception
    {
        public string UserMessage { get; private set; }

        public CustomException(string message) : base(message)
        {
            UserMessage = message;
        }

        public CustomException(string message, string userMessage) : base(message)
        {
            UserMessage = userMessage;
        }

        public override string ToString()
        {
            return UserMessage;
        }
    }
}
