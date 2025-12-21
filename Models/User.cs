using SQLite;

namespace JournalApp.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty; 


        public string PasswordHash { get; set; } = string.Empty; 

        
        public bool IsDarkMode { get; set; } = false;

      
        public DateTime RegistrationDate { get; set; }
    }
}