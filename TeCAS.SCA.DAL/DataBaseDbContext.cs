using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TeCAS.SCA.Entities;
using TeCAS.SCA.Helpers;

namespace TeCAS.SCA.DAL
{
    public class DataBaseDbContext : DbContext
    {
        public DataBaseDbContext() { }

        public DataBaseDbContext(DbContextOptions<DataBaseDbContext> options)
            : base(options) { }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = HelperConfiguration.GetAppConfiguration().ConnectionString;
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
