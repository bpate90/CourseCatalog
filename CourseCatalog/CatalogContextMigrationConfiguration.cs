using System.Data.Entity.Migrations;

namespace CourseCatalog
{
	internal class CatalogContextMigrationConfiguration : DbMigrationsConfiguration<CatalogContext>
	{
		public CatalogContextMigrationConfiguration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

#if DEBUG
		protected override void Seed(CatalogContext context)
		{
			new CoursCatalogSeeder(context).Seed();
		}
#endif
	}
}