using CoursesAPI.Data;

namespace CoursesAPI.Repositories;

public class UnityOfWork : IUnityOfWork
{
    private ApplicationDbContext _context;

    public UnityOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
