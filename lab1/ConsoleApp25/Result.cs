using System;

namespace ConsoleApp25
{
    public class Result
    {
        public bool IsSuccess { get; }
        public TimeSpan Value { get; }

        private Result(TimeSpan value)
        {
            IsSuccess = true;
            Value = value;
        }

        private Result()
        {
            IsSuccess = false;
            Value = default;
        }

        public static Result Success(TimeSpan value) => new Result(value);
        public static Result Failure() => new Result();
    }
}