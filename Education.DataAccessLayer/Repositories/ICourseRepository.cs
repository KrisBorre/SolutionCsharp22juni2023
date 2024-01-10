namespace Education.DataAccessLayer.Repositories
{
    public interface ICourseRepository
    {
        void DeleteById(int id);

        IEnumerable<Course> GetAll();

        void Insert(Course course);

        void Save();
    }
}
