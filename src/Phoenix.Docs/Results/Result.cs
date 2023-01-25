using Phoenix.Docs.Errors;

namespace Phoenix.Docs.Results;

public class Result
{
    #region Constructors
    
    protected Result(bool success, Error? error)
    {
        Success = success;
        Error = error;
    } 
    
    #endregion

    public bool Success { get; }

    public Error? Error { get; }
}

public class Result<T> : Result
{
    #region Constructors

    protected Result(bool success, Error? error, T value) : base(success, error)
    {
        Value = value;
    } 
    
    #endregion

    public T Value { get; }
    
    public static Result<T> Ok(T value)
    {
        return new Result<T>(true, null, value);
    }

    public static Result<T> Fail(Error? error)
    {
        return new Result<T>(false, error, default(T));
    }
}