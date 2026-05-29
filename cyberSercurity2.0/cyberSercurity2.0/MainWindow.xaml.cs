using System;
using System.Media;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace CyberSecurity2._0
{
    public partial class MainWindow : Window
    {
        private readonly Services services;

        public MainWindow()
        {
            InitializeComponent();

            services = new Services();

            PlayGreeting();

            AddMessage("🤖 Welcome to CyberSecurity2.0!", Brushes.Lime);
            AddMessage("Type 'help' for available topics.\n", Brushes.Cyan);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            AddMessage($"👤 You: {input}", Brushes.White);

            string response = services.GetResponse(input.ToLower());

            AddMessage($"🤖 Bot: {response}\n", Brushes.Lime);

            UserInput.Clear();
        }

        private void AddMessage(string message, Brush color)
        {
            Paragraph paragraph = new Paragraph();

            Run run = new Run(message)
            {
                Foreground = color
            };

            paragraph.Inlines.Add(run);

            ChatBox.Document.Blocks.Add(paragraph);

            ChatBox.ScrollToEnd();
        }

        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");

                player.PlaySync();
            }
            catch
            {
                MessageBox.Show("Voice greeting could not be played.");
            }
        }
    }
}