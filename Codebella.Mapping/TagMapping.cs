using Codebella.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Mapping
{
    public class TagMapping : BaseEntityMapping<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Name).HasMaxLength(64).IsRequired();
            builder.HasIndex(t => t.Name).IsUnique();

            // Article-Tags model içerisinde ki ayar kullanılacak
        }
    }
}
