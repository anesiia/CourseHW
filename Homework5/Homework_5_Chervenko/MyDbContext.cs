using Homework_5_Chervenko.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_5_Chervenko
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=ANESIA;Database=LabolatoryDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
