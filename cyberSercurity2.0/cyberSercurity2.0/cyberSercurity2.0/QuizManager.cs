using System.Collections.Generic;

namespace CyberSecurity2._0
{
    public class QuizManager
    {
        public List<Question> Questions { get; set; }

        public QuizManager()
        {
            Questions = new List<Question>()
            {
                new Question
                {
                    Text = "What does HTTPS stand for?",
                    Answer = "HyperText Transfer Protocol Secure"
                },

                new Question
                {
                    Text = "What is phishing?",
                    Answer = "A scam"
                },

                new Question
                {
                    Text = "What should you use for stronger account security?",
                    Answer = "Two-factor authentication"
                },

                new Question
                {
                    Text = "What makes a strong password?",
                    Answer = "Uppercase, lowercase, numbers and symbols"
                },

                new Question
                {
                    Text = "Should you click suspicious email links?",
                    Answer = "No"
                },

                new Question
                {
                    Text = "What should you check before entering personal information on a website?",
                    Answer = "HTTPS"
                },

                new Question
                {
                    Text = "What software helps protect your computer from malware?",
                    Answer = "Antivirus"
                },

                new Question
                {
                    Text = "What is malware?",
                    Answer = "Malicious software"
                },

                new Question
                {
                    Text = "Why should you update your software regularly?",
                    Answer = "Security patches"
                },

                new Question
                {
                    Text = "What should you do if you receive a suspicious email?",
                    Answer = "Delete it"
                }
            };
        }
    }
}