using TodoList.API.Models.Enums;

namespace TodoList.API.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TodoStatus Status { get; set; } = TodoStatus.Pending;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
