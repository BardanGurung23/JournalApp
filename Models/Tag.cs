using SQLite;

namespace JournalApp.Models
{
    [Table("Tags")]
    public class Tag
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed(Unique = true)]
        public string Name { get; set; } = string.Empty;

    }
}