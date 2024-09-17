namespace CoursesAPI.Repositories;

public interface IUnityOfWork
{
    public Task SaveAsync();
    public void Dispose();
}
