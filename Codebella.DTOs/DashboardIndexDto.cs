using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.DTOs
{
    public class DashboardIndexDto
    {
        public IEnumerable<DashboardArticleDto> Articles { get; set; }
    }
}
