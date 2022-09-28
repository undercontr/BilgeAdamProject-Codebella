using Codebella.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Mapping
{
    public class CategoryMapping : BaseEntityMapping<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name).HasMaxLength(64).IsRequired();
            builder.HasMany(c => c.Articles).WithOne(a => a.Category).HasForeignKey(a => a.CategoryId);

            builder.HasData(
                new Category { Id = 1, Name = "C#", Slug = "csharp" },
                new Category { Id = 2, Name = "EntityFramework Core", Slug = "entityframework-core" },
                new Category { Id = 3, Name = "Javascript", Slug = "javascript" },
                new Category { Id = 4, Name = "CSS", Slug = "css" },
                new Category { Id = 5, Name = "HTML5", Slug = "html5" },
                new Category { Id = 6, Name = "Python", Slug = "python" },
                new Category { Id = 7, Name = "Next.js", Slug = "next-js" }
                );
        }
    }
}
