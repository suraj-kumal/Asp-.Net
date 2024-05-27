using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using WebApp3BySuraj.Data;
using WebApp3BySuraj.Models;

namespace TodoListApp.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public IEnumerable<Todo> GetAllTodos()
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "SELECT * FROM Todos";
                return connection.Query<Todo>(sql).ToList();
            }
        }

        public Todo GetTodoById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "SELECT * FROM Todos WHERE Id = @Id";
                return connection.QuerySingleOrDefault<Todo>(sql, new { Id = id });
            }
        }

        public void AddTodo(Todo todo)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "INSERT INTO Todos (Title, Description, IsCompleted) VALUES (@Title, @Description, @IsCompleted)";
                connection.Execute(sql, todo);
            }
        }

        public void UpdateTodo(Todo todo)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "UPDATE Todos SET Title = @Title, Description = @Description, IsCompleted = @IsCompleted WHERE Id = @Id";
                connection.Execute(sql, todo);
            }
        }

        public void DeleteTodo(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var sql = "DELETE FROM Todos WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}
