using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserArtStudio.Application.Common.Models
{
    public class Result<T> : Result
    {
        public T? Data { get; init; }

        public static Result<T> Ok(
            T data,
            string message = "")
        {
            return new Result<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public new static Result<T> Failure(
            string message,
            Dictionary<string, string[]>? errors = null)
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Errors = errors
            };
        }
    }
}
