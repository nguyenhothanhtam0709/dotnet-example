namespace DotnetExample.Core.Commons.HttpExceptions;

public class NotFoundHttpException : BaseHttpException
{
    public NotFoundHttpException(string message) : base(message, StatusCodes.Status404NotFound) { }
}