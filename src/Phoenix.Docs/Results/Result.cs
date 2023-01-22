namespace Phoenix.Docs.Results;

public class Result
{
    public bool Succees { get; set; }
}

public class Result<T> : Result
{
    public T Value { get; set; }
    
    public string? Error { get; set; }
}