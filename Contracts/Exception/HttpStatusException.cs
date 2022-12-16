using Contracts.Utils;

namespace Contracts.Exception
{
    public class HttpStatusException : System.Exception
    {
        public int StatusCode { get; set; }

        public HttpStatusException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusException(ExceptionPhrasesEnum message, int statusCode) : base(ExtensionMethodsUtil.GetDescription(message))
        {
            StatusCode = statusCode;
        }

        public HttpStatusException(ExceptionPhrasesEnum message) : base(ExtensionMethodsUtil.GetDescription(message))
        {
            StatusCode = (int) message;
        }
    }
}
