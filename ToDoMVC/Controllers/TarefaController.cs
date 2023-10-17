using Microsoft.AspNetCore.Mvc;
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
    }
}
