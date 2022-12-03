namespace DotnetExample.Core.Commons.HttpExceptions;

public class BadRequestHttpException : BaseHttpException
{
    public BadRequestHttpException(string message) : base(message, StatusCodes.Status400BadRequest) { }
}