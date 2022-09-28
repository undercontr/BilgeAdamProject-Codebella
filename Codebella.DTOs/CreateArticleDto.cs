using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.DTOs;

public class CreateArticleDto
{
    public string Email { get; set; }
    public string Nickname { get; set; }
    public IEnumerable<CategoryDto> Categories { get; set; }
    public string? StatusMessage { get; set; }
}
