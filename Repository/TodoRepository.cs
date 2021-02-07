using System;
using System.Collections.Generic;
using System.Linq;
using TodoApiCs.Models;

namespace TodoApiCs.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }
        public void CreateTodo(Todo todo)
        {
            if (todo == null)
            {
                throw new ArgumentNullException(nameof(todo)); 
            }

            _context.Todos.Add(todo);
        }

        public void DeleteTodo(Todo todo)
        {
            if (todo == null)
            {
                throw new ArgumentNullException(nameof(todo));
            }

            _context.Todos.Remove(todo);
        }

        public IEnumerable<Todo> GetAllTodos()
        {
            return _context.Todos.ToList();
        }

        public Todo GetTodoById(int id)
        {
            return _context.Todos.FirstOrDefault(item => item.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTodo(Todo todo)
        {
            // nothing
        }
    }
}