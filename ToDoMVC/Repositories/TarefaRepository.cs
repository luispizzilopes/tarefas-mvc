using Microsoft.EntityFrameworkCore;
using ToDoMVC.Context;
using ToDoMVC.Models;
using ToDoMVC.Repositories.Interfaces;

namespace ToDoMVC.Repositories
{
    public class TarefaRepository : ITarefas
    {
        private readonly AppDbContext _context; 

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTarefa(Tarefa model)
        {
            if(model != null)
            {
                await _context.Tarefas.AddAsync(model); 
                await _context.SaveChangesAsync();

                return true; 
            }

            return false;
        }

        public async Task<bool> DeleteTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id); 

            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();

                return true; 
            }

            return false;
        }

        public async Task<Tarefa> GetTarefa(int id)
        {
            return await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id); 
        }

        public async Task<IEnumerable<Tarefa>> GetTarefas()
        {
            return await _context.Tarefas.AsNoTracking().ToListAsync(); 
        }

        public async Task<bool> UpdateTarefa(Tarefa model, int id)
        {
            if(model.Id == id)
            {
                var tarefa = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);

                if(tarefa != null)
                {
                    tarefa.Name = model.Name;
                    tarefa.Description = model.Description;

                    _context.Entry(tarefa).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return true;
                }
            }

            return false; 
        }
    }
}
