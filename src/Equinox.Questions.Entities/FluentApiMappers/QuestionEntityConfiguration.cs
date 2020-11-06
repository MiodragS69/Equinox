using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Equinox.Questions.Entities.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equinox.Questions.Entities.FluentApiMappers
{
    public class QuestionEntityConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            throw new NotImplementedException();
        }
    }
}
