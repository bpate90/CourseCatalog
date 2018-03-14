using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CourseCatalog.Entities;

namespace CourseCatalog.Mappers
{
	internal class InstructorMapper : EntityTypeConfiguration<Instructor>
	{
		public InstructorMapper()
		{
			ToTable("Instructors");

			HasKey(s => s.Id);
			Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(s => s.Id).IsRequired();

			Property(s => s.Email).IsRequired();
			Property(s => s.Email).HasMaxLength(255);
			Property(s => s.Email).IsUnicode(false);

			Property(s => s.UserName).IsRequired();
			Property(s => s.UserName).HasMaxLength(50);
			Property(s => s.UserName).IsUnicode(false);

			Property(s => s.Password).IsRequired();
			Property(s => s.Password).HasMaxLength(255);

			Property(s => s.FirstName).IsRequired();
			Property(s => s.FirstName).HasMaxLength(50);

			Property(s => s.LastName).IsRequired();
			Property(s => s.LastName).HasMaxLength(50);

			Property(s => s.Gender).IsOptional();
		}
	}
}