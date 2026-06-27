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
        private readonly MemoryManager memory;
        private readonly TaskManager taskManager;
        private readonly QuizManager quizManager;
        private readonly ActivityLogger logger;
        private readonly DatabaseHelper database;

        public MainWindow()
        {
            InitializeComponent();

            // Create objects
            services = new Services();
            memory = new MemoryManager();
            taskManager = new TaskManager();
            quizManager = new QuizManager();
            logger = new ActivityLogger();
            database = new DatabaseHelper();

            // Create database and table
            database.CreateDatabase();

            // Play greeting
            PlayGreeting();

            // Welcome message
            AddMessage("🤖 Welcome to CyberSecurity2.0!", Brushes.Lime);
            AddMessage("Type 'help' to view all available commands.\n", Brushes.Cyan);

            logger.AddLog("Application started.");

            foreach (string log in logger.GetLatestLogs())
            {
                lstActivity.Items.Add(log);
            }
        }

        //=========================================================
        // SEND BUTTON
        //=========================================================
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            AddMessage("👤 You: " + input, Brushes.White);

            logger.AddLog("User: " + input);

            string lowerInput = input.ToLower();

            //----------------------------------------------------
            // ADD TASK
            //----------------------------------------------------
            if (lowerInput.StartsWith("add task "))
            {
                string title = input.Substring(9);

                TaskItem task = new TaskItem()
                {
                    Title = title,
                    Description = "Cybersecurity reminder",
                    ReminderDate = DateTime.Now.AddDays(1),
                    Completed = false
                };

                taskManager.AddTask(task);

                AddMessage("✅ Task added successfully!", Brushes.Yellow);

                UserInput.Clear();
                return;
            }

            //----------------------------------------------------
            // SHOW TASKS
            //----------------------------------------------------
            if (lowerInput == "show tasks")
            {
                if (taskManager.Tasks.Count == 0)
                {
                    AddMessage("No tasks found.", Brushes.Orange);
                }
                else
                {
                    AddMessage("===== YOUR TASKS =====", Brushes.Cyan);

                    foreach (TaskItem task in taskManager.Tasks)
                    {
                        AddMessage(
                            $"• {task.Title} | {task.ReminderDate.ToShortDateString()}",
                            Brushes.White);
                    }
                }

                UserInput.Clear();
                return;
            }

            //----------------------------------------------------
            // START QUIZ
            //----------------------------------------------------
            if (lowerInput == "quiz")
            {
                AddMessage("Cybersecurity Quiz Started!", Brushes.Yellow);

                foreach (Question q in quizManager.Questions)
                {
                    AddMessage("Q: " + q.Text, Brushes.LightBlue);
                }

                UserInput.Clear();
                return;
            }

            //----------------------------------------------------
            // NORMAL CHATBOT RESPONSE
            //----------------------------------------------------
            string response = services.GetResponse(input);

            AddMessage("🤖 Bot: " + response, Brushes.Lime);

            logger.AddLog("Bot: " + response);

            UserInput.Clear();
        }

        //=========================================================
        // DISPLAY CHAT MESSAGES
        //=========================================================
        private void AddMessage(string message, Brush colour)
        {
            Paragraph paragraph = new Paragraph();

            Run run = new Run(message);

            run.Foreground = colour;

            paragraph.Inlines.Add(run);

            ChatBox.Document.Blocks.Add(paragraph);

            ChatBox.ScrollToEnd();
        }

        //=========================================================
        // PLAY VOICE GREETING
        //=========================================================
        private void PlayGreeting()
        {
            try
            {
                string path = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "greeting.wav");

                SoundPlayer player = new SoundPlayer(path);

                player.Load();

                player.PlaySync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Voice greeting could not be played.\n\n" +
                    ex.Message);
            }
        }
        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTask.Text))
            {
                MessageBox.Show("Enter a task title.");
                return;
            }

            TaskItem task = new TaskItem()
            {
                Title = txtTask.Text,
                Description = txtDescription.Text,
                ReminderDate = dpReminder.SelectedDate ?? DateTime.Now,
                Completed = false
            };

            taskManager.AddTask(task);

            AddMessage("✅ Task added successfully!", Brushes.Yellow);

            lstActivity.Items.Add("Task Added: " + task.Title);

            txtTask.Clear();
            txtDescription.Clear();
        }
        private void btnShowTasks_Click(object sender, RoutedEventArgs e)
        {
            AddMessage("===== TASK LIST =====", Brushes.Cyan);

            if (taskManager.Tasks.Count == 0)
            {
                AddMessage("No tasks available.", Brushes.Orange);
                return;
            }

            foreach (TaskItem task in taskManager.Tasks)
            {
                AddMessage(
                    $"{task.Title} - {task.Description} - {task.ReminderDate.ToShortDateString()}",
                    Brushes.White);
            }

            lstActivity.Items.Add("Viewed Task List");
        }
        private void btnQuiz_Click(object sender, RoutedEventArgs e)
        {
            AddMessage("===== CYBER SECURITY QUIZ =====", Brushes.LightGreen);

            foreach (Question question in quizManager.Questions)
            {
                AddMessage(question.Text, Brushes.LightBlue);
            }

            lstActivity.Items.Add("Quiz Started");
        }
    }
}