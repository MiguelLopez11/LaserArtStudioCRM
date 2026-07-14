using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserArtStudio.Application.Common.Models
{
    public class Result
    {
        public bool Success { get; init; }

        public string Message { get; init; } = string.Empty;

        public Dictionary<string, string[]>? Errors { get; init; }

        public static Result Ok(string message = "")
        {
            return new Result
            {
                Success = true,
                Message = message
            };
        }

        public static Result Failure(
            string message,
            Dictionary<string, string[]>? errors = null)
        {
            return new Result
            {
                Success = false,
                Message = message,
                Errors = errors
            };
        }
    }
}
