namespace CoursesAPI.Models;

public class Instructor : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();
}