using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Core.Utility.ResultType
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(false, data)
        {
        }

        public ErrorDataResult(string message, T data) : base(false, message, data)
        {
        }
    }
}
