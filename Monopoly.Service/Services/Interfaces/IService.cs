namespace Monopoly.Service.Services.Interfaces;

public interface IService<T>
{
    public T Create(T entity);

    public void Delete(int id);
    
    public T Get(int id);

    public List<T> GetAll(int? gameId, int page, int perPage);
    
    public T Update(T entity);
}