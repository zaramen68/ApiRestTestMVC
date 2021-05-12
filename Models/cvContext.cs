using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestTestMVC.Models
{
    public class cvContext : DbContext
    {
        public cvContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<CodeValue> CodeValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=codedb;Trusted_Connection=True;");
        }


    }
}
