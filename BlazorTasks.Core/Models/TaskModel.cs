namespace BlazorTasks.Core.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public bool Done { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
