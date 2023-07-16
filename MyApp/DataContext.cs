using Microsoft.EntityFrameworkCore;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    public class DataContext :DbContext
    {
        
        public DbSet<Users> Dbusers { get; set; }

        public DbSet<Module> Dbmodules { get; set; }
        public DbSet<Students> Dbstudnets { get; set; }

        public DbSet<Results> Dbresults { get; set; }

        public DbSet<ModuleStudent> DbmoduleStudents { get; set; }




        private readonly string dbPath = @"C:\Users\Ishara Rajapaksha\Downloads\GroupFinal002\MyApp.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={dbPath}");

      
    }
}
