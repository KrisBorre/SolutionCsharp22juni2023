﻿namespace Education.DataAccessLayer.Repositories
{
    // Repository classes exchange data between the data context and the business logic layer of the application.
    // These Repository classes hide the logics required to store and retrieve data.
    // The repository pattern of design separates the logic that stores and retrieves data from the business logic that acts on the data.
    public class TeacherRepository : ITeacherRepository
    {
        private readonly EducationDbContext _context;

        public TeacherRepository()
        {
            _context = new EducationDbContext();
        }

        public TeacherRepository(EducationDbContext context)
        {
            _context = context;
        }

        //This method will return all the Physicians from the Physician table
        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public Teacher? GetById(int id)
        {
            return _context.Teachers.Find(id);
        }

        public void Insert(Teacher teacher)
        {
            // There are tracking methods on DbSet and on DbContext.
            // Here we track via DbSet.
            _context.Teachers.Add(teacher);
            // Tracking via DbContext would be _context.Add(physician) and then the context will discover the type.
        }

        public void DeleteById(int id)
        {
            Teacher? physician = _context.Teachers.Find(id);

            if (physician != null)
            {
                _context.Teachers.Remove(physician);
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