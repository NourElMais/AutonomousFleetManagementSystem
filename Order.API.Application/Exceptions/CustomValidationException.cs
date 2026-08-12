namespace Order.API.Application.Exceptions;

public class CustomValidationException : Exception
{
    public CustomValidationException(string message) : base(message)
    {
    }
}