using ToDoMVC.Models;

namespace ToDoMVC.Repositories.Interfaces
{
    public interface ITarefas
    {
        Task<IEnumerable<Tarefa>> GetTarefas(); 
        Task<Tarefa> GetTarefa(int id);
        Task<bool> CreateTarefa(Tarefa model);
        Task<bool> UpdateTarefa(Tarefa model, int id);
        Task<bool> DeleteTarefa(int id); 
    }
}
