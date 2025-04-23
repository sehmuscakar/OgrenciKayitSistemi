using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class ProjeContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // ovveride on yaz gerisi gelir
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;  database=OgrenciKayitSitemiMVC; integrated security=true; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
