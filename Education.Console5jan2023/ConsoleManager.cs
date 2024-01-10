using Education.BusinessLogicLayer;
using Education.DataAccessLayer;

namespace Education.Console5jan2023
{
    public class ConsoleManager
    {
        private readonly StudentService _studentService;
        private readonly TeacherService _teacherService;

        public ConsoleManager()
        {
            _teacherService = new TeacherService();
            _studentService = new StudentService();
        }

        public ConsoleManager(StudentService serviceManager, TeacherService teacherService)
        {
            _teacherService = teacherService;
            _studentService = serviceManager;
        }

        public bool ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Educatie database");

            Console.WriteLine("");
            Console.WriteLine("1 - Student toevoegen");
            Console.WriteLine("2 - Studenten verwijderen");
            Console.WriteLine("3 - Leerkracht toevoegen");
            Console.WriteLine("4 - Leerkracht verwijderen");
            Console.WriteLine("5 - Cursus toevoegen");
            Console.WriteLine("6 - Cursussen inzien");
            Console.WriteLine("7 - Cursussen voor een leerkracht inzien.");
            Console.WriteLine("8 - Cursussen voor een student inzien.");
            Console.WriteLine("9 - Sluiten");
            Console.WriteLine("10 - Reset db");

            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        AddStudent();
                        return true;
                    case 2:
                        DeleteStudent();
                        return true;
                    case 3:
                        AddTeacher();
                        return true;
                    case 4:
                        DeleteTeacher();
                        return true;
                    case 5:
                        AddCourse();
                        return true;
                    case 6:
                        ShowCourses();
                        return true;
                    case 7:
                        ShowCourseForTeacher();
                        return true;
                    case 8:
                        ShowCourseForStudent();
                        return true;
                    case 9:
                        return false;
                    case 10:
                        EducationDbContext dbContext = new EducationDbContext();
                        dbContext.Database.EnsureDeleted();
                        dbContext.Database.EnsureCreated();
                        return true;
                    default:
                        return true;
                }
            }
            return true;
        }

        public void AddStudent()
        {
            Console.WriteLine("Geef de naam van de student:");
            string? naam = Console.ReadLine();

            Console.WriteLine("Geef het contactgegeven:");
            string? contactGegeven = Console.ReadLine();

            Console.WriteLine("Geef het land:");
            string? land = Console.ReadLine();

            Console.WriteLine("Geef de stad:");
            string? stad = Console.ReadLine();

            Console.WriteLine("Geef de straat:");
            string? straat = Console.ReadLine();

            Console.WriteLine("Geef het huisnummer:");
            string? huisnummer = Console.ReadLine();

            _studentService.AddStudent(naam ?? string.Empty, contactGegeven ?? string.Empty, land ?? string.Empty, stad ?? string.Empty, straat ?? string.Empty, huisnummer ?? string.Empty);
        }

        public void DeleteStudent()
        {
            Console.WriteLine("Geef de naam van de te verwijderen student:");
            string? naam = Console.ReadLine();
            if (naam != null)
            {
                _studentService.DeleteStudent(naam);
            }
        }

        public void AddTeacher()
        {
            Console.WriteLine("Geef de naam van de leerkracht:");
            string? naam = Console.ReadLine();

            Console.WriteLine("Geef het land:");
            string? land = Console.ReadLine();

            Console.WriteLine("Geef de stad:");
            string? stad = Console.ReadLine();

            Console.WriteLine("Geef de straat:");
            string? straat = Console.ReadLine();

            Console.WriteLine("Geef het huisnummer:");
            string? huisnummer = Console.ReadLine();

            _teacherService.AddTeacher(naam ?? string.Empty, land ?? string.Empty, stad ?? string.Empty, straat ?? string.Empty, huisnummer ?? string.Empty);
        }

        public void DeleteTeacher()
        {
            Console.WriteLine("Geef de naam van de te verwijderen leerkracht:");
            string? naam = Console.ReadLine();
            if (naam != null)
            {
                _teacherService.DeleteTeacher(naam);
            }
        }

        public void AddCourse()
        {
            Console.WriteLine("Geef de naam van de leerkracht:");
            string? naamLeerkracht = Console.ReadLine();

            Console.WriteLine("Geef de naam van de student:");
            string? naamStudent = Console.ReadLine();

            Console.WriteLine("Geef een beschrijving van de cursus:");
            string? beschrijving = Console.ReadLine();

            _teacherService.AddCourse(naamLeerkracht, naamStudent, beschrijving);
        }

        public void ShowCourses()
        {
            List<CourseItem> list = _teacherService.ShowCourse();

            foreach (CourseItem item in list)
            {
                Console.WriteLine(item.TeacherName + " " + item.Description + " " + item.StudentName);
            }
            Console.WriteLine("Typ om terug naar het menu te gaan:");
            string? input = Console.ReadLine();
        }

        public void ShowCourseForTeacher()
        {
            if (_teacherService.TeachersExist())
            {
                string? naamLeerkracht = string.Empty;
                bool exists = false;
                while (!exists)
                {
                    Console.WriteLine("Geef de naam van de leerkracht:");
                    naamLeerkracht = Console.ReadLine();

                    exists = !string.IsNullOrEmpty(naamLeerkracht) && _teacherService.TeacherExists(naamLeerkracht);
                    if (!exists) Console.WriteLine("Sorry, leerkracht niet gevonden.");
                }

                List<CourseItem> list = _teacherService.ShowCourseForTeacher(naamLeerkracht ?? string.Empty);

                foreach (CourseItem item in list)
                {
                    Console.WriteLine(item.TeacherName + " " + item.Description + " " + item.StudentName);
                }
            }
            else
            {
                Console.WriteLine("Sorry, er zijn nog geen leerkrachten toegevoegd.");
            }

            Console.WriteLine("Typ om terug naar het menu te gaan:");
            string? input = Console.ReadLine();
        }

        public void ShowCourseForStudent()
        {
            Console.WriteLine("Geef de naam van de student:");
            string? naamStudent = Console.ReadLine();

            List<CourseItem> list = _studentService.ShowCourseForStudent(naamStudent);

            foreach (CourseItem item in list)
            {
                // mooie plek om string interpolatie en verbatim te tonen.
                var heading = @"Leerkracht      Beschrijving       Student
------------------------------------";
                Console.WriteLine(heading);
                Console.WriteLine($"{item.TeacherName} {item.Description} {item.StudentName}");
            }
            Console.WriteLine("Typ om terug naar het menu te gaan:");
            string? input = Console.ReadLine();
        }



    }
}
