namespace Core1.Services;

public interface IBaseService<T>
{
    List<T> GetAll();
    List<T> GetWhere(string query);
    T GetById(int id);

    int Create(T Data);
    int Delete(int id);
    int Update(int id, T Data);
}
