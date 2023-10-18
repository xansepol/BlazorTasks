using BlazorTasks.API.DTO;
using BlazorTasks.API.Repositories;
using BlazorTasks.Core.Factories;
using BlazorTasks.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorTasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TaskController : ControllerBase
    {
        TaskRepository _repository;

        public TaskController(TaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var task = await _repository.Get(id);
            if(task is null)
                return NotFound();

            return Ok(task);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _repository.GetAll();
            if (tasks is null || tasks.Length == 0)
                return NotFound();

            return Ok(tasks);
        }

        [HttpPut]
        public async Task<IActionResult> Create(TaskDTO task)
        {
            if (string.IsNullOrWhiteSpace(task.Description))
                return BadRequest();

            TaskModel newTask = FactoryTask.CreateNew(task.Description);

            bool created = await _repository.Create(newTask);
            if (created)
                return Ok(newTask);
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTaskDTO task)
        {
            if (String.IsNullOrWhiteSpace(task.Description))
                return BadRequest();

            return Ok(await _repository.Update(FactoryTask.CreateNew(task.Id, task.Description, task.Done)));
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.Delete(id);
            return Ok();
        }

    }
}
