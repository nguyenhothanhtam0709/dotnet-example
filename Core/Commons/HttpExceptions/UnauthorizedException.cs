using DotnetExample.Core.Commons.Messages;

namespace DotnetExample.Core.Commons.HttpExceptions;

public class UnauthorizedException : BaseHttpException
{
    public UnauthorizedException() : base(HttpMessage.Unauthorized, StatusCodes.Status401Unauthorized) { }
}