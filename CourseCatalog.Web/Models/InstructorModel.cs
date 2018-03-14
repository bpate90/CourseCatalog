using CourseCatalog.Enums;

namespace CourseCatalog.Web.Models
{
	public class InstructorModel
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Gender Gender { get; set; }
	}
}