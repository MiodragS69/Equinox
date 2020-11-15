using System;
using System.Collections.Generic;
using System.Text;
using Equinox.Questions.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinox.Questions.Entities.FluentApiMappers
{
    public class ExplanationEntityConfiguration : IEntityTypeConfiguration<Explanation>
    {
        public void Configure(EntityTypeBuilder<Explanation> builder)
        {
            builder.ToTable("Explanations");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Text)
                .HasMaxLength(1000);
        }
    }
}
