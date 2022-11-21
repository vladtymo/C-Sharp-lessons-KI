using _02_ef_university_db.Data;

namespace _02_ef_university_db
{
    public class UniversityManager : IUniversityManager
    {
        private readonly UniversityDbContext context;
        public UniversityManager()
        {
            this.context = new UniversityDbContext();
        }

        public void AddNewSubject(string subjectName)
        {
            context.Subjects.Add(new Subject() { Name = subjectName });
            context.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return context.Students.ToList();
        }

        public bool RemoveSubjectById(int id)
        {
            Subject? subject = context.Subjects.Find(id);

            // ----------- check if subject was found
            if (subject == null) return false;

            context.Subjects.Remove(subject);
            context.SaveChanges();
            return true;
        }

        public void ShowAllStudents()
        {
            foreach (var st in context.Students)
            {
                Console.WriteLine($"[Student]: {st.Name} {st.Birthdate?.ToShortDateString()} - {st.AverageMark} mark");
            }
        }

        public void ShowAllSubjects()
        {
            foreach (var sb in context.Subjects)
                Console.WriteLine($"Subject [{sb.Id}]: {sb.Name}");
        }

        public void ShowStudentsByMark(int markFrom)
        {
            var result = context.Students.Where(s => s.AverageMark >= markFrom).OrderBy(s => s.Name);

            foreach (var st in result)
                Console.WriteLine($"[Student]: {st.Name} {st.Birthdate?.ToShortDateString()} - {st.AverageMark} mark");
        }

        public void ShowTopStudent(int topLevel)
        {
            var topStudents = context.Students.OrderByDescending(s => s.AverageMark).Take(topLevel);

            foreach (var st in topStudents)
                Console.WriteLine($"[Student]: {st.Name} {st.Birthdate?.ToShortDateString()} - {st.AverageMark} mark");
        }
    }
}