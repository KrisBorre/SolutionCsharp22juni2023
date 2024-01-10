namespace Education.BusinessLogicLayer
{
    public interface ITeacherService
    {
        void AddCourse(string naamTeacher, string naamStudent, string beschrijving);
        void AddTeacher(string naam, string land, string stad, string straat, string huisnummer);
        void DeleteTeacher(string naam);
        List<CourseItem> ShowCourse();
        List<CourseItem> ShowCourseForTeacher(string naam);
    }
}