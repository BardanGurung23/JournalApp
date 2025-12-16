using SQLite;



namespace Myjournal.Database;


    public class ApplicationDbContext
    {
        public SQLiteAsyncConnection DbConnection;

        public static readonly string NameSpace = "Myjournal.Database";

        public const string DatabaseFileName = "Myjournal.Database.db3";

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);

        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;

        public ApplicationDbContext()
        {
           
            DbConnection ??=  new SQLiteAsyncConnection(DatabasePath, Flags);

        }
    }
