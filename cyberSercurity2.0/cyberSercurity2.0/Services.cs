using System;
using System.Collections.Generic;

namespace CyberSecurity2._0
{
    public class Services
    {
        private readonly Dictionary<string, List<string>> responses;

        private readonly Dictionary<string, List<string>> keywordMap;

        private readonly Random rand;

        private readonly MemoryManager memory;

        private string currentTopic = "";

        public Services()
        {
            rand = new Random();

            memory = new MemoryManager();

            responses = new Dictionary<string, List<string>>
            {
                {
                    "password", new List<string>
                    {
                        "Use strong passwords with symbols and numbers.",
                        "Avoid using birthdays in passwords.",
                        "Use a password manager for stronger security."
                    }
                },

                {
                    "phishing", new List<string>
                    {
                        "Never click suspicious links.",
                        "Scammers pretend to be trusted companies.",
                        "Always verify email senders."
                    }
                },

                {
                    "privacy", new List<string>
                    {
                        "Review your privacy settings regularly.",
                        "Avoid oversharing online.",
                        "Enable two-factor authentication."
                    }
                },

                {
                    "safe browsing", new List<string>
                    {
                        "Only visit trusted websites.",
                        "Check for HTTPS before entering passwords.",
                        "Keep your browser updated."
                    }
                }
            };

            keywordMap = new Dictionary<string, List<string>>
            {
                {
                    "password",
                    new List<string>
                    {
                        "password",
                        "login",
                        "credentials"
                    }
                },

                {
                    "phishing",
                    new List<string>
                    {
                        "phishing",
                        "scam",
                        "fraud"
                    }
                },

                {
                    "privacy",
                    new List<string>
                    {
                        "privacy",
                        "private"
                    }
                },

                {
                    "safe browsing",
                    new List<string>
                    {
                        "browser",
                        "website",
                        "internet"
                    }
                }
            };
        }

        public string GetResponse(string input)
        {
            // HELP MENU
            if (input == "help")
            {
                return
                    "\n============= HELP MENU =============\n" +
                    "• Password Safety\n" +
                    "• Phishing Scams\n" +
                    "• Privacy Protection\n" +
                    "• Safe Browsing\n" +
                    "• Sentiment Support\n" +
                    "=====================================";
            }
            // GENERAL QUESTIONS
            if (input.Contains("how are you"))
                return "I'm functioning perfectly and ready to help!";

            if (input.Contains("your purpose"))
                return "My purpose is to teach cybersecurity awareness.";

            if (input.Contains("what can i ask"))
                return "You can ask about passwords, phishing, privacy, and safe browsing.";

            // MEMORY
            if (input.Contains("i like"))
            {
                string topic = input.Replace("i like", "").Trim();

                memory.SaveFavouriteTopic(topic);

                return $"Great! I'll remember that you're interested in {topic}.";
            }

            if (input.Contains("what do you remember"))
            {
                return memory.RecallFavouriteTopic();
            }

            // SENTIMENT DETECTION
            if (input.Contains("worried"))
            {
                return "It's understandable to feel worried. Let me help you stay safe online.";
            }

            if (input.Contains("frustrated"))
            {
                return "Cybersecurity can seem difficult at first, but you're learning valuable skills.";
            }

            if (input.Contains("curious"))
            {
                return "Curiosity is important in cybersecurity. Keep learning!";
            }

            // FOLLOW-UP QUESTIONS
            if (input.Contains("tell me more") ||
                input.Contains("another tip"))
            {
                if (!string.IsNullOrWhiteSpace(currentTopic))
                {
                    return GetRandomResponse(currentTopic);
                }

                return "Please ask about a cybersecurity topic first.";
            }

            // KEYWORD MATCHING
            foreach (var category in keywordMap)
            {
                foreach (var keyword in category.Value)
                {
                    if (input.Contains(keyword))
                    {
                        currentTopic = category.Key;

                        memory.SaveLastTopic(category.Key);

                        return GetRandomResponse(category.Key);
                    }
                }
            }

            return "I didn't quite understand that. Could you rephrase?";
        }

        private string GetRandomResponse(string key)
        {
            var list = responses[key];

            return list[rand.Next(list.Count)];
        }
    }
}