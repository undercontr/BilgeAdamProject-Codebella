using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Core.Utility.ResultType
{
    public class Result : IResult
    {
        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
            Message = null;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
