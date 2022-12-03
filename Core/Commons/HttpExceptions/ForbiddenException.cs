using DotnetExample.Core.Commons.Messages;

namespace DotnetExample.Core.Commons.HttpExceptions;

public class ForbiddenException : BaseHttpException
{
    public ForbiddenException() : base(HttpMessage.Forbidden, StatusCodes.Status403Forbidden) { }
}