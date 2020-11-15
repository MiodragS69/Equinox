using System;
using System.Collections.Generic;
using System.Text;
using Equinox.Questions.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinox.Questions.Entities.FluentApiMappers
{
    public class AttachedImageEntityConfiguration : IEntityTypeConfiguration<AttachedImage>
    {
        public void Configure(EntityTypeBuilder<AttachedImage> builder)
        {
            builder.ToTable("Images");
            builder.HasKey(i => i.Id);            
        }
    }
}
