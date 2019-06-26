using Microsoft.EntityFrameworkCore;
using L34_C02_working_with_ef_core_final.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace L34_C02_working_with_ef_core_final.Data
{
	public class OnlineStoreContext : DbContext
	{
		private readonly string _connectionString;

        public static readonly LoggerFactory MyConsoleLoggerFactory =
            new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider(
                    (category, level) => category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information,
                    true)
            });

		public DbSet<Product> Products { get; set; }

		public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

		public OnlineStoreContext()
		{
			_connectionString =
				@"Data Source=localhost\SQLEXPRESS;" +
				"Initial Catalog=OnlineStoreEF2;" +
				"Integrated Security=true;";
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(_connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder
                .Entity<Customer>()
                    .HasIndex(p => p.Name)
                    .IsUnique();

			modelBuilder
				.Entity<OrderItem>()
					.HasKey("OrderId", "ProductId")
					.HasName("PK_OrderItems")
					.ForSqlServerIsClustered(true);
		}
	}
}
