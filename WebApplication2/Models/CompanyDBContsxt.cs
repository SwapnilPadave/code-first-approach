using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
//using WebApplication2.Migrations;

namespace WebApplication2.Models
{
    public class CompanyDBContsxt:DbContext
    {
        public CompanyDBContsxt():base("MyConnectionString")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDBContsxt,Configuration>());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}