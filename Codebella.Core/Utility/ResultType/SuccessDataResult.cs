using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Core.Utility.ResultType;

public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult(T data) : base(true, data)
    {
    }

    public SuccessDataResult(string message, T data) : base(true, message, data)
    {
    }
}
