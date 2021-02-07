using Microsoft.EntityFrameworkCore;
using TodoApiCs.Models;

namespace TodoApiCs.Repository
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> opt) : base(opt)
        {
            
        }

        public DbSet<Todo> Todos { get; set; }
    }
}