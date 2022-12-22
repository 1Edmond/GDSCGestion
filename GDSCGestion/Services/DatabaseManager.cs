using GDSCGestion.Customs;
using GDSCGestion.IServices;
using GDSCGestion.Models;
using SQLite;

namespace GDSCGestion.Services;

public class DatabaseManager : IDatabaseManager<UserPassage>
{
    private static SQLiteAsyncConnection Connection;
    public DatabaseManager()
    {   
        Connection = new SQLiteAsyncConnection(Constants.database);
        Connection.CreateTableAsync<UserPassage>();
    }


    public async Task<bool> AddElement(UserPassage entity)
    {
        if(Connection is null)
            return false;
        await Connection.InsertAsync(entity);
        return true;
    }

    public async Task<bool> DeleteElemennt(string id)
    {
        if (Connection is null)
            return false;
        return await Connection.DeleteAsync(id) > 0 ;
    }

    public async Task<bool> ExisteElement(string code)
    {
        if (Connection is null)
            return true;
        if (GetAllElements().Result.Where(x => x.Code == code).Count() > 0)
            return true;
        return false;
    }

    public async Task<List<UserPassage>> GetAllElements()
    {
        if (Connection is null)
            return new List<UserPassage>();
        return Connection.Table<UserPassage>().ToListAsync().Result;
    }

    public async Task<UserPassage> GetElement(string id)
    {
        if (Connection is null)
            return new UserPassage();
        return await Connection.GetAsync<UserPassage>(id);
    }

    public async Task<UserPassage> GetElementWithCode(string code)
    {
        var elements = await GetAllElements();
        return elements.FirstOrDefault(x => x.Code == code);
    }
}
