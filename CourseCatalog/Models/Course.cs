using System.ComponentModel.DataAnnotations.Schema;

namespace CourseCatalog.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        public string Title { get; set; }

        public byte[] CourseArt { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }
    }
}