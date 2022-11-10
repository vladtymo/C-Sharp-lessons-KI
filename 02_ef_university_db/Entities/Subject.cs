namespace _02_ef_university_db
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Group> Groups { get; set; }
    }
}