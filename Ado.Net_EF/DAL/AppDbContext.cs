using Ado.Net_EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ado.Net_EF.DAL
{
    class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-NH7SON4\SQLEXPRESS; Initial Catalog = AP204CodeFirstEF; Integrated Security = SSPI");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<DeletedStudent> DeletedStudents { get; set; }

    }
}
