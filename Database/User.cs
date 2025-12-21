using SQLite;

namespace Myjournal.Database;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }     

    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
}