using Microsoft.EntityFrameworkCore;
using MVC_ViewModels_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ViewModels_Data.Data
{
    public class ExDbContext : DbContext
    {
        public ExDbContext(DbContextOptions<ExDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Person priya = new Person() { PersonId = 1, Name = "Priya", ContactNumber = "034-4242-657", City = "Kurnool" };
            Person Keerthi = new Person() { PersonId = 2, Name = "Keerthi", ContactNumber = "034-4242-658", City = "Kurnool" };
            modelBuilder.Entity<Person>().HasData(priya, Keerthi);
        }
        public DbSet<Person> Person { get; set; }
    }
}
