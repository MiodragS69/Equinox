using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Equinox.Questions.Entities.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Equinox.Questions.Entities.Enums;

namespace Equinox.Questions.Entities.FluentApiMappers
{
    public class QuestionEntityConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(q => q.Id);            
            builder.HasQueryFilter(q => q.IsDeleted == false) ;
            builder.Property(q => q.Text)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(q => q.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(q => q.MultiAnswer)
                .HasDefaultValue(false);
            builder.Property(q => q.QuestionGrade)
                .HasDefaultValue(Grade.NoGrade);
            builder.Property(q => q.QuestionScope)
                .HasDefaultValue(Scope.NoScope);
        }
    }
}
