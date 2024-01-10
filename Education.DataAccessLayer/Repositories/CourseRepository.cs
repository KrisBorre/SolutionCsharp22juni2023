namespace Education.DataAccessLayer.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly EducationDbContext _context;

        public CourseRepository()
        {
            _context = new EducationDbContext();
        }

        public CourseRepository(EducationDbContext context)
        {
            _context = context;
        }

        //This method will return all the Courses from the Course table
        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public void Insert(Course course)
        {
            _context.Courses.Add(course);
        }

        public void DeleteById(int id)
        {
            Course? course = _context.Courses.Find(id);

            if (course != null)
            {
                _context.Courses.Remove(course);
            }
        }

        //This method will make the changes permanent in the database
        //That means once we call Insert, Update, and Delete Methods, then we need to call
        //the Save method to make the changes permanent in the database
        public void Save()
        {
            //Based on the Entity State, it will generate the corresponding SQL Statement and
            //Execute the SQL Statement in the database
            //For Added Entity State: It will generate INSERT SQL Statement
            //For Modified Entity State: It will generate UPDATE SQL Statement
            //For Deleted Entity State: It will generate DELETE SQL Statement
            _context.SaveChanges();
        }
        private bool disposed = false;

        //As a context object is a heavy object or you can say time-consuming object
        //So, once the operations are done we need to dispose of the same using Dispose method
        //The EmployeeDBContext class inherited from DbContext class and the DbContext class
        //is Inherited from the IDisposable interface

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
