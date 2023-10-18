using Microsoft.AspNetCore.Mvc;
using ToDoMVC.Models;
using ToDoMVC.Repositories.Interfaces;

namespace ToDoMVC.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefas tarefasRepository;

        public TarefaController(ITarefas tarefasRepository)
        {
            this.tarefasRepository = tarefasRepository;
        }

        public async Task<IActionResult> Listar()
        {
            var tarefas = await tarefasRepository.GetTarefas(); 
            return View(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(string name, string description)
        {
            var tarefa = new Tarefa { Name = name, Description = description };

            await tarefasRepository.CreateTarefa(tarefa);

            return RedirectToAction("Listar");
        }

        [HttpDelete]
        public async Task<IActionResult> Apagar(int id)
        {
            await tarefasRepository.DeleteTarefa(id);

            return RedirectToAction("Listar"); 
        }
    }
}
