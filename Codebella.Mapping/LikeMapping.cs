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
    public class LikeMapping : BaseEntityMapping<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            base.Configure(builder);

            builder.HasOne(l => l.Owner).WithMany().HasForeignKey(l => l.OwnerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(l => l.Article).WithMany(a => a.Likes).HasForeignKey(l => l.ArticleId);
        }
    }
}
