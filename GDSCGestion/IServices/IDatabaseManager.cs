namespace GDSCGestion.IServices;

public interface IDatabaseManager<T> where T : new()
{
    Task<bool> AddElement(T entity);
    Task<bool> ExisteElement(string id);
    Task<bool> DeleteElemennt(string id);
    Task<T> GetElement(string id);
    Task<T> GetElementWithCode(string code);
    Task<List<T>> GetAllElements();

}
