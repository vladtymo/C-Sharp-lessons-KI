namespace _02_ef_university_db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUniversityManager manager = new UniversityManager();

            // ----------- show all students
            manager.ShowAllStudents();

            // ----------- add new subject
            Console.Write("Enter new subject name: ");
            string subjectName = Console.ReadLine();

            manager.AddNewSubject(subjectName);

            manager.ShowAllSubjects();

            // ----------- delete subject by ID
            Console.Write("Enter subject ID to remove: ");
            int id = int.Parse(Console.ReadLine());

            manager.RemoveSubjectById(id);

            // --------------------------- LINQ queries ---------------------------

            Console.WriteLine("Successfull students");
            manager.ShowStudentsByMark(10);

            Console.WriteLine("TOP-3 students by average mark");
            manager.ShowTopStudent(3);
        }
    }
}