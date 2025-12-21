namespace JournalApp.Models
{
    public static class AppConstants
    {
        public static List<string> PositiveMoods = new() { "Happy", "Excited", "Relaxed", "Grateful", "Confident" };
        public static List<string> NeutralMoods = new() { "Calm", "Thoughtful", "Curious", "Nostalgic", "Bored" };
        public static List<string> NegativeMoods = new() { "Sad", "Angry", "Stressed", "Lonely", "Anxious" };

        public const string CategoryPositive = "Positive";
        public const string CategoryNeutral = "Neutral";
        public const string CategoryNegative = "Negative";
    }
}