using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Education.DataAccessLayer
{
    // The annotation attributes could be removed from the class to keep it simpler, and replaced with an equivalent Fluent API statement in the OnModelCreating method of the database context class.
    public class Student
    {
        public Student()
        {
            Courses = new List<Course>();
        }

        [Key]
        public int StudentID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int AddressID { get; set; }
        public Address? Address { get; set; }

        public string Contactgegeven { get; set; } = string.Empty;

        // To use Eager overloading we need to make this virtual and do some other things.
        // Using Eager overloading we can use the DbSet Include method.
        public List<Course> Courses { get; set; }

        // Andere naam gekozen voor kolom in tabel
        [Column("Vaardigheden")]
        public string? StudySkills { get; set; }
    }
}
