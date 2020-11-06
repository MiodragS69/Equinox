using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Equinox.Questions.Entities.FluentApiMappers;
using System.Reflection;

namespace Equinox.Questions.Entities.Model
{
    public class QuestionsContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuestionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExplanationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AttachedImageEntityConfiguration());

            // TODO: Replace registrations above with
            // TODO: This will find all that implements IEntityTypeConfiguration and register them (!!)
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
    }
}
