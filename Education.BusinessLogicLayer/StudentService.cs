using Education.DataAccessLayer;
using Education.DataAccessLayer.Repositories;

namespace Education.BusinessLogicLayer
{
    public class StudentService
    {
        private AddressRepository _addressRepository;
        private CourseRepository _courseRepository;
        private StudentRepository _studentRepository;
        private TeacherRepository _teacherRepository;

        public StudentService()
        {
            EducationDbContext dbContext = new EducationDbContext();
            MakeRepositories(dbContext);
        }

        public StudentService(EducationDbContext dbContext)
        {
            MakeRepositories(dbContext);
        }

        private void MakeRepositories(EducationDbContext dbContext)
        {
            _addressRepository = new AddressRepository(dbContext);
            _courseRepository = new CourseRepository(dbContext);
            _studentRepository = new StudentRepository(dbContext);
            _teacherRepository = new TeacherRepository(dbContext);
        }

        private Address AddAddress(string land, string stad, string straat, string huisnummer)
        {
            // Object Initializer Syntax
            Address address = new Address()
            {
                Country = land,
                City = stad,
                Street = straat,
                HouseNumber = huisnummer
            };
            _addressRepository.Insert(address);
            _addressRepository.Save();
            return address;
        }

        public void AddStudent(string naam, string contactgegeven, string land, string stad, string straat, string huisnummer)
        {
            Address address = AddAddress(land, stad, straat, huisnummer);

            Student student = new Student();
            student.Name = naam;
            student.Contactgegeven = contactgegeven;
            student.AddressID = address.AddressID;
            _studentRepository.Insert(student);
            _studentRepository.Save();
        }

        public void DeleteStudent(string naam)
        {
            // Here I give an example of using Linq.
            var students = _studentRepository.GetAll().Where(p => p.Name == naam);

            foreach (var p in students)
            {
                _studentRepository.DeleteById(p.StudentID);
                _addressRepository.DeleteById(p.AddressID);
                _studentRepository.Save();
                _addressRepository.Save();
            }
        }

        public List<CourseItem> ShowCourseForStudent(string naam)
        {
            List<CourseItem> list = new List<CourseItem>();
            var allCourses = _courseRepository.GetAll();

            foreach (var course in allCourses)
            {
                Teacher? teacher = _teacherRepository.GetById(course.TeacherID);
                Student? student = _studentRepository.GetById(course.StudentID);

                if (teacher != null && student != null && student.Name == naam)
                {
                    CourseItem item = new CourseItem();
                    item.Description = course.Description;
                    item.StudentName = student.Name;
                    item.TeacherName = teacher.Name;
                    list.Add(item);
                }
            }
            return list;
        }
    }
}