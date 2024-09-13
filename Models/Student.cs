namespace CoursesAPI.Models;

public class Student : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public DateOnly BirthDate { get; set; }
    public List<Course> Courses { get; set; }
}
