using CoursesAPI.Models;

namespace CoursesAPI.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    public void Create(T entity);
    public void Update(T entity);
    public void Delete(int Id);
    public T? GetById(int Id);
    public List<T> GetAll();
}
