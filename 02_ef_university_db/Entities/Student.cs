namespace _02_ef_university_db
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public float AverageMark { get; set; }
        public string Address { get; set; }
        public int GroupId { get; set; }

        // Navigation Properties
        public Group Group { get; set; }
    }
}