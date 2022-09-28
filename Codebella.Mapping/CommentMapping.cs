using Codebella.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Mapping
{
    public class CommentMapping : BaseEntityMapping<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Content).IsRequired();
            builder.HasOne(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId);

            builder.HasOne(c => c.User).WithMany(a => a.Comments).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
