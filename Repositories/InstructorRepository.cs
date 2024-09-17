using CoursesAPI.Data;
using CoursesAPI.Models;

namespace CoursesAPI.Repositories;

public class InstructorRepository : BaseRepository<Instructor>, IInstructorRepository
{
    public InstructorRepository(ApplicationDbContext context) : base(context)
    {
    }
}
