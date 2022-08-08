using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MUIManagement.Infrastructure.Database.Entities;

namespace MUIManagement.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<RentalEntity> Rentals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
