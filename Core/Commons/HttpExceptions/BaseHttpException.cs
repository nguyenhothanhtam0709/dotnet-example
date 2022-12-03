namespace DotnetExample.Core.Commons.HttpExceptions;

public class BaseHttpException : Exception
{
    public int HttpCode { get; set; }

    public BaseHttpException(string message, int httpCode) : base(message)
    {
        this.HttpCode = httpCode;
    }
}