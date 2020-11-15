using System;
using System.Collections.Generic;
using System.Text;
using Equinox.Questions.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinox.Questions.Entities.FluentApiMappers
{
    public class AnswerEntityConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Text)
                .IsRequired(true)
                .HasMaxLength(100);
            builder.Property(a => a.IsCorrect)
                .HasDefaultValue(false);            
        }
    }
}
