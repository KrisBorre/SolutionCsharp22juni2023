namespace Education.DataAccessLayer.Repositories
{
    public interface IStudentRepository
    {
        void DeleteById(int id);

        IEnumerable<Student> GetAll();

        void Insert(Student student);

        void Save();
    }
}
