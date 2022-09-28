using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.DTOs
{
    public class DashboardArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string Tags { get; set; }
        public string Slug { get; set; }
    }
}
