namespace BlazorTasks.API.DTO
{
    public class UpdateTaskDTO
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public bool Done { get; set; }
    }
}
