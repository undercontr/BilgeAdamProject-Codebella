using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.DTOs
{
    public class SingleArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorNickname { get; set; }
        public string ArticleUserEmail { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public string Slug { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public IEnumerable<TagDto> Tags { get; set; }

        public int UserId { get; set; }
        public bool IsLiked { get; set; }
        public int LikeId { get; set; }
        public bool IsMyArticle { get; set; }
    }
}
