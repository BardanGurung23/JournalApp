using SQLite;

namespace JournalApp.Models
{
    [Table("EntryTags")]
    public class EntryTag
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int JournalEntryId { get; set; }

        [Indexed]
        public int TagId { get; set; }
    }
}