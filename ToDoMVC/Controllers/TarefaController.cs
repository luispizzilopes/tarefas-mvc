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
            if(name != null && description != null)
            {
                var tarefa = new Tarefa { Name = name, Description = description };

                await tarefasRepository.CreateTarefa(tarefa);

                TempData["MensagemDeSucesso"] = "Tarefa adicionada com sucesso!";

                return RedirectToAction("Listar");
            }

            TempData["MensagemDeErro"] = "Por favor, preencha todos os campos.";

            return RedirectToAction("Listar");
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(string name, string description, int id)
        {
            Tarefa tarefa = new Tarefa { Name = name, Id = id, Description = description };

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
            {
                if (tarefa.Id == id)
                {
                    await tarefasRepository.UpdateTarefa(tarefa, id);

                    TempData["MensagemDeSucesso"] = "Tarefa atualizada com sucesso!"; 
                }
            }
            else
            {
                TempData["MensagemDeErro"] = "Por favor, preencha todos os campos.";
            }

            return RedirectToAction("Listar");
        }

        [HttpPost]
        public async Task<IActionResult> Apagar(int id)
        {
            await tarefasRepository.DeleteTarefa(id);

            return RedirectToAction("Listar"); 
        }
    }
}
