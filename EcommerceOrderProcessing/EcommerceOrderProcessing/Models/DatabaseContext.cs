using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EcommerceOrderProcessing.Models
{
    public class DatabaseContext: DbContext
    {
        public DbSet<items> items { get; set; }
        public DbSet<orderdetails> orderdetails { get; set; }
        public DbSet<orders> orders { get; set; }
        public DbSet<payment> payment { get; set; }
        public DbSet<shipping> shipping { get; set; }

        private string DefaultConnection = "server=localhost; port=3306; database=ecommmerceorderprocessing; user=root; password=root1234";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(DefaultConnection);
        }
    }
}
