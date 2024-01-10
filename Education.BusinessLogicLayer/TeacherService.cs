using Education.DataAccessLayer;
using Education.DataAccessLayer.Repositories;

namespace Education.BusinessLogicLayer
{
    // We could create Unit Test projects parallel to the existing projects, for example, named Chipsoft.BusinessLogicLayer.Test
    public class TeacherService : ITeacherService
    {
        private AddressRepository _addressRepository;
        private CourseRepository _courseRepository;
        private StudentRepository _studentRepository;
        private TeacherRepository _teacherRepository;

        public TeacherService()
        {
            EducationDbContext dbContext = new EducationDbContext();
            MakeRepositories(dbContext);
        }

        public TeacherService(EducationDbContext dbContext)
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
            Address address = new Address();
            address.Country = land;
            address.City = stad;
            address.Street = straat;
            address.HouseNumber = huisnummer;
            _addressRepository.Insert(address);
            _addressRepository.Save();
            return address;
        }

        public void AddTeacher(string naam, string land, string stad, string straat, string huisnummer)
        {
            Address address = AddAddress(land, stad, straat, huisnummer);

            Teacher teacher = new Teacher();
            teacher.Name = naam;
            teacher.AddressID = address.AddressID;
            _teacherRepository.Insert(teacher);
            _teacherRepository.Save();
        }

        public void DeleteTeacher(string naam)
        {
            var teachers = _teacherRepository.GetAll();

            foreach (var p in teachers)
            {
                if (p.Name == naam)
                {
                    _teacherRepository.DeleteById(p.TeacherID);
                    _addressRepository.DeleteById(p.AddressID);
                    _teacherRepository.Save();
                    _addressRepository.Save();
                }
            }
        }

        public void AddCourse(string naamTeacher, string naamStudent, string beschrijving)
        {
            var teachers = _teacherRepository.GetAll();
            Teacher? teacher = null;
            foreach (var p in teachers)
            {
                if (p.Name == naamTeacher)
                {
                    teacher = p;
                }
            }

            var students = _studentRepository.GetAll();
            Student? student = null;
            foreach (var p in students)
            {
                if (p.Name == naamStudent)
                {
                    student = p;
                }
            }

            if (teacher != null && student != null)
            {
                Course course = new Course();
                course.Description = beschrijving;
                course.StudentID = student.StudentID;
                course.TeacherID = teacher.TeacherID;
                _courseRepository.Insert(course);
                _courseRepository.Save();
            }
        }

        public List<CourseItem> ShowCourse()
        {
            List<CourseItem> list = new List<CourseItem>();
            var allCourses = _courseRepository.GetAll();

            foreach (var course in allCourses)
            {
                Teacher? teacher = _teacherRepository.GetById(course.TeacherID);
                Student? student = _studentRepository.GetById(course.StudentID);

                if (teacher != null && student != null)
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

        public bool TeachersExist()
        {
            return _teacherRepository.GetAll().Any();
        }

        public bool TeacherExists(string naamLeerkracht)
        {
            bool result;
            var all = _teacherRepository.GetAll();
            result = all.Any(p => p.Name == naamLeerkracht);
            return result;
        }

        public List<CourseItem> ShowCourseForTeacher(string naam)
        {
            List<CourseItem> list = new List<CourseItem>();
            var allCourses = _courseRepository.GetAll();

            foreach (var course in allCourses)
            {
                Teacher? teacher = _teacherRepository.GetById(course.TeacherID);
                Student? student = _studentRepository.GetById(course.StudentID);

                if (teacher != null && student != null && teacher.Name == naam)
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
