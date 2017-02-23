using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.Data
{
    public class DataContext : DbContext
    {
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<LocationPlace> LocationPlaces { get; set; }
        public DbSet<IncomeSource> IncomeSources { get; set; }
        public DbSet<ActiveType> ActiveTypes { get; set; }
        public DbSet<ActiveSpecificationType> ActiveSpecificationTypes { get; set; }
        public DbSet<ActiveSpecification> ActiveSpecifications { get; set; }
        public DbSet<MaterialActive> MaterialActives { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

           /* modelBuilder.Entity<MaterialActive>().HasRequired(f => f.OwnerPerson)
               .WithRequiredDependent()
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialActive>()
               .HasRequired(f => f.ResponsiblePerson)
               .WithRequiredDependent()
               .WillCascadeOnDelete(false);*/

        }
    }
}
