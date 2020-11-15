using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Equinox.Questions.Entities.FluentApiMappers;
using Equinox.Common.Connection.Service;
using Equinox.Common.Connection.Interface;
using System.Reflection;

namespace Equinox.Questions.Entities.Model
{
    public class QuestionsContext : DbContext
    {        
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Explanation> Explanations { get; set; }
        public DbSet<AttachedImage> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // TODO: Connection string can be hard coded
            builder.UseSqlServer("Data Source=SABLJIC\\SQL17;Initial Catalog = Equinox;User=sa;Password=sa");
            // TODO: Connection string maybe can be read by service

        }
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
