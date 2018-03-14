using System.Data.Entity;
using CourseCatalog.Entities;
using CourseCatalog.Mappers;

namespace CourseCatalog
{
	public class CatalogContext : DbContext
	{
		public CatalogContext() : base("CourseCatolog")
		{
			Configuration.ProxyCreationEnabled = false;
			Configuration.LazyLoadingEnabled = false;

			Database.SetInitializer(new MigrateDatabaseToLatestVersion<CatalogContext, CatalogContextMigrationConfiguration>());
		}

		public DbSet<Course> Courses { get; set; }

		public DbSet<Instructor> Instructors { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new InstructorMapper());
			modelBuilder.Configurations.Add(new CourseMapper());

			base.OnModelCreating(modelBuilder);
		}
	}
}