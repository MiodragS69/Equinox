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
            throw new NotImplementedException();
        }
    }
}
