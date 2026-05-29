namespace CyberSecurity2._0
{
    public class MemoryManager
    {
        public string FavouriteTopic { get; set; } = "";

        public string LastTopic { get; set; } = "";

        public void SaveFavouriteTopic(string topic)
        {
            FavouriteTopic = topic;
        }

        public void SaveLastTopic(string topic)
        {
            LastTopic = topic;
        }

        public string RecallFavouriteTopic()
        {
            if (!string.IsNullOrWhiteSpace(FavouriteTopic))
            {
                return $"You told me you're interested in {FavouriteTopic}.";
            }

            return "I don't remember your favourite topic yet.";
        }
    }
}