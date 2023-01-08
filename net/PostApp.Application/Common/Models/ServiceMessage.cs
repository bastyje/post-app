namespace PostApp.Application.Common.Models;

public class ServiceMessage
{
    public ServiceMessage()
    {
        ErrorMessages = new List<ErrorMessage>();
    }
    public List<ErrorMessage> ErrorMessages { get; set; }
    public bool Success => ErrorMessages is null || ErrorMessages.All(e => e.ErrorType != Enums.ErrorTypeEnum.Error);
}

public class ServiceMessage<T> : ServiceMessage
{
    public T Content { get; set; }
}