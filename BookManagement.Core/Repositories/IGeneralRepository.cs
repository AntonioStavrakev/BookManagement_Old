namespace BookManagement.Core.Repositories;

public interface IGeneralRepository<T> where T : class // чудих се дали да го направя с отделни изцяло репоситори интерфейси, но се отказах
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    T Add(T entity);
    T Update(T entity);
    void Delete(int id);
}