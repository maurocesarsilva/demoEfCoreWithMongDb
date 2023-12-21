using crudMongo.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace crudMongo.DataBase
{
	public class Context(DbContextOptions<Context> options) : DbContext(options)
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Movie>().ToCollection("movies");
		}

		public DbSet<Movie> Movie { get; set; }
	}
}
