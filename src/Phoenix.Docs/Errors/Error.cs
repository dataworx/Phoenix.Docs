namespace Phoenix.Docs.Errors;

public class Error
{
    public string ErrorMessage { get; }

    public ErrorCode ErrorCode { get; }
    
    public Error(ErrorCode errorCode, string errorMessage)
    {
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
    }

    public override string ToString() => ErrorMessage;
}