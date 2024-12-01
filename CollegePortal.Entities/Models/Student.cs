namespace CollegePortal.Entities.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
    }
}
