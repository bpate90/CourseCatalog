using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CourseCatalog.Entities;

namespace CourseCatalog.Mappers
{
	internal class CourseMapper : EntityTypeConfiguration<Course>
	{
		public CourseMapper()
		{
			ToTable("Courses");

			HasKey(c => c.Id);
			Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(c => c.Id).IsRequired();

			Property(c => c.Name).IsRequired();
			Property(c => c.Name).HasMaxLength(255);

			Property(c => c.Duration).IsRequired();

			Property(c => c.Description).IsOptional();
			Property(c => c.Description).HasMaxLength(1000);

			HasRequired(c => c.CourseInstructor).WithMany().Map(t => t.MapKey("InstructorID"));
		}
	}
}