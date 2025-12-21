using SQLite;
using System;

namespace JournalApp.Models
{
    [Table("Entries")]
    public class JournalEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // --- FUTURE PROOFING ---
        // Even if we only have 1 user now, we store which user owns this entry.
        // For now, this will always be '1'.
        [Indexed]
        public int UserId { get; set; } 

        [Indexed(Unique = true)] 
        public DateTime EntryDate { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        // Moods
        public string PrimaryMood { get; set; } = string.Empty;
        public string PrimaryMoodCategory { get; set; } = string.Empty;
        public string? SecondaryMood1 { get; set; }
        public string? SecondaryMood2 { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}