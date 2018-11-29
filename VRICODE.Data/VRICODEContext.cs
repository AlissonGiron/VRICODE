using Microsoft.EntityFrameworkCore;
using System;
using VRICODE.Data.Mapping;
using VRICODE.Models;

namespace VRICODE.Data
{
    public class VRICODEContext : DbContext
    {
        public VRICODEContext(DbContextOptions<VRICODEContext> options) : base(options) { }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<ProblemClass> ProblemClasses { get; set; }
        public DbSet<ProblemTest> ProblemTests { get; set; }
        public DbSet<ProblemUser> ProblemUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserClass> UserClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClassMap());
            modelBuilder.ApplyConfiguration(new ProblemClassMap());
            modelBuilder.ApplyConfiguration(new ProblemMap());
            modelBuilder.ApplyConfiguration(new ProblemTestMap());
            modelBuilder.ApplyConfiguration(new ProblemUserMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserClassMap());
        }
    }
}
