using PostApp.Application.Common.Enums;

namespace PostApp.Application.Common.Models;

public class ErrorMessage
{
    public ErrorMessage(string message, ErrorTypeEnum errorType)
    {
        Message = message;
        ErrorType = errorType;
    }
    public string Id { get; set; }
    public string Message { get; set; }
    public ErrorTypeEnum ErrorType { get; set; }

}