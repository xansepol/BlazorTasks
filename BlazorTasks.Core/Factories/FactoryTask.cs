using BlazorTasks.Core.Models;

namespace BlazorTasks.Core.Factories
{
    public static class FactoryTask
    {
        public static TaskModel CreateNew(string description) =>
            new(){ 
                Id = new Guid(),
                Description = description,
                Done = false,
                EntryDate = DateTime.UtcNow
            };

        public static TaskModel CreateNew(Guid id, string description, bool done) =>
            new()
            {
                Id = id,
                Description = description,
                Done = done,
                EntryDate = DateTime.UtcNow
            };
    }
}
