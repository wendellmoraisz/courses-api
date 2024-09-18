using CoursesAPI.Data;
using CoursesAPI.Models;

namespace CoursesAPI.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
