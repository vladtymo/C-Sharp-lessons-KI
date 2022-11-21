namespace _02_ef_university_db
{
    public interface IUniversityManager
    {
        IEnumerable<Student> GetAllStudents();
        void ShowAllStudents();
        void AddNewSubject(string subjectName);
        bool RemoveSubjectById(int id);
        void ShowStudentsByMark(int markFrom);
        void ShowTopStudent(int topLevel);
        void ShowAllSubjects();
    }
}