using System.Collections.Generic;
using CourseCatalog.Enums;

namespace CourseCatalog.Entities
{
	public class Instructor
	{
		public ICollection<Course> Courses;

		public Instructor()
		{
			Courses = new List<Course>();
		}

		public int Id { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Gender Gender { get; set; }
	}
}