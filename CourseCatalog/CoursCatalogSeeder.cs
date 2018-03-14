using System;
using System.Collections.Generic;
using System.Linq;
using CourseCatalog.Entities;
using CourseCatalog.Enums;

namespace CourseCatalog
{
	internal class CoursCatalogSeeder
	{
		private static readonly string[] InstructorNames =
		{
			"Dalton,Waylon,Male,outlook.com",
			"Henderson,Justine,Female,mymail.com",
			"Hugginkiss,Amanda,Female,mymail.com",
			"Wislon,Owen,Male,outlook.com",
			"Alba,Jessica,Female,mymail.com",
			"Nisreen,Wesam,Female,hotmail.com"
		};

		private static readonly IList<CoursesSeed> CoursesSeedData = new List<CoursesSeed>
		{
			new CoursesSeed {SubjectId = 1, CourseName = "History Teaching Methods 1"},
			new CoursesSeed {SubjectId = 1, CourseName = "History Teaching Methods 2"},
			new CoursesSeed {SubjectId = 1, CourseName = "History Teaching Methods 3"},

			new CoursesSeed {SubjectId = 2, CourseName = "Professional Experience 1 (Mathematics/Science)"},
			new CoursesSeed {SubjectId = 2, CourseName = "Professional Experience 2 (Mathematics/Science)"},
			new CoursesSeed {SubjectId = 2, CourseName = "Professional Experience 3 (Mathematics/Science)"},

			new CoursesSeed {SubjectId = 3, CourseName = "Geography Teaching Methods 1"},
			new CoursesSeed {SubjectId = 3, CourseName = "Geography Teaching Methods 2"},
			new CoursesSeed {SubjectId = 3, CourseName = "Geography Teaching Methods 3"},

			new CoursesSeed {SubjectId = 4, CourseName = "English Education 1"},
			new CoursesSeed {SubjectId = 4, CourseName = "English Education 2"},
			new CoursesSeed {SubjectId = 4, CourseName = "English Education 3"},
			new CoursesSeed {SubjectId = 4, CourseName = "English Teaching Methods 1"},
			new CoursesSeed {SubjectId = 4, CourseName = "English Teaching Methods 2"},

			new CoursesSeed {SubjectId = 5, CourseName = "Commerce, Business Studies and Economics Teaching Methods 1"},
			new CoursesSeed {SubjectId = 5, CourseName = "Commerce, Business Studies and Economics Teaching Methods 2"},
			new CoursesSeed {SubjectId = 5, CourseName = "Commerce, Business Studies and Economics Teaching Methods 3"},

			new CoursesSeed {SubjectId = 6, CourseName = "Computing Studies Teaching Methods 1"},
			new CoursesSeed {SubjectId = 6, CourseName = "Computing Studies Teaching Methods 2"},
			new CoursesSeed {SubjectId = 6, CourseName = "Computing Studies Teaching Methods 3"},

			new CoursesSeed {SubjectId = 7, CourseName = "Human Resource Development in Organisations"},
			new CoursesSeed {SubjectId = 7, CourseName = "Human Resources and Organisational Development"},

			new CoursesSeed {SubjectId = 8, CourseName = "Mathematics Teaching and Learning 1"},
			new CoursesSeed {SubjectId = 8, CourseName = "Mathematics Teaching and Learning 2"},
			new CoursesSeed {SubjectId = 8, CourseName = "Mathematics Teaching Methods 1"},
			new CoursesSeed {SubjectId = 8, CourseName = "Mathematics Teaching Methods 2"},

			new CoursesSeed {SubjectId = 9, CourseName = "Music Study 1"},
			new CoursesSeed {SubjectId = 9, CourseName = "Music Therapy 1"},
			new CoursesSeed {SubjectId = 9, CourseName = "Music, Movement and Dance"},

			new CoursesSeed {SubjectId = 10, CourseName = "Personal Development, Health and Physical Education 1"},
			new CoursesSeed
			{
				SubjectId = 10,
				CourseName = "Personal Development, Health and Physical Education Teaching Methods 1"
			},
			new CoursesSeed
			{
				SubjectId = 10,
				CourseName = "Personal Development, Health and Physical Education Teaching Methods 2"
			}
		};

		private readonly CatalogContext _context;

		public CoursCatalogSeeder(CatalogContext context)
		{
			_context = context;
		}

		public void Seed()
		{
			if (_context.Courses.Any())
				return;

			try
			{
				foreach (var name in InstructorNames)
				{
					var nameGenderMail = SplitValue(name);
					var instructor = new Instructor
					{
						Email = string.Format($"{nameGenderMail[0]}.{nameGenderMail[1]}@{nameGenderMail[3]}"),
						UserName = $"{nameGenderMail[0]}{nameGenderMail[1]}",
						Password = RandomString(8),
						FirstName = nameGenderMail[0],
						LastName = nameGenderMail[1],
						Gender = (Gender) Enum.Parse(typeof(Gender), nameGenderMail[2])
					};

					_context.Instructors.Add(instructor);

					foreach (var courseDataItem in CoursesSeedData)
					{
						var course = new Course
						{
							Name = courseDataItem.CourseName,
							CourseInstructor = instructor,
							Duration = new Random().Next(3, 6),
							Description = $"The course will talk in depth about: {courseDataItem.CourseName}"
						};
						_context.Courses.Add(course);
					}
				}

				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				var message = ex.ToString();
				throw ex;
			}
		}

		private static string[] SplitValue(string val)
		{
			return val.Split(',');
		}

		private string RandomString(int size)
		{
			var rng = new Random((int) DateTime.Now.Ticks);
			var buffer = new char[size];

			for (var i = 0; i < size; i++)
				buffer[i] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[rng.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length)];
			return new string(buffer);
		}

		private class CoursesSeed
		{
			public int SubjectId { get; set; }
			public string CourseName { get; set; }
		}
	}
}