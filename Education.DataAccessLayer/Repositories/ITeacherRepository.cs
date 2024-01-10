namespace Education.DataAccessLayer.Repositories
{
    public interface ITeacherRepository
    {   
        void DeleteById(int id);

        IEnumerable<Teacher> GetAll();

        void Insert(Teacher teacher);

        void Save();
    }
}
