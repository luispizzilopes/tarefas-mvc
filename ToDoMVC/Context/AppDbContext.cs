using Microsoft.EntityFrameworkCore;
using ToDoMVC.Models;

namespace ToDoMVC.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tarefa>? Tarefas { get; set; }
    }
}
