namespace BeautySalon.Contracts.Exceptions;

public class ApiException : Exception
{
    public ApiException(string description, int statusCode)
    {
        Description = description;
        StatusCode = statusCode;
    }

    public ApiException()
    {
    }

    public int StatusCode { get; } = 500;

    public string Description { get; } = "Unhandled exception occured";

    public override string ToString()
    {
        return Description;
    }
}