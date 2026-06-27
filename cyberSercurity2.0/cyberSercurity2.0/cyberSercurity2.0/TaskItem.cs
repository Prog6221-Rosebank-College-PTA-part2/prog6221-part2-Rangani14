using System;

namespace CyberSecurity2._0
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReminderDate { get; set; }

        public bool Completed { get; set; }
    }
}