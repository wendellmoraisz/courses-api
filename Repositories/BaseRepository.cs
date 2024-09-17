using CoursesAPI.Common.Exceptions;
using CoursesAPI.Data;
using CoursesAPI.Models;

namespace CoursesAPI.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(int Id)
    {
        return _context.Set<T>().FirstOrDefault(x => x.Id == Id);
    }

    public void Create(T entity)
    {
        _context.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Delete(int Id)
    {
        var entity = _context.Set<T>().FirstOrDefault(x => x.Id == Id);
        if (entity is not null)
        {
            _context.Remove(entity);
        } else {
            throw new NotFoundException("Instrutor não encontrado");
        }
    }

}