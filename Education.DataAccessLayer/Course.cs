using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Education.DataAccessLayer
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        public string Description { get; set; } = string.Empty;

        [StringLength(100)]
        public string Location { get; set; } = string.Empty;

        // Hier bepaal ik het type van de database kolom.
        [Column(TypeName = "datetime")]
        public DateTime? StartTime { get; set; }

        public int StudentID { get; set; }
        public int TeacherID { get; set; }

        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; }
    }
}