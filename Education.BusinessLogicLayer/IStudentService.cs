namespace Education.BusinessLogicLayer
{
    public interface IStudentService
    {
        void AddStudent(string naam, string contactgegeven, string land, string stad, string straat, string huisnummer);
        void DeleteStudent(string naam);
        List<CourseItem> ShowCourseForStudent(string naam);
    }
}
