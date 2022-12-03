using DotnetExample.Core.Commons.Messages;

namespace DotnetExample.Core.Commons.HttpExceptions;

public class InternalServerErrorHttpExeption : BaseHttpException
{
    public InternalServerErrorHttpExeption() : base(HttpMessage.InternalServerError, StatusCodes.Status500InternalServerError) { }
}