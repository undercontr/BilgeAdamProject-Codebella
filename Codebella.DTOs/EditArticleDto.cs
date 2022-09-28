using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.DTOs
{
    public class EditArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? StatusMessage { get; set; }
        public CategoryDto Category { get; set; }
        public IEnumerable<TagDto> Tags { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
