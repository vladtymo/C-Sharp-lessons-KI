namespace _02_ef_university_db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniversityDbContext context = new UniversityDbContext();

            // ----------- show all students
            foreach (var st in context.Students)
            {
                Console.WriteLine($"[Student]: {st.Name} {st.Birthdate?.ToShortDateString()} - {st.AverageMark} mark");
            }

            Console.Write("Enter new subject name: ");
            string subjectName = Console.ReadLine();

            // ----------- add new subject
            context.Subjects.Add(new Subject() { Name = subjectName });
            context.SaveChanges();

            foreach (var sb in context.Subjects)
                Console.WriteLine($"Subject [{sb.Id}]: {sb.Name}");

            // ----------- delete subject by ID
            Console.Write("Enter subject ID to remove: ");
            int id = int.Parse(Console.ReadLine());

            Subject? subject = context.Subjects.Find(id);

            // ----------- check if subject was found
            if (subject != null)
            {
                context.Subjects.Remove(subject);
                context.SaveChanges();
            }
            else Console.WriteLine("Invalid subject ID!");

            // --------------------------- LINQ queries ---------------------------

            var result = context.Students.Where(s => s.AverageMark >= 10).OrderBy(s => s.Name);

            Console.WriteLine("Successfull students");
            foreach (var st in result)
                Console.WriteLine($"[Student]: {st.Name} {st.Birthdate?.ToShortDateString()} - {st.AverageMark} mark");

            var topStudents = context.Students.OrderByDescending(s => s.AverageMark).Take(3);

            Console.WriteLine("TOP-3 students by average mark");
            foreach (var st in topStudents)
                Console.WriteLine($"[Student]: {st.Name} {st.Birthdate?.ToShortDateString()} - {st.AverageMark} mark");
        }
    }
}