using System.Data;
using System.Data.SqlClient;
using todoListApi.Helpers;
using todoListApi.Models;

namespace todoListApi.Services
{
    public interface ITaskService
    {
        TodoTask GetTaskById(int id);
        IEnumerable<TodoTask> GetAllTasks();
        void CreateTask(string title);
        void UpdateTask(int id, string title, bool completed);
    }

    public class TaskService : ITaskService
    {
        private readonly IConnectionHelper _connectionHelper;

        public TaskService(IConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public TodoTask GetTaskById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionHelper.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("STaskById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TodoTask
                            {
                                Id = (int)reader["id"],
                                Title = reader["title"].ToString(),
                                Completed = (bool)reader["completed"],
                                CreatedAt = (DateTime)reader["createdAt"]
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public IEnumerable<TodoTask> GetAllTasks()
        {
            List<TodoTask> tasks = new List<TodoTask>();

            using (SqlConnection connection = new SqlConnection(_connectionHelper.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("STasks", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks.Add(new TodoTask
                            {
                                Id = (int)reader["id"],
                                Title = reader["title"].ToString(),
                                Completed = (bool)reader["completed"],
                                CreatedAt = (DateTime)reader["createdAt"]
                            });
                        }
                    }
                }
            }

            return tasks;
        }

        public void CreateTask(string title)
        {
            using (SqlConnection connection = new SqlConnection(_connectionHelper.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("ITask", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@title", title);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTask(int id, string title, bool completed)
        {
            using (SqlConnection connection = new SqlConnection(_connectionHelper.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("UTask", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@completed", completed);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
