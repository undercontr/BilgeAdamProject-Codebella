using Codebella.Core.Utility.ResultType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Core.Utility.BusinessRules
{
    public static class CheckRules
    {
        public static IResult Run(params IResult[] rules)
        {
            foreach (var rule in rules)
            {
                if (!rule.Success)
                {
                    return rule;
                }
            }

            return new SuccessResult();
        }
    }
}
