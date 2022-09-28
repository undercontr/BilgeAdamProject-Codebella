using Codebella.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Mapping
{
    public class ArticleMapping : BaseEntityMapping<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            base.Configure(builder);    

            builder.Property(a => a.Title).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Content).IsRequired();

            builder.HasOne(a => a.Author).WithMany(au => au.Articles).HasForeignKey(a => a.AuthorId);
            builder.HasMany(a => a.Likes).WithOne(l => l.Article).HasForeignKey(l => l.ArticleId);
            builder.HasMany(a => a.Comments).WithOne(c => c.Article).HasForeignKey(c => c.ArticleId);
        }
    }
}
