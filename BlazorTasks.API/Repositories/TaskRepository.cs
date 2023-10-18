using BlazorTasks.API.Data;
using BlazorTasks.Core.Models;
using BlazorTasks.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorTasks.API.Repositories
{
    public class TaskRepository : IDataRepository<TaskModel>
    {
        private AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(TaskModel item)
        {
            await _context.Tasks.AddAsync(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task Delete(Guid id)
        {
            var task = await Get(id);
            if(task is not null)
            {
                _context.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TaskModel?> Get(Guid id) =>
            await _context.Tasks.SingleOrDefaultAsync(item => item.Id == id);

        public async Task<TaskModel[]> GetAll() => await _context.Tasks.ToArrayAsync();
        

        public async Task<TaskModel> Update(TaskModel item)
        {
            var task = await Get(item.Id) ?? throw new Exception("Task not found");

            task.Description = item.Description;
            task.EntryDate = item.EntryDate;
            task.Done = item.Done;

            await _context.SaveChangesAsync();

            return task;
        }
    }
}
