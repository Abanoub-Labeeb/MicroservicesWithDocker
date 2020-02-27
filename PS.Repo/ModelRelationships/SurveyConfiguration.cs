using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data
{
    //Model configuration folder exists only if you decided 
    //to use EF as the FW to deal with DB
    //to build the relationship between models using fluent API
    //then Add the next configuration to the DBContext >> OnModelCreating(DbModelBuilder modelBuilder)
    //And Use the next Line modelBuilder.Configurations.Add(new SurveyConfiguration());

    //either use fluent API or use the annotation and convension naming on the models
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.HasMany<Model>(s => s.Models)
           .WithOne(m => m.Survey)
           .HasForeignKey(m => m.SurveyId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
