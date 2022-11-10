namespace _02_ef_university_db
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Properties

        // Relationship type: One to Many (1...*)
        // Student has one Group, Group has many students
        public ICollection<Student> Students { get; set; }

        // Relationship type: Many to Many (*...*)
        // Group has many subjects, Subject has many groups
        public ICollection<Subject> Subjects { get; set; }
    }
}