using Phoenix.Docs.Errors;
using System.Collections.Generic;

namespace Phoenix.Docs
{
    public class Result
    {
        #region Constructors

        protected Result(bool success, Error? error)
        {
            this.Errors = new List<Error>();
            Success = success;
            if (error != null)
            {
                Errors.Add(error);
            }
        }

        #endregion

        public bool Success { get; }

        public IList<Error> Errors { get; }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result Fail(Error? error)
        {
            return new Result(false, error);
        }
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
            return new Result<T>(false, error, default);
        }
    }
}