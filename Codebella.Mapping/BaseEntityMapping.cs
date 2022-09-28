using Codebella.Core.Entity.Abstract;
using Codebella.Core.Entity.Concrete;
using Codebella.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebella.Mapping
{
    public class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(a => a.Status).IsRequired();

            builder.HasQueryFilter(b => b.Status == Status.Approved);
        }
    }
}
