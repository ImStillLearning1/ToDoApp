using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.DbContexts
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public DbSet<User> Users { get; set; }
		public DbSet<Scheduler> Schedulers { get; set; }
		public DbSet<Duty> Duties { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Event> Events { get; set; }
	}
}
