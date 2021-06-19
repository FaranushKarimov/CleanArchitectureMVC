using DataAccessLayer.Models;
using DataAccessLayer.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace DataAccessLayer.ApplicationDbContext
{
    public partial class CFCDbContext : DbContext
    {
        public CFCDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> users { get; set; }
        public DbSet<UserRoles> userRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            base.OnModelCreating(modelbuilder);
            modelbuilder.Seed();
        }
    }
}
