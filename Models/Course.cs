namespace CoursesAPI.Models;

public class Course : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Language { get; set; }
    public string Category { get; set; }
    public string Level { get; set; }
    public Instructor Instructor { get; set; }
    public List<Student> Students { get; set; }
}