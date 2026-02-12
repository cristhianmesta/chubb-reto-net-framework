using System.Collections.Generic;

namespace ChubbReto.Application.Shared
{
    public class Result<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public IEnumerable<string> Errors { get; private set; }
        public T Data { get; private set; }

        public static Result<T> Ok(T data, string message = null)
            => new Result<T> { Success = true, Data = data, Message = message };

        public static Result<T> Fail(IEnumerable<string> errors)
            => new Result<T> { Success = false, Errors = errors };

        public static Result<T> Fail(string error)
            => new Result<T> { Success = false, Errors = new[] { error } };
    }
}
