using System.Collections.Generic;
using TodoApiCs.Models;

namespace TodoApiCs.Repository
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAllTodos();
        Todo GetTodoById(int id);
        void CreateTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void DeleteTodo(Todo todo);
        bool SaveChanges();
    }
}