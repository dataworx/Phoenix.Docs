using System.Collections.Generic;

namespace Phoenix.Docs
{
    public class Result
    {
        #region Constructors

        protected Result(bool success, string? error)
        {
            this.Errors = new List<string>();
            Success = success;
            if (error != null)
            {
                Errors.Add(error);
            }
        }

        #endregion

        public bool Success { get; }

        public IList<string> Errors { get; }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result Fail(string? error)
        {
            return new Result(false, error);
        }
    }

    public class Result<T> : Result
    {
        #region Constructors

        protected Result(bool success, string? error, T value) : base(success, error)
        {
            Value = value;
        }

        #endregion

        public T Value { get; }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(true, null, value);
        }

        public new static Result<T> Fail(string? error)
        {
            return new Result<T>(false, error, default);
        }
    }
}