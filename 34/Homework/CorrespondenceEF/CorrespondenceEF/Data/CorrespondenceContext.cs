using CorrespondenceEF.Domain;
using Microsoft.EntityFrameworkCore;

namespace CorrespondenceEF.Data
{
	public class CorrespondenceContext : DbContext
	{
		private string _connectionString;

		public DbSet<Address> Addresses { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Contractor> Contractors { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<PostalItem> PostalItems { get; set; }
		public DbSet<SendingStatus> SendingStatuses { get; set; }
		public DbSet<Status> Statuses { get; set; }

		public CorrespondenceContext()
		{
			_connectionString =
				@"Data Source=localhost\SQLEXPRESS;" +
				"Initial Catalog=CorrespondenceEF;" +
				"Integrated Security=true;";
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder
				.Entity<SendingStatus>()
				.HasKey(
					"PostalItemId",
					"UpdateStatusDateTime",
					"StatusId",
					"SendingContractorId",
					"SendingAddressId",
					"RecievingContractorId",
					"RecievingAddressId");
		}
	}
}
