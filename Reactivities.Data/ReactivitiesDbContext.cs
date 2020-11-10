using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reactivities.Core.Entities;
namespace Reactivities.Data
{
    public class ReactivitiesDbContext : DbContext
    {
        public ReactivitiesDbContext(DbContextOptions<ReactivitiesDbContext> options) : base(options)
        {
            
        }

        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            
        }
    }
}
