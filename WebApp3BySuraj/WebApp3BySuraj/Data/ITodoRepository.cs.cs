using System.Collections.Generic;
using WebApp3BySuraj.Models;

namespace WebApp3BySuraj.Data
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAllTodos();
        Todo GetTodoById(int id);
        void AddTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void DeleteTodo(int id);
    }
}

