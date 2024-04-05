using Education.BusinessLogicLayer;
using Education.DataAccessLayer;
using System.Reflection;

namespace Education.Console5apr2024
{
    public class ConsoleManager5apr2024
    {
        private readonly StudentService _studentService;
        private readonly TeacherService _teacherService;

        public ConsoleManager5apr2024()
        {
            _teacherService = new TeacherService();
            _studentService = new StudentService();
        }

        public ConsoleManager5apr2024(StudentService serviceManager, TeacherService teacherService)
        {
            _teacherService = teacherService;
            _studentService = serviceManager;
        }

        public bool ShowMenu()
        {
            Console.Clear();

            // loop through the assemblies that this app references 
            foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies())
            {
                // load the assembly so we can read its details
                var a = Assembly.Load(new AssemblyName(r.FullName));

                // declare a variable to count the number of methods
                int methodCount = 0;

                // loop through all the types in the assembly 
                foreach (var t in a.DefinedTypes)
                {
                    // add up the counts of methods 
                    methodCount += t.GetMethods().Count();
                }
                // output the count of types and their methods
                Console.WriteLine(
                  "{0:N0} types with {1:N0} methods in {2} assembly.",
                  arg0: a.DefinedTypes.Count(),
                  arg1: methodCount,
                  arg2: r.Name);
            }

            Console.WriteLine();

            Console.WriteLine("Educatie database met Func delegate");

            Console.WriteLine("");
            Console.WriteLine("1 - Student toevoegen");
            Console.WriteLine("2 - Student verwijderen");
            Console.WriteLine("3 - Leerkracht toevoegen");
            Console.WriteLine("4 - Leerkracht verwijderen");
            Console.WriteLine("5 - Cursus toevoegen");
            Console.WriteLine("6 - Cursussen inzien");
            Console.WriteLine("7 - Cursussen voor een leerkracht inzien.");
            Console.WriteLine("8 - Cursussen voor een student inzien.");
            Console.WriteLine("9 - Sluiten");
            Console.WriteLine("10 - Reset db");

            var options = new Dictionary<int, Func<bool>>
            {
                { 1, AddStudent},
                { 2, DeleteStudent},
                { 3, AddTeacher},
                { 4, DeleteTeacher},
                { 5, AddCourse},
                { 6, ShowCourses},
                { 7, ShowCourseForTeacher},
                { 8, ShowCourseForStudent},
                { 9, Exit},
                { 10, Reset},
            };

            if (int.TryParse(Console.ReadLine(), out int option))
            {
                if (options.ContainsKey(option))
                {
                    return options[option]();
                }
            }
            return true;
        }

        private bool AddStudent()
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
            return true;
        }

        private bool DeleteStudent()
        {
            Console.WriteLine("Geef de naam van de te verwijderen student:");
            string? naam = Console.ReadLine();
            if (naam != null)
            {
                _studentService.DeleteStudent(naam);
            }
            return true;
        }

        private bool AddTeacher()
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
            return true;
        }

        private bool DeleteTeacher()
        {
            Console.WriteLine("Geef de naam van de te verwijderen leerkracht:");
            string? naam = Console.ReadLine();
            if (naam != null)
            {
                _teacherService.DeleteTeacher(naam);
            }
            return true;
        }

        private bool AddCourse()
        {
            Console.WriteLine("Geef de naam van de leerkracht:");
            string? naamLeerkracht = Console.ReadLine();

            Console.WriteLine("Geef de naam van de student:");
            string? naamStudent = Console.ReadLine();

            Console.WriteLine("Geef een beschrijving van de cursus:");
            string? beschrijving = Console.ReadLine();

            _teacherService.AddCourse(naamLeerkracht, naamStudent, beschrijving);
            return true;
        }

        private bool ShowCourses()
        {
            List<CourseItem> list = _teacherService.ShowCourse();

            foreach (CourseItem item in list)
            {
                Console.WriteLine(item.TeacherName + " " + item.Description + " " + item.StudentName);
            }
            Console.WriteLine("Typ om terug naar het menu te gaan:");
            string? input = Console.ReadLine();
            return true;
        }

        private bool ShowCourseForTeacher()
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
            return true;
        }

        private bool ShowCourseForStudent()
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
            return true;
        }

        private bool Exit()
        {
            return false;
        }

        private bool Reset()
        {
            EducationDbContext dbContext = new EducationDbContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return true;
        }

    }
}
