using System.Collections.Generic;

namespace CyberSecurity2._0
{
    public class TaskManager
    {
        public List<TaskItem> Tasks { get; set; }

        public TaskManager()
        {
            Tasks = new List<TaskItem>();
        }

        public void AddTask(TaskItem task)
        {
            Tasks.Add(task);
        }

        public List<TaskItem> GetTasks()
        {
            return Tasks;
        }
    }
}