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
    public class AuthorMapping : BaseEntityMapping<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.Nickname).HasMaxLength(64).IsRequired();
            builder.Property(a => a.FullName).HasMaxLength(128);

            builder.HasMany(ar => ar.Articles).WithOne(au => au.Author).HasForeignKey(au => au.AuthorId);
        }
    }
}
