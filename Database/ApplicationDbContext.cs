using JournalApp.Models;
using SQLite;
using System.Reflection;

namespace Myjournal.Database;


public class ApplicationDbContext
{
    private SQLiteAsyncConnection _dbConnection;

    public const string DatabaseFileName = "Myjournal.Database.db3";
    public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
    public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

    public async Task InitAsync()
    {
        if (_dbConnection != null) return;

        _dbConnection = new SQLiteAsyncConnection(DatabasePath, Flags);

        await _dbConnection.CreateTableAsync<User>();
        await _dbConnection.CreateTableAsync<JournalEntry>();
        await _dbConnection.CreateTableAsync<Tag>();
        await _dbConnection.CreateTableAsync<EntryTag>();
    }

    // CRUD methods
    public async Task<int> CreateAsync<TEntity>(TEntity entity) where TEntity : class, new()
    {
        await InitAsync();
        return await _dbConnection.InsertAsync(entity);
    }

    public async Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, new()
    {
        await InitAsync();
        return await _dbConnection.UpdateAsync(entity);
    }

    public async Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class, new()
    {
        await InitAsync();
        return await _dbConnection.DeleteAsync(entity);
    }
    
    public async Task<int> AddOrUpdateAsync<TEntity>(TEntity entity) where TEntity : class, new()
    {
        await InitAsync();
        return await _dbConnection.InsertOrReplaceAsync(entity);
    }

    public async Task<List<T>> GetTableRowsAsync<T>() where T : class, new()
    {
        await InitAsync();
        return await _dbConnection.Table<T>().ToListAsync();
    }
    
    public async Task<T?> GetRowAsync<T>(string column, object value) where T : class, new()
    {
        await InitAsync();
        
        var tableAttribute = typeof(T).GetCustomAttribute<TableAttribute>();
        string tableName = tableAttribute != null ? tableAttribute.Name : typeof(T).Name;
        
        string query = $"SELECT * FROM [{tableName}] WHERE {column} = ?";
        var result = await _dbConnection.QueryAsync<T>(query, value);

        return result.FirstOrDefault();
    }
    public SQLiteAsyncConnection GetConnection()
    {
        return _dbConnection; 
    }
}