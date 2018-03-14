using System.Collections.Generic;

namespace CourseCatalog.Entities
{
	public class Course
	{
		public Course()
		{
			CourseInstructor = new Instructor();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public double Duration { get; set; }
		public string Description { get; set; }

		public byte[] CourseArt { get; set; }
		public Instructor CourseInstructor { get; set; }
	}
}