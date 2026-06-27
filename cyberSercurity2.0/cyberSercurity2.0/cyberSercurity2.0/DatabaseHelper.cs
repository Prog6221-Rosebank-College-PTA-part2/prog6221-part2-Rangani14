using System.Data.SQLite;

namespace CyberSecurity2._0
{
    public class DatabaseHelper
    {
        private readonly string connectionString = "Data Source=Tasks.db;Version=3;";

        public void CreateDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = @"
                CREATE TABLE IF NOT EXISTS Tasks
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT,
                    Description TEXT,
                    ReminderDate TEXT,
                    Completed INTEGER
                );";

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}